﻿let students = [];
let connection = null;

getData();
setupSignalR();

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:3736/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("StudentCreated", (user, message) => {
        getData();
    });
    connection.on("StudentDeleted", (user, message) => {
        getData();
    });

    connection.onclose(async () => {
            await start();
    });
    start();

}

async function getData() {

    await fetch('http://localhost:3736/Student')
        .then(x => x.json())
        .then(y => {
            students = y;
            display();
        });
}

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};


function display() {
    document.getElementById('resultarea').innerHTML = "";
    students.forEach(t => {
       
       if (t.quidditch_player == true) {

            document.getElementById('resultarea').innerHTML +=
                "<tr><td>" + t.name + "</td><td>"
                + t.id + "</td>" + "<td>" + "Quidditch Player" + "<td>"+ `<button id="deleteBtn" type="button" onclick="remove(${ t.id })">Delete</button>`+"</td></tr>";
        }
       else {
            document.getElementById('resultarea').innerHTML +=
                "<tr><td>" + t.name + "</td><td>"
                + t.id + "</td>" + "<td>" + " - " + "<td>" + `<button id="deleteBtn" type="button" onclick="remove(${t.id})">Delete</button>` + "</td></tr>";
        }
        console.log(t.name);
        
    })
}



function create() {
    let name = document.getElementById('studentname').value;
    fetch('http://localhost:3736/Student/', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            {
                name: name
            })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => {
            console.error('Error:', error);
        });
}

function remove(id) {
    fetch('http://localhost:3736/Student/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}