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

function handleModal(m, handlers, fixScroll, shownFunction) {
    var vals = [];
    for (var id in handlers) {
        vals[id] = false;
        $('#' + id).on('click.handleModal', { id: id }, function (e) {
            vals[e.data.id] = true;
        });
    }
    m.modal({
        backdrop: 'static',
        keyboard: false
    }).one('shown.bs.modal', function () {
        if (shownFunction) shownFunction();
    }).one('hidden.bs.modal', function (e) {
        if (fixScroll) $('body').addClass('modal-open');
        for (var id in handlers) {
            $('#' + id).off('click.handleModal');
            if (vals[id]) {
                handlers[id]();
            }
        }
    });
}

function dateString(date) {
    return new Date(date).toLocaleString();
}

function saveGridSort(gridElementId) {
    var sort = $("#unverifiedGrid").data("kendoGrid").getOptions().dataSource.sort;
    sessionStorage["gridSort-" + gridElementId] = JSON.stringify(sort);
}

function loadGridSort(gridElementId) {
    try {
        return JSON.parse(sessionStorage["gridSort-" + gridElementId]);
    }
    catch (ex) {
        return null;
    }
}