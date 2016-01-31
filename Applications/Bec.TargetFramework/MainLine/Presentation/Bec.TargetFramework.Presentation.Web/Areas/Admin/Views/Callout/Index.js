var cGrid
$(function () {

    //set up grid options for the three grids. most are passed straight on to kendo grid.
     cGrid = new gridItem(
        {
            gridElementId: 'cGrid',
            url: $('#cGrid').data("url"),
            schema: { data: "Items", total: "Count", model: { id: "CalloutID" } },
            type: 'odata-v4',
            serverSorting: true,
            serverPaging: true,
            defaultSort: { field: "Role.RoleName", dir: "asc" },
            panels: ['nPanel'],
            change: nChange,
            jumpToId: $('#cGrid').data("jumpto"),
            jumpToPage: $('#cGrid').data("jumptopage"),
            searchElementId: 'gridSearchInput',
            searchButtonId: 'gridSearchButton',
            columns: [
                    {
                        field: "CalloutID",
                        hidden: true,
                    },
                    {
                        field: "Role.RoleName",
                        title: "Role"
                    },
                    {
                        field: "Title",
                        title: "Title"
                    },
                    {
                        field: "EffectiveOn",
                        title: "Effective Date",
                        template: function (dataItem) { return dateString(dataItem.EffectiveOn); }
                    },
                    {
                        field: "CreatedOn",
                        title: "Created",
                        template: function (dataItem) { return dateString(dataItem.CreatedOn); }
                    },
                    {
                        field: "ModifiedOn",
                        title: "Modified",
                        template: function (dataItem) { if (dataItem.ModifiedOn != null) return dateString(dataItem.ModifiedOn); else return ""; }
                    }

            ]
        });

    var uGrid = new gridItem(
        {
            gridElementId: 'uGrid',
            url: $('#uGrid').data("url"),
            schema: { data: "Items", total: "Count", model: { id: "CalloutSelectorID" } },
            type: 'odata-v4',
            serverSorting: true,
            serverPaging: true,
            defaultSort: { field: "Callout.Name", dir: "des" },
            panels: ['ePanel'],
            change: eChange,
            jumpToId: $('#uGrid').data("jumpto"),
            columns: [
                    {
                        field: "CalloutSelectorID",
                        hidden: true,
                    },
                    {
                        field: "Callout.Name",
                        title: "Callout"
                    },
                    {
                        field: "Role.RoleName",
                        title: "Role"
                    },
                    {
                        field: "Feature.Name",
                        title: "Feature"
                    },
                    {
                        field: "Selector",
                        title: "User"
                    },
                    {
                        field: "Selector",
                        title: "Version"
                    },
                    {
                        field: "Selector",
                        title: "Viewed Date"
                    }
            ]
        });

    var tabs = new tabItem("myTab1",
    {
        s1: {
            grids: [cGrid]
        },
        s2: {
            grids: [uGrid]
        }
    });


    tabs.makeTab();
    tabs.showTab($('#myTab1').data("selected"));
    findModalLinks();
});

//data binding for the panes beneath each grid
function nChange(dataItem) {
    $("p#ddnTitle").text(dataItem.Title || "");
    $("p#ddnRole").text(dataItem.Role.RoleName);
    $("p#ddnPosition").text(displayPosition(dataItem.Position));
    $("p#ddnCreatedOn").text(dateString(dataItem.CreatedOn) || "");
    $("p#ddnEffectiveOn").text(dateString(dataItem.EffectiveOn) || "");
    $("p#ddnCreatedBy").text(dataItem.CreatedBy || "");
    $("p#ddnModifiedOn").text(dateString(dataItem.ModifiedOn) || "");
    $("p#ddnModifiedBy").text(dataItem.ModifiedBy || "");
    $("div#ddnDescription").text(dataItem.Description || "");
    $("#editButtonCallout").data('href', $("#editButtonCallout").data("url") + "?CalloutId=" + dataItem.CalloutID + "&pageNumber=" + cGrid.grid.dataSource.page());
    $("#deleteButtonCallout").data('href', $("#deleteButtonCallout").data("url") + "?CalloutId=" + dataItem.CalloutID + "&pageNumber=" + cGrid.grid.dataSource.page());
}
function eChange(dataItem) {
   
}

function displayPosition(value) {
    if (value == 1) return "Right";
    if (value == 2) return "Left";
    if (value == 3) return "Top";
    if (value == 4) return "Bottom";
    return "";
}

$('#roleDropdown').on('change', function () {
    var valOfThis = $(this).val();
    if (valOfThis.trim().length > 10) {
        $("#viewCalloutOrder").data('href', $("#viewCalloutOrder").data("url") + "?RoleId=" + $(this).val());
        $("#viewCalloutOrder").attr("disabled", false);
    }
    else {
        $("#viewCalloutOrder").data('href', '');
        $("#viewCalloutOrder").attr("disabled", true);
    }

})


