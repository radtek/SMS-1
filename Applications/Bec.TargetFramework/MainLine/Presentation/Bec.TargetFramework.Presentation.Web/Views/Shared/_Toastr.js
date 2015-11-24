$(function () {
    toastr.options.closeButton = true;
    toastr.options.newestOnTop = true;

    $('#toastrMessages').children().each(function (i, value) {
        var toast = $(value);
        var toastTypeValue = toast.data('toast-type');
        var title = toast.data('title');
        var message = toast.data('message');
        var isSticky = toast.data('is-sticky');
        var optionsOverride = {
            progressBar: true,
            hideDuration: 100
        };
        if (isSticky) {
            _.extend(optionsOverride, {
                timeOut: 0, 
                extendedTimeout: 0
            });
        }

        toastr[toastTypeValue](message, title, optionsOverride);
    });
});