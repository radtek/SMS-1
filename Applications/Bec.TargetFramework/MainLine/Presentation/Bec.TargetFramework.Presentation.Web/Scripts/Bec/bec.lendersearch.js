(function ($) {
    $.fn.lenderSearch = function (options) {
        var self = this;

        // defaults
        var settings = $.extend({
            searchUrl: ""
        }, options);

        var lenders = new Bloodhound({
            datumTokenizer: Bloodhound.tokenizers.obj.whitespace('Name'),
            queryTokenizer: Bloodhound.tokenizers.whitespace,
            remote: {
                url: settings.searchUrl + '?search=%QUERY',
                wildcard: '%QUERY',
                transform: function (response) {
                    return response.Items;
                }
            }
        });

        self.typeahead({
            minLength: 1,
            highlight: true,
            hint: false
        }, {
            display: 'Name',
            source: lenders
        })
        .on('typeahead:asyncrequest', function () {
            self.parent().siblings('.typeahead-spinner').show();
        })
        .on('typeahead:asynccancel typeahead:asyncreceive', function () {
            self.parent().siblings('.typeahead-spinner').hide();
        });

        return self;
    }
})(jQuery);