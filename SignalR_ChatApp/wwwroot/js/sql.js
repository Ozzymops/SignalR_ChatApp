"use strict";

document.getElementById("addButton").addEventListener("click", function (event) {
    // Do SQL stuff
    var name = document.getElementById("nameInput").value;
    var username = document.getElementById("usernameInput").value;
    var password = document.getElementById("passwordInput").value;
    addUser(name, username, password);
});

// Simple POST
function addUser(name, username, password) {
    $.ajax({
        url: "Sql/SaveUser",
        type: "POST",
        data: { name: name, username: username, password: password },
        success: function (response) {
            response ? alert(response) : alert(response);
        }
    });
}