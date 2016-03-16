$(function () {
    'use strict';

    setupForm();
    setupSmsPostcodeLookup();
    setupPrimaryBuyersPostcodeLookup();
    setupWizard();
    setupMortgageSelect();

    function setupForm() {
        var addressDependsRule = function (namePrefix) {
            return function (element) {
                return _.find($('[name^="' + namePrefix + '"][type="text"]'), function (input) {
                    return $(input).val().trim() !== '';
                });
            };
        };

        $("#addTransaction-form").validate({
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
                "BuyingWithMortgageSelect": {
                    required: true
                },
                "SmsTransactionDTO.LenderName": {
                    required: {
                        depends: function (element) {
                            return $("#BuyingWithMortgageSelect").find("option:selected").val() != 0;
                        }
                    }
                },
                "SmsTransactionDTO.MortgageApplicationNumber": {
                    required: {
                        depends: function (element) {
                            return $("#BuyingWithMortgageSelect").find("option:selected").val() != 0;
                        }
                    }
                },
                "SmsTransactionDTO.Address.Line1": {
                    required: {
                        depends: addressDependsRule('SmsTransactionDTO.Address')
                    }
                },
                "SmsTransactionDTO.Address.Town": {
                    required: {
                        depends: addressDependsRule('SmsTransactionDTO.Address')
                    }
                },
                "SmsTransactionDTO.Address.PostalCode": {
                    minlength: 5,
                    required: {
                        depends: addressDependsRule('SmsTransactionDTO.Address')
                    }
                },
                "RegisteredHomeAddressDTO.Line1": {
                    required: {
                        depends: addressDependsRule('RegisteredHomeAddressDTO')
                    }
                },
                "RegisteredHomeAddressDTO.Town": {
                    required: {
                        depends: addressDependsRule('RegisteredHomeAddressDTO')
                    }
                },
                "RegisteredHomeAddressDTO.PostalCode": {
                    minlength: 5,
                    required: {
                        depends: addressDependsRule('RegisteredHomeAddressDTO')
                    }
                }
            },

            // Do not change code below
            errorPlacement: function (error, element) {
                error.insertAfter(element.parent());
            },

            submitHandler: validateSubmit
        });

        makeDatePicker("#birthDateInput", {
            maxDate: new Date()
        });

        function validateSubmit(form) {
            var formElement = $("#addTransaction-form");
            var formButtons = $("#addTransactionControls button");
            formButtons.prop('disabled', true);
            var formData = formElement.serializeArray();
            fixDate(formData, 'BirthDate', "#birthDateInput");

            var saveTransaction = function () {
                ajaxWrapper({
                    url: formElement.data("url"),
                    type: "POST",
                    data: formData
                }).done(function (res) {
                    if (res.result === true)
                        window.location = formElement.data("redirectto") + "?selectedTransactionID=" + res.txID;
                    else {
                        handleModal({ url: formElement.data("message") + "?title=" + res.title + "&message=" + res.message + "&button=Back" }, {
                            messageButton: function () {
                                formButtons.prop('disabled', false);
                            }
                        }, true);
                    }
                }).fail(function (e) {
                    if (!hasRedirect(e.responseJSON)) {
                        showtoastrError();
                    }
                });
            }

            //handlemodal won't show the modal if there are no results, i.e. it receives a json result {"result" : "ok"}
            handleModal(
            {
                url: formElement.data("check"),
                data: formData,
                method: 'POST'
            },
            {
                cancel: function () {
                    formButtons.prop('disabled', false);
                },
                save: saveTransaction
            },
            true,
            "save"); //default action if no duplicate results
        }
    }

    function setupSmsPostcodeLookup() {
        new findAddress({
            postcodelookup: '#txPostcodeLookup',
            line1: '#txLine1',
            line2: '#txLine2',
            town: '#txTown',
            county: '#txCounty',
            postcode: '#txPostalCode',
            manualAddress: '#txManualAddress',
            resList: '#txAddressResults',
            manAddRow: '#txManAddRow',
            noMatch: '#txNoMatch',
            findAddressButton: '#txFindAddressButton'
        }).setup();
    }

    function setupPrimaryBuyersPostcodeLookup() {
        new findAddress({
            postcodelookup: '#primaryBuyerPostcodeLookup',
            line1: '#primaryBuyerLine1',
            line2: '#primaryBuyerLine2',
            town: '#primaryBuyerTown',
            county: '#primaryBuyerCounty',
            postcode: '#primaryBuyerPostalCode',
            manualAddress: '#primaryBuyerManualAddress',
            resList: '#primaryBuyerAddressResults',
            manAddRow: '#primaryBuyerManAddRow',
            noMatch: '#primaryBuyerNoMatch',
            findAddressButton: '#primaryBuyerFindAddressButton'
        }).setup();
    }

    function setupWizard() {
        var wizard = $('#addTransactionWizard').bootstrapWizard({
            tabClass: 'form-wizard',
            onTabShow: function (tab, navigation, index) {
                var $total = navigation.find('li').length;
                var $current = index + 1;
                if ($current >= $total) {
                    $('#stepBack').show();
                    $('#stepNext').hide();
                    $('#submitAddTransaction').show();
                    $('#submitAddTransaction').removeClass('disabled');
                } else {
                    $('#stepBack').hide();
                    $('#stepNext').show();
                    $('#submitAddTransaction').hide();
                }
            }
        });

        $("#submitAddTransaction").click(checkWizardValid(wizard, "#addTransaction-form"));

        $("#stepNext").click(function () {
            wizard.bootstrapWizard('next');
        });

        $("#stepBack").click(function () {
            wizard.bootstrapWizard('previous');
        });
    }

    function setupMortgageSelect() {
        $("#BuyingWithMortgageSelect").change(function () {
            $(this).find("option:selected").each(function () {
                var selectedValue = parseInt($(this).attr("value"));
                $("#BuyingWithMortgageContainer").toggle(!!selectedValue);
                if (selectedValue != 1) {
                    $('#lenderSearch').val('');
                    $('#SmsTransactionDTO_MortgageApplicationNumber').val('');
                }
            });
        }).change();

        $('#lenderSearch').lenderSearch({
            searchUrl: $('#lenderSearch').data("url")
        });
    }
});
