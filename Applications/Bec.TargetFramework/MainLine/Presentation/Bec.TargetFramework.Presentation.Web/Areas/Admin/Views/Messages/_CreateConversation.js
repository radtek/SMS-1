//$(function () {
//    var createConversationForm = $("#createConversationForm");
//    var submitCreateConversation = $("#submitCreateConversation");

//    submitCreateConversation.click(function () {
//        createConversationForm.submit();
//    });

//    createConversationForm.validate({
//        ignore: '.skip',
//        // Rules for form validation
//        rules: {
//            "Subject": {
//                required: true
//            },
//            "Message": {
//                required: true
//            },
//        },

//        // Do not change code below
//        errorPlacement: function (error, element) {
//            error.insertAfter(element.parent());
//        },

//        submitHandler: submitForm
//    });

//    function submitForm(form) {
//        submitCreateConversation.prop('disabled', true);
//        var formData = createConversationForm.serializeArray();
//        ajaxWrapper({
//            url: createConversationForm.data("url"),
//            type: "POST",
//            data: formData
//        }).done(function (res) {
//            if (res.result === true)
//                window.location = createConversationForm.data('redirectto');
//            else {
//                handleModal({ url: createConversationForm.data("message") + "?title=" + res.title + "&message=" + res.message + "&button=Back" }, {
//                    messageButton: function () {
//                        submitCreateConversation.prop('disabled', false);
//                    }
//                }, true);
//            }
//        }).fail(function (e) {
//            if (!hasRedirect(e.responseJSON)) {
//                console.log(e);
//                handleModal({ url: createConversationForm.data("message") + "?title=Error&message=" + e.statusText + "&button=Back" }, {
//                    messageButton: function () {
//                        submitCreateConversation.prop('disabled', false);
//                    }
//                }, true);
//            }
//        });
//    }
//});
