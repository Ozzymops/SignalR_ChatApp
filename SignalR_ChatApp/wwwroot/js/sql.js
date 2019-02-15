"use strict";

document.getElementById("addButton").addEventListener("click", function (event) {
    // Do SQL stuff
    var name = document.getElementById("nameInput").value;
    addUser(name);
});

// Simple POST
function addUser(name) {
    $.ajax({
        url: 'Sql/SaveUser?name=' + name,
        type: "POST",
        success: function (response) {
            response ? alert(response) : alert(response);
        }
    });
}