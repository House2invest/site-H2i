$.fn.exchangePositionWith = function (selector) {
    var other = $(selector);
    this.after(other.clone());
    other.after(this).remove();
};
function trimSpaces(a) {
    s = document.getElementById(a).value;
    s = s.replace(/(^\s*)|(\s*$)/gi, "");
    s = s.replace(/[ ]{2,}/gi, " ");
    s = s.replace(/\n /, "\n");
    document.getElementById(a).value = s;
}

//var messageTime = document.querySelectorAll('.message .time');
//var _momento = moment();
//_momento.locale('pt-BR');
//for (var i = 0; i < messageTime.length; i++) {
//    messageTime[i].innerHTML = _momento.format('HH:mm');
//}
//var form = document.querySelector('.conversation-compose');

var conversation = document.querySelector('.conversation-container');
//var conversation = $("#salachat_quadromens_" + $('#salachat_remet_uid').val() + "_" + $('#salachat_dest_uid').val());
function newMessage(m, c, d) {
    //var input = $("#salachat_mensagem_" + $('#salachat_remet_uid').val() + "_" + $('#salachat_dest_uid').val());
    //if (input.val()) {
    if (m) {
        //var message = buildMessage(input.val(), e);
        var message = buildMessage(m, c, d);
        conversation.appendChild(message);
        conversation.scrollTop = conversation.scrollHeight;
    }
}
function buildMessage(text, classe, data) {
    //var element = document.createElement('div');
    var element = document.createElement('li');
    //element.classList.add('message', classe);
    element.classList.add(classe);
    element.innerHTML =
        //'<img src="/images/sem-imagem.png" alt="">' +
        '<p>' + text +
        //'<span class="mens-datahora">' + data + '</span>';
        '<span class="metadata">' +
        '<span class="time">' + data + '</span>' +
        '</span>' +
        '</p>';


    //element.innerHTML = text +
    //    '<span class="metadata">' +
    //    //'<span class="time">' + _momento.format('HH:mm') + '</span>' +
    //    '<span class="time">' + data + '</span>' +
    //    '</span>';

    return element;
}
function Teclando() {
    var input = $("#salachat_mensagem_" + $('#salachat_remet_uid').val() + "_" + $('#salachat_dest_uid').val());
    if (input.val() !== null && input.val() !== undefined && input.val() !== '') {
        var _para = $("#salachat_dest_uid").val();
        $.ajax({ url: "/api/hubmens/teclando?para=" + _para });
    }
}
function SelecionaConversa() {
    // SETA O CONTATO COMO ATIVO
    var _achei = $("ul").find("[data-id='" + $("#salachat_dest_uid").val() + "']");
    if (_achei.attr('data-avatar') !== undefined) {
        //_achei.removeClass("active");
        //$("ul").find("[data-id='" + $("#salachat_dest_uid").val() + "']").removeClass("active");
        _achei.addClass("active");

        document.getElementById("salachat_dest_avatar_" + $("#salachat_dest_uid").val()).src = _achei.attr('data-avatar');
        document.getElementById("salachat_dest_nome_" + $("#salachat_dest_uid").val()).innerText = _achei.attr('data-nome');

        document.getElementById("salachat_dest_status_" + $("#salachat_dest_uid").val()).innerText = $("ul").find("[data-id='" + $("#salachat_dest_uid").val() + "']").attr("data-status");
        if (_achei.attr("data-status") === 'ONLINE') {
            $("#salachat_dest_status_" + $("#salachat_dest_uid").val()).addClass("text-bold");
        } else {
            $("#salachat_dest_status_" + $("#salachat_dest_uid").val()).addClass("text-invisivel");
        }

        $("#__CHAT_menschatselemens").fadeOut("fast", function () {
            $("#__CHAT_menschatselemens").addClass("invisivel");

            //$(".page").removeClass("invisivel");
            //$(".page").fadeIn("slow", function () { });

            //messages
            $(".contact-profile").removeClass("invisivel");
            $(".messages").removeClass("invisivel");
            $(".message-input").removeClass("invisivel");

            $(".messages").fadeIn("slow", function () { });
        });

        $("#salachat_remet_objcontato_mensnlidas_" + $("#salachat_dest_uid").val()).html("0");
        $("#salachat_remet_objcontato_mensnlidas_" + $("#salachat_dest_uid").val()).addClass("invisivel");

        Historico($("#salachat_dest_uid").val());

        var _divscroll = document.querySelector('.messages');
        _divscroll.scrollTop = _divscroll.scrollHeight;

        // ENVIAR O ITEM LI PARA A PRIMEIRA POSICAO NA UL
        //var _indice = $("ul").find("[data-id='" + para + "']");
        //$("#contacts ul li:eq(" + _indice.index() + ")").exchangePositionWith("#contacts ul li:eq(0)");
    }
}
$("#salachat_mensagem_" + $('#salachat_remet_uid').val() + "_" + $('#salachat_dest_uid').val()).on('keyup', function (e) {
    var _txtarea = $("textarea#salachat_mensagem_" + $('#salachat_remet_uid').val() + "_" + $('#salachat_dest_uid').val());
    var _idusu_de = $('#salachat_remet_uid').val();
    var _idusu_para = $('#salachat_dest_uid').val();
    var _mens = _txtarea.val();

    if (e.keyCode === 13) {
        if (_txtarea.val() < 2) {
            _txtarea.val('');
            return false;
        }

        if (_idusu_para === null || _idusu_para === undefined || _idusu_para === '') {
            alert('SELECIONE UM USUÁRIO');
            _txtarea.focus();
            return false;
        }

        try {
            newMessage(_mens, "replies", new Date().toLocaleTimeString("pt-BR", { hour12: false}));

            //var _novamens = document.querySelector('.conversation-container');
            //var _novamensconversacao = document.createElement('li');
            //_novamensconversacao.classList.add("replies");
            //_novamensconversacao.innerHTML = '<p>' + _mens + '</p>';
            //_novamens.appendChild(_novamensconversacao);

            var _divscroll = document.querySelector('.messages');
            _divscroll.scrollTop = _divscroll.scrollHeight;

            // ENVIAR O ITEM LI PARA A PRIMEIRA POSICAO NA UL
            var _indice = $("ul").find("[data-id='" + _idusu_para + "']");
            $("#contacts ul li:eq(" + _indice.index() + ")").exchangePositionWith("#contacts ul li:eq(0)");

            $.ajax({
                type: "POST",
                url: "/api/hubmens/correio",
                data:
                {
                    'de': _idusu_de,
                    'para': _idusu_para,
                    'mens': _mens
                },
                complete: function () { },
                success: function (result) {
                    _txtarea.val('');
                    _txtarea.focus();

                    _novamens.scrollTop = _novamens.scrollHeight;
                }
            });
        } catch (e) { var _erro = e; }
    } else {
        Teclando();
    }
});
function procForceLogOff(user, message) {
    var scrollLeft = window.pageXOffset || document.documentElement.scrollLeft;
    var scrollTop = window.pageYOffset || document.documentElement.scrollTop;
    jQuery.ajax({
        url: "/api/sistema/forcalogoff?id=" + user + "&sl=" + scrollLeft + "&st=" + scrollTop + "&rota=" + window.location.href,
        complete: function () { },
        success: function (retorno) {
            if (retorno.status === "ok") {
                window.location.href = "/LogOffForcado";
            }
        },
        error: function (error) { }
    });
}

