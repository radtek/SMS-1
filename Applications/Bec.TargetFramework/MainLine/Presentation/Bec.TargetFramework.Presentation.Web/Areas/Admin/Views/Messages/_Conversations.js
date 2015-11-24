$(function () {
    var currentConversation = {
        id: null,
        subject: null
    };
    var viewMessagesContainer = $('#viewMessagesContainer');
    var urls = {
        templateUrl: viewMessagesContainer.data("templateurl"),
        conversationUrl: viewMessagesContainer.data("conversations-url"),
        messagesUrl: viewMessagesContainer.data("messages-url"),
        replyUrl: viewMessagesContainer.data("reply-url"),
    }

    setupDataReload(viewMessagesContainer);
    setupWindowToggling();
    setupReply();

    function loadConversations(activityId) {
        var conversationsTemplatePromise = $.Deferred();
        ajaxWrapper(
            { url: urls.templateUrl + '?view=' + getRazorViewPath('_conversationsTmpl', 'Messages', 'Admin') }
        ).done(function (res) {
            conversationsTemplatePromise.resolve(Handlebars.compile(res));
        });

        $('#conversationsSpinner').show();
        $('#conversationsError').hide();
        ajaxWrapper({
            url: urls.conversationUrl,
            type: 'GET',
            data: {
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
            items = _.map(items, function (item) {
                var notificationData = JSON.parse(item.NotificationData);
                return _.extend({}, item, {
                    message: notificationData.Message,
                    DateSent: dateString(item.DateSent)
                });
            });
            var templateData = {
                isEmpty: items.length === 0,
                items: items,
                conversation: conversation,
                requestVerificationToken: viewMessagesContainer.data('request-verification-token')
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
                    url: urls.replyUrl,
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
            });
        } else {
            loadConversations();
        }
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
