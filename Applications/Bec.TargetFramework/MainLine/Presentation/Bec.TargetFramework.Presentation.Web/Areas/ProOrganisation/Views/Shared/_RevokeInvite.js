// submit from when Save button clicked
$("#submitrevokeLogins").click(function () {
    $("#submitrevokeLogins").prop('disabled', true);
    $("#revokeLogins-form").submit();
});