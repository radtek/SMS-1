$(function () {
    $.validator.addMethod("ukmobile",
    function (value, element) {
        return /07[0-9]+/.test(value);
    }, 'Please enter a valid UK mobile number');

    $("#personal-details-form").validate({
        ignore: '.skip',
        // Rules for form validation
        rules: {
            "mobileNumber": {
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
        }
    });

});