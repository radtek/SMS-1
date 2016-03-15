(function ($) {
    $.fn.fieldPendingUpdates = function (options) {
        
        var self = this;
        var popovers = [];
        var settings = $.extend({
            selector: ".pending-update",
            includeApproveReject: false,
            container: false,
            showFirst: false
        }, options);

        self.find(settings.selector).each(function (i, anchor) {
            var anchorElement = $(anchor);
            $(anchor).parent().addClass('pending-changes-input');
            var fullName = anchorElement.data('pending-fullname');
            var modifiedOn = anchorElement.data('pending-modifiedon');

            var title = 'Pending update from ' + fullName + ', on ' + dateString(modifiedOn);

            var popover = anchorElement.popover({
                container: settings.container,
                content: getContent(i, anchorElement),
                html: true,
                placement: "bottom",
                title: title,
                trigger: "focus"
            });

            popovers.push(popover);
        });

        if (settings.showFirst) {
            $(settings.container).on('shown.bs.modal', function () {
                popovers[0].focus();
            });
        }

        function showPopover(index, wrap) {
            if (wrap) {
                if (index >= popovers.length) index = 0;
                if (index < 0) index = popovers.length - 1;
            }
            if (index >= 0 && index < popovers.length) {
                setTimeout(function () {
                    console.log(popovers[index]);
                    popovers[index].focus();
                }, 100);
            }
        }

        function getContent(i, anchorElement) {
            return function () {
                var originalValue = anchorElement.data('pending-originalval');
                var pendingValue = anchorElement.data('pending-value');

                var formattedOriginalValue = originalValue ? originalValue : '<span class="pending-no-value">Empty</span>';
                var formattedPendingValue = pendingValue ? pendingValue : '<span class="pending-no-value">Removed</span>';

                var content = $('<table class="pending-update-table"><tr><td>Original:</td><td><strong>' + formattedOriginalValue + '</strong></td></tr><tr><td>Requested:</td><td><strong>' + formattedPendingValue + '</strong></td></tr></table>');
                if (settings.includeApproveReject) {
                    var inputSelector = '#' + anchorElement.data('input-id');
                    var actionedSelector = '#' + anchorElement.data('input-id') + '-check';

                    var approveLabel = $('<label for="acceptRadio" class="btn btn-default approve-reject-button margin-left-5"><i class="fa fa-check accept margin-right-5"></i>Use</label>');
                    var approveButton = $('<input type="radio" name="' + anchorElement.data('input-id') + '-radio" id="acceptRadio" class="hidden" />');

                    var rejectLabel = $('<label for="rejectRadio" class="btn btn-default approve-reject-button"><i class="fa fa-times reject margin-right-5"></i>Discard</label>');
                    var rejectButton = $('<input type="radio" name="' + anchorElement.data('input-id') + '-radio" id="rejectRadio" class="hidden" />');

                    var state = $(inputSelector).data('approvereject');
                    if (state === 'approve')
                        approveButton.attr('checked', 'checked');
                    else if (state === 'reject')
                        rejectButton.attr('checked', 'checked');

                    var prevButton = $('<button class="btn"><i class="fa fa-chevron-left"></i></button>');
                    var nextButton = $('<button class="btn margin-left-5"><i class="fa fa-chevron-right"></i></button>');

                    var buttonContainer = $('<div></div>');
                    buttonContainer.append(prevButton).append(approveButton).append(approveLabel).append(rejectButton).append(rejectLabel).append(nextButton);

                    var closeButton = $('<a class="popover-close-button" title="Close"><i class="fa fa-times"></i></a>');

                    content = $('<div></div>').append(closeButton).append(content).append(buttonContainer);

                    approveLabel.on('mousedown', function () {
                        action(true, pendingValue);
                    });

                    rejectLabel.on('mousedown', function () {
                        action(false, originalValue);
                    });

                    prevButton.on('mousedown', function () {
                        showPopover(i - 1, true);
                    });

                    nextButton.on('mousedown', function () {
                        showPopover(i + 1, true);
                    });

                    function action(result, value) {
                        var button = anchorElement.parent().find('button.pending-changes-button');
                        button.removeClass('not-actioned');
                        button.addClass('actioned');
                        var glyph = button.find('i');
                        glyph.removeClass('fa-chevron-right');
                        if (result) {
                            glyph.addClass('fa-check');
                            glyph.removeClass('fa-times');
                            glyph.removeClass('fa-reject-fix');
                            button.addClass('accepted');
                            button.removeClass('rejected');
                        }
                        else {
                            glyph.removeClass('fa-check');
                            glyph.addClass('fa-times');
                            glyph.addClass('fa-reject-fix');
                            button.removeClass('accepted');
                            button.addClass('rejected');
                        }
                        anchorElement.parent().removeClass('pending-changes-input');
                        $(actionedSelector).attr('checked', 'true');
                        $(inputSelector).data('approvereject', result ? 'approve' : 'reject');
                        $(inputSelector).val(value);
                        showPopover(i + 1, false);
                    }
                }
                return content;
            }
        }
    }
})(jQuery);