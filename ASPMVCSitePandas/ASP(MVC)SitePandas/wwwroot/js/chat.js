"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

//Disable the send button until connection is established.
document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (message, date, role) {
    let li = document.createElement("li");
    document.getElementById("messagesList").appendChild(li);
    let dateFormat = date.replace("T", " ").replace(/\..+/, "");
    let name = receiveName();
    let nameArray = name.split("|");
    if (role == "E") {
        li.innerHTML = `${nameArray[0]} : ${message}<br>${dateFormat}`;
    }
    else {
        li.innerHTML = `${nameArray[1]} : ${message}<br>${dateFormat}`;
    }
    
});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    let userE = document.getElementById("educatriceId").innerText;
    let userR = document.getElementById("repondantId").innerText;
    let role = document.getElementById("userRole").innerText;
    let message = document.getElementById("messageInput").value;
    connection.invoke("SendMessage", userE, userR, role, message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});