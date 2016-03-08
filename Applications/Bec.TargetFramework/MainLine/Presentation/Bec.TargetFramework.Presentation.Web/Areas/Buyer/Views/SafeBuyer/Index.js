$(function () {
    'use strict';

    findModalLinks();
    showAudit(0);
    setupNotifyButton();
    setupDates();
    setupTabs();

    function setupNotifyButton() {
        $('.notify-button').each(function () {
            $(this).on('click', function () {
                var url = $(this).data('href');
                $('#post-no-match').show();
                $('#notify-button').hide();

                ajaxWrapper({
                    url: url + "&accountNumber=" + $('#accountNumberNoMatch').text() + "&sortCode=" + $('#sortCodeNoMatch').text(),
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

    function setupTabs() {
        var areConversationsLoaded = false;
        $('#transactionTabs li a').click(function (e) {
            e.stopPropagation();
            if (history.pushState) {
                history.pushState(null, null, $(this).attr('href'));
            }
            $(this).tab('show');

            if (!areConversationsLoaded) {
                $('#safeSendPanel').trigger('loadConversations');
                areConversationsLoaded = true;
            }
            return false;
        });
    }

    if ($('#content').data("welcome") === "True") {
        $('#firstLogin').data("autorun", "False");
        handleModal({ url: $('#content').data("welcomeurl") }, null, true);        
    }
});

// Publicly available!!! Used by _ConfirmDetails.js too
function showAudit() {
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

    var auditDiv = $('#audit');
    var companyName = $('#transactionContainer').data("companyname");
    var phone = $('#transactionContainer').data("phone");
    auditDiv.empty();
    ajaxWrapper({
        url: auditDiv.data("url")
    }).done(function (res) {
        if (res.length > 0) auditDiv.append("<h5 class=\"padding-10\">Previous checks:</h5>");
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
            $('#result-server-error').show();
        }
    });;
}
