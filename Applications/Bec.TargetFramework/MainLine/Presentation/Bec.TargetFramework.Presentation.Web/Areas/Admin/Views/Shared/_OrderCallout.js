$(function () {
    $("#sortable").sortable({ containment: 'parent' });
    $("#submitOrderCallout").on("click", function (event, ui) {
        var valList = '';
        var items = $('#sortable li');
        $('#sortable li').each(function () {
            var index = items.index(this);
            var calo = $(this).data('callout');
            valList += index + ', ' + calo + '?'
        })
        $('#calloutOrderList').val(valList);
        $('#calloutRoleId').val($('#roleDropdown').val());

        $("#submitOrderCallout").prop('disabled', true);
        var formData = $("#orderCallout-form").serializeArray();
        ajaxWrapper({
            url: $("#orderCallout-form").data("url"),
            type: "POST",
            data: formData
        }).done(function (res) {
            if (res.result === true)
                window.location = $("#orderCallout-form").data("redirectto");
            else {
                handleModal({ url: $("#orderCallout-form").data("message") + "?title=" + res.title + "&message=" + res.message + "&button=Back" }, {
                    messageButton: function () {
                        $("#submitOrderCallout").prop('disabled', false);
                    }
                }, true);
            }
        }).fail(function (e) {
            if (!hasRedirect(e.responseJSON)) {
                console.log(e);
                handleModal({ url: $("#orderCallout-form").data("message") + "?title=Error&message=" + e.statusText + "&button=Back" }, {
                    messageButton: function () {
                        $("#submitOrderCallout").prop('disabled', false);
                    }
                }, true);
            }
        });

    });
})
    
   