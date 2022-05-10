let array = [];
let connection = null;
getdata();
setupSignalR();

//?????????????????
function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:21980/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("AppleServiceCreated", (user, message) => {
        getdata();
    });

    connection.on("AppleServiceDeleted", (user, message) => {
        getdata();
    });
    connection.on("AppleServiceUpdated", (user, message) => {
        getdata();
    });

    connection.onclose(async () => {
        await start();
    });
    start();


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

async function getdata() {
    await fetch('http://localhost:21980/appleService')
        .then(x => x.json())
        .then(y => {
            array = y;
            console.log(array);
            display();
        });
}

function display() {
    document.getElementById('resultarea').innerHTML = "";
    array.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.serviceID + "</td><td>"
            + t.serviceName + "</td><td>"
            + t.location + "</td><td>"
            + `<button type="button" onclick="remove(${t.serviceID})">Delete</button>`
            + "</td></tr>";
    });
}

function remove(id) {
    fetch('http://localhost:21980/appleService/' + id, {
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

function create() {
    let servicename = document.getElementById('servicename').value;
    let location = document.getElementById('location').value;


    fetch('http://localhost:21980/appleService', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { serviceName: servicename, location: location})
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}