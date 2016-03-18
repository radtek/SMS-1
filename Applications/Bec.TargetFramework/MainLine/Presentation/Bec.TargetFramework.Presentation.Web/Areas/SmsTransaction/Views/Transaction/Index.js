$(function () {
    'use strict';

    var transactionDetailsTemplatePromise = $.Deferred(),
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
        defaultSort: { field: "SmsTransaction.CreatedOn", dir: "desc" },
        resetSort: $('#txGrid').data("resetsort"),
        panels: ['rPanel'],
        jumpToId: $('#txGrid').data("jumpto"),
        jumpToPage: $('#txGrid').data("jumptopage"),
        jumpToRow: $('#txGrid').data("jumptorow"),
        change: txChange,
        searchElementId: 'gridSearchInput',
        searchButtonId: 'gridSearchButton',
        clearSearchButtonId: 'clearGridSearch',
        extraFilters: [
            { selector: '#decisionFilter', parameter: 'decisionFilter' },
            { selector: '#noMatchFilter', parameter: 'noMatchFilter' }
        ],
        columns: [
            {
                field: "SmsTransactionID",
                hidden: true
            },
            {
                field: "UserAccountOrganisation.UserAccount.Email",
                title: "Primary Buyer's Email"
            },
            {
                field: "Contact.LastName",
                title: "Last Name"
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
                field: "SmsTransaction.UserAccountOrganisation.Contact.LastName",
                title: "Created By",
                template: function (dataItem) { return dataItem.SmsTransaction.UserAccountOrganisation.Contact.FirstName + " " + dataItem.SmsTransaction.UserAccountOrganisation.Contact.LastName; }
            },
            {
                field: "SmsTransaction.ProductAdvisedOn",
                title: "Product Advised On",
                template: function (dataItem) { return dataItem.SmsTransaction.ProductAdvisedOn ? dateString(dataItem.SmsTransaction.ProductAdvisedOn) : ""; }
            },
            {
                field: "",
                title: "Required Actions",
                width: 120,
                template: function (dataItem) {
                    var notActionedPartiesCount = _.filter(dataItem.SmsTransaction.SmsUserAccountOrganisationTransactions, function (uaot){
                        return !uaot.ProductAcceptedOn && !uaot.ProductDeclinedOn;
                    }).length;
                    var noMatchResultsCount = _.sum(
                        _.map(dataItem.SmsTransaction.SmsUserAccountOrganisationTransactions, function (item) {
                            var noMatchesPerPersona = _.filter(item.SmsBankAccountChecks, { IsMatch: false });
                            return noMatchesPerPersona.length;
                        }));

                    var resultText = '';
                    var emptyBox = '<span class="transaction-issues">&nbsp;</span>';
                    if (notActionedPartiesCount > 0) {
                        resultText += '<span class="transaction-issues"><b class="badge" title="Outstanding Decisions">' + notActionedPartiesCount + '</b></span>';
                    } else {
                        resultText += emptyBox;
                    }
                    if (noMatchResultsCount > 0) {
                        resultText += '<span class="transaction-issues"><b class="badge bg-color-red" title="Safe Buyer No Matches">' + noMatchResultsCount + '</b></span>';
                    } else {
                        resultText += emptyBox;
                    }
                    if (dataItem.PendingUpdateCount > 0) {
                        resultText += '<span class="transaction-issues"><b class="badge bg-color-pending-update" title="Pending Changes">' + dataItem.PendingUpdateCount + '</b></span>';
                    } 
                    return resultText;
                }
            }
        ]
    });

    txGrid.makeGrid();
    findModalLinks();
    setupTabs();

    setupTemplatePromise(bankAccountChecksDetailsPromise, getRazorViewPath('_bankAccountChecksDetailsTmpl', 'Shared/Templates', ''));

    if ($('#content').data("welcome") == "True") {
        handleModal({ url: $('#content').data("welcomeurl") }, null, true);
    }

    function setupTabs() {
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
        $("#createConversationButton").data('href', $("#createConversationButton").data("url") + "&activityId=" + dataItem.SmsTransactionID + "&pageNumber=" + txGrid.grid.dataSource.page());

        showTransactionDetails(dataItem);
        showBankAccountChecksDetails(dataItem);

        $('#transactionConversationContainer')
            .data('activity-id', dataItem.SmsTransactionID)
            .trigger('activitychange', [dataItem.SmsTransactionID, true]);
        areConversationsLoaded = false;

        $('#quoteButton').data('href', $('#quoteButton').data("url") + "?txID=" + dataItem.SmsTransactionID);
    }

    function showTransactionDetails(dataItem) {
        var transactionDetailsContainer = $('#transactionDetails');
        var spinner = $('#spinnerTransactionDetails');

        spinner.show();
        ajaxWrapper({
            url: transactionDetailsContainer.data('url') + '?txID=' + dataItem.SmsTransactionID,
            type: 'GET',
            data: {
                txID: dataItem.SmsTransactionID,
                pageNumber: txGrid.grid.dataSource.page()
            }
        }).success(function (data) {
            transactionDetailsContainer.html(data);
            formatDates();
            transactionDetailsContainer.fieldPendingUpdates();
        }).fail(function (e) {
            if (!hasRedirect(e.responseJSON)) {
                showtoastrError();
            }
        }).always(function () {
            spinner.hide();
        });
    }

    function showBankAccountChecksDetails(dataItem) {
        var mappedData = _.map(dataItem.SmsTransaction.SmsUserAccountOrganisationTransactions, function (item) {
            var mappedBankAccountChecks = _.map(item.SmsBankAccountChecks, function (bankAccountCheck) {
                bankAccountCheck.CheckedOn = dateString(bankAccountCheck.CheckedOn);
                return bankAccountCheck;
            });
            var orderedBankAccountChecks = _.orderBy(mappedBankAccountChecks, ['CheckedOn'], ['desc']);
            item.SmsBankAccountChecks = _.toArray(orderedBankAccountChecks);
            item.SmsSrcFundsBankAccounts = _.toArray(item.SmsSrcFundsBankAccounts);
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
