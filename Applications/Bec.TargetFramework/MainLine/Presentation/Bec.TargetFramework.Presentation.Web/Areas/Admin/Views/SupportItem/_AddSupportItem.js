$(function () {
    jQuery.event.handle = jQuery.event.dispatch
    function setupFormRequest() {
        // submit from when Save button clicked
        $("#submitAddSupportItem").click(function () {
            $("#addSupportItem-form").submit();
        });
        $("#addSupportItem-form").validate({
            ignore: '.skip',
            // Rules for form validation
            rules: {
                'Title': {
                    required: true
                },
                'Description': {
                    required: true
                },
                'RequestTypeID': {
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
        $("#submitAddSupportItem").prop('disabled', true);
        var formData = $("#addSupportItem-form").serializeArray();
        ajaxWrapper({
            url: $("#addSupportItem-form").attr("action"),
            type: "POST",
            data: formData
        }).done(function (res) {
            if (res.result === true){
                location.reload();
            }
            else {
                handleModal({ url: $("#addSupportItem-form").data("message") + "?title=" + res.title + "&message=" + res.message + "&button=Back" }, {
                    messageButton: function () {
                        $("#submitAddSupportItem").prop('disabled', false);
                    }
                }, true);
            }
        }).fail(function (e) {
            if (!hasRedirect(e.responseJSON)) {
                console.log(e);
                handleModal({ url: $("#addSupportItem-form").data("message") + "?title=Error&message=" + e.statusText + "&button=Back" }, {
                    messageButton: function () {
                        $("#submitAddSupportItem").prop('disabled', false);
                    }
                }, true);
            }
        });
    }
    setupFormRequest();
});
