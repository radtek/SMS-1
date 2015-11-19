$(function () {
    $('.discussion-item').click(function () {

        if (!isMessageBoxOpen()) {
            $('#messagesContainer').toggleClass('col-lg-offset-0 col-lg-offset-6');
            if (isCompactView()) {
                $('#discussionsContainer').toggleClass('col-xs-12 col-lg-6 col-xs-0');
                $('#messagesContainer').toggleClass('col-xs-0 col-xs-12');
            } else {
                $('#discussionsContainer').toggleClass('col-lg-6 col-xs-4');
                $('#messagesContainer').toggleClass('col-xs-0 col-xs-8');
            }
        }
    });

    $('#discussionSubject').click(function () {
        if (isCompactView()) {
            $('#messagesContainer').toggleClass('col-lg-offset-0 col-lg-offset-6');
            $('#discussionsContainer').toggleClass('col-xs-12 col-lg-6 col-xs-0');
            $('#messagesContainer').toggleClass('col-xs-0 col-xs-12');
        }
    });

    $(window).on('resize', function () {

        if (isMessageBoxOpen()){
            if (isCompactView()) {

                if ($('#messagesContainer').hasClass('col-xs-8')) {
                    $('#messagesContainer').toggleClass('col-xs-12 col-xs-8');
                }

                if ($('#discussionsContainer').hasClass('col-xs-12')) {
                    $('#discussionsContainer').toggleClass('col-xs-12 col-lg-4 col-xs-0');
                }

            } else {
                if ($('#messagesContainer').hasClass('col-xs-12')) {
                    $('#messagesContainer').toggleClass('col-xs-12 col-xs-8');
                }

                if ($('#discussionsContainer').hasClass('col-xs-0')) {
                    $('#discussionsContainer').toggleClass('col-xs-12 col-lg-4 col-xs-0');
                }
            }
        }
    });

    function isCompactView() {
        return $('#discussionSubject i').is(':visible');
    }

    function isMessageBoxOpen() {
        return !$('#messagesContainer').hasClass('col-xs-0');
    }
});
