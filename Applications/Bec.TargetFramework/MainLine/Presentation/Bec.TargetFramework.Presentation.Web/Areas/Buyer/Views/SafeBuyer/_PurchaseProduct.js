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
                },
                accountNumber: {
                    required: true,
                    digits: true,
                    minlength: 8
                },
                sortCode: {
                    required: true,
                    digits: true,
                    minlength: 6
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

                if (res.paymentresult == true) {
                    window.location = $("#purchaseProductForm").data("redirectto");
                }
                else {
                    handleModal({ url: $("#purchaseProductForm").data("message") + "?title=" + res.title + "&message=" + res.message + "&button=Back" }, {
                        messageButton: function () {
                            $("#submitPurchase").prop('disabled', false);
                        }
                    }, true);
                }
            }).fail(function (e) {
                if (!hasRedirect(e.responseJSON)) {
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

