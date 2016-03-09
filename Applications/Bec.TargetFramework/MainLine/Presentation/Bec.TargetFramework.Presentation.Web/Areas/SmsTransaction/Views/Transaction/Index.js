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
                hidden: true,
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
            },
            {
                field: "",
                title: "Decision",
                template: function (dataItem) {
                    if (dataItem.SmsTransaction.Invoice) {
                        return 'Purchased';
                    } else if (dataItem.SmsTransaction.ProductDeclinedOn) {
                        return 'Declined';
                    } else {
                        return '';
                    }
                }
            },
            {
                field: "",
                title: "Safe Buyer No Matches",
                template: function (dataItem) {
                    var noMatchResultsCount = _.sum(
                        _.map(dataItem.SmsTransaction.SmsUserAccountOrganisationTransactions, function (item) {
                            var noMatchesPerPersona = _.filter(item.SmsBankAccountChecks, { IsMatch: false });
                            return noMatchesPerPersona.length;
                        }));
                    if (noMatchResultsCount > 0) {
                        return '<b class="badge bg-color-red">' + noMatchResultsCount + '</b>';
                    } else {
                        return '';
                    }
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

    function formatDates() {
        $('.format-date').each(function () {
            $(this).text(dateStringNoTime($(this).data("val")));
        });
        $('.format-date-time').each(function () {
            $(this).text(dateString($(this).data("val")));
        });
        $('.format-pending-date').each(function () {
            var originalText = $(this).text();
            $(this).text(dateStringNoTime(originalText));
        });
    }
});
