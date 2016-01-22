$(function () {
    initAddTradingNames();
});

// submit from when Save button clicked
$("#submitRegister").click(function () {
    $("#registerlender-form").submit();
});

// Validation
$("#registerlender-form").validate({
    ignore: '.skip',
    // Rules for form validation
    rules: {
        OrganisationAdminSalutation: {
            required: true
        },
        OrganisationAdminFirstName: {
            required: true
        },
        OrganisationAdminLastName: {
            required: true
        },
        OrganisationAdminEmail: {
            required: true,
            email: true,
            remote: {
                cache: false,
                url: $('#OrganisationAdminEmail').data("url"),
                data: {
                    email: function () {
                        return $('#OrganisationAdminEmail').val();
                    },
                    __RequestVerificationToken: $("input[name='__RequestVerificationToken']").val()
                },
                type: 'POST',
                dataType: 'json',
                error: function (xhr, status, error) { checkRedirect(xhr.responseJSON); }
            }
        },
        OrganisationAdminTelephone: {
            required: true
        },
        CompanyName: {
            required: true
        },
        RegulatorOther: {
            required: true
        },
        Regulator: {
            required: true
        }
    },

    // Do not change code below
    errorPlacement: function (error, element) {
        error.insertAfter(element.parent());
    },

    submitHandler: validateRegisterSubmit
});

function validateRegisterSubmit(form) {
    $("#submitRegister").prop('disabled', true);
    form.submit();
}

function initAddTradingNames() {
    var index = 1;
    var tradingNameTemplatePromise = $.Deferred();
    var addNextTradingNameBtn = $('#addNextTradingNameBtn');
    var addNextTradingNameRow = $('#addNextTradingNameRow');
    ajaxWrapper({
        url: addNextTradingNameRow.data("templateurl") + '?view=' + getRazorViewPath('_tradingNameTmpl', 'Company', 'Admin')
    }).done(function (res) {
        tradingNameTemplatePromise.resolve(Handlebars.compile(res));
    }).fail(function (e) {
        if (!hasRedirect(e.responseJSON)) {
            showtoastrError();
        }
    });

    addNextTradingNameBtn.click(function (event) {
        if ($('input[name="TradingNames[' + (index - 1) + ']').val()) {
            var templateData = {
                index: index++
            };
            tradingNameTemplatePromise.done(function (template) {
                var html = template(templateData);
                addNextTradingNameRow.before(html);

                $('input[name="TradingNames[' + (index - 1) + ']').focus();
            });
        }

        event.preventDefault();
        return false;
    });

    $('body').on('click', '.delete-entry', function (event) {
        var parentRowId = $(this).data('parent-id');
        var parentToRemove = $('#' + parentRowId);
        parentToRemove
            .addClass('red-bg')
            .fadeOut(500, function () {
                parentToRemove.remove();
                renumberInputs('input[name^="TradingNames"]', 'TradingNames');
                reindexElementAttr('[id^="tradingNameRow"]', 'tradingNameRow', 'id');
                reindexElementAttr('[data-parent-id^="tradingNameRow"', 'tradingNameRow', 'data-parent-id');
                index--;
            });
        event.preventDefault();
        return false;
    });
}

function renumberInputs(inputsSelector, prefix) {
    console.log("rn");
    $(inputsSelector).each(function (index) {
        console.log("rn: " + index);
        var prefixWithIndex = prefix + "[" + index + "]";
        var regExp = new RegExp(prefix + '\\[\\d+\\]');
        this.name = this.name.replace(regExp, prefixWithIndex);
    });
}

function reindexElementAttr(selector, prefix, attrName) {
    $(selector).each(function (index) {
        var prefixWithIndex = prefix + index;
        var regExp = new RegExp(prefix + '\\d+');
        var newValue = $(this).attr(attrName).replace(regExp, prefixWithIndex);
        $(this).attr(attrName, newValue);
    });
}