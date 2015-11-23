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
            { url: urls.templateUrl + '?view=_conversationsTmpl' }
        ).done(function (res) {
            conversationsTemplatePromise.resolve(Handlebars.compile(res));
        });

        $('#conversationsSpinner').show();
        $('#conversationsError').hide();
        ajaxWrapper({
            url: urls.conversationUrl,
            type: 'GET',
            data: {
                activityId: activityId
            }
        })
        .success(function (data) {
            var items = data.Items;
            
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
            { url: urls.templateUrl + '?view=_messagesTmpl' }
        ).done(function (res) {
            messagesTemplatePromise.resolve(Handlebars.compile(res));
        });

        $('#messagesSpinner').show();
        return ajaxWrapper({
            url: urls.messagesUrl,
            type: 'GET',
            data: {
                conversationId: conversation.id
            }
        })
        .success(function (data) {
            var items = data.Items;
            items = _.map(items, function (item) {
                var notificationData = JSON.parse(item.NotificationData);
                return _.extend({}, item, {
                    message: notificationData.Message
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
                }).success(function(){
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

    function setupWindowToggling() {
        $('#viewMessagesContainer').on('click', '.conversation-item', function (e) {
            if (!isMessageBoxOpen()) {
                $('#messagesContainer').toggleClass('col-lg-offset-0 col-lg-offset-6');
                if (isCompactView()) {
                    $('#conversationsContainer').toggleClass('col-xs-12 col-lg-6 col-xs-0');
                    $('#messagesContainer').toggleClass('col-xs-0 col-xs-12');
                } else {
                    $('#conversationsContainer').toggleClass('col-lg-6 col-xs-4');
                    $('#messagesContainer').toggleClass('col-xs-0 col-xs-8');
                }
            }

            currentConversation.id = $(this).data('conversation-id');
            currentConversation.subject = $(this).data('conversation-subject');
            loadMessages(currentConversation).then(scrollToLastMessage);
        });

        $('#conversationSubject').click(function () {
            if (isCompactView()) {
                $('#messagesContainer').toggleClass('col-lg-offset-0 col-lg-offset-6');
                $('#conversationsContainer').toggleClass('col-xs-12 col-lg-6 col-xs-0');
                $('#messagesContainer').toggleClass('col-xs-0 col-xs-12');
            }
        });

        $(window).on('resize', function () {

            if (isMessageBoxOpen()) {
                if (isCompactView()) {

                    if ($('#messagesContainer').hasClass('col-xs-8')) {
                        $('#messagesContainer').toggleClass('col-xs-12 col-xs-8');
                    }

                    if ($('#conversationsContainer').hasClass('col-xs-12')) {
                        $('#conversationsContainer').toggleClass('col-xs-12 col-lg-4 col-xs-0');
                    }

                } else {
                    if ($('#messagesContainer').hasClass('col-xs-12')) {
                        $('#messagesContainer').toggleClass('col-xs-12 col-xs-8');
                    }

                    if ($('#conversationsContainer').hasClass('col-xs-0')) {
                        $('#conversationsContainer').toggleClass('col-xs-12 col-lg-4 col-xs-0');
                    }
                }
            }
        });
    }

    function isCompactView() {
        return $('#conversationSubject i').is(':visible');
    }

    function isMessageBoxOpen() {
        return !$('#messagesContainer').hasClass('col-xs-0');
    }
});
