var timeSync = {};
timeSync.debug = false;
timeSync.url = "";
timeSync.httpMethod = "GET";
timeSync.dataType = "json";
timeSync.contentType = "application/json; charset=utf-8";

timeSync.getTimeDifference = function () {

    timeSync.clientTime = new Date();
    timeSync.timeDifference = 0;
    timeSync.roundTrip = 0;
    timeSync.roundTripStart = new Date();
    timeSync.serverTime = null;

    return $.ajax({
        type: timeSync.httpMethod,
        url: timeSync.url,
        dataType: timeSync.dataType,
        contentType: timeSync.contentType,
        success: function (data) {

            timeSync.roundTrip = new Date().getTime() - timeSync.roundTripStart.getTime();

            timeSync.serverTime = new Date(data);

            timeSync.timeDifference = (timeSync.serverTime.getTime() - timeSync.roundTrip) - timeSync.clientTime.getTime();

            if (timeSync.debug) {

                document.write("Server time:" + timeSync.serverTime.getTime());
                document.write("<br/>Client time: " + timeSync.clientTime.getTime());
                document.write("<br/>Roundtrip: " + timeSync.roundTrip);
                document.write("<br/>Time diff: " + timeSync.timeDifference);
            }

            return timeSync.timeDifference;
        },
        async: false
    });
}