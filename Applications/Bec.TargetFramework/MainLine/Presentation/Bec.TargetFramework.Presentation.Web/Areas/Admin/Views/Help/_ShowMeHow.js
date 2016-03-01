$(function () {
    $('#smh').click(function () {
        runPageIntro();
    });

    function runPageIntro() {
        var ajaxOptions = {
            url: "/App/GetSmhItemOnPage",
            data: { pageUrl: window.location.pathname },
            cache: false
        };
        ajaxWrapper(ajaxOptions)
            .done(function (result) {
                if (result.data !== undefined && result.data.length > 0) {
                    startSMHOnPage(result.data);
                }
            });
    }

    function getSteps(items) {
        var steps = [];
        $.each(items, function (i, item) {
            steps.push({
                element: item.Selector,
                intro: '<div class="modal-header" style="padding: 5px !important;"><h4 class="modal-title"  style="font-size:15px">' + item.Title + '</h4></div><div class="modal-body"  style="padding: 5px !important;">' + item.Description + '</div>',
                position: getPosition(item.Position),
                tabId: item.TabContainerId
            });
        });
        return steps;
    }
    function checkStart(intro) {
        if (intro._options.steps.length > 0) {
            var item0 = intro._options.steps[0];

            var SelectedTabHeader = undefined;
            var SelectedTab = undefined;
            var isChanged = false;

            if (item0.tabId !== undefined) {

                var containerId = $('[href=' + item0.tabId + ']').parent().parent().attr('id');
                var e1 = $('#' + containerId + '[role=\"tablist\"] li[class~=\"active\"]');
                var e2 = $('[href=' + item0.tabId + ']').parent();

                if (!e1.is(e2)) {
                    $('[href=' + item0.tabId + ']').parent().addClass('active');
                    $(item0.tabId).addClass('active');

                    SelectedTabHeader = $('#' + containerId + '[role=\"tablist\"] li[class~=\"active\"]');
                    SelectedTab = $('.active', $('#' + containerId).parent());
                    $('#' + containerId + '[role=\"tablist\"] li[class~=\"active\"]').removeClass('active');
                    $('.active', $('#' + containerId).parent()).removeClass('active');
                    $('[href=' + item0.tabId + ']').click();

                    isChanged = true;
                }
            }

            var isVisible = $(item0.element).is(":visible");

            if (!isVisible) {
                if (isChanged && SelectedTabHeader !== undefined && SelectedTab !== undefined) {
                    SelectedTabHeader.addClass('active');
                    SelectedTab.addClass('active');
                    $('[href=' + item0.tabId + ']').parent().removeClass('active');
                    $(item0.tabId).removeClass('active');
                }
                intro._options.steps.splice(0, 1);
                checkStart(intro);
            } else {
                intro.goToStep(1).start().onbeforechange(function () {

                    var item = intro._introItems[intro._currentStep];
                    var wait = true;
                    if (item.tabId !== undefined) {
                        var containerId = $('[href=' + item.tabId + ']').parent().parent().attr('id');
                        var e1 = $('#' + containerId + '[role=\"tablist\"] li[class~=\"active\"]');
                        var e2 = $('[href=' + item.tabId + ']').parent();
                        if (!e1.is(e2)) {
                            $('[href=' + item.tabId + ']').parent().addClass('active');
                            $(item.tabId).addClass('active');

                            $('#' + containerId + '[role=\"tablist\"] li[class~=\"active\"]').removeClass('active');
                            $('.active', $('#' + containerId).parent()).removeClass('active');
                            $('[href=' + item.tabId + ']').click();
                        }
                    }

                    var isVisible = $(item.element).is(":visible");
                    
                    if (!isVisible) {
                        intro.nextStep();
                        introJs().refresh().setOptions(intro._options);
                    }
                });
            }
        }
    }
    function startSMHOnPage(items) {
        var intro = introJs();
        var stepList = getSteps(items).filter(function (obj) {
            return $(obj.element).length;
        });
        if (stepList.length > 0) {

            intro.setOptions({
                skipLabel: 'Close',
                exitOnOverlayClick: false,
                showProgress: false,
                showBullets: true,
                showStepNumbers: false,
                scrollToElement: false,
                disableInteraction: true,
                overlayOpacity: 0.1,
                steps: stepList
            });
            checkStart(intro);
        }
    }
});