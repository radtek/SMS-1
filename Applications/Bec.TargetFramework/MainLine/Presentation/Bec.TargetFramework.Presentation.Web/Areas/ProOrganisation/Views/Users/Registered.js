var iGrid;
var registeredTemplatePromise;
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

    registeredTemplatePromise = $.Deferred();
    ajaxWrapper(
        { url: $('#content').data("templateurl") + '?view=' + getRazorViewPath('_RegisteredDetailsTmpl', 'Users', 'ProOrganisation') }
    ).done(function (res) {
        registeredTemplatePromise.resolve(Handlebars.compile(res));
    });

    iGrid.makeGrid();
    findModalLinks();
});

//data binding for the panes beneath each grid
function rChange(dataItem) {
    dataItem.Contact.FullName = dataItem.Contact.Salutation + " " + dataItem.Contact.FirstName + " " + dataItem.Contact.LastName;
    registeredTemplatePromise.done(function (template) {
        var html = template(dataItem);
        $('#rPanel').html(html);
    });
}
