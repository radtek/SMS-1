// submit from when Save button clicked
$("#submitReinstate").click(function () {
    $("#submitReinstate").prop('disabled', true);
    $("#reinstate-form").submit();
});