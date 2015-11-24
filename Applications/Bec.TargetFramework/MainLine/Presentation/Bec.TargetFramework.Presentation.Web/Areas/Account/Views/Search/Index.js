var template = Handlebars.compile('<dl class="dl-horizontal">'+
    '<dt><p>Company Name:</p></dt>' +
    '<dd><p>{{Name}}</p></dd>'+
    '<dt><p>Address:</p></dt>' +
    '<dd>'+
        '<p>{{Line1}}</p>'+
        '<p>{{Town}}</p>'+
        '<p>{{County}}</p>'+
        '<p>{{PostalCode}}</p>'+
    '</dd>'+
    '<dt><p>Regulator:</p></dt>' +
    '<dd><p>{{Regulator}}</p></dd>' +
    '<dt><p>Regulator Number:</p></dt>' +
    '<dd><p>{{RegulatorNumber}}</p></dd>' +    
'</dl>');

$(function () {

    // Validation
    $("#search-form").validate({
        ignore: '.skip',
        // Rules for form validation
        rules: {
            schemeID: {
                required: true,
                digits: true
            },
            hiddenRecaptcha: {
                required: function () {
                    return grecaptcha.getResponse() == '';
                }
            }
        },
        // Do not change code below
        errorPlacement: function (error, element) {
            element.parent().append(error);
        },
        submitHandler: function (form) {
            $('#formSubmit').prop('disabled', true);
            ajaxWrapper({
                url: $('#search-form').data("url"),
                data: $('#search-form').serializeArray(),
                method: 'POST'
            }).done(function (res) {
                if (res.message) {
                    $('#searchResult').empty();
                    $('#searchResult').append('<p><strong>' + res.message + '</strong></p>');
                    appendRetryButton();
                }
                else {
                    showSearchResult(res);
                    appendRetryButton();
                }
            })
            .always(function () {
                $('#formSubmit').hide();
            });
        }
    });
});

function showSearchResult(dataItem) {
    var html = template(dataItem);
    $('#searchResult').html(html);
}

function appendRetryButton() {
    $('#searchResult').append('<p><a class="btn btn-primary" href="' + $('#search-form').data("url") + '">Click here to search again</a></p>');
}