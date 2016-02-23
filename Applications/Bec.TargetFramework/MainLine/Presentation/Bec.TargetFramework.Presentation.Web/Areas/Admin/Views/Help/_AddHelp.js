$(function () {
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
});
