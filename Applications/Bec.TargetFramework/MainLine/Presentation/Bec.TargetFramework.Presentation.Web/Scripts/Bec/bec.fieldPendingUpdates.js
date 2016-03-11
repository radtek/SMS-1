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
            $(anchor).parent().addClass('pending-changes-input');
            var fullName = anchorElement.data('pending-fullname');
            var modifiedOn = anchorElement.data('pending-modifiedon');

            var title = 'Pending update from ' + fullName + ', on ' + dateString(modifiedOn);

            anchorElement.popover({
                container: settings.container,
                content: getContent(anchorElement),
                html: true,
                placement: "bottom",
                title: title,
                trigger: "focus"
            });
        });

        function getContent(anchorElement) {
            return function () {
                var originalValue = anchorElement.data('pending-originalval');
                var pendingValue = anchorElement.data('pending-value');

                var formattedOriginalValue = originalValue ? originalValue : '<span class="pending-no-value">Empty</span>';
                var formattedPendingValue = pendingValue ? pendingValue : '<span class="pending-no-value">Removed</span>';

                var content = $('<table class="pending-update-table"><tr><td>Original:</td><td><strong>' + formattedOriginalValue + '</strong></td></tr><tr><td>Requested:</td><td><strong>' + formattedPendingValue + '</strong></td></tr></table>');
                if (settings.includeApproveReject) {
                    var inputSelector = '#' + anchorElement.data('input-id');
                    var actionedSelector = '#' + anchorElement.data('input-id') + '-check';

                    var approveLabel = $('<label for="acceptRadio" class="btn btn-default approve-reject-button"><i class="fa fa-check accept"></i>Use</label>');
                    var approveButton = $('<input type="radio" name="' + anchorElement.data('input-id') + '-radio" id="acceptRadio" class="hidden" />');

                    var rejectLabel = $('<label for="rejectRadio" class="btn btn-default approve-reject-button"><i class="fa fa-times reject"></i>Discard</label>');
                    var rejectButton = $('<input type="radio" name="' + anchorElement.data('input-id') + '-radio" id="rejectRadio" class="hidden" />');

                    var state = $(inputSelector).data('approvereject');
                    if (state === 'approve')
                        approveButton.attr('checked', 'checked');
                    else if (state === 'reject')
                        rejectButton.attr('checked', 'checked');

                    var buttonContainer = $('<div></div>');
                    buttonContainer.append(approveButton).append(approveLabel).append(rejectButton).append(rejectLabel);
                    content = $('<div></div>').append(content).append(buttonContainer);

                    approveLabel.on('mousedown', function () {
                        anchorElement.parent().removeClass('pending-changes-input');
                        $(actionedSelector).attr('checked', 'true');
                        $(inputSelector).data('approvereject', 'approve');
                        $(inputSelector).val(pendingValue);
                    });

                    rejectLabel.on('mousedown', function () {
                        anchorElement.parent().removeClass('pending-changes-input');
                        $(actionedSelector).attr('checked', 'true');
                        $(inputSelector).data('approvereject', 'reject');
                        $(inputSelector).val(originalValue);
                    });
                }
                return content;
            }
        }
    }
})(jQuery);