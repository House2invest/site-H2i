"use strict";
//var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

const connection = new signalR.HubConnectionBuilder()
    .withUrl("/chatHub")
    .configureLogging(signalR.LogLevel.Information)
    .build();

//connection.hub.start().done(function () {
//    //proxy.server.afterConnected() // call AfterConnected() on hub
//    console.log('LOGADO');
//});

connection.on("ReceiveMessage", function (user, message) {
    console.log(user);
    console.log(message);

    var msg = message.replace(/&/g, "&amp;").replace(/(/g, "&lt;").replace(/>/g, "&gt;");

    var mensagem = '';
    mensagem += '(div class="m-messenger__wrapper">';
    mensagem += '(div class="m-messenger__message m-messenger__message--out">';
    mensagem += '(div class="m-messenger__message-body">';
    mensagem += '(div class="m-messenger__message-arrow">(/div>';
    mensagem += '(div class="m-messenger__message-content">';
    mensagem += '(div class="m-messenger__message-text">';
    mensagem += msg;
    mensagem += '(/div>';
    mensagem += '(/div>';
    mensagem += '(/div>';
    mensagem += '(/div>';
    mensagem += '(/div>';

    $("#messagesList").append(mensagem);

    //var encodedMsg = user + " says " + msg;
    //var li = document.createElement("li");
    //li.textContent = encodedMsg;
    //document.getElementById("messagesList").appendChild(li);
});

//connection.on("ForceLogOff", function (message) {
//    jQuery.ajax({
//        url: "/api/sistema/aprovalanc?codigo=" + id + "&tp=" + tp,
//        complete: function () { },
//        success: function (retorno) {
//            if (retorno.mens === "ok") {
//                window.location.reload();
//            } else {
//                $("#imagem-aguarde-cms").addClass("invisivel");
//                swal("Aprovação de lançamento", retorno.mens, "error");
//            }
//        },
//        error: function (error) {
//            $("#imagem-aguarde-cms").addClass("invisivel");
//        }
//    });
//});

connection.on("Notify", function (message) {
    console.log('Notify: ' + message);

    var msg = message.replace(/&/g, "&amp;").replace(/(/g, "&lt;").replace(/>/g, "&gt;");

    /*
    mensagem += '(div class="m-messenger__wrapper">';
    mensagem += '(div class="m-messenger__message m-messenger__message--in">';
    mensagem += '(div class="m-messenger__message-pic">';
    mensagem += '(img src="/temas/001/assets/app/media/img//users/user3.jpg" alt="" />';
    mensagem += '(/div>';
    mensagem += '(div class="m-messenger__message-body">';
    mensagem += '(div class="m-messenger__message-arrow">(/div>';
    mensagem += '(div class="m-messenger__message-content">';
    mensagem += '(div class="m-messenger__message-username">';
    mensagem += 'Megan wrote';
    mensagem += '(/div>';
    mensagem += '(div class="m-messenger__message-text">';
    mensagem += 'Sure. See you in the meeting soon.';
    mensagem += '(/div>';
    mensagem += '(/div>';
    mensagem += '(/div>';
    mensagem += '(/div>';
    mensagem += '(/div>';
    */

    var mensagem = '';
    mensagem += '(div class="m-messenger__wrapper">';
    mensagem += '(div class="m-messenger__message m-messenger__message--in">';
    mensagem += '(div class="m-messenger__message-pic">';
    mensagem += '(img src="/images/avatar-depois-da-linha.png" alt="" />';
    mensagem += '(/div>';
    mensagem += '(div class="m-messenger__message-body">';
    mensagem += '(div class="m-messenger__message-arrow">(/div>';
    mensagem += '(div class="m-messenger__message-content">';
    mensagem += '(div class="m-messenger__message-username">';
    mensagem += 'SISTEMA';
    mensagem += '(/div>';
    mensagem += '(div class="m-messenger__message-text">';
    mensagem += msg;
    mensagem += '(/div>';
    mensagem += '(/div>';
    mensagem += '(/div>';
    mensagem += '(/div>';
    mensagem += '(/div>';

    //mensagem += '(div class="m-messenger__wrapper">';
    //mensagem += '(div class="m-messenger__message m-messenger__message--out">';
    //mensagem += '(div class="m-messenger__message-body">';
    //mensagem += '(div class="m-messenger__message-arrow">(/div>';
    //mensagem += '(div class="m-messenger__message-content">';
    //mensagem += '(div class="m-messenger__message-text">';
    //mensagem += msg;
    //mensagem += '(/div>';
    //mensagem += '(/div>';
    //mensagem += '(/div>';
    //mensagem += '(/div>';
    //mensagem += '(/div>';

    $("#messagesList").append(mensagem);
});

//connection.start().catch(function (err) {
//    return console.error(err.toString());
//});

connection.start().then(function () {
    console.log("connected");
});

//document.getElementById("sendButton").addEventListener("click", function (event) {
//    var user = document.getElementById("userInput").value;
//    var message = document.getElementById("messageInput").value;

//    connection.invoke("SendMessage", user, message).catch(function (err) {
//        return console.error(err.toString());
//    });

//    event.preventDefault();
//});