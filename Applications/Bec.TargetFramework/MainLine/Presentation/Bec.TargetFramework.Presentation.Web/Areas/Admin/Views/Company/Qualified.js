﻿var uGrid;
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
                        title: "Bank Account Status",
                        template: function (dataItem) {

                            console.log(dataItem.OrganisationAdminEmail);
                            console.log(dataItem);
                            if (dataItem.ActiveSafeAccounts > 0) {
                                return 'Approved';
                            } else if (dataItem.PendingValidationAccounts > 0) {
                                return 'Submitted';
                            } else {
                                return 'None';
                            }
                        }
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
    });
}