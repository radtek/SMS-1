new findAddress({
    postcodelookup: '#postcodelookup',
    companyName: '#CompanyName',
    line1: '#Line1',
    line2: '#Line2',
    town: '#Town',
    county: '#County',
    postcode: '#PostalCode',
    additionalAddress: '#AdditionalAddressInformation',
    manualAddress: '#manualAddress',
    resList: '#addressresults',
    manAddRow: '#manAddRow',
    noMatch: '#noMatch',
    findAddressButton: '#findaddressbutton'
}).setup();

// submit from when Save button clicked
$("#formSubmit").click(function () {
    $("#addTempCompany-form").submit();
});

// Validation
$("#addTempCompany-form").validate({
    ignore: '.skip',
    // Rules for form validation
    rules: {
        CompanyName: {
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
        RegulatorNumber: {
            required: true
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
            email: true,
            remote: {
                url: $('#OrganisationAdminEmail').data("url"),
                data: { email: function () { return $('#OrganisationAdminEmail').val(); } },
                dataType: 'json',
                error: function (xhr, status, error) { checkRedirect(xhr.responseJSON); }
            }
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
            CompanyName: $('#CompanyName').val(),
            Postalcode: $('#PostalCode').val()
        }
    },
    {
        abortSave: function () {
            $("#formSubmit").prop('disabled', false);
        },
        save: function () {
            form.submit();
        }
    },
    true,
    "save"); //default action if no duplicate results
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