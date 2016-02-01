var uGrid, vGrid, rGrid;
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
                        hidden: true,
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
                    hidden: true,
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
                    hidden: true,
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
                    hidden: true,
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

    findModalLinks();

    if ($('#content').data("welcome") == "True") {
        runSystemIntro();
    }
});

//data binding for the panes beneath each grid
function unverifiedChange(dataItem) {
    $("p#dduCompanyName").text(dataItem.Name || "");
    $("p#dduCompanyCreatedOn").text(dateString(dataItem.CreatedOn));
    $("p#dduCompanyCounty").text(dataItem.County || "");
    $("p#dduCompanyPostCode").text(dataItem.PostalCode || "");
    $("p#dduCompanyTownCity").text(dataItem.Town || "");
    $("p#dduCompanyAddress2").text(dataItem.Line2 || "");
    $("p#dduCompanyAddress1").text(dataItem.Line1 || "");
    $("p#dduSystemAdminEmail").text(dataItem.OrganisationAdminEmail || "");
    $("p#dduSystemAdminName").text((dataItem.OrganisationAdminSalutation || "") + " " + (dataItem.OrganisationAdminFirstName || "") + " " + (dataItem.OrganisationAdminLastName || ""));
    $("p#dduReferrer").text(dataItem.Referrer || "");
    $("p#dduSchemeID").text(dataItem.SchemeID || "");
    $("p#ddufpm").text(dataItem.FilesPerMonth || "");

    var regulatorName = dataItem.Regulator || "";
    if (regulatorName.toLowerCase() == 'other') regulatorName = dataItem.RegulatorOther;
    $("p#dduRegulator").text(regulatorName);
    $("p#dduRegulatorNumber").text(dataItem.RegulatorNumber || "");

    //update links
    $("#rejectButton").data('href', $("#rejectButton").data("url") + "?orgId=" + dataItem.OrganisationID);
    $("#verifyButton").data('href', $("#verifyButton").data("url") + "?orgId=" + dataItem.OrganisationID + "&uaoId=" + dataItem.UserAccountOrganisationID);
}

function verifiedChange(dataItem) {
    $("p#ddvCompanyName").text(dataItem.Name || "");
    $("p#ddvCompanyCreatedOn").text(dateString(dataItem.CreatedOn));
    $("p#ddvCompanyCounty").text(dataItem.County || "");
    $("p#ddvCompanyPostCode").text(dataItem.PostalCode || "");
    $("p#ddvCompanyTownCity").text(dataItem.Town || "");
    $("p#ddvCompanyAddress2").text(dataItem.Line2 || "");
    $("p#ddvCompanyAddress1").text(dataItem.Line1 || "");
    $("p#ddvSystemAdminEmail").text(dataItem.OrganisationAdminEmail || "");
    $("p#ddvVerifiedPhoneNumber").text(dataItem.Notes || "");
    $("p#ddvReferrer").text(dataItem.Referrer || "");
    $("p#ddvSchemeID").text(dataItem.SchemeID || "");
    $("p#ddvfpm").text(dataItem.FilesPerMonth || "");
    
    $("p#ddvSystemAdminName").text((dataItem.OrganisationAdminSalutation || "") + " " + (dataItem.OrganisationAdminFirstName || "") + " " + (dataItem.OrganisationAdminLastName || ""));

    var regulatorName = dataItem.Regulator || "";
    if (regulatorName.toLowerCase() == 'other') regulatorName = dataItem.RegulatorOther;
    $("p#ddvRegulator").text(regulatorName);
    $("p#ddvRegulatorNumber").text(dataItem.RegulatorNumber || "");
    $("p#ddvRegisteredAsName").text(dataItem.RegisteredAsName);

    $("p#ddvPINNumber").text(dataItem.PinCode);
    $("p#ddvPINCreatedOn").text(dateString(dataItem.PinCreated));
    
    //update links
    $("#pinButton").data('href', $("#pinButton").data("url") + "&orgId=" + dataItem.OrganisationID + "&uaoId=" + dataItem.UserAccountOrganisationID);

    // toggle visibility
    $("p#ddvPINNumber").toggle(!!dataItem.PinCode);
    $("p#ddvPINNumber").parent().prev().toggle(!!dataItem.PinCode);
    $("p#ddvPINCreatedOn").toggle(!!dataItem.PinCreated);
    $("p#ddvPINCreatedOn").parent().prev().toggle(!!dataItem.PinCreated);
}

