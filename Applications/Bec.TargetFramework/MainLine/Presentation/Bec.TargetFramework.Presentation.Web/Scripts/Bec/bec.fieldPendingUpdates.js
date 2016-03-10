(function ($) {
    $.fn.fieldPendingUpdates = function (options) {
        
        var self = this;
        var settings = $.extend({
            selector: ".pending-update",
            includeApproveReject: false,
            container: false
        }, options);

        return self.find(settings.selector).each(function (i, anchor) {
            var anchorElement = $(anchor);
            var originalValue = anchorElement.data('pending-originalval');
            var pendingValue = anchorElement.data('pending-value');
            var fullName = anchorElement.data('pending-fullname');
            var modifiedOn = anchorElement.data('pending-modifiedon');

            if (!originalValue) originalValue = '<span class="pending-no-value">Empty</span>';
            if (!pendingValue) pendingValue = '<span class="pending-no-value">Removed</span>';

            var content = $('<table class="pending-update-table"><tr><td>Original:</td><td><strong>' + originalValue + '</strong></td></tr><tr><td>Requested:</td><td><strong>' + pendingValue + '</strong></td></tr></table>');
            if (settings.includeApproveReject) {
                var approveButton = $('<button class="btn btn-default"><i class="fa fa-check accept"></i></button>');
                var rejectButton = $('<button class="btn btn-default"><i class="fa fa-times reject"></i></button>');
                var buttonContainer = $('<div></div>');
                buttonContainer.append(approveButton).append(rejectButton);
                content = $('<div></div>').append(content).append(buttonContainer);

                rejectButton.on('click', function () {
                    
                });
                approveButton.on('click', function () {

                });
            }
            var title = 'Pending update from ' + fullName + ', on ' + dateString(modifiedOn);

            anchorElement.popover({
                container: settings.container,
                content: content,
                html: true,
                placement: "bottom",
                title: title,
                trigger: "click"
            });
        });
    }
})(jQuery);