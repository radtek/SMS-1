$(function () {
    console.log('test');
    if (isCompactView()) {

    }

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
        console.log($('#discussionsContainer').parent().innerWidth());
        //return $('#discussionsContainer').parent().innerWidth() < 600;
        return $('#discussionSubject i').is(':visible');// || $('#discussionsContainer').parent().innerWidth() < 700;
    }
});
