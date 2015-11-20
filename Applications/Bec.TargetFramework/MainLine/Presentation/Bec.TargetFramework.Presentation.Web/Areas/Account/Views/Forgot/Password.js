$(function () {
    // Validation
    $("#forgot-password-form").validate({
        ignore: '.skip',
        // Rules for form validation
        rules: {
            Username: {
                required: true,
                email: true
            },
            PIN: {
                required: true
            },
            NewPassword: {
                required: true,
                minlength: 10,
                pwcheck: true
            },
            ConfirmPassword: {
                equalTo: '#NewPassword'
            },
            hiddenRecaptcha: {
                required: function () {
                    return grecaptcha.getResponse() == '';
                }
            }
        },

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
            if (grecaptcha.getResponse().length > 0) {
                $('#formSubmit').prop('disabled', true);
                form.submit();
            }
        }
    });
    $('#genRequest').on('click', function () {
        if (!$('#username').valid()) {
            return false;
        }

        $('#genRequest').prop('disabled', true);
        ajaxWrapper({
            url: $('#genRequest').data("url"),
            method: 'POST',
            data: {
                username: $('#username').val(),
                __RequestVerificationToken: $("input[name='__RequestVerificationToken']").val()
            }
        }).done(function (e) {
            $('#genRequestLabel').text(e.message);
        }).fail(function (e) {
            if (!hasRedirect(e.responseJSON)) {
                console.log(e);
                $('#genRequestLabel').text("An error has occured");
            }
        }).always(function () {
            $('#genRequestLabel').show();
            $('#genRequest').prop('disabled', false);
        });
    });
});