// submit from when Save button clicked
$("#submitResendLogins").click(function () {
    $("#submitResendLogins").prop('disabled', true);
    $("#resendLogins-form").submit();
});