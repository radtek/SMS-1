
function ignore(e) {
    if (e) e.preventDefault();
}

// submit from when Save button clicked
$("#submitAddPage").click(function () {
    $("#addPage-form").submit();
});

$("#addPage-form").validate({
    ignore: '.skip',
    // Rules for form validation
    rules: {
        RoleId: {
            required: true
        },
        PageName: {
            required: true
        },
        PageURL: {
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
    $("#submitAddPage").prop('disabled', true);
    form.submit();
}