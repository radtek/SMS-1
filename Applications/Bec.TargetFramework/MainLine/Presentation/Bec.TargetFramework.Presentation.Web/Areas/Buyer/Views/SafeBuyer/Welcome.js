$(function () {
    $('#messageButton').click(function () {
        $('#firstLogin').data("autorun", 'True');
        Tour.startTour();
    });    
})