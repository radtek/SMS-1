var notesTemplatePromise;
var uGrid, vGrid, rGrid;
var promises;
$(function () {
    //set up grid options for the three grids. most are passed straight on to kendo grid.
    uGrid = new gridItem(
        {
            gridElementId: 'unverifiedGrid',
            url: $('#unverifiedGrid').data("url"),
            schema: { data: "list", total: "total", model: { id: "OrganisationID" } },
            defaultSort: { field: "CreatedOn", dir: "asc" },
            change: unverifiedChange,
            jumpToId: $('#unverifiedGrid').data("jumpto"),
            panels: ['unverifiedPanel'],
            columns: [
                    {
                        field: "OrganisationID",
                        hidden: true
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
                        field: "OrganisationAdminEmail",
                        title: "Email"
                    },
                    {
                        field: "CreatedOn",
                        title: "Created On",
                        template: function (dataItem) {
                            return dateString(dataItem.CreatedOn);
                        }
                    }
            ]
        });

    vGrid = new gridItem(
        {
            gridElementId: 'verifiedGrid',
            url: $('#verifiedGrid').data("url"),
            schema: { data: "list", total: "total", model: { id: "OrganisationID" } },
            defaultSort: { field: "PinCreated", dir: "desc" },
            change: verifiedChange,
            jumpToId: $('#verifiedGrid').data("jumpto"),
            panels: ['verifiedPanel'],
            columns: [
                {
                    field: "OrganisationID",
                    hidden: true
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
                    field: "PinCode",
                    title: "PIN Number"
                },
                {
                    field: "PinCreated",
                    title: "PIN Created",
                    template: function (dataItem) {
                        return dateString(dataItem.PinCreated);
                    }
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
                    field: "Notes",
                    title: "Verified Phone Number"
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
                    field: "VerifiedOn",
                    title: "Verified On",
                    template: function (dataItem) {
                        return dateString(dataItem.VerifiedOn);
                    }
                }
            ]
        });

    rGrid = new gridItem(
        {
            gridElementId: 'rejectedGrid',
            url: $('#rejectedGrid').data("url"),
            schema: { data: "list", total: "total", model: { id: "OrganisationID" } },
            defaultSort: { field: "StatusChangedOn", dir: "desc" },
            change: rejectedChange,
            panels: ['rejectedPanel'],
            columns: [
                {
                    field: "OrganisationID",
                    hidden: true
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
                    field: "StatusChangedOn",
                    title: "Rejected On",
                    template: function (dataItem) {
                        return dateString(dataItem.StatusChangedOn);
                    }
                },
                {
                    field: "StatusChangedBy",
                    title: "Rejected By"
                },
                {
                    field: "Reason",
                    title: "Rejected Reason"
                }
            ]
        });

    eGrid = new gridItem(
        {
            gridElementId: 'expiredGrid',
            url: $('#expiredGrid').data("url"),
            schema: { data: "list", total: "total", model: { id: "OrganisationID" } },
            defaultSort: { field: "StatusChangedOn", dir: "desc" },
            change: expiredChange,
            panels: ['expiredPanel'],
            columns: [
                {
                    field: "OrganisationID",
                    hidden: true
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
                    field: "StatusChangedOn",
                    title: "Rejected On",
                    template: function (dataItem) {
                        return dateString(dataItem.StatusChangedOn);
                    }
                },
                {
                    field: "StatusChangedBy",
                    title: "Rejected By"
                },
                {
                    field: "Reason",
                    title: "Rejected Reason"
                }
            ]
        });

    //declare which grids are on which tabs, as the kendo grid can only be created once its container is shown.
    var tabs = new tabItem("myTab1",
        {
            s1: {
                grids: [uGrid]
            },
            s2: {
                grids: [vGrid]
            },
            s3: {
                grids: [rGrid]
            },
            s4: {
                grids: [eGrid]
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

    promises = new defTmpl('Company/DetailTemplates/Provisional/',
        ['unverified', 'verified', 'rejected', 'expired'],
        [
            { name: 'Conveyancer', description: 'Professional Organisation' },
            { name: 'Broker', description: 'Mortgage Broker' },
            { name: 'Lender', description: 'Lender' }
        ]);
});

//data binding for the panes beneath each grid
function unverifiedChange(dataItem) {
    populateCompany(dataItem);
    promises.unverified[dataItem.OrganisationTypeDescription].done(function (template) {
        var html = template(dataItem);
        $('#unverifiedPanel').html(html);
        $("#rejectButton").data('href', $("#rejectButton").data("url") + "?orgId=" + dataItem.OrganisationID);
        $("#verifyButton").data('href', $("#verifyButton").data("url") + "?orgId=" + dataItem.OrganisationID + "&uaoId=" + dataItem.UserAccountOrganisationID);
    });
}

function verifiedChange(dataItem) {
    populateCompany(dataItem);
    promises.verified[dataItem.OrganisationTypeDescription].done(function (template) {
        var data = _.extend({}, dataItem, {
            authorityDelegatedBy: dataItem.AuthorityDelegatedBySalutation
                ? '{0} {1} {2} ({3})'.format(dataItem.AuthorityDelegatedBySalutation, dataItem.AuthorityDelegatedByFirstName, dataItem.AuthorityDelegatedByLastName,
                    dataItem.AuthorityDelegatedByEmail)
                : ''
        });
        var html = template(data);
        $('#verifiedPanel').html(html);
        $("#pinButton").data('href', $("#pinButton").data("url") + "&orgId=" + dataItem.OrganisationID + "&uaoId=" + dataItem.UserAccountOrganisationID);

        $("#unverifyButton").data('href', $("#unverifyButton").data("url") + "?orgId=" + dataItem.OrganisationID);
        $("#rejectVerifiedButton").data('href', $("#rejectVerifiedButton").data("url") + "?orgId=" + dataItem.OrganisationID + "&returnTab=1");
        $('#addNotesButton').data('href', $('#addNotesButton').data('url') + "?orgID=" + dataItem.OrganisationID + "&qualified=false");

        ajaxWrapper({ url: $('#verifiedPanel').data('url') + "?orgID=" + dataItem.OrganisationID }).done(function (notes) {
            notesTemplatePromise.done(function (template) {

                $.each(notes, function (i, item) {
                    item.DateTime = dateString(item.DateTime);
                });
                var html = template(notes);
                $('#verifiedNotes').html(html);
            });
        });
    });
}

function rejectedChange(dataItem) {
    populateCompany(dataItem);
    promises.rejected[dataItem.OrganisationTypeDescription].done(function (template) {
        var html = template(dataItem);
        $('#rejectedPanel').html(html);
    });
}

function expiredChange(dataItem) {
    populateCompany(dataItem);
    promises.expired[dataItem.OrganisationTypeDescription].done(function (template) {
        var html = template(dataItem);
        $('#expiredPanel').html(html);
        $("#expiredPinButton").data('href', $("#expiredPinButton").data("url") + "&orgId=" + dataItem.OrganisationID + "&uaoId=" + dataItem.UserAccountOrganisationID);
    });
}