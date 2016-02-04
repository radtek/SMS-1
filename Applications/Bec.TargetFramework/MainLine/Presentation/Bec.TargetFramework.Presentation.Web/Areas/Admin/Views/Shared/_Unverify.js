// submit from when Save button clicked
$("#submitUnverify").click(function () {
    $("#unverifyTempCompany-form").submit();
});

// Validation
$("#unverifyTempCompany-form").validate({
    ignore: '.skip',
    // Rules for form validation
    rules: {
        Notes: {
            required: true
        }
    },

    // Do not change code below
    errorPlacement: function (error, element) {
        error.insertAfter(element.parent());
    },

    submitHandler: validateUnverifySubmit
});

function validateUnverifySubmit(form) {
    $("#submitUnverify").prop('disabled', true);
    form.submit();
}