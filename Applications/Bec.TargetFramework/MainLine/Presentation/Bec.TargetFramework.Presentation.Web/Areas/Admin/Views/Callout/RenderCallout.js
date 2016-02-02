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
    $(document).ready(function () {
        getCallout();
    })

    function getStepCallouts(callouts) {
        var step = [];
        if (callouts != null && callouts.length > 0) {
            step.push({
                intro: "<h4>There are some changes in this version</h4>. <p> Click next to see details",
            })
            for (i = 0; i < callouts.length; i++) {
                if ($(callouts[i].Selector).length > 0) {
                    step.push({
                        element: callouts[i].Selector,
                        intro: '<h4>' + callouts[i].Title + '</h4><p>' + callouts[i].Description + '</p>',
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
            showStepNumbers: false, overlayOpacity: 0.3,
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

   
});
