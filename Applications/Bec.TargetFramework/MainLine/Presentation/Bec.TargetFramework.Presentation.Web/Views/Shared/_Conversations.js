$(function () {
    loadConversations();
    setupWindowToggling();


    function loadConversations() {
        var conversationsTemplatePromise = $.Deferred();
        ajaxWrapper(
            { url: $('#viewMessagesContainer').data("templateurl") + '?view=_conversationsTmpl' }
        ).done(function (res) {
            conversationsTemplatePromise.resolve(Handlebars.compile(res));
        });

        ajaxWrapper({
            url: $('#conversationsContainer').data("conversations-url"),
            type: 'GET'
        })
        .success(function (data) {
            console.log(data);
            var items = data.Items;
            //items = _.map(items, function (item) {
            //    var contact = item.Contact;
            //    return _.extend({}, item, {
            //        fullName: contact.Salutation + " " + contact.FirstName + " " + contact.LastName,
            //        elementId: 'id' + item.SmsUserAccountOrganisationTransactionID,
            //        transactionId: item.SmsTransactionID,
            //        formattedBirthDate: dateStringNoTime(contact.BirthDate),
            //        formattedLastLogin: item.UserAccountOrganisation.UserAccount.LastLogin ? dateString(item.UserAccountOrganisation.UserAccount.LastLogin) : null,
            //        formattedLatestBankAccountCheckOn: item.LatestBankAccountCheck ? dateString(item.LatestBankAccountCheck.CheckedOn) : null,
            //        srcFundsBankAccounts: _.toArray(item.SmsSrcFundsBankAccounts)
            //    });
            //});
            var templateData = {
                isEmpty: items.length === 0,
                items: items
            };

            conversationsTemplatePromise.done(function (template) {
                var html = template(templateData);
                $('#conversationsList').html(html);
            });
        })
        .error(function (data) {
            console.log(data);
        })
        .always(function () {
            //$('#' + spinnerId).hide();
        });
    }

    function setupWindowToggling() {
        $('.discussion-item').click(function () {

            if (!isMessageBoxOpen()) {
                $('#messagesContainer').toggleClass('col-lg-offset-0 col-lg-offset-6');
                if (isCompactView()) {
                    $('#discussionsContainer').toggleClass('col-xs-12 col-lg-6 col-xs-0');
                    $('#messagesContainer').toggleClass('col-xs-0 col-xs-12');
                } else {
                    $('#discussionsContainer').toggleClass('col-lg-6 col-xs-4');
                    $('#messagesContainer').toggleClass('col-xs-0 col-xs-8');
                }
            }
        });

        $('#discussionSubject').click(function () {
            if (isCompactView()) {
                $('#messagesContainer').toggleClass('col-lg-offset-0 col-lg-offset-6');
                $('#discussionsContainer').toggleClass('col-xs-12 col-lg-6 col-xs-0');
                $('#messagesContainer').toggleClass('col-xs-0 col-xs-12');
            }
        });

        $(window).on('resize', function () {

            if (isMessageBoxOpen()) {
                if (isCompactView()) {

                    if ($('#messagesContainer').hasClass('col-xs-8')) {
                        $('#messagesContainer').toggleClass('col-xs-12 col-xs-8');
                    }

                    if ($('#discussionsContainer').hasClass('col-xs-12')) {
                        $('#discussionsContainer').toggleClass('col-xs-12 col-lg-4 col-xs-0');
                    }

                } else {
                    if ($('#messagesContainer').hasClass('col-xs-12')) {
                        $('#messagesContainer').toggleClass('col-xs-12 col-xs-8');
                    }

                    if ($('#discussionsContainer').hasClass('col-xs-0')) {
                        $('#discussionsContainer').toggleClass('col-xs-12 col-lg-4 col-xs-0');
                    }
                }
            }
        });
    }

    function isCompactView() {
        return $('#discussionSubject i').is(':visible');
    }

    function isMessageBoxOpen() {
        return !$('#messagesContainer').hasClass('col-xs-0');
    }
});
