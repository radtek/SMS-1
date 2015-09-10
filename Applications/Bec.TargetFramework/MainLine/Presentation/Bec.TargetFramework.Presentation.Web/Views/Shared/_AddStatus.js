// submit from when Save button clicked
$("#okButton").click(function () {
    $("#confirmStatus-form").submit();
});

$("#confirmStatus-form").validate({
    ignore: '.skip',
    // Rules for form validation
    rules: {
        "notes": {
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
    $("#okButton").prop('disabled', true);
    form.submit();
}