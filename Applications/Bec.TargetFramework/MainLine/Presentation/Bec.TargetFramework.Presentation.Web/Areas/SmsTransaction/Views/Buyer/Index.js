﻿$(function(){
    $('.check-bank-form').each(function (i, item) {
        $(item).validate({
            ignore: '.skip',
            // Rules for form validation
            rules: {
                accountNumber: {
                    required: true,
                    digits: true,
                    minlength: 8
                },
                sortCode: {
                    required: true,
                    digits: true,
                    minlength: 6
                }
            },
            submitHandler: validateSubmit
        });
    });

    function validateSubmit(form) {
        $("#submitButton").prop('disabled', true);

        var matchDiv = $('#result-match-' + $(form).data("index"));
        var noMatchDiv = $('#result-no-match-' + $(form).data("index"));
        var serverErrorDiv = $('#result-server-error-' + $(form).data("index"));
        var spinner = $('#spinner-' + $(form).data("index"));

        matchDiv.hide();
        noMatchDiv.hide();
        serverErrorDiv.hide();
        spinner.show();

        var formData = $(form).serializeArray();
        ajaxWrapper({
            url: $(form).data("url"),
            type: "POST",
            data: formData
        }).done(function (res) {
            $("#submitButton").prop('disabled', false);
            spinner.hide();
            if (res.result == true) {
                matchDiv.show();
            }
            else {
                noMatchDiv.show();
            }
        }).fail(function (e) {
            $("#submitButton").prop('disabled', false);
            console.log(e);
            spinner.hide();
            serverErrorDiv.show();
        });
    }
});