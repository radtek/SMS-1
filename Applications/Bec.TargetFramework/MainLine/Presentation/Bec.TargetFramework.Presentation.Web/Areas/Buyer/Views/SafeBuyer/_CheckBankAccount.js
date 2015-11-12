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

    var index = $("#confirmDetails-form").data("index");
    var matchDiv = $('#result-match-' + index);
    var noMatchDiv = $('#result-no-match-' + index);
    var serverErrorDiv = $('#result-server-error-' + index);

    matchDiv.hide();
    noMatchDiv.hide();
    serverErrorDiv.hide();

    ajaxWrapper({
        url: $("#confirmDetails-form").data("url"),
        type: "POST",
        data: formData
    }).done(function (res) {
        showDetails(res.data, res.accountNumber, res.sortCode, index);
        if (res.result == true)
            matchDiv.show();
        else
            noMatchDiv.show();
        hideCurrentModal();
    }).fail(function (e) {
        if (!hasRedirect(e.responseJSON)) {
            console.log(e);
            serverErrorDiv.show();
            hideCurrentModal();
        }
    });
}

function showDetails(data, an, sc, index) {
    $('#accountNumberMatch-' + index).text(an);
    $('#sortCodeMatch-' + index).text(sc);
    $('#accountNumberNoMatch-' + index).text(an);
    $('#sortCodeNoMatch-' + index).text(sc);

    $('#post-no-match-' + index).hide();
    $('#notify-button-' + index).show();
}