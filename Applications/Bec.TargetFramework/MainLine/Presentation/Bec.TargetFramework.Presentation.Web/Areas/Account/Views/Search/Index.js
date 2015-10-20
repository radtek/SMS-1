var template = Handlebars.compile('<dl class="dl-horizontal">'+
    '<dt>Company Name:</dt>'+
    '<dd><p>{{Name}}</p></dd>'+
    '<dt>Address:</dt>'+
    '<dd>'+
        '<p>{{Line1}}</p>'+
        '<p>{{Town}}</p>'+
        '<p>{{County}}</p>'+
        '<p>{{PostalCode}}</p>'+
    '</dd>'+
    '<dt>Regulator:</dt>' +
    '<dd><p>{{Regulator}}</p></dd>' +
    '<dt>Regulator Number:</dt>' +
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
                    $('#searchResult').append('<p class="alert alert-info">' + res.message + '</p>');
                }
                else {
                    showSearchResult(res);
                }
            })
            .always(function () {
                $('#formSubmit').prop('disabled', false);
            });
        }
    });
});

function showSearchResult(dataItem) {
    var html = template(dataItem);
    $('#searchResult').html(html);
}