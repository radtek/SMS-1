(function ($) {
    $.validator.addMethod("dateGB", function (value, element) {
        return /^(0?[1-9]|[12][0-9]|3[01])[\/\-](0?[1-9]|1[012])[\/\-]\d{4}$/.test(value);
    }, "Please enter a valid date.");
})(jQuery);