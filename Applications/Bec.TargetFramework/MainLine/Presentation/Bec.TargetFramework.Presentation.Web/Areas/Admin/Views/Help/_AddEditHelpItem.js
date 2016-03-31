$(function () {
    'use strict';
    
    hideShowElements();

    $("#ddlRolesAddEdit").select2({
        placeholder: "Select a Role"
    });

    $("#EffectiveFrom").each(function () {
        $(this).datepicker(
        {
            dateFormat: "dd/mm/yy",
            defaultDate: new Date($(this).val())
        });
    });
    
    // submit from when Save button clicked
    $("#submitAddEditHelpItem").click(function () {
        if ($("#addEditHelpItem-form").valid())
        {
            $.ajax({
                url: $("#addEditHelpItem-form").attr('action'),
                type: 'POST',
                data: $("#addEditHelpItem-form").serialize(),
                complete: function (data) {
                        $("#ehGrid").data('kendoGrid').dataSource.read();
                        $('#cancelAddEditHelpItem').click();
                }
            });
        }
    });

    $("#addEditHelpItem-form").validate({
        ignore: ':hidden',
        // Rules for form validation
        rules: {
            Title: {
                required: true
            },
            UiSelector: {
                required: true
            },
            SelectedRoles: {
                required: true
            },
            EffectiveFrom: {
                required: true
            },
            UiPosition: {
                required: true
            }
        },

        // Do not change code below
        errorPlacement: function (error, element) {
            error.insertAfter(element.parent());
        },

        submitHandler: validateSubmit
    });

    function validateSubmit(form) {
        $("#submitAddEditHelpItem").prop('disabled', true);
        form.submit();
    }

    function hideShowElements()
    {
        var helpType = $("#HelpTypeName").val();

        showHideAndClearValueElement("#effectionFromSection", (helpType === "Callout"));
        showHideAndClearValueElement("#includeStartTourSection", (helpType === "Callout"));
        showHideAndClearValueElement("#uiPositionSection", (helpType !== "Callout"));
    }

    function showHideAndClearValueElement(sectionName, show) {
        if (show) {
            $(sectionName).css('display', 'block');
        }
        else {
            $(sectionName).css('display', 'none');
        }
    }

});