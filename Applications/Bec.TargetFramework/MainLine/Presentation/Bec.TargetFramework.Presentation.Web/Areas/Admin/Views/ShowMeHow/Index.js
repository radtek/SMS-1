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
                listId: postData,
                __RequestVerificationToken: $("input[name='__RequestVerificationToken']").val()
            },
            type: 'POST'
        })
                .always(function () {
                })
                .done(function (result) {
                    if (result.data != null || result.data != undefined) {
                        $('#saveItemOrder').addClass('btn-default');
                        $('#saveItemOrder').removeClass('btn-primary');
                        $('#saveOrderStatus').css('display', 'inline-block').fadeIn(1000).delay(3000).fadeOut(1000);
                    }
                })
                .fail(function (err) {
                    if (!hasRedirect(err.responseJSON)) self.lookupFailed();
                });
    }

    function SendUpdateOrder2() {
        var ids = [];
        var postData = "";
        var self = this;
        $('#ItemList2 li').each(function () {
            var index = $(this).index();
            var idValue = $(this).data("itemid");
            postData += index + "," + idValue + ";";
        });
        ajaxWrapper({
            url: $("#saveItemOrder2").data("url"),
            data: {
                listId: postData,
                __RequestVerificationToken: $("input[name='__RequestVerificationToken']").val()
            },
            type: 'POST'
        })
                .always(function () {
                })
                .done(function (result) {
                    if (result.data != null || result.data != undefined) {
                        $('#saveItemOrder2').addClass('btn-default');
                        $('#saveItemOrder2').removeClass('btn-primary');
                        $('#saveOrderStatus2').css('display', 'inline-block').fadeIn(1000).delay(3000).fadeOut(1000);
                    }
                })
                .fail(function (err) {
                    if (!hasRedirect(err.responseJSON)) self.lookupFailed();
                });
    }

    $('#saveItemOrder').click(function () {
        SendUpdateOrder();
    });

    $('#saveItemOrder2').click(function () {
        SendUpdateOrder2();
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

                        $('#saveItemOrder').removeClass('btn-default');
                        $('#saveItemOrder').addClass('btn-primary');
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
                $('#ItemList2').remove();
                var items = [];
                var editLink = $('#editItemLink2').data('url');
                var deleteLink = $('#deleteItemLink2').data('url');
                $.each(result.data, function (i, item) {
                    items.push("<li data-itemid='" + item.ItemID + "'>"
                        + "<span>" + item.ItemName + "</span>"
                        + "<span>| <a data-href=\"" + editLink + "?itemId=" + item.ItemID + "\" data-modallink=\"true\">Edit</a>"
                        + " | <a data-href=\"" + deleteLink + "?itemId=" + item.ItemID + "\" data-modallink=\"true\">Delete</a></span>"
                    + "</li>");
                });

                $("<ul/>", {
                    "id": "ItemList2",
                    html: items.join("")
                }).insertAfter("#listItem2");

                $('#ItemList2').sortable({
                    start: function (event, ui) {
                        var start_pos = ui.item.index();
                        ui.item.data('start_pos', start_pos);
                    },
                    change: function (event, ui) {
                        var start_pos = ui.item.data('start_pos');
                        var index = ui.placeholder.index();

                        if (start_pos < index) {
                            $('#ItemList2 li:nth-child(' + index + ')').addClass('highlights');
                            ui.item.data('start_index', start_pos + 1);
                            ui.item.data('end_index', index);
                        } else {
                            $('#ItemList2 li:eq(' + (index + 1) + ')').addClass('highlights');
                            ui.item.data('start_index', start_pos + 1);
                            ui.item.data('end_index', index + 1);
                        }

                        $('#saveItemOrder2').removeClass('btn-default');
                        $('#saveItemOrder2').addClass('btn-primary');
                    },
                    update: function (event, ui) {
                        $('#ItemList2 li').removeClass('highlights');
                    }
                });
            }, function (data) {
                console.log("ERR");
            });
    }

    //data binding for the panes beneath each grid
    function onPageChange(dataItem) {
        $("p#ddnName").text(dataItem.PageName);
        $("p#ddnRole").text(dataItem.RoleName || "");
        $("p#ddnURL").text(dataItem.PageUrl || "");

        $("#editPage").data('href', $("#editPage").data("url") + "?pageId=" + dataItem.PageId);
        $("#delPage").data('href', $("#delPage").data("url") + "?pageId=" + dataItem.PageId);
        $("#btnAddPageItem").data('href', $("#btnAddPageItem").data("url") + "?pageId=" + dataItem.PageId);

        loadItemForPage(dataItem.PageId, $("#listItem").data("url"));
    }

    function forSystemChange(dataItem) {
        $("p#ddnName2").text(dataItem.PageName);
        $("p#ddnRole2").text(dataItem.RoleName || "");

        $("#editPage2").data('href', $("#editPage2").data("url") + "?pageId=" + dataItem.PageId);
        $("#delPage2").data('href', $("#delPage2").data("url") + "?pageId=" + dataItem.PageId);
        $("#btnAddPageItem2").data('href', $("#btnAddPageItem2").data("url") + "?pageId=" + dataItem.PageId);

        loadItemForPage2(dataItem.PageId, $("#listItem2").data("url"));
    }

});