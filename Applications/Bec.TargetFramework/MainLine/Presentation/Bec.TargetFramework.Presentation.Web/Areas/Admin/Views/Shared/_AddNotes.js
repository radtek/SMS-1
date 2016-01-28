 // submit from when Save button clicked
$("#submitAddNotes").click(function () {
    $("#submitAddNotes").prop('disabled', true)
    $("#addNotes-form").submit();
});