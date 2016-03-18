$(function () {
    'use strict';

    $("#submitDeleteHelpItem").click(function () {
        if ($("#deleteHelpItem-form").valid()) {
            $.ajax({
                url: $("#deleteHelpItem-form").attr('action'),
                type: 'POST',
                data: $("#deleteHelpItem-form").serialize(),
                success: function (data) {
                    if (data.success === true) {
                        $("#ehGrid").data('kendoGrid').dataSource.read();
                        $('#cancelDeleteHelpItem').click();
                    }
                }
            });
        }
    });
});