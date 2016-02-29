var requestGrid
$(function () {
    //set up grid options for the three grids. most are passed straight on to kendo grid.
    requestGrid = new gridItem(
       {
           gridElementId: 'requestGrid',
           url: $('#requestGrid').data("url"),
           schema: { data: "Items", total: "Count", model: { id: "RequestSupportID" } },
           type: 'odata-v4',
           serverSorting: true,
           serverPaging: true,
           defaultSort: [{ field: 'CreatedOn', dir: 'asc' }],
           panels: ['nPanel'],
           change: nChange,
           searchElementId: 'gridSearchInput',
           searchButtonId: 'gridSearchButton',
           columns: [
                   {
                       field: "RequestSupportID",
                       hidden: true,
                   },
                   {
                       field: "TicketNumber",
                       title: "Ticket Number"
                   },
                   {
                       field: "UserAccountOrganisation.Contact.FullName",
                       title: "User Name",
                       template: function (dataItem) { return (dataItem.UserAccountOrganisation.Contact.Salutation + ' ' + dataItem.UserAccountOrganisation.Contact.FirstName + ' ' + dataItem.UserAccountOrganisation.Contact.LastName); }

                   },
                   {
                       field: "UserAccountOrganisation.UserAccount.Email",
                       title: "Email"
                   },
                   {
                       field: "Telephone",
                       title: "Telephone"
                   },
                   
                   {
                       field: "Title",
                       title: "Title",
                   },
                   {
                       field: "CreatedOn",
                       title: "Created On",
                       template: function (dataItem) { return dateString(dataItem.CreatedOn); }
                   }
           ]
       });

    var closedGrid = new gridItem(
        {
            gridElementId: 'closedGrid',
            url: $('#closedGrid').data("url"),
            schema: { data: "Items", total: "Count", model: { id: "RequestSupportID" } },
            type: 'odata-v4',
            serverSorting: true,
            serverPaging: true,
            defaultSort: { field: "ClosedOn", dir: "des" },
            panels: ['ePanel'],
            change: eChange,
            columns: [
                    {
                        field: "RequestSupportID",
                        hidden: true,
                    },
                    {
                        field: "TicketNumber",
                        title: "Ticket Number"
                    },
                    {
                        field: "UserAccountOrganisation.Contact.FirstName",
                        title: "User Name",
                        template: function (dataItem) { return (dataItem.UserAccountOrganisation.Contact.Salutation + ' ' + dataItem.UserAccountOrganisation.Contact.FirstName + ' ' + dataItem.UserAccountOrganisation.Contact.LastName); }
},
                    {
                        field: "UserAccountOrganisation.UserAccount.Email",
                        title: "Email"
                    },
                   {
                       field: "Telephone",
                       title: "Telephone"
                   },
                    {
                        field: "Title",
                        title: "Title",
                    },
                    {
                        field: "ClosedOn",
                        title: "Closed On",
                        template: function (dataItem) { return dateString(dataItem.ClosedOn); }
                    }
            ]
        });

    var tabs = new tabItem("tabList",
    {
        s1: {
            grids: [requestGrid]
        },
        s2: {
            grids: [closedGrid]
        }
    });
    tabs.makeTab();
    tabs.showTab($('#tabList').data("selected"));
    findModalLinks();
});

//data binding for the panes beneath each grid
function nChange(dataItem) {
    $("p#ddnUserName").text(dataItem.UserAccountOrganisation.Contact.Salutation + ' ' + dataItem.UserAccountOrganisation.Contact.FirstName + ' ' + dataItem.UserAccountOrganisation.Contact.LastName);
    $("p#ddnEmail").text(dataItem.UserAccountOrganisation.UserAccount.Email);
    $("p#ddnTelephone").text(dataItem.Telephone);
    $("p#ddnTicketNumber").text(dataItem.TicketNumber);
    $("p#ddnTitle").text(dataItem.Title || "");
    $("p#ddnType").text(getRequestType(dataItem.RequestType));
    $("p#ddnCreatedOn").text(dateString(dataItem.CreatedOn) || "");
    $("div#ddnDescription").text(dataItem.Description || "");
    $("#closeButtonRequestSupport").data('href', $("#closeButtonRequestSupport").data("url") + "?RequestSupportId=" + dataItem.RequestSupportID + "&pageNumber=" + requestGrid.grid.dataSource.page());
}
function eChange(dataItem) {
    $("p#ddeUserName").text(dataItem.UserAccountOrganisation.Contact.Salutation + ' ' + dataItem.UserAccountOrganisation.Contact.FirstName + ' ' + dataItem.UserAccountOrganisation.Contact.LastName);
    $("p#ddeEmail").text(dataItem.UserAccountOrganisation.UserAccount.Email);
    $("p#ddeTelephone").text(dataItem.Telephone);
    $("p#ddeTicketNumber").text(dataItem.TicketNumber);
    $("p#ddeTitle").text(dataItem.Title || "");
    $("p#ddeType").text(getRequestType(dataItem.RequestType));
    $("p#ddeClosedOn").text(dateString(dataItem.ClosedOn) || "");
    $("div#ddeDescription").text(dataItem.Description || "");
    $("div#ddeReason").text(dataItem.Reason || "");
}
function getRequestType(rType) {
    if (rType == 1) return "Product Offering";
    if (rType == 2) return "Safe Buyer Results";
    if (rType == 3) return "Safe Send";
    if (rType == 4) return "Pin Generation";
    if (rType == 5) return "Bank Account Verification";
    if (rType == 6) return "User Management";
    if (rType == 7) return "Performance Issues";
    return "Product Offering";
}
