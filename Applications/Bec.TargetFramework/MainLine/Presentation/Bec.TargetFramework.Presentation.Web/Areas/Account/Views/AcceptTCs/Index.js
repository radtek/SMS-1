$(function () {
    $('#tc').change(function () {
        $('#formSubmit').prop('disabled', !$('#tc').prop('checked'));
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

    $('#formSubmit').click(function () {
        $('#tc').prop('disabled', true);
        $('#download-btn').prop('disabled', true);
        $('#formSubmit').prop('disabled', true);
        $('#login-form').submit();
    });

    $('#download-btn').click(function (e) {
        if ($('#download-btn').prop('disabled')) e.preventDefault();
    });
});