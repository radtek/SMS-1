﻿var transactionDetailsTemplatePromise,
    primaryBuyerTemplatePromise,
    relatedPartiesTemplatePromise;
var txGrid;
$(function () {
    txGrid = new gridItem(
    {
        gridElementId: 'txGrid',
        url: $('#txGrid').data("url"),
        schema: { data: "Items", total: "Count", model: { id: "SmsTransactionID" } },
        type: 'odata-v4',
        serverSorting: true,
        serverPaging: true,
        defaultSort: { field: "SmsTransaction.CreatedOn", dir: "desc" },
        panels: ['rPanel'],
        jumpToId: $('#txGrid').data("jumpto"),
        jumpToPage: $('#txGrid').data("jumptopage"),
        change: txChange,
        searchElementId: 'gridSearchInput',
        searchButtonId: 'gridSearchButton',
        columns: [
            {
                field: "SmsTransactionID",
                hidden: true,
            },
            {
                field: "UserAccountOrganisation.UserAccount.Email",
                title: "Primary Buyer's Email"
            },
            {
                field: "SmsTransaction.Reference",
                title: "Your Reference"
            },
            {
                field: "SmsTransaction.Address.Line1",
                title: "Address Line 1"
            },
            {
                field: "SmsTransaction.Address.PostalCode",
                title: "Postcode"
            },
            {
                field: "SmsTransaction.CreatedOn",
                title: "Created On",
                template: function (dataItem) { return dateString(dataItem.SmsTransaction.CreatedOn); }
            },
            {
                field: "SmsTransaction.CreatedBy",
                title: "Created By"
            },
            {
                field: "UserAccountOrganisation.UserAccount.LastLogin",
                title: "Last Logged in",
                template: function (dataItem) {
                    return dataItem.UserAccountOrganisation.UserAccount.IsTemporaryAccount || !dataItem.UserAccountOrganisation.UserAccount.LastLogin
                        ? ""
                        : dateString(dataItem.UserAccountOrganisation.UserAccount.LastLogin);
                }
            }
        ]
    });

    txGrid.makeGrid();
    findModalLinks();

    transactionDetailsTemplatePromise = $.Deferred();
    ajaxWrapper(
        { url: $('#content').data("templateurl") + '?view=_transactionDetailsTmpl' }
    ).done(function (res) {
        transactionDetailsTemplatePromise.resolve(Handlebars.compile(res));
    });

    primaryBuyerTemplatePromise = $.Deferred();
    ajaxWrapper(
        { url: $('#content').data("templateurl") + '?view=_primaryBuyerDetailsTmpl' }
    ).done(function (res) {
        primaryBuyerTemplatePromise.resolve(Handlebars.compile(res));
    });

    relatedPartiesTemplatePromise = $.Deferred();
    ajaxWrapper(
        { url: $('#content').data("templateurl") + '?view=_relatedPartiesTmpl' }
    ).done(function (res) {
        relatedPartiesTemplatePromise.resolve(Handlebars.compile(res));
    });

    if ($('#content').data("welcome") == "True") {
        handleModal({ url: $('#content').data("welcomeurl") }, null, true);
    }
});

