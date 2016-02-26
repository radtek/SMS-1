//from SmartAdmin template
$(document).ready(function () {
    pageSetUp();
    drawBreadCrumb();

    resetSessionTimeout();
    $.sound_on = false;
});

function resetSessionTimeout() {
    setTimeout(timeoutAlert, 15 * 60 * 1000);
}

function Logout() {
    window.location = $('#logout > a').attr("href");
}

function timeoutAlert() {
    var countdown = 15;
    var logoutTimer = setTimeout(Logout, countdown * 1000);
    $.SmartMessageBox({
        title: "Session Timeout",
        content: "",
        buttons: '[Stay logged in][Log out]'
    }, function (ButtonPressed) {
        if (ButtonPressed === "Stay logged in") {
            clearTimeout(logoutTimer);
            resetSessionTimeout();
        }
        if (ButtonPressed === "Log out") {
            Logout();
        }
    });
    updateMessage(countdown);
}

function updateMessage(val) {
    $('.MessageBoxContainer p.pText').text("In " + val + " second" + (val != 1 ? "s" : "") + " you will be automatically logged out due to a period of inactivity.");
    if (val > 1) setTimeout(updateMessage, 1000, val - 1);
}