var _CNXHUB;

function ExibeMensQuadro(de, para, mens) {
    //$("#quadro_mens_" + para).append("<li style='text-align:right;padding:5px;'>" + de + ": " + mens + "<li/>");
    //$("#quadro_mens_" + de).append("<li style='text-align:right;padding:5px;'>Você: " + mens + "<li/>");
    //console.log('DE: ' + de);
    //console.log('PARA: ' + para);
}
function EnviarMensagem(de, para, mens) {
    //var _obj = document.getElementById("quadro_mens_" + de);
    //_obj.innerHTML = mens;
    //connection.invoke("enviarmens", de, para, mens);
}
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

async function ReiniciaHUB(hub) {
    try {
        await hub.start();
        //console.log("[" + (new Date().toLocaleDateString() + " " + new Date().toLocaleTimeString()) + "] signalR reconectado");
    } catch (err) {
        //console.log("[" + (new Date().toLocaleDateString() + " " + new Date().toLocaleTimeString()) + "] signalR err: " + err);
        setTimeout(() => ReiniciaHUB(hub), 5000);
    }
}
function InicializaHUB() {
    _CNXHUB = new signalR
        .HubConnectionBuilder()
        .withUrl("/notificacoes", {
            //skipNegotiation: true,
            //transport: signalR.HttpTransportType.WebSockets
        })
        //.withUrl("/notificacoes", options => {
        //    options.AccessTokenProvider = async () => {
        //        // Get and return the access token.
        //    };
        //})
        //.configureLogging(signalR.LogLevel.Information)
        .configureLogging(signalR.LogLevel.None)
        .build();

    _CNXHUB.start()
        .then(function () {
            //console.log("[" + (new Date().toLocaleDateString() + " " + new Date().toLocaleTimeString()) + "] signalR escutando");
        })
        //.catch(err => console.log(err)); //'Error while establishing connection :('));
        .catch(); //'Error while establishing connection :('));
    //console.log(this._hubConnection);

    _CNXHUB.onclose(async () => {
        //console.log("[" + (new Date().toLocaleDateString() + " " + new Date().toLocaleTimeString()) + "] signalR fechado");
        await ReiniciaHUB(_CNXHUB);
    });

    _CNXHUB.on("teclando", async (de, para) => {
        if ($("#id_para").val() === de && $("#profile-img").attr('data-uid') === para) {
            var id = window.setTimeout(function () { }, 0);
            while (id--) { window.clearTimeout(id); }
            var _mens = document.getElementById("acoes_conversa_para");
            _mens.innerText = "digitando...";
            $('.contact.active .status-chat-datahora').html('digitando...');
            setTimeout(function () {
                _mens.innerText = "online";
                $('.contact.active .status-chat-datahora').html('');
            }, 150);
        }
    });

    _CNXHUB.on("quemsoueu", async (cnxid, de, para, mens, status) => {
        //console.log("[" + (new Date().toLocaleDateString() + " " + new Date().toLocaleTimeString()) + "] " + mens + " " + status + " com ID " + cnxid);

        if ($("#profile-img").attr('data-uid') === de) {
            $("#__CHAT_bullet-sele-status").removeClass();

            $("#__CHAT_bullet-sele-status").addClass("uid-status-marcador " + (status === 'ENTROU' ? "online" : status === 'SAIU' ? "offline" : ""));
            $("#de-cnxid").val(status === 'ENTROU' ? cnxid : "[offline]");
            //$("#const_DE_CNXID").val(status === 'ENTROU' ? cnxid : "[offline]");
            document.getElementById("acoes_conversa_para").innerText = status === 'ENTROU' ? "ONLINE" : "visto por último " + new Date().toLocaleDateString() + " " + new Date().toLocaleTimeString();

            $("#profile-img").addClass(status === 'ENTROU' ? "borda-online" : "borda-offline");

            //$("#__CHAT_bullet-sele-status").removeClass();
            //if (status === 'ENTROU') {
            //    $("#__CHAT_bullet-sele-status").addClass("uid-status-marcador online");
            //    $("#de-cnxid").val(cnxid);
            //    //var _mens = document.getElementById("acoes_conversa_para");
            //    //_mens.innerText = "ONLINE";
            //    document.getElementById("acoes_conversa_para").innerText = "ONLINE";
            //} else if (status === 'SAIU') {
            //    $("#__CHAT_bullet-sele-status").addClass("uid-status-marcador offline");
            //    $("#de-cnxid").val("[offline]");
            //    //var _mens001 = document.getElementById("acoes_conversa_para");
            //    //_mens001.innerText = "visto por último " + new Date().toLocaleDateString();
            //    document.getElementById("acoes_conversa_para").innerText = "visto por último " + new Date().toLocaleDateString();
            //}
        } else {
            //if ($("#id_para").val() === para) {
            //console.log("DE: " + de);
            //console.log("PARA: " + para);

            var _existeNaListaDeOutro = $("ul").find("[data-id='" + de + "']");
            //console.log(_existeNaListaDeOutro.attr("data-nome"));
            //console.log(_existeNaListaDeOutro.attr("data-nome").length > 0);

            if (_existeNaListaDeOutro.attr("data-nome").length > 0) {

                $("#avatar-lista-contatos-" + de).removeClass();
                $("#avatar-lista-contatos-" + de).addClass(status === 'ENTROU' ? "borda-online" : "borda-offline");
                $('.contact.active .status-chat-datahora').html('');

                status === 'SAIU' ? $("ul").find("[data-id='" + de + "']").addClass("opaco-5") : $("ul").find("[data-id='" + de + "']").removeClass("opaco-5");

                //$("ul").find("[data-id='" + de + "']").removeClass("opaco-6");
                //$("ul").find("[data-id='" + de + "']").addClass(status === 'SAIU' ? "opaco-6" : "");

                //$('.contact.active').addClass(status === 'SAIU' ? "opaco-6" : "");

                //$("#const_PARA_CNXID").val(status === 'ENTROU' ? cnxid : "[offline]");

                if (status === "ENTROU") {
                    var id = window.setTimeout(function () { }, 0);
                    while (id--) { window.clearTimeout(id); }
                    //var _mens = document.getElementById("acoes_conversa_para");
                    //_mens.innerText = "ONLINE";
                    if ($("#id_para").val() === para) {
                        document.getElementById("acoes_conversa_para").innerText = "ONLINE";
                    }
                    $("#marcador-status-" + de).removeClass("offline");
                    $("#marcador-status-" + de).addClass("online");
                } else {
                    //var _mens001 = document.getElementById("acoes_conversa_para");
                    //_mens001.innerText = "visto por último " + new Date().toLocaleDateString();
                    setTimeout(function () {
                        if ($("#id_para").val() === para) {
                            document.getElementById("acoes_conversa_para").innerText = "visto por último " + new Date().toLocaleDateString() + " " + new Date().toLocaleTimeString();
                        }
                        $("#marcador-status-" + de).removeClass("online");
                        $("#marcador-status-" + de).addClass("offline");
                    }, 3000);
                }
            }

            //if (_existeNaListaDeOutro.attr("data-nome").val() !== undefined && _existeNaListaDeOutro.attr("data-nome").val() !== '') {
            //    if (status === "ENTROU") {
            //        //var _mens = document.getElementById("acoes_conversa_para");
            //        //_mens.innerText = "ONLINE";
            //        document.getElementById("acoes_conversa_para").innerText = "ONLINE";
            //        $("#marcador-status-" + de).removeClass("offline");
            //        $("#marcador-status-" + de).addClass("online");
            //    } else {
            //        //var _mens001 = document.getElementById("acoes_conversa_para");
            //        //_mens001.innerText = "visto por último " + new Date().toLocaleDateString();
            //        document.getElementById("acoes_conversa_para").innerText = "visto por último " + new Date().toLocaleDateString();
            //        $("#marcador-status-" + de).removeClass("online");
            //        $("#marcador-status-" + de).addClass("offline");
            //    }
            //}

            //if ($("#id_para").val() === de) {

            //if (status === "ENTROU") {
            //    //var _mens = document.getElementById("acoes_conversa_para");
            //    //_mens.innerText = "ONLINE";
            //    document.getElementById("acoes_conversa_para").innerText = "ONLINE";
            //    $("#marcador-status-" + de).removeClass("offline");
            //    $("#marcador-status-" + de).addClass("online");
            //} else {
            //    //var _mens001 = document.getElementById("acoes_conversa_para");
            //    //_mens001.innerText = "visto por último " + new Date().toLocaleDateString();
            //    document.getElementById("acoes_conversa_para").innerText = "visto por último " + new Date().toLocaleDateString();
            //    $("#marcador-status-" + de).removeClass("online");
            //    $("#marcador-status-" + de).addClass("offline");
            //}

            //}

            //}
        }
    });

    //_CNXHUB.on("listaclientes", async (lsthtml) => {
    //    $(".combo_clientes").html(lsthtml);
    //    $(".combo_clientes").change();
    //});

    _CNXHUB.on("listaclienteschat", async (chave) => {
        /*
        var _lsthtml = '';
        //_lsthtml += "<input class='form-control chat-user-filter' placeholder='Filter' type='text'>";
        try {
            jQuery.ajax({
                url: "/api/sistema/retornalistausuchatsalavip",
                complete: function () {
                    $(".class-ativa-conversa-quadro").on('click', function (e) {
                        //var de_cnxid = this.getAttribute("data-de-cnxid");
                        var uid_de = this.getAttribute("data-uid-de");
                        var _cnx_de = this.getAttribute("data-cnx-de");
                        var _avatar_de = this.getAttribute("data-de-avatar");
                        var _nome_de = this.getAttribute("data-de-nome");
                        //var email_de = this.getAttribute("data-de-email");

                        $("#uid_para").val(uid_de);
                        document.getElementById("avatar_para").src = _avatar_de;
                        $("#nome_para").val(_nome_de);

                        $(".chatsele").removeClass('sombra-usu-selecionado-sala');

                        $("#chatsele_" + uid_de).removeClass('sombra');
                        $("#chatsele_" + uid_de).addClass('sombra-usu-selecionado-sala');

                        //$("#avatar_para").attr('src', _avatar_de);
                        //$("#cnxpara").val(uid_cnx);
                        //var _saida = '';
                        //_saida += 'UID: ' + atrib_de_id + ', EMAIL: ' + atrib_de_email + ', CNXID: ' + atrib_de_cnxid;
                        //console.log(_saida);

                        $("#chat").removeClass("invisivel");
                        $("#menschatselemens").addClass("invisivel");
                        $("#imgmenschatselemens").addClass("invisivel");

                        $("#mens").focus();
                    });
                },
                success: function (retorno) {
                    if (retorno.dados !== null) {
                        for (var i = 0; i < retorno.dados.length; i++) {
                            _lsthtml += "<a id='chat_" + retorno.dados[i].idusu + "' name='chat_" + retorno.dados[i].idusu + "'";
                            _lsthtml += "class='class-ativa-conversa-quadro'";

                            _lsthtml += "data-uid-de='" + retorno.dados[i].idusu + "'";
                            _lsthtml += "data-cnx-de='" + retorno.dados[i].cnxid + "'";
                            _lsthtml += "data-de-email='" + retorno.dados[i].email + "'";
                            _lsthtml += "data-de-avatar='" + retorno.dados[i].avatar + "'";
                            _lsthtml += "data-de-nome='" + retorno.dados[i].nome + " " + retorno.dados[i].sobrenome + "'";
                            //_lsthtml += "data-cnxid='" + retorno.dados[i].cnxid + "'";

                            _lsthtml += "href='javascript:;'";
                            _lsthtml += ">";

                            _lsthtml += "   <div class='col-xl-12 col-lg-12 mb-2'>";
                            _lsthtml += "       <div id='chatsele_" + retorno.dados[i].idusu + "' name='chatsele_" + retorno.dados[i].idusu + "' class='bg-white shadow roundy p-2 h-100 d-flex align-items-center justify-content-between chatsele'>";
                            _lsthtml += "           <div class='flex-grow-1 d-flex align-items-center'>";
                            _lsthtml += "               <div class='icon text-white'>";
                            _lsthtml += "                   <img src='" + retorno.dados[i].avatar + "' class='mx-fluid' />";
                            _lsthtml += "               </div>";
                            _lsthtml += "               <div class='text chat-linha-nome-status'>";
                            _lsthtml += "                   <h6 class='mb-0'>" + retorno.dados[i].nome + " " + retorno.dados[i].sobrenome + "</h6>";
                            _lsthtml += "                   <span class='text-gray text-success'>";
                            _lsthtml += "                       ONLINE";
                            _lsthtml += "                   </span>";
                            _lsthtml += "               </div>";
                            _lsthtml += "           </div>";
                            _lsthtml += "       </div>";
                            _lsthtml += "   </div>";

                            _lsthtml += "</a>";

                            //**********************************
                            // DEIXA O ULTIMO NA LISTA (OFFLINE)
                            //**********************************
                            //if (_existoNaLista === undefined) {
                            //    var _objMINHACHAVENOSOUTROS = $("#chat_" + chave);
                            //    if (_objMINHACHAVENOSOUTROS) {
                            //        if ($("#chat_" + chave).attr('data-chat-fname') !== undefined) {
                            //            _lsthtml += "<a id='chat_" + chave + "' name='chat_" + chave + "' href='#' class='usr offline'";
                            //            _lsthtml += "    data-chat-id='chat_" + chave + "'";
                            //            _lsthtml += "    data-chat-fname='" + $("#chat_" + chave).attr('data-chat-fname') + "'";
                            //            _lsthtml += "    data-chat-lname='" + $("#chat_" + chave).attr('data-chat-lname') + "'";
                            //            _lsthtml += "    data-chat-status='incognito'";
                            //            _lsthtml += "    data-chat-alertmsg='[Offline]'";
                            //            _lsthtml += "    data-chat-alertshow='true'";
                            //            _lsthtml += "    data-rel='popover-hover'";
                            //            _lsthtml += "    data-placement='right'";
                            //            _lsthtml += "    data-html='true'";
                            //            _lsthtml += "    data-content=\"";
                            //            _lsthtml += "	    <div class='usr-card'>";
                            //            //_lsthtml += "		    <img src='" + retorno.dados[i].avatar + "' alt='" + retorno.dados[i].nome + " " + retorno.dados[i].sobrenome + "'>";
                            //            //_lsthtml += "			<div class='usr-card-content'>";
                            //            //_lsthtml += "			    <h3>" + retorno.dados[i].nome + " " + retorno.dados[i].sobrenome + "</h3>";
                            //            //_lsthtml += "				<p>" + retorno.dados[i].trabalho + "</p>";
                            //            //_lsthtml += "	        </div>";
                            //            _lsthtml += "		</div>";
                            //            _lsthtml += "	\">";
                            //            _lsthtml += "	<i></i>" + $("#chat_" + chave).attr('data-chat-fname') + " " + $("#chat_" + chave).attr('data-chat-lname');
                            //            _lsthtml += "</a>";
                            //        }
                            //    }
                        }

                        $("#RAIZ_ul_chat-users").html(_lsthtml);
                    }
                },
                error: function (error) { }
            });

        } catch (e) {
            //console.log(e.message);
        }
        */
    });
    _CNXHUB.on("exibehist", async () => {
        //ExibeHistorico();
    });
    _CNXHUB.on("enviarmens", async (de, para, mens) => {

        //console.log("Evento _CNXHUB [enviarmens]: DE '" + de + "' PARA '" + para);
        //ExibeHistConversa(de, para);
        //ExibeHistConversa(para, de);

        //$("#quadro_mens").append("<li style='text-align:right;padding:8px;font-size:12px;color:red;max-width:80%;word-break:break-all;word-wrap:break-word;'>Você: " + mens + "<li/>");

        //$("#quadro_mens_" + para).append("<li style='text-align:right;padding:8px;font-size:12px;color:red;max-width:80%;word-break:break-all;word-wrap:break-word;'>" + de + ": " + mens + "<li/>");

        ////var _rafa = de;
        ////var _vi = para;
        ////_rafa = _rafa.replace('@Html.Raw("@")', '');
        ////_vi = _vi.replace('@Html.Raw("@")', '');
        ////var _rafasemponto = _rafa;
        ////var _visemponto = _vi;
        ////_rafasemponto = _rafasemponto.replace(/\./g, '');
        ////_visemponto = _visemponto.replace(/\./g, '');

        ////var _alturaCxMensDe = $("#quadro_mens_" + _rafasemponto);
        ////var _alturaCxMensPara = $("#quadro_mens_" + _visemponto);

        ////$("#quadro_mens_" + _rafasemponto).animate({ scrollTop: _alturaCxMensDe.height() }, 1500);
        ////$("#quadro_mens_" + _visemponto).animate({ scrollTop: _alturaCxMensPara.height() }, 1500);

        //var _alturaCxMensDe = $("#quadro_mens_" + de);
        //var _alturaCxMensPara = $("#quadro_mens_" + para);
        //$("#quadro_mens_" + de).animate({ scrollTop: _alturaCxMensDe.height() }, 1500);
        //$("#quadro_mens_" + para).animate({ scrollTop: _alturaCxMensPara.height() }, 1500);
    });
    _CNXHUB.on("quadromens", async (canal, para, mens) => {
        ExibeMensQuadro(de, para, mens);
    });
    _CNXHUB.on("forcelogoff", function (user, message) {
        procForceLogOff(user, message);
    });

    _CNXHUB.on("teste", function (de, para, mens, cnxde, cnxpara) {
        //console.log("('#uid').val(): " + $("#uid").val());
        //console.log("para: " + para);
        //console.log("('#id_para').val(): " + $("#id_para").val());
        //console.log("de: " + de);

        //if ($("#uid").val() === para && $("#id_para").val() === de) {

        //    var _momento = moment();
        //    _momento.locale('pt-BR');

        //    var form = document.querySelector('.conversation-compose');
        //    var conversation = document.querySelector('.conversation-container');
        //    var element = document.createElement('div');
        //    element.classList.add('message', 'received');
        //    element.innerHTML = mens +
        //        '<span class="metadata">' +
        //        '<span class="time">' + _momento.format('HH:mm') + '</span>' +
        //        //'<span class="tick tick-animation">' +
        //        //'<svg xmlns="http://www.w3.org/2000/svg" width="16" height="15" id="msg-dblcheck" x="2047" y="2061"><path d="M15.01 3.316l-.478-.372a.365.365 0 0 0-.51.063L8.666 9.88a.32.32 0 0 1-.484.032l-.358-.325a.32.32 0 0 0-.484.032l-.378.48a.418.418 0 0 0 .036.54l1.32 1.267a.32.32 0 0 0 .484-.034l6.272-8.048a.366.366 0 0 0-.064-.512zm-4.1 0l-.478-.372a.365.365 0 0 0-.51.063L4.566 9.88a.32.32 0 0 1-.484.032L1.892 7.77a.366.366 0 0 0-.516.005l-.423.433a.364.364 0 0 0 .006.514l3.255 3.185a.32.32 0 0 0 .484-.033l6.272-8.048a.365.365 0 0 0-.063-.51z" fill="#92a58c"/></svg>' +
        //        //'<svg xmlns="http://www.w3.org/2000/svg" width="16" height="15" id="msg-dblcheck-ack" x="2063" y="2076"><path d="M15.01 3.316l-.478-.372a.365.365 0 0 0-.51.063L8.666 9.88a.32.32 0 0 1-.484.032l-.358-.325a.32.32 0 0 0-.484.032l-.378.48a.418.418 0 0 0 .036.54l1.32 1.267a.32.32 0 0 0 .484-.034l6.272-8.048a.366.366 0 0 0-.064-.512zm-4.1 0l-.478-.372a.365.365 0 0 0-.51.063L4.566 9.88a.32.32 0 0 1-.484.032L1.892 7.77a.366.366 0 0 0-.516.005l-.423.433a.364.364 0 0 0 .006.514l3.255 3.185a.32.32 0 0 0 .484-.033l6.272-8.048a.365.365 0 0 0-.063-.51z" fill="#0973ba"/></svg>' +
        //        //'</span>' +
        //        '</span>';

        //    conversation.appendChild(element);

        //    //setTimeout(function () {
        //    //    var tick = element.querySelector('.tick');
        //    //    tick.classList.remove('tick-animation');
        //    //}, 500);

        //    conversation.scrollTop = conversation.scrollHeight;
        //}

    });
}

