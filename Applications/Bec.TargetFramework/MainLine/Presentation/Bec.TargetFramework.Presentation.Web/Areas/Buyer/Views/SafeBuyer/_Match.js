$(function () {
    'use strict';

    $('#yesButton').on('click', function () {
        window.location = $("#confirmDetails-form").data("redirectto");
    });
});
