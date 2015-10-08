$(function () {
    // Validation
    $("#forgot-password-form").validate({
        ignore: '.skip',
        // Rules for form validation
        rules: {
            username: {
                required: true
            },
            hiddenRecaptcha: {
                required: function () {
                    return grecaptcha.getResponse() == '';
                }
            }
        },

        // Do not change code below
        errorPlacement: function (error, element) {
            error.insertAfter(element.parent());
        },

        submitHandler: function (form) {
            $('#formSubmit').prop('disabled', true);
            if (grecaptcha.getResponse().length > 0) form.submit();
        }
    });
});