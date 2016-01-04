
function ignore(e) {
    if (e) e.preventDefault();
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
                cache: false,
                url: $('#EmailAddress1').data("url"),
                data: { email: function () { return $('#EmailAddress1').val(); } },
                dataType: 'json',
                error: function (xhr, status, error) { checkRedirect(xhr.responseJSON); }
            }
        }
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