$(function () {

    sessionStorage.clear();

    // Validation
    $("#login-form").validate({
        // Rules for form validation
        rules: {
            Username: {
                required: true
            },
            Password: {
                required: true,
                minlength: 3,
                maxlength: 20
            }
        },

        // Messages for form validation
        messages: {
            Username: {
                required: 'Please enter your username'
            },
            Password: {
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

    $("#register-form").validate({
        // Rules for form validation
        rules: {
            RegistrationEmail: {
                required: true,
                email: true,
                remote: {
                    url: $('#RegistrationEmail').data("url"),
                    data: {
                        email: function () {
                            return $('#RegistrationEmail').val();
                        },
                        __RequestVerificationToken: $("input[name='__RequestVerificationToken']").val()
                    },
                    type: 'POST',
                    dataType: 'json',
                    error: function (xhr, status, error) { checkRedirect(xhr.responseJSON); }
                }
            }
        },

        // Do not change code below
        errorPlacement: function (error, element) {
            error.insertAfter(element.parent());
        },

        submitHandler: function (form) {
            $('#registerFormSubmit').prop('disabled', true);
            form.submit();
        }
    });
});