$(function () {

    setupClientPostcodeLookup();
    formatDates();

    $("#editSmsTransaction-form").fieldPendingUpdates({
        selector: '.pending-changes-button',
        includeApproveReject: true,
        container: '#editBuyerPartyContainer',
        showFirst: true
    });

    function validateSubmit(form) {
        $("#submitEditSmsTransaction").prop('disabled', true);
        var formData = $("#editSmsTransaction-form").serializeArray();
        fixDate(formData, 'Dto.Contact.BirthDate', "#birthDateInput");
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
            'Dto.Contact.Salutation': {
                required: true
            },
            'Dto.Contact.FirstName': {
                required: true
            },
            'Dto.Contact.LastName': {
                required: true
            },
            'Dto.UserAccountOrganisation.UserAccount.Email': {
                required: true,
                email: true,
                remote: {
                    cache: false,
                    url: $('#Dto_UserAccountOrganisation_UserAccount_Email').data("url"),
                    data: { email: function () { return $('#Dto_UserAccountOrganisation_UserAccount_Email').val(); } },
                    dataType: 'json',
                    error: function (xhr, status, error) { checkRedirect(xhr.responseJSON); }
                }
            },
            'Dto.Address.Line1': {
                required: {
                    depends: addressDependsRule
                }
            },
            'Dto.Address.Town': {
                required: {
                    depends: addressDependsRule
                }
            },
            'Dto.Address.PostalCode': {
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

    var roDate = $('#birthDateReadOnly');
    if (roDate.length === 1) roDate.val(dateStringNoTime(roDate.val()));

    function setupClientPostcodeLookup() {
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
});