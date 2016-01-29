
function ignore(e) {
    if (e) e.preventDefault();
}

// submit from when Save button clicked
$("#submitDeleteItem").click(function () {
    $("#deleteItem-form").submit();
});

$("#deleteItem-form").validate({
    ignore: '.skip',
    // Rules for form validation
    rules: {
        //PageID: {
        //    required: true
        //},
        //ItemName: {
        //    required: true
        //},
        //ItemSelector: {
        //    required: true
        //}
    },

    // Do not change code below
    errorPlacement: function (error, element) {
        error.insertAfter(element.parent());
    },

    submitHandler: validateSubmit
});

function validateSubmit(form) {
    $("#submitDeleteItem").prop('disabled', true);
    form.submit();
}