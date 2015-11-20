$(function () {

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