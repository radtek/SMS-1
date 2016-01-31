$(function () {
    function setupForm() {
        // submit from when Save button clicked
        $("#submitEditCallout").click(function () {
            $("#editCallout-form").submit();
        });

        $("#editCallout-form").validate({
            ignore: '.skip',
            // Rules for form validation
            rules: {
                'Model.RoleID': {
                    required: true
                },
                'Model.Title': {
                    required: true
                },
                'Model.Description': {
                    required: true
                },
                'Model.Selector': {
                    required: true
                },
                'Model.EffectiveOn': {
                    required: true
                },
                'Model.Position': {
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
        $("#submitEditCallout").prop('disabled', true);
        var formData = $("#editCallout-form").serializeArray();
        fixDate(formData, 'Model.EffectiveOn', "#effectiveDateInput");
        ajaxWrapper({
            url: $("#editCallout-form").data("url"),
            type: "POST",
            data: formData
        }).done(function (res) {
            if (res.result === true)
                window.location = $("#editCallout-form").data("redirectto");
            else {
                handleModal({ url: $("#editCallout-form").data("message") + "?title=" + res.title + "&message=" + res.message + "&button=Back" }, {
                    messageButton: function () {
                        $("#submitEditCallout").prop('disabled', false);
                    }
                }, true);
            }
        }).fail(function (e) {
            if (!hasRedirect(e.responseJSON)) {
                console.log(e);
                handleModal({ url: $("#editCallout-form").data("message") + "?title=Error&message=" + e.statusText + "&button=Back" }, {
                    messageButton: function () {
                        $("#submitEditCallout").prop('disabled', false);
                    }
                }, true);
            }
        });
    }

    makeDatePicker("#effectiveDateInput", {
        minDate: new Date()
    });
    setupForm();
});
