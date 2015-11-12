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
            },
            "SrcFundsBankAccountNumber": {
                required: true,
                digits: true,
                minlength: 8
            },
            "SrcFundsBankAccountSortCode": {
                required: true,
                digits: true,
                minlength: 6
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

        $("#BuyingWithMortgageSelect").change(function () {
            $(this).find("option:selected").each(function () {
                var selectedValue = parseInt($(this).attr("value"));
                $("#BuyingWithMortgageContainer").toggle(!!selectedValue);
            });
        }).change();

        function validateSubmit(form) {
            $("#submitAddTransaction").prop('disabled', true);
            var formData = confirmDetailsForm.serializeArray();
            fixDate(formData, 'Contact.BirthDate', "#birthDateInput");

            var index = confirmDetailsForm.data("index");
            var matchDiv = $('#result-match-' + index);
            var noMatchDiv = $('#result-no-match-' + index);
            var serverErrorDiv = $('#result-server-error-' + index);

            matchDiv.hide();
            noMatchDiv.hide();
            serverErrorDiv.hide();

            ajaxWrapper({
                url: confirmDetailsForm.data("url"),
                type: "POST",
                data: formData
            }).done(function (res) {
                showDetails(res.data, res.accountNumber, res.sortCode, index);

                if (res.result == true)
                    matchDiv.show();
                else
                    noMatchDiv.show();
                hideCurrentModal();
            }).fail(function (e) {
                if (!hasRedirect(e.responseJSON)) {
                    console.log(e);
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

    function showDetails(data, an, sc, index) {
        $('#accountNumberMatch-' + index).text(an);
        $('#sortCodeMatch-' + index).text(sc);
        $('#accountNumberNoMatch-' + index).text(an);
        $('#sortCodeNoMatch-' + index).text(sc);

        if (data.SmsTransaction.Address) {
            $('#addressHeading-' + index).text(data.SmsTransaction.Address.Line1 + " " + data.SmsTransaction.Address.PostalCode);

            $('#txLine1-' + index).text(data.SmsTransaction.Address.Line1);
            $('#txLine2-' + index).text(data.SmsTransaction.Address.Line2);
            $('#txTown-' + index).text(data.SmsTransaction.Address.Town);
            $('#txCounty-' + index).text(data.SmsTransaction.Address.County);
            $('#txPostalCode-' + index).text(data.SmsTransaction.Address.PostalCode);

            $('#mortgageLender-' + index).text(data.SmsTransaction.LenderName || "None");
            $('#mortgageAppNumber-' + index).text(data.SmsTransaction.MortgageApplicationNumber || "None");
            $('#purchasePrice-' + index).text(formatCurrency(data.SmsTransaction.Price));

            $('#detailsRowTransactionAddress-' + index).show();
        }

        $('#bLine1-' + index).text(data.Address.Line1);
        $('#bLine2-' + index).text(data.Address.Line2);
        $('#bTown-' + index).text(data.Address.Town);
        $('#bCounty-' + index).text(data.Address.County);
        $('#bPostalCode-' + index).text(data.Address.PostalCode);

        $('#detailsRow-' + index).show();
    }

    function initLenderSearch() {
        var lenders = new Bloodhound({
            datumTokenizer: Bloodhound.tokenizers.obj.whitespace('Name'),
            queryTokenizer: Bloodhound.tokenizers.whitespace,
            remote: {
                url: $('#lenderSearch').data("url") + '?search=%QUERY',
                wildcard: '%QUERY',
                transform: function (response) {
                    return response.Items;
                }
            }
        });

        $('#lenderSearch').typeahead({
            minLength: 1,
            highlight: true,
            hint: false
        }, {
            display: 'Name',
            source: lenders
        })
        .on('typeahead:asyncrequest', function () {
            $('#lenderSearch').parent().siblings('.typeahead-spinner').show();
        })
        .on('typeahead:asynccancel typeahead:asyncreceive', function () {
            $('#lenderSearch').parent().siblings('.typeahead-spinner').hide();
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
