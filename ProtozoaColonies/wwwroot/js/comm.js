"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/pchub").build();

//Disable send button until connection is established
document.getElementById("sendButton").disabled = true;

connection.on("SendBoard", function (user, message) {
    // access DOM to update board
});

connection.start().then(function () {
    document.getElementById("actionBtn").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("actionBtn").addEventListener("click", function (event) {
    var color = "red";
    var x = 2;
    var y = 7;

    console.log("actionBtn pressed");

    connection.invoke("SetCell", color, x, y).catch(function (err) {
        return console.error(err.toString());
    });

    event.preventDefault();
});