$(function () {
    'use strict';

    $("input[name='selCorrect']").change(function () {
        $('#continueButton').prop('disabled', false);
    });

    $('#continueButton').on('click', function () {
        if ($('#radioYes').is(":checked")) {
            $('#continueButton').prop('disabled', true);
            ajaxWrapper({
                url: $('#confirmDetails-form').data("url"),
                data: $('#confirmDetails-form').serializeArray(),
                method: "POST"
            }).done(function () {
                window.location = $("#confirmDetails-form").data("redirectto");
            }).fail(function (e) {
                if (!hasRedirect(e.responseJSON)) {
                    showtoastrError();
                }
            }).always(function () {
                $('#continueButton').prop('disabled', false);
            });
        }
        else {
            $('#checkBankAccountBtn').click();
            hideCurrentModal();
        }
    });
});
