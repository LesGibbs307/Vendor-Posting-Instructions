/*eslint-disable */

window.startCountdown = function (seconds, elem) {
    var content = $(elem).text("Will go back to home page in " + seconds + " seconds.");

    if (seconds == 0) {
        clearTimeout(timer);
        window.location.replace("../");
    }

    seconds--;
    var timer = setTimeout('startCountdown(' + seconds + ',"' + elem + '")', 1000);
};