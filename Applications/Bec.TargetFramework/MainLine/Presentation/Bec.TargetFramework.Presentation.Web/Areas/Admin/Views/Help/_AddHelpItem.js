﻿$(function () {
    'use strict';
    
    hideShowElements();

    $("#ddlRoles").select2({
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
    $("#submitAddHelpItem").click(function () {
        if ($("#addHelpItem-form").valid())
        {
            $.ajax({
                url: $("#addHelpItem-form").attr('action'),
                type: 'POST',
                data: $("#addHelpItem-form").serialize(),
                success: function (data) {
                    if (data.success === true) {
                        $("#hiGrid").data('kendoGrid').dataSource.read();
                        $('#cancelAddHelpItem').click();
                    }
                }
            });
        }
    });

    $("#addHelpItem-form").validate({
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
        $("#submitAddHelpItem").prop('disabled', true);
        form.submit();
    }


    function hideShowElements()
    {
        var helpType = $("#HelpTypeName").val();
        showHideAndClearValueElement("#effectionFromSection", (helpType === "Callout"));
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