var transactionDetailsTemplatePromise,
    partiesTemplatePromise,
    txGrid;
var areConversationsLoaded;
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
            },
            {
                field: "",
                title: "Safe Buyer No Matches",
                template: function (dataItem) {
                    var noMatchResultsCount = _.sum(
                        _.map(dataItem.SmsUserAccountOrganisationTransactions, function (item) {
                            var noMatchesPerPersona = _.filter(item.SmsBankAccountChecks, { IsMatch: false });
                            return noMatchesPerPersona.length;
                        }));
                    return noMatchResultsCount || "";
                }
            }
        ]
    });

    txGrid.makeGrid();
    findModalLinks();
    setupTabs();

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

    function setupTabs() {
        areConversationsLoaded = false;
        $('#rPanel li a').click(function (e) {
            e.stopPropagation();
            if (history.pushState) {
                history.pushState(null, null, $(this).attr('href'));
            }
            $(this).tab('show');

            if ($(this).attr('id') == 'safeSendTab' && !areConversationsLoaded) {
                $('#transactionConversationContainer').trigger('loadConversations');
                areConversationsLoaded = true;
            }
            return false;
        });
    }
});

//data binding for the panes beneath each grid
function txChange(dataItem) {
    showTransactionDetails(dataItem);
    showPartiesDetails(dataItem);

    $("#createConversationButton").data('href', $("#createConversationButton").data("url") + "&activityId=" + dataItem.SmsTransactionID + "&pageNumber=" + txGrid.grid.dataSource.page());
    $('#transactionConversationContainer')
        .data('activity-id', dataItem.SmsTransactionID)
        .trigger('activitychange', [dataItem.SmsTransactionID, dataItem.Invoice != null]);
    areConversationsLoaded = false;
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
    var orderedParties = _.orderBy(dataItem.SmsUserAccountOrganisationTransactions, ['SmsUserAccountOrganisationTransactionType.SmsUserAccountOrganisationTransactionTypeID'], ['asc']);
    var data = _.map(orderedParties, function (uaot) {
        return _.extend({}, uaot, {
            fullName: uaot.Contact.Salutation + " " + uaot.Contact.FirstName + " " + uaot.Contact.LastName,
            formattedBirthDate: dateStringNoTime(uaot.Contact.BirthDate),
            formattedLatestBankAccountCheckOn: uaot.LatestBankAccountCheck ? dateString(uaot.LatestBankAccountCheck.CheckedOn) : null,
            latestCheckResult: uaot.LatestBankAccountCheck == null ? null : (uaot.LatestBankAccountCheck.IsMatch ? "Match" : "No Match"),
            matchClass: uaot.LatestBankAccountCheck == null ? null : (uaot.LatestBankAccountCheck.IsMatch ? "match" : "error")
        });
    });

    partiesTemplatePromise.done(function (template) {
        var html = template(data);
        $('#partiesDetails').html(html);
    });
}