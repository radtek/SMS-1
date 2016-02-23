var registeredTemplatePromise;

$(function () {
    //set up grid options for the three grids. most are passed straight on to kendo grid.
    ajaxWrapper({ url: $('#content').data("groups-url") }).done(function (res) {

        var allGrid = makeOneGrid('all');

        if (res.length === 0) {
            allGrid.grids[0].makeGrid();
        }
        else {
            var tabData = {};
            tabData["tab-all"] = allGrid;

            for (var i = 0; i < res.length; i++) {
                tabData["tab-" + res[i].SafeSendGroupID]= makeOneGrid(res[i].SafeSendGroupID);
            }

            var tabs = new tabItem("myTab1", tabData);
            //set up tabs
            tabs.makeTab();
            tabs.showTab(0);
        }
    });

    registeredTemplatePromise = $.Deferred();
    ajaxWrapper(
        { url: $('#content').data("templateurl") + '?view=' + getRazorViewPath('_RegisteredDetailsTmpl', 'Users', 'ProOrganisation') }
    ).done(function (res) {
        registeredTemplatePromise.resolve(Handlebars.compile(res));
    });


    findModalLinks();
});

function makeOneGrid(suffix) {
    var id = 'regGrid-' + suffix;
    var iGrid = new gridItem(
        {
            gridElementId: id,
            url: $('#' + id).data("url"),
            schema: { data: "Items", total: "Count", model: { id: "UserID" } },
            type: 'odata-v4',
            serverSorting: true,
            serverPaging: true,
            defaultSort: { field: "Contact.LastName", dir: "asc" },
            panels: ['rPanel-' + suffix],
            change: function (dataItem) {
                dataItem.Contact.FullName = dataItem.Contact.Salutation + " " + dataItem.Contact.FirstName + " " + dataItem.Contact.LastName;
                if (!dataItem.UserAccountOrganisationSafeSendGroupsSorted)
                    dataItem.UserAccountOrganisationSafeSendGroupsSorted = _.sortBy(dataItem.UserAccountOrganisationSafeSendGroups, ['SafeSendGroup.Name']);
                registeredTemplatePromise.done(function (template) {
                    var html = template(dataItem);
                    $('#rPanel-' + suffix).html(html);
                });
            },
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
    return { grids: [iGrid] };
}