$(function () {
    function ignore(e) {
        if (e) e.preventDefault();
    }

    // submit from when Save button clicked
    $("#submitAddCallout").click(function () {
        $("#addCallout-form").submit();
    });

    $("#addCallout-form").validate({
        ignore: '.skip',
        // Rules for form validation
        rules: {

            RoleID: {
                required: true
            },
            Title: {
                required: true
            }, Selectore: {
                required: true
            }
            ,
            Description: {
                required: true
            },
            Selector: {
                required: true
            }
            ,
            EffectiveOn: {
                required: true
            },
            Position: {
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
        $("#submitAddCallout").prop('disabled', true);
        form.submit();
    }
    makeDatePicker("#effectiveDateInput", {
        minDate: new Date(), yearRange: "-110:+1"
    }, {
        onSelect: function (date, inst) {
            var birthDateField = $('#EffectiveOn');
            birthDateField.val(inst.input.data("val"));
            birthDateField.valid();
        }
    });
})
