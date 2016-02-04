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

    // Validation
    $("#addCompanyForm").validate({
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
            BrokerType: {
                required: true
            },
            BrokerBusinessType: {
                required: true
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
                    cache: false,
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
            },
            checkSecPol: {
                required: true
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

