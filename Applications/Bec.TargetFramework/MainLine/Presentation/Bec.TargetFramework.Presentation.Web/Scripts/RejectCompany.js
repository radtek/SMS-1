﻿// submit from when Save button clicked
$("#submitReject").click(function () {
    $("#rejectTempCompany-form").submit();
});

// Validation
$("#rejectTempCompany-form").validate({
    ignore: '.skip',
    // Rules for form validation
    rules: {
        Reason: {
            required: true
        },
        Notes: {
            required: true
        }
    },

    // Do not change code below
    errorPlacement: function (error, element) {
        error.insertAfter(element.parent());
    },

    submitHandler: validateRejectSubmit
});

function validateRejectSubmit(form) {
    $("#submitReject").prop('disabled', true);
    form.submit();
}