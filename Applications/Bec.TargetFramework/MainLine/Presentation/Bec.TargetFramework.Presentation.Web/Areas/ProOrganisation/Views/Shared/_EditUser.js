
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
        'Model.UserAccount.Email': {
            required: true,
            email: true,
            remote: {
                url: $('#Model_UserAccount_Email').data("url"),
                data: {
                    email: function () { return $('#Model_UserAccount_Email').val(); },
                    uaoID: function () { return $('#uaoID'); }
                },
                dataType: 'json',
                error: function (xhr, status, error) { checkRedirect(xhr.responseJSON); }
            }
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