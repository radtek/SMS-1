$(function () {
    function ignore(e) {
        if (e) e.preventDefault();
    }

    // submit from when Save button clicked
    $("#submitAddItem").click(function () {
        $("#addItem-form").submit();
    });

    $("#addItem-form").validate({
        ignore: '.skip',
        // Rules for form validation
        rules: {
            Title: {
                required: true
            },
            Selector: {
                required: true
            },
            Description: {
                required: true
            }
        },

        // Do not change code below
        errorPlacement: function (error, element) {
            error.insertAfter(element.parent());
        },

        submitHandler: validateSubmit
    });

    function validateSubmit(form) {        
        $("#submitAddItem").prop('disabled', true);
        ajaxWrapper({
            url: $(form).attr('action'),            
            data: $(form).serializeArray(),
            type: 'POST'
        })
                .done(function (response) {
                    if (response != null || response != undefined) {
                        console.log(response);
                        $("#submitAddItem").prop('disabled', false);
                    }
                })
    }
})