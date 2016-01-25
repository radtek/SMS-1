$("#submitPushProduct").click(function () {
    $("#submitPushProduct").prop('disabled', true);
    $("#pushProduct-form").submit();
});