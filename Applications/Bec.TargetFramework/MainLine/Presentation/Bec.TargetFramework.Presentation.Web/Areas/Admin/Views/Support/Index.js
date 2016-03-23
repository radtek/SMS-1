var requestGrid;
var areConversationsLoaded;

$(function () {
    'use strict';

    var requestGridContainer = $("#requestGrid");
    var closedGridContainer = $("#closedGrid");

    //set up grid options for the three grids. most are passed straight on to kendo grid.
    requestGrid = new gridItem(
       {
           gridElementId: 'requestGrid',
           url: $('#requestGrid').data("url"),
           schema: { data: "Items", total: "Count", model: { id: "SupportItemID" } },
           type: 'odata-v4',
           serverSorting: true,
           serverPaging: true,
           resetSort: requestGridContainer.data("resetsort"),
           jumpToId: requestGridContainer.data("jumpto"),
           jumpToPage: requestGridContainer.data("jumptopage"),
           jumpToRow: requestGridContainer.data("jumptorow"),
           defaultSort: [{ field: "CreatedOn", dir: "desc" }],
           panels: ['nPanel'],
           change: nChange,
           searchElementId: 'gridSearchInput',
           searchButtonId: 'gridSearchButton',
           columns: [
                   {
                       field: "SupportItemID",
                       hidden: true
                   },
                   {
                       field: "TicketNumber",
                       title: "Ticket Number"
                   },
                   {
                       field: "UserAccountOrganisation.Contact.FirstName",
                       title: "Name",
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
                       title: "Subject"
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
            schema: { data: "Items", total: "Count", model: { id: "SupportItemID" } },
            type: 'odata-v4',
            serverSorting: true,
            serverPaging: true,
            resetSort: closedGridContainer.data("resetsort"),
            jumpToId: closedGridContainer.data("jumpto"),
            jumpToPage: closedGridContainer.data("jumptopage"),
            jumpToRow: closedGridContainer.data("jumptorow"),
            defaultSort: [{ field: "ClosedOn", dir: "desc" }],
            panels: ['ePanel'],
            searchElementId: 'gridSearchInput',
            searchButtonId: 'gridSearchButton',
            change: eChange,
            columns: [
                    {
                        field: "SupportItemID",
                        hidden: true
                    },
                    {
                        field: "TicketNumber",
                        title: "Ticket Number"
                    },
                    {
                        field: "UserAccountOrganisation.Contact.FirstName",
                        title: "Name",
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
                        title: "Subject"
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
    setupTabs();
    switchTabs();
});

function switchTabs() {
    $('#tabList li a').click(function (e) {
        $('#gridSearchInput').val('');
        $('#gridSearchButton').click();
    });
}
function setupTabs() {
    areConversationsLoaded = false;
    $('#nPanel li a').click(function (e) {
        e.stopPropagation();
        if (history.pushState) {
            history.pushState(null, null, $(this).attr('href'));
        }
        $(this).tab('show');

        if ($(this).attr('id') === 'safeSendTab' && !areConversationsLoaded) {
            $('#supportItemConversationContainer').trigger('loadConversations');
            areConversationsLoaded = true;
        }
        return false;
    });
}


//data binding for the panes beneath each grid
function nChange(dataItem) {
    $("p#ddnUserName").text(dataItem.UserAccountOrganisation.Contact.Salutation + ' ' + dataItem.UserAccountOrganisation.Contact.FirstName + ' ' + dataItem.UserAccountOrganisation.Contact.LastName);
    $("p#ddnEmail").text(dataItem.UserAccountOrganisation.UserAccount.Email);
    $("p#ddnTelephone").text(dataItem.Telephone);
    $("p#ddnTicketNumber").text(dataItem.TicketNumber);
    $("p#ddnSubject").text(dataItem.Title || "");
    $("p#ddnType").text(getRequestType(dataItem.RequestTypeID));
    $("p#ddnCreatedOn").text(dateString(dataItem.CreatedOn) || "");
    $("div#ddnDescription").text(dataItem.Description || "");
    $("#closeButtonSupportItem").data('href', $("#closeButtonSupportItem").data("url") + "?SupportItemId=" + dataItem.SupportItemID + "&pageNumber=" + requestGrid.grid.dataSource.page());
    $("#createConversationButton").data('href', $("#createConversationButton").data("url") + "&activityId=" + dataItem.SupportItemID + "&pageNumber=" + requestGrid.grid.dataSource.page());
    $('#supportItemConversationContainer')
        .data('activity-id', dataItem.SupportItemID)
        .trigger('activitychange', [dataItem.SupportItemID,true]);
    areConversationsLoaded = false;
}

function eChange(dataItem) {
    $("p#ddcUserName").text(dataItem.UserAccountOrganisation.Contact.Salutation + ' ' + dataItem.UserAccountOrganisation.Contact.FirstName + ' ' + dataItem.UserAccountOrganisation.Contact.LastName);
    $("p#ddcEmail").text(dataItem.UserAccountOrganisation.UserAccount.Email);
    $("p#ddcTelephone").text(dataItem.Telephone);
    $("p#ddcTicketNumber").text(dataItem.TicketNumber);
    $("p#ddcSubject").text(dataItem.Title || "");
    $("p#ddcType").text(getRequestType(dataItem.RequestTypeID));
    $("p#ddcClosedOn").text(dateString(dataItem.ClosedOn) || "");
    $("div#ddcDescription").text(dataItem.Description || "");
    $("div#ddcReason").text(dataItem.Reason || "");
}
function getRequestType(rType) {
    if (rType === 680) return "Transaction";
    if (rType === 681) return "Product Offering";
    if (rType === 682) return "Safe Buyer Results";
    if (rType === 683) return "Safe Send";
    if (rType === 684) return "Pin Generation";
    if (rType === 685) return "System Management";
    if (rType === 686) return "Bank Account Verification";
    if (rType === 687) return "User Management";
    if (rType === 688) return "Performance Issues";
    if (rType === 689) return "Other";
    return "Other";
}