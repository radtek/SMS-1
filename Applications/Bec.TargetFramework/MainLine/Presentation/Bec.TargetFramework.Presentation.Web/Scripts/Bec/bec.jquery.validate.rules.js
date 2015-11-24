(function ($) {
    $.validator.addMethod("pwcheck",
        function (value, element) {
            return /\d/.test(value) && /[A-Z]/.test(value) && /\W/.test(value);
        }, 'Your password must contain 1 number, 1 uppercase character and 1 symbol');

    $.validator.addMethod("ukmobile",
        function (value, element) {
            return /07[0-9]+/.test(value);
        }, 'Please enter a valid UK mobile number');

    $.validator.addMethod("lettersanddigits",
        function (value, element) {
            return /^[a-z0-9]+$/i.test(value);
        }, 'Your username must contain only letters and digits');

    $.validator.addMethod("nospace",
        function (value, element) {
            return value.indexOf(" ") < 0;
        }, 'Spaces are not allowed');

})(jQuery);