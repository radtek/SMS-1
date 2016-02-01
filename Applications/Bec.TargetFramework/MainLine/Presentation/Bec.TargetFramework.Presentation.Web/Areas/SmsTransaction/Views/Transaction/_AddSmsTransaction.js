﻿$(function () {

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
            }
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

    $("#submitAddTransaction").click(checkWizardValid(wizard, "#addTransaction-form"));

    $("#stepNext").click(function () {
        wizard.bootstrapWizard('next');
    });

    $("#stepBack").click(function () {
        wizard.bootstrapWizard('previous');
    });

    function validateSubmit(form) {
        $("#addTransactionControls button").prop('disabled', true);
        var formData = $("#addTransaction-form").serializeArray();
        fixDate(formData, 'BirthDate', "#birthDateInput");
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
                window.location = $('#d1').data("redirectto") + '?selectedTransactionID=' + res.transactionId;
            else {
                $('#buyerUaoID').val(res.buyerUaoID);
                handleModal({ url: $('#d1').data("message") + "?title=" + res.title + "&message=" + res.message + "&button=Back" }, {
                    messageButton: function () {
                        $("#addTransactionControls button").prop('disabled', false);
                    }
                }, true);
            }
        }).fail(function (e) {
            if (!hasRedirect(e.responseJSON)) {
                showtoastrError();
            }
        }, true);
    }

    makeDatePicker("#birthDateInput", {
        maxDate: new Date()
    });
});