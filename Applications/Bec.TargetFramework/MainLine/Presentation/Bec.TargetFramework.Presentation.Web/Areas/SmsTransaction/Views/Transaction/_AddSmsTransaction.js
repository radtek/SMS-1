$(function () {

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
                form.submit();
            }
        },
        true,
        "save"); //default action if no duplicate results
    }

    makeDatePicker("#birthDateInput", {
        maxDate: new Date()
    });

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
});
