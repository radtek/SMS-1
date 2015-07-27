var resList = $('#addressresults');
var manAddRow = $("#manAddRow");
var noMatch = $('#noMatch');

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
        $('#CompanyName').val(selOpt.attr('data-Company')).valid();
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
    $('#CompanyName').val('');
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

    ajaxWrapper({
        url: window.location.origin + '/Home/FindAddress',
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