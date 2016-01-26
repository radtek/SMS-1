$(function () {
    'use strict';
    setupAddressFinder();
    setupPaymentForm();

    function setupAddressFinder() {
        new findAddress({
            postcodelookup: '#postcodelookup',
            line1: '#Line1',
            line2: '#Line2',
            town: '#Town',
            county: '#County',
            postcode: '#PostalCode',
            manualAddress: '#manualAddress',
            resList: '#addressresults',
            manAddRow: '#manAddRow',
            noMatch: '#noMatch',
            findAddressButton: '#findaddressbutton'
        }).setup();
    }

    function setupPaymentForm() {
        // submit from when Save button clicked
        $("#submitPurchase").click(function () {
            $("#purchaseProductForm").submit();
        });

        $("#purchaseProductForm").validate({
            ignore: '.skip',
            // Rules for form validation
            rules: {
                CardNumber: {
                    required: true,
                    digits: true,
                    minlength: 16
                },
                CardExpiryYear: {
                    required: true,
                    digits: true,
                    minlength: 2
                },
                CVVNumber: {
                    required: true,
                    digits: true,
                    minlength: 3
                },
                Line1: {
                    required: true
                },
                Town: {
                    required: true
                },
                PostalCode: {
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
            $("#submitPurchase").prop('disabled', true);
            var formData = $("#purchaseProductForm").serializeArray();
            ajaxWrapper({
                url: $("#purchaseProductForm").data("url"),
                type: "POST",
                data: formData
            }).done(function (res) {
                if (res.result == true) {
                    if ($("#purchaseProductForm").data("redirect")) {
                        window.location = $("#purchaseProductForm").data("redirectto");
                    } else {
                        hideCurrentModal();
                    }
                }
                else {
                    $('#txID').val(res.txID);
                    handleModal({ url: $("#purchaseProductForm").data("message") + "?title=" + res.title + "&message=" + res.message + "&button=Back" }, {
                        messageButton: function () {
                            $("#submitPurchase").prop('disabled', false);
                        }
                    }, true);
                }
            }).fail(function (e) {
                if (!hasRedirect(e.responseJSON)) {
                    console.log(e);
                    handleModal({ url: $("#purchaseProductForm").data("message") + "?title=Error&message=" + e.statusText + "&button=Back" }, {
                        messageButton: function () {
                            $("#submitPurchase").prop('disabled', false);
                        }
                    }, true);
                }
            });
        }
    }
});

