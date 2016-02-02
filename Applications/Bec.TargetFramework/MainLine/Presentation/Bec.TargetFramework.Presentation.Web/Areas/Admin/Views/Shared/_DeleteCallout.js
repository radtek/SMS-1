$(function () {
    // submit from when Save button clicked
    $("#submitDeleteCallouts").click(function () {
        $("#submitDeleteCallouts").prop('disabled', true);
        $("#deleteCallouts-form").submit();
    });
})
