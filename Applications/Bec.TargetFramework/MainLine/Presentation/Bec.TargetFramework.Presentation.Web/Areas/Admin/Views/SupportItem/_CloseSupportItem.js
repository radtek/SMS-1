$(function () {
    function setupForm() {
        // submit from when Save button clicked
        $("#submitCloseSupportItem").click(function () {
            $("#closeSupportItem-form").submit();
        });

        $("#closeSupportItem-form").validate({
            ignore: '.skip',
            // Rules for form validation
            rules: {
                'Model.Reason': {
                    required: true
                }
            },
            // Do not change code below
            errorPlacement: function (error, element) {
                error.insertAfter(element.parent());
            },
            submitHandler: submitForm
        });
    }

    function submitForm(form) {
        $("#submitCloseSupportItem").prop('disabled', true);
        var formData = $("#closeSupportItem-form").serializeArray();
        ajaxWrapper({
            url: $("#closeSupportItem-form").data("url"),
            type: "POST",
            data: formData
        }).done(function (res) {
            if (res.result === true)
                window.location = $("#closeSupportItem-form").data("redirectto");
            else {
                handleModal({ url: $("#closeSupportItem-form").data("message") + "?title=" + res.title + "&message=" + res.message + "&button=Back" }, {
                    messageButton: function () {
                        $("#submitCloseSupportItem").prop('disabled', false);
                    }
                }, true);
            }
        }).fail(function (e) {
            if (!hasRedirect(e.responseJSON)) {
                console.log(e);
                handleModal({ url: $("#closeSupportItem-form").data("message") + "?title=Error&message=" + e.statusText + "&button=Back" }, {
                    messageButton: function () {
                        $("#submitCloseSupportItem").prop('disabled', false);
                    }
                }, true);
            }
        });
    }
    setupForm();
});
