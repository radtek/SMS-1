$(function () {
    $('body').on('conversationMarkedAsRead', function (event, conversationId) {
        $('#latestConversationsList li').filter(function () {
            return $(this).data('conversation-id') == conversationId;
        }).remove();
        $('#unreadConversationsCountId').text($('#latestConversationsList li[data-conversation-id]').length);
    });
});
