let noncrudcoll = [];

function cleardisplay() {
    document.getElementById('noncrudform').style.display = "none";
    document.getElementById('form_GetQuidditchPlayers').style.display = "none";
    document.getElementById('form_GetRetiredTeachersFromHouse').style.display = "none";
    document.getElementById('form_GetTeacherFromSubject').style.display = "none";
    document.getElementById('form_GetAnimagusTeachersFromASubjects').style.display = "none";
}

async function getdata03() {
    cleardisplay();
    document.getElementById('form_GetQuidditchPlayers').style.display = "initial";
    document.getElementById('result_GetQuidditchPlayers').innerHTML = "";
    await getHouses();
    houses.forEach(function (item) {
        let o = document.createElement("option");
        o.text = item.house_name;
        o.value = item.house_name;
        document.getElementById('slctHouse').appendChild(o);
        console.log(o);
    })
}


let houses = [];
async function getHouses() {
    await fetch('http://localhost:3736/House')
        .then(x => x.json())
        .then(y => {
            houses = y;
            console.log(houses);
        });
}

function display03() {
    cleardisplay();
    document.getElementById('form_GetQuidditchPlayers').style.display = "initial";
    document.getElementById('result_GetQuidditchPlayers').innerHTML = "";
    noncrudcoll.forEach(t => {
        console.log(t.studentname);
        document.getElementById('result_GetQuidditchPlayers').innerHTML +=
            "<tr><td>" + t.studentname+ "</td></tr>";
        console.log(t);
    })
}


async function getdata03_final() {
    let str = document.getElementById('slctHouse').value;
    str = "http://localhost:3736/Stat/GetQuidditchPlayers/" + str;

    await fetch(str)
        .then(x => x.json())
        .then(y => {
            noncrudcoll = y;
            console.log(noncrudcoll)
            display03();
        });
}


async function getdata04() {
    cleardisplay();
    document.getElementById('form_GetRetiredTeachersFromHouse').style.display = "initial";
    document.getElementById('result_GetRetiredTeachersFromHouse').innerHTML = "";
    await getHouses();
    houses.forEach(function (item) {
        let o = document.createElement("option");
        o.text = item.house_name;
        o.value = item.house_name;
        document.getElementById('slctHouse2').appendChild(o);
        console.log(o);
    })
}

function display04() {
    cleardisplay();
    document.getElementById('form_GetRetiredTeachersFromHouse').style.display = "initial";
    document.getElementById('result_GetRetiredTeachersFromHouse').innerHTML = "";
    noncrudcoll.forEach(t => {
        console.log(t.teachername);
        document.getElementById('result_GetRetiredTeachersFromHouse').innerHTML +=
            "<tr><td>" + t.teachername + "</td></tr>";
        console.log(t);
    })
}

async function getdata04_final() {
    let str = document.getElementById('slctHouse2').value;
    str = "http://localhost:3736/Stat/GetRetiredTeachersFromHouse/" + str;

    await fetch(str)
        .then(x => x.json())
        .then(y => {
            noncrudcoll = y;
            console.log(noncrudcoll)
            display04();
        });
}



async function getdata05() {
    cleardisplay();
    document.getElementById('form_GetStudentFromHouse').style.display = "initial";
    document.getElementById('result_GetStudentFromHouse').innerHTML = "";
    await getHouses();
    houses.forEach(function (item) {
        let o = document.createElement("option");
        o.text = item.house_name;
        o.value = item.house_name;
        document.getElementById('slctHouse3').appendChild(o);
        console.log(o);
    })
}

function display05() {
    cleardisplay();
    document.getElementById('form_GetStudentFromHouse').style.display = "initial";
    document.getElementById('result_GetStudentFromHouse').innerHTML = "";
    noncrudcoll.forEach(t => {
        console.log(t.studentname);
        document.getElementById('result_GetStudentFromHouse').innerHTML +=
            "<tr><td>" + t.studentname + "</td></tr>";
        console.log(t);
    })
}

async function getdata05_final() {
    let str = document.getElementById('slctHouse3').value;
    str = "http://localhost:3736/Stat/GetStudentFromHouse/" + str;

    await fetch(str)
        .then(x => x.json())
        .then(y => {
            noncrudcoll = y;
            console.log(noncrudcoll)
            display05();
        });
}



async function getdata06() {
    cleardisplay();
    document.getElementById('form_GetTeacherFromSubject').style.display = "initial";
    document.getElementById('result_GetTeacherFromSubject').innerHTML = "";
    await getSubjects();
    subjects.forEach(function (item) {
        let o = document.createElement("option");
        o.text = item.subject_Name;
        o.value = item.subject_Name;
        document.getElementById('slctsubject').appendChild(o);
        console.log(o);
    })
}


let subjects = [];
async function getSubjects() {
    await fetch('http://localhost:3736/Subject')
        .then(x => x.json())
        .then(y => {
            subjects = y;
            console.log(subjects);
        });
}

function display06() {
    cleardisplay();
    document.getElementById('form_GetTeacherFromSubject').style.display = "initial";
    document.getElementById('result_GetTeacherFromSubject').innerHTML = "";
    noncrudcoll.forEach(t => {
        document.getElementById('result_GetTeacherFromSubject').innerHTML +=
            "<tr><td>" + t.teachername + "</td></tr>";
    })
}


async function getdata06_final() {
    let str = document.getElementById('slctsubject').value;
    str = "http://localhost:3736/Stat/GetAnimagusTeachersFromASubjects/" + str;

    await fetch(str)
        .then(x => x.json())
        .then(y => {
            noncrudcoll = y;
            console.log(noncrudcoll)
            display06();
        });
}





async function getdata07() {
    cleardisplay();
    document.getElementById('form_GetAnimagusTeachersFromASubjects').style.display = "initial";
    document.getElementById('result_GetAnimagusTeachersFromASubjects').innerHTML = "";
    await getSubjects();
    subjects.forEach(function (item) {
        let o = document.createElement("option");
        o.text = item.subject_Name;
        o.value = item.subject_Name;
        document.getElementById('slctsubject2').appendChild(o);
        console.log(o);
    })
}

function display07() {
    cleardisplay();
    document.getElementById('form_GetAnimagusTeachersFromASubjects').style.display = "initial";
    document.getElementById('result_GetAnimagusTeachersFromASubjects').innerHTML = "";
    noncrudcoll.forEach(t => {
        document.getElementById('result_GetAnimagusTeachersFromASubjects').innerHTML +=
            "<tr><td>" + t.teachername + "</td></tr>";
    })
}


async function getdata07_final() {
    let str = document.getElementById('slctsubject2').value;
    str = "http://localhost:3736/Stat/GetAnimagusTeachersFromASubjects/" + str;

    await fetch(str)
        .then(x => x.json())
        .then(y => {
            noncrudcoll = y;
            console.log(noncrudcoll)
            display07();
        });
}
