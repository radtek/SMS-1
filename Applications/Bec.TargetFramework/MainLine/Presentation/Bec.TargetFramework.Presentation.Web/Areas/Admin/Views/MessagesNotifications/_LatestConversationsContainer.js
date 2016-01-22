$(function () {
    'use strict';
    var latestConversationsContainer = $('#latestConversationsContainer'),
        latestConversationsError = $('#latestConversationsError'),
        loadConversationsUrl = latestConversationsContainer.data('load-conversations-url'),
        unreadCountElement = $('#unreadConversationsCountId'),
        getUnreadCountUrl = unreadCountElement.data('get-unread-count-url');

    refresh();
    setupMarkAsRead();
    
    function setupMarkAsRead() {
        $('body').on('conversationsChanged', refresh);
    }

    function refresh() {
        loadConversations();
        updateUnreadCount();
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
        }).fail(function (e) {
            if (!hasRedirect(e.responseJSON)) {
                showtoastrError();
            }
        });
    }

    function updateUnreadCount() {
        return ajaxWrapper({
            url: getUnreadCountUrl
        })
        .then(function (result) {
            updateNotificationCount(result);
        }, function (data) {
            // error
            console.log(data);
        }).fail(function (e) {
            if (!hasRedirect(e.responseJSON)) {
                showtoastrError();
            }
        });
    }

    function updateNotificationCount(newCount) {
        var currentCount = unreadCountElement.text();
        if (newCount == currentCount) {
            return;
        }
        unreadCountElement.addClass('animated bounceIn');
        unreadCountElement.text(newCount);
        unreadCountElement.toggle(newCount > 0)
    }
});
