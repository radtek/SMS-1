$(function () {
    jQuery.event.handle = jQuery.event.dispatch
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
            if (res.result === true){
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
                console.log(e);
                handleModal({ url: $("#addSupportItem-form").data("message") + "?title=Error&message=" + e.statusText + "&button=Back" }, {
                    messageButton: function () {
                        $("#submitAddSupportItem").prop('disabled', false);
                    }
                }, true);
            }
        });
    }
    setupFormRequest();

    var viewContainer = $('#addSupportItem-form'),
        attachmentsID = guid(),
        fbUploading = false;

    var urls = {
        //templateUrl: viewContainer.data("templateurl"),
        //conversationUrl: viewContainer.data("conversations-url"),
        //messagesUrl: viewContainer.data("messages-url"),
        //recipientsUrl: viewContainer.data("recipients-url"),
        //convRankUrl: viewContainer.data("convrank-url"),
        //participantsUrl: viewContainer.data("participants-url"),
        uploadUrl: viewContainer.data("upload-url"),
        removeUploadUrl: viewContainer.data("remove-upload-url"),
    };
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
                    console.log($("#file").val());
                    $("#file").replaceWith($("#file").clone(true));
                    console.log($("#file").val());

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

    createDropZone($('#upload'), $('#submitAddSupportItem'));

    function removeFile(name) {
        return ajaxWrapper({
            url: urls.removeUploadUrl,
            data: {
                filename: name,
                id: attachmentsID
            },
            method: 'POST'
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
