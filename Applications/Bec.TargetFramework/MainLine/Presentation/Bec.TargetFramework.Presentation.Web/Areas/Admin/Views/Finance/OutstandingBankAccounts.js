var baGrid;
$(function () {
    //set up grid options for the three grids. most are passed straight on to kendo grid.
    baGrid = new gridItem(
    {
        gridElementId: 'baGrid',
        url: $('#baGrid').data("url"),
        schema: { data: "list", total: "total", model: { id: "OrganisationBankAccountID" } },
        defaultSort: { field: "Created", dir: "asc" },
        panels: ['rPanel'],
        jumpToId: $('#baGrid').data("jumpto"),
        change: txChange,
        columns: [
                {
                    field: "Name",
                    title: "Firm Name"
                },
                {
                    field: "BankAccountNumber",
                    title: "Account Number"
                },
                {
                    field: "SortCode",
                    title: "Sort Code"
                },
                {
                    field: "Status",
                    title: "Status"
                },
                {
                    field: "StatusChangedBy",
                    title: "Changed By"
                },
                {
                    field: "StatusChangedOn",
                    title: "Changed On",
                    template: function (dataItem) { return dateString(dataItem.StatusChangedOn); }
                },
                {
                    field: "Created",
                    title: "Created",
                    template: function (dataItem) {
                        return dateString(dataItem.Created);
                    }
                },
                {
                    field: "Duplicates.length",
                    title: "Alert",
                    template: function (dataItem) {
                        return dataItem.Duplicates.length > 0 ? "<i class='fa fa-exclamation-triangle fa-lg' style='color:red;'></i> Duplicate accounts exist" : "";
                    }
                }
        ]
    });

    baGrid.makeGrid();

    findModalLinks();       
});

//data binding for the panes beneath each grid
function txChange(dataItem) {
    $("p#ddAccountNumber").text(dataItem.BankAccountNumber || "");
    $("p#ddSortCode").text(dataItem.SortCode || "");
    $("p#ddCreated").text(dateString(dataItem.Created));
    $("p#ddStatus").text(dataItem.Description || "");

    $("#markPotentialButton").data('href', $("#markPotentialButton").data("url") + "&baId=" + dataItem.OrganisationBankAccountID + "&title=" + encodeURIComponent("Confirm Potential Fraud") + "&message=" + encodeURIComponent("Are you sure that you wish to confirm this account as Potential Fraud?"));
    $("#markSafeButton").data('href', $("#markSafeButton").data("url") + "&baId=" + dataItem.OrganisationBankAccountID + "&title=" + encodeURIComponent("Mark Safe") + "&message=" + encodeURIComponent("Are you sure that you wish to mark this account Safe?"));
    $("#markSafeKillDupesButton").data('href', $("#markSafeKillDupesButton").data("url") + "&baId=" + dataItem.OrganisationBankAccountID + "&title=" + encodeURIComponent("Mark Safe") + "&message=" + encodeURIComponent("Are you sure that you wish to mark this account Safe?"));

    $("#markSafeButton").attr("disabled", dataItem.Duplicates.length > 0);
    $("#markSafeKillDupesButton").attr("disabled", dataItem.Duplicates.length == 0);

    showHistory('#history', dataItem);
    showDuplicates('#duplicates', '#dupeHeading', dataItem);
}