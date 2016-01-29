
function ignore(e) {
    if (e) e.preventDefault();
}

// submit from when Save button clicked
$("#submitEditPage").click(function () {
    $("#editPage-form").submit();
});

$("#editPage-form").validate({
    ignore: '.skip',
    // Rules for form validation
    rules: {
        RoleName: {
            required: true
        },
        PageName: {
            required: true
        },
        PageUrl: {
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
    $("#submitEditPage").prop('disabled', true);
    form.submit();
}