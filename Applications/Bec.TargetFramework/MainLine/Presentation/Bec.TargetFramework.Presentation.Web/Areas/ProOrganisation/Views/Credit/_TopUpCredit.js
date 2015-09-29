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

// submit from when Save button clicked
$("#submitPay").click(function () {
    $("#payment-form").submit();
});

$("#payment-form").validate({
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
        amount: {
            required: true,
            digits: true,
            min: 1,
            max: 500
        }
    },

    // Do not change code below
    errorPlacement: function (error, element) {
        error.insertAfter(element.parent());
    },

    submitHandler: validateSubmit
});

function validateSubmit(form) {
    $("#submitPay").prop('disabled', true);
    var formData = $("#payment-form").serializeArray();
    ajaxWrapper({
        url: $("#payment-form").data("url"),
        type: "POST",
        data: formData
    }).done(function (res) {
        if (res.result == true) {
            if ($("#payment-form").data("redirect"))
                window.location = $("#payment-form").data("redirectto");
            else
                hideCurrentModal();
        }
        else {
            $('#txID').val(res.txID);
            handleModal({ url: $("#payment-form").data("message") + "?title=" + res.title + "&message=" + res.message + "&button=Back" }, {
                messageButton: function () {
                    $("#submitPay").prop('disabled', false);
                }
            }, true);
        }
    }).fail(function (e) {
        if (!hasRedirect(e.responseJSON)) {
            console.log(e);
            handleModal({ url: $("#payment-form").data("message") + "?title=Error&message=" + e.statusText + "&button=Back" }, {
                messageButton: function () {
                    $("#submitPay").prop('disabled', false);
                }
            }, true);
        }
    });
}