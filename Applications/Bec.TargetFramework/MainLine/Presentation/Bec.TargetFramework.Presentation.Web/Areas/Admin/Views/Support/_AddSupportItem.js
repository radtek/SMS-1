$(function () {
    'use strict';

    jQuery.event.handle = jQuery.event.dispatch;

    function setupFormRequest() {
        // submit from when Save button clicked
        $("#submitAddSupportItem").click(function () {
            $("#addSupportItem-form").submit();
        });
        $("#addSupportItem-form").validate({
            ignore: '.skip',
            // Rules for form validation
            rules: {
                'Title': {
                    required: true
                },
                'Description': {
                    required: true
                },
                'RequestTypeID': {
                    required: true
                },
                'Telephone': {
                    required: true
                }
            },
            // Do not change code below
            errorPlacement: function (error, element) {
                error.insertAfter(element.parent());
            },
            submitHandler: submitFormRequest
        });
    }

    function submitFormRequest(form) {
        $("#submitAddSupportItem").prop('disabled', true);
        var formData = $("#addSupportItem-form").serializeArray();
        ajaxWrapper({
            url: $("#addSupportItem-form").attr("action"),
            type: "POST",
            data: formData
        }).done(function (res) {
            if (res.result === true) {
                location.reload();
            }
            else {
                handleModal({ url: $("#addSupportItem-form").data("message") + "?title=" + res.title + "&message=" + res.message + "&button=Back" }, {
                    messageButton: function () {
                        $("#submitAddSupportItem").prop('disabled', false);
                    }
                }, true);
            }
        }).fail(function (e) {
            if (!hasRedirect(e.responseJSON)) {
                handleModal({ url: $("#addSupportItem-form").data("message") + "?title=Error&message=" + e.statusText + "&button=Back" }, {
                    messageButton: function () {
                        $("#submitAddSupportItem").prop('disabled', false);
                    }
                }, true);
            }
        });
    }
    setupFormRequest();

    var viewContainerSi = $('#addSupportItem-form'),
        attachmentsIDSi = guid(),
        fbUploadingSi = false;

    var urlsSi = {
        uploadUrl: viewContainerSi.data("upload-url"),
        removeUploadUrl: viewContainerSi.data("remove-upload-url")
};
    function createDropZoneSi(item, sendButton) {
        attachmentsIDSi = guid();
        $('#AttachmentsIDSi').val(attachmentsIDSi);
        item.dropzone({
            url: urlsSi.uploadUrl + '?id=' + attachmentsIDSi,
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
                    removeFileSi(file.name);
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

        $('#multiformSi').attr("action", urlsSi.uploadUrl + '?id=' + attachmentsIDSi);

        $("#testSi").on('click', function (e) {
            $("#fileSi").click();
        });

        $("#fileSi").on('click', function (e) {
            if (fbUploadingSi) {
                e.preventDefault();
                alert('Please wait for the previous upload to complete');
            }
        });

        $("#fileSi").on('change', function (e) {
            if ($("#fileSi").val() !== '') {
                sendButton.prop('disabled', true);
                $('#multiformSi').submit();
            }
        });

        if (!Dropzone.isBrowserSupported()) {
            $("#multiformSi").submit(function (e) {

                fbUploadingSi = true;
                var formObj = $(this);

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

                    $("#fileSi").replaceWith($("#fileSi").clone(true));

                    var doc = getDocSi(iframe[0]); //get iframe Document
                    var docRoot = doc.body ? doc.body : doc.documentElement;
                    var data = docRoot.innerHTML;
                    var msg = $("<p>Something went wrong. File size is limited to 25MB</p>");
                    try {
                        var j = JSON.parse(data);
                        msg = $('<p>' + j.Message + ' </p>');

                        var removeLink = $('<a>Remove</a>');
                        removeLink.on('click', function() {
                            removeFileSi(j.FileName).success(function() {
                                removeLink.parent().remove();
                            });
                        });
                        msg.append(removeLink);
                    }
                    catch (e) {
                    }

                    $('#multiformSi').prepend(msg);
                    fbUploadingSi = false;
                    sendButton.prop('disabled', false);
                });

            });
        }
    }

    createDropZoneSi($('#uploadSi'), $('#submitAddSupportItem'));

    function removeFileSi(name) {
        return ajaxWrapper({
            url: urlsSi.removeUploadUrl,
            data: {
                filename: name,
                id: attachmentsIDSi
            },
            method: 'POST'
        });
    }

    function getDocSi(frame) {
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
            doc = frame.document;
        }
        return doc;
    }
});