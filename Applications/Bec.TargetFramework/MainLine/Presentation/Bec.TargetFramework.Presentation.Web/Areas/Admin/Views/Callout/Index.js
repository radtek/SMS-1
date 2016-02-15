var callGrid
$(function () {
    //set up grid options for the three grids. most are passed straight on to kendo grid.
    callGrid = new gridItem(
       {
           gridElementId: 'callGrid',
           url: $('#callGrid').data("url"),
           schema: { data: "Items", total: "Count", model: { id: "CalloutID" } },
           type: 'odata-v4',
           serverSorting: true,
           serverPaging: true,
           defaultSort: [{ field: 'Role.RoleName', dir: 'asc' }, { field: 'DisplayOrder', dir: 'asc' }],
           panels: ['nPanel'],
           change: nChange,
           jumpToId: $('#callGrid').data("jumpto"),
           jumpToPage: $('#callGrid').data("jumptopage"),
           searchElementId: 'gridSearchInput',
           searchButtonId: 'gridSearchButton',
           extraParameters: function () {
               return "&calloutRoleId=" + $('#roleDropdown').val()
           },
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
                       template: function (dataItem) { return dateStringNoTime(dataItem.EffectiveOn); }
                   },
                   {
                       field: "CreatedOn",
                       title: "Created On",
                       template: function (dataItem) { return dateString(dataItem.CreatedOn); }
                   },
                   {
                       field: "ModifiedOn",
                       title: "Modified On",
                       template: function (dataItem) { if (dataItem.ModifiedOn != null) return dateString(dataItem.ModifiedOn); else return ""; }
                   }
           ]
       });

    var tabs = new tabItem("tabList",
    {
        s1: {
            grids: [callGrid]
        }
    });
    tabs.makeTab();
    tabs.showTab($('#tabList').data("selected"));
    findModalLinks();
});

//data binding for the panes beneath each grid
function nChange(dataItem) {
    $("p#ddnTitle").text(dataItem.Title || "");
    $("p#ddnRole").text(dataItem.Role.RoleName);
    $("p#ddnSelector").text(dataItem.Selector);
    $("p#ddnPosition").text(getPosition(dataItem.Position));
    $("p#ddnCreatedOn").text(dateString(dataItem.CreatedOn) || "");
    $("p#ddnEffectiveOn").text(dateStringNoTime(dataItem.EffectiveOn) || "");
    $("p#ddnCreatedBy").text(dataItem.CreatedBy || "");
    $("p#ddnModifiedOn").text(dataItem.ModifiedOn != null ? dateString(dataItem.ModifiedOn) : "");
    $("p#ddnModifiedBy").text(dataItem.ModifiedBy || "");
    $("div#ddnDescription").text(dataItem.Description || "");
     var valOfThis = $('#roleDropdown').val();
     if (valOfThis.trim().length > 10) {
         $("#editButtonCallout").data('href', $("#editButtonCallout").data("url") + "?CalloutId=" + dataItem.CalloutID + "&pageNumber=" + callGrid.grid.dataSource.page() + "&roleId=" + valOfThis);
         $("#deleteButtonCallout").data('href', $("#deleteButtonCallout").data("url") + "?CalloutId=" + dataItem.CalloutID + "&pageNumber=" + callGrid.grid.dataSource.page() + "&roleId=" + valOfThis);
         $("#viewCalloutOrder").data('href', $("#viewCalloutOrder").data("url") + "?RoleId=" + valOfThis);
         $("#viewCalloutOrder").attr("disabled", false);
    }
    else {
        $("#editButtonCallout").data('href', $("#editButtonCallout").data("url") + "?CalloutId=" +dataItem.CalloutID + "&pageNumber=" +callGrid.grid.dataSource.page());
        $("#deleteButtonCallout").data('href', $("#deleteButtonCallout").data("url") + "?CalloutId=" +dataItem.CalloutID + "&pageNumber=" +callGrid.grid.dataSource.page());
        $("#viewCalloutOrder").attr("disabled", true);
        $("#viewCalloutOrder").data('href', '');
    }
    
}

$('#roleDropdown').on('change', function () {
    $("#viewCalloutOrder").attr("disabled", true);
    var valOfThis = $(this).val();
    if (valOfThis.trim().length > 10) {
        $("#addButtonCallout").data('href', $("#addButtonCallout").data("url") + "?RoleId=" + valOfThis);
    }
    else {
        $("#addButtonCallout").data('href', $("#addButtonCallout").data("url"));
    }
    callGrid.refreshGrid();
})


