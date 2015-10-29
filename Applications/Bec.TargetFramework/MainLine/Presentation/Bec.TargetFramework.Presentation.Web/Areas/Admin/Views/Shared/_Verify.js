// submit from when Save button clicked
$("#submitVerify").click(function () {
    $("#verify-form").submit();
});

// Validation
$("#verify-form").validate({
    ignore: '.skip',
    // Rules for form validation
    rules: {
        notes: {
            required: true
        },
        name: {
            required: true
        }
    },

    // Do not change code below
    errorPlacement: function (error, element) {
        error.insertAfter(element.parent());
    },

    submitHandler: validateVerifySubmit
});

function validateVerifySubmit(form) {
    $("#submitVerify").prop('disabled', true);
    form.submit();
}