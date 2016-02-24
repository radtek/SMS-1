$(function () {
    'use strict';

    setupForm();
    initAddTradingNames();

    function setupForm() {
        $.validator.addMethod("lenderDupeCheck",
            function (value, element) {
                var isDupe = false;
                ajaxWrapper({
                    url: $(element).data("lender-dupe-check-url"),
                    type: "POST",
                    data: {
                        lenderName: value,
                        __RequestVerificationToken: $("input[name='__RequestVerificationToken']").val()
                    },
                    async: false
                }).done(function (res) {
                    isDupe = res;
                }).fail(function (e) {
                    showtoastrError();
                });
                return isDupe;
            }, 'The lender with that name is already registered in the system');

        // submit from when Save button clicked
        $("#submitRegister").click(function () {
            $("#registerlender-form").submit();
        });

        // Validation
        $("#registerlender-form").validate({
            ignore: '.skip',
            onkeyup: false,
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
                    required: true,
                    //lenderDupeCheck: true - set as html data attribute
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
    }

    function initAddTradingNames() {

        var lenderSearchUrl = $('#registerlender-form').data("lender-search-url");
        var lenderDupeCheckUrl = $('#registerlender-form').data("lender-dupe-check-url");
        $('#companyName, input[name="TradingNames[0]').lenderSearch({
            searchUrl: lenderSearchUrl
        });

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
                    index: index++,
                    lenderDupeCheckUrl: lenderDupeCheckUrl
                };
                tradingNameTemplatePromise.done(function (template) {
                    var html = template(templateData);
                    addNextTradingNameRow.before(html);

                    var sel = 'input[name="TradingNames[' + (index - 1) + ']';
                    $(sel).focus();

                    $(sel).lenderSearch({
                        searchUrl: lenderSearchUrl
                    });
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
        $(inputsSelector).each(function (index) {
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
});
