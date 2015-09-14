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
                        field: "OrganisationAdminTelephone",
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
                        field: "CreatedBy",
                        title: "Created By"
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
                    field: "OrganisationAdminTelephone",
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
                    field: "CreatedBy",
                    title: "Created By"
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
        });

    //set up tabs
    tabs.makeTab();
    tabs.showTab($('#myTab1').data("selected"));

    findModalLinks();
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
    $("p#dduAdditional").text(dataItem.AdditionalAddressInformation || "");
    $("p#dduSystemAdminEmail").text(dataItem.OrganisationAdminEmail || "");
    $("p#dduSystemAdminTel").text(dataItem.OrganisationAdminTelephone || "");
    $("p#dduSystemAdminName").text(dataItem.OrganisationAdminSalutation + " " + dataItem.OrganisationAdminFirstName + " " + dataItem.OrganisationAdminLastName);

    var regulatorName = dataItem.Regulator || "";
    if (regulatorName.toLowerCase() == 'other') regulatorName = dataItem.RegulatorOther;
    $("p#dduRegulator").text(regulatorName);
    $("p#dduRegulatorNumber").text(dataItem.RegulatorNumber || "");

    //update links
    $("#rejectButton").data('href', $("#rejectButton").data("url") + "?orgId=" + dataItem.OrganisationID);
    $("#pinButton").data('href', $("#pinButton").data("url") + "?orgId=" + dataItem.OrganisationID + "&uaoId=" + dataItem.UserAccountOrganisationID);
    $("#uEmailLogButton").data('href', $("#uEmailLogButton").data("url") + "?orgId=" + dataItem.OrganisationID);
}

function verifiedChange(dataItem) {
    $("p#ddvCompanyName").text(dataItem.Name || "");
    $("p#ddvCompanyCreatedOn").text(dateString(dataItem.CreatedOn));
    $("p#ddvCompanyCounty").text(dataItem.County || "");
    $("p#ddvCompanyPostCode").text(dataItem.PostalCode || "");
    $("p#ddvCompanyTownCity").text(dataItem.Town || "");
    $("p#ddvCompanyAddress2").text(dataItem.Line2 || "");
    $("p#ddvCompanyAddress1").text(dataItem.Line1 || "");
    $("p#ddvAdditional").text(dataItem.AdditionalAddressInformation || "");
    $("p#ddvSystemAdminEmail").text(dataItem.OrganisationAdminEmail || "");
    $("p#ddvSystemAdminTel").text(dataItem.OrganisationAdminTelephone || "");
    $("p#ddvSystemAdminName").text(dataItem.OrganisationAdminSalutation + " " + dataItem.OrganisationAdminFirstName + " " + dataItem.OrganisationAdminLastName);

    var regulatorName = dataItem.Regulator || "";
    if (regulatorName.toLowerCase() == 'other') regulatorName = dataItem.RegulatorOther;
    $("p#ddvRegulator").text(regulatorName);
    $("p#ddvRegulatorNumber").text(dataItem.RegulatorNumber || "");

    $("p#ddvPINNumber").text(dataItem.PinCode);
    $("p#ddvPINCreatedOn").text(dateString(dataItem.PinCreated));
    $("p#ddvLoginsSent").text(dateString(dataItem.OrganisationAdminCreated));

    //update links
    $("#resendButton").data('href', $("#resendButton").data("url") + "?uaoId=" + dataItem.UserAccountOrganisationID + "&label=" + encodeURIComponent(dataItem.Name));
    $("#vEmailLogButton").data('href', $("#vEmailLogButton").data("url") + "?orgId=" + dataItem.OrganisationID);
}

function rejectedChange(dataItem) {
    $("p#ddrCompanyName").text(dataItem.Name || "");
    $("p#ddrCompanyCounty").text(dataItem.County || "");
    $("p#ddrCompanyPostCode").text(dataItem.PostalCode || "");
    $("p#ddrCompanyTownCity").text(dataItem.Town || "");
    $("p#ddrCompanyAddress2").text(dataItem.Line2 || "");
    $("p#ddrCompanyAddress1").text(dataItem.Line1 || "");
    $("p#ddrAdditional").text(dataItem.AdditionalAddressInformation || "");
    $("p#ddrSystemAdminEmail").text(dataItem.OrganisationAdminEmail || "");
    $("p#ddrSystemAdminTel").text(dataItem.OrganisationAdminTelephone || "");
    $("p#ddrSystemAdminName").text(dataItem.OrganisationAdminSalutation + " " + dataItem.OrganisationAdminFirstName + " " + dataItem.OrganisationAdminLastName);

    var regulatorName = dataItem.Regulator || "";
    if (regulatorName.toLowerCase() == 'other') regulatorName = dataItem.RegulatorOther;
    $("p#ddrRegulator").text(regulatorName);
    $("p#ddrRegulatorNumber").text(dataItem.RegulatorNumber || "");

    $("p#ddrRejectedOn").text(dateString(dataItem.StatusChangedOn));
    $("p#ddrRejectedBy").text(dataItem.StatusChangedBy);
    $("p#ddrRejectedReason").text(dataItem.Reason);
    $("p#ddrRejectedNotes").text(dataItem.Notes);
}