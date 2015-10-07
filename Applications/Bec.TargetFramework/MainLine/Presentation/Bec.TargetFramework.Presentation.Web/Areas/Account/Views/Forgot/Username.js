// global for _Captcha view
function captchaClick() {
    $('#formSubmit').prop('disabled', false);
}

$(function () {
    // Validation
    $("#username-form").validate({
        // Rules for form validation
        rules: {
            email: {
                required: true,
                email: true
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