$(function () {
    function getCallout() {
        ajaxWrapper({
            url: '/app/viewrendercallout',
            type: "Post"
        }).done(function (res) {
            if (res.result === true && res.callOuts != null && res.callOuts.length > 0) {
                startIntro(res.callOuts);
            }
        })
    }
    function getStepCallouts(callouts) {
        var step = [];
        if (callouts != null && callouts.length > 0) {
            step.push({
                intro: '<div class="modal-header" style="padding: 5px !important;"><h4 class="modal-title" style="font-size:15px">There are some changes in this version</h4></div><div class="modal-body"  style="padding: 5px !important;">Click next to see details</div><div class="modal-footer"  style="padding: 5px !important;"></div>',
                position: 'top'
               
            })
            for (i = 0; i < callouts.length; i++) {
                if ($(callouts[i].Selector).length > 0) {
                    step.push({
                        element: callouts[i].Selector,
                        intro: '<div class="modal-header" style="padding: 5px !important;"><h4 class="modal-title"  style="font-size:15px">' + callouts[i].Title + '</h4></div><div class="modal-body"  style="padding: 5px !important;">' + callouts[i].Description + '</div><div class="modal-footer"  style="padding: 5px !important;"></div>',
                        position: getPosition(callouts[i].Position)
                    })
                }
            }
        }
        return step;
    }
    var elementHidden = "";
    function startIntro(callouts) {
        var intro = introJs();
        intro.setOptions({
            showStepNumbers: false, disableInteraction: true, exitOnOverlayClick: false, skipLabel: 'Close',
            overlayOpacity: 0.1,
            steps: getStepCallouts(callouts)
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

    getCallout();

});
