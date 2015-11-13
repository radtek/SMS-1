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
    '<p><a class="btn btn-primary" href="mailto:[please enter your conveyancers email address]?subject=Name:&body=The above named client has expressed their interest in using the Safe Move Scheme to reduce the risk of cybercrime affecting them during their property transaction. If your Firm is already a member of the Safe Move Scheme you will be able to login to order products.%0D%0A%0D%0AIf your Firm is new to the Safe Move Scheme you can register via our website – for security reasons please search ‘Safe Move Scheme’ via Google to find our website to avoid hackers from redirecting you to a bogus site.%0D%0A%0D%0AKind Regards%0D%0A%0D%0AThe Safe Move Scheme">Click here to contact your conveyancer</a></p>' +
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
                    $('#searchResult').append('<p><strong>' + res.message + '</strong></p>');
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