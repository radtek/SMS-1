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
        change: txChange,
        searchElementId: 'gridSearchInput',
        searchButtonId: 'gridSearchButton',
        columns: [
            {
                field: "SmsTransactionID",
                hidden: true,
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
                title: "Created",
                template: function (dataItem) { return dateString(dataItem.SmsTransaction.CreatedOn); }
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

});

//data binding for the panes beneath each grid
function txChange(dataItem) {
    $("#addAdditionalBuyerButton").data('href', $("#addAdditionalBuyerButton").data("url") + "?txID=" + dataItem.SmsTransactionID);
    $("#addGiftorButton").data('href', $("#addGiftorButton").data("url") + "?txID=" + dataItem.SmsTransactionID);

    $("#editButton").data('href', $("#editButton").data("url") + "?txID=" + dataItem.SmsTransactionID + "&uaoID=" + dataItem.UserAccountOrganisationID);
    $("#resendButton").data('href', $("#resendButton").data("url") + "?txID=" + dataItem.SmsTransactionID + "&label=" +
        encodeURIComponent(
        (dataItem.Contact.Salutation || "") + " " +
        (dataItem.Contact.FirstName || "") + " " +
        (dataItem.Contact.LastName || "")));
    $("#resendButton").attr("disabled", !dataItem.UserAccountOrganisation.UserAccount.IsTemporaryAccount);

    showTransactionDetails(dataItem);
    showPrimaryBuyerDetails(dataItem);
    showTransactionRelatedParties(dataItem, $('#additionalBuyers').data("url"), 'additionalBuyers', 'additionalBuyersAccordion', 'spinnerAdditionalBuyers');
    showTransactionRelatedParties(dataItem, $('#giftors').data("url"), 'giftors', 'giftorsAccordion', 'spinnerGiftors');
}

function showTransactionDetails(dataItem) {
    var data = _.extend({}, dataItem, {
        purchasePrice: formatCurrency(dataItem.SmsTransaction.Price)
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
        formattedBirthDate: moment(contact.BirthDate).format('DD/MM/YYYY')
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
                formattedBirthDate: moment(contact.BirthDate).format('DD/MM/YYYY')
            });
        });
        var templateData = {
            accordionId: accordionId,
            isEmpty: items.length === 0,
            items: items
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