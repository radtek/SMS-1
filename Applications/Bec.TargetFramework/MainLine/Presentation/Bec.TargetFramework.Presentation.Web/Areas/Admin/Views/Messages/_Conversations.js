$(function () {
    'use strict';

    var viewMessagesContainer = $('#viewMessagesContainer'),
        conversationsContainer = $('#conversationsContainer'),
        converationsList = $('#conversationsList'),
        conversationsSpinner = $('#conversationsSpinner'),
        conversationsError = $('#conversationsError'),
        messagesContainer = $('#messagesContainer'),
        messagesList = $('#messagesList'),
        getMessagesSpinner = function () { return $('#messagesSpinner'); },
        getNewConversationError = function () { return $('#newConversationError'); },
        createConversationButton = $('#createConversationButton'),
        targetConversationId = viewMessagesContainer.data('target-conversation-id');
    var currentConversation = {
        id: null,
        subject: null
    };
    var currentActivity = {
        activityType: viewMessagesContainer.data('activity-type'),
        activityId: viewMessagesContainer.data('activity-id')
    };
    var urls = {
        templateUrl: viewMessagesContainer.data("templateurl"),
        conversationUrl: viewMessagesContainer.data("conversations-url"),
        messagesUrl: viewMessagesContainer.data("messages-url"),
        recipientsUrl: viewMessagesContainer.data("recipients-url"),
        convRankUrl: viewMessagesContainer.data("convrank-url"),
        participantsUrl: viewMessagesContainer.data("participants-url")
    };

    var conversationsTemplatePromise = getTemplatePromise('_conversationsTmpl');
    var emptyMessageTemplatePromise = getTemplatePromise('_emptyMessagesTmpl');
    var itemTemplatePromise = getTemplatePromise('_itemTmpl');
    var messagesTemplatePromise = getTemplatePromise('_messagesTmpl');
    var createConversationTemplatePromise = getTemplatePromise('_createConversationTmpl');

    var getRecipientsPromise = $.Deferred();

    var dataSource = new kendo.data.DataSource({
        type: "odata-v4",
        transport: {
            read: function (options) {
                var d = kendo.data.transports['odata-v4'].parameterMap(options.data);
                delete d['$inlinecount'];
                d['$count'] = true;

                _.extend(d, {
                    activityId: currentActivity.activityId,
                    activityType: currentActivity.activityType
                });

                var ajaxOptions = {
                    url: urls.conversationUrl,
                    data: d
                };
                ajaxWrapper(ajaxOptions)
                    .then(function (result) {
                        options.success(result);
                    }, function (data) {
                        options.error(data);
                    });
            }
        },
        serverSorting: false,
        serverPaging: true,
        pageSize: 10,
        change: selectCurrentOrLatestConversation,
        schema: { data: "Items", total: "Count" },
    });
    
    if (!isActivitySpecificView() && canLoadConversations()) {
        loadConversations();
    }

    var pager = $('#conversationsPager').kendoPager({
        dataSource: dataSource,
        refresh: true
    }).data('kendoPager');

    var messagesPageSize = 10;
    var messagesPage = 0;
    var allLoaded = false;
    var jumpedPage = false;

    setupDataReload();
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

    function canCreateNewConversation() {
        return !!currentActivity.activityId;
    }

    function canLoadConversations() {
        return viewMessagesContainer.is(':visible');
    }

    function isActivitySpecificView() {
        return viewMessagesContainer.data("is-activity-specific");
    }

    function loadConversations() {
        conversationsSpinner.show();
        conversationsError.hide();
        dataSource.read();
        if (canCreateNewConversation()) {
            getRecipientsPromise = getRecipients();
    }
    }

    function loadMessages() {
        allLoaded = false;
        messagesPage = 0;
        return loadItems();
    }

    function loadItems() {
        var ret = $.Deferred();
        if (allLoaded) return ret.resolve([]);        

        ajaxWrapper({
            url: urls.messagesUrl,
            type: 'GET',
            data: {
                conversationId: currentConversation.id,
                page: messagesPage,
                pageSize: messagesPageSize
            }
        })
        .success(function (items) {
            if (items.length < messagesPageSize) allLoaded = true;
            messagesPage = messagesPage + 1;
            $.each(items, function (i, item) {

                item.Content = JSON.parse(item.Message.NotificationData);

                switch (item.Message.NotificationConstructName) {
                    case 'Message': item.isMessage = true; break;
                    case 'BankAccountMarkedAsSafe': item.isBaSafe = true; break;
                    case 'BankAccountMarkedAsFraudSuspicious': item.isBaFraud = true; break;
                    case 'BankAccountCheckNoMatch': r = item.isBaNoMatch = true; break;
                }

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
                    default:
                        item.icon = 'fa-comment-o';
                        item.Message.FirstName = "Safe Move Scheme";
                        item.Message.UserType = "Safe Move Scheme"
                        break;
                }
                item.Message.DateSent = dateString(item.Message.DateSent);
                item.Unread = item.Reads.length == 0;


                $.each(item.Reads, function (j, r) {
                    if (r.AcceptedDate) r.AcceptedDate = dateString(r.AcceptedDate);
                });
            });
            ret.resolve(items);
        })
        .error(function (data) {
            console.log(data);
        });
        return ret;
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
            var messagesSpinner = getMessagesSpinner();
            messagesSpinner.show();
            $.when(createConversationTemplatePromise, getRecipientsPromise).done(function (template, recipientsResponse) {
                var templateData = {
                    activityType: currentActivity.activityType,
                    activityId: currentActivity.activityId,
                    recipients: recipientsResponse[0]
                };
                var html = template(templateData);
                messagesList.html(html);
                setupNewConversationForm();
                messagesSpinner.hide();
            })
        });
    }

    function setupNewConversationForm() {
        var newConversationForm = $('#newConversationForm');
        var submitNewConversation = $("#submitNewConversationBtn");

        $('#conversationRecipients').select2();
        $("#conversationRecipients").on("select2-close", function () {
            $(this).valid();
        });
        $('#newConversationMessage').on('keyup', function () {
            autoresizeTextarea($(this));
        });

        newConversationForm.validate({
            ignore: '.skip',
            // Rules for form validation
            rules: {
                "RecipientUaoIds[]": {
                    required: true
                },
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
            var newConversationError = getNewConversationError();
            newConversationError.hide();
            var messagesSpinner = getMessagesSpinner();
            messagesSpinner.show();

            var formData = newConversationForm.serializeArray();
            ajaxWrapper({
                url: newConversationForm.data("url"),
                type: "POST",
                data: formData
            }).done(function (res) {
                if (res.result === true) {
                    targetConversationId = null;
                    pager.page(1);
                } else {
                    showNewConversationError();
                }
                messagesSpinner.hide();
            }).fail(function (e) {
                console.log(e);
                showNewConversationError();
            });

            var showNewConversationError = function () {
                newConversationError.show();
                submitNewConversation.prop('disabled', false);
            }
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
        publishConversationsChangedEvent();

        var conversations = $('#conversationsList .conversation-item');
        if (targetConversationId) {
            conversations = conversations.filter(function () {
                return $(this).data('conversation-id') == targetConversationId;
            });

            if (conversations.length == 1) {
                conversations.first().trigger('click');
                targetConversationId = null;
            } else if (!jumpedPage) {
                jumpedPage = true;
                ajaxWrapper({
                    url: urls.convRankUrl,
                    data: {
                        convID: targetConversationId
                    }
                }).success(function (data) {
                    var page = getPageFromRow(data, messagesPageSize);
                    pager.page(page);
                });
            }
        } else {
            conversations.first().trigger('click');
        }
    }

    function autoresizeTextarea(textarea) {
        textarea.height(0);
        textarea.height(textarea[0].scrollHeight - 10);
    }

    function setupReply() {
        viewMessagesContainer.on('keyup', '#replyMessageTextArea', function () {
            autoresizeTextarea($(this));
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
                    targetConversationId = currentConversation.id;
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
                showMessagesSpinner();
                loadItems().then(function (items) {
                    populateContainer($('#itemsContainer'), items);
                })
                .always(hideMessagesSpinner);
            }
        });
    }

    function setupDataReload() {
        if (isActivitySpecificView()) {
            // capturing the event from any parent views and refresh the view
            viewMessagesContainer.parent().on('activitychange', function (event, activityId) {
                resetCurrentConversation();
                currentActivity.activityId = activityId;

                if (canLoadConversations()) {
                    loadConversations();
                }
            });
        }

        viewMessagesContainer.parent().on('loadConversations', function (event, activityId) {
            loadConversations();
        });
    }

    function getRecipients() {
        return ajaxWrapper({
            url: urls.recipientsUrl,
            data: {
                activityId: currentActivity.activityId,
                activityType: currentActivity.activityType
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
            var conv = $(this);
            setConversationItemActive(conv);
            markConversationAsRead(conv);
            currentConversation.id = conv.data('conversation-id');
            currentConversation.subject = conv.data('conversation-subject');
            currentConversation.link = conv.data('conversation-link');
            currentConversation.linkdescription = conv.data('conversation-link-description');
            currentConversation.issystemmessage = conv.data('conversation-issystemmessage');

            showMessagesSpinner();
            $.when(getParticipantDetails(), loadMessages())
            .then(compileTemplates)
            .then(scrollToLastOrFirstUnreadMessage)
            .always(hideMessagesSpinner);
        });

        messagesContainer.on('click', '#conversationSubject', function () {
            if (isCompactView()) {
                hideMessagesBoxCompact();
                showConversationsBox();
            }
        });
    }

    function showMessagesSpinner() {
        getMessagesSpinner().show();
    }

    function hideMessagesSpinner() {
        getMessagesSpinner().hide();
    }

    function getParticipantDetails() {
        return ajaxWrapper({
            url: urls.participantsUrl,
            data: {
                conversationId: currentConversation.id
            }
        });
    }

    function compileTemplates(participantsAjax, messages) {
        currentConversation.participants = participantsAjax[0];
        messagesTemplatePromise.done(function (template) {
            var html = $(template({
                conversation: currentConversation
            }));
            populateContainer(html.find('#itemsContainer'), messages);
            messagesList.html(html);
        });
    }

    function setConversationItemActive(selectedItem) {
        $('.conversation-item').removeClass('active');
        selectedItem.addClass('active');
    }

    function publishConversationsChangedEvent() {
        $('body').trigger('conversationsChanged');
    }

    function markConversationAsRead(selectedItem) {
        if (!selectedItem.hasClass('unread')) {
            return;
        }

        setTimeout(function () {
            selectedItem.removeClass('unread');
            publishConversationsChangedEvent();
        }, 3000);
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