$(".send").on("click", function () {
    var e = jQuery.Event("keyup");
    e.which = 13;
    e.keyCode = 13;
    //$("#theInputToTest").trigger(e);

    $("#salachat_mensagem_" + $('#salachat_remet_uid').val() + "_" + $('#salachat_dest_uid').val()).trigger(e);
});
//$("#salachat_mensagem_" + $('#salachat_remet_uid').val() + "_" + $('#salachat_dest_uid').val())

var _CNXHUB;
async function ReiniciaHUB(hub) {
    try {
        await hub.start();
    } catch (err) {
        setTimeout(() => ReiniciaHUB(hub), 2500);
    }
}
function InicializaHUB() {
    _CNXHUB = new signalR.HubConnectionBuilder().withUrl("/mensagens").configureLogging(signalR.LogLevel.None).build();
    _CNXHUB.start().then(function () { }).catch(err => console.log("Erro ao tentar estabelecer conexão ao socket principal."));
    _CNXHUB.onclose(async () => { await ReiniciaHUB(_CNXHUB); });

    _CNXHUB.on("correio", async (de, para, mens, cnxid_de, cnxidpara) => {
        var conversacao = document.getElementById("salachat_quadromens_" + para + "_" + de);
        //$("#salachat_quadromens_" + $('#salachat_remet_uid').val() + "_" + $('#salachat_dest_uid').val()).html(_item);
        if (conversacao !== null) {
            //var mensagem = buildMessage(mens, "received");
            //conversacao.appendChild(mensagem);
            //conversacao.scrollTop = conversacao.scrollHeight;

            newMessage(mens, "sent", new Date().toLocaleTimeString("pt-BR", { hour12: false }));
            //var _item = '';
            //_item += '<li class="sent">';
            ////_item += '<img src="/images/sem-imagem.png" alt="">';
            //_item += '<p>' + mens + '</p>';
            //_item += '</li>';

            //$("#salachat_quadromens_" + para + "_" + de).append(_item);

            //var _novamens = document.querySelector('.conversation-container');
            //var _novamensconversacao = document.createElement('li');
            //_novamensconversacao.classList.add("sent");
            //_novamensconversacao.innerHTML = '<p>' + mens + '</p>';
            //_novamens.appendChild(_novamensconversacao);

            var _divscroll = document.querySelector('.messages');
            _divscroll.scrollTop = _divscroll.scrollHeight;
        } else {
            //notif_corpo_push_@_notif.De
            var _push = document.getElementById("notif_corpo_push_" + de);
            if (_push === null) {
                var _totnlidasgeral = parseInt($(".notification-icon").html()) + 1;
                $(".notification-icon").html(_totnlidasgeral);
            }
            $("#salachat_remet_objcontato_mensnlidas_" + de).html(parseInt($("#salachat_remet_objcontato_mensnlidas_" + de).html()) + 1);
            $("#salachat_remet_objcontato_mensnlidas_" + de).removeClass("invisivel");
            Notificacoes();
        }
    });
    _CNXHUB.on("teclando", async (de, para, id_de, id_para) => {
        var id = window.setTimeout(function () { }, 0);
        while (id--) { window.clearTimeout(id); }
        $("#salachat_dest_status_" + id_de).html("digitando ...");
        $("#salachat_dest_status_" + id_de).fadeIn('slow');
        $("#salachat_remet_objcontato_status_" + id_de).html("digitando ...");
        $("#salachat_remet_objcontato_status_" + id_de).fadeIn('slow');
        setTimeout(function () {
            $("#salachat_dest_status_" + id_de + ", #salachat_remet_objcontato_status_" + id_de).fadeOut("slow", function () {
                $("#salachat_dest_status_" + id_de).html("online");
                $("#salachat_remet_objcontato_status_" + id_de).html("");
                $("#salachat_dest_status_" + id_de + ", #salachat_remet_objcontato_status_" + id_de).fadeIn("fast");
            });
        }, 1000);
    });
    _CNXHUB.on("quem", async (cnxde, uid, nome, status) => {

        //if (uid !== $("#salachat_remet_uid").val())
        //    console.log(nome + " [" + uid + "] " + status + " com o canal {" + cnxde + "}");

        //--------------------------------
        // ARRUMO AS COISAS NO MEU SIDEBAR
        //--------------------------------
        // altero STATUS em PROFILE
        $("#salachat_remet_status_" + uid).html(status === "ENTROU" ? "online" : "offline");
        $("#salachat_remet_status_" + uid).addClass(status === "ENTROU" ? "text-bold" : "text-invisivel");

        //---------------------------------------
        // ARRUMO AS COISAS NO SIDEBAR DOS OUTROS
        //---------------------------------------
        var _existeNaListaDeOutro = $("ul").find("[data-id='" + uid + "']");

        if (_existeNaListaDeOutro.attr("data-nome") !== undefined) {

            if (_existeNaListaDeOutro.attr("data-id") === uid) {

                if (status === "ENTROU") {
                    var id = window.setTimeout(function () { }, 0);
                    while (id--) { window.clearTimeout(id); }
                    _existeNaListaDeOutro.attr("data-status", "ONLINE");
                    _existeNaListaDeOutro.removeClass("opaco-5");

                    //$("#salachat_remet_objcontato_avatar_" + uid).removeClass("borda-offline").addClass("borda-online");
                    //salachat_remet_objcontato_span_status_@_contato.Id
                    $("#salachat_remet_objcontato_span_status_" + uid).removeClass("offline").addClass("online");

                    $("#salachat_dest_status_" + uid).removeClass("text-invisivel").addClass("text-bold");
                    $("#salachat_dest_status_" + uid).html(_existeNaListaDeOutro.attr("data-status"));
                } else {
                    setTimeout(function () {
                        _existeNaListaDeOutro.attr("data-status", "OFFLINE");
                        _existeNaListaDeOutro.addClass("opaco-5");

                        $("#salachat_dest_status_" + uid + ", #salachat_remet_objcontato_status_" + uid).fadeOut("slow", function () {
                            //$("#salachat_dest_status_" + id_de).html("online");
                            //$("#salachat_remet_objcontato_status_" + id_de).html("");
                            $("#salachat_remet_objcontato_span_status_" + uid).removeClass("online").addClass("offline");
                            $("#salachat_remet_objcontato_avatar_" + uid).removeClass("borda-online").addClass("borda-offline");
                            $("#salachat_dest_status_" + uid).removeClass("text-bold").addClass("text-invisivel");
                            $("#salachat_dest_status_" + uid).html("visto por último " + new Date().toLocaleDateString() + " " + new Date().toLocaleTimeString());
                            $("#salachat_remet_objcontato_status_" + uid).html("");

                            $("#salachat_dest_status_" + uid + ", #salachat_remet_objcontato_status_" + uid).fadeIn("fast");
                        });
                    }, 2000);
                }

            }
        }

    });
    _CNXHUB.on("forcelogoff", function (user, message) {
        procForceLogOff(user, message);
    });
}

$(document).ready(function () {
    InicializaHUB();

    // ESCONDE A SIDEBAR
    //$("#sidebar").addClass("invisivel");

    //$("#sidebar").addClass("shrink show");

    SelecionaConversa();
});