$(function () {
    'use strict';

    $("#IsAuthorityDelegated").change(function () {
        $('#authorityDelgationDetails').find('input, select')
            .prop('disabled', !this.checked)
            .parent().toggleClass('state-disabled', !this.checked);
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
    $.validator.addMethod("differsFromMainEmail",
        function (value, element) {
            return value.trim() != $('#Email').val().trim();
        }, 'Please enter a different email address');

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
            RegulatorName: {
                required: true
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
            AuthorityDelegatedToSalutation: {
                required: depnedsOnIsAuthorityDelegated
            },
            AuthorityDelegatedToFirstName: {
                required: depnedsOnIsAuthorityDelegated
            },
            AuthorityDelegatedToLastName: {
                required: depnedsOnIsAuthorityDelegated
            },
            AuthorityDelegatedToEmail: {
                required: depnedsOnIsAuthorityDelegated,
                email: true,
                differsFromMainEmail: true,
                remote: {
                    cache: false,
                    url: $('#AuthorityDelegatedToEmail').data("url"),
                    data: { email: function () { return $('#AuthorityDelegatedToEmail').val(); } },
                    dataType: 'json',
                    error: function (xhr, status, error) { checkRedirect(xhr.responseJSON); }
                }
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
