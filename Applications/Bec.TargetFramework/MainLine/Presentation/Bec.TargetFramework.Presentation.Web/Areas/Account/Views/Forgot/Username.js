
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
            $('#formSubmit').prop('disabled', true);
            if (grecaptcha.getResponse().length > 0) form.submit();
        }
    });
});