"use strict";

// Todo remove debug button, should be triggered by a change in HTML table

// If publishing, change the .withUrl("\pcdev/pchub")
// todo fix IIS Express WithURL and Publish WithURL difference
var connection = new signalR.HubConnectionBuilder()
    .configureLogging(signalR.LogLevel.Debug)
    .withUrl("\pchub")
    .build();

// todo: Disable UI components until connection established

connection.on("SendBoard", function (board) {
    console.log("Server board: " + board);
    updateGrid(board);
});

connection.on("ServerMsg", function (msg) {
    console.log("Server message: " + msg);
});

connection.start().then(function () {
    console.log("Client: connection init");
}).catch(function (err) {
    return console.error(err.toString());
});

function setCell(color, row, col) {
    color = color.substring(1);
    console.log("Client: SetCell " + color + " " + row + "," + col);
    connection.invoke("SetCell", color, row, col).catch(function (err) {
        return console.error(err.toString());
    });
}

function advanceGame() {
    console.log("Client: NextState");
    connection.invoke("NextState").catch(function (err) {
        return console.error(err.toString());
    });
}

function startGame() {
    startTimer(2);
}

function pauseGame() {
    stopTimer();
}

// todo allow setAuto to false with no seconds arg
function startTimer(seconds) {
    console.log("Client: StartTimer " + seconds);
    connection.invoke("StartTimer", seconds).catch(function (err) {
        return console.error(err.toString());
    });
}

function stopTimer() {
    console.log("Client: StopTimer");
    connection.invoke("StopTimer").catch(function (err) {
        return console.error(err.toString());
    });
}

function clearBoard() {
    console.log("Client: ClearBoard");
    connection.invoke("ClearBoard").catch(function (err) {
        return console.error(err.toString());
    });
}