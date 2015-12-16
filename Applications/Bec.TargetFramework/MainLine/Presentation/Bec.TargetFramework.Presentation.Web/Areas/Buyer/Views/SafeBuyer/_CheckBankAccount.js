$(function () {
   
    $("#confirmDetails-form").validate({
        ignore: '.skip',
        // Rules for form validation
        rules: {
            accountNumber: {
                required: true,
                digits: true,
                minlength: 8
            },
            sortCode: {
                required: true,
                digits: true,
                minlength: 6
            }
        },

        // Do not change code below
        errorPlacement: function (error, element) {
            error.insertAfter(element.parent());
        },

        submitHandler: validateSubmit
    });

    $("#submitAddTransaction").click(function () {
        $("#confirmDetails-form").submit();
    });
});

function validateSubmit(form) {
    $("#submitAddTransaction").prop('disabled', true);
    var formData = $("#confirmDetails-form").serializeArray();

    var matchDiv = $('#result-match');
    var noMatchDiv = $('#result-no-match');
    var serverErrorDiv = $('#result-server-error');

    matchDiv.hide();
    noMatchDiv.hide();
    serverErrorDiv.hide();

    ajaxWrapper({
        url: $("#confirmDetails-form").data("url"),
        type: "POST",
        data: formData
    }).done(function (res) {
        hideCurrentModal();
        if (res.result == true)
            handleModal({ url: $('#transactionContainer').data('url') + "&accountNumber=" + res.accountNumber + "&sortCode=" + res.sortCode }, null, true);
        else
            handleModal({ url: $('#transactionContainer').data('failurl') + "&accountNumber=" + res.accountNumber + "&sortCode=" + res.sortCode }, null, true);
    }).fail(function (e) {
        if (!hasRedirect(e.responseJSON)) {
            console.log(e);
            serverErrorDiv.show();
            hideCurrentModal();
        }
    });
}