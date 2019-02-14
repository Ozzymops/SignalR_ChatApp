"use strict";

// Create and start connection
var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

// Other variables
var currentRoom = 0;

// Disable stuff until connection is established
document.getElementById("sendButton").disabled = true;
document.getElementById("messageInput").disabled = true;

// MESSAGES
// Receive message from Hub
connection.on("ReceiveMessage", function (user, message, room) {
    if (room == currentRoom) {
        var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
        var encodedMsg = "R" + room + ": " + user + " - " + msg;
        var li = document.createElement("li");
        li.textContent = encodedMsg;
        document.getElementById("messagesList").appendChild(li);
    }
});

// Send message to Hub
document.getElementById("sendButton").addEventListener("click", function (event) {
    var user = document.getElementById("userInput").value;
    var message = document.getElementById("messageInput").value;
    var room = document.getElementById("roomInput").value;
    connection.invoke("SendMessage", user, message, room).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});

// ROOM
// Join a room
document.getElementById("roomButton").addEventListener("click", function (event) {
    currentRoom = document.getElementById("roomInput").value;
    var li = document.createElement("li");
    var user = document.getElementById("userInput").value;

    if (user == "") {
        return console.error("Please enter a username.");
    }

    document.getElementById("userInput").disabled = true;
    document.getElementById("roomButton").disabled = true;
    document.getElementById("leaveButton").disabled = false;

    li.textContent = "Joining room " + document.getElementById("roomInput").value + "...";
    document.getElementById("messagesList").appendChild(li);
    connection.invoke("JoinMessage", user, currentRoom).catch(function (err) {
        var li = document.createElement("li");
        li.textContent = "Failed to join room " + document.getElementById("roomInput").value;
        document.getElementById("messagesList").appendChild(li);
        currentRoom = 0;
        document.getElementById("userInput").disabled = false;
        document.getElementById("roomButton").disabled = false;
        document.getElementById("leaveButton").disabled = true;
        return console.error(err.toString());
    });
    event.preventDefault();
});

// Receive room message
connection.on("RoomMessage", function (user, room) {
    if (room == currentRoom) {
        var li = document.createElement("li");
        li.textContent = "R" + room + ": " + user + " has joined the room.";
        document.getElementById("messagesList").appendChild(li);
    }
});

// Leave room
document.getElementById("leaveButton").addEventListener("click", function (event) {
    var oldRoom = currentRoom;
    var user = document.getElementById("userInput").value;
    currentRoom = 0;
    connection.invoke("LeaveMessage", user, oldRoom).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();

    var li = document.createElement("li");
    li.textContent = "Left room " + oldRoom;
    document.getElementById("messagesList").appendChild(li);
    document.getElementById("userInput").disabled = false;
    document.getElementById("roomButton").disabled = false;
    document.getElementById("leaveButton").disabled = true;
});

// Receive leave message
connection.on("LeaveMessage", function (user, room) {
    if (room == currentRoom) {
        var li = document.createElement("li");
        li.textContent = "R" + room + ": " + user + " has left the room.";
        document.getElementById("messagesList").appendChild(li);
    }
});

// Check if connected (?)
connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
    document.getElementById("messageInput").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

// Clear messages
document.getElementById("deleteButton").addEventListener("click", function (event) {
    document.getElementById("messagesList").innerHTML = "";
});