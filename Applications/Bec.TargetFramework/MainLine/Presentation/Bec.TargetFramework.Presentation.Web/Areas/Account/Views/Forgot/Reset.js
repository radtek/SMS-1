$(function () {
    $.validator.addMethod("pwcheck",
        function (value, element) {
            return /\d/.test(value) && /[A-Z]/.test(value) && /\W/.test(value);
        });

    // Validation
    $("#reset-form").validate({
        // Rules for form validation
        rules: {
            Username: {
                required: true
            },
            NewPassword: {
                required: true,
                minlength: 10,
                pwcheck: true
            },
            confirmPassword: {
                equalTo: '#NewPassword'
            }
        },

        // Messages for form validation
        messages: {
            NewPassword: {
                pwcheck: 'Your password must contain 1 number, 1 uppercase character and 1 symbol'
            },
            confirmPassword: {
                equalTo: 'Passwords do not match'
            }
        },

        // Do not change code below
        errorPlacement: function (error, element) {
            error.insertAfter(element.parent());
        },

        submitHandler: function (form) {
            $('#formSubmit').prop('disabled', true);
            form.submit();
        }
    });
});