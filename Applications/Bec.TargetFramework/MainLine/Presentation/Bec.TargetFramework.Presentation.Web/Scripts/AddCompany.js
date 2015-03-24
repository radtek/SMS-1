// submit from when Save button clicked
$("#formSubmit").click(function () {
    $("#addTempCompany-form").submit();
});

var resRow = $('#resRow');
var resList = $('#addressresults');
var manAddRow = $("#manAddRow");
var noMatch = $('#noMatch');

resRow.hide();
manAddRow.hide();
noMatch.hide();

$('#manualAddress').change(function () {
    $('#addressline1').attr('readonly', !this.checked);
    $('#addressline2').attr('readonly', !this.checked);
    $('#town').attr('readonly', !this.checked);
    $('#county').attr('readonly', !this.checked);
    $('#postcode').attr('readonly', !this.checked);
});

resList.change(function () {
    var selOpt = resList.find(":selected");
    $('#companyname').val(selOpt.attr('data-Company')).valid();
    $('#addressline1').val(selOpt.attr('data-Line1')).valid();
    $('#addressline2').val(selOpt.attr('data-Line2')).valid();
    $('#town').val(selOpt.attr('data-PostTown')).valid();
    $('#county').val(selOpt.attr('data-County')).valid();
    $('#postcode').val(selOpt.attr('data-Postcode')).valid();
});

$("#findaddressbutton").click(function () {
    var fa = $("#findaddressbutton");
    var pc = $('#postcodelookup').val().trim();

    if (pc == "") return;

    fa.prop('disabled', true);
    resRow.hide();

    $.ajax({
        url: 'TempCompany/FindAddress',
        data: { postcode: pc }
    }).done(function (result) {

        resList.empty();
        noMatch.hide();

        if (result && result.length > 0) {
            $.each(result, function (i, item) {
                var opt = $("<option>" + item.FullAddress + "</option>");
                opt.attr('data-Company', item.Company);
                opt.attr('data-Line1', item.Line1);
                opt.attr('data-Line2', item.Line2);
                opt.attr('data-PostTown', item.PostTown);
                opt.attr('data-County', item.County);
                opt.attr('data-Postcode', item.Postcode);
                resList.append(opt);
            });
            resRow.show();
        }
        else {
            noMatch.show();
        }
    }).always(function () {
        fa.prop('disabled', false);
        manAddRow.show();
    });
});

// Validation
$("#addTempCompany-form").validate({
    ignore: '.skip',
    // Rules for form validation
    rules: {
        CompanyName: {
            required: true
        },
        CompanyAddress1: {
            required: true
        },
        CompanyTownCity: {
            required: true
        },
        CompanyPostCode: {
            required: true
        },
        CompanyRegulator: {
            required: true
        },
        CompanyOtherRegulator: {
            required: {
                depends: function (element) {
                    return $("#CompanyOtherRegulator").is(":visible")
                }
            }
        },
        SystemAdminTitle: {
            required: true
        },
        SystemAdminFirstName: {
            required: true
        },
        SystemAdminLastName: {
            required: true
        },
        SystemAdminEmail: {
            required: true,
            email: true
        },
        SystemAdminTel: {
            required: true
        }

    },

    // Messages for form validation
    messages: {
        CompanyName: {
            required: 'Please enter a Company Name'
        }
    },

    // Do not change code below
    errorPlacement: function (error, element) {
        error.insertAfter(element.parent());
    },

    submitHandler: function (form) {
        $("#formSubmit").prop('disabled', true);
        form.submit();
    }
});

$("#otherRegulatorLabel").hide();
$("#CompanyRegulator").change(function () {
    var selectedValue = this.value;

    if (selectedValue.toLowerCase() == 'other') {
        $("#otherRegulatorLabel").show();

    } else {
        $("#otherRegulatorLabel").next('em[for="CompanyOtherRegulator"]').remove();
        $("#otherRegulatorLabel").removeClass("state-error");
        $("#otherRegulatorLabel").hide();
        $("#CompanyOtherRegulator").val(null);
    }
});