
function ignore(e) {
    if (e) e.preventDefault();
}

// submit from when Save button clicked
$("#submitEditItem").click(function () {
    $("#editItem-form").submit();
});

$("#editItem-form").validate({
    ignore: '.skip',
    // Rules for form validation
    rules: {
        PageID: {
            required: true
        },
        ItemName: {
            required: true
        },
        ItemSelector: {
            required: true
        },
        ItemDescription: {
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
    $("#submitEditItem").prop('disabled', true);
    form.submit();
}