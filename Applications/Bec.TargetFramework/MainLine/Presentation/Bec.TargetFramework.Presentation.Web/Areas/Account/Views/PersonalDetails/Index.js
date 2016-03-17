$(function () {
    new findAddress({
        postcodelookup: '#postcodeLookup',
        line1: '#Line1',
        line2: '#Line2',
        town: '#Town',
        county: '#County',
        postcode: '#PostalCode',
        manualAddress: '#manualAddress',
        resList: '#addressResults',
        manAddRow: '#manAddRow',
        noMatch: '#noMatch',
        findAddressButton: '#findAddressButton'
    }).setup();

    $("#personalDetailsForm").validate({
        ignore: '.skip',
        // Rules for form validation
        rules: {
            "BirthDate": {
                required: true
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
            }
        },

        // Do not change code below
        errorPlacement: function (error, element) {
            error.insertAfter(element.parent());
        }
    });
   
    makeDatePicker("#birthDateInput", {
        maxDate: new Date()
    }, {
        onSelect: function (date, inst) {
            var birthDateField = $('#BirthDate');
            birthDateField.val(inst.input.data("val"));
            birthDateField.valid();
        }
    });
});