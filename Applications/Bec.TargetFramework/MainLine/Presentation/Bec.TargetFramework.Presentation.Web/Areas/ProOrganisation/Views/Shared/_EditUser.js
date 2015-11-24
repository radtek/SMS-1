
function ignore(e) {
    if (e) e.preventDefault();
}


// submit from when Save button clicked
$("#submitEditUser").click(function () {
    $("#editUser-form").submit();
});

$("#editUser-form").validate({
    ignore: '.skip',
    // Rules for form validation
    rules: {
        'Model.Contact.Salutation': {
            required: true
        },
        'Model.Contact.FirstName': {
            required: true
        },
        'Model.Contact.LastName': {
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
    $("#submitEditUser").prop('disabled', true);
    form.submit();
}