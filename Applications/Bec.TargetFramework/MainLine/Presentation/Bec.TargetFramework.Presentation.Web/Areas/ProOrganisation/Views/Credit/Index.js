var statementGrid;
$(function () {
    var shownMessage = false;
    //set up grid options for the three grids. most are passed straight on to kendo grid.
    statementGrid = new gridItem(
        {
            gridElementId: 'statementGrid',
            url: $('#statementGrid').data("url"),
            schema: { data: "Items", total: "Count", model: { id: "TransactionOrderID" } },
            type: 'odata-v4',
            serverSorting: true,
            serverPaging: true,
            defaultSort: { field: "BalanceOn", dir: "desc" },
            panels: ['rPanel'],
            change: txChange,
            jumpToId: $('#statementGrid').data("jumpto"),
            onLoadFailed: function (data) {
                console.log(data);
            },
            extraParameters: function () {
                var selectedDateRange = getSelectedDateRange();
                return "&from=" + selectedDateRange.from + "&to=" + selectedDateRange.to;
            },
            columns: [
                    {
                        field: "InvoiceReference",
                        title: "Reference",
                        sortable: false
                    },
                    {
                        field: "Amount",
                        title: "Amount",
                        sortable: false,
                        template: function (dataItem) { return formatCurrency(dataItem.Amount); }
                    },
                    {
                        field: "Balance",
                        title: "Balance",
                        sortable: false,
                        template: function (dataItem) { return formatCurrency(dataItem.Balance); }
                    },
                    {
                        field: "BalanceOn",
                        title: "Date",
                        template: function (dataItem) { return dateString(dataItem.BalanceOn); }
                    },
                    {
                        field: "CreatedByName",
                        title: "Created By",
                        sortable: false
                    }
            ]
        });

    findModalLinks();
    setupDateRangeInputs();
    statementGrid.makeGrid();
    updateBalances();
    setupForm();
});

function applyFilter() {
    statementGrid.refreshGrid();
    updateBalances();
}

function updateBalances() {
    var selectedDateRange = getSelectedDateRange();

    ajaxWrapper({ url: $('#content').data("url") + '?startOfDay=true&date=' + selectedDateRange.from })
        .done(function (res) {
            $('#openingBal').text(formatCurrency(parseFloat(res)));
        });
    ajaxWrapper({ url: $('#content').data("url") + '?startOfDay=false&date=' + selectedDateRange.to })
        .done(function (res) {
            $('#closingBal').text(formatCurrency(parseFloat(res)));
        });
}

//data binding for the panes beneath each grid
function txChange(dataItem) {
    $("p#ddReference").text(dataItem.InvoiceReference || "");
    $("p#ddAmount").text(formatCurrency(dataItem.Amount));
    $("p#ddDate").text(dateString(dataItem.BalanceOn) || "");
    $("p#ddCreatedBy").text(dataItem.CreatedByName || "");
}

function getSelectedDateRange() {
    var dateFrom = moment($('#from').val(), 'DD/MM/YYYY').format('YYYY-MM-DD');
    var dateTo = moment($('#to').val(), 'DD/MM/YYYY').format('YYYY-MM-DD');
    return {
        from: dateFrom,
        to: dateTo
    };
}

function setupDateRangeInputs() {
    $.becDateRange({
        dateFromInputSelector: "#from",
        dateToInputSelector: "#to",
        dateFromShowButtonSelector: "#from ~ .input-group-addon",
        dateToShowButtonSelector: "#to ~ .input-group-addon"
    });
}

function setupForm() {
    var creditSearchForm = $("#creditSearchForm");
    $("#submitCreditSearch").click(function (e) {
        creditSearchForm.submit();
    });
    creditSearchForm.validate({
        ignore: '.skip',
        rules: {
            from: {
                required: true,
                dateGB: true
            },
            to: {
                required: true,
                dateGB: true
            },
        },

        // Do not change code below
        errorPlacement: function (error, element) {
            error.insertAfter(element.parent());
        },

        submitHandler: applyFilter
    });
}
