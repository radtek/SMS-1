$(function () {
    //set up grid options for the three grids. most are passed straight on to kendo grid.
    var txGrid = new gridItem(
        {
            gridElementId: 'txGrid',
            url: $('#txGrid').data("url"),
            schema: { data: "Items", total: "Count", model: { id: "SmsTransactionID" } },
            type: 'odata-v4',
            serverSorting: true,
            serverPaging: true,
            defaultSort: { field: "CreatedOn", dir: "desc" },
            panels: ['rPanel'],
            jumpToId: $('#txGrid').data("jumpto"),
            change: txChange,
            searchElementId: 'gridSearchInput',
            searchButtonId: 'gridSearchButton',
            columns: [
                    {
                        field: "SmsTransactionID",
                        hidden: true,
                    },
                    {
                        field: "Reference",
                        title: "Reference"
                    },
                    {
                        field: "Address.Line1",
                        title: "Address Line 1"
                    },
                    {
                        field: "Address.PostalCode",
                        title: "Postcode"
                    },
                    {
                        field: "CreatedOn",
                        title: "Created",
                        template: function (dataItem) { return dateString(dataItem.CreatedOn); }
                    }
            ]
        });

    txGrid.makeGrid();
    findModalLinks();
});

//data binding for the panes beneath each grid
function txChange(dataItem) {
    $("p#ddAddressLine1").text(dataItem.Address.Line1 || "");
    $("p#ddAddressLine2").text(dataItem.Address.Line2 || "");
    $("p#ddTown").text(dataItem.Address.Town || "");
    $("p#ddCounty").text(dataItem.Address.County || "");
    $("p#ddPostCode").text(dataItem.Address.PostalCode || "");
    $("p#ddAdditionalAddressInformation").text(dataItem.Address.AdditionalAddressInformation || "");

    $("p#ddName").text(
        (dataItem.UserAccountOrganisation.Contact.Salutation || "") + " " +
        (dataItem.UserAccountOrganisation.Contact.FirstName || "") + " " +
        (dataItem.UserAccountOrganisation.Contact.LastName || ""));
    $("p#ddEmail").text(dataItem.UserAccountOrganisation.UserAccount.Email || "");

    $("#editButton").data('href', $("#editButton").data("url") + "?txId=" + dataItem.SmsTransactionID);
    $("#resendButton").data('href', $("#resendButton").data("url") + "?txId=" + dataItem.SmsTransactionID + "&label=" +
        encodeURIComponent(
            (dataItem.UserAccountOrganisation.Contact.Salutation || "") + " " +
            (dataItem.UserAccountOrganisation.Contact.FirstName || "") + " " +
            (dataItem.UserAccountOrganisation.Contact.LastName || "")));

    $("#resendButton").attr("disabled", !dataItem.UserAccountOrganisation.UserAccount.IsTemporaryAccount);

    toggleFields(dataItem);
}

function toggleFields(dataItem) {
    $('#dtAddressLine1, p#ddAddressLine1').toggle(!!dataItem.Address.Line1);
    $('#dtAddressLine2, p#ddAddressLine2').toggle(!!dataItem.Address.Line2);
    $("#dtTown, p#ddTown").toggle(!!dataItem.Address.Town);
    $("#dtCounty, p#ddCounty").toggle(!!dataItem.Address.County);
    $("#dtPostCode, p#ddPostCode").toggle(!!dataItem.Address.PostalCode);
    $("#dtAdditionalAddressInformation, p#ddAdditionalAddressInformation").toggle(!!dataItem.Address.AdditionalAddressInformation);
}
