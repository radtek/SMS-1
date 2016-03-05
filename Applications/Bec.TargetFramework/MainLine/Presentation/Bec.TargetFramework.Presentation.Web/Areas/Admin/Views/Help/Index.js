$(function () {
    var btnDelete = $("#btnDeleteHelp");
    var btnEdit = $("#btnEditHelp");
    var helpOrderListContainer = $("#help-item-order");
    var helpItemListContainer = $("#help-item-list");

    var urls = {
        deleteHelpUrl: btnDelete.data("url"),
        editHelpUrl: btnEdit.data("url"),
        getHelpItemsUrl: helpItemListContainer.data("items-url")
    };

    var helpGrid = new gridItem(
        {
            gridElementId: 'helpGrid',
            url: $('#helpGrid').data("url"),
            schema: { data: "Items", total: "Count", model: { id: "HelpPageID" } },
            defaultSort: { field: "HelpPageType", dir: "asc" },
            panels: ['helpDetailPanel'],
            change: onPageChange,
            jumpToId: $('#helpGrid').data("jumpto"),
            extraParameters: function () {
                return "&pageType=" + $('#typeList').val();
            },
            type: 'odata-v4',
            serverSorting: false,
            serverPaging: true,
            columns: [
                    {
                        field: "HelpPageType",
                        title: "Help Type"
                    },
                    {
                        field: "HelpPageID",
                        hidden: true
                    },
                    {
                        field: "PageName",
                        title: "Page Name"
                    },
                    {
                        field: "PageUrl",
                        title: "Page URL"
                    },
                    {
                        field: "CreatedOn",
                        title: "Created On",
                        template: function (dataItem) { return formatDate(dataItem.CreatedOn); },
                        type: "date"
                    },
                    {
                        field: "ModifiedOn",
                        title: "Modified On",
                        template: function (dataItem) { return dataItem.ModifiedOn !== null ? formatDate(dataItem.ModifiedOn) : ""; }
                    }
            ]
        });

    function formatDate(jsonDate) {
        var dateRegExp = /^\/Date\((.*?)\)\/$/;
        var date = dateRegExp.exec(jsonDate);
        return dateString(new Date(parseInt(date[1])));
    }

    var tabs = new tabItem("helpTab",
    {
        helpGridWrapper: {
            grids: [helpGrid]
        }
    });
    tabs.makeTab();
    tabs.showTab($('#helpTab').data("selected"));
    findModalLinks();

    $('#typeList').on('change', function () {
        var valOfThis = $(this).val();
        if (valOfThis.length > 0) {
            $("#btnAddPage").data('href', $("#btnAddPage").data("url") + "?HelpPageTypeId=" + valOfThis);
        }
        else {
            $("#btnAddPage").data('href', $("#btnAddPage").data("url"));
        }
        helpGrid.refreshGrid();
    });

    function loadItemForPage(pageId, url) {
        var ajaxOptions = {
            url: url,
            data: { pageId: pageId },
            cache: false
        };
        ajaxWrapper(ajaxOptions)
            .done(function (result) {
                loadItemForList(result.Items);
            });
    }

    function onPageChange(dataItem) {
        if (dataItem.HelpPageTypeId !== 800002) {
            $("p#ddnName").css('display', 'none');
            $("p#ddnUrl").css('display', 'none');
            $("dt#ddnNameLabel").css('display', 'none');
            $("dt#ddnUrlLabel").css('display', 'none');
        } else {
            $("p#ddnName").css('display', 'block');
            $("p#ddnUrl").css('display', 'block');
            $("dt#ddnNameLabel").css('display', 'block');
            $("dt#ddnUrlLabel").css('display', 'block');
            $("p#ddnUrl").text(dataItem.PageUrl != null ? dataItem.PageUrl : "");
        }
        $("p#ddnName").text(dataItem.PageName);
        $("p#ddnType").text(dataItem.HelpPageType);
        $("p#ddnCreatedOn").text(formatDate(dataItem.CreatedOn) || "");
        $("p#ddnModifiedOn").text(dataItem.ModifiedOn != null ? formatDate(dataItem.ModifiedOn) : "");
        btnEdit.data('href', urls.editHelpUrl + "?pageId=" + dataItem.HelpPageID);
        btnDelete.data('href', urls.deleteHelpUrl + "?pageId=" + dataItem.HelpPageID);
        loadItemForPage(dataItem.HelpPageID, urls.getHelpItemsUrl);
    }

    function loadItemForList(items) {
        helpItemListContainer.html("");
        helpOrderListContainer.html("");
        var order = 0;
        if (items != null && items.length >= 1) {
            for (var i = 0; i < items.length; i++) {
                var itemContent = createItem(items[i]);
                if (itemContent !== '') {
                    helpItemListContainer.append(itemContent);
                    order++;
                    helpOrderListContainer.append(createOrder(order));
                }
            }
        }
    }

    function createItem(item) {
        if (item.Status !== 800005) {
            var itemHtml = '<li class="ui-state-default" data-item-order="' + item.DisplayOrder + '" style="cursor: default;">' +
                            '<span class="help-item-title" style="width: 100%;">' + item.Title + '</span>' +
                            ' </li>';
            return itemHtml;
        } else {
            return '';
        }
    }
    function createOrder(order) {
        return '<li style="cursor: default;">' + order + '</li>';
    }
});

