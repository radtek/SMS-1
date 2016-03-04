$(function () {
    'use strict';

    var transactionDetailsTemplatePromise = $.Deferred(),
        primaryBuyerTemplatePromise = $.Deferred(),
        relatedPartiesTemplatePromise = $.Deferred(),
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

    setupTemplatePromise(transactionDetailsTemplatePromise, getRazorViewPath('_transactionDetailsTmpl', 'Transaction', 'SmsTransaction'));
    setupTemplatePromise(primaryBuyerTemplatePromise, getRazorViewPath('_primaryBuyerDetailsTmpl', 'Transaction', 'SmsTransaction'));
    setupTemplatePromise(relatedPartiesTemplatePromise, getRazorViewPath('_relatedPartiesTmpl', 'Transaction', 'SmsTransaction'));
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
        $("#addAdditionalBuyerButton").data('href', $("#addAdditionalBuyerButton").data("url") + "&txID=" + dataItem.SmsTransactionID + "&pageNumber=" + txGrid.grid.dataSource.page());
        $("#addGiftorButton").data('href', $("#addGiftorButton").data("url") + "&txID=" + dataItem.SmsTransactionID + "&pageNumber=" + txGrid.grid.dataSource.page());

        $("#editButton").data('href', $("#editButton").data("url") + "?txID=" + dataItem.SmsTransactionID + "&uaoID=" + dataItem.UserAccountOrganisationID + "&pageNumber=" + txGrid.grid.dataSource.page());

        $("#pinButton").data('href', $("#pinButton").data("url") + "?txID=" + dataItem.SmsTransactionID + "&uaoID=" + dataItem.UserAccountOrganisationID + "&email=" + dataItem.UserAccountOrganisation.UserAccount.Email + "&pageNumber=" + txGrid.grid.dataSource.page());
        $("#pinButton").attr("disabled", !dataItem.UserAccountOrganisation.UserAccount.IsTemporaryAccount);

        $("#createConversationButton").data('href', $("#createConversationButton").data("url") + "&activityId=" + dataItem.SmsTransactionID + "&pageNumber=" + txGrid.grid.dataSource.page());

        showTransactionDetails(dataItem);
        showPrimaryBuyerDetails(dataItem);
        showTransactionRelatedParties(dataItem, $('#additionalBuyers').data("url"), 'additionalBuyers', 'additionalBuyersAccordion', 'spinnerAdditionalBuyers');
        showTransactionRelatedParties(dataItem, $('#giftors').data("url"), 'giftors', 'giftorsAccordion', 'spinnerGiftors');
        showBankAccountChecksDetails(dataItem);

        $('#transactionConversationContainer')
            .data('activity-id', dataItem.SmsTransactionID)
            .trigger('activitychange', [dataItem.SmsTransactionID, true]);
        areConversationsLoaded = false;

        $('#quoteButton').data('href', $('#quoteButton').data("url") + "?txID=" + dataItem.SmsTransactionID);
    }

    function showTransactionDetails(dataItem) {
        var orderedByContact = dataItem.SmsTransaction.Invoice
            ? dataItem.SmsTransaction.Invoice.UserAccountOrganisation.Contact
            : null;
        var data = _.extend({}, dataItem, {
            purchasePrice: formatCurrency(dataItem.SmsTransaction.Price),
            pageNumber: txGrid.grid.dataSource.page(),
            transactionCreated: dateString(dataItem.SmsTransaction.CreatedOn),
            productAdvisedOn: dataItem.SmsTransaction.ProductAdvisedOn
                ? dateString(dataItem.SmsTransaction.ProductAdvisedOn)
                : null,
            safeBuyerOrderedBy: orderedByContact
                ? orderedByContact.Salutation + " " + orderedByContact.FirstName + " " + orderedByContact.LastName
                : null,
            safeBuyerOrderedOn: dataItem.SmsTransaction.Invoice
                ? dateString(dataItem.SmsTransaction.Invoice.CreatedOn)
                : null
        });
        transactionDetailsTemplatePromise.done(function (template) {
            var html = template(data);
            $('#transactionDetails').html(html);

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

            var table = $('#transaction-details');
            magicEdit({
                url: table.data('edit-url'),
                activityType: table.data('activity-type'),
                activityId: table.data('activity-id'),
                updateUrl: table.data('update-url'),
                approveUrl: table.data('approve-url'),
                rejectUrl: table.data('reject-url')
            });
        });
    }

    function showPrimaryBuyerDetails(dataItem) {
        var contact = dataItem.Contact;
        var data = _.extend({}, dataItem, {
            fullName: contact.Salutation + " " + contact.FirstName + " " + contact.LastName,
            formattedBirthDate: dateStringNoTime(contact.BirthDate),
            formattedLastLogin: dataItem.UserAccountOrganisation.UserAccount.LastLogin ? dateString(dataItem.UserAccountOrganisation.UserAccount.LastLogin) : null,
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
        }).success(function (data) {
            var items = data.Items;
            items = _.map(items, function (item) {
                var contact = item.Contact;
                return _.extend({}, item, {
                    fullName: contact.Salutation + " " + contact.FirstName + " " + contact.LastName,
                    elementId: 'id' + item.SmsUserAccountOrganisationTransactionID,
                    transactionId: item.SmsTransactionID,
                    formattedBirthDate: dateStringNoTime(contact.BirthDate),
                    formattedLastLogin: item.UserAccountOrganisation.UserAccount.LastLogin ? dateString(item.UserAccountOrganisation.UserAccount.LastLogin) : null,
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
        }).fail(function (e) {
            if (!hasRedirect(e.responseJSON)) {
                showtoastrError();
            }
        }).always(function () {
            $('#' + spinnerId).hide();
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
