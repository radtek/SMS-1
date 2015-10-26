$(function () {
    findModalLinks();

    $('.format-date').each(function () {
        $(this).text(dateStringNoTime($(this).data("val")));
    });

    $('.format-number').each(function () {
        $(this).text(formatCurrency($(this).data("val")));
    });

});