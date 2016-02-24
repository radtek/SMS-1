$(function () {
    'use strict';
    var latestConversationsContainer = $('#latestConversationsContainer'),
        latestConversationsError = $('#latestConversationsError'),
        loadConversationsUrl = latestConversationsContainer.data('load-conversations-url'),
        unreadCountElement = $('#unreadConversationsCountId'),
        getUnreadCountUrl = unreadCountElement.data('get-unread-count-url');

    refresh();
    setupMarkAsRead();
    pollForNotifications();

    function setupMarkAsRead() {
        $('body').on('conversationsChanged', refresh);
    }

    function refresh() {
        var loadConversationsDeferred = loadConversations();
        var updateUnreadCountDeferred = updateUnreadCount();
        return $.when(loadConversationsDeferred, updateUnreadCountDeferred);
    }

    function loadConversations() {
        latestConversationsError.hide();
        return ajaxWrapper({
            url: loadConversationsUrl
        })
        .then(function (result) {
            latestConversationsContainer.html(result);
        }).fail(function (e) {
            latestConversationsError.show();
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

    function pollForNotifications() {
        setTimeout(function () {
            refresh().always(pollForNotifications);
        }, 10000);
    }
});
