﻿$(function () {
    'use strict';

    findModalLinks();
    showAudit(0);
    setupTabs();
    setupState();
    setupEditForm();
    setupDates();

    $('.pending-update').each(function(i, anchor){
        var anchorElement = $(anchor);
        var originalValue = anchorElement.data('pending-originalval');
        var pendingValue = anchorElement.data('pending-value');
        var fullName = anchorElement.data('pending-fullname');
        var modifiedOn = anchorElement.data('pending-modifiedon');

        var content = $('<table class="pending-update-table"><tr><td>Original:</td><td><strong>' + originalValue +'</strong></td></tr><tr><td>Requested:</td><td><strong>'+ pendingValue + '</strong></td></tr></table>');
        var title = 'Pending update from ' + fullName + ', on ' + dateString(modifiedOn);

        anchorElement.popover({
            content: content,
            html: true,
            placement: "bottom",
            title: title,
            trigger: "focus"
        });
    });

    function setupEditForm() {
        makeDatePicker("#birthDateInput", {
            maxDate: new Date()
        });
        $('#lenderSearch').lenderSearch({
            searchUrl: $('#lenderSearch').data("url")
        });
        $('#buyingWithMortgage').click(function () {
            $('#mortgageDetails').toggle(this.checked);
            if (!this.checked) {
                $('#lenderSearch').val('');
                $('#lenderAppNumber').val('');
            }
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

    function setupState() {
        var advised = $('#content').data('advised') == "True";
        var accepted = $('#content').data('accepted') == "True";
        var declined = $('#content').data('declined') == "True";
        
        if (!accepted) {
            $('#acceptProductBtn').show();
            $('#infoBankAccountCheck').hide();

            if (declined) {
                $('#checkBankAccountBtn').hide();
                if(advised)
                    $('#declineAdvisedMessage').show();
                else
                    $('#declineMessage').show();
            }
            else {
                $('#declineButton').show();
                $('#checkBankAccountBtn').hide();
                if (advised)
                    $('#infoAdviceMessage').show();
                else
                    $('#infoMessage').show();
            }
        }
    }

});

// Publicly available!!! Used by _Edit.js too
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
            $('#result-server-error').show();
        }
    });;
}
