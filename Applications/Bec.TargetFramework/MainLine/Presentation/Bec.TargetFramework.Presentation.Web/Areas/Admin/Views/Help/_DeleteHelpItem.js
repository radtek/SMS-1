$(function () {
    'use strict';

    $("#submitDeleteHelpItem").click(function () {
        if ($("#deleteHelpItem-form").valid()) {
            $.ajax({
                url: $("#deleteHelpItem-form").attr('action'),
                type: 'POST',
                data: $("#deleteHelpItem-form").serialize(),
                complete: function (data) {
                        $("#ehGrid").data('kendoGrid').dataSource.read();
                        $('#cancelDeleteHelpItem').click();
                }
            });
        }
    });
});