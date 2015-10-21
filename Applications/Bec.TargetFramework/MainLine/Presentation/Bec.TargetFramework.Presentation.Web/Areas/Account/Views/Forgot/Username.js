
$(function () {
    // Validation
    $("#username-form").validate({
        ignore: '.skip',
        // Rules for form validation
        rules: {
            email: {
                required: true,
                email: true
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
            if (grecaptcha.getResponse().length > 0) {
                $('#formSubmit').prop('disabled', true);
                form.submit();
            }
        }
    });
});