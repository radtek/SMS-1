$(function () {
    var btnDelete = $("#btnDeleteHelp");
    var btnEdit = $("#btnEditHelp");
    var helpItemList = $("#helpItemList");
    var typeDropdown = $("#typeList");

    var urls = {
        deleteHelpUrl: btnDelete.data("url"),
        editHelpUrl: btnEdit.data("url"),
        getHelpsUrl: helpItemList.data("helps-url"),
        templateUrl: helpItemList.data("template-url"),
        getHelpItemsUrl: helpItemList.data("items-url")
    }

    var currentHelp = {
        id: null,
        type: null
    }
    var helpItemsTemplatePromise = getTemplatePromise('_ItemList');

    function getTemplatePromise(viewName) {
        var def = $.Deferred();
        ajaxWrapper({
            url: urls.templateUrl,
            data: {
                view: getRazorViewPath(viewName, 'Help', 'Admin')
            }
        }).then(function (res) {
            def.resolve(Handlebars.compile(res));
        });
        return def;
    }

    var helpGrid = new gridItem(
        {
            gridElementId: 'helpGrid',
            url: $('#helpGrid').data("url"),
            schema: { data: "Items", total: "Count", model: { id: "HelpPageID" } },
            defaultSort: { field: "PageName", dir: "asc" },
            panels: ['helpDetailPanel'],
            change: onPageChange,
            jumpToId: $('#helpGrid').data("jumpto"),
            extraParameters: function () {
                return "&type=" + $('#typeList').val()
            },
            columns: [
                    {
                        field: "HelpPageID",
                        hidden: true,
                    },
                    {
                        field: "PageName",
                        title: "Page Name",
                    },
                    {
                        field: "PageUrl",
                        title: "Page URL"
                    },
                    {
                        field: "PageType",
                        title: "Page Type",
                        template: function (dataItem) { return (dataItem.PageType == 1 ? "Tour" : (dataItem.PageType == 2 ? "Show Me How" : "Callout")); }
                    },
                    {
                        field: "CreatedOn",
                        title: "Created On",
                        template: function (dataItem) { return dateString(dataItem.CreatedOn); }
                    },
                    {
                        field: "ModifiedOn",
                        title: "Modified On",
                        template: function (dataItem) { return dateString(dataItem.ModifiedOn); }
                    }
            ]
        });

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
        console.log(valOfThis.length);
        if (valOfThis.length > 0) {
            $("#btnAddPage").data('href', $("#btnAddPage").data("url") + "?PageType=" + valOfThis);
        }
        else {
            console.log('a');
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
            .then(function (result) {
                var templateData = {
                    data: result
                };
                helpItemsTemplatePromise.done(function (template) {
                    var html = template(templateData);
                    helpItemList.html(html);
                });
            });
    }

    function onPageChange(dataItem) {

        $("p#ddnName").text(dataItem.PageName);
        $("p#ddnUrl").text(dataItem.PageUrl != null ? dataItem.PageUrl : "");
        $("p#ddnType").text((dataItem.PageType == 1 ? "Tour" : (dataItem.PageType == 2 ? "Show Me How" : "Callout")) || "");
        $("p#ddnCreatedOn").text(dateString(dataItem.CreatedOn) || "");
        $("p#ddnModifiedOn").text(dateString(dataItem.ModifiedOn) || "");
        btnEdit.data('href', urls.editHelpUrl + "?pageId=" + dataItem.HelpPageID);
        btnDelete.data('href', urls.deleteHelpUrl + "?pageId=" + dataItem.HelpPageID);
        loadItemForPage(dataItem.HelpPageID, urls.getHelpItemsUrl);
    }
});

