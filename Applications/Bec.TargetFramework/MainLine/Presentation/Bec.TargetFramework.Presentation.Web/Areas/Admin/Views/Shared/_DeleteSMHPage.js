
function ignore(e) {
    if (e) e.preventDefault();
}

// submit from when Save button clicked
$("#submitDeletePage").click(function () {
    $("#deletePage-form").submit();
});

$("#deletePage-form").validate({
    ignore: '.skip',
    // Rules for form validation
    rules: {
    },

    // Do not change code below
    errorPlacement: function (error, element) {
        error.insertAfter(element.parent());
    },

    submitHandler: validateSubmit
});

function validateSubmit(form) {
    $("#submitDeletePage").prop('disabled', true);
    form.submit();
}