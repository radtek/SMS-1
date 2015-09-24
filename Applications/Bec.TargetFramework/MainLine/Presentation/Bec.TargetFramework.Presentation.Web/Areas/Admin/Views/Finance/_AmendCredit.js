// submit from when Save button clicked
$("#submitAmend").click(function () {
    $("#amend-form").submit();
});

$("#amend-form").validate({
    ignore: '.skip',
    // Rules for form validation
    rules: {
        amount: {
            required: true,
            number: true,
            min: -10000,
            max: 10000
        },
        reason: {
            required: true
        }
    },

    // Do not change code below
    errorPlacement: function (error, element) {
        error.insertAfter(element.parent());
    },

    submitHandler: validateSubmit
});

function validateSubmit(form) {
    $("#submitAmend").prop('disabled', true);
    var formData = $("#amend-form").serializeArray();
    ajaxWrapper({
        url: $("#amend-form").data("url"),
        type: "POST",
        data: formData
    }).done(function (res) {
        hideCurrentModal();
        applyFilter();
    }).fail(function (e) {
        handleModal({ url: $("#amend-form").data("fail") + "?title=Error&message=" + e + "&button=Back" }, {
            messageButton: function () {
                $("#submitAmend").prop('disabled', false);
            }
        }, true);
    });
}