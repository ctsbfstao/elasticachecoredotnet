(function() {
    var counter = 11;
    var interval = setInterval(function () {
        counter--;
        // Display 'counter' wherever you want to display it.
        $('#timerSpan').text(counter);
        if (counter == 0) {
            // Display a login box
            clearInterval(interval);
        }
    }, 1000);
}());

