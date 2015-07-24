// submit from when Save button clicked
$("#formSubmit").click(function () {
    $("#addTempCompany-form").submit();
});

// Validation
$("#addTempCompany-form").validate({
    ignore: '.skip',
    // Rules for form validation
    rules: {
        Name: {
            required: true
        },
        Line1: {
            required: true
        },
        Town: {
            required: true
        },
        PostalCode: {
            required: true,
            minlength: 5
        },
        Regulator: {
            required: true
        },
        RegulatorOther: {
            required: {
                depends: function (element) {
                    return $("#RegulatorOther").is(":visible")
                }
            }
        },
        OrganisationAdminSalutation: {
            required: true
        },
        OrganisationAdminFirstName: {
            required: true
        },
        OrganisationAdminLastName: {
            required: true
        },
        OrganisationAdminEmail: {
            required: true,
            email: true
        },
        OrganisationAdminTelephone: {
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
    $("#formSubmit").prop('disabled', true);

    //handlemodal won't show the modal if there are no results, i.e. it receives a json result {"result" : "ok"}
    handleModal(
    {
        url: 'ViewDuplicates',
        data: {
            Manual: $('#manualAddress').prop('checked'),
            Line1: $('#Line1').val(),
            Line2: $('#Line2').val(),
            Town: $('#Town').val(),
            County: $('#County').val(),
            Postalcode: $('#PostalCode').val()
        }
    },
    {
        abortSave: function () {
            $("#formSubmit").prop('disabled', false);
        },
        saveWithDuplicates: function () {
            form.submit();
        }
    },
    true,
    "saveWithDuplicates"); //default action if no duplicate results
}

$("#otherRegulatorSection").hide();
$("#Regulator").change(function () {
    var selectedValue = this.value;

    if (selectedValue.toLowerCase() == 'other') {
        $("#otherRegulatorSection").show();

    } else {
        $("#otherRegulatorSection").next('em[for="RegulatorOther"]').remove();
        $("#otherRegulatorSection").removeClass("state-error");
        $("#otherRegulatorSection").hide();
        $("#RegulatorOther").val(null);
    }
});