﻿$(function () {
    $("#changePasswordForm").validate({
        ignore: '.skip',
        // Rules for form validation
        rules: {
            "OldPassword": {
                required: true
            },
            "NewPassword": {
                required: true,
                minlength: 10,
                pwcheck: true,
                nospace: true
            },
            "ConfirmNewPassword": {
                equalTo: '#NewPassword',
                required: true
            }
        },
        messages: {
            "NewPassword": {
                pwcheck: 'Your password must contain 1 number, 1 uppercase character and 1 symbol'
            },
            "ConfirmNewPassword": {
                equalTo: 'Passwords do not match'
            }
        },

        // Do not change code below
        errorPlacement: function (error, element) {
            error.insertAfter(element.parent());
        },

        submitHandler: function (form) {
            $('#changePasswordSubmit').prop('disabled', true);
            form.submit();
        }
    });
});
