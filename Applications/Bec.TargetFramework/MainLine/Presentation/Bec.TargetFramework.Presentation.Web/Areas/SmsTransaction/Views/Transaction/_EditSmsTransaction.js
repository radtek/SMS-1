$(function () {
    'use strict';

    setupSmsPostcodeLookup();
    setupMortgageSelect();
    setupForm();

    function setupForm() {
        // submit from when Save button clicked
        $("#submitEditSmsTransaction").click(function () {
            $("#editSmsTransaction-form").submit();
        });

        var addressDependsRule = function (element) {
            return _.find($('[name^="Dto.Address"][type="text"]'), function (input) {
                return $(input).val().trim() !== '';
            })
        };

        $("#editSmsTransaction-form").validate({
            ignore: '.skip',
            // Rules for form validation
            rules: {
                "Dto.Price": {
                    digits: true,
                    max: 2147483647
                },
                "Dto.LenderName": {
                    required: {
                        depends: function (element) {
                            return $("#BuyingWithMortgageSelect").find("option:selected").val() != 0;
                        }
                    }
                },
                "Dto.MortgageApplicationNumber": {
                    required: {
                        depends: function (element) {
                            return $("#BuyingWithMortgageSelect").find("option:selected").val() != 0;
                        }
                    }
                },
                "Dto.Address.Line1": {
                    required: {
                        depends: addressDependsRule
                    }
                },
                "Dto.Address.Town": {
                    required: {
                        depends: addressDependsRule
                    }
                },
                "Dto.Address.PostalCode": {
                    minlength: 5,
                    required: {
                        depends: addressDependsRule
                    }
                }
            },

            // Do not change code below
            errorPlacement: function (error, element) {
                error.insertAfter(element.parent());
            },

            submitHandler: validateSubmit
        });

        makeDatePicker("#birthDateInput", {
            maxDate: new Date()
        });

        $("#editSmsTransaction-form").fieldPendingUpdates({
            selector: '.pending-changes-button',
            includeApproveReject: true,
            container: '#editSmsTransactionContainer',
            showFirst: true
        });

        function validateSubmit(form) {
            $("#submitEditSmsTransaction").prop('disabled', true);
            var formData = $("#editSmsTransaction-form").serializeArray();
            fixDate(formData, 'Model.Contact.BirthDate', "#birthDateInput");
            ajaxWrapper({
                url: $("#editSmsTransaction-form").data("url"),
                type: "POST",
                data: formData
            }).done(function (res) {
                if (res.result === true)
                    window.location = $("#editSmsTransaction-form").data("redirectto");
                else {
                    handleModal({ url: $("#editSmsTransaction-form").data("message") + "?title=" + res.title + "&message=" + res.message + "&button=Back" }, {
                        messageButton: function () {
                            $("#submitEditSmsTransaction").prop('disabled', false);
                        }
                    }, true);
                }
            }).fail(function (e) {
                if (!hasRedirect(e.responseJSON)) {
                    showtoastrError();
                }
            });
        }
    }

    function setupSmsPostcodeLookup() {
        new findAddress({
            postcodelookup: '#txPostcodeLookup',
            line1: '#txLine1',
            line2: '#txLine2',
            town: '#txTown',
            county: '#txCounty',
            postcode: '#txPostalCode',
            manualAddress: '#txManualAddress',
            resList: '#txAddressResults',
            manAddRow: '#txManAddRow',
            noMatch: '#txNoMatch',
            findAddressButton: '#txFindAddressButton',
            alwaysEditable: true
        }).setup();
    }

    function setupMortgageSelect() {
        var mortgageSel = $("#BuyingWithMortgageSelect");
        mortgageSel.change(function () {
            $(this).find("option:selected").each(function () {
                var selectedValue = parseInt($(this).attr("value"));
                $("#BuyingWithMortgageContainer").toggle(!!selectedValue);
                if (selectedValue != 1) {
                    $('#lenderSearch').val('');
                    $('#mortgageAppNumber').val('');
                }
            });
        });

        var lenderInput = $('#lenderSearch');
        var lenderCheck = $('#lenderSearch-check');
        var appNumberInput = $('#mortgageAppNumber');
        var appNumberCheck = $('#mortgageAppNumber-check');
        
        var mortgagePresent =  (lenderInput.val() || lenderCheck.length > 0 || appNumberInput.val() || appNumberCheck.length > 0)
        
        mortgageSel.val(mortgagePresent ? '1' : '0');
        mortgageSel.change();

        lenderInput.lenderSearch({
            searchUrl: lenderInput.data("url")
        });
    }
});