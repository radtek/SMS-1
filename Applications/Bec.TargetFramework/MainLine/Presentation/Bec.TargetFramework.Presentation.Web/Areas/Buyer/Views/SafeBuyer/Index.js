$(function () {
    findModalLinks();

    $('.format-date').each(function () {
        $(this).text(dateStringNoTime($(this).data("val")));
    });

    $('.format-number').each(function () {
        $(this).text(formatCurrency($(this).data("val")));
    });

    $('.notify-button').each(function () {
        $(this).on('click', function () {
            var index = $(this).data('index');
            var url = $(this).data('href');
            $('#post-no-match-' + index).show();
            $('#notify-button-' + index).hide();
           
            ajaxWrapper({
                url: url + "&accountNumber=" + $('#accountNumberNoMatch-' + index).text() + "&sortCode=" + $('#sortCodeNoMatch-' + index).text(),
                method: "POST"
            });
        });
    });

});