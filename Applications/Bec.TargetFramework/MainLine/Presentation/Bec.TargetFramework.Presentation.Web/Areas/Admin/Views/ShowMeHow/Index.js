var onPageGrid;
var forSystemGrid;
$(function () {

    //set up grid options for the three grids. most are passed straight on to kendo grid.
    onPageGrid = new gridItem(
        {
            gridElementId: 'onPageGrid',
            url: $('#onPageGrid').data("url"),
            schema: { data: "list", total: "total", model: { id: "PageId" } },
            type: 'odata-v4',
            defaultSort: { field: "PageId", dir: "asc" },
            panels: ['onPagePanel'],
            change: onPageChange,
            jumpToId: $('#onPageGrid').data("jumpto"),
            extraParameters: function () {
                return "&roleId=" + $('#roleOnPage').val()
            },
            columns: [
                    {
                        field: "PageId",
                        hidden: true,
                    },
                    {
                        field: "PageName",
                        title: "Page Name",
                    },
                    {
                        field: "PageUrl",
                        title: "URL"
                    },
                    {
                        field: "RoleId",
                        hidden: true,
                    },
                    {
                        field: "RoleName",
                        title: "Role"
                    }
            ]
        });

    forSystemGrid = new gridItem(
        {
            gridElementId: 'forSystemGrid',
            url: $('#forSystemGrid').data("url"),
            schema: { data: "list", total: "total", model: { id: "PageId" } },
            type: 'odata-v4',
            defaultSort: { field: "PageId", dir: "asc" },
            panels: ['forSystemPanel'],
            change: forSystemChange,
            jumpToId: $('#forSystemGrid').data("jumpto"),
            extraParameters: function () {
                return "&roleId=" + $('#roleForSystem').val()
            },
            columns: [
                    {
                        field: "PageId",
                        hidden: true,
                    },
                    {
                        field: "PageName",
                        title: "Page Name",
                    },
                    {
                        field: "PageUrl",
                        hidden: true,
                    },
                    {
                        field: "RoleId",
                        hidden: true,
                    },
                    {
                        field: "RoleName",
                        title: "Role"
                    }
            ]
        });

    var tabs = new tabItem("myTab1",
    {
        s1: {
            grids: [onPageGrid]
        },
        s2: {
            grids: [forSystemGrid]
        }
    });


    tabs.makeTab();
    tabs.showTab($('#myTab1').data("selected"));
    findModalLinks();

    $('#roleOnPage').on('change', function () {
        onPageGrid.refreshGrid();
    });

    $('#roleForSystem').on('change', function () {
        forSystemGrid.refreshGrid();
    });

    function SendUpdateOrder() {
        var ids = [];
        var postData = "";
        var self = this;
        $('#ItemList li').each(function () {
            var index = $(this).index();
            var idValue = $(this).data("itemid");
            postData += index + "," + idValue + ";";
        });
        ajaxWrapper({
            url: $("#saveItemOrder").data("url"),
            data: {
                listId : postData,
                pageId: $('#pageId').val(),
                isSysPage : false,
                __RequestVerificationToken: $("input[name='__RequestVerificationToken']").val()
            },
            type: 'POST'
        })               
                .done(function (response) {
                    if (response != null || response != undefined) {
                        window.location.href = response.Url;
                    }
                })
    }

    function SendUpdateSysOrder() {
        var ids = [];
        var postData = "";
        var self = this;
        $('#SysItemList li').each(function () {
            var index = $(this).index();
            var idValue = $(this).data("itemid");
            postData += index + "," + idValue + ";";
        });
        ajaxWrapper({
            url: $("#saveSysItemOrder").data("url"),
            data: {
                listId: postData,
                pageId: $('#sysPageId').val(),
                isSysPage: true,
                __RequestVerificationToken: $("input[name='__RequestVerificationToken']").val()
            },
            type: 'POST'
        })
                .done(function (response) {
                    if (response != null || response != undefined) {
                        window.location.href = response.Url;
                    }
                })
    }

    $('#saveItemOrder').click(function () {
        SendUpdateOrder();
    });

    $('#saveSysItemOrder').click(function () {
        SendUpdateSysOrder();
    });

    function loadItemForPage(PageId, url) {
        var ajaxOptions = {
            url: url,
            data: { pageId: PageId },
            cache: false
        };
        ajaxWrapper(ajaxOptions)
            .then(function (result) {
                $('#ItemList').remove();
                var items = [];
                var editLink = $('#editItemLink').data('url');
                var deleteLink = $('#deleteItemLink').data('url');
                $.each(result.data, function (i, item) {
                    items.push("<li data-itemid='" + item.ItemID + "'>"
                        + "<span>" + item.ItemName + "</span>"
                        + "<span>| <a data-href=\"" + editLink + "?itemId=" + item.ItemID + "\" data-modallink=\"true\">Edit</a>"
                        + " | <a data-href=\"" + deleteLink + "?itemId=" + item.ItemID + "\" data-modallink=\"true\">Delete</a></span>"
                    + "</li>");
                });


                $("<ul/>", {
                    "id": "ItemList",
                    html: items.join("")
                }).insertAfter("#listItem");

                $('#ItemList').sortable({
                    start: function (event, ui) {
                        var start_pos = ui.item.index();
                        ui.item.data('start_pos', start_pos);
                    },
                    change: function (event, ui) {
                        var start_pos = ui.item.data('start_pos');
                        var index = ui.placeholder.index();

                        if (start_pos < index) {
                            $('#ItemList li:nth-child(' + index + ')').addClass('highlights');
                            ui.item.data('start_index', start_pos + 1);
                            ui.item.data('end_index', index);
                        } else {
                            $('#ItemList li:eq(' + (index + 1) + ')').addClass('highlights');
                            ui.item.data('start_index', start_pos + 1);
                            ui.item.data('end_index', index + 1);
                        }
                                                
                        enableButton($('#saveItemOrder'));
                    },
                    update: function (event, ui) {
                        $('#ItemList li').removeClass('highlights');
                    }
                });
            }, function (data) {
                console.log("ERR");
            });
    }

    function loadItemForPage2(PageId, url) {
        var ajaxOptions = {
            url: url,
            data: { pageId: PageId },
            cache: false
        };
        ajaxWrapper(ajaxOptions)
            .then(function (result) {
                $('#SysItemList').remove();
                var items = [];
                var editLink = $('#editSysItemLink').data('url');
                var deleteLink = $('#delSysItemLink').data('url');
                $.each(result.data, function (i, item) {
                    items.push("<li data-itemid='" + item.ItemID + "'>"
                        + "<span>" + item.ItemName + "</span>"
                        + "<span>| <a data-href=\"" + editLink + "?itemId=" + item.ItemID + "\" data-modallink=\"true\">Edit</a>"
                        + " | <a data-href=\"" + deleteLink + "?itemId=" + item.ItemID + "\" data-modallink=\"true\">Delete</a></span>"
                    + "</li>");
                });

                $("<ul/>", {
                    "id": "SysItemList",
                    html: items.join("")
                }).insertAfter("#listSysItem");

                $('#SysItemList').sortable({
                    start: function (event, ui) {
                        var start_pos = ui.item.index();
                        ui.item.data('start_pos', start_pos);
                    },
                    change: function (event, ui) {
                        var start_pos = ui.item.data('start_pos');
                        var index = ui.placeholder.index();

                        if (start_pos < index) {
                            $('#SysItemList li:nth-child(' + index + ')').addClass('highlights');
                            ui.item.data('start_index', start_pos + 1);
                            ui.item.data('end_index', index);
                        } else {
                            $('#SysItemList li:eq(' + (index + 1) + ')').addClass('highlights');
                            ui.item.data('start_index', start_pos + 1);
                            ui.item.data('end_index', index + 1);
                        }

                        enableButton($('#saveSysItemOrder'));
                    },
                    update: function (event, ui) {
                        $('#SysItemList li').removeClass('highlights');
                    }
                });
            }, function (data) {
                console.log("ERR");
            });
    }
    function setDefaultButton(btn) {        
        $(btn).addClass('disabled');
    }
    function enableButton(btn) {
        $(btn).removeClass('disabled');
    }

    //data binding for the panes beneath each grid
    function onPageChange(dataItem) {
        $("p#ddnName").text(dataItem.PageName);
        $("p#ddnRole").text(dataItem.RoleName || "");
        $("p#ddnURL").text(dataItem.PageUrl || "");
        $('#pageId').val(dataItem.PageId);

        $("#editPage").data('href', $("#editPage").data("url") + "?pageId=" + dataItem.PageId);
        $("#delPage").data('href', $("#delPage").data("url") + "?pageId=" + dataItem.PageId);
        $("#btnAddPageItem").data('href', $("#btnAddPageItem").data("url") + "?pageId=" + dataItem.PageId);
        setDefaultButton($('#saveItemOrder'));
        setDefaultButton($('#saveSysItemOrder'));

        loadItemForPage(dataItem.PageId, $("#listItem").data("url"));
    }

    function forSystemChange(dataItem) {
        $("p#ddnSysName").text(dataItem.PageName);
        $("p#ddnSysRole").text(dataItem.RoleName || "");
        $('#sysPageId').val(dataItem.PageId);

        $("#editSysPage").data('href', $("#editSysPage").data("url") + "?pageId=" + dataItem.PageId);
        $("#delSysPage").data('href', $("#delSysPage").data("url") + "?pageId=" + dataItem.PageId);
        $("#btnAddSysPageItem").data('href', $("#btnAddSysPageItem").data("url") + "?pageId=" + dataItem.PageId);
        setDefaultButton($('#saveItemOrder'));
        setDefaultButton($('#saveSysItemOrder'));

        loadItemForPage2(dataItem.PageId, $("#listSysItem").data("url"));
    }

});