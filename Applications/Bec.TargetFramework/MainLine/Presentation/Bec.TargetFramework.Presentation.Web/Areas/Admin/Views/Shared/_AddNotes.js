 // submit from when Save button clicked
$("#submitAddNotes").click(function () {
    $("#addNotes-form").submit();
});

// Validation
$("#addNotes-form").validate({
    ignore: '.skip',
    // Rules for form validation
    rules: {
        notes: {
            required: true
        }
    },

    // Do not change code below
    errorPlacement: function (error, element) {
        error.insertAfter(element.parent());
    },

    submitHandler: validateSubmit
});

function validateSubmit(form) {
    $("#submitAddNotes").prop('disabled', true);
    form.submit();
}