$(document).ready(function () {
    InicializaHUB();

    //$(".input-msg").on('keydown', function (e) {
    //    if (e.which === 13) {
    //        _CNXHUB.invoke("teste", $("#uid").val(), $("#id_para").val(), $(this).val());
    //    } else {
    //        Teclando();
    //    }
    //});
});



























































//async function start() {
//    try {
//        await connection.start();
//        //console.log("[" + (new Date().toLocaleDateString() + " " + new Date().toLocaleTimeString()) + "] signalR reconectado");
//    } catch (err) {
//        //console.log("[" + (new Date().toLocaleDateString() + " " + new Date().toLocaleTimeString()) + "] signalR err: " + err);
//        setTimeout(() => start(), 5000);
//    }
//}
//try {
//    const connection = new signalR
//        .HubConnectionBuilder()
//        .withUrl("/notificacoes", {
//            //skipNegotiation: true,
//            //transport: signalR.HttpTransportType.WebSockets
//        })
//        //.withUrl("/notificacoes", options => {
//        //    options.AccessTokenProvider = async () => {
//        //        // Get and return the access token.
//        //    };
//        //})
//        //.configureLogging(signalR.LogLevel.Information)
//        .build();

//    //connection.serverTimeoutInMilliseconds = 9999999999999;

//    connection.serverTimeoutInMilliseconds = 60000;

