$(function () {
    'use strict';

    setupDates();

    function setupDates() {
        $('.format-date').each(function () {
            $(this).text(dateStringNoTime($(this).data("val")));
        });
    }
});
