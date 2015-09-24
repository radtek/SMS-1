
function dupeCheck() {
    //just used for jquery validation remote check cache
    $('#combined').val($('#ac').val() + ":" + $('#sc').val());
    $("#addBankAccount-form").validate().element('#combined');
}

// submit from when Save button clicked
$("#submitAddBankAccount").click(function () {
    $("#addBankAccount-form").submit();
});

$("#addBankAccount-form").validate({
    ignore: '.skip',
    // Rules for form validation
    rules: {
        BankAccountNumber: {
            required: true,
            digits: true,
            minlength: 8
        },
        SortCode: {
            required: true,
            digits: true,
            minlength: 6
        },
        combined: {
            remote: {
                url: $("#addBankAccount-form").data("check"),
                data: {
                    accountNumber: function () {
                        return $('#ac').val();
                    },
                    sortCode: function () {
                        return $('#sc').val();
                    }
                },
                dataType: 'json',
                error: function (xhr, status, error) {
                    checkRedirect(xhr.responseJSON);
                }
            }
        }
    },

    // Do not change code below
    errorPlacement: function (error, element) {
        error.insertAfter(element.parent());
    },

    submitHandler: validateSubmit
});

function validateSubmit(form) {
    $("#submitAddBankAccount").prop('disabled', true);
    form.submit();
}