function rejectedChange(dataItem) {
    $("p#ddrCompanyName").text(dataItem.Name || "");
    $("p#ddrCompanyCounty").text(dataItem.County || "");
    $("p#ddrCompanyPostCode").text(dataItem.PostalCode || "");
    $("p#ddrCompanyTownCity").text(dataItem.Town || "");
    $("p#ddrCompanyAddress2").text(dataItem.Line2 || "");
    $("p#ddrCompanyAddress1").text(dataItem.Line1 || "");
    $("p#ddrSystemAdminEmail").text(dataItem.OrganisationAdminEmail || "");
    $("p#ddrSystemAdminName").text(dataItem.OrganisationAdminSalutation + " " + dataItem.OrganisationAdminFirstName + " " + dataItem.OrganisationAdminLastName);
    $("p#ddrReferrer").text(dataItem.Referrer || "");
    $("p#ddrSchemeID").text(dataItem.SchemeID || "");
    $("p#ddrfpm").text(dataItem.FilesPerMonth || "");

    var regulatorName = dataItem.Regulator || "";
    if (regulatorName.toLowerCase() == 'other') regulatorName = dataItem.RegulatorOther;
    $("p#ddrRegulator").text(regulatorName);
    $("p#ddrRegulatorNumber").text(dataItem.RegulatorNumber || "");

    $("p#ddrRejectedOn").text(dateString(dataItem.StatusChangedOn));
    $("p#ddrRejectedBy").text(dataItem.StatusChangedBy);
    $("p#ddrRejectedReason").text(dataItem.Reason);
    $("p#ddrRejectedNotes").text(dataItem.Notes);
}

function expiredChange(dataItem) {
    $("p#ddeCompanyName").text(dataItem.Name || "");
    $("p#ddeCompanyCreatedOn").text(dateString(dataItem.CreatedOn));
    $("p#ddeCompanyCounty").text(dataItem.County || "");
    $("p#ddeCompanyPostCode").text(dataItem.PostalCode || "");
    $("p#ddeCompanyTownCity").text(dataItem.Town || "");
    $("p#ddeCompanyAddress2").text(dataItem.Line2 || "");
    $("p#ddeCompanyAddress1").text(dataItem.Line1 || "");
    $("p#ddeSystemAdminEmail").text(dataItem.OrganisationAdminEmail || "");
    $("p#ddeVerifiedPhoneNumber").text(dataItem.Notes || "");
    $("p#ddeReferrer").text(dataItem.Referrer || "");
    $("p#ddeSchemeID").text(dataItem.SchemeID || "");
    $("p#ddefpm").text(dataItem.FilesPerMonth || "");

    $("p#ddeSystemAdminName").text((dataItem.OrganisationAdminSalutation || "") + " " + (dataItem.OrganisationAdminFirstName || "") + " " + (dataItem.OrganisationAdminLastName || ""));

    var regulatorName = dataItem.Regulator || "";
    if (regulatorName.toLowerCase() == 'other') regulatorName = dataItem.RegulatorOther;
    $("p#ddeRegulator").text(regulatorName);
    $("p#ddeRegulatorNumber").text(dataItem.RegulatorNumber || "");
    $("p#ddeRegisteredAsName").text(dataItem.RegisteredAsName);

    //update links
    $("#expiredPinButton").data('href', $("#expiredPinButton").data("url") + "&orgId=" + dataItem.OrganisationID + "&uaoId=" + dataItem.UserAccountOrganisationID);
}