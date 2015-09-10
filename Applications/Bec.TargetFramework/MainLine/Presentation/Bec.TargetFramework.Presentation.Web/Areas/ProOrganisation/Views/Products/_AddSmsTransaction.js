
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
    additionalAddress: '#AdditionalAddressInformation'
}).setup();

// submit from when Save button clicked
$("#submitAddTransaction").click(function () {
    $("#addTransaction-form").submit();
});

$("#addTransaction-form").validate({
    ignore: '.skip',
    // Rules for form validation
    rules: {
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
        Reference: {
            required: true
        },
        Price: {
            required: true,
            digits: true,
            max: 2147483647
        }
    },

    // Do not change code below
    errorPlacement: function (error, element) {
        error.insertAfter(element.parent());
    },

    submitHandler: validateSubmit
});

function validateSubmit(form) {
    $("#submitAddTransaction").prop('disabled', true);
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
            $("#submitAddTransaction").prop('disabled', false);
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
                    $("#submitAddTransaction").prop('disabled', false);
                }
            }, true);
        }
    }).fail(function (e) {
        console.log(e);
        updateBalance();
        handleModal({ url: $('#d1').data("redirectto") + "?title=Error&message=" + e + "&button=Back" }, {
            messageButton: function () {
                $("#submitAddTransaction").prop('disabled', false);
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

updateBalance();