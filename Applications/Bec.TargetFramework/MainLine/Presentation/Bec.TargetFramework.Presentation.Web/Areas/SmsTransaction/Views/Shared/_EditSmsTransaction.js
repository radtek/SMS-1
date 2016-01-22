$(function () {
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
        var formData = $("#editSmsTransaction-form").serializeArray();
        fixDate(formData, 'Model.Contact.BirthDate', "#birthDateInput");
        ajaxWrapper({
            url: $("#editSmsTransaction-form").data("url"),
            type: "POST",
            data: formData
        }).done(function (res) {
            if (res.result === true)
                window.location = $("#editSmsTransaction-form").data("redirectto");
            else {
                handleModal({ url: $("#editSmsTransaction-form").data("message") + "?title=" + res.title + "&message=" + res.message + "&button=Back" }, {
                    messageButton: function () {
                        $("#submitEditSmsTransaction").prop('disabled', false);
                    }
                }, true);
            }
        }).fail(function (e) {
            if (!hasRedirect(e.responseJSON)) {
                showtoastrError();
            }
        });
    }

    // submit from when Save button clicked
    $("#submitEditSmsTransaction").click(function () {
        $("#editSmsTransaction-form").submit();
    });

    $("#editSmsTransaction-form").validate({
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
            'Model.UserAccountOrganisation.UserAccount.Email': {
                required: true,
                email: true,
                remote: {
                    cache: false,
                    url: $('#Model_UserAccountOrganisation_UserAccount_Email').data("url"),
                    data: {
                        email: function () { return $('#Model_UserAccountOrganisation_UserAccount_Email').val(); },
                        uaoID: function () { return $('#uaoID').val(); }
                    },
                    dataType: 'json',
                    error: function (xhr, status, error) { checkRedirect(xhr.responseJSON); }
                }
            },
            'Model.Contact.BirthDate': {
                required: true
            }
        },

        // Do not change code below
        errorPlacement: function (error, element) {
            error.insertAfter(element.parent());
        },

        submitHandler: validateSubmit
    });

    makeDatePicker("#birthDateInput", {
        maxDate: new Date()
    });
});