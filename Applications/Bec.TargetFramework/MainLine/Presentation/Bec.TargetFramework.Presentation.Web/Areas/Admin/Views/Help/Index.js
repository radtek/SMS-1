
$(function () {
    'use strict';

    var promises;
    var hGrid;

    hGrid = new gridItem(
    {
        gridElementId: 'txGrid',
        url: $('#txGrid').data("url"),
        schema: { data: "Items", total: "Count", model: { id: "HelpID" } },
        type: 'odata-v4',
        serverSorting: true,
        serverPaging: true,
        autoFitColumns: true,
        change: helpChange,
        defaultSort: { field: "CreatedOn", dir: "desc" },
        resetSort: $('#txGrid').data("resetsort"),
        panels: ['helpPanel'],
        jumpToId: $('#txGrid').data("jumpto"),
        jumpToPage: $('#txGrid').data("jumptopage"),
        jumpToRow: $('#txGrid').data("jumptorow"),
        searchElementId: 'gridSearchInput',
        searchButtonId: 'gridSearchButton',
        clearSearchButtonId: 'clearGridSearch',
        extraFilters: [
            { selector: '#helpTypeFilter', parameter: 'helpTypeFilter' }
        ],
        columns: [
            {
                field: "HelpID",
                hidden: true
            },
            {
                field: "ClassificationType.Name",
                title: "Type"
            },
            {
                field: "Name",
                title: "Name"
            },
            {
                field: "Description",
                title: "Description"
            },
            {
                field: "UiPageUrl",
                title: "Page Url"
            },
            {
                field: "CreatedOn",
                title: "Created On",
                template: function (dataItem) { return kendo.toString(kendo.parseDate(dataItem.CreatedOn),'dd MMM yyyy'); }
            },
            {
                field: "CreatedBy",
                title: "Created By"
            },
            {
                field: "ModifiedOn",
                title: "Modified On",
                template: function (dataItem) { if (dataItem.ModifiedOn == null) { return '' } else return kendo.toString(kendo.parseDate(dataItem.ModifiedOn), 'dd MMM yyyy'); }
            },
            {
                field: "ModifiedBy",
                title: "Modified By"
            }
        ]
    });

    // render grid
    hGrid.makeGrid();
    findModalLinks();

    promises = new defTmpl('Help/TypeTemplates/',
        ['helptype'],
        [
            { name: 'Tour', description: 'Tour' },
            { name: 'Callout', description: 'Callout' },
            { name: 'ShowMeHow', description: 'Show Me How' }
        ]);

    function helpChange(dataItem) {
        if (!!dataItem.CreatedOn) dataItem.CreatedOnDisplay = dateString(dataItem.CreatedOn);
        if (!!dataItem.ModifiedOn) dataItem.ModifiedOnDisplay = dateString(dataItem.ModifiedOn);

        var data = _.extend({}, dataItem, {
            helpItems: _.toArray(dataItem.HelpItems)
        });

        // sort items
        data.helpItems.sort(function (a, b) { return a.DisplayOrder - b.DisplayOrder });

        promises.helptype[dataItem.ClassificationType.Name].done(function (template) {
            var html = template(data);
            $('#helpPanel').html(html);
        });
    }

    Handlebars.registerHelper('dateFormat', function (context, block) {

        if (window.moment && context && moment(context).isValid()) {

            var f = block.hash.format || "Do MMM YYYY";

            return moment(context).format(f);

        } else {

            return context; 
        }

    });
});





