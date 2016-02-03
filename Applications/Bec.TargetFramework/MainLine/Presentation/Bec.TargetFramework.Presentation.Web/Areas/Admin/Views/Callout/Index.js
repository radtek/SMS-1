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
                        template: function (dataItem) { return dateString(dataItem.EffectiveOn); }
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

    var hisGrid = new gridItem(
        {
            gridElementId: 'hisGrid',
            url: $('#hisGrid').data("url"),
            schema: { data: "Items", total: "Count", model: { id: "CalloutUserAccountID" } },
            type: 'odata-v4',
            serverSorting: true,
            serverPaging: true,
            defaultSort: { field: "Callout.Title", dir: "des" },
            panels: ['ePanel'],
            change: eChange,
            jumpToId: $('#hisGrid').data("jumpto"),
            columns: [
                    {
                        field: "CalloutUserAccountID",
                        hidden: true,
                    },
                    {
                        field: "Callout.Title",
                        title: "Callout"
                    },
                    {
                        field: "Role.RoleName",
                        title: "Role"
                    },
                    {
                        field: "UserAccount.Email",
                        title: "User"
                    },
                    {
                        field: "CreatedOn",
                        title: "Viewed Date",
                        template: function (dataItem) { if (dataItem.CreatedOn != null) return dateString(dataItem.CreatedOn); else return ""; }
                    }
            ]
        });

    var tabs = new tabItem("tabList",
    {
        s1: {
            grids: [callGrid]
        },
        s2: {
            grids: [hisGrid]
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
    $("p#ddnPosition").text(getPosition(dataItem.Position));
    $("p#ddnCreatedOn").text(dateString(dataItem.CreatedOn) || "");
    $("p#ddnEffectiveOn").text(dateString(dataItem.EffectiveOn) || "");
    $("p#ddnCreatedBy").text(dataItem.CreatedBy || "");
    $("p#ddnModifiedOn").text(dateString(dataItem.ModifiedOn) || "");
    $("p#ddnModifiedBy").text(dataItem.ModifiedBy || "");
    $("div#ddnDescription").text(dataItem.Description || "");
    $("#editButtonCallout").data('href', $("#editButtonCallout").data("url") + "?CalloutId=" + dataItem.CalloutID + "&pageNumber=" + callGrid.grid.dataSource.page());
    $("#deleteButtonCallout").data('href', $("#deleteButtonCallout").data("url") + "?CalloutId=" + dataItem.CalloutID + "&pageNumber=" + callGrid.grid.dataSource.page());
}
function eChange(dataItem) {
    $("p#ddeTitle").text(dataItem.Callout.Title || "");
    $("p#ddeRole").text(dataItem.Role.RoleName);
    $("p#ddeUser").text(dataItem.UserAccount.Email);
    $("p#ddeViewedDate").text(dateString(dataItem.CreatedOn) || "");
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
    callGrid.refreshGrid();
})


