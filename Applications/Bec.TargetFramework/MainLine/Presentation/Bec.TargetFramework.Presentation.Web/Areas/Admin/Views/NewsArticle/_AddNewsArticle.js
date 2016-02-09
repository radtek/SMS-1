$(function () {
    makeDatePicker("#dateTimeInput", {
        maxDate: new Date()
    });

    // submit from when Save button clicked
    $("#submitAddNewsArticle").click(function () {
        console.log('test');
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

        form.submit();
    }
});
