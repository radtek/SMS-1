var iGrid;
$(function () {
    //set up grid options for the three grids. most are passed straight on to kendo grid.
    iGrid = new gridItem(
        {
            gridElementId: 'regGrid',
            url: $('#regGrid').data("url"),
            schema: { data: "Items", total: "Count", model: { id: "UserID" } },
            type: 'odata-v4',
            serverSorting: true,
            serverPaging: true,
            defaultSort: { field: "Contact.LastName", dir: "asc" },
            panels: ['rPanel'],
            change: rChange,
            columns: [
                    {
                        field: "UserID",
                        hidden: true,
                    },
                    {
                        field: "Contact.Salutation",
                        title: "Title"
                    },
                    {
                        field: "Contact.LastName",
                        title: "Name",
                        template: function (dataItem) { return dataItem.Contact.FirstName + " " + dataItem.Contact.LastName; }
                    },
                    {
                        field: "UserAccount.Email",
                        title: "Email"
                    },
                    {
                        field: "UserAccount.Username",
                        title: "Username"
                    },
                    {
                        field: "UserAccount.Created",
                        title: "Invite Created",
                        template: function (dataItem) { return dateString(dataItem.UserAccount.Created); }
                    }
            ]
        });


    iGrid.makeGrid();
    findModalLinks();
});

//data binding for the panes beneath each grid
function rChange(dataItem) {
    $("p#ddName").text(dataItem.Contact.FirstName + " " + dataItem.Contact.LastName);
    $("p#ddEmail").text(dataItem.UserAccount.Email || "");
    $("p#ddUsername").text(dataItem.UserAccount.Username || "");

    $("#editButton").data('href', $("#editButton").data("url") + "?uaoID=" + dataItem.UserAccountOrganisationID);
}
