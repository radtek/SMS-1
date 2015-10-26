
function ignore(e) {
    if (e) e.preventDefault();
}

function countRoles() {
    var c = 0;
    $('.role-checkbox').each(function (i, item) {
        if ($(item).prop('checked')) c++;
    });
    $('#rolecheck').val(c);
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
        },
        rolecheck: {
            required: true,
            min: 1
        }
    },
    messages: {
        rolecheck: 'Please select one or more roles'
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