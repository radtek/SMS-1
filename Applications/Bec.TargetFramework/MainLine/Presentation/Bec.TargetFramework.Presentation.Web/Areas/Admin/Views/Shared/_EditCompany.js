// submit from when Save button clicked
$("#submitEditCompany").click(function () {
    $("#submitEditCompany").prop('disabled', true)
    $("#editCompany-form").submit();
});