//data binding for the panes beneath each grid
function txChange(dataItem) {
    $("#addAdditionalBuyerButton").data('href', $("#addAdditionalBuyerButton").data("url") + "?txID=" + dataItem.SmsTransactionID + "&pageNumber=" + txGrid.grid.dataSource.page());
    $("#addGiftorButton").data('href', $("#addGiftorButton").data("url") + "?txID=" + dataItem.SmsTransactionID + "&pageNumber=" + txGrid.grid.dataSource.page());

    $("#editButton").data('href', $("#editButton").data("url") + "?txID=" + dataItem.SmsTransactionID + "&uaoID=" + dataItem.UserAccountOrganisationID + "&pageNumber=" + txGrid.grid.dataSource.page());
    $("#editButton").attr("disabled", dataItem.Confirmed);

    $("#pinButton").data('href', $("#pinButton").data("url") + "?txID=" + dataItem.SmsTransactionID + "&uaoID=" + dataItem.UserAccountOrganisationID + "&email=" + dataItem.UserAccountOrganisation.UserAccount.Email + "&pageNumber=" + txGrid.grid.dataSource.page());
    $("#pinButton").attr("disabled", !dataItem.UserAccountOrganisation.UserAccount.IsTemporaryAccount);
    
    $("#createConversationButton").data('href', $("#createConversationButton").data("url") + "?activityId=" + dataItem.SmsTransactionID + "&pageNumber=" + txGrid.grid.dataSource.page());

    showTransactionDetails(dataItem);
    showPrimaryBuyerDetails(dataItem);
    showTransactionRelatedParties(dataItem, $('#additionalBuyers').data("url"), 'additionalBuyers', 'additionalBuyersAccordion', 'spinnerAdditionalBuyers');
    showTransactionRelatedParties(dataItem, $('#giftors').data("url"), 'giftors', 'giftorsAccordion', 'spinnerGiftors');

    $('#transactionConversationContainer')
        .data('activity-id', dataItem.SmsTransactionID)
        .trigger('activitychange', dataItem.SmsTransactionID);
}

function showTransactionDetails(dataItem) {
    var data = _.extend({}, dataItem, {
        purchasePrice: formatCurrency(dataItem.SmsTransaction.Price),
        pageNumber:  txGrid.grid.dataSource.page()
    });
    transactionDetailsTemplatePromise.done(function (template) {
        var html = template(data);
        $('#transactionDetails').html(html);
    });
}

function showPrimaryBuyerDetails(dataItem) {
    var contact = dataItem.Contact;
    var data = _.extend({}, dataItem, {
        fullName: contact.Salutation + " " + contact.FirstName + " " + contact.LastName,
        formattedBirthDate: dateStringNoTime(contact.BirthDate),
        formattedLastLogin: dataItem.UserAccountOrganisation.UserAccount.LastLogin ? dateString(dataItem.UserAccountOrganisation.UserAccount.LastLogin) : null,
        formattedLatestBankAccountCheckOn: dataItem.LatestBankAccountCheck ? dateString(dataItem.LatestBankAccountCheck.CheckedOn) : null,
        pageNumber: txGrid.grid.dataSource.page(),
        srcFundsBankAccounts: _.toArray(dataItem.SmsSrcFundsBankAccounts)
    });

    primaryBuyerTemplatePromise.done(function (template) {
        var html = template(data);
        $('#primaryBuyer').html(html);
    });
}

function showTransactionRelatedParties(dataItem, url, targetElementId, accordionId, spinnerId) {
    $('#' + spinnerId).show();

    ajaxWrapper({
        url: url,
        type: 'GET',
        data: {
            transactionID: dataItem.SmsTransactionID
        }
    })
    .success(function (data) {
        var items = data.Items;
        items = _.map(items, function (item) {
            var contact = item.Contact;
            return _.extend({}, item, {
                fullName: contact.Salutation + " " + contact.FirstName + " " + contact.LastName,
                elementId: 'id' + item.SmsUserAccountOrganisationTransactionID,
                transactionId: item.SmsTransactionID,
                formattedBirthDate: dateStringNoTime(contact.BirthDate),
                formattedLastLogin: item.UserAccountOrganisation.UserAccount.LastLogin ? dateString(item.UserAccountOrganisation.UserAccount.LastLogin) : null,
                formattedLatestBankAccountCheckOn: item.LatestBankAccountCheck ? dateString(item.LatestBankAccountCheck.CheckedOn) : null,
                srcFundsBankAccounts: _.toArray(item.SmsSrcFundsBankAccounts)
            });
        });
        var templateData = {
            accordionId: accordionId,
            isEmpty: items.length === 0,
            items: items,
            pageNumber: txGrid.grid.dataSource.page()
        };

        relatedPartiesTemplatePromise.done(function (template) {
            var html = template(templateData);
            $('#' + targetElementId).html(html);
        });        
    })
    .error(function (data) {
        console.log(data);
    })
    .always(function () {
        $('#' + spinnerId).hide();
    });
}