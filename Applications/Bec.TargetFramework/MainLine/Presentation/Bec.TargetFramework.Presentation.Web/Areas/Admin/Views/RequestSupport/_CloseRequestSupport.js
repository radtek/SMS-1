$(function () {
    function setupForm() {
        // submit from when Save button clicked
        $("#submitCloseRequestSupport").click(function () {
            $("#closeRequestSupport-form").submit();
        });

        $("#closeRequestSupport-form").validate({
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
        $("#submitCloseRequestSupport").prop('disabled', true);
        var formData = $("#closeRequestSupport-form").serializeArray();
        ajaxWrapper({
            url: $("#closeRequestSupport-form").data("url"),
            type: "POST",
            data: formData
        }).done(function (res) {
            if (res.result === true)
                window.location = $("#closeRequestSupport-form").data("redirectto");
            else {
                handleModal({ url: $("#closeRequestSupport-form").data("message") + "?title=" + res.title + "&message=" + res.message + "&button=Back" }, {
                    messageButton: function () {
                        $("#submitCloseRequestSupport").prop('disabled', false);
                    }
                }, true);
            }
        }).fail(function (e) {
            if (!hasRedirect(e.responseJSON)) {
                console.log(e);
                handleModal({ url: $("#closeRequestSupport-form").data("message") + "?title=Error&message=" + e.statusText + "&button=Back" }, {
                    messageButton: function () {
                        $("#submitCloseRequestSupport").prop('disabled', false);
                    }
                }, true);
            }
        });
    }
    setupForm();
});
