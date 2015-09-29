$(function () {
    $("#check-Form").validate({
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

        submitHandler: validateSubmit
    });
});

function validateSubmit(form) {
    $("#submitButton").prop('disabled', true);

    $('#result').empty();
    $('#result').append("Please wait...");

    var formData = $("#check-Form").serializeArray();
    ajaxWrapper({
        url: $("#check-Form").data("url"),
        type: "POST",
        data: formData
    }).done(function (res) {
        $("#submitButton").prop('disabled', false);
        $('#result').empty();
        if (res.result == true)
            $('#result').append("Match");
        else {
            $('#result').append("No Match");
        }
    }).fail(function (e) {
        if (!hasRedirect(e.responseJSON)) {
            $("#submitButton").prop('disabled', false);
            $('#result').empty();

            console.log(e);
            $('#result').append("Error");
        }
    });
}
