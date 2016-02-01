function runPageIntro() {
    console.log('run smh');
    var ajaxOptions = {
        url: "/App/GetSMHItemOnPage",
        data: { pageUrl: window.location.pathname },
        cache: false
    };
    ajaxWrapper(ajaxOptions)
        .then(function (result) {
            //console.log(result.data);
            startSMHOnPage(result.data);
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
        
        //console.log(getPosition(item.ItemPosition));
        steps.push({
            element: item.ItemSelector,
            intro: item.ItemDescription,
            position: getPosition(item.ItemPosition),
            onbeforechange: function (e,t) {
                //if ($(item.ItemSelector) == undefined) { return true; }
                

                if (item.TabContainerId != null) {
                    $('[href=#' + item.TabContainerId + ']').parent().addClass('active');
                    $('#' + item.TabContainerId).addClass('active');
                    var containerId = $('[href=#' + item.TabContainerId + ']').parent().parent().attr('id');
                    $('#' + containerId + '[role=\"tablist\"] li[class~=\"active\"]').removeClass('active');
                    $('.active', $('#' + containerId).parent()).removeClass('active');
                    $('[href=#' + item.TabContainerId + ']').click();
                }

                var isHidden = $(item.ItemSelector).is(':hidden');
                if (isHidden) { $(item.ItemSelector).css('visibility', 'visible'); }
                //if (isHidden) {
                //    return true;
                //}
                //console.log(e);
                //console.log(e,t);
            },

        });


    });
    //console.log(steps);
    return steps;
}

function startSMHOnPage(items) {
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

$(document).ready(function () {
    //@*@if (Bec.TargetFramework.Presentation.Web.App_Helpers.IntroHelper.IsFirstLogin)
    //{
    //    Bec.TargetFramework.Presentation.Web.App_Helpers.IntroHelper.IsFirstLogin = false;
    //   @Html.Raw("startSysIntro();");
    //}*@

});
