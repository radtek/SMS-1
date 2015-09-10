$(function () {
    //set up grid options for the three grids. most are passed straight on to kendo grid.
    var notificationsGrid = new gridItem(
    {
        gridElementId: 'notificationsGrid',
        url: $('#notificationsGrid').data("url"),
        schema: { data: "data", total: "total", model: { id: "NotificationID" } },
        defaultSort: { field: "DateSent", dir: "desc" },
        change: notificationsChange,
        panels: ['notificationsPanel'],
        columns: [
                {
                    field: "NotificationID",
                    hidden: true,
                },
                {
                    field: "NotificationSubject",
                    title: "Notification Subject"
                },
                {
                    field: "DateSent",
                    title: "Date Sent",
                    template: function (dataItem) {
                        return moment(dataItem.DateSent).format('DD/MM/YYYY HH:mm');
                    }
                }
        ]
    });

    notificationsGrid.makeGrid();
});

//data binding for the panes beneath each grid
function notificationsChange(dataItem) {
    var notificationDetailsBtn = $("#notificationDetailsButton");
    var notificationPdfBtn = $("#notificationPdfButton");
    var notificationContentElement = $("#notificationContent");
    var notificationContentWrapper = $('#notificationContentWrapper');
    var spinner = $('#notificationsPanel .fa-spin');

    spinner.show();
    notificationContentWrapper.hide();

    ajaxWrapper({
        url: notificationContentWrapper.data("url"),
        method: 'GET',
        data: { notificationId: dataItem.NotificationID }
    }).done(function (result) {
        notificationContentElement.html(result.data);
        notificationDetailsBtn.attr('href', $(notificationDetailsBtn).data("url") + "?notificationId=" + dataItem.NotificationID);
        notificationPdfBtn.attr('href', $(notificationPdfBtn).data("url") + "?notificationId=" + dataItem.NotificationID);

        notificationContentWrapper.show();
        spinner.hide();
    });
}
