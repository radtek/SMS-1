﻿function runSystemIntro() {
    console.log('run sys smh');
    var ajaxOptions = {
        url: "/App/GetSystemSmhItem",
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
        steps.push({
            element: item.ItemSelector,
            intro: item.ItemDescription,
            position: getPosition(item.ItemPosition),
        });
    });
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

    intro.oncomplete(function () {
        if (elementHidden != "") {
            $(elementHidden).closest('ul').css("display", "none");
            elementHidden = "";
        }
    });
    intro.onexit(function () {
        if (elementHidden != "") {
            $(elementHidden).closest('ul').css("display", "none");
            elementHidden = "";
        }
    });
    intro.onchange(function (targetElement) {
        if ($(targetElement).closest('ul').css("display") == 'none') {
            $(targetElement).closest('ul').css("display", "block");
            elementHidden = targetElement;
        }
        else {
            if (elementHidden != "") {
                if ($(elementHidden).closest('ul').is($(targetElement).closest('ul'))) {
                    $(elementHidden).closest('ul').css("display", "block");
                }
                else {
                    $(elementHidden).closest('ul').css("display", "none");
                    elementHidden = "";
                }
            }
        }
    });
    intro.start();
}
