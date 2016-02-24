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
            },            
            EffectiveOn: {
                required: true
            }
        },

        // Do not change code below
        errorPlacement: function (error, element) {
            error.insertAfter(element.parent());
        },

        submitHandler: validateSubmit
    });

    function createItem(item) {
        var itemHtml = '<li class="ui-state-default" data-item-id="">' +
                        '<span class="ui-icon ui-icon-arrowthick-2-n-s"></span>' +
                        '<span class="help-item-title">' + item.Title + '</span>' +
                        ' <span class="help-item-btn">' +
                         ' <a class="btn btn-primary btn-sm" data-modallink="true" data-url=""><i class="fa fa-times"></i></a>' +
                         ' <a class="btn btn-primary btn-sm" data-modallink="true" data-url=""><i class="fa fa-edit"></i></a> ' +
                        '</span>' +
                      ' </li>';
        return itemHtml
    }

    function validateSubmit(form) {
        $("#submitAddItem").prop('disabled', true);
        ajaxWrapper({
            url: $(form).attr('action'),
            data: $(form).serializeArray(),
            type: 'POST'
        })
                .done(function (response) {
                    if (response != null || response != undefined) {
                        $('#helpItemListContainer').html("");
                        $("#submitAddItem").prop('disabled', false);
                        if (response.Items != null && response.Items.length >= 1) {
                            for (var i = 0; i < response.Items.length; i++) {
                                $('#helpItemListContainer').append(createItem(response.Items[i]));
                            }
                            $('#helpItemListContainer').sortable({ containment: 'parent' });
                        }
                    }
                })
    }

    makeDatePicker("#effectiveDateInput", {
        minDate: new Date(), yearRange: "-110:+1"
    }, {
        onSelect: function (date, inst) {
            var birthDateField = $('#EffectiveOn');
            birthDateField.val(inst.input.data("val"));
            birthDateField.valid();
            console.log(inst);
            console.log(inst.input);
            console.log(inst.input.data("val"));
        }
    });
        
       
})