//    connection.start()
//        .then(function () {
//            //console.log("[" + (new Date().toLocaleDateString() + " " + new Date().toLocaleTimeString()) + "] signalR escutando");
//        })
//        .catch(err => console.log(err)); //'Error while establishing connection :('));

//    //console.log(this._hubConnection);

//    connection.onclose(async () => {
//        //console.log("[" + (new Date().toLocaleDateString() + " " + new Date().toLocaleTimeString()) + "] signalR fechado");
//        await start();
//    });

//    connection.on("quemsoueu", async (user, status, email) => {
//        //console.log("[" + (new Date().toLocaleDateString() + " " + new Date().toLocaleTimeString()) + "] " + email + " " + status + " com ID " + user);
//        $("#canal_" + email).val(user);
//        $("#cnxid_" + email).val(user);
//    });
//    connection.on("listaclientes", async (lsthtml) => {
//        $(".combo_clientes").html(lsthtml);
//        $(".combo_clientes").change();
//    });
//    connection.on("enviarmens", async (canal, de, para, mens) => {
//        $("#quadro_mens_" + para).append("<li style='text-align:right;padding:8px;font-size:12px;color:red;max-width:80%;word-break:break-all;word-wrap:break-word;'>" + de + ": " + mens + "<li/>");

//        var _rafa = de;
//        var _vi = para;
//        _rafa = _rafa.replace('@Html.Raw("@")', '');
//        _vi = _vi.replace('@Html.Raw("@")', '');
//        var _rafasemponto = _rafa;
//        var _visemponto = _vi;
//        _rafasemponto = _rafasemponto.replace(/\./g, '');
//        _visemponto = _visemponto.replace(/\./g, '');

