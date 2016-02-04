$(function () {
    $('#smh').click(function () {
        runPageIntro();
    })

    function runPageIntro() {
        var ajaxOptions = {
            url: "/App/GetSmhItemOnPage",
            data: { pageUrl: window.location.pathname },
            cache: false
        };
        ajaxWrapper(ajaxOptions)
            .then(function (result) {
                startSMHOnPage(result.data);
            }, function (data) {
                console.log("ERR");
            });
    }

    function getSteps(items) {
        var steps = [];
        $.each(items, function (i, item) {
            steps.push({
                element: item.ItemSelector,
                intro: item.ItemDescription,
                position: getPosition(item.ItemPosition),
                onbeforechange: function (e, t) {
                    if (item.TabContainerId != null) {
                        $('[href=' + item.TabContainerId + ']').parent().addClass('active');
                        $(item.TabContainerId).addClass('active');
                        var containerId = $('[href=' + item.TabContainerId + ']').parent().parent().attr('id');
                        $('#' + containerId + '[role=\"tablist\"] li[class~=\"active\"]').removeClass('active');
                        $('.active', $('#' + containerId).parent()).removeClass('active');
                        $('[href=' + item.TabContainerId + ']').click();
                    }
                },
            });
        });
        return steps;
    }

    function startSMHOnPage(items) {
        var intro = introJs();
        var stepList = getSteps(items).filter(function (obj) {
            return $(obj.element).length;
        });
        if (stepList.length > 0) {

            intro.setOptions({
                exitOnOverlayClick: false,
                showProgress: false,
                showBullets: false,
                showStepNumbers: false,
                scrollToElement: false,
                disableInteraction: false,
                steps: stepList
            });

            var createStepEvents = function (guideObject, eventList) {
                _.each(eventList, function (event) {
                    guideObject[event](function () {
                        var steps = this._options.steps,
                            currentStep = this._currentStep;
                        if (_.isFunction(steps[currentStep][event])) {
                            steps[currentStep][event]();
                        }
                    });

                }, this);
            }

            createStepEvents(intro, ['onbeforechange']);
            var tempShow = false;
            var tempElement = null;

            intro.start();
        }
    }
});