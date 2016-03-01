$(function () {
    jQuery.event.handle = jQuery.event.dispatch
    function setupFormRequest() {
        // submit from when Save button clicked
        $("#submitAddRequestSupport").click(function () {
            $("#addRequestSupport-form").submit();
        });
        $("#addRequestSupport-form").validate({
            ignore: '.skip',
            // Rules for form validation
            rules: {
                'Title': {
                    required: true
                },
                'Description': {
                    required: true
                },
                'RequestType': {
                    required: true
                }
            },
            // Do not change code below
            errorPlacement: function (error, element) {
                error.insertAfter(element.parent());
            },
            submitHandler: submitFormRequest
        });
    }

    function submitFormRequest(form) {
        $("#submitAddRequestSupport").prop('disabled', true);
        var formData = $("#addRequestSupport-form").serializeArray();
        ajaxWrapper({
            url: $("#addRequestSupport-form").attr("action"),
            type: "POST",
            data: formData
        }).done(function (res) {
            if (res.result === true){
                location.reload();
            }
            else {
                handleModal({ url: $("#addRequestSupport-form").data("message") + "?title=" + res.title + "&message=" + res.message + "&button=Back" }, {
                    messageButton: function () {
                        $("#submitAddRequestSupport").prop('disabled', false);
                    }
                }, true);
            }
        }).fail(function (e) {
            if (!hasRedirect(e.responseJSON)) {
                console.log(e);
                handleModal({ url: $("#addRequestSupport-form").data("message") + "?title=Error&message=" + e.statusText + "&button=Back" }, {
                    messageButton: function () {
                        $("#submitAddRequestSupport").prop('disabled', false);
                    }
                }, true);
            }
        });
    }
    setupFormRequest();
});
