$(function () {
    var wizard = $('#addHelpWizard').bootstrapWizard({
        tabClass: 'form-wizard',
        onTabClick: function() {
            return $("#addHelp-form").valid();
        },
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
    
    $("#stepNext").click(function () {
        if ($("#addHelp-form").valid()) {
            wizard.bootstrapWizard('next');
        }
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
        $("#PageName").css('background-color', 'rgba(218, 218, 218, 1)');
        $('#pageUrlSection').css('display', 'none');
    }

    function enablePagefields() {
        $('#PageName').val('');
        $('#PageUrl').val('');
        $("#PageName").prop('disabled', false);
        $("#PageUrl").prop('disabled', false);
        $("#PageName").css('background-color', '#fff');
        $('#pageUrlSection').css('display', 'block');
    }
    function hideTabIdAdnEffectiveOn() {
        $("#tabIdSection").css('display', 'none');
        $("#tourSection").css('display', 'none');
    }

    $('#HelpPageTypeId').on('change', function () {
        var valOfThis = $('#HelpPageTypeId option:selected').val();
        if (valOfThis === "800000") {
            setDefaultEffectiveDate();
            disablePagefields("Tour");
            hideTabIdAdnEffectiveOn();
        } else if (valOfThis === "800001") {
            resetEffectiveDate();
            $("#tabIdSection").css('display', 'none');
            $("#tourSection").css('display', 'block');
            disablePagefields("Callout");
        } else if (valOfThis === "800002") {
            setDefaultEffectiveDate();
            $("#tabIdSection").css('display', 'block');
            $("#tourSection").css('display', 'none');
            enablePagefields();        
        } else {
            resetEffectiveDate();
            enablePagefields();
            hideTabIdAdnEffectiveOn();
        }
    });
});