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

    $("#personal-details-form").validate({
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
        },

        submitHandler: validateSubmit
    });
   
    function validateSubmit(form) {
        fixDate(formData, 'BirthDate', "#birthDateInput");
        form.submit();
    }

    makeDatePicker("#birthDateInput", {
        maxDate: new Date()
    });
});