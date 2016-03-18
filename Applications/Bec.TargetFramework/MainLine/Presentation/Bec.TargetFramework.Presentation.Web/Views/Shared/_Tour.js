$(function () {
    'use strict';

    var helpPromises;

    setHelpPromises();

    $("#tourButton").click(function () {
        $.ajax({
            url: ($("#tourDisplay").attr('data-getHelpItems')),
            type: 'GET',
            success: function (data) {
                var steps = getStepsFromJson(data.Items);
                startHelp("Tour",steps,null);
            }
        });
    });


    $("#showMeHowButton").click(function () {
        var uiPageUrl = window.location.pathname;

        $.ajax({ 
            url: ($("#tourDisplay").attr('data-gethelpitemsSMH')) + "&uiPageUrl=" + uiPageUrl,
            type: 'GET',
            success: function (data) {
                var steps = getStepsFromJson(data.Items);
                startHelp("Tour",steps,null);
            }
        });
    });

    $("#showCalloutButton").click(function () {
        $.ajax({
            url: ($("#tourDisplay").attr('data-gethelpitemsCallout')),
            type: 'GET',
            success: function (data) {
                var steps = getStepsFromJsonForCallouts(data.Items);
                startHelp("Callout",steps,480);
            }
        });
    });

    function getStepsFromJson(jsonDataItems)
    {
        var steps = [];
        var totalItems = jsonDataItems.length;
        $.each(jsonDataItems, function (i, item) {

            steps.push({
                target: item.UiSelector,
                title: item.Title,
                content: item.Description,
                placement: item.UiPositionName.toLowerCase(),
                delay: 500,
                totalItems: totalItems,
                onBindTarget: function() {
                    console.log(item.UiSelector + " onBindTarget");
                    if ($(item.UiSelector).closest('ul').hasClass('dropdown-menu')) {
                        if ($(item.UiSelector).closest('ul').css("display") === 'none')
                            $(item.UiSelector).closest('ul').dropdown('toggle');
                    } else if ($(item.UiSelector).closest('ul').hasClass('nav-tabs'))
                        if (!$(item.UiSelector).closest('li').hasClass('active'))
                            $(item.UiSelector).closest('a').trigger('click');
                },
                onNext: function() {
                    console.log(item.UiSelector + " onNext");
                    if ($(item.UiSelector).closest('ul').hasClass('dropdown-menu')) {
                        if ($(item.UiSelector).closest('ul').css("display") === 'block')
                            $(item.UiSelector).closest('ul').dropdown('toggle');
                    } else if ($(item.UiSelector).closest('ul').hasClass('nav-tabs'))
                        if ($(item.UiSelector).closest('li').hasClass('active'))
                            $(item.UiSelector).closest('a').trigger('click');
                },
                onPrev: function() {
                    console.log(item.UiSelector + " onPrev");
                    if ($(item.UiSelector).closest('ul').hasClass('dropdown-menu')) {
                        if ($(item.UiSelector).closest('ul').css("display") === 'block')
                            $(item.UiSelector).closest('ul').dropdown('toggle');
                    } else if ($(item.UiSelector).closest('ul').hasClass('nav-tabs'))
                        if ($(item.UiSelector).closest('li').hasClass('active'))
                            $(item.UiSelector).closest('a').trigger('click');
                }
            });
        });

        return steps;
    }

    function getStepsFromJsonForCallouts(jsonDataItems) {
        var steps = [];

        $.each(jsonDataItems, function (i, item) {
            steps.push({
                target: 'aside#left-panel',
                title: item.Title,
                content: item.Description,
                placement: 'right',
                yOffset: 70,
                totalItems: jsonDataItems.length,
                onBindTarget: function() {
                },
                onNext: function() {
                    // mark as viewed
                    $.ajax({
                        url: ($("#tourDisplay").attr('data-calloutasviewed')) + "?helpItemID=" + item.HelpItemID,
                        type: 'GET',
                        success: function(data) {
                        }
                    });
                }
            });
        });

        return steps;
    }

    function startHelp(helpType,stepList,width) {
        if (stepList.length > 0) {
            var helpProcess = {
                id: "boo",
                steps: stepList,
                showPrevButton: true,
                isTourButton: true,
                width: width
            };

            if (width != null)
                helpProcess.bubbleWidth = width;

            setHopscotchRenderer(helpType);
            hopscotch.startTour(helpProcess);
        }
    }

    function setHopscotchRenderer(helpType)
    {
        hopscotch.setRenderer(function (data) {
            var html;
            helpPromises.helptype[helpType].done(function (template) {
                html = template(data);
            });
            return html;
        });
    }

    function setHelpPromises()
    {
        helpPromises = new defTmplWithNoContent($("#tourDisplay").data("templateurl"), "/Views/Shared/HelpTemplates/",
            ['helptype'],
            [
                { name: 'Tour', description: 'Tour'},
                 { name: 'Callout', description: 'Callout'}
            ]
        );
    }
});