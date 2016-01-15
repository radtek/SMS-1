$(function () {
    'use strict';

    $("input[name='selCorrect']").change(function () {
        $('#continueButton').prop('disabled', false);
    });

    $('#continueButton').on('click', function () {
        if ($('#radioYes').is(":checked")) {
            ajaxWrapper({
                url: $('#confirmDetails-form').data("url"),
                method: "POST"
            }).done(function () {
                showAudit();
                hideCurrentModal();
            });
        }
        else {
            $('#conf').click();
            hideCurrentModal();
        }
    });
});
