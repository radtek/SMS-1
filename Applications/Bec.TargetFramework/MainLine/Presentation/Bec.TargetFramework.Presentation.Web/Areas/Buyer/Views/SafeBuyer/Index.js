$(function () {
    'use strict';

    findModalLinks();
    showAudit(0);
    setupNotifyButton();
    setupDates();

    function setupNotifyButton() {
        $('.notify-button').each(function () {
            $(this).on('click', function () {
                var index = $(this).data('index');
                var url = $(this).data('href');
                $('#post-no-match-' + index).show();
                $('#notify-button-' + index).hide();

                ajaxWrapper({
                    url: url + "&accountNumber=" + $('#accountNumberNoMatch-' + index).text() + "&sortCode=" + $('#sortCodeNoMatch-' + index).text(),
                    method: "POST"
                });
            });
        });
    }

    function setupDates() {
        $('.format-date').each(function () {
            $(this).text(dateStringNoTime($(this).data("val")));
        });

        $('.format-number').each(function () {
            $(this).text(formatCurrency($(this).data("val")));
        });
    }
});

// Publicly available!!! Used by _ConfirmDetails.js too
function showAudit(index) {
    var matchTemplate = Handlebars.compile(
    '<div class="alert alert-success fade in margin-left-10 margin-right-10">' +
        '<h4><i class="fa fa-check-square-o"></i><strong> Match</strong></h4>' +
        '<p>{{date}}: The bank account with account number <strong>{{accountNumber}}</strong> and sort code <strong>{{sortCode}}</strong> is registered to <strong>{{companyName}}</strong> on the Safe Move Scheme.</p>' +
    '</div>');

    var warnTemplate = Handlebars.compile(
        '<div class="alert alert-warning fade in margin-left-10 margin-right-10">' +
            '<h4><i class="fa fa-check-square-o"></i><strong> Match</strong></h4>' +
            '<p>{{date}}: The bank account with account number <strong>{{accountNumber}}</strong> and sort code <strong>{{sortCode}}</strong> did belong to <strong>{{companyName}}</strong> at the time when the check was performed. The status of this account has since changed.</p>' +
        '</div>');

    var nomatchTemplate = Handlebars.compile(
        '<div class="alert alert-danger fade in margin-left-10 margin-right-10">' +
            '<h4><i class="fa fa-warning"></i><strong> No Match. Do not send funds.</strong></h4>' +
            "<p>{{date}}: The bank account with account number <strong>{{accountNumber}}</strong> and sort code <strong>{{sortCode}}</strong> is not a registered bank account on The Safe Move Scheme. <strong>Please contact {{companyName}} immediately on {{phone}}</strong></p>" +
        '</div>');

    var auditDiv = $('#audit-' + index);
    var companyName = $('#collapse-' + index).data("companyname");
    var phone = $('#collapse-' + index).data("phone");
    auditDiv.empty();
    ajaxWrapper({
        url: auditDiv.data("url")
    }).done(function (res) {
        auditDiv.append("<h5>Previous checks:</h5>");
        for (var i in res) {
            var html;
            res[i].date = dateString(res[i].date);
            res[i].companyName = companyName;
            res[i].phone = phone;
            switch (res[i].result) {
                case "match": html = matchTemplate(res[i]); break;
                case "warn": html = warnTemplate(res[i]); break;
                case "nomatch": html = nomatchTemplate(res[i]); break;
            }
            auditDiv.append(html);
        }
    }).fail(function (e) {
        if (!hasRedirect(e.responseJSON)) {
            console.log(e);
            $('#result-server-error-' + index).show();
        }
    });;
}
