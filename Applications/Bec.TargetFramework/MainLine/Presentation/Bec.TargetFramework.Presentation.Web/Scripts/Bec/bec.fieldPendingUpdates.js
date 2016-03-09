(function ($) {
    $.fn.fieldPendingUpdates = function () {
        var self = this;

        return self.find('.pending-update').each(function (i, anchor) {
            var anchorElement = $(anchor);
            var originalValue = anchorElement.data('pending-originalval');
            var pendingValue = anchorElement.data('pending-value');
            var fullName = anchorElement.data('pending-fullname');
            var modifiedOn = anchorElement.data('pending-modifiedon');

            var content = $('<table class="pending-update-table"><tr><td>Original:</td><td><strong>' + originalValue + '</strong></td></tr><tr><td>Requested:</td><td><strong>' + pendingValue + '</strong></td></tr></table>');
            var title = 'Pending update from ' + fullName + ', on ' + dateString(modifiedOn);

            anchorElement.popover({
                content: content,
                html: true,
                placement: "bottom",
                title: title,
                trigger: "focus"
            });
        });
    }
})(jQuery);