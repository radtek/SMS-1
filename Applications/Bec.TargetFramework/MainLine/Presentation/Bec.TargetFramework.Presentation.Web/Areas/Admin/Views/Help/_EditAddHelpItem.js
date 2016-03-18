﻿$(function () {
    'use strict';
    
    hideShowElements();

    $("#ddlRolesEdit").select2({
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
    $("#submitEditAddHelpItem").click(function () {
        if ($("#editAddHelpItem-form").valid()) {
            $.ajax({
                url: $("#editAddHelpItem-form").attr('action'),
                type: 'POST',
                data: $("#editAddHelpItem-form").serialize(),
                success: function (data) {
                    if (data.success === true) {
                        $("#hiGrid").data('kendoGrid').dataSource.read();
                        $('#cancelEditAddHelpItem').click();
                    } 
                }
            });
        }
    });

    $("#editAddHelpItem-form").validate({
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
        $("#submiteEditAddHelpItem").prop('disabled', true);
        form.submit();
    }

    function hideShowElements()
    {
        var helpType = $("#HelpTypeName").val();
        showHideAndClearValueElement("#effectionFromSection", "#EffectiveFrom", (helpType === "Callout"));
        showHideAndClearValueElement("#uiPositionSection", "#UiPosition", (helpType !== "Callout"));
        showHideAndClearValueElement("#uiSelectorParentSection", "#UiSelectorParent", (helpType !== "Callout"));
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