var uGrid;
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
});

//data binding for the panes beneath each grid
function activeChange(dataItem) {
    $("p#ddaCompanyName").text(dataItem.Name || "");
    $("p#ddaCompanyCreatedOn").text(dateString(dataItem.CreatedOn));
    $("p#ddaCompanyCounty").text(dataItem.County || "");
    $("p#ddaCompanyPostCode").text(dataItem.PostalCode || "");
    $("p#ddaCompanyTownCity").text(dataItem.Town || "");
    $("p#ddaCompanyAddress2").text(dataItem.Line2 || "");
    $("p#ddaCompanyAddress1").text(dataItem.Line1 || "");
    $("p#ddaAdditional").text(dataItem.AdditionalAddressInformation || "");
    $("p#ddaSystemAdminEmail").text(dataItem.OrganisationAdminEmail || "");
    $("p#ddaSystemAdminTel").text(dataItem.OrganisationAdminTelephone || "");
    $("p#ddaSystemAdminName").text(dataItem.OrganisationAdminSalutation + " " + dataItem.OrganisationAdminFirstName + " " + dataItem.OrganisationAdminLastName);

    var regulatorName = dataItem.Regulator || "";
    if (regulatorName.toLowerCase() == 'other') regulatorName = dataItem.RegulatorOther;
    $("p#ddaRegulator").text(regulatorName);
    $("p#ddaRegulatorNumber").text(dataItem.RegulatorNumber);

    $("p#ddaCompanyCreatedBy").text(dataItem.CreatedBy || "");
    $("p#ddaCompanyVerifiedOn").text(dateString(dataItem.VerifiedOn));
    $("p#ddaCompanyVerifiedBy").text(dataItem.VerifiedBy || "");
    $("p#ddaCompanyVerifiedTelephone").text(dataItem.VerifiedNotes || "");

    //update reject & generate links
    $("#editButton").data('href', $("#editButton").data("url") + "?orgId=" + dataItem.OrganisationID);

    // toggle fields
    $("p#ddaCompanyCreatedBy").toggle(!!dataItem.CreatedBy);
    $("p#ddaCompanyCreatedBy").parent().prev().toggle(!!dataItem.CreatedBy);
}