$(function() {
    "use strict";

    // hide by default
    $("#uiPageUrlSection").css("display", "none");
    $("#addHelpItemButton").hide();
    $("#editAddHelpItemButton").hide();

    // submit from when Save button clicked
    $("#submitAddHelp").click(function() {
        $("#addHelp-form").submit();
    });

    $("#cancelAddHelp").click(function() {
        $.ajax({
            url: $("#cancelAddHelp").data("href"),
            type: "GET"
        });
    });

    $("#addHelp-form").validate({
        ignore: ":hidden",
        // Rules for form validation
        rules: {
            HelpTypeID: {
                required: true,
                remote: {
                    cache: false,
                    url: $("#HelpTypeID").data("url"),
                    data: {
                        htn: function() { return $("#HelpTypeID").find(":selected").text(); },

                        __RequestVerificationToken: $("input[name='__RequestVerificationToken']").val()
                    },
                    type: "POST",
                    dataType: "json",
                    error: function(xhr, status, error) { checkRedirect(xhr.responseJSON); }
                }
            },
            Name: {
                required: true
            },
            UiPageUrl: {
                required: true,
                remote: {
                    cache: false,
                    url: $("#UiPageUrl").data("url"),
                    data: {
                        htn: function() { return $("#HelpTypeID").find(":selected").text(); },
                        helpID: function() { return $("#HelpID").val(); },
                        uiPageUrl: function() { return $("#UiPageUrl").val(); },
                        __RequestVerificationToken: $("input[name='__RequestVerificationToken']").val()
                    },
                    type: "POST",
                    dataType: "json",
                    error: function(xhr, status, error) { checkRedirect(xhr.responseJSON); }
                }
            }
        },

        // Do not change code below
        errorPlacement: function(error, element) {
            error.insertAfter(element.parent());
        },

        submitHandler: validateSubmit
    });

    var hiGrid = new gridItem(
    {
        gridElementId: "hiGrid",
        url: $("#hiGrid").data("url"),
        schema: { data: "Items", total: "Count", model: { id: "HelpItemID" } },
        type: "json",
        serverSorting: true,
        serverPaging: true,
        defaultSort: { field: "CreatedOn", dir: "desc" },
        resetSort: $("#hiGrid").data("resetsort"),
        jumpToId: $("#hiGrid").data("jumpto"),
        jumpToPage: $("#hiGrid").data("jumptopage"),
        jumpToRow: $("#hiGrid").data("jumptorow"),
        columns: [
            {
                field: "HelpItemID",
                hidden: true
            },
            {
                field: "Title",
                title: "Title"
            },
            {
                field: "UiSelector",
                title: "UI Selector"
            },
            {
                field: "UiPositionName",
                title: "UI Position"
            },
            {
                field: "SelectedRoles",
                title: "Roles",
                template: function(dataItem) {
                    if (dataItem.SelectedRoleNames != null) {
                        var dataString = "";
                        for (var k = 0; k < dataItem.SelectedRoleNames.length; k++) {
                            dataString += dataItem.SelectedRoleNames[k] + "</br>";
                        }
                        return dataString;
                    } else
                        return "";
                }
            },
            {
                field: "EffectiveFrom",
                title: "Effective From",
                width: 100,
                template: function(dataItem) {
                    if (dataItem.EffectiveFrom == null) {
                        return ""
                    } else return kendo.toString(kendo.parseDate(dataItem.EffectiveFrom), "dd/MM/yyyy");
                }
            },
            {
                command: { name: "Up", text: "", imageClass: "k-icon k-i-arrowhead-n", click: upItem },
                title: " ",
                width: 40
            },
            {
                command: { name: "Down", text: "", imageClass: "k-icon k-i-arrowhead-s ob-icon-only", click: downItem },
                title: " ",
                width: 40
            },
            {
                command: { name: "Edit", text: "", imageClass: "k-icon k-i-pencil ob-icon-only", click: editItem },
                title: " ",
                width: 40
            },
            {
                command: { name: "Delete", text: "", imageClass: "k-icon k-i-close ob-icon-only", click: deleteItem },
                title: " ",
                width: 40
            }
        ]
    });

    hiGrid.makeGrid();

    $("#hiGrid").data("kendoGrid").bind("dataBound", function(e) {
        var helpType = $("#HelpTypeID").find(":selected").text();
        if (helpType === "Callout") {
            hideShowGridColumn("#hiGrid", "UiPositionName", false);
            hideShowGridColumn("#hiGrid", "EffectiveFrom", true);
        } else {
            hideShowGridColumn("#hiGrid", "UiPositionName", true);
            hideShowGridColumn("#hiGrid", "EffectiveFrom", false);
        }
    });
    // hide and show elements based upon the helptypeid being changed
    $("#HelpTypeID").on("change", function(e) {

        var optionSelected = $("option:selected", this);

        if (this.selectedIndex > 0) {
            $("#addHelpItemButton").show();

            $("#addHelpItemButton").data("href", ($("#addHelpItemButton").attr("data-href") + "&htn=" + optionSelected.text()));
        } else
            $("#addHelpItemButton").hide();

        hideShowElementsBasedOnHelpType(optionSelected.text());
    });

    function editItem(e) {
        e.preventDefault();

        var dataItem = this.dataItem($(e.currentTarget).closest("tr"));
        $("#editAddHelpItemButton").data("href", ($("#editAddHelpItemButton").attr("data-href") + "&hiID=" + getGuid(dataItem.HelpItemID)));
        $("#editAddHelpItemButton").click();
    }

    function upItem(e) {
        e.preventDefault();

        var dataItem = this.dataItem($(e.currentTarget).closest("tr"));
        performGridFunctionViaGETAndRefresh(($("#upItemButton").attr("data-href") + "&hiID=" + getGuid(dataItem.HelpItemID)), "#hiGrid");
    }

    function downItem(e) {
        e.preventDefault();

        var dataItem = this.dataItem($(e.currentTarget).closest("tr"));
        performGridFunctionViaGETAndRefresh(($("#downItemButton").attr("data-href") + "&hiID=" + getGuid(dataItem.HelpItemID)), "#hiGrid");
    }

    function deleteItem(e) {
        e.preventDefault();

        var dataItem = this.dataItem($(e.currentTarget).closest("tr"));

        performGridFunctionViaGETAndRefresh(($("#deleteItemButton").data("href") + "&hiID=" + getGuid(dataItem.HelpItemID)), "#hiGrid");
    }

    function hideShowElementsBasedOnHelpType(helpType) {
        if (helpType === "ShowMeHow") {
            showHideAndClearValueElement("#uiPageUrlSection", true);
        } else {
            showHideAndClearValueElement("#uiPageUrlSection", false);
        }
    }

    function validateSubmit(form) {
        $("#submitAddHelp").prop("disabled", true);
        form.submit();
    }


    function showHideAndClearValueElement(sectionName, show) {
        if (show) {
            $(sectionName).css("display", "block");
        } else {
            $(sectionName).css("display", "none");
        }
    }

    function performGridFunctionViaGETAndRefresh(url, grid) {
        $.ajax({
            url: url,
            type: "GET",
            complete: function (data) {
                $(grid).data("kendoGrid").dataSource.read();
            }
        });
    }

    function hideShowGridColumn(grid, column, show) {
        var kendoGrid = $(grid).data("kendoGrid");
        var columnPosition = 0;

        for (var i = 0; i < kendoGrid.columns.length; i++) {
            if (kendoGrid.columns[i].field === column)
                columnPosition = i;
        }

        if (show) {
            $(grid).find("table th").eq(column).show();
            kendoGrid.showColumn(columnPosition);
        } else {
            $(grid).find("table th").eq(column).hide();
            kendoGrid.hideColumn(columnPosition);
        }
    }


    function getGuid(str) {
        return str.slice(0, 8) + "-" + str.slice(8, 12) + "-" + str.slice(12, 16) +
            "-" + str.slice(16, 20) + "-" + str.slice(20, str.length + 1);
    }
});