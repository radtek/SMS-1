var Tour = (function () {
    function startCallout() {
        ajaxWrapper({
            url: '/app/viewrendercallout',
            type: "Post"
        }).done(function (res) {
            if (res.result === true && res.callOuts != null && res.callOuts.length > 0) {
                var stepList = getStepCallouts(res.callOuts);
                var intro = introJs();
                startIntro(stepList, intro);
            }
        });
    }
    function getStepCallouts(callouts) {
        var step = [];
        if (callouts != null && callouts.length > 0) {
            for (var i = 0; i < callouts.length; i++) {
                if ($(callouts[i].Selector).length > 0) {
                    step.push({
                        element: callouts[i].Selector,
                        intro: '<div class="modal-header" style="padding: 5px !important;"><h4 class="modal-title"  style="font-size:15px">' + callouts[i].Title + '</h4></div><div class="modal-body"  style="padding: 5px !important;">' + callouts[i].Description + '</div>',
                        position: getPosition(callouts[i].Position)
                    });
                }
            }

            step.filter(function (obj) {
                return $(obj.element).length;
            });
        }
        return step;
    }

    var startTour = function () {
        var ajaxOptions = {
            url: "/App/GetTourItem",
            cache: false
        };
        ajaxWrapper(ajaxOptions)
            .done(function (result) {
                if (result.data !== undefined && result.data.length > 0) {
                    var stepList = getSteps(result.data).filter(function (obj) {
                        return $(obj.element).length;
                    });
                    var intro = introJs();
                    startIntro(stepList, intro);
                }
            });
    }

    function getSteps(items) {
        var steps = [];
        $.each(items, function (i, item) {
            steps.push({
                element: item.Selector,
                intro: '<div class="modal-header" style="padding: 5px !important;"><h4 class="modal-title"  style="font-size:15px">' + item.Title + '</h4></div><div class="modal-body"  style="padding: 5px !important;">' + item.Description + '</div>',
                position: getPosition(item.Position)
            });
        });
        return steps;
    }

    function startIntro(stepList, intro) {
        var elementHidden = "";
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

            intro.oncomplete(function () {
                if (elementHidden !== "") {
                    $(elementHidden).closest('ul').removeAttr("style");
                    elementHidden = "";
                }
                if ($('#firstLogin').data("callout-autorun") === "False") {
                    $('#firstLogin').data("callout-autorun", "True");
                    checkStartCallout();
                }
            });
            intro.onexit(function () {
                if (elementHidden !== "") {
                    $(elementHidden).closest('ul').removeAttr("style");
                    elementHidden = "";
                }
                if ($('#firstLogin').data("callout-autorun") === "False") {
                    $('#firstLogin').data("callout-autorun", "True");
                    checkStartCallout();
                }
            });
            intro.onchange(function (targetElement) {
                if ($(targetElement).closest('ul').css("display") === 'none') {
                    $(targetElement).closest('ul').css("display", "block");
                    if (elementHidden !== "") {
                        if ($(elementHidden).closest('ul').is($(targetElement).closest('ul'))) {
                        }
                        else {
                            $(elementHidden).closest('ul').removeAttr("style");
                        }
                    }
                    else {
                    }
                    elementHidden = targetElement;
                }
                else {
                    if (elementHidden !== "") {
                        if ($(elementHidden).closest('ul').is($(targetElement).closest('ul'))) {
                            $(elementHidden).closest('ul').css("display", "block");
                        }
                        else {
                            $(elementHidden).closest('ul').removeAttr("style");
                            elementHidden = "";
                        }
                    }
                    else {
                        if ($(targetElement).closest('ul').hasClass('dropdown-menu')) {
                            $(targetElement).closest(".dropdown.open").removeClass("open");
                        }

                    }
                }
            });

            intro.start();
        }
    }


    $('#tour').click(function () {
        startTour();
    });

    function checkStartTour() {
        if ($('#firstLogin').data("welcome") === "True" && $('#firstLogin').data("autorun") === "True") {
            if ($('#firstLogin').data("login") === "True") {
                $('#firstLogin').data("callout-autorun", "False");
            }
            startTour();
        }
    }

    function checkStartCallout() {
        if ($('#firstLogin').data("login") === "True" && $('#firstLogin').data("callout-autorun") === "True") {
            startCallout();
        }
    }

    $(document).ready(function () {
        checkStartTour();
        checkStartCallout();
    });

    return {
        startTour: startTour
    }
})();