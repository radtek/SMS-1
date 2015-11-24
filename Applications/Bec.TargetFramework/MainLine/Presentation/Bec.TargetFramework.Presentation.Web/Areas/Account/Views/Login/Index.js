$(function () {

    sessionStorage.clear();

    // Validation
    $("#login-form").validate({
        // Rules for form validation
        rules: {
            "LoginDTO.Email": {
                required: true,
                email: true
            },
            "LoginDTO.Password": {
                required: true,
                minlength: 3,
                maxlength: 20
            }
        },

        // Messages for form validation
        messages: {
            "LoginDTO.Email": {
                required: 'Please enter your e-mail'
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

    //dirty fix for error messages and switching between tabs
    $('#loginTabs a').click(function () {
        $('form .alert-danger').remove();
    });
});
