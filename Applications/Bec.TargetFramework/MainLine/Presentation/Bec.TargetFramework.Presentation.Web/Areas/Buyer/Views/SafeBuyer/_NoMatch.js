$(function () {

    $('#yesButton').on('click', function () {
        ajaxWrapper({
            url: $('#confirmDetails-form').data("url"),
            method: "POST"
        }).done(function () {
            showAudit($('#confirmDetails-form').data("index"));
            hideCurrentModal();
        });
    });

    $('#noButton').on('click', function () {
        $('#conf').click();
        hideCurrentModal();
    });
  
});
