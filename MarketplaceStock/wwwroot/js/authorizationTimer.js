var totalTime = 3 * 60 * 1000;

var timer = setInterval(function () {
    totalTime -= 1000;

    var minutes = Math.floor(totalTime / (60 * 1000));
    var seconds = Math.floor((totalTime % (60 * 1000)) / 1000);

    minutes = (minutes < 10 ? "0" : "") + minutes;
    seconds = (seconds < 10 ? "0" : "") + seconds;

    document.getElementById("timer").innerText = minutes + ":" + seconds;

    if (totalTime <= 0) {
        document.getElementById("resendBtn").style.display = "block";
        document.getElementById("timer").style.display = "none";
        clearInterval(timer);
    }
}, 1000);