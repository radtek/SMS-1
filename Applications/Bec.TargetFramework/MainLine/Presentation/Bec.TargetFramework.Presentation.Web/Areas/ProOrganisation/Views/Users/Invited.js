﻿var nGrid;
$(function () {

    //set up grid options for the three grids. most are passed straight on to kendo grid.
    nGrid = new gridItem(
        {
            gridElementId: 'nGrid',
            url: $('#nGrid').data("url"),
            schema: { data: "Items", total: "Count", model: { id: "UserID" } },
            type: 'odata-v4',
            serverSorting: true,
            serverPaging: true,
            defaultSort: { field: "Contact.LastName", dir: "asc" },
            panels: ['nPanel'],
            change: nChange,
            jumpToId: $('#nGrid').data("jumpto"),
            columns: [
                    {
                        field: "UserID",
                        hidden: true
                    },
                    {
                        field: "Contact.LastName",
                        title: "Name",
                        template: function (dataItem) { return dataItem.Contact.Salutation + " " + dataItem.Contact.FirstName + " " + dataItem.Contact.LastName; }
                    },
                    {
                        field: "UserAccount.Email",
                        title: "Email"
                    },
                    {
                        field: "UserAccount.Created",
                        title: "Invite Created",
                        template: function (dataItem) { return dateString(dataItem.UserAccount.Created); }
                    },
                    {
                        field: "PinCode",
                        title: "PIN"
                    }
            ]
        });

    var eGrid = new gridItem(
        {
            gridElementId: 'eGrid',
            url: $('#eGrid').data("url"),
            schema: { data: "Items", total: "Count", model: { id: "UserID" } },
            type: 'odata-v4',
            serverSorting: true,
            serverPaging: true,
            defaultSort: { field: "Contact.LastName", dir: "asc" },
            panels: ['ePanel'],
            change: eChange,
            jumpToId: $('#eGrid').data("jumpto"),
            columns: [
                    {
                        field: "UserID",
                        hidden: true
                    },
                    {
                        field: "Contact.LastName",
                        title: "Name",
                        template: function (dataItem) { return dataItem.Contact.Salutation + " " + dataItem.Contact.FirstName + " " + dataItem.Contact.LastName; }
                    },
                    {
                        field: "UserAccount.Email",
                        title: "Email"
                    },
                    {
                        field: "UserAccount.Created",
                        title: "Invite Created",
                        template: function (dataItem) { return dateString(dataItem.UserAccount.Created); }
                    }
            ]
        });

    var tabs = new tabItem("myTab1",
    {
        s1: {
            grids: [nGrid]
        },
        s2: {
            grids: [eGrid]
        }
    });


    tabs.makeTab();
    tabs.showTab($('#myTab1').data("selected"));
    findModalLinks();
});

//data binding for the panes beneath each grid
function nChange(dataItem) {
    $("p#ddnName").text(dataItem.Contact.Salutation + " " + dataItem.Contact.FirstName + " " + dataItem.Contact.LastName);
    $("p#ddnEmail").text(dataItem.UserAccount.Email || "");
    $("p#ddnPIN").text(dataItem.PinCode || "");

    $("#revokeButton1").data('href', $("#revokeButton1").data("url") + "?uaoId=" + dataItem.UserAccountOrganisationID + "&label=" + encodeURIComponent(dataItem.Contact.Salutation + " " + dataItem.Contact.FirstName + " " + dataItem.Contact.LastName));
}
function eChange(dataItem) {
    $("p#ddeName").text(dataItem.Contact.Salutation + " " + dataItem.Contact.FirstName + " " + dataItem.Contact.LastName);
    $("p#ddeEmail").text(dataItem.UserAccount.Email || "");

    $("#reinstateButton").data('href', $("#reinstateButton").data("url") + "?uaoId=" + dataItem.UserAccountOrganisationID + "&userId=" + dataItem.UserAccount.ID + "&label=" + encodeURIComponent(dataItem.Contact.Salutation + " " + dataItem.Contact.FirstName + " " + dataItem.Contact.LastName));
}
