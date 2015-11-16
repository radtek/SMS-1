$(function () {

    $('#yesButton').on('click', function () {
        showAudit($('#confirmDetails-form').data("index"));
        hideCurrentModal();
    });

});
