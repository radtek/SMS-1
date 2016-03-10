$(function () {
    var helpPageTypeList = $("#HelpPageTypeId");
    var wizard = $('#editHelpWizard').bootstrapWizard({
        tabClass: 'form-wizard',
        onTabClick: function () {
            return $("#editHelp-form").valid() && validateAddHelp();
        },
        onTabShow: function (tab, navigation, index) {
            var $total = navigation.find('li').length;
            var $current = index + 1;
            if ($current >= $total) {
                $('#stepBack').show();
                $('#stepNext').hide();
                $('#submitEditHelp').show();
                $('#submitEditHelp').removeClass('disabled');
            } else {
                $('#stepBack').hide();
                $('#stepNext').show();
                $('#submitEditHelp').hide();
            }
        }
    });

    $("#stepNext").click(function () {
        if ($("#editHelp-form").valid() && validateAddHelp()) {
            wizard.bootstrapWizard('next');
        }
    });

    $("#stepBack").click(function () {
        wizard.bootstrapWizard('previous');
    });

    $("#submitEditHelp").click(function () {
        if ($('ul#helpItemListContainer li').length < 1) {
            $('#messageAlert').show();
            return;
        }
        $("#editHelp-form").submit();
    });

    var validator = $("#editHelp-form").validate({
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
        $("#submitEditHelp").prop('disabled', true);
        if (validateAddHelp()) {
            form.submit();
        } else {
            wizard.bootstrapWizard('previous');
        }
    }

    function setDefaultEffectiveDate() {
        $("#effectiveDateInput").datepicker('setDate', new Date());
        $('#EffectiveOn').val($("#effectiveDateInput").val());
    }

    function resetEffectiveDate() {
        $("#effectiveDateInput").val("");
        $('#EffectiveOn').val("");
    }

    function disablePagefields(pageName) {
        $('#PageName').val(pageName);
        $('#PageUrl').val('HomePage');
        $('#hiddenName').val(pageName);
        $('#hiddenUrl').val('HomePage');

        $("#PageName").valid();
        $("#PageUrl").valid();
        $("#PageName").prop('disabled', true);
        $("#PageUrl").prop('disabled', true);
        $('#pageNameSection').css('display', 'none');
        $('#pageUrlSection').css('display', 'none');
    }

    function enablePagefields() {
        $("#PageName").prop('disabled', false);
        $("#PageUrl").prop('disabled', false);
        $('#pageNameSection').css('display', 'block');
        $('#pageUrlSection').css('display', 'block');
    }

    function hideTabIdAdnEffectiveOn() {
        $("#tabIdSection").css('display', 'none');
        $("#tourSection").css('display', 'none');
    }

    function checkType() {
        var valOfThis = $('#HelpPageTypeId option:selected').val();
        if (valOfThis === "800000") {
            setDefaultEffectiveDate();
            disablePagefields("Tour");
            $("#tourRoleList").css('display', 'block');
            hideTabIdAdnEffectiveOn();
        } else if (valOfThis === "800001") {
            resetEffectiveDate();
            $("#tabIdSection").css('display', 'none');
            $("#tourSection").css('display', 'block');
            $("#tourRoleList").css('display', 'none');
            disablePagefields("Callout");
        } else if (valOfThis === "800002") {
            setDefaultEffectiveDate();
            $("#tabIdSection").css('display', 'block');
            $("#tourSection").css('display', 'none');
            $("#tourRoleList").css('display', 'none');
            enablePagefields();
        } else {
            $("#tourRoleList").css('display', 'none');
            resetEffectiveDate();
            enablePagefields();
            hideTabIdAdnEffectiveOn();
        }
    }

    $('#HelpPageTypeId').on('change', function () {
        checkType();
    });

    $(document).ready(function () {
        checkType();
    });

    function handleHelpValidationResult(res) {
        if (res) {
            helpPageTypeList.parent().removeClass("state-error").addClass("state-success");
        } else {
            if (helpPageTypeList.val() === "800002") {
                validator.showErrors({
                    "HelpPageTypeId": "",
                    "PageUrl": "This page URL has already existed"
                });
            } else {
                validator.showErrors({
                    "HelpPageTypeId": "This help has already existed"
                });
            }
        }
        return res;
    }

    function validateAddHelp() {
        var result = false;
        ajaxWrapper({
            url: $("#editHelp-form").data("validate-url"),
            data: {
                helpType: helpPageTypeList.val(),
                helpUrl: $("#PageUrl").val()
            },
            async: false
        }).done(function (res) {
            result = handleHelpValidationResult(res);
        });
        return result;
    }
});
