$(function () {

    function setupForm() {
        // submit from when Save button clicked
        $("#submitAddAdditionalBuyer").click(function () {
            $("#addAdditionalBuyer-form").submit();
        });

        $("#addAdditionalBuyer-form").validate({
            ignore: '.skip',
            // Rules for form validation
            rules: {
                "Salutation": {
                    required: true
                },
                "FirstName": {
                    required: true
                },
                "LastName": {
                    required: true
                },
                "Email": {
                    required: true,
                    email: true,
                    remote: {
                        cache: false,
                        url: $('#Email').data("url"),
                        data: { email: function () { return $('#Email').val(); } },
                        dataType: 'json',
                        error: function (xhr, status, error) { checkRedirect(xhr.responseJSON); }
                    }
                },
                "BirthDate": {
                    required: true
                },
                "PhoneNumber": {
                    required: true,
                    digits: true,
                    minlength: 11,
                    maxlength: 11,
                    ukmobile: true
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
        $("#submitAddAdditionalBuyer").prop('disabled', true);
        var formData = $("#addAdditionalBuyer-form").serializeArray();
        fixDate(formData, 'BirthDate', "#birthDateInput");
        ajaxWrapper({
            url: $("#addAdditionalBuyer-form").data("url"),
            type: "POST",
            data: formData
        }).done(function (res) {
            if (res.result === true)
                window.location = $("#addAdditionalBuyer-form").data("redirectto");
            else {
                handleModal({ url: $("#addAdditionalBuyer-form").data("message") + "?title=" + res.title + "&message=" + res.message + "&button=Back" }, {
                    messageButton: function () {
                        $("#submitAddAdditionalBuyer").prop('disabled', false);
                    }
                }, true);
            }
        }).fail(function (e) {
            if (!hasRedirect(e.responseJSON)) {
                console.log(e);
                handleModal({ url: $("#addAdditionalBuyer-form").data("message") + "?title=Error&message=" + e.statusText + "&button=Back" }, {
                    messageButton: function () {
                        $("#submitAddAdditionalBuyer").prop('disabled', false);
                    }
                }, true);
            }
        });
    }

    makeDatePicker("#birthDateInput", {
        maxDate: new Date()
    });
    setupForm();
});
