﻿// submit from when Save button clicked
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
    $('#Line1').attr('readonly', !this.checked);
    $('#Line2').attr('readonly', !this.checked);
    $('#Town').attr('readonly', !this.checked);
    $('#County').attr('readonly', !this.checked);
    $('#PostalCode').attr('readonly', !this.checked);
});

resList.change(function () {
    var selOpt = resList.find(":selected");
    $('#Name').val(selOpt.attr('data-Company')).valid();
    $('#Line1').val(selOpt.attr('data-Line1')).valid();
    $('#Line2').val(selOpt.attr('data-Line2')).valid();
    $('#Town').val(selOpt.attr('data-PostTown')).valid();
    $('#County').val(selOpt.attr('data-County')).valid();
    $('#PostalCode').val(selOpt.attr('data-Postcode')).valid();
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
    }).error(function () {
        noMatch.show();
    })
    .always(function () {
        fa.prop('disabled', false);
        manAddRow.show();
    });
});

// Validation
$("#addTempCompany-form").validate({
    ignore: '.skip',
    // Rules for form validation
    rules: {
        Name: {
            required: true
        },
        Line1: {
            required: true
        },
        Town: {
            required: true
        },
        PostalCode: {
            required: true
        },
        Regulator: {
            required: true
        },
        RegulatorOther: {
            required: {
                depends: function (element) {
                    return $("#RegulatorOther").is(":visible")
                }
            }
        },
        OrganisationAdminSalutation: {
            required: true
        },
        OrganisationAdminFirstName: {
            required: true
        },
        OrganisationAdminLastName: {
            required: true
        },
        OrganisationAdminEmail: {
            required: true,
            email: true
        },
        OrganisationAdminTelephone: {
            required: true
        }

    },

    // Messages for form validation
    messages: {
        Name: {
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
$("#Regulator").change(function () {
    var selectedValue = this.value;

    if (selectedValue.toLowerCase() == 'other') {
        $("#otherRegulatorLabel").show();

    } else {
        $("#otherRegulatorLabel").next('em[for="RegulatorOther"]').remove();
        $("#otherRegulatorLabel").removeClass("state-error");
        $("#otherRegulatorLabel").hide();
        $("#RegulatorOther").val(null);
    }
});