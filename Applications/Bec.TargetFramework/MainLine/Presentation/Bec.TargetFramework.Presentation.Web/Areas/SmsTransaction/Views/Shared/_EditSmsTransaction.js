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

function validateSubmit(form) {
    $("#submitEditSmsTransaction").prop('disabled', true);
    form.submit();
}

$(function () {
    // submit from when Save button clicked
    $("#submitEditSmsTransaction").click(function () {
        $("#editSmsTransaction-form").submit();
    });

    $("#editSmsTransaction-form").validate({
        ignore: '.skip',
        // Rules for form validation
        rules: {
            'Model.UserAccountOrganisation.Contact.Salutation': {
                required: true
            },
            'Model.UserAccountOrganisation.Contact.FirstName': {
                required: true
            },
            'Model.UserAccountOrganisation.Contact.LastName': {
                required: true
            },
            'Model.UserAccountOrganisation.UserAccount.Email': {
                required: true,
                email: true,
                remote: {
                    url: $('#Model_UserAccountOrganisation_UserAccount_Email').data("url"),
                    data: {
                        email: function () { return $('#Model_UserAccountOrganisation_UserAccount_Email').val(); },
                        uaoID: function () { return $('#uaoID').val(); }
                    },
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
});