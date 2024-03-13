let houses = [];
let connection = null;

let houseIdToUpdate = -1;

getData();
setupSignalR();

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:3736/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("HouseCreated", (user, message) => {
        getData();
    });
    connection.on("HouseDeleted", (user, message) => {
        getData();
    });
    connection.on("HouseUpdated", (user, message) => {
        getData();
    });

    connection.onclose(async () => {
        await start();
    });
    start();

}

async function getData() {

    await fetch('http://localhost:3736/House')
        .then(x => x.json())
        .then(y => {
            houses = y;
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
    houses.forEach(t => {

        

        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.house_name +
            "</td><td>" + t.id + "</td><td>" +
            t.house_points + "</td><td>" +
            `<button id="deleteBtn" type="button" onclick="remove(${t.id})">Delete</button>` +
            `<button id="updateBtn" type="button" onclick="showupdate(${t.id})">Update</button>` +
            "</td></tr>";
       
        console.log(t);

    })
}



function create() {
    let name = document.getElementById('housename').value;
    let points = document.getElementById('housepoints').value;
    fetch('http://localhost:3736/House/', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            {
                house_name: name,
                house_points : points
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
    fetch('http://localhost:3736/House/' + id, {
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
    let name = document.getElementById('housenameToupdate').value;
    let points = document.getElementById('housepointsToupdate').value;
    fetch('http://localhost:3736/House/', {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            {
                house_name: name,
                Id: houseIdToUpdate,
                house_points: points
               

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
    document.getElementById('housenameToupdate').value = houses.find(t => t['id'] == id)['house_name'];
    document.getElementById('housepointsToupdate').value = houses.find(t => t['id'] == id)['house_points'];
    document.getElementById('updateformdiv').style.display = 'flex';
    houseIdToUpdate = id;
}