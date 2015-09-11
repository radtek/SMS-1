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
            $('#formSubmit').prop('disabled', true);
            form.submit();
        }
    });
});