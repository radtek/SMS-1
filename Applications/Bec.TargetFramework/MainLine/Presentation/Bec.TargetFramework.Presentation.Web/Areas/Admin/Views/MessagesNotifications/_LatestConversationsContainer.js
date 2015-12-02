$(function () {
    'use strict';
    var latestConversationsContainer = $('#latestConversationsContainer'),
        latestConversationsError = $('#latestConversationsError');
    var loadConversationsUrl = latestConversationsContainer.data('load-conversations-url');

    loadConversations().then(updateNotificationCount);
    setupMarkAsRead();
    
    function setupMarkAsRead() {
        $('body').on('conversationsChanged', function (event, conversationId) {
            loadConversations().then(updateNotificationCount);
        });
    }

    function loadConversations() {
        latestConversationsError.hide();
        return ajaxWrapper({
            url: loadConversationsUrl
        })
        .then(function (result) {
            latestConversationsContainer.html(result);
        }, function (data) {
            // error
            console.log(data);
            latestConversationsError.show();
        });
    }

    function updateNotificationCount() {
        var countElement = $('#unreadConversationsCountId');
        var currentCount = countElement.text();
        var newCount = $('#latestConversationsList li[data-conversation-id]').length;

        countElement.text(newCount);
        countElement.removeClass('bounceIn');
        if (currentCount != newCount) {
            countElement.toggleClass('bg-color-red', !!newCount);
            countElement.addClass('bounceIn');
        }
    }
});
