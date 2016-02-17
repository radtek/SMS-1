
$(function () {
    var transactionDetailsTemplatePromise = $.Deferred(),
        partiesTemplatePromise = $.Deferred(),
        bankAccountChecksDetailsPromise = $.Deferred();
    var areConversationsLoaded = false;

    var txGrid = new gridItem(
    {
        gridElementId: 'txGrid',
        url: $('#txGrid').data("url"),
        schema: { data: "Items", total: "Count", model: { id: "SmsTransactionID" } },
        type: 'odata-v4',
        serverSorting: true,
        serverPaging: true,
        defaultSort: { field: "ProductAdvisedOn", dir: "desc" },
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
                field: "",
                title: "Conveyancer",
                template: function (dataItem) { return dataItem.Organisation.OrganisationDetails[0].Name; }
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

    setupTemplatePromise(transactionDetailsTemplatePromise, getRazorViewPath('_transactionDetailsTmpl', 'Transaction', 'Lender'));
    setupTemplatePromise(partiesTemplatePromise, getRazorViewPath('_partiesDetailsTmpl', 'Transaction', 'Lender'));
    setupTemplatePromise(bankAccountChecksDetailsPromise, getRazorViewPath('_bankAccountChecksDetailsTmpl', 'Shared', ''));

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

    function setupTemplatePromise(templatePromise, viewPath) {
        ajaxWrapper(
            { url: $('#content').data("templateurl") + '?view=' + viewPath }
        ).done(function (res) {
            templatePromise.resolve(Handlebars.compile(res));
        }).fail(function (e) {
            if (!hasRedirect(e.responseJSON)) {
                showtoastrError();
            }
        });
    }

    //data binding for the panes beneath each grid
    function txChange(dataItem) {
        showTransactionDetails(dataItem);
        showPartiesDetails(dataItem);
        showBankAccountChecksDetails(dataItem);

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

    function showBankAccountChecksDetails(dataItem) {
        var mappedData = _.map(dataItem.SmsUserAccountOrganisationTransactions, function (item) {
            var mappedBankAccountChecks = _.map(item.SmsBankAccountChecks, function (bankAccountCheck) {
                bankAccountCheck.CheckedOn = dateString(bankAccountCheck.CheckedOn);
                return bankAccountCheck;
            });
            var orderedBankAccountChecks = _.orderBy(mappedBankAccountChecks, ['CheckedOn'], ['desc']);
            item.SmsBankAccountChecks = _.toArray(orderedBankAccountChecks);
            return item;
        });
        var orderedData = _.orderBy(mappedData, ['SmsUserAccountOrganisationTransactionTypeID'], ['asc']);
        var data = _.toArray(orderedData);
        bankAccountChecksDetailsPromise.done(function (template) {
            var html = template(data);
            $('#bankAccountChecksDetails').html(html);
        });
    }
});
