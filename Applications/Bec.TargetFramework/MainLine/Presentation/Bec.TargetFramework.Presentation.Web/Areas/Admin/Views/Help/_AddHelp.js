﻿$(function () {
    var wizard = $('#addHelpWizard').bootstrapWizard({
        tabClass: 'form-wizard',
        onTabShow: function (tab, navigation, index) {
            var $total = navigation.find('li').length;
            var $current = index + 1;
            if ($current >= $total) {
                $('#stepBack').show();
                $('#stepNext').hide();
                $('#submitAddHelp').show();
                $('#submitAddHelp').removeClass('disabled');
            } else {
                $('#stepBack').hide();
                $('#stepNext').show();
                $('#submitAddHelp').hide();
            }
        }
    });

    //$("#submitAddHelp").click(checkWizardValid(wizard, "#addHelp-form"));

    $("#stepNext").click(function () {
        wizard.bootstrapWizard('next');
    });

    $("#stepBack").click(function () {
        wizard.bootstrapWizard('previous');
    });

    $("#submitAddHelp").click(function () {
        $("#addHelp-form").submit();
    });

    $("#addHelp-form").validate({
        ignore: '.skip',
        // Rules for form validation
        rules: {
            PageType: {
                required: true
            },
            PageName: {
                required: true
            },
            PageUrl: {
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
        $("#submitAddHelp").prop('disabled', true);
        form.submit();
    }

    $('#pageType').on('change', function () {

        var valOfThis = $('#pageType option:selected').val();
        if (valOfThis === "2") {
            $("#tabIdSection").css('display', 'block');
            $("#tourSection").css('display', 'none');
        }
        else {
            if (valOfThis === "3") {
                $("#tabIdSection").css('display', 'none');
                $("#tourSection").css('display', 'block');
                $("#effectiveDateInput").val("");
                $('#EffectiveOn').val("");
            } else {
                $("#tabIdSection").css('display', 'none');
                $("#tourSection").css('display', 'none');
            }
        }

        if (valOfThis === "1" || valOfThis === "2") {
            $("#effectiveDateInput").datepicker('setDate', new Date());
            $('#EffectiveOn').val($("#effectiveDateInput").val());
            $('#EffectiveOn').valid();
        }
    });
});
