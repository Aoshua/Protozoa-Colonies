"use strict";

// Todo remove debug button, should be triggered by a change in HTML table

var connection = new signalR.HubConnectionBuilder().withUrl("/pchub").build();

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
    setAuto(true, 2);
}

function pauseGame() {
    setAuto(false, 2);
}

// todo allow setAuto to false with no seconds arg
function setAuto(auto, seconds) {
    console.log("Client: SetAuto " + auto + " " + seconds);
    connection.invoke("SetAuto", auto, seconds).catch(function (err) {
        return console.error(err.toString());
    });
}

function clearBoard() {
    console.log("Client: ClearBoard");
    connection.invoke("ClearBoard").catch(function (err) {
        return console.error(err.toString());
    });
}