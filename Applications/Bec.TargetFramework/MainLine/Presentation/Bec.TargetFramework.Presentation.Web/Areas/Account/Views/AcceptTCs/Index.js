$(function () {
    var formSubmitButton = $('#formSubmit');
    var tcCheckbox = $('#tc');
    var isTsCsAccepted = false;
    tcCheckbox.change(function () {
        isTsCsAccepted = $('#tc').prop('checked');
        if (isTsCsAccepted) {
            formSubmitButton.attr("title", "");
            formSubmitButton.tooltip("destroy");
        }
    });

    $(window).on('resize', function (e) {
        //smart admin is a bit odd. 'hidden-menu' means hidden when > 979 pixels, but shown when < 979 pixels...
        if ($(window).width() < 979) {
            if ($('body').hasClass('hidden-menu')) $('body').removeClass('hidden-menu');
        }
        else {
            if (!$('body').hasClass('hidden-menu')) $('body').addClass('hidden-menu');
        }
    });

    formSubmitButton.click(function (e) {
        formSubmitButton.prop('disabled', true);
        if (isTsCsAccepted) {
            $('#tc').prop('disabled', true);
            $('#download-btn').prop('disabled', true);
            $('#login-form').submit();
        } else {
            handleModal({ url: $(formSubmitButton).data("message") }, {
                messageButton: function () {
                    formSubmitButton.prop('disabled', false);
                }
            }, true);

            e.preventDefault();
            return false;
        }
    });

    $('#download-btn').click(function (e) {
        if ($('#download-btn').prop('disabled')) e.preventDefault();
    });
});