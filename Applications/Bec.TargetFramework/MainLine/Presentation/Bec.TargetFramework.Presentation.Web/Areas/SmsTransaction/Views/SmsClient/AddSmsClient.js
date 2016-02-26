$(function () {
    'use strict';

    setupForm();
    setupClientsPostcodeLookup();

    function setupForm() {
        var addSmsClientForm = $("#addSmsClientForm");
        var submitAddSmsClientBtn = $("#submitAddSmsClientBtn");

        makeDatePicker("#birthDateInput", {
            maxDate: new Date()
        });

        // submit from when Save button clicked
        submitAddSmsClientBtn.click(function () {
            addSmsClientForm.submit();
        });

        addSmsClientForm.validate({
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
                }
            },
            // Do not change code below
            errorPlacement: function (error, element) {
                error.insertAfter(element.parent());
            },

            submitHandler: submitForm
        });

        function submitForm(form) {
            submitAddSmsClientBtn.prop('disabled', true);
            var formData = addSmsClientForm.serializeArray();
            fixDate(formData, 'BirthDate', "#birthDateInput");
            ajaxWrapper({
                url: addSmsClientForm.data("url"),
                type: "POST",
                data: formData
            }).done(function (res) {
                if (res.result === true)
                    window.location = addSmsClientForm.data('redirectto');
                else {
                    handleModal({ url: addSmsClientForm.data("message") + "?title=" + res.title + "&message=" + res.message + "&button=Back" }, {
                        messageButton: function () {
                            submitAddSmsClientBtn.prop('disabled', false);
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
            postcodelookup: '#smsClientPostcodeLookup',
            line1: '#smsClientLine1',
            line2: '#smsClientLine2',
            town: '#smsClientTown',
            county: '#smsClientCounty',
            postcode: '#smsClientPostalCode',
            manualAddress: '#smsClientManualAddress',
            resList: '#smsClientAddressResults',
            manAddRow: '#smsClientManAddRow',
            noMatch: '#smsClientNoMatch',
            findAddressButton: '#smsClientFindAddressButton'
        }).setup();
    }
});
