$(function () {
    var viewMessagesContainer = $('#viewMessagesContainer');
    var currentConversation = {
        id: null,
        subject: null,
        activityId: null
    };
    var activityType = viewMessagesContainer.data('activity-type');
    var urls = {
        templateUrl: viewMessagesContainer.data("templateurl"),
        conversationUrl: viewMessagesContainer.data("conversations-url"),
        messagesUrl: viewMessagesContainer.data("messages-url"),
        participantsUrl: viewMessagesContainer.data("participants-url")
    };
    var getParticipantsPromise = $.Deferred();

    setupDataReload(viewMessagesContainer);
    setupWindowToggling();
    setupReply();
    setupCreateConversation();
    setupRefreshConversationsBtn();

    function loadConversations(activityId) {
        var conversationsTemplatePromise = $.Deferred();
        ajaxWrapper(
            { url: urls.templateUrl + '?view=' + getRazorViewPath('_conversationsTmpl', 'Messages', 'Admin') }
        ).done(function (res) {
            conversationsTemplatePromise.resolve(Handlebars.compile(res));
        });

        $('#conversationsSpinner').show();
        $('#conversationsError').hide();
        return ajaxWrapper({
            url: urls.conversationUrl,
            type: 'GET',
            data: {
                activityType: activityType,
                activityId: activityId,
                page: 0,
                pageSize: 10
            }
        })
        .success(function (items) {
            items = _.map(items, function (item) {
                return _.extend({}, item, {
                    Latest: dateString(item.Latest)
                });
            });
            var templateData = {
                isEmpty: items.length === 0,
                items: items
            };

            conversationsTemplatePromise.done(function (template) {
                var html = template(templateData);
                $('#conversationsList').html(html);
            });
        })
        .error(function (data) {
            $('#conversationsError').show();
            console.log(data);
        })
        .always(function () {
            $('#conversationsSpinner').hide();
        });
    }

    function loadMessages(conversation) {
        var messagesTemplatePromise = $.Deferred();
        ajaxWrapper(
            { url: urls.templateUrl + '?view=' + getRazorViewPath('_messagesTmpl', 'Messages', 'Admin') }
        ).done(function (res) {
            messagesTemplatePromise.resolve(Handlebars.compile(res));
        });

        $('#messagesSpinner').show();
        return ajaxWrapper({
            url: urls.messagesUrl,
            type: 'GET',
            data: {
                conversationId: conversation.id,
                page: 0,
                pageSize: 10
            }
        })
        .success(function (items) {
            $.each(items, function (i, item) {
                switch (item.Message.OrganisationType) {
                    case 'Personal':
                        switch (item.Message.UserType) {
                            case "Giftor": item.icon = 'fa-gift'; break;
                            default: item.icon = 'fa-home'; break;
                        }
                        break;
                    case "Professional":
                        item.icon = 'fa-building';
                        break;
                }
                item.Message.DateSent = dateString(item.Message.DateSent);
                item.Unread = item.Reads.length == 0;
                $.each(item.Reads, function (j, r) {
                    if (r.AcceptedDate) r.AcceptedDate = dateString(r.AcceptedDate);
                });
            });

            var templateData = {
                isEmpty: items.length === 0,
                items: items,
                conversation: conversation
            };

            messagesTemplatePromise.done(function (template) {
                var html = template(templateData);
                $('#messagesList').html(html);
            });
        })
        .error(function (data) {
            console.log(data);
        })
        .always(function () {
            $('#messagesSpinner').hide();
        });
    }

    function setupCreateConversation() {
        var createConversationTemplatePromise = $.Deferred();
        ajaxWrapper(
            { url: urls.templateUrl + '?view=' + getRazorViewPath('_createConversationTmpl', 'Messages', 'Admin') }
        ).then(function (res) {
            createConversationTemplatePromise.resolve(Handlebars.compile(res));
        });
        
        $('#createConversationButton').click(function () {
            if (isCompactView() && !isMessageBoxOpen()) {
                hideConversationsBox();
                showMessagesBoxCompact();
            }

            $.when(createConversationTemplatePromise, getParticipantsPromise).done(function (template, participants) {
                var templateData = {
                    activityType: activityType,
                    activityId: currentConversation.activityId,
                    participantUaoIds: [participants[0].UserAccountOrganisationID]
                };
                var html = template(templateData);
                $('#messagesList').html(html);
                setupNewConversationForm();
            })
        });
    }

    function setupRefreshConversationsBtn() {
        $('#refreshConversationsButton').click(function () {
            loadConversations(currentConversation.activityId);
        })
    }

    function setupNewConversationForm(){
        var newConversationForm = $('#newConversationForm');
        var submitNewConversation = $("#submitNewConversationBtn");

        submitNewConversation.click(function () {
            newConversationForm.submit();
        });

        newConversationForm.validate({
            ignore: '.skip',
            // Rules for form validation
            rules: {
                "Subject": {
                    required: true
                },
                "Message": {
                    required: true
                },
            },

            // Do not change code below
            errorPlacement: function (error, element) {
                error.insertAfter(element.parent());
            },

            submitHandler: submitForm
        });

        function submitForm(form) {
            submitNewConversation.prop('disabled', true);
            var formData = newConversationForm.serializeArray();
            ajaxWrapper({
                url: newConversationForm.data("url"),
                type: "POST",
                data: formData
            }).done(function (res) {
                console.log(res);
                if (res.result === true) {
                    loadConversations(currentConversation.activityId).then(selectLatestConversation);

                    // show the message
                } else {
                    // handle error
                }
            }).fail(function (e) {
                console.log(e);
                if (!hasRedirect(e.responseJSON)) {
                    console.log(e);
                    handleModal({ url: newConversationForm.data("message") + "?title=Error&message=" + e.statusText + "&button=Back" }, {
                        messageButton: function () {
                            submitNewConversation.prop('disabled', false);
                        }
                    }, true);
                }
            });
        }
    }

    function selectLatestConversation() {
        $('#conversationsList .conversation-item').first().trigger('click');
    }

    function setupReply() {
        $('#viewMessagesContainer').on('click', '#replyButton', function (e) {
            var replyForm = $("#replyForm");
            var replyBtn = $("#replyButton");

            replyForm.validate({
                ignore: '.skip',
                rules: {
                    "Message": {
                        required: true
                    },
                },
                // Do not change code below
                errorPlacement: function (error, element) {
                    error.insertAfter(element.parent());
                },

                submitHandler: submitForm
            });
            function submitForm(form) {
                replyBtn.prop('disabled', true);
                var formData = replyForm.serializeArray();

                ajaxWrapper({
                    url: replyForm.data('url'),
                    type: "POST",
                    data: formData
                }).success(function () {
                    loadMessages(currentConversation).then(scrollToLastMessage);
                    replyForm.find('textarea').val('');
                }).done(function (res) {

                }).fail(function (e) {
                    if (!hasRedirect(e.responseJSON)) {
                        console.log(e);
                    }
                });
            }
        });
    }

    function scrollToLastMessage() {
        var messagesListElement = $('#messagesList .messages-list');
        var mostRecentItem = $('#messagesList .messages-list .row:last');
        messagesListElement.scrollTo(mostRecentItem, 0);
    }

    function setupDataReload(container) {
        var isActivitySpecificView = container.data("is-activity-specific");
        if (isActivitySpecificView) {
            // capturing the event from any parent views and refresh the view
            container.parent().on('activitychange', function (event, activityId) {
                loadConversations(activityId);
                fetchParticipants(activityId);
                currentConversation.activityId = activityId;
            });
        } else {
            loadConversations();
        }
    }

    function fetchParticipants(activityId) {
        getParticipantsPromise = ajaxWrapper({
            url: urls.participantsUrl,
            data: {
                activityId: activityId,
                activityType: activityType
            }
        });
    }

    // the functions related to toggling strictly depend on the bootstrap classes so any change to these may break the function
    function setupWindowToggling() {
        $('#viewMessagesContainer').on('click', '.conversation-item', function (e) {
            if (isCompactView() && !isMessageBoxOpen()) {
                hideConversationsBox();
                showMessagesBoxCompact();
            }

            currentConversation.id = $(this).data('conversation-id');
            currentConversation.subject = $(this).data('conversation-subject');
            loadMessages(currentConversation).then(scrollToLastMessage);
        });

        $('#messagesContainer').on('click', '#conversationSubject', function () {
            if (isCompactView()) {
                hideMessagesBoxCompact();
                showConversationsBox();
            }
        });

    }

    function isCompactView() {
        return $('#conversationSubject i').is(':visible');
    }

    function isMessageBoxOpen() {
        return !$('#messagesContainer').hasClass('col-xs-0');
    }

    function showMessagesBoxCompact() {
        $('#messagesContainer').addClass('col-xs-12');
        $('#messagesContainer').removeClass('col-xs-0 col-sm-0');
    }

    function hideMessagesBoxCompact() {
        $('#messagesContainer').addClass('col-xs-0 col-sm-0');
        $('#conversationsContainer').removeClass('col-xs-12');
    }

    function showConversationsBox() {
        $('#conversationsContainer').removeClass('col-xs-0 col-sm-0');
    }

    function hideConversationsBox() {
        $('#conversationsContainer').addClass('col-xs-0 col-sm-0');
    }
});
