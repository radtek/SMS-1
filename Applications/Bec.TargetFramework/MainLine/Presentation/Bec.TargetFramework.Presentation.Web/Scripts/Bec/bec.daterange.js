(function ($) {
    $.extend({
        becDateRange: function (options) {
            var dateTo = new Date();
            var dateFrom = new Date(dateTo.getFullYear() - 1, dateTo.getMonth(), dateTo.getDate());

            // defaults
            var settings = $.extend({
                dateFromInputSelector: "",
                dateToInputSelector: "",
                dateFromShowButtonSelector: "",
                dateToShowButtonSelector: "",
                dateFormat: "dd/mm/yy",
                dateFrom: dateFrom,
                dateTo: dateTo
            }, options);

            // Date Range Picker
            $(settings.dateFromInputSelector).datepicker({
                defaultDate: settings.dateFrom,
                dateFormat: settings.dateFormat,
                changeMonth: true,
                showButtonPanel: true,
                prevText: "<i class=\"fa fa-chevron-left\"></i>",
                nextText: "<i class=\"fa fa-chevron-right\"></i>"
            }).datepicker("setDate", settings.dateFrom);

            $(settings.dateToInputSelector).datepicker({
                defaultDate: settings.dateTo,
                dateFormat: settings.dateFormat,
                changeMonth: true,
                showButtonPanel: true,
                prevText: "<i class=\"fa fa-chevron-left\"></i>",
                nextText: "<i class=\"fa fa-chevron-right\"></i>"
            }).datepicker("setDate", settings.dateTo);

            $(settings.dateFromShowButtonSelector).click(function () {
                $(settings.dateFromInputSelector).datepicker("show");
            });
            $(settings.dateToShowButtonSelector).click(function () {
                $(settings.dateToInputSelector).datepicker("show");
            });
        }
    });
})(jQuery);