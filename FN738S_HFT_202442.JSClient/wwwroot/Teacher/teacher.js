let teachers = [];
let connection = null;

let teacherIdToUpdate = -1;

getData();
setupSignalR();

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:3736/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("TeacherCreated", (user, message) => {
        getData();
    });
    connection.on("TeacherDeleted", (user, message) => {
        getData();
    });
    connection.on("TeacherUpdated", (user, message) => {
        getData();
    });

    connection.onclose(async () => {
        await start();
    });
    start();

}

async function getData() {

    await fetch('http://localhost:3736/Teacher')
        .then(x => x.json())
        .then(y => {
            teachers = y;
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
    teachers.forEach(t => {

       
            document.getElementById('resultarea').innerHTML +=
                "<tr><td>" + t.name + "</td><td>"
                + t.id + "</td>" + "<td>" +
                `<button id="deleteBtn" type="button" onclick="remove(${t.id})">Delete</button>` +
                `<button id="updateBtn" type="button" onclick="showupdate(${t.id})">Update</button>` +
                "</td></tr>";
        
       
          
        console.log(t);

    })
}



function create() {
    let name = document.getElementById('teachername').value;
    fetch('http://localhost:3736/Teacher/', {
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
    fetch('http://localhost:3736/Teacher/' + id, {
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
    let name = document.getElementById('teachernameToupdate').value;
    fetch('http://localhost:3736/Teacher/', {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            {
                name: name,
                Id: teacherIdToUpdate
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
    document.getElementById('teachernameToupdate').value = teachers.find(t => t['id'] == id)['name'];
    document.getElementById('updateformdiv').style.display = 'flex';
    teacherIdToUpdate = id;
}