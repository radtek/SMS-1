$(function () {

    function setupForm() {
        // submit from when Save button clicked
        $("#submitAddGiftor").click(function () {
            $("#addGiftor-form").submit();
        });

        $("#addGiftor-form").validate({
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
                        url: $('#Email').data("url"),
                        data: { email: function () { return $('#Email').val(); } },
                        dataType: 'json',
                        error: function (xhr, status, error) { checkRedirect(xhr.responseJSON); }
                    }
                },
                "BirthDate": {
                    required: true,
                    dateGB: true
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
        $("#submitAddGiftor").prop('disabled', true);
        var formData = $("#addGiftor-form").serializeArray();

        ajaxWrapper({
            url: $("#addGiftor-form").data("url"),
            type: "POST",
            data: formData
        }).done(function (res) {
            if (res.result === true)
                window.location = $("#addGiftor-form").data('redirectto');
            else {
                handleModal({ url: $("#addGiftor-form").data("message") + "?title=" + res.title + "&message=" + res.message + "&button=Back" }, {
                    messageButton: function () {
                        $("#submitAddTransaction").prop('disabled', false);
                    }
                }, true);
            }
        }).fail(function (e) {
            console.log(e);
            handleModal({ url: $("#addGiftor-form").data("message") + "?title=Error&message=" + e + "&button=Back" }, {
                messageButton: function () {
                    $("#submitAddGiftor").prop('disabled', false);
                }
            }, true);
        });
    }

    function setupDateOfBirthInput() {
        var now = new Date();
        $("#birthDateInput").datepicker({
            dateFormat: "dd/mm/yy",
            maxDate: now,
            changeMonth: true,
            changeYear: true,
            yearRange: "-110:+0",
            showButtonPanel: true,
            prevText: "<i class=\"fa fa-chevron-left\"></i>",
            nextText: "<i class=\"fa fa-chevron-right\"></i>",
            onSelect: function (date, inst) { $(this).valid(); }
        });
    }

    setupDateOfBirthInput();
    setupForm();
});
