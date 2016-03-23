$(function () {
    'use strict';

    var viewMessagesContainer = $('#viewMessagesContainer'),
        conversationsContainer = $('#conversationsContainer'),
        converationsList = $('#conversationsList'),
        conversationsSpinner = $('#conversationsSpinner'),
        conversationsError = $('#conversationsError'),
        messagesContainer = $('#messagesContainer'),
        messagesList = $('#messagesList'),
        disabledContainer = $('#disabledContainer'),
        getMessagesSpinner = function () { return $('#messagesSpinner'); },
        getNewConversationError = function () { return $('#newConversationError'); },
        createConversationButton = $('#createConversationButton'),
        targetConversationId = viewMessagesContainer.data('target-conversation-id'),
        attachmentsID = guid(),
        fbUploading = false;

    var currentConversation = {
        id: null,
        subject: null
    };
    var currentActivity = {
        activityType: viewMessagesContainer.data('activity-type'),
        activityId: viewMessagesContainer.data('activity-id'),
        enabled: viewMessagesContainer.data('enabled')
    };
    var urls = {
        templateUrl: viewMessagesContainer.data("templateurl"),
        conversationUrl: viewMessagesContainer.data("conversations-url"),
        messagesUrl: viewMessagesContainer.data("messages-url"),
        recipientsUrl: viewMessagesContainer.data("recipients-url"),
        convRankUrl: viewMessagesContainer.data("convrank-url"),
        participantsUrl: viewMessagesContainer.data("participants-url"),
        uploadUrl: viewMessagesContainer.data("upload-url"),
        removeUploadUrl: viewMessagesContainer.data("remove-upload-url"),
        safesendgroupsUrl: viewMessagesContainer.data("safesendgroups-url")
    };

    var conversationsTemplatePromise = getTemplatePromise('_conversationsTmpl');
    var emptyMessageTemplatePromise = getTemplatePromise('_emptyMessagesTmpl');
    var itemTemplatePromise = getTemplatePromise('_itemTmpl');
    var messagesTemplatePromise = getTemplatePromise('_messagesTmpl');
    var createConversationTemplatePromise = getTemplatePromise('_createConversationTmpl');

    var getRecipientsPromise = $.Deferred();
    var getSafeSendGroupsPromise = ajaxWrapper({
        url: urls.safesendgroupsUrl
    }).fail(function (e) {
        if (!hasRedirect(e.responseJSON)) {
            showtoastrError();
        }
    });

    var dataSource = new kendo.data.DataSource({
        type: "odata-v4",
        transport: {
            read: function (options) {
                var d = kendo.data.transports['odata-v4'].parameterMap(options.data);
                delete d['$inlinecount'];
                d['$count'] = true;

                _.extend(d, {
                    activityId: currentActivity.activityId,
                    activityType: currentActivity.activityType
                });

                var ajaxOptions = {
                    url: urls.conversationUrl,
                    data: d
                };
                ajaxWrapper(ajaxOptions)
                    .then(function (result) {
                        options.success(result);
                    }, function (data) {
                        options.error(data);
                    });
            }
        },
        serverSorting: false,
        serverPaging: true,
        pageSize: 10,
        change: selectCurrentOrLatestConversation,
        schema: { data: "Items", total: "Count" }
    });

    if (!isActivitySpecificView() && canLoadConversations()) {
        loadConversations();
    }

    var pager = $('#conversationsPager').kendoPager({
        dataSource: dataSource,
        refresh: true
    }).data('kendoPager');

    var messagesPageSize = 10;
    var messagesPage = 0;
    var allLoaded = false;
    var jumpedPage = false;

    setupDataReload();
    setupWindowToggling();
    setupReply();
    setupCreateConversation();

    function resetCurrentConversation() {
        for (var p in currentConversation) {
            if (currentConversation.hasOwnProperty(p)) {
                currentConversation[p] = null;
            }
        }
    }

    function canCreateNewConversation() {
        return !!currentActivity.activityId;
    }

    function canLoadConversations() {
        return viewMessagesContainer.is(':visible');
    }

    function isActivitySpecificView() {
        return viewMessagesContainer.data("is-activity-specific");
    }

    function loadConversations() {
        
        if (!currentActivity.enabled) {
            $('#conversationsContainer').hide();
            $('#messagesContainer').hide();
            $('#disabledContainer').show();
        }
        else {
            $('#conversationsContainer').show();
            $('#messagesContainer').show();
            $('#disabledContainer').hide();
            conversationsSpinner.show();
            conversationsError.hide();
            dataSource.read();
            if (canCreateNewConversation()) {
                getRecipientsPromise = getRecipients();
            }
        }
    }

    function loadMessages() {
        allLoaded = false;
        messagesPage = 0;
        return loadItems();
    }

    function loadItems() {
        var ret = $.Deferred();
        if (allLoaded) return ret.resolve([]);

        ajaxWrapper({
            url: urls.messagesUrl,
            type: 'GET',
            data: {
                conversationId: currentConversation.id,
                page: messagesPage,
                pageSize: messagesPageSize
            }
        })
        .success(function (items) {
            if (items.length < messagesPageSize) allLoaded = true;
            messagesPage = messagesPage + 1;
            $.each(items, function (i, item) {

                item.Content = JSON.parse(item.Message.NotificationData);

                switch (item.Message.NotificationConstructName) {
                    case 'Message': item.isMessage = true; break;
                    case 'BankAccountMarkedAsSafe': item.isBaSafe = true; break;
                    case 'BankAccountMarkedAsFraudSuspicious': item.isBaFraud = true; break;
                    case 'BankAccountCheckNoMatch': item.isBaNoMatch = true; break;
                    case 'BankAccountMarkedAsPotentialFraud': item.isBaPotFraud = true; break;
                    case 'ProductAdvised': item.isProductAdvised = true; break;
                }

                switch (item.Message.OrganisationType) {
                    case 'Personal':
                        switch (item.Message.UserType) {
                            case "Giftor": item.icon = 'fa-gift'; break;
                            default: item.icon = 'fa-home'; break;
                        }
                        item.isFromProfessionalUser = false;
                        break;
                    case "Professional":
                        item.icon = 'fa-building';
                        item.isFromProfessionalUser = true;
                        break;
                    case "Lender":
                        item.icon = 'fa-bank';
                        item.isFromProfessionalUser = true;
                        break;
                    default:
                        item.icon = 'fa-comment-o';
                        item.Message.FirstName = "Safe Move Scheme";
                        item.Message.UserType = "Safe Move Scheme"
                        break;
                }
                item.Message.DateSent = dateString(item.Message.DateSent);
                item.Unread = item.Reads.length == 0;


                $.each(item.Reads, function (j, r) {
                    if (r.AcceptedDate) r.AcceptedDate = dateString(r.AcceptedDate);
                });
            });
            ret.resolve(items);
        }).fail(function (e) {
            if (!hasRedirect(e.responseJSON)) {
                showtoastrError();
            }
        });
        return ret;
    }

    function populateContainer(itemsContainer, items) {
        itemsContainer.css('overflow-y', 'hidden'); //force user to start their scroll again if dragging thumb
        setTimeout(function () { itemsContainer.css('overflow-y', 'auto'); }, 10);
        itemTemplatePromise.done(function (template) {
            var html = $(template({ items: items.reverse() }));
            itemsContainer.prepend(html);
            var addingHeight = html.outerHeight();
            if (messagesPage > 1) itemsContainer.scrollTop(addingHeight);
        });
    }

    function setupCreateConversation() {
        createConversationButton.click(function () {
            if (isCompactView() && !isMessageBoxOpen()) {
                hideConversationsBox();
                showMessagesBoxCompact();
            }
            var messagesSpinner = getMessagesSpinner();
            messagesSpinner.show();
            getSafeSendGroupsPromise.done(function (safesendgroups) {
                $.when(createConversationTemplatePromise, getRecipientsPromise).done(function (template, recipientsResponse) {
                    var templateData = {
                        activityType: currentActivity.activityType,
                        activityId: currentActivity.activityId,
                        recipients: recipientsResponse[0],
                        showFrom: safesendgroups.length > 1,
                        from: safesendgroups
                    };
                    var html = template(templateData);
                    messagesList.html(html);
                    setupNewConversationForm();
                    messagesSpinner.hide();
                });
            });
        });
    }

    function setupNewConversationForm() {
        var newConversationForm = $('#newConversationForm');
        var submitNewConversation = $("#submitNewConversationBtn");

        $('#conversationRecipients').select2();
        $("#conversationRecipients").on("select2-close", function () {
            $(this).valid();
        });
        $('#newConversationMessage').on('keyup', function () {
            autoresizeTextarea($(this));
        });

        $('#conversationRecipients').select2('focus');

        newConversationForm.validate({
            ignore: '.skip',
            // Rules for form validation
            rules: {
                "RecipientUaoIds[]": {
                    required: true
                },
                "Subject": {
                    required: true
                },
                "Message": {
                    required: true
                }
            },

            // Do not change code below
            errorPlacement: function (error, element) {
                error.insertAfter(element.parent());
            },

            submitHandler: submitForm
        });

        function submitForm(form) {
            submitNewConversation.prop('disabled', true);
            var newConversationError = getNewConversationError();
            newConversationError.hide();
            var messagesSpinner = getMessagesSpinner();
            messagesSpinner.show();

            var formData = newConversationForm.serializeArray();

            ajaxWrapper({
                url: newConversationForm.data("url"),
                type: "POST",
                data: formData
            }).done(function (res) {
                if (res.result === true) {
                    targetConversationId = null;
                    pager.page(1);
                } else {
                    showNewConversationError();
                }
                messagesSpinner.hide();
            }).fail(function (e) {
                showNewConversationError();
            });

            var showNewConversationError = function () {
                newConversationError.show();
                submitNewConversation.prop('disabled', false);
            }
        }

        createDropZone($('#upload'), $('#submitNewConversationBtn'));
    }

    function selectCurrentOrLatestConversation() {
        var items = dataSource.view();
        var items = _.map(items, function (item) {
            return _.extend({}, item, {
                Latest: dateString(item.Latest)
            });
        });
        var templateData = {
            isEmpty: items.length === 0,
            items: items
        };
        conversationsTemplatePromise.done(function (template) {
            var html = template(templateData);
            converationsList.html(html);
        });
        if (templateData.isEmpty) {
            emptyMessageTemplatePromise.done(function (template) {
                messagesList.html(template());
            });
        }
        conversationsSpinner.hide();
        publishConversationsChangedEvent();

        var conversations = $('#conversationsList .conversation-item');
        if (targetConversationId) {
            conversations = conversations.filter(function () {
                return $(this).data('conversation-id') == targetConversationId;
            });

            if (conversations.length == 1) {
                conversations.first().trigger('click');
                targetConversationId = null;
            } else if (!jumpedPage) {
                jumpedPage = true;
                ajaxWrapper({
                    url: urls.convRankUrl,
                    data: {
                        convID: targetConversationId
                    }
                }).success(function (data) {
                    var page = getPageFromRow(data, messagesPageSize);
                    pager.page(page);
                }).fail(function (e) {
                    if (!hasRedirect(e.responseJSON)) {
                        showtoastrError();
                    }
                });
            }
        } else {
            conversations.first().trigger('click');
        }
    }

    function autoresizeTextarea(textarea) {
        textarea.height(textarea[0].scrollHeight - 10);
    }

    function setupReply() {
        viewMessagesContainer.on('keyup', '#replyMessageTextArea', function () {
            autoresizeTextarea($(this));
        });

        viewMessagesContainer.on('click', '#replyButton', function (e) {
            var replyForm = $("#replyForm");
            var replyBtn = $("#replyButton");

            replyForm.validate({
                ignore: '.skip',
                rules: {
                    "Message": {
                        required: true
                    }
                },
                // Do not change code below
                errorPlacement: function (error, element) {
                    error.insertAfter(element.parent());
                },
                submitHandler: submitForm
            });
            function submitForm(form) {
                replyBtn.prop('disabled', true);
                var formData = replyForm.serializeArray();

                ajaxWrapper({
                    url: replyForm.data('url'),
                    type: "POST",
                    data: formData
                }).success(function () {
                    targetConversationId = currentConversation.id;
                    pager.page(1);
                    replyForm.find('textarea').val('');
                }).fail(function (e) {
                    if (!hasRedirect(e.responseJSON)) {
                        showtoastrError();
                    }
                });
            }
        });
    }

    function scrollToLastOrFirstUnreadMessage() {
        var messagesListElement = $('#messagesList .messages-list .scrollable');
        var messageToFocus = messagesListElement.find('.message-item.unread:first');
        if (messageToFocus.length == 0) {
            messageToFocus = messagesListElement.find('.message-item:last');
        }
        messagesListElement.scrollTo(messageToFocus, 0);
        messagesListElement.scroll(function () {
            if (messagesListElement.scrollTop() == 0) {
                showMessagesSpinner();
                loadItems().then(function (items) {
                    populateContainer($('#itemsContainer'), items);
                })
                .always(hideMessagesSpinner);
            }
        });
    }

    function setupDataReload() {
        if (isActivitySpecificView()) {
            // capturing the event from any parent views and refresh the view
            viewMessagesContainer.parent().on('activitychange', function (event, activityId, enabled) {
                resetCurrentConversation();
                cleanConversationsAndMessages();
                currentActivity.activityId = activityId;
                currentActivity.enabled = enabled;

                if (canLoadConversations()) {
               
                    loadConversations();
                }
            });
        }

        viewMessagesContainer.parent().on('loadConversations', function (event) {
            loadConversations();
        });
    }

    function getRecipients() {
        return ajaxWrapper({
            url: urls.recipientsUrl,
            data: {
                activityId: currentActivity.activityId,
                activityType: currentActivity.activityType
            }
        }).fail(function (e) {
            if (!hasRedirect(e.responseJSON)) {
                showtoastrError();
            }
        });
    }

    function getTemplatePromise(viewName) {
        var def = $.Deferred();
        ajaxWrapper({
            url: urls.templateUrl,
            data: {
                view: getRazorViewPath(viewName, 'Messages', 'Admin')
            }
        }).then(function (res) {
            def.resolve(Handlebars.compile(res));
        }).fail(function (e) {
            if (!hasRedirect(e.responseJSON)) {
                showtoastrError();
            }
        });
        return def;
    }

    function cleanConversationsAndMessages() {
        converationsList.html('');
        messagesList.html('');
    }

    // the functions related to toggling strictly depend on the bootstrap classes so any change to these may break the function
    function setupWindowToggling() {
        viewMessagesContainer.on('click', '.conversation-item', function (e) {
            attachmentsID = guid();
            var conv = $(this);

            if (isCompactView() && !isMessageBoxOpen()) {
                hideConversationsBox();
                showMessagesBoxCompact();
            }
            //var previousConversationId = currentConversation.id;

            setConversationItemActive(conv);
            markConversationAsRead(conv);
            updateCurrentConversation(conv);

            //if (currentConversation.id == previousConversationId) {
            //    return;
            //}
            showMessagesSpinner();
            $.when(getParticipantDetails(), loadMessages())
            .then(compileTemplates)
            .then(scrollToLastOrFirstUnreadMessage)
            .always(hideMessagesSpinner);
        });

        messagesContainer.on('click', '#conversationSubject', function () {
            if (isCompactView()) {
                hideMessagesBoxCompact();
                showConversationsBox();
            }
        });
    }

    function updateCurrentConversation(conversationElement) {
        currentConversation.id = conversationElement.data('conversation-id');
        currentConversation.subject = conversationElement.data('conversation-subject');
        currentConversation.link = conversationElement.data('conversation-link');
        currentConversation.linkdescription = conversationElement.data('conversation-link-description');
        currentConversation.issystemmessage = conversationElement.data('conversation-issystemmessage');
    }

    function showMessagesSpinner() {
        getMessagesSpinner().show();
    }

    function hideMessagesSpinner() {
        getMessagesSpinner().hide();
    }

    function getParticipantDetails() {
        return ajaxWrapper({
            url: urls.participantsUrl,
            data: {
                conversationId: currentConversation.id
            }
        }).fail(function (e) {
            if (!hasRedirect(e.responseJSON)) {
                showtoastrError();
            }
        });
    }

    function compileTemplates(participantsAjax, messages) {
        currentConversation.participants = participantsAjax[0];
        getSafeSendGroupsPromise.done(function (safesendgroups) {
            messagesTemplatePromise.done(function (template) {
                var html = $(template({
                    lonely: currentConversation.participants.length == 1,
                    conversation: currentConversation,
                    showFrom: safesendgroups.length > 1,
                    from: safesendgroups
                }));
                populateContainer(html.find('#itemsContainer'), messages);
                messagesList.html(html);

                createDropZone($('#upload'), $('#replyButton'));
            });
        });
    }

    function setConversationItemActive(selectedItem) {
        $('.conversation-item').removeClass('active');
        selectedItem.addClass('active');
    }

    function publishConversationsChangedEvent() {
        $('body').trigger('conversationsChanged');
    }

    function markConversationAsRead(selectedItem) {
        if (!selectedItem.hasClass('unread')) {
            return;
        }

        setTimeout(function () {
            selectedItem.removeClass('unread');
            publishConversationsChangedEvent();
        }, 3000);
    }

    function isCompactView() {
        return $('#conversationSubject i').is(':visible');
    }

    function isMessageBoxOpen() {
        return !messagesContainer.hasClass('col-xs-0');
    }

    function showMessagesBoxCompact() {
        messagesContainer.addClass('col-xs-12');
        messagesContainer.removeClass('col-xs-0 col-sm-0');
    }

    function hideMessagesBoxCompact() {
        messagesContainer.addClass('col-xs-0 col-sm-0');
        conversationsContainer.removeClass('col-xs-12');
    }

    function showConversationsBox() {
        conversationsContainer.removeClass('col-xs-0 col-sm-0');
    }

    function hideConversationsBox() {
        conversationsContainer.addClass('col-xs-0 col-sm-0');
    }

    function createDropZone(item, sendButton) {
        attachmentsID = guid();
        $('#AttachmentsID').val(attachmentsID);
        var dzelem = item.dropzone({
            url: urls.uploadUrl + '?id=' + attachmentsID,
            addRemoveLinks: true,
            maxFilesize: 20, //MB
            accept: function (file, done) {
                if (file.size > 0)
                    done();
                else
                    done('This file is empty and will not be uploaded');
            },
            init: function () {
                var dz = this;
                dz.on("addedfile", function (file) {
                    sendButton.prop('disabled', true);
                });
                dz.on("queuecomplete", function () {
                    sendButton.prop('disabled', false);
                });

                dz.on("removedfile", function (file, dataUrl) {
                    removeFile(file.name)
                });

                dz.on("error", function (file, msg, xhr) {
                    if (xhr && xhr.response) {
                        var j = JSON.parse(xhr.response);
                        checkRedirect(j);
                    }
                });
            },
            previewTemplate: '<div class="dz-preview dz-file-preview">' +
              '<div class="dz-details">' +
                '<div class="dz-filename"><span data-dz-name></span></div>' +
                '<div class="dz-size" data-dz-size></div>' +
                '<img data-dz-thumbnail />' +
              '</div>' +
              '<div class="dz-progress"><span class="dz-upload" data-dz-uploadprogress></span></div>' +
              '<div class="dz-success-mark"><span>✔</span></div>' +
              '<div class="dz-error-mark"><span>✘</span></div>' +
              '<div class="dz-error-message"><span data-dz-errormessage></span></div>' +
            '</div>'
        });

        $('#multiform').attr("action", urls.uploadUrl + '?id=' + attachmentsID);

        $("#test").on('click', function (e) {
            $("#file").click();
        });

        $("#file").on('click', function (e) {
            if (fbUploading) {
                e.preventDefault();
                alert('Please wait for the previous upload to complete');
            }
        });

        $("#file").on('change', function (e) {
            if ($("#file").val() != '') {
                sendButton.prop('disabled', true);
                $('#multiform').submit();
            }
            else {
                console.log('blank');
            }
        });

        if (!Dropzone.isBrowserSupported()) {
            $("#multiform").submit(function (e) {

                fbUploading = true;
                var formObj = $(this);
                var formURL = formObj.attr("action");

                //generate a random id
                var iframeId = 'unique' + (new Date().getTime());

                //create an empty iframe
                var iframe = $('<iframe src="javascript:false;" name="' + iframeId + '" />');

                //hide it
                iframe.hide();

                //set form target to iframe
                formObj.attr('target', iframeId);

                //Add iframe to body
                iframe.appendTo('body');
                iframe.load(function (e) {
                    $("#file").replaceWith($("#file").clone(true));

                    var doc = getDoc(iframe[0]); //get iframe Document
                    var docRoot = doc.body ? doc.body : doc.documentElement;
                    var data = docRoot.innerHTML;
                    var msg = $("<p>Something went wrong. File size is limited to 25MB</p>");
                    try {
                        var j = JSON.parse(data);
                        msg = $('<p>' + j.Message + ' </p>');

                        var removeLink = $('<a>Remove</a>');
                        removeLink.on('click', function () {
                            removeFile(j.FileName).success(function () {
                                removeLink.parent().remove();
                            });
                        })
                        msg.append(removeLink);
                    }
                    catch (e) {
                        console.log(e);
                    }

                    $('#multiform').prepend(msg);
                    fbUploading = false;
                    sendButton.prop('disabled', false);
                });

            });
        }
    }

    function removeFile(name) {
        return ajaxWrapper({
            url: urls.removeUploadUrl,
            data: {
                filename: name,
                id: attachmentsID
            },
            method: 'POST'
        }).fail(function (e) {
            if (!hasRedirect(e.responseJSON)) {
                showtoastrError();
            }
        });
    }

    function getDoc(frame) {
        var doc = null;

        // IE8 cascading access check
        try {
            if (frame.contentWindow) {
                doc = frame.contentWindow.document;
            }
        } catch (err) {
        }

        if (doc) { // successful getting content
            return doc;
        }

        try { // simply checking may throw in ie8 under ssl or mismatched protocol
            doc = frame.contentDocument ? frame.contentDocument : frame.document;
        } catch (err) {
            // last attempt
            doc = frame.document;
        }
        return doc;
    }

});
