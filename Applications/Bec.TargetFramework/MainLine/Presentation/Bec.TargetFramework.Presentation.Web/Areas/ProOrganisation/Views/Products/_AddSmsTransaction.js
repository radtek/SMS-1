﻿
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
    findAddressButton: '#primaryBuyerFindAddressButton',
    additionalAddress: '#primaryBuyerAdditionalAddressInformation'
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
    findAddressButton: '#sms_findaddressbutton',
    additionalAddress: '#sms_AdditionalAddressInformation'
}).setup();

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
                url: $('#Email').data("url"),
                data: { email: function () { return $('#Email').val(); } },
                dataType: 'json',
                error: function (xhr, status, error) { checkRedirect(xhr.responseJSON); }
            }
        },
        "BirthDate": {
            required: true,
            dateGB: true
        },
        "Line1": {
            required: true
        },
        "Town": {
            required: true
        },
        "PostalCode": {
            required: true,
            minlength: 5
        },
        "SmsTransactionDTO.Address.Line1": {
            required: true
        },
        "SmsTransactionDTO.Address.Town": {
            required: true
        },
        "SmsTransactionDTO.Address.PostalCode": {
            required: true,
            minlength: 5
        },
        "SmsTransactionDTO.Reference": {
            required: true
        },
        "SmsTransactionDTO.Price": {
            required: true,
            digits: true,
            max: 2147483647
        },
    },

    // Do not change code below
    errorPlacement: function (error, element) {
        error.insertAfter(element.parent());
    },

    submitHandler: validateSubmit
});

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

$("#submitAddTransaction").click(function () {
    var form = $("#addTransaction-form");
    var isValid = form.valid();
    if (!isValid) {
        var invalidInputs = $(form.find('.tab-pane .invalid')[0]);
        var tabId = $(invalidInputs.parents('.tab-pane')[0]).attr('id');
        wizard.bootstrapWizard('show', tabId);

        return false;
    }
    form.submit();
});

$("#stepNext").click(function () {
    wizard.bootstrapWizard('next');
});

$("#stepBack").click(function () {
    wizard.bootstrapWizard('previous');
});

function validateSubmit(form) {
    $("#addTransactionControls button").prop('disabled', true);
    var formData = $("#addTransaction-form").serializeArray();
    //handlemodal won't show the modal if there are no results, i.e. it receives a json result {"result" : "ok"}
    handleModal(
    {
        url: $("#addTransaction-form").data("check"),
        data: formData,
        method: 'POST'
    },
    {
        cancel: function () {
            $("#addTransactionControls button").prop('disabled', false);
        },
        save: function () {
            doPost(formData);
        }
    },
    true,
    "save"); //default action if no duplicate results
}

function doPost(formData) {
    ajaxWrapper({
        url: $("#addTransaction-form").data("url"),
        type: "POST",
        data: formData
    }).done(function (res) {
        if (res.result == true)
            window.location = $('#d1').data("redirectto");
        else {
            $('#buyerUaoID').val(res.buyerUaoID);
            updateBalance();
            handleModal({ url: $('#d1').data("message") + "?title=" + res.title + "&message=" + res.message + "&button=Back" }, {
                messageButton: function () {
                    $("#addTransactionControls button").prop('disabled', false);
                }
            }, true);
        }
    }).fail(function (e) {
        console.log(e);
        updateBalance();
        handleModal({ url: $('#d1').data("redirectto") + "?title=Error&message=" + e + "&button=Back" }, {
            messageButton: function () {
                $("#addTransactionControls button").prop('disabled', false);
            }
        }, true);
    });
}

function updateBalance() {
    ajaxWrapper({ url: $('#d1').data("getbal") + '?startOfDay=false&date=' + new Date().toJSON().slice(0, 10) })
        .done(function (res) {
            $('#balance').text(new Date().toLocaleTimeString() + ": " + formatCurrency(parseFloat(res)));
        });
}

function topUp() {
    handleModal({ url: $('#d1').data("topup") }, {
        submitPay: function () {
            updateBalance();
        }
    }, true);
}

function setupDateOfBirthInput() {
    var now = new Date();
    var minDate = new Date(now.getFullYear() - 110, 0, 1);//, 1, 1);
    $("#birthDateInput").datepicker({
        dateFormat: "dd/mm/yy",
        maxDate: now,
        minDate: minDate,
        changeMonth: true,
        changeYear: true,
        yearRange: "-110:+0",
        showButtonPanel: true,
        prevText: "<i class=\"fa fa-chevron-left\"></i>",
        nextText: "<i class=\"fa fa-chevron-right\"></i>"
    });
}

updateBalance();
setupDateOfBirthInput();