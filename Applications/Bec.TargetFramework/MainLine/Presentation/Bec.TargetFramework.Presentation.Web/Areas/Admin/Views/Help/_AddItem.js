$(function () {
    function ignore(e) {
        if (e) e.preventDefault();
    }
    function addRequestVerificationToken(data) {
        data.__RequestVerificationToken = $('input[name=__RequestVerificationToken]').val();
        return data;
    };

    // submit from when Save button clicked
    $("#submitAddItem").click(function () {
        
        var inputValue = {     
            Title: $('#Title').val(),
            Description: $('#Description').val(),
            Selector: $('#Selector').val(),
            TabContainerId: $('#TabContainerId').val(),
            EffectiveOn: $('#EffectiveOn').val(),
            Position: $('#Position').val()
        };
        
        var pagedata = JSON.stringify(inputValue);
        //pagedata = pagedata + '&__RequestVerificationToken=' + $('input[name= "__RequestVerificationToken"]').val();

        ajaxWrapper({
            url: '/Admin/Help/AddItem',            
            data: pagedata,
        type: 'POST',
        contentType: 'application/json; charset=utf-8'
    })
                .done(function (response) {
                    if (response != null || response != undefined) {
                        console.log(response);
                    }
                })
    
});

$("#addItem-form").validate({
    ignore: '.skip',
    // Rules for form validation
    rules: {
        //PageID: {
        //    required: true
        //},
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
    form.submit();
}
})