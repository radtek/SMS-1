﻿$(function () {
    $('.discussion-item').click(function () {
        $('#messagesContainer').show();

        if (isCompactView()) {
            $('#discussionsContainer').hide();
        }
    });

    $('#discussionSubject').click(function () {
        $('#messagesContainer').hide();
        $('#discussionsContainer').show();
    });

    $(window).on('resize', function () {
        if (isCompactView() && $('#messagesContainer').is(':visible')) {
            $('#discussionsContainer').hide();
        } else {
            $('#discussionsContainer').show();
        }
    });

    function isCompactView() {
        return $('#discussionSubject i').is(':visible');
    }
});