//        var _alturaCxMensDe = $("#quadro_mens_" + _rafasemponto);
//        var _alturaCxMensPara = $("#quadro_mens_" + _visemponto);

//        $("#quadro_mens_" + _rafasemponto).animate({ scrollTop: _alturaCxMensDe.height() }, 1500);
//        $("#quadro_mens_" + _visemponto).animate({ scrollTop: _alturaCxMensPara.height() }, 1500);
//    });
//    connection.on("quadromens", async (canal, para, mens) => {
//        ExibeMensQuadro(de, para, mens);
//    });
//    connection.on("forcelogoff", function (user, message) {
//        procForceLogOff(user, message);
//    });
//} catch (e) { console.log('ERRO: ' + e); }











//connection.on('novanotificacao', function ()
//{
//});
//var hub =
//    connection
//    .createHubProxy('notificacoes');
//var novanotificacao = function () { ExibeNotificacoes(); };
//var obtconnId = function () { Conecta(); };
//connection.on('novanotificacao', novanotificacao);
//connection.on('obterconnectionid', obtconnId);
//connection.disconnected(function () {
//    setTimeout(function () {
//        IniciaHub();
//    }, 5000);
//});
//connection.onclose(async () => { await IniciaHub(); });
//async function start() {
//    try {
//        await connection.start();
//        console.log("[" + (new Date().toLocaleDateString() + " " + new Date().toLocaleTimeString()) + "] signalR reconectado");
//    } catch (err) {
//        //console.log(err);
//        setTimeout(() => start(), 5000);
//    }
//}
//async function IniciaHub() {
//    //setTimeout(function () {
//    connection.start(
//        //{
//        //    transport: ['webSockets', 'serverSentEvents', 'longPolling']
//        //})
//        )
//        .then(function () {
//            var _resposta = Conecta();
//            console.log('Hub iniciado com o id ' + JSON.stringify(_resposta));
//            //connection.invoke("obterconnectionid");
//            //console.log('Hub iniciado com o id ' + connection.id + ' por ' + connection.transport.name);
//            //$("#layoutcms_rodape").html('<b class="i i-flow-tree"></b> <small class="text-muted" style="font-size:9px;">' + connection.id + '</small>');
//            //$("#spin-signalr").removeClass('show');
//            //$("#spin-signalr").removeClass('inline');
//            //$("#spin-signalr").addClass('hide');
//        });
//    //}, 5000);
//}
//function ExibeNotificacoes() {
//    console.log('ExibeNotificacoes');
//}
//function Conecta() {
//    //return connection.invoke("obterconnectionid");
//}
//function NovaNotificacao(str) {
//    console.log(str);
//}
//$(document).ready(function () {
//    IniciaHub();
//});