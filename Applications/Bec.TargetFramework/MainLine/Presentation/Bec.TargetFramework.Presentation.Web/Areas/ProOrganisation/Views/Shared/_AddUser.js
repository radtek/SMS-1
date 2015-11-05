
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
$("#submitAddUser").click(function () {
    $("#addUser-form").submit();
});

$("#addUser-form").validate({
    ignore: '.skip',
    // Rules for form validation
    rules: {
        Salutation: {
            required: true
        },
        FirstName: {
            required: true
        },
        LastName: {
            required: true
        },
        EmailAddress1: {
            required: true,
            email: true,
            remote: {
                url: $('#EmailAddress1').data("url"),
                data: { email: function () { return $('#EmailAddress1').val(); } },
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
        rolecheck: 'Please select one or more permissions'
    },

    // Do not change code below
    errorPlacement: function (error, element) {
        error.insertAfter(element.parent());
    },

    submitHandler: validateSubmit
});

function validateSubmit(form) {
    $("#submitAddUser").prop('disabled', true);
    form.submit();
}