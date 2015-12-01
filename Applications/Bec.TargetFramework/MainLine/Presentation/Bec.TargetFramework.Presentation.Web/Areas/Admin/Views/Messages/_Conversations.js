$(function () {
    var viewMessagesContainer = $('#viewMessagesContainer'),
        conversationsContainer = $('#conversationsContainer'),
        converationsList = $('#conversationsList'),
        conversationsSpinner = $('#conversationsSpinner'),
        conversationsError = $('#conversationsError'),
        messagesContainer = $('#messagesContainer'),
        messagesList = $('#messagesList'),
        createConversationButton = $('#createConversationButton'),
        selectedConversationId = viewMessagesContainer.data('selected-conversation-id');
    var currentConversation = {
        id: selectedConversationId || null,
        subject: null,
        activityId: null
    };
    var activityType = viewMessagesContainer.data('activity-type');
    var urls = {
        templateUrl: viewMessagesContainer.data("templateurl"),
        conversationUrl: viewMessagesContainer.data("conversations-url"),
        messagesUrl: viewMessagesContainer.data("messages-url"),
        participantsUrl: viewMessagesContainer.data("participants-url"),
        convRankUrl: viewMessagesContainer.data("convrank-url"),
    };
    var getParticipantsPromise = $.Deferred();

    var conversationsTemplatePromise = getTemplatePromise('_conversationsTmpl');
    var emptyMessageTemplatePromise = getTemplatePromise('_emptyMessagesTmpl');
    var itemTemplatePromise = getTemplatePromise('_itemTmpl');
    var messagesTemplatePromise = getTemplatePromise('_messagesTmpl');
    var createConversationTemplatePromise = getTemplatePromise('_createConversationTmpl');

    var dataSource = new kendo.data.DataSource({
        type: "odata-v4",
        transport: {
            read: urls.conversationUrl
        },
        serverSorting: true,
        serverPaging: true,
        pageSize: 10,
        change: selectCurrentOrLatestConversation,
        schema: { data: "Items", total: "Count" },
    });

    var isActivitySpecificView = viewMessagesContainer.data("is-activity-specific");
    if(!isActivitySpecificView) loadConversations(currentConversation.activityId);

    var pager = $('#conversationsPager').kendoPager({
        dataSource: dataSource,
        refresh: true
    }).data('kendoPager');

    var messagesPageSize = 10;
    var messagesPage = 0;
    var allLoaded = false;
    var jumpedPage = false;

    setupDataReload(viewMessagesContainer);
    setupWindowToggling();
    setupReply();
    setupCreateConversation();

    function resetCurrentConversation() {
        for (var p in currentConversation) {
            if (currentConversation.hasOwnProperty(p)) {
                currentConversation[p] = null;
            }
        }
    }

    function loadConversations(activityId) {
        conversationsSpinner.show();
        conversationsError.hide();

        dataSource.read({ activityType: activityType, activityId: activityId });
    }

    function loadMessages(conversation) {
        allLoaded = false;
        messagesPage = 0;
        return loadItems(conversation, true);
    }

    function loadItems(conversation, includeContainer) {
        if (allLoaded) return $.Deferred().resolve();

        var messagesSpinner = $('#messagesSpinner');

        messagesSpinner.show();
        return ajaxWrapper({
            url: urls.messagesUrl,
            type: 'GET',
            data: {
                conversationId: conversation.id,
                page: messagesPage,
                pageSize: messagesPageSize
            }
        })
        .success(function (items) {
            if (items.length < messagesPageSize) allLoaded = true;
            messagesPage = messagesPage + 1;
            $.each(items, function (i, item) {
                switch (item.Message.OrganisationType) {
                    case 'Personal':
                        switch (item.Message.UserType) {
                            case "Giftor": item.icon = 'fa-gift'; break;
                            default: item.icon = 'fa-home'; break;
                        }
                        item.isFromProfessionalUser = false;
                        break;
                    case "Professional":
                        item.icon = 'fa-building';
                        item.isFromProfessionalUser = true;
                        break;
                }
                item.Message.DateSent = dateString(item.Message.DateSent);
                item.Unread = item.Reads.length == 0;
                
                $.each(item.Reads, function (j, r) {
                    if (r.AcceptedDate) r.AcceptedDate = dateString(r.AcceptedDate);
                });
            });

            if (includeContainer) {
                messagesTemplatePromise.done(function (template) {
                    var html = $(template({ conversation: conversation }));
                    populateContainer(html.find('#itemsContainer'), items);
                    messagesList.html(html);
                });
            }
            else populateContainer($('#itemsContainer'), items);

        })
        .error(function (data) {
            console.log(data);
        })
        .always(function () {
            messagesSpinner.hide();
        });
    }

    function populateContainer(itemsContainer, items) {
        itemsContainer.css('overflow-y', 'hidden'); //force user to start their scroll again if dragging thumb
        setTimeout(function () { itemsContainer.css('overflow-y', 'auto'); }, 10);
        itemTemplatePromise.done(function (template) {
            var html = $(template({ items: items.reverse() }));
            itemsContainer.prepend(html);
            var addingHeight = html.outerHeight();
            if (messagesPage > 1) itemsContainer.scrollTop(addingHeight);
        });
    }

    function setupCreateConversation() {
        createConversationButton.click(function () {
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
                messagesList.html(html);
                setupNewConversationForm();
            })
        });
    }

    function setupNewConversationForm() {
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
                if (res.result === true) {
                    currentConversation.id = null;
                    loadConversations(currentConversation.activityId);
                    // show the message
                } else {
                    // handle error
                }
            }).fail(function (e) {
                console.log(e);
                // handle fail
            });
        }
    }

    function selectCurrentOrLatestConversation() {
        var items = dataSource.view();
        var items = _.map(items, function (item) {
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
            converationsList.html(html);
        });
        if (templateData.isEmpty) {
            emptyMessageTemplatePromise.done(function (template) {
                messagesList.html(template());
            });
        }
        conversationsSpinner.hide();
        var conversations = $('#conversationsList .conversation-item');
        if (currentConversation.id) {
            alert(currentConversation.id);
            conversations = conversations.filter(function () {
                return $(this).data('conversation-id') == currentConversation.id;
            });
        }
        if(conversations.length==1)
            conversations.first().trigger('click');
        else if (currentConversation.id && !jumpedPage) {
            jumpedPage = true;
            ajaxWrapper({
                url: urls.convRankUrl,
                data: {
                    convID: currentConversation.id
                }
            }).success(function (data) {
                var page = Math.floor((data - 1) / messagesPageSize) + 1;
                console.log('jump to page: ' + page);
                pager.page(page);
            });
        }
    }

    function autoresizeTextarea(textarea) {
        textarea.style.height = '0px'; //Reset height, so that it not only grows but also shrinks
        textarea.style.height = (textarea.scrollHeight) + 'px'; //Set new height
    }

    function setupReply() {
        viewMessagesContainer.on('keyup', '#replyMessageTextArea', function () {
            autoresizeTextarea(this);
        });

        viewMessagesContainer.on('click', '#replyButton', function (e) {
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
                    pager.page(1);
                    replyForm.find('textarea').val('');
                }).fail(function (e) {
                    if (!hasRedirect(e.responseJSON)) {
                        console.log(e);
                    }
                });
            }
        });
    }

    function scrollToLastOrFirstUnreadMessage() {
        var messagesListElement = $('#messagesList .messages-list .scrollable');
        var messageToFocus = messagesListElement.find('.message-item.unread:first');
        if (messageToFocus.length == 0) {
            messageToFocus = messagesListElement.find('.message-item:last');
        }
        messagesListElement.scrollTo(messageToFocus, 0);
        messagesListElement.scroll(function () {
            if (messagesListElement.scrollTop() == 0) {
                loadItems(currentConversation);
            }
        });
    }

    function setupDataReload(container) {
        var isActivitySpecificView = container.data("is-activity-specific");
        if (isActivitySpecificView) {
            // capturing the event from any parent views and refresh the view
            container.parent().on('activitychange', function (event, activityId) {
                resetCurrentConversation();
                currentConversation.activityId = activityId;
                loadConversations(activityId);
                fetchParticipants(activityId);
            });
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

    function getTemplatePromise(viewName) {
        var def = $.Deferred();
        ajaxWrapper({
            url: urls.templateUrl,
            data: {
                view: getRazorViewPath(viewName, 'Messages', 'Admin')
            }
        }).then(function (res) {
            def.resolve(Handlebars.compile(res));
        });
        return def;
    }

    // the functions related to toggling strictly depend on the bootstrap classes so any change to these may break the function
    function setupWindowToggling() {
        viewMessagesContainer.on('click', '.conversation-item', function (e) {
            if (isCompactView() && !isMessageBoxOpen()) {
                hideConversationsBox();
                showMessagesBoxCompact();
            }
            setConversationItemActive($(this));
            markConversationAsRead($(this));
            currentConversation.id = $(this).data('conversation-id');
            currentConversation.subject = $(this).data('conversation-subject');
            loadMessages(currentConversation).then(scrollToLastOrFirstUnreadMessage);
        });

        messagesContainer.on('click', '#conversationSubject', function () {
            if (isCompactView()) {
                hideMessagesBoxCompact();
                showConversationsBox();
            }
        });
    }

    function setConversationItemActive(selectedItem) {
        $('.conversation-item').removeClass('active');
        selectedItem.addClass('active');
    }

    function markConversationAsRead(selectedItem) {
        setTimeout(function () {
            selectedItem.removeClass('unread');
            $('body').trigger('conversationMarkedAsRead', selectedItem.data('conversation-id'));
        }, 2000);
    }

    function isCompactView() {
        return $('#conversationSubject i').is(':visible');
    }

    function isMessageBoxOpen() {
        return !messagesContainer.hasClass('col-xs-0');
    }

    function showMessagesBoxCompact() {
        messagesContainer.addClass('col-xs-12');
        messagesContainer.removeClass('col-xs-0 col-sm-0');
    }

    function hideMessagesBoxCompact() {
        messagesContainer.addClass('col-xs-0 col-sm-0');
        conversationsContainer.removeClass('col-xs-12');
    }

    function showConversationsBox() {
        conversationsContainer.removeClass('col-xs-0 col-sm-0');
    }

    function hideConversationsBox() {
        conversationsContainer.addClass('col-xs-0 col-sm-0');
    }
});
