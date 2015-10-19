$(function () {
    sessionStorage.clear();
    setTimeout(function () { window.location.replace($('#content').data("url")) }, 900000); //15 minutes

    $.validator.addMethod("pwcheck",
        function (value, element) {
            return /\d/.test(value) && /[A-Z]/.test(value) && /\W/.test(value);
        }, 'Your password must contain 1 number, 1 uppercase character and 1 symbol');

    $.validator.addMethod("lettersanddigits",
        function (value, element) {
            return /^[a-z0-9]+$/i.test(value);
        }, 'Your username must contain only letters and digits');

    $.validator.addMethod("nospace",
        function (value, element) {
            return value.indexOf(" ") < 0;
        }, 'Spaces are not allowed');

    // Validation
    $("#login-form").validate({
        // Rules for form validation
        rules: {
            Pin: {
                required: true
            },
            NewUsername: {
                required: true,
                lettersanddigits: true,
                remote: {
                    url: $('#login-form').data("checkuser"),
                    data: {
                        username: function () {
                            return $('#NewUsername').val();
                        }
                    },
                    dataType: 'json',
                    error: function (xhr, status, error) {
                        checkRedirect(xhr.responseJSON);
                    }
                }
            },
            NewPassword: {
                required: true,
                minlength: 10,
                pwcheck: true,
                nospace: true
            },
            ConfirmNewPassword: {
                equalTo: '#NewPassword'
            },
            hiddenRecaptcha: {
                required: function () {
                    return grecaptcha.getResponse() == '';
                }
            }
        },

        // Messages for form validation
        messages: {
            NewPassword: {
                pwcheck: 'Your password must contain 1 number, 1 uppercase character and 1 symbol'
            },
            ConfirmNewPassword: {
                equalTo: 'Passwords do not match'
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