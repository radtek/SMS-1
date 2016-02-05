var transactionDetailsTemplatePromise,
    partiesTemplatePromise,
    txGrid;
$(function () {
    txGrid = new gridItem(
    {
        gridElementId: 'txGrid',
        url: $('#txGrid').data("url"),
        schema: { data: "Items", total: "Count", model: { id: "SmsTransactionID" } },
        type: 'odata-v4',
        serverSorting: true,
        serverPaging: true,
        defaultSort: { field: "CreatedOn", dir: "desc" },
        //resetSort: $('#txGrid').data("resetsort"),
        panels: ['rPanel'],
        //jumpToId: $('#txGrid').data("jumpto"),
        //jumpToPage: $('#txGrid').data("jumptopage"),
        //jumpToRow: $('#txGrid').data("jumptorow"),
        change: txChange,
        //searchElementId: 'gridSearchInput',
        //searchButtonId: 'gridSearchButton',
        columns: [
            {
                field: "SmsTransactionID",
                hidden: true,
            },
            {
                field: "Address.Line1",
                title: "Address Line 1"
            },
            {
                field: "Address.PostalCode",
                title: "Postcode"
            },
            {
                field: "Price",
                title: "Price",
                template: function (dataItem) { return formatCurrency(dataItem.Price); }
            },
            {
                field: "MortgageApplicationNumber",
                title: "App. Number"
            },
            {
                field: "ProductAdvisedOn",
                title: "Advised On",
                template: function (dataItem) { return dateString(dataItem.ProductAdvisedOn); }
            },
            {
                field: "ProductDeclinedOn",
                title: "Declined On",
                template: function (dataItem) { return dateString(dataItem.ProductDeclinedOn); }
            },
            {
                field: "Invoice.CreatedOn",
                title: "Purchased On",
                template: function (dataItem) { return dataItem.Invoice ? dateString(dataItem.Invoice.CreatedOn) : ""; }
            },
            {
                field: "CreatedOn",
                title: "Created On",
                template: function (dataItem) { return dateString(dataItem.CreatedOn); }
            },
            {
                field: "CreatedBy",
                title: "Created By"
            }
        ]
    });

    txGrid.makeGrid();
    findModalLinks();

    transactionDetailsTemplatePromise = $.Deferred();
    ajaxWrapper(
        { url: $('#content').data("templateurl") + '?view=' + getRazorViewPath('_transactionDetailsTmpl', 'Transaction', 'Lender') }
    ).done(function (res) {
        transactionDetailsTemplatePromise.resolve(Handlebars.compile(res));
    }).fail(function (e) {
        if (!hasRedirect(e.responseJSON)) {
            showtoastrError();
        }
    });

    partiesTemplatePromise = $.Deferred();
    ajaxWrapper(
        { url: $('#content').data("templateurl") + '?view=' + getRazorViewPath('_partiesDetailsTmpl', 'Transaction', 'Lender') }
    ).done(function (res) {
        partiesTemplatePromise.resolve(Handlebars.compile(res));
    }).fail(function (e) {
        if (!hasRedirect(e.responseJSON)) {
            showtoastrError();
        }
    });

});

//data binding for the panes beneath each grid
function txChange(dataItem) {
    showTransactionDetails(dataItem);
    showPartiesDetails(dataItem);
}

function showTransactionDetails(dataItem) {
    var orderedByContact = dataItem.Invoice
        ? dataItem.Invoice.UserAccountOrganisation.Contact
        : null;
    var data = _.extend({}, dataItem, {
        purchasePrice: formatCurrency(dataItem.Price),
        pageNumber: txGrid.grid.dataSource.page(),
        transactionCreated: dateString(dataItem.CreatedOn),
        productAdvisedOn: dataItem.ProductAdvisedOn
            ? dateString(dataItem.ProductAdvisedOn)
            : null,
        safeBuyerOrderedBy: orderedByContact
            ? orderedByContact.Salutation + " " + orderedByContact.FirstName + " " + orderedByContact.LastName
            : null,
        safeBuyerOrderedOn: dataItem.Invoice
            ? dateString(dataItem.Invoice.CreatedOn)
            : null
    });
    transactionDetailsTemplatePromise.done(function (template) {
        var html = template(data);
        $('#transactionDetails').html(html);
    });
}

function showPartiesDetails(dataItem) {
    var data = _.map(dataItem.SmsUserAccountOrganisationTransactions, function (uaot) {
        return _.extend({}, uaot, {
            fullName: uaot.Contact.Salutation + " " + uaot.Contact.FirstName + " " + uaot.Contact.LastName,
            formattedBirthDate: dateStringNoTime(uaot.Contact.BirthDate),
            formattedLatestBankAccountCheckOn: uaot.Contact.LatestBankAccountCheck ? dateString(uaot.Contact.LatestBankAccountCheck.CheckedOn) : null
        });
    });

    partiesTemplatePromise.done(function (template) {
        var html = template(data);
        $('#partiesDetails').html(html);
    });
}