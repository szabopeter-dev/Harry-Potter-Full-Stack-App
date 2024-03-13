let subjects = [];
let connection = null;

let subjectIdToUpdate = -1;

getData();
setupSignalR();

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:3736/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("SubjectCreated", (user, message) => {
        getData();
    });
    connection.on("SubjectDeleted", (user, message) => {
        getData();
    });
    connection.on("SubjectUpdated", (user, message) => {
        getData();
    });

    connection.onclose(async () => {
        await start();
    });
    start();

}

async function getData() {

    await fetch('http://localhost:3736/Subject')
        .then(x => x.json())
        .then(y => {
            subjects = y;
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
    subjects.forEach(t => {

        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.subject_Name +
            "</td><td>" + t.id + "</td><td>" +
            `<button id="deleteBtn" type="button" onclick="remove(${t.id})">Delete</button>` +
            `<button id="updateBtn" type="button" onclick="showupdate(${t.id})">Update</button>` +
            "</td></tr>";

        console.log(t);

    })
}



function create() {
    let name = document.getElementById('subjectname').value;
    fetch('http://localhost:3736/Subject/', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            {
                subject_Name: name,
               
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
    fetch('http://localhost:3736/Subject/' + id, {
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

function update() {
    document.getElementById('updateformdiv').style.display = 'none';
    let name = document.getElementById('subjectnameToupdate').value;
    fetch('http://localhost:3736/Subject/', {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            {
                subject_Name: name,
                Id: subjectIdToUpdate,


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
function showupdate(id) {
    document.getElementById('subjectnameToupdate').value = subjects.find(t => t['id'] == id)['subject_Name'];
    document.getElementById('updateformdiv').style.display = 'flex';
    subjectIdToUpdate = id;
}