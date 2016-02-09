var newsArticleDetailsTemplatePromise;
var newsArticlesGrid;
$(function () {
    newsArticlesGrid = new gridItem(
    {
        gridElementId: 'newsArticlesGrid',
        url: $('#newsArticlesGrid').data("url"),
        schema: { data: "Items", total: "Count", model: { id: "NewsArticleID" } },
        type: 'odata-v4',
        defaultSort: { field: "DateTime", dir: "desc" },
        panels: ['newsArticlesPanel'],
        change: newsArticleChange,
        jumpToId: $('#newsArticlesGrid').data("jumpto"),
        columns: [
            {
                field: "NewsArticleID",
                hidden: true,
            },
            {
                field: "Title",
                title: "Title"
            },
            {
                field: "DateTime",
                template: function (dataItem) { return dateString(dataItem.DateTime); }
            },
        ]
    });

    newsArticlesGrid.makeGrid();
    findModalLinks();

    newsArticleDetailsTemplatePromise = $.Deferred();
    ajaxWrapper(
        { url: $('#content').data("templateurl") + '?view=' + getRazorViewPath('_newsArticleDetailsTmpl', 'NewsArticle', 'Admin') }
    ).done(function (res) {
        newsArticleDetailsTemplatePromise.resolve(Handlebars.compile(res));
    }).fail(function (e) {
        if (!hasRedirect(e.responseJSON)) {
            showtoastrError();
        }
    });
});

function newsArticleChange(dataItem) {
    $("#editButton").data('href', $("#editButton").data("url") + "?newsArticleID=" + dataItem.NewsArticleID);
    $("#editButton").attr("disabled", dataItem.Confirmed);

    showNewsDetails(dataItem);
}

function showNewsDetails(dataItem) {
    var data = _.extend({}, dataItem, {
        contentLines: dataItem.Content.split('\n')
    });
    newsArticleDetailsTemplatePromise.done(function (template) {
        var html = template(data);
        $('#newsArticleDetails').html(html);
    });
}
