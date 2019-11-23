"use strict";
const connectioncms =
    new signalR.HubConnectionBuilder()
        .withUrl("/chatHubCMS")
        .configureLogging(signalR.LogLevel.Information)
        .build();

connectioncms.start().then(function () { console.log("[" + (new Date().toLocaleDateString() + " " + new Date().toLocaleTimeString()) + "] signalR_CMS escutando"); });
connectioncms.onclose(async () => { await start(); });
async function start() {
    try {
        await connectioncms.start();
        console.log("[" + (new Date().toLocaleDateString() + " " + new Date().toLocaleTimeString()) + "] signalR_CMS reconectado");
    } catch (err) {
        //console.log(err);
        setTimeout(() => start(), 5000);
    }
}
//connectioncms.start().catch(function (err) {
//    return console.error(err.toString());
//});

connectioncms.on("ReceiveMessage", function (user, message) {
    swal('Olá', message, 'info');
});

connectioncms.on("ForceLogOff", function (user, message) {
    procForceLogOff(user, message);
    //var scrollLeft = window.pageXOffset || document.documentElement.scrollLeft;
    //var scrollTop = window.pageYOffset || document.documentElement.scrollTop;
    //jQuery.ajax({
    //    url: "/api/sistema/forcalogoff?id=" + user + "&sl=" + scrollLeft + "&st=" + scrollTop + "&rota=" + window.location.href,
    //    complete: function () { },
    //    success: function (retorno) {
    //        if (retorno.status === "ok") {
    //            //var _menshtml = "Você foi desconectado do portal por um administrador da House2Invest. Você não possui mais acesso ao portal. Entraremos em contato pelo email cadastrado.";
    //            //swal({
    //            //    title: "LogOff forçado",
    //            //    //content: _menshtml,
    //            //    text: _menshtml,
    //            //    icon: "warning",
    //            //    //buttons: true,
    //            //    buttons: {
    //            //        //cancel: "Cancelar",
    //            //        confirm: "Login"
    //            //    },
    //            //    dangerMode: true,
    //            //    onClose: FecharSwal
    //            //})
    //            //.then((ok) => {
    //            //    if (ok) {
    //            //        window.location.href = "/Identity/Account/Login";
    //            //    }
    //            //});

    //            window.location.href = "/LogOffForcado";
    //        }
    //    },
    //    error: function (error) {
    //        //$("#imagem-aguarde-cms").addClass("invisivel");
    //    }
    //});
});










//connectioncms.start().then(function () {
//    console.log("Conectado CMS");
//});
//async function start() {
//    try {
//        await connectioncms.start();
//        console.log("reconectado");
//    } catch (err) {
//        console.log(err);
//        setTimeout(() => start(), 5000);
//    }
//}
//connectioncms.onclose(async () => {
//    await start();
//});
//connectioncms.on("ForceLogOff", function (message) {
//    var scrollLeft = window.pageXOffset || document.documentElement.scrollLeft;
//    var scrollTop = window.pageYOffset || document.documentElement.scrollTop;
//    $.ajax({
//        url: "/api/sistema/forcalogoff?id=@idusuario&sl=" + scrollLeft + "&st=" + scrollTop + "&rota=" + window.location.href,
//        complete: function () { },
//        success: function (retorno) {
//            if (retorno.status === "ok") {
//                window.location.href = "/LogOffForcado";
//            }
//        },
//        error: function (error) { }
//    });
//});



