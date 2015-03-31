function checkRedirect(response) {
    if (response.HasRedirectUrl) window.location.href = response.RedirectUrl;
}

function ajaxWrapper(options) {
    return $.ajax(options).fail(function (err) {
        checkRedirect(err.responseJSON);
    });
}

function getGridDataFromUrl(url) {
    return function (options) {
        ajaxWrapper({
            url: url
        }).done(function (result) {
            options.success(result);
        });
    };
}