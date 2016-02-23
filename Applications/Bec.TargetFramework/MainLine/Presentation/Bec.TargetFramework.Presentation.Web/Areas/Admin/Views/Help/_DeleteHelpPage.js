$(function () {

    function ignore(e) {
        if (e) e.preventDefault();
    }

    // submit from when Save button clicked
    $("#submitDeleteHelp").click(function () {
        $("#deleteHelp-form").submit();
    });

    $("#deleteHelp-form").validate({
        // Do not change code below
        errorPlacement: function (error, element) {
            error.insertAfter(element.parent());
        },
        submitHandler: validateSubmit
    });

    function validateSubmit(form) {
        $("#submitDeleteHelp").prop('disabled', true);
        form.submit();
    }
})