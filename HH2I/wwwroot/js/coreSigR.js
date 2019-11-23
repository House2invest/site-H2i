//"use strict";
//const connection =
//    new signalR.HubConnectionBuilder()
//        .withUrl("/RaizHub")
//        .configureLogging(signalR.LogLevel.Information)
//        .build();

//connection.start().then(function () {
//    //var hub = connection;
//    //var connectionUrl = hub["connection"].transport.webSocket.url;
//    ////var connectionObjWebSocket = JSON.stringify(hub["connection"].transport.webSocket);

//    //var objConnection = hub["connection"];
//    //var objConnectionTranp = hub["connection"].transport;
//    ////var objConnectionWS = hub["connection"].transport.webSocket;

//    //var ser_objConnection = JSON.stringify(objConnection);
//    //var ser_objConnectionTranp = JSON.stringify(objConnectionTranp);
//    ////var ser_objConnectionWS = JSON.stringify(objConnectionWS);

//    //console.log("-------------------------------------");
//    //console.log("connectionUrl......: " + connectionUrl);
//    //console.log("objConnection......: " + ser_objConnection);
//    //console.log("objConnectionTransp: " + ser_objConnectionTranp);
//    ////console.log("objConnectionWS....: " + ser_objConnectionWS);
//    //console.log("-------------------------------------");

//    //var hub = connection;
//    //console.log("Connected, transport = " + hub);
//    //console.log("[" + (new Date().toLocaleDateString() + " " + new Date().toLocaleTimeString()) + "] signalR escutando em " + connection.get);
//});
//connection.onclose(async () => {
//    console.log("[" + (new Date().toLocaleDateString() + " " + new Date().toLocaleTimeString()) + "] DISCONECTADO");
//    await start();
//});
//async function start() {
//    try {
//        await connection.start();
//        console.log("[" + (new Date().toLocaleDateString() + " " + new Date().toLocaleTimeString()) + "] signalR reconectado");
//    } catch (err) {
//        //console.log(err);
//        setTimeout(() => start(), 5000);
//    }
//}
////connection.start().catch(function (err) {
////    return console.error(err.toString());
////});
//connection.on("GravaLog", function (idusu, idcnx, status) {
//    //swal('Olá', message, 'info');
//    console.log("[" + (new Date().toLocaleDateString() + " " + new Date().toLocaleTimeString()) + "] " + (idusu + " com ID " + idcnx + " e com STATUS " + status));
//});


"use strict";
const connection =
    new signalR.HubConnectionBuilder()
        .withUrl("/RaizHub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

//var hub = connection;
//var clientId = hub.clientId;
// register mobile and tell it to start executing
connection.ClientConnected = function (clientId) {
    connection.server.startExecution(clientId);
};
// update orientation
//hub.client.orientationChanged = function (orientation) { };
// connect to server
connection.start().then(function (clientId) {
    connection.Invoke( .client.getConnectionId().done(function (clientId) {
        /* show QR code with url containing desktop connection id */
        console.log("[" + (new Date().toLocaleDateString() + " " + new Date().toLocaleTimeString()) + "] " + ("VISITANTE com ID " + clientId + " e com STATUS INICIADO"));
    });
});
connection.on("GravaLog", function (idusu, idcnx, status) {
    //swal('Olá', message, 'info');
    console.log("[" + (new Date().toLocaleDateString() + " " + new Date().toLocaleTimeString()) + "] " + (idusu + " com ID " + idcnx + " e com STATUS " + status));
});

