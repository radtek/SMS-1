$(function () {
    'use strict';

    // submit from when Save button clicked
    $("#submitEditHelp").click(function () {
        $("#editHelp-form").submit();
    });

    $("#editHelp-form").validate({
        ignore: ':hidden',
        // Rules for form validation
        rules: {
            HelpTypeID: {
                required: true
            },
            Name: {
                required: true
            },
            UiPageUrl: {
                required: true,
                remote: {
                    cache: false,
                    url: $('#UiPageUrl').data("url"),
                    data: {
                        htn: function () { return $("#HelpTypeID").find(":selected").text(); },
                        helpID: function () { return $("#HelpID").val(); },
                        uiPageUrl: function () { return $("#UiPageUrl").val(); },
                        __RequestVerificationToken: $("input[name='__RequestVerificationToken']").val()
                    },
                    type: 'POST',
                    dataType: 'json',
                    error: function (xhr, status, error) { checkRedirect(xhr.responseJSON); }
                }
            }
        },

        // Do not change code below
        errorPlacement: function (error, element) {
            error.insertAfter(element.parent());
        },

        submitHandler: validateSubmit
    });
   
    
    function hideAndShow()
    {
        $("#HelpTypeID").prop('disabled', true);
        $("#editHelpItemButton").hide();
        hideShowElementsBasedOnHelpType($("#HelpTypeID").find(":selected").text());
        
        $("#addEditHelpItemButton").data('href', ($("#addEditHelpItemButton").attr('data-href') + "&htn=" + $("#HelpTypeID").find(":selected").text()));
    }
    
    function editItem(e)
    {
        e.preventDefault();

        var dataItem = this.dataItem($(e.currentTarget).closest("tr"));
        $("#editHelpItemButton").data('href', ($("#editHelpItemButton").attr('data-href') + "&htn=" + $("#HelpTypeID").find(":selected").text() + "&hiID=" + getGuid(dataItem.HelpItemID)));
        $("#editHelpItemButton").click();
    }

    function upItem(e) {
        e.preventDefault();

        var dataItem = this.dataItem($(e.currentTarget).closest("tr"));
        performGridFunctionViaGETAndRefresh(($("#upItemButton").attr('data-href') + "&hiID=" + getGuid(dataItem.HelpItemID)), "#ehGrid");
    }

    function downItem(e) {
        e.preventDefault();

        var dataItem = this.dataItem($(e.currentTarget).closest("tr"));
        performGridFunctionViaGETAndRefresh(($("#downItemButton").attr('data-href') + "&hiID=" + getGuid(dataItem.HelpItemID)), "#ehGrid");
    }

    function deleteItem(e) {
        e.preventDefault();

        var dataItem = this.dataItem($(e.currentTarget).closest("tr"));
        $("#deleteItemButton").data('href', ($("#deleteItemButton").attr('data-href') + "?hiID=" + getGuid(dataItem.HelpItemID)));
        $("#deleteItemButton").click();
    }

    function hideShowElementsBasedOnHelpType(helpType) {
        if (helpType === "ShowMeHow") {
            showHideAndClearValueElement("#uiPageUrlSection",null, true);
        }
        else {
            showHideAndClearValueElement("#uiPageUrlSection", null, false);
        } 
    }

    function validateSubmit(form) {
        $("#submitEditHelp").prop('disabled', true);
        form.submit();
    }

    var ehGrid = new gridItem(
        {
            gridElementId: 'ehGrid',
            url: $('#ehGrid').data("url"),
            schema: { data: "Items", total: "Count", model: { id: "HelpItemID" } },
            type: 'json',
            serverSorting: true,
            serverPaging: true,
            defaultSort: { field: "DisplayOrder", dir: "asc" },
            resetSort: $('#ehGrid').data("resetsort"),
            jumpToId: $('#ehGrid').data("jumpto"),
            jumpToPage: $('#ehGrid').data("jumptopage"),
            jumpToRow: $('#ehGrid').data("jumptorow"),
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
                    template: function (dataItem) {
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
                    template: function (dataItem) { if (dataItem.EffectiveFrom == null) { return '' } else return kendo.toString(kendo.parseDate(dataItem.EffectiveFrom), 'dd MMM yyyy'); }
                },
                {
                    command: { name: "Up", text: "", imageClass: "k-icon k-i-arrowhead-n", click: upItem }, title: " ",
                    width: 40
                },
                {
                    command: { name: "Down", text: "", imageClass: "k-icon k-i-arrowhead-s ob-icon-only", click: downItem }, title: " ",
                    width: 40
                },
                {
                    command: { name: "Edit", text: "", imageClass: "k-icon k-i-pencil ob-icon-only", click: editItem }, title: " ",
                    width: 40
                },
                {
                    command: { name: "Delete", text: "", imageClass: "k-icon k-i-close ob-icon-only", click: deleteItem }, title: " ",
                    width: 40
                }
            ]
        });

    ehGrid.makeGrid();

    $('#ehGrid').data('kendoGrid').bind("dataBound", function (e) {
        var helpType = $("#HelpTypeID").find(":selected").text();
        if (helpType === "Callout") {
            hideShowGridColumn('#ehGrid', "UiPositionName", false);
            hideShowGridColumn('#ehGrid', "EffectiveFrom", true);
        }
        else {
            hideShowGridColumn('#ehGrid', "UiPositionName", true);
            hideShowGridColumn('#ehGrid', "EffectiveFrom", false);
        }
    });

    hideAndShow();

    function showHideAndClearValueElement(sectionName, show) {
        if (show) {
            $(sectionName).css('display', 'block');
        }
        else {
            $(sectionName).css('display', 'none');
        }
    }

    function performGridFunctionViaGETAndRefresh(url, grid) {
        $.ajax({
            url: url,
            type: 'GET',
            success: function (data) {
                if (data.success === true) {
                    $(grid).data('kendoGrid').dataSource.read();
                }
            }
        });
    }

    function hideShowGridColumn(grid, column, show) {
        if (show) {
            $(grid).find("table th").eq(column).show();
            $(grid).data('kendoGrid').showColumn(column);
        }
        else {
            $(grid).find("table th").eq(column).hide();
            $(grid).data('kendoGrid').hideColumn(column);
        }
    }


    function getGuid(str) {
        return str.slice(0, 8) + "-" + str.slice(8, 12) + "-" + str.slice(12, 16) +
            "-" + str.slice(16, 20) + "-" + str.slice(20, str.length + 1);
    }
});