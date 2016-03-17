$(function () {
    'use strict';

    setupForm();
    setupClientsPostcodeLookup();

    function setupForm() {
        var addBuyerPartyForm = $("#addBuyerPartyForm");
        var submitAddBuyerPartyBtn = $("#submitAddBuyerPartyBtn");

        makeDatePicker("#birthDateInput", {
            maxDate: new Date()
        });

        // submit from when Save button clicked
        submitAddBuyerPartyBtn.click(function () {
            addBuyerPartyForm.submit();
        });

        var addressDependsRule = function (element) {
            return _.find($('[name^="RegisteredHomeAddressDTO"][type="text"]'), function (input) {
                return $(input).val().trim() !== '';
            })
        };

        addBuyerPartyForm.validate({
            ignore: '.skip',
            // Rules for form validation
            rules: {
                "Salutation": {
                    required: true
                },
                "FirstName": {
                    required: true
                },
                "LastName": {
                    required: true
                },
                "Email": {
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
                "BirthDate": {
                    required: true
                },
                "PhoneNumber": {
                    required: true,
                    digits: true,
                    minlength: 11,
                    maxlength: 11,
                    ukmobile: true
                },
                "RegisteredHomeAddressDTO.Line1": {
                    required: {
                        depends: addressDependsRule
                    }
                },
                "RegisteredHomeAddressDTO.Town": {
                    required: {
                        depends: addressDependsRule
                    }
                },
                "RegisteredHomeAddressDTO.PostalCode": {
                    minlength: 5,
                    required: {
                        depends: addressDependsRule
                    }
                }
            },
            // Do not change code below
            errorPlacement: function (error, element) {
                error.insertAfter(element.parent());
            },

            submitHandler: submitForm
        });

        function submitForm(form) {
            submitAddBuyerPartyBtn.prop('disabled', true);
            var formData = addBuyerPartyForm.serializeArray();
            fixDate(formData, 'BirthDate', "#birthDateInput");
            ajaxWrapper({
                url: addBuyerPartyForm.data("url"),
                type: "POST",
                data: formData
            }).done(function (res) {
                if (res.result === true)
                    window.location = addBuyerPartyForm.data('redirectto');
                else {
                    handleModal({ url: addBuyerPartyForm.data("message") + "?title=" + res.title + "&message=" + res.message + "&button=Back" }, {
                        messageButton: function () {
                            submitAddBuyerPartyBtn.prop('disabled', false);
                        }
                    }, true);
                }
            }).fail(function (e) {
                if (!hasRedirect(e.responseJSON)) {
                    showtoastrError();
                }
            });
        }
    }

    function setupClientsPostcodeLookup() {
        new findAddress({
            postcodelookup: '#buyerPartyPostcodeLookup',
            line1: '#buyerPartyLine1',
            line2: '#buyerPartyLine2',
            town: '#buyerPartyTown',
            county: '#buyerPartyCounty',
            postcode: '#buyerPartyPostalCode',
            manualAddress: '#buyerPartyManualAddress',
            resList: '#buyerPartyAddressResults',
            manAddRow: '#buyerPartyManAddRow',
            noMatch: '#buyerPartyNoMatch',
            findAddressButton: '#buyerPartyFindAddressButton'
        }).setup();
    }
});
