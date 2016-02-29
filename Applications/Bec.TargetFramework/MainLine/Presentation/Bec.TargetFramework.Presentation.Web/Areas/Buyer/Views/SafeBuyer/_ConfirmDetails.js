$(function () {
    'use strict';

    initLenderSearch();
    initPrimaryBuyerPostcodeLookup();
    initTransactionPostcodeLookup();
    setupForm();
    setupWizard();

    function setupForm() {
        
        var validationRules = {
            "Contact.Salutation": {
                required: true
            },
            "Contact.FirstName": {
                required: true
            },
            "Contact.LastName": {
                required: true
            },
            "Contact.BirthDate": {
                required: true
            },
            "Address.Line1": {
                required: true
            },
            "Address.Town": {
                required: true
            },
            "Address.PostalCode": {
                required: true,
                minlength: 5
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
        };

        var smsTransactionValidationRules = {
            "SmsTransaction.Address.Line1": {
                required: true
            },
            "SmsTransaction.Address.Town": {
                required: true
            },
            "SmsTransaction.Address.PostalCode": {
                required: true,
                minlength: 5
            },
            "SmsTransaction.Price": {
                required: true,
                digits: true,
                max: 2147483647
            },
            "BuyingWithMortgageSelect": {
                required: true
            },
            "SmsTransaction.LenderName": {
                required: {
                    depends: function (element) {
                        return $("#BuyingWithMortgageSelect").find("option:selected").val() != 0;
                    }
                }
            },
            "SmsTransaction.MortgageApplicationNumber": {
                required: {
                    depends: function (element) {
                        return $("#BuyingWithMortgageSelect").find("option:selected").val() != 0;
                    }
                }
            }
        };

        var confirmDetailsForm = $("#confirmDetails-form");
        var canEditTransactionDetails = !!confirmDetailsForm.data('can-edit-transaction-details');
        if (canEditTransactionDetails) {
            _.extend(validationRules, smsTransactionValidationRules);
        }

        confirmDetailsForm.validate({
            ignore: '.skip',
            // Rules for form validation
            rules: validationRules,
            // Do not change code below
            errorPlacement: function (error, element) {
                error.insertAfter(element.parent());
            },
            submitHandler: validateSubmit
        });

        makeDatePicker("#birthDateInput", {
            maxDate: new Date()
        });

        var disabledBirthDateInput = $('#disabledBirthDateInput');
        disabledBirthDateInput.val(dateStringNoTime(disabledBirthDateInput.val()));

        $("#BuyingWithMortgageSelect").change(function () {
            $(this).find("option:selected").each(function () {
                var selectedValue = parseInt($(this).attr("value"));
                $("#BuyingWithMortgageContainer").toggle(!!selectedValue);
                if (selectedValue != 1) {
                    $('#lenderSearch').val('');
                    $('#SmsTransaction_MortgageApplicationNumber').val('');
                }
            });
        }).change();

        function validateSubmit(form) {
            $("#submitAddTransaction").prop('disabled', true);
            var formData = confirmDetailsForm.serializeArray();
            fixDate(formData, 'Contact.BirthDate', "#birthDateInput");

            var matchDiv = $('#result-match');
            var noMatchDiv = $('#result-no-match');
            var serverErrorDiv = $('#result-server-error');

            matchDiv.hide();
            noMatchDiv.hide();
            serverErrorDiv.hide();
            
            ajaxWrapper({
                url: confirmDetailsForm.data("url"),
                type: "POST",
                data: formData
            }).done(function (res) {
                showDetails(res.data, res.accountNumber, res.sortCode);
                hideCurrentModal();

                if (res.result == true)
                    handleModal({ url: $('#transactionContainer').data('url') + "&accountNumber=" + res.accountNumber + "&sortCode=" + res.sortCode }, null, true);
                else
                    handleModal({ url: $('#transactionContainer').data('failurl') + "&accountNumber=" + res.accountNumber + "&sortCode=" + res.sortCode }, null, true);
                
            }).fail(function (e) {
                if (!hasRedirect(e.responseJSON)) {
                    serverErrorDiv.show();
                    hideCurrentModal();
                }
            });
        }
    }

    function setupWizard() {
        var wizard = $('#confirmDetailsWizard').bootstrapWizard({
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
                    $('#submitAddTransaction').show();
                    $('#stepNext').hide();
                }
                else {
                    $('#submitAddTransaction').hide();
                    $('#stepNext').show();
                }
            },
            onTabClick: function (tab, navigation, index) {
                return false;
            }
        });

        $("#submitAddTransaction").click(checkWizardValid(wizard, "#confirmDetails-form"));

        $("#stepNext").click(function () {
            wizard.bootstrapWizard('next');
        });

        $("#stepBack").click(function () {
            wizard.bootstrapWizard('previous');
        });
    }

    function showDetails(data, an, sc) {

        if (data.SmsTransaction.Address) {
            $('#addressHeading').text(data.SmsTransaction.Address.Line1 + " " + data.SmsTransaction.Address.PostalCode);

            $('#txLine1').text(data.SmsTransaction.Address.Line1);
            $('#txLine2').text(data.SmsTransaction.Address.Line2);
            $('#txTown').text(data.SmsTransaction.Address.Town);
            $('#txCounty').text(data.SmsTransaction.Address.County);
            $('#txPostalCode').text(data.SmsTransaction.Address.PostalCode);

            $('#mortgageLender').text(data.SmsTransaction.LenderName || "None");
            $('#mortgageAppNumber').text(data.SmsTransaction.MortgageApplicationNumber || "None");
            $('#purchasePrice').text(formatCurrency(data.SmsTransaction.Price));

            $('#detailsRowTransactionAddress').show();
        }

        $('#bFullName').text(data.Contact.FullName);
        $('#bDateOfBirth').text(dateStringNoTime(data.Contact.BirthDate));
        $('#bLine1').text(data.Address.Line1);
        $('#bLine2').text(data.Address.Line2);
        $('#bTown').text(data.Address.Town);
        $('#bCounty').text(data.Address.County);
        $('#bPostalCode').text(data.Address.PostalCode);

        $('#detailsRow').show();

        var personalBankAccountTemplate = Handlebars.compile('<tr><td>{{AccountNumber}}</td><td>{{SortCode}}</td>');
        _.map(data.SmsSrcFundsBankAccounts, function (item) {
            return personalBankAccountTemplate(item);
        }).forEach(function (html) {
            $('#personalBankAccountsTable tbody').append(html);
        });

        $('#post-no-match').hide();
    }

    function initLenderSearch() {
        $('#lenderSearch').lenderSearch({
            searchUrl: $('#lenderSearch').data("url")
        });
    }

    function initPrimaryBuyerPostcodeLookup() {
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

    function initTransactionPostcodeLookup() {
        new findAddress({
            postcodelookup: '#sms_postcodelookup',
            line1: '#sms_Line1',
            line2: '#sms_Line2',
            town: '#sms_Town',
            county: '#sms_County',
            postcode: '#sms_PostalCode',
            manualAddress: '#sms_manualAddress',
            resList: '#sms_addressresults',
            manAddRow: '#sms_manAddRow',
            noMatch: '#sms_noMatch',
            findAddressButton: '#sms_findaddressbutton'
        }).setup();
    }
});
