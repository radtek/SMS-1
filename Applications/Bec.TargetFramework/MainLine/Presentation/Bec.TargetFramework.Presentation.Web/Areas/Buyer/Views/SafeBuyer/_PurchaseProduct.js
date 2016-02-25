$(function () {
    'use strict';
    setupAddressFinder();
    setupPaymentForm();
    setupWizard();

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
                    hideCurrentModal();

                    if (res.matchresult == true)
                        handleModal({ url: $('#transactionContainer').data('url') + "&accountNumber=" + res.accountNumber + "&sortCode=" + res.sortCode }, null, true);
                    else
                        handleModal({ url: $('#transactionContainer').data('failurl') + "&accountNumber=" + res.accountNumber + "&sortCode=" + res.sortCode }, null, true);
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

    function setupWizard() {
        var wizard = $('#purchaseWizard').bootstrapWizard({
            tabClass: 'form-wizard',
            onTabShow: function (tab, navigation, index) {
                var total = navigation.find('li').length;
                var first = index == 0;
                var last = index == total - 1;

                if (first) {
                    $('#stepBack').hide();
                }
                else {
                    $('#stepBack').show();
                }

                if (last) {
                    $('#submitPurchase').show();
                    $('#stepNext').hide();
                }
                else {
                    $('#submitPurchase').hide();
                    $('#stepNext').show();
                }
            },
            onTabClick: function (tab, navigation, index) {
                return false;
            }
        });

        $("#submitPurchase").click(checkWizardValid(wizard, "#purchaseProductForm"));

        $("#stepNext").click(function () {
            wizard.bootstrapWizard('next');
        });

        $("#stepBack").click(function () {
            wizard.bootstrapWizard('previous');
        });
    }
});

