$(function () {

    sessionStorage.clear();

    // Validation
    $("#login-form").validate({
        // Rules for form validation
        rules: {
            "LoginDTO.Username": {
                required: true
            },
            "LoginDTO.Password": {
                required: true,
                minlength: 3,
                maxlength: 20
            }
        },

        // Messages for form validation
        messages: {
            "LoginDTO.Username": {
                required: 'Please enter your username'
            },
            "LoginDTO.Password": {
                required: 'Please enter your password'
            }
        },

        // Do not change code below
        errorPlacement: function (error, element) {
            error.insertAfter(element.parent());
        },

        submitHandler: function (form) {
            $('#loginFormSubmit').prop('disabled', true);
            form.submit();
        }
    });

    // Registration tab

    $.validator.addMethod("pwcheck",
        function (value, element) {
            return /\d/.test(value) && /[A-Z]/.test(value) && /\W/.test(value);
        }, 'Your password must contain 1 number, 1 uppercase character and 1 symbol');

    $.validator.addMethod("ukmobile",
        function (value, element) {
            return /07[0-9]+/.test(value);
        }, 'Please enter a valid UK mobile number');

    $.validator.addMethod("lettersanddigits",
        function (value, element) {
            return /^[a-z0-9]+$/i.test(value);
        }, 'Your username must contain only letters and digits');

    $.validator.addMethod("nospace",
        function (value, element) {
            return value.indexOf(" ") < 0;
        }, 'Spaces are not allowed');

    // Validation
    $("#register-form").validate({
        ignore: '.skip',
        // Rules for form validation
        rules: {
            "CreatePermanentLoginModel.RegistrationEmail": {
                required: true,
                email: true,
                remote: {
                    url: $('#CreatePermanentLoginModel_RegistrationEmail').data("url"),
                    data: {
                        email: function () {
                            return $('#CreatePermanentLoginModel_RegistrationEmail').val();
                        },
                        __RequestVerificationToken: $("input[name='__RequestVerificationToken']").val()
                    },
                    type: 'POST',
                    dataType: 'json',
                    error: function (xhr, status, error) { checkRedirect(xhr.responseJSON); }
                }
            },
            "CreatePermanentLoginModel.Pin": {
                required: true
            },
            "CreatePermanentLoginModel.PhoneNumber": {
                required: true,
                digits: true,
                minlength: 11,
                maxlength: 11,
                ukmobile: true
            },
            "CreatePermanentLoginModel.NewPassword": {
                required: true,
                minlength: 10,
                pwcheck: true,
                nospace: true
            },
            "CreatePermanentLoginModel.ConfirmNewPassword": {
                equalTo: '#CreatePermanentLoginModel_NewPassword'
            },
            hiddenRecaptcha: {
                required: function () {
                    return grecaptcha.getResponse() == '';
                }
            }
        },

        // Messages for form validation
        messages: {
            "CreatePermanentLoginModel.NewPassword": {
                pwcheck: 'Your password must contain 1 number, 1 uppercase character and 1 symbol'
            },
            "CreatePermanentLoginModel.ConfirmNewPassword": {
                equalTo: 'Passwords do not match'
            }
        },

        // Do not change code below
        errorPlacement: function (error, element) {
            error.insertAfter(element.parent());
        },

        submitHandler: function (form) {
            if (grecaptcha.getResponse().length > 0) {
                $('#registerFormSubmit').prop('disabled', true);
                form.submit();
            }
        }
    });

    var selectedTab = $('#loginTabs').data('selected');
    $('#' + selectedTab).tab('show');
});
