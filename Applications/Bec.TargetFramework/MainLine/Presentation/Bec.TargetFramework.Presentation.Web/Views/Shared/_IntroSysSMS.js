function runSystemIntro() {
    //console.log('run sys smh');
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

function getSteps(items) {
    var steps = [];
    $.each(items, function (i, item) {
        steps.push({
            element: item.ItemSelector,
            intro: '<div class="modal-header" style="padding: 5px !important;"><h4 class="modal-title"  style="font-size:15px">' + 'The title of this' + '</h4></div><div class="modal-body"  style="padding: 5px !important;">' + item.ItemDescription + '</div><div class="modal-footer"  style="padding: 5px !important;"></div>',
            position: getPosition(item.ItemPosition),
        });
    });
    return steps;
}

function startSysSMH(items) {
    var intro = introJs();
    var stepList = getSteps(items).filter(function (obj) {
        return $(obj.element).length;
    });
    var elementHidden = "";
    if (stepList.length > 0) {

        intro.setOptions({
            exitOnOverlayClick: false,
            showProgress: false,
            showBullets: false,
            showStepNumbers: false,
            scrollToElement: false,
            disableInteraction: false,
            overlayOpacity: 0.1,
            steps: stepList
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
}