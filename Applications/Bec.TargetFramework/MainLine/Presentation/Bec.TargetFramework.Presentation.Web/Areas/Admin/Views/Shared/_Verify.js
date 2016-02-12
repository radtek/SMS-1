$(function () {
    'use strict';

    $("#IsAuthorityDelegated").change(function () {
        $('#authorityDelgationDetails').toggle(this.checked);
    }).change();

    // submit from when Save button clicked
    $("#submitVerify").click(function () {
        $("#verify-form").submit();
    });

    var depnedsOnIsAuthorityDelegated = {
        depends: function (element) {
            return $('#IsAuthorityDelegated').is(':checked');
        }
    };

    // Validation
    $("#verify-form").validate({
        ignore: '.skip',
        // Rules for form validation
        rules: {
            PhoneNumber: {
                required: true
            },
            OrganisationName: {
                required: true
            },
            FilesPerMonth: {
                required: true,
                digits: true
            },
            RegulatorNumber: {
                required: true,
                number: true,
                remote: {
                    cache: false,
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
            Salutation: {
                required: true
            },
            FirstName: {
                required: true
            },
            LastName: {
                required: true
            },
            Email: {
                required: true,
                email: true,
                remote: {
                    cache: false,
                    url: $('#Email').data("url"),
                    data: { email: function () { return $('#Email').val(); } },
                    dataType: 'json',
                    error: function (xhr, status, error) { checkRedirect(xhr.responseJSON); }
                }
            },
            AuthorityDelegatedBySalutation: {
                required: depnedsOnIsAuthorityDelegated
            },
            AuthorityDelegatedByFirstName: {
                required: depnedsOnIsAuthorityDelegated
            },
            AuthorityDelegatedByLastName: {
                required: depnedsOnIsAuthorityDelegated
            },
            AuthorityDelegatedByEmail: {
                required: depnedsOnIsAuthorityDelegated,
                email: true
            },
        },

        // Do not change code below
        errorPlacement: function (error, element) {
            error.insertAfter(element.parent());
        },

        submitHandler: validateVerifySubmit
    });

    function validateVerifySubmit(form) {
        $("#submitVerify").prop('disabled', true);
        form.submit();
    }
});
