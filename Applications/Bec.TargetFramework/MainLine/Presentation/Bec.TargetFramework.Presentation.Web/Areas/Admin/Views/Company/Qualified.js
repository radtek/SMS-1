var notesTemplatePromise;
var uGrid;
var promises;
$(function () {
    //set up grid options for the three grids. most are passed straight on to kendo grid.
    uGrid = new gridItem(
        {
            gridElementId: 'activeGrid',
            url: $('#activeGrid').data("url"),
            schema: { data: "list", total: "total", model: { id: "OrganisationID" } },
            defaultSort: { field: "Name", dir: "asc" },
            change: activeChange,
            jumpToId: $('#activeGrid').data("jumpto"),
            panels: ['activePanel'],
            columns: [
                    {
                        field: "OrganisationID",
                        hidden: true,
                    },
                    {
                        field: "OrganisationTypeDescription",
                        title: "Type"
                    },
                    {
                        field: "Name",
                        title: "Company Name"
                    },
                    {
                        field: "Line1",
                        title: "Address 1"
                    },
                    {
                        field: "PostalCode",
                        title: "Post Code"
                    },
                    {
                        field: "OrganisationAdminLastName",
                        title: "Organisation Administrator",
                        template: function (dataItem) {
                            return kendo.htmlEncode(dataItem.OrganisationAdminFirstName) + " " + kendo.htmlEncode(dataItem.OrganisationAdminLastName);
                        }
                    },
                    {
                        field: "VerifiedNotes",
                        title: "Telephone Number"
                    },
                    {
                        field: "OrganisationAdminEmail",
                        title: "Email"
                    },
                    {
                        field: "CreatedOn",
                        title: "Created On",
                        template: function (dataItem) {
                            return dateString(dataItem.CreatedOn);
                        }
                    },
                    {
                        field: "BankAccountStatus",
                        title: "Bank Account Status"
                    }
            ]
        });

    //declare which grids are on which tabs, as the kendo grid can only be created once its container is shown.
    var tabs = new tabItem("myTab1",
        {
            s1: {
                grids: [uGrid]
            }
        });


    //set up tabs
    tabs.makeTab();
    tabs.showTab($('#myTab1').data("selected"));

    notesTemplatePromise = $.Deferred();
    ajaxWrapper(
        { url: $('#content').data("templateurl") + '?view=' + getRazorViewPath('_orgNotesTmpl', 'Shared', 'Admin') }
    ).done(function (res) {
        notesTemplatePromise.resolve(Handlebars.compile(res));
    });

    findModalLinks();

    promises = new defTmpl('Company/DetailTemplates/Qualified/',
        ['active'],
        [
            { name: 'Conveyancer', description: 'Professional Organisation' },
            { name: 'Broker', description: 'Mortgage Broker' },
            { name: 'Lender', description: 'Lender' }
        ]);
});

//data binding for the panes beneath each grid
function activeChange(dataItem) {
    populateCompany(dataItem);
    promises.active[dataItem.OrganisationTypeDescription].done(function (template) {
        var html = template(dataItem);
        $('#activePanel').html(html);
        
        $('#addNotesButton').data('href', $('#addNotesButton').data('url') + "?orgID=" + dataItem.OrganisationID + "&qualified=true");

        ajaxWrapper({ url: $('#activePanel').data('url') + "?orgID=" + dataItem.OrganisationID }).done(function (notes) {
            notesTemplatePromise.done(function (template) {

                $.each(notes, function (i, item) {
                    item.DateTime = dateString(item.DateTime);
                });
                var html = template(notes);
                $('#activeNotes').html(html);
            });
        });
    });
}