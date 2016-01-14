// submit from when Save button clicked
$("#submitVerify").click(function () {
    $("#verify-form").submit();
});

// Validation
$("#verify-form").validate({
    ignore: '.skip',
    // Rules for form validation
    rules: {
        notes: {
            required: true
        },
        name: {
            required: true
        },
        filesPerMonth: {
            required: true,
            digits: true
        },
        regulatorNumber: {
            required: true,
            number: true,
            remote: {
                cache: false,
                url: $('#RegulatorNumber').data("url"),
                data: {
                    regulatorNumber: function () {
                        return $('#RegulatorNumber').val();
                    },
                    __RequestVerificationToken: $("input[name='__RequestVerificationToken']").val()
                },
                type: 'POST',
                dataType: 'json',
                error: function (xhr, status, error) { checkRedirect(xhr.responseJSON); }
            }
        }
    },

    // Do not change code below
    errorPlacement: function (error, element) {
        error.insertAfter(element.parent());
    },

    submitHandler: validateVerifySubmit
});

function validateVerifySubmit(form) {
    $("#submitVerify").prop('disabled', true);
    form.submit();
}