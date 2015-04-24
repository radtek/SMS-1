﻿// submit from when Save button clicked
$("#submitGeneratePin").click(function () {
    $("#generatePin-form").submit();
});

$('#cancelGeneratePin').click(function () {
    handleModal($(this).data('href'), {
        cancelYes: function () {
            hideParentModal();
        }
    }, true);
});

// Validation
$("#generatePin-form").validate({
    ignore: '.skip',
    // Rules for form validation
    rules: {
        ContactedTelephoneNumber: {
            required: true
        }
    },

    // Do not change code below
    errorPlacement: function (error, element) {
        error.insertAfter(element.parent());
    },

    submitHandler: validateGenereatePinSubmit
});

function validateGenereatePinSubmit(form) {
    $("#submitGeneratePin").prop('disabled', true);
    form.submit();
}