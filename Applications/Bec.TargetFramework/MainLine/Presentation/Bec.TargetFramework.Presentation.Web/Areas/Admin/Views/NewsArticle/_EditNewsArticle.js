$(function () {

    function validateSubmit(form) {
        $("#submitEditNewsArticle").prop('disabled', true);
        var formData = $("#editNewsArticleForm").serializeArray();
        fixDate(formData, 'Model.DateTime', "#dateTimeInput");
        ajaxWrapper({
            url: $("#editNewsArticleForm").data("url"),
            type: "POST",
            data: formData
        }).done(function (res) {
            if (res.result === true)
                window.location = $("#editNewsArticleForm").data("redirectto");
            else {
                handleModal({ url: $("#editNewsArticleForm").data("message") + "?title=" + res.title + "&message=" + res.message + "&button=Back" }, {
                    messageButton: function () {
                        $("#submitEditNewsArticle").prop('disabled', false);
                    }
                }, true);
            }
        }).fail(function (e) {
            if (!hasRedirect(e.responseJSON)) {
                showtoastrError();
            }
        });
    }

    // submit from when Save button clicked
    $("#submitEditNewsArticle").click(function () {
        $("#editNewsArticleForm").submit();
    });

    $("#editNewsArticleForm").validate({
        ignore: '.skip',
        // Rules for form validation
        rules: {
            'Model.Title': {
                required: true
            },
            'Model.Content': {
                required: true
            },
            'Model.DateTime': {
                required: true
            }
        },

        // Do not change code below
        errorPlacement: function (error, element) {
            error.insertAfter(element.parent());
        },

        submitHandler: validateSubmit
    });

    makeDatePicker("#dateTimeInput", {
        maxDate: new Date()
    });
});