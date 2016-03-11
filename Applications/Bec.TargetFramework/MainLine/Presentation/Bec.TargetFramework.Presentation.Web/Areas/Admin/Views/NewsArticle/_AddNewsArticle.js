﻿$(function () {
    makeDatePicker("#dateTimeInput", {
        maxDate: new Date()
    });

    // submit from when Save button clicked
    $("#submitAddNewsArticle").click(function () {
        $("#addNewsArticleForm").submit();
    });

    // Validation
    $("#addNewsArticleForm").validate({
        ignore: '.skip',
        // Rules for form validation
        rules: {
            Title: {
                required: true
            },
            Content: {
                required: true
            },
            DateTime: {
                required: true
            }
        },

        // Do not change code below
        errorPlacement: function (error, element) {
            error.insertAfter(element.parent());
        },

        submitHandler: validateSubmit
    });

    function validateSubmit(form) {
        $("#submitAddNewsArticle").prop('disabled', true);

        var formData = $("#addNewsArticleForm").serializeArray();
        fixDate(formData, 'DateTime', "#dateTimeInput");

        ajaxWrapper({
            url: $("#addNewsArticleForm").data("url"),
            type: "POST",
            data: formData
        }).done(function (res) {
            if (res.result === true)
                window.location = $("#addNewsArticleForm").data("redirectto") + "?selectedNewsArticleID=" + res.selectedNewsArticleID;
            else {
                handleModal({ url: $("#addNewsArticleForm").data("message") + "?title=" + res.title + "&message=" + res.message + "&button=Back" }, {
                    messageButton: function () {
                        $("#submitAddNewsArticle").prop('disabled', false);
                    }
                }, true);
            }
        }).fail(function (e) {
            if (!hasRedirect(e.responseJSON)) {
                showtoastrError();
                $("#submitAddNewsArticle").prop('disabled', false);
            }
        });
    }
});
