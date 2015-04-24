// submit from when Save button clicked
$("#formSubmit").click(function () {
    $("#addTempCompany-form").submit();
});

$('#cancelAdd').click(function () {
    handleModal({ url: $(this).data('href') }, {
        cancelYes: function () {
            hideParentModal();
        }
    }, true);
});

var resRow = $('#resRow');
var resList = $('#addressresults');
var manAddRow = $("#manAddRow");
var noMatch = $('#noMatch');

resRow.hide();
manAddRow.hide();
noMatch.hide();
resList.prop('disabled', true);

$('#manualAddress').change(function () {
    lockFields(!this.checked);
});

resList.change(function () {
    var selOpt = resList.find(":selected");
    var x = selOpt.attr('data-Opt');
    if (x) {
        if (x == "manual") {
            clearForm();
        }
    }
    else {
        manAddRow.show();
        checkMan(false);
        $('#Name').val(selOpt.attr('data-Company')).valid();
        $('#Line1').val(selOpt.attr('data-Line1')).valid();
        $('#Line2').val(selOpt.attr('data-Line2')).valid();
        $('#Town').val(selOpt.attr('data-PostTown')).valid();
        $('#County').val(selOpt.attr('data-County')).valid();
        $('#PostalCode').val(selOpt.attr('data-Postcode')).valid();
    }
});

function clearForm() {
    manAddRow.hide();
    checkMan(true);
    $('#Name').val('');
    $('#Line1').val('');
    $('#Line2').val('');
    $('#Town').val('');
    $('#County').val('');
    $('#PostalCode').val('');
}

function checkMan(check) {
    $('#manualAddress').prop('checked', check);
    lockFields(!check);
}

function lockFields(lock) {
    $('#Line1').attr('readonly', lock);
    $('#Line2').attr('readonly', lock);
    $('#Town').attr('readonly', lock);
    $('#County').attr('readonly', lock);
    $('#PostalCode').attr('readonly', lock);
    $('#AdditionalAddressInformation').attr('readonly', lock);
}

$("#findaddressbutton").click(function () {
    var fa = $("#findaddressbutton");
    var pc = $('#postcodelookup').val().trim();

    if (pc == "") return;

    fa.prop('disabled', true);
    resRow.hide();

    ajaxWrapper({
        url: 'TempCompany/FindAddress',
        data: { postcode: pc }
    })
    .always(function () {
        resList.empty();
        fa.prop('disabled', false);
        checkMan(false);
    })
    .done(function (result) {
        noMatch.hide();
        resList.prop('disabled', false);
        if (result && result.length > 0) {
            resList.append($("<option data-Opt='none'>Please select an address:</option>"));
            resList.append($("<option data-Opt='manual'>Address not listed, please enter manually</option>"));
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
            lookupFailed();
        }
    })
    .fail(function () {
        lookupFailed();
    });
});

function lookupFailed() {
    noMatch.show();
    resList.prop('disabled', true);
    clearForm();
}

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
            required: true,
            minlength: 5
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

    // Do not change code below
    errorPlacement: function (error, element) {
        error.insertAfter(element.parent());
    },

    submitHandler: validateSubmit
});

function validateSubmit(form) {
    $("#formSubmit").prop('disabled', true);

    //handlemodal won't show the modal if there are no results, i.e. it receives a json result {"result" : "ok"}
    handleModal(
    {
        url: 'TempCompany/ViewDuplicates',
        data: {
            Manual: $('#manualAddress').prop('checked'),
            Line1: $('#Line1').val(),
            Line2: $('#Line2').val(),
            Town: $('#Town').val(),
            County: $('#County').val(),
            Postalcode: $('#PostalCode').val()
        }
    },
    {
        abortSave: function () {
            $("#formSubmit").prop('disabled', false);
        },
        saveWithDuplicates: function () {
            form.submit();
        }
    },
    true,
    "saveWithDuplicates"); //default action if no duplicate results
}

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