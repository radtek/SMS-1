$('#emailcontainer').hide();
$('#emailback').hide();

function showBody(uid) {
    var grid = $('#grid').data('kendoGrid');
    var row = grid.tbody.find("tr[data-uid='" + uid + "']");
    var dataItem = grid.dataItem(row);
    $('#emailcontainer').html(dataItem.Body);

    $('#emailcontainer').show();
    $('#emailback').show();
    $('#grid').hide();
}

function emailBack() {
    $('#emailcontainer').hide();
    $('#emailback').hide();
    $('#grid').show();
}