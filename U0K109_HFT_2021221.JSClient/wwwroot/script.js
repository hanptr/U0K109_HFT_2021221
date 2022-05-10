
fetch('http://localhost:21980/appleService')
    .then(x => x.json())
    .then(y => {
        console.log(y);
    })
////let array = [];
//////let connection = null;
//////getdata();
//////setupSignalR();


////function setupSignalR() {
////    connection = new signalR.HubConnectionBuilder()
////        .withUrl("http://localhost:21980/hub")
////        .configureLogging(signalR.LogLevel.Information)
////        .build();

////    connection.on("AppleServiceCreated", (user, message) => {
////        getdata();
////    });

////    connection.on("AppleServiceDeleted", (user, message) => {
////        getdata();
////    });

////    connection.onclose(async () => {
////        await start();
////    });
////    start();


////}

////async function start() {
////    try {
////        await connection.start();
////        console.log("SignalR Connected.");
////    } catch (err) {
////        console.log(err);
////        setTimeout(start, 5000);
////    }
////};

////fetch('http://localhost:21980/appleService')
////    .then(x => x.json())
////    .then(y => {
////        array = y;
////        console.log(array);
////        display;
////    })
////function display() {
////    array.forEach(t => {
////           console.log(t.)
////    })
////}


//////function display() {
//////    document.getElementById('resultarea').innerHTML = "";
//////    array.forEach(t => {
//////        document.getElementById('resultarea').innerHTML +=
//////            "<tr><td>" + t.mechanicId + "</td><td>"
//////            + t.serviceId + "</td><td>"
//////            + t.name + "</td><td>"
//////            + `<button type="button" onclick="remove(${t.mechanicId})">Delete</button>`
//////            + "</td></tr>";
//////    });
//////}

//////function remove(id) {
//////    fetch('http://localhost:11111/mechanic/' + id, {
//////        method: 'DELETE',
//////        headers: { 'Content-Type': 'application/json', },
//////        body: null
//////    })
//////        .then(response => response)
//////        .then(data => {
//////            console.log('Success:', data);
//////            getdata();
//////        })
//////        .catch((error) => { console.error('Error:', error); });

//////}

//////function create() {
//////    let serviceid = document.getElementById('serviceid').value;
//////    let name = document.getElementById('name').value;


//////    fetch('http://localhost:11111/mechanic', {
//////        method: 'POST',
//////        headers: { 'Content-Type': 'application/json', },
//////        body: JSON.stringify(
//////            { serviceId: serviceid, name: name })
//////    })
//////        .then(response => response)
//////        .then(data => {
//////            console.log('Success:', data);
//////            getdata();
//////        })
//////        .catch((error) => { console.error('Error:', error); });
//////}