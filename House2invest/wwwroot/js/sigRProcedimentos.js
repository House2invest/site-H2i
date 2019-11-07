//if (connection !== null) {
//    connection.on("ReceiveMessage", function (user, message) {
//        console.log(user);
//        console.log(message);

//        var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");

//        var mensagem = '';
//        mensagem += '<div class="m-messenger__wrapper">';
//        mensagem += '<div class="m-messenger__message m-messenger__message--out">';
//        mensagem += '<div class="m-messenger__message-body">';
//        mensagem += '<div class="m-messenger__message-arrow"></div>';
//        mensagem += '<div class="m-messenger__message-content">';
//        mensagem += '<div class="m-messenger__message-text">';
//        mensagem += msg;
//        mensagem += '</div>';
//        mensagem += '</div>';
//        mensagem += '</div>';
//        mensagem += '</div>';
//        mensagem += '</div>';

//        $("#messagesList").append(mensagem);

//        //var encodedMsg = user + " says " + msg;
//        //var li = document.createElement("li");
//        //li.textContent = encodedMsg;
//        //document.getElementById("messagesList").appendChild(li);
//    });
//    connection.on("Notify", function (message) {
//        console.log('Notify: ' + message);

//        var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");

//        var mensagem = '';
//        mensagem += '<div class="m-messenger__wrapper">';
//        mensagem += '<div class="m-messenger__message m-messenger__message--in">';
//        mensagem += '<div class="m-messenger__message-pic">';
//        mensagem += '<img src="/images/avatar-depois-da-linha.png" alt="" />';
//        mensagem += '</div>';
//        mensagem += '<div class="m-messenger__message-body">';
//        mensagem += '<div class="m-messenger__message-arrow"></div>';
//        mensagem += '<div class="m-messenger__message-content">';
//        mensagem += '<div class="m-messenger__message-username">';
//        mensagem += 'SISTEMA';
//        mensagem += '</div>';
//        mensagem += '<div class="m-messenger__message-text">';
//        mensagem += msg;
//        mensagem += '</div>';
//        mensagem += '</div>';
//        mensagem += '</div>';
//        mensagem += '</div>';
//        mensagem += '</div>';

//        $("#messagesList").append(mensagem);
//    });
//    connection.on("ForceLogOff", function (user, message) {
//        procForceLogOff(user, message);
//        //var scrollLeft = window.pageXOffset || document.documentElement.scrollLeft;
//        //var scrollTop = window.pageYOffset || document.documentElement.scrollTop;
//        //jQuery.ajax({
//        //    url: "/api/sistema/forcalogoff?id=" + user + "&sl=" + scrollLeft + "&st=" + scrollTop + "&rota=" + window.location.href,
//        //    complete: function () { },
//        //    success: function (retorno) {
//        //        if (retorno.status === "ok") {
//        //            //var _menshtml = "Você foi desconectado do portal por um administrador da House2Invest. Você não possui mais acesso ao portal. Entraremos em contato pelo email cadastrado.";
//        //            //swal({
//        //            //    title: "LogOff forçado",
//        //            //    //content: _menshtml,
//        //            //    text: _menshtml,
//        //            //    icon: "warning",
//        //            //    //buttons: true,
//        //            //    buttons: {
//        //            //        //cancel: "Cancelar",
//        //            //        confirm: "Login"
//        //            //    },
//        //            //    dangerMode: true,
//        //            //    onClose: FecharSwal
//        //            //})
//        //            //.then((ok) => {
//        //            //    if (ok) {
//        //            //        window.location.href = "/Identity/Account/Login";
//        //            //    }
//        //            //});

//        //            window.location.href = "/LogOffForcado";
//        //        }
//        //    },
//        //    error: function (error) {
//        //        //$("#imagem-aguarde-cms").addClass("invisivel");
//        //    }
//        //});
//    });
//}

//if (connectioncms !== null) {
//    connectioncms.on("ForceLogOff", function (user, message) {
//        procForceLogOff(user, message);
//        //var scrollLeft = window.pageXOffset || document.documentElement.scrollLeft;
//        //var scrollTop = window.pageYOffset || document.documentElement.scrollTop;
//        //jQuery.ajax({
//        //    url: "/api/sistema/forcalogoff?id=" + user + "&sl=" + scrollLeft + "&st=" + scrollTop + "&rota=" + window.location.href,
//        //    complete: function () { },
//        //    success: function (retorno) {
//        //        if (retorno.status === "ok") {
//        //            //var _menshtml = "Você foi desconectado do portal por um administrador da House2Invest. Você não possui mais acesso ao portal. Entraremos em contato pelo email cadastrado.";
//        //            //swal({
//        //            //    title: "LogOff forçado",
//        //            //    //content: _menshtml,
//        //            //    text: _menshtml,
//        //            //    icon: "warning",
//        //            //    //buttons: true,
//        //            //    buttons: {
//        //            //        //cancel: "Cancelar",
//        //            //        confirm: "Login"
//        //            //    },
//        //            //    dangerMode: true,
//        //            //    onClose: FecharSwal
//        //            //})
//        //            //.then((ok) => {
//        //            //    if (ok) {
//        //            //        window.location.href = "/Identity/Account/Login";
//        //            //    }
//        //            //});

//        //            window.location.href = "/LogOffForcado";
//        //        }
//        //    },
//        //    error: function (error) {
//        //        //$("#imagem-aguarde-cms").addClass("invisivel");
//        //    }
//        //});
//    });
//}
function procForceLogOff(user, message) {
    var scrollLeft = window.pageXOffset || document.documentElement.scrollLeft;
    var scrollTop = window.pageYOffset || document.documentElement.scrollTop;
    jQuery.ajax({
        url: "/api/sistema/forcalogoff?id=" + user + "&sl=" + scrollLeft + "&st=" + scrollTop + "&rota=" + window.location.href,
        complete: function () { },
        success: function (retorno) {
            if (retorno.status === "ok") {
                //var _menshtml = "Você foi desconectado do portal por um administrador da House2Invest. Você não possui mais acesso ao portal. Entraremos em contato pelo email cadastrado.";
                //swal({
                //    title: "LogOff forçado",
                //    //content: _menshtml,
                //    text: _menshtml,
                //    icon: "warning",
                //    //buttons: true,
                //    buttons: {
                //        //cancel: "Cancelar",
                //        confirm: "Login"
                //    },
                //    dangerMode: true,
                //    onClose: FecharSwal
                //})
                //.then((ok) => {
                //    if (ok) {
                //        window.location.href = "/Identity/Account/Login";
                //    }
                //});

                window.location.href = "/LogOffForcado";
            }
        },
        error: function (error) {
            //$("#imagem-aguarde-cms").addClass("invisivel");
        }
    });
}