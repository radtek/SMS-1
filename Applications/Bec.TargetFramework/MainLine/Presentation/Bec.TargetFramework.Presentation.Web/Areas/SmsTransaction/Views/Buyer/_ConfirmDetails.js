﻿$(function () {
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
        $('#orgSearch').parent().siblings('.typeahead-spinner').show();
    })
    .on('typeahead:asynccancel typeahead:asyncreceive', function () {
        $('#orgSearch').parent().siblings('.typeahead-spinner').hide();
    });

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

    $("#confirmDetails-form").validate({
        ignore: '.skip',
        // Rules for form validation
        rules: {
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

    var wizard = $('#confirmDetailsWizard').bootstrapWizard({
        tabClass: 'form-wizard',
        onTabShow: function (tab, navigation, index) {
            var total = navigation.find('li').length;
            var first = index == 0;
            var last = index == total - 1;

            if (first) {
                $('#stepBack').hide();
            }
            else{
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

    makeDatePicker("#birthDateInput");
});

function validateSubmit(form) {
    $("#addTransactionControls button").prop('disabled', true);
    var formData = $("#confirmDetails-form").serializeArray();
    fixDate(formData, 'Contact.BirthDate', "#birthDateInput");

    var index = $("#confirmDetails-form").data("index");
    var matchDiv = $('#result-match-' + index);
    var noMatchDiv = $('#result-no-match-' + index);
    var serverErrorDiv = $('#result-server-error-' + index);

    matchDiv.hide();
    noMatchDiv.hide();
    serverErrorDiv.hide();

    ajaxWrapper({
        url: $("#confirmDetails-form").data("url"),
        type: "POST",
        data: formData
    }).done(function (res) {
        showDetails(res.data, res.accountNumber, res.sortCode);
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

function showDetails(data, an, sc) {
    $('#addressHeading').text(data.SmsTransaction.Address.Line1 + " " + data.SmsTransaction.Address.PostalCode);
    $('.accountNumber').text(an);
    $('.sortCode').text(sc);
}