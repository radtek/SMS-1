var baGrid;
var shownMessage = false;
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
                        field: "BankAccountNumber",
                        title: "Account Number"
                    },
                    {
                        field: "SortCode",
                        title: "Sort Code"
                    },
                    {
                        field: "IsActive",
                        title: "Active",
                        template: function (dataItem) { return dataItem.IsActive ? "Active" : "Inactive"; }
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

    $("#markFraudSuspiciousButton").data('href', $("#markFraudSuspiciousButton").data("url") + "&baId=" + dataItem.OrganisationBankAccountID + "&title=" + encodeURIComponent("Mark as Fraud Suspicious") + "&message=" + encodeURIComponent("Are you sure that you wish to mark this account as Fraud Suspicious?"));
    $("#confirmPotentialButton").data('href', $("#confirmPotentialButton").data("url") + "&baId=" + dataItem.OrganisationBankAccountID + "&title=" + encodeURIComponent("Confirm Potential Fraud") + "&message=" + encodeURIComponent("Are you sure that you wish to confirm this account as Potential Fraud?"));
    $("#markSafeButton").data('href', $("#markSafeButton").data("url") + "&baId=" + dataItem.OrganisationBankAccountID + "&title=" + encodeURIComponent("Mark Safe") + "&message=" + encodeURIComponent("Are you sure that you wish to mark this account Safe?"));
    $("#activateButton").data('href', $("#activateButton").data("url") + "?baId=" + dataItem.OrganisationBankAccountID + "&title=" + encodeURIComponent("Activate Account") + "&message=" + encodeURIComponent("Are you sure that you wish to activate this account?") + "&isactive=true");
    $("#deactivateButton").data('href', $("#deactivateButton").data("url") + "?baId=" + dataItem.OrganisationBankAccountID + "&title=" + encodeURIComponent("Deactivate Account") + "&message=" + encodeURIComponent("Are you sure that you wish to deactivate this account?") + "&isactive=false");
    $("#certButton").attr('href', $("#certButton").data("url") + "?baId=" + dataItem.OrganisationBankAccountID);

    $("#markFraudButton").attr("disabled", !dataItem.IsActive || dataItem.Status != "Safe");
    $("#markFraudSuspiciousButton").attr("disabled", dataItem.Status != "Safe");
    $("#confirmPotentialButton").attr("disabled", !dataItem.IsActive || dataItem.Status != "Fraud Suspicion");
    $("#markSafeButton").attr("disabled", !dataItem.IsActive || dataItem.Status != "Fraud Suspicion");
    $("#activateButton").attr("disabled", dataItem.IsActive || dataItem.Status != "Safe");
    $("#deactivateButton").attr("disabled", !dataItem.IsActive || dataItem.Status != "Safe");
    $("#certButton").attr("disabled", !dataItem.IsActive || dataItem.Status != "Safe");

    showHistory('#history', dataItem);

    //show a message on adding an account
    if ($('#content').data("showmessage") == 'True' && !shownMessage) {
        shownMessage = true;
        handleModal({ url: $('#content').data("url") + "?title=" + encodeURIComponent("Validation Pending") + "&message=" + encodeURIComponent(dataItem.Description) + "&button=OK" }, null, true);
    }
}
