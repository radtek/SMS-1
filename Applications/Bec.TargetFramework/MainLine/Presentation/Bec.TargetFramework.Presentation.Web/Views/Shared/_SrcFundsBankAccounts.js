$(function () {
    'use strict';

    var srcFundsElement = $('#srcFundsBankAccounts');

    var index = srcFundsElement.data('index');
    var srcFundBankAccountTemplatePromise = $.Deferred();
    var addNextBankAccountBtn = srcFundsElement.find('.add-next-bank-account-btn');
    var addNextBankAccountRow = srcFundsElement.find('.add-next-bank-account-row');
    ajaxWrapper({
        url: srcFundsElement.data("templateurl") + '?view=' + getRazorViewPath('_srcFundsBankAccountTmpl', 'Shared/Templates', '')
    }).done(function (res) {
        srcFundBankAccountTemplatePromise.resolve(Handlebars.compile(res));
    }).fail(function (e) {
        if (!hasRedirect(e.responseJSON)) {
            showtoastrError();
        }
    });

    addNextBankAccountBtn.click(function (event) {
        console.log(index);
        var getLastBankAccount = function () {
            return {
                accountNumber: $('input[name="SmsSrcFundsBankAccounts[' + (index - 1) + '].AccountNumber'),
                sortCode: $('input[name="SmsSrcFundsBankAccounts[' + (index - 1) + '].SortCode')
            };
        };

        var lastBankAccount = getLastBankAccount();
        console.log(lastBankAccount);
        if (lastBankAccount.accountNumber.val() && lastBankAccount.sortCode.val()) {
            var templateData = {
                index: index++
            };
            srcFundBankAccountTemplatePromise.done(function (template) {
                var html = template(templateData);
                addNextBankAccountRow.before(html);

                var newBankAccount = getLastBankAccount();
                newBankAccount.accountNumber.focus();
            });
        }

        event.preventDefault();
        return false;
    });

    $('body').on('click', '.delete-src-of-funds-entry', function (event) {
        var parentRowId = $(this).data('parent-id');
        var parentToRemove = $('#' + parentRowId);
        parentToRemove
            .addClass('red-bg')
            .fadeOut(500, function () {
                parentToRemove.remove();
                renumberInputs('input[name$="AccountNumber"]', 'SmsSrcFundsBankAccounts');
                renumberInputs('input[name$="SortCode"]', 'SmsSrcFundsBankAccounts');
                reindexElementAttr('[id^="bankAccountRow-"]', 'bankAccountRow-', 'id');
                reindexElementAttr('[data-parent-id^="bankAccountRow-"', 'bankAccountRow-', 'data-parent-id');
                index--;
            });
        event.preventDefault();
        return false;
    });

    function renumberInputs(inputsSelector, prefix) {
        $(inputsSelector).each(function (index) {
            var prefixWithIndex = prefix + "[" + index + "]";
            var regExp = new RegExp(prefix + '\\[\\d+\\]');
            this.name = this.name.replace(regExp, prefixWithIndex);
        });
    }

    function reindexElementAttr(selector, prefix, attrName) {
        $(selector).each(function (index) {
            var prefixWithIndex = prefix + index;
            var regExp = new RegExp(prefix + '\\d+');
            var newValue = $(this).attr(attrName).replace(regExp, prefixWithIndex);
            $(this).attr(attrName, newValue);
        });
    }
});