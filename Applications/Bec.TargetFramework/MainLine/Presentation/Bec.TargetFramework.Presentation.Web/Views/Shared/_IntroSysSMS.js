function runSystemIntro() {
    console.log('run sys smh');
    var ajaxOptions = {
        url: "/App/GetSystemSMHItem",
        cache: false
    };
    ajaxWrapper(ajaxOptions)
        .then(function (result) {
            //console.log(result.data);
            startSysSMH(result.data);
        }, function (data) {
            console.log("ERR");
        });
}

function getPosition(pos) {
    if (pos == 1) return "right";
    if (pos == 2) return "left";
    if (pos == 3) return "top";
    if (pos == 4) return "bottom";
    return "right";
}

function getSteps(items) {
    var steps = [];
    $.each(items, function (i, item) {
        //console.log(item.ItemSelector);

        steps.push({
            element: item.ItemSelector,
            intro: item.ItemDescription,
            position: getPosition(item.ItemPosition),
            onbeforechange: function (e, t) {
                //if (item.TabContainerId != null) {
                //    $('[href=#' + item.TabContainerId + ']').parent().addClass('active');
                //    $('#' + item.TabContainerId).addClass('active');
                //    var containerId = $('[href=#' + item.TabContainerId + ']').parent().parent().attr('id');
                //    $('#' + containerId + '[role=\"tablist\"] li[class~=\"active\"]').removeClass('active');
                //    $('.active', $('#' + containerId).parent()).removeClass('active');
                //    $('[href=#' + item.TabContainerId + ']').click();
                //}

                //var isHidden = $(item.ItemSelector).is(':hidden');
                //if (isHidden) { $(item.ItemSelector).css('visibility', 'visible'); }
            },
        });
    });
    //console.log(steps);
    return steps;
}

function startSysSMH(items) {
    var intro = introJs();
    intro.setOptions({
        exitOnOverlayClick: false,
        showProgress: false,
        showBullets: false,
        showStepNumbers: false,
        scrollToElement: false,
        disableInteraction: false,
        steps: getSteps(items).filter(function (obj) {
            return $(obj.element).length;
        })
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
