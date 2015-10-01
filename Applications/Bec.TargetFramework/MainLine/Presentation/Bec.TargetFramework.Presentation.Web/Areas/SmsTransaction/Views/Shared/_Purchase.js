$("#submitPurchase").click(function () {
    $("#submitPurchase").prop('disabled', true);
    var formData = $("#purchase-form").serializeArray();
    ajaxWrapper({
        url: $("#purchase-form").data("url"),
        type: "POST",
        data: formData
    }).done(function (res) {
        if (res.result == true)
            hideCurrentModal();
        else
            handleModal({ url: $("#purchase-form").data("message") + "?title=" + res.title + "&message=" + res.message + "&button=Back" }, {
                messageButton: function () {
                    $("#submitPurchase").prop('disabled', false);
                }
            }, true);
    }).fail(function (e) {
        if (!hasRedirect(e.responseJSON)) {
            console.log(e);
            handleModal({ url: $("#purchase-form").data("message") + "?title=Error&message=" + e.statusText + "&button=Back" }, {
                messageButton: function () {
                    $("#submitPurchase").prop('disabled', false);
                }
            }, true);
        }
    });

});