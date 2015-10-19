$(function () {
    'use strict';

    new findAddress({
        postcodelookup: '#postcodeLookup',
        line1: '#Line1',
        line2: '#Line2',
        town: '#Town',
        county: '#County',
        postcode: '#PostalCode',
        manualAddress: '#manualAddress',
        resList: '#addressResults',
        manAddRow: '#manAddRow',
        noMatch: '#noMatch',
        findAddressButton: '#findAddressButton'
    }).setup();

    // submit from when Save button clicked
    $("#formSubmit").click(function () {
        $("#addCompany-form").submit();
    });

    // Validation
    $("#addCompany-form").validate({
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
                required: true,
                number: true,
                remote: {
                    url: $('#RegulatorNumber').data("url"),
                    data: {
                        regulatorNumber: function () {
                            return $('#RegulatorNumber').val();
                        },
                        __RequestVerificationToken: $("input[name='__RequestVerificationToken']").val()
                    },
                    type: 'POST',
                    dataType: 'json',
                    error: function (xhr, status, error) { checkRedirect(xhr.responseJSON); }
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
                email: true,
                remote: {
                    url: $('#OrganisationAdminEmail').data("url"),
                    data: {
                        email: function () { 
                            return $('#OrganisationAdminEmail').val();
                        },
                        __RequestVerificationToken: $("input[name='__RequestVerificationToken']").val()
                    },
                    type: 'POST',
                    dataType: 'json',
                    error: function (xhr, status, error) { checkRedirect(xhr.responseJSON); }
                }
            },
            OrganisationAdminTelephone: {
                required: true
            },
            OrganisationRecommendationSource: {
                required: true
            },
            hiddenRecaptcha: {
                required: function () {
                    return grecaptcha.getResponse() == '';
                }
            }
        },
        // Do not change code below
        errorPlacement: function (error, element) {
            element.parent().append(error);
        },
        submitHandler: function (form) {
            if (grecaptcha.getResponse().length > 0) {
                $('#formSubmit').prop('disabled', true);
                form.submit();
            }
        }
    });
});

