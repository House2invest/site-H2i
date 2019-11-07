function ExcluirRegistro(tabela, id, refresh, idpai) {
    $.SmartMessageBox({
        title: "<i class='medium mdi-action-delete'></i> <b class='titulomessagox'>Exclusão de registro</b>",
        content: "Deseja realmente excluir o registro de ID <b>" + id + "</b> da TABELA <b>" + tabela + "</b>?",
        buttons: '[Não][Sim]',
        classe: 'msgboxcntvermelho',
        sound: 0,
        closeOnConfirm: false,
        showLoaderOnConfirm: true
    },
        function (ButtonPressed) {
            $("body").removeClass('impedirscroll');
            $("#navprincadm").removeClass('bluraliza');
            $("#main").removeClass('bluraliza');

            if (ButtonPressed === "Sim") {
                $("#imagem-aguarde-cms").removeClass("invisivel");
                jQuery.ajax({
                    //type: "post",
                    url: "/api/sistema/delreg?objeto=" + tabela + "&codigo=" + id,
                    //data: { objeto: tabela, codigo: id },
                    complete: function () { },
                    success: function (retorno) {
                        //console.log(mensagem);
                        if (retorno.mens === "ok") {
                            if (!refresh) {
                                window.location.reload();
                            }
                            else {
                                $("#imagem-aguarde-cms").addClass("invisivel");

                                if (refresh === 'blocoCRUDItemDoc')
                                    CarregaListaMenus('docsinvest', '#body-tbl-documentacao', idpai);
                                //else if (refresh === 'caract')
                                //    CarregaListaMenus('caract', '#body-tbl-caract', idpai);
                                //else if (refresh === 'faq')
                                //    CarregaListaMenus('faq', '#body-tbl-faq', idpai);
                            }

                            //$("#lintbl_tr_" + id).remove();
                            //swal("Exclusão de registro", "O registro foi excluído.", "success");
                            //setTimeout(function () { window.location.reload(); }, 2000);
                            //            if (urlreload != null) {
                            //                window.location.href = urlreload;
                            //            }
                            //            //$('#card_' + id).hide();
                            //            quickRemove('#card_' + id);
                            //            //console.log(divcontainercards);
                            //            //CarregarBlocos('#' + divcontainercards, '.blog');
                            //            $("#imgcarregandobuscar").addClass("elementoinvisivel");
                            //            //swal("Apagando", "O registro foi excluído com sucesso.", "success");
                            //            //ExibeMens('Sucesso', 'O registro foi excluído com sucesso.', 'success');
                            //            //ReiniciaGradedeDados();
                        } else {
                            $("#imagem-aguarde-cms").addClass("invisivel");
                            swal("Exclusão de registro", retorno.mens, "error");
                            //            swal("Apagando", mensagem, "error");
                            //            //ExibeMens('Atenção', mensagem, 'error');
                        }
                    },
                    error: function (error) {
                        //        swal("Apagando", error, "error");
                        //        //ExibeMens('Atenção', "Falha ao excluir o registro.", 'error');
                        $("#imagem-aguarde-cms").addClass("invisivel");
                    }
                });
                //swal("Apagando", "O registro foi excluído com sucesso.", "success");
            }
        });
}

function TransfFundos(tabela, id, tp) {
    $.SmartMessageBox({
        title: "<i class='medium mdi-action-delete'></i> <b class='titulomessagox'>Transferência de Fundos</b>",
        content: "Deseja realmente transferir fundos do investimento de ID <b>" + id + "</b> da TABELA <b>" + tabela + "</b>?",
        buttons: '[Não][Sim]',
        classe: 'msgboxcntvermelho',
        sound: 0,
        closeOnConfirm: false,
        showLoaderOnConfirm: true
    },
        function (ButtonPressed) {
            $("body").removeClass('impedirscroll');
            $("#navprincadm").removeClass('bluraliza');
            $("#main").removeClass('bluraliza');

            if (ButtonPressed === "Sim") {
                $("#imagem-aguarde-cms").removeClass("invisivel");
                jQuery.ajax({
                    url: "/api/sistema/transffundos?objeto=" + tabela + "&codigo=" + id + "&tp=" + tp,
                    complete: function () { },
                    success: function (retorno) {
                        if (retorno.mens === "ok") {
                            window.location.reload();
                        } else {
                            $("#imagem-aguarde-cms").addClass("invisivel");
                            swal("Transferência de fundos", retorno.mens, "error");
                        }
                    },
                    error: function (error) {
                        $("#imagem-aguarde-cms").addClass("invisivel");
                    }
                });
            }
        });
}

//var input = document.getElementById("caixatexto-comando");
var b = document.getElementById("cmd-botao");
var img = document.getElementById("img-aguarde-cmd");

//input.addEventListener("keyup", function (event) {
//    if (event.keyCode === 13) {
//        event.preventDefault();
//        document.getElementById("cmd-botao").click();
//    }
//});

function CriarDump() {
    $("#imagem-aguarde-cms").removeClass("invisivel");

    //input.setAttribute("disabled", "disabled");
    b.setAttribute("disabled", "disabled");
    img.classList.remove("invisivel");

    jQuery.ajax({
        url: "/api/sistema/criardump?titulo=" + $("#caixatexto_titulo_copsegur").val(),
        complete: function () { },
        success: function (retorno) {

            swal({ title: "CÓPIA DE SEGURANÇA", html: retorno.mens, type: retorno.status === "ok" ? "success" : "error" }, function () { window.location.reload(); });

            //setTimeout(function () {
            //    window.location.reload();
            //}, 3000);

            $("#imagem-aguarde-cms").addClass("invisivel");

            //$("#caixatexto-comando-saida-cod").html("COD: " + retorno.cod);
            //$("#caixatexto-comando-saida-sai").html("SAI: " + retorno.sai);
            //$("#caixatexto-comando-saida-err").html("ERR: " + retorno.err);

            //if (retorno.status === "ok") {
            //    //window.location.reload();
            //    swal("DUMP", retorno.mens, "error");
            //} else {
            //    swal("DUMP", retorno.mens, "error");
            //}

            b.removeAttribute("disabled");
            //input.removeAttribute("disabled");
            img.classList.add("invisivel");

            //input.focus();
        },
        error: function (error) {
            //$("#imagem-aguarde-cms").addClass("invisivel");
        }
    });



    //$.SmartMessageBox({
    //    title: "<i class='medium mdi-action-delete'></i> <b class='titulomessagox'>Criar DUMP</b>",
    //    content: "Iniciar o processo de cópia do banco de dados?",
    //    buttons: '[Não][Sim]',
    //    classe: 'msgboxcntvermelho',
    //    sound: 0,
    //    closeOnConfirm: false,
    //    showLoaderOnConfirm: true
    //},
    //    function (ButtonPressed) {
    //        $("body").removeClass('impedirscroll');
    //        $("#navprincadm").removeClass('bluraliza');
    //        $("#main").removeClass('bluraliza');

    //        if (ButtonPressed === "Sim") {


    //            $("#imagem-aguarde-cms").removeClass("invisivel");
    //            jQuery.ajax({
    //                url: "/api/sistema/criardump?comando=" + $("#caixatexto-comando").val(),
    //                complete: function () { },
    //                success: function (retorno) {
    //                    $("#imagem-aguarde-cms").addClass("invisivel");

    //                    $("#caixatexto-comando-saida-cod").html("COD: " + retorno.cod);
    //                    $("#caixatexto-comando-saida-sai").html("SAI: " + retorno.sai);
    //                    $("#caixatexto-comando-saida-err").html("ERR: " + retorno.err);

    //                    //if (retorno.status === "ok") {
    //                    //    //window.location.reload();
    //                    //    swal("DUMP", retorno.mens, "error");
    //                    //} else {
    //                    //    swal("DUMP", retorno.mens, "error");
    //                    //}
    //                },
    //                error: function (error) {
    //                    $("#imagem-aguarde-cms").addClass("invisivel");
    //                }
    //            });


    //        }
    //    });
}
function RestaurarBanco(id) {
    $.SmartMessageBox({
        title: "<i class='medium mdi-action-delete'></i> <b class='titulomessagox'>Restaurar banco</b>",
        content: "Iniciar o processo de restauração do banco de dados?",
        buttons: '[Não][Sim]',
        classe: 'msgboxcntvermelho',
        sound: 0,
        closeOnConfirm: false,
        showLoaderOnConfirm: true
    },
        function (ButtonPressed) {
            $("body").removeClass('impedirscroll');
            $("#navprincadm").removeClass('bluraliza');
            $("#main").removeClass('bluraliza');

            if (ButtonPressed === "Sim") {
                $("#imagem-aguarde-cms").removeClass("invisivel");
                jQuery.ajax({
                    url: "/api/sistema/restaurardump?id=" + id,
                    complete: function () { },
                    success: function (retorno) {
                        $("#imagem-aguarde-cms").addClass("invisivel");

                        if (retorno.status === "ok") {
                            swal("RESTORE", retorno.mens, "success");
                            //console.log(retorno.mens);
                            //window.location.reload();
                        } else {
                            swal("RESTORE", retorno.mens, "error");
                        }
                    },
                    error: function (error) {
                        $("#imagem-aguarde-cms").addClass("invisivel");
                    }
                });
            }
        });
}

function RemoverImagemAlbum(id) {
    $("#div_princ_imagem_album_" + id).remove();

    var $container = $('.grid');
    $container.masonry('reloadItems');
    $container.masonry('layout');
}
function ReorganizarAlbum() {
    var $container = $('.grid');
    $container.masonry('reloadItems');
    $container.masonry('layout');
}
function CarregaListaMenus(tp, idtbl, idbloco) {
    var _item = '';
    try {
        jQuery.ajax({
            url: "/api/sistema/retornalistafilhoslp?tp=" + tp + "&idbloco=" + idbloco,
            complete: function () {
                $(idtbl).html(_item);

                $('.lpcrud-novo-menu').on('click', function (e) {
                    e.preventDefault();
                    var url = $(this).attr('href');
                    swal({
                        title: '<iframe id="frm_lpcrud_menu" name="frm_lpcrud_menu" width="100%" height="100%" frameborder="0" scrolling="yes" allowtransparency="true" src="' + url + '"></iframe>',
                        content: '<iframe width="100%" height="100%" frameborder="0" scrolling="yes" allowtransparency="true" src="' + url + '"></iframe>',
                        html: '<iframe width="100%" height="100%" frameborder="0" scrolling="yes" allowtransparency="true" src="' + url + '"></iframe>',
                        cancelButtonText: 'Fechar',
                        showConfirmButton: false,
                        showCloseButton: false,
                        showCancelButton: true
                    },
                        function (isConfirm) {
                            if (isConfirm) {
                                //
                            } else {
                                CarregaListaMenus('docsinvest', '#body-tbl-documentacao', idbloco);
                                //CarregaListaMenus('caract', '#body-tbl-caract', idlp);
                                //CarregaListaMenus('faq', '#body-tbl-faq', idlp);
                            }
                        });
                });
            },
            success: function (retorno) {
                if (retorno.dados !== null) {
                    for (var i = 0; i < retorno.dados.length; i++) {

                        if (tp === 'docsinvest') {
                            _item += '<tr>';
                            _item += '    <td scope="row">';
                            //_item += '        <a href="/blocoCRUDItemDoc/Edit?idbloco=' + retorno.dados[i].idbloco + '&id=' + retorno.dados[i].id + '" class="btn btn-primary btn-pequeno lpcrud-novo-menu"><i class="far fa-edit"></i></a>';
                            _item += '        <a href="javascript:ExcluirRegistro(\'blocoCRUDItemDoc\', ' + retorno.dados[i].id + ', \'blocoCRUDItemDoc\', ' + retorno.dados[i].idbloco + ');" class="btn btn-danger btn-pequeno"><i class="fa fa-trash"></i></a>';
                            _item += '    </td>';
                            _item += '    <td>';
                            _item += retorno.dados[i].dthr;
                            _item += '    </td>';
                            //_item += '    <td>';
                            //_item += retorno.dados[i].blocotit;
                            //_item += '    </td>';
                            _item += '    <td>';
                            _item += retorno.dados[i].doctit;
                            _item += '    </td>';
                            //_item += '    <td>';
                            //_item += retorno.dados[i].invest_modelodocid;
                            //_item += '    </td>';
                            _item += '</tr>';
                        }
                        //else if (tp === 'caract') {
                        //    _item += '<tr>';
                        //    _item += '    <td scope="row">';
                        //    _item += '        <a href="/lpCRUDCaract/Edit?idlp=' + retorno.dados[i].idlp + '&id=' + retorno.dados[i].id + '" class="btn btn-primary btn-pequeno lpcrud-novo-menu"><i class="far fa-edit"></i></a>';
                        //    _item += '        <a href="javascript:ExcluirRegistro(\'LandsPag_Caract\', ' + retorno.dados[i].id + ', \'caract\', ' + retorno.dados[i].idlp + ');" class="btn btn-danger btn-pequeno"><i class="fa fa-trash"></i></a>';
                        //    _item += '    </td>';
                        //    _item += '    <td>';
                        //    _item += retorno.dados[i].ordem;
                        //    _item += '    </td>';
                        //    _item += '    <td>';
                        //    _item += retorno.dados[i].icone;
                        //    _item += '    </td>';
                        //    _item += '    <td>';
                        //    _item += retorno.dados[i].titulo;
                        //    _item += '    </td>';
                        //    _item += '    <td>';
                        //    _item += retorno.dados[i].descricao;
                        //    _item += '    </td>';
                        //    _item += '</tr>';
                        //}
                        //else if (tp === 'faq') {
                        //    _item += '<tr>';
                        //    _item += '    <td scope="row">';
                        //    _item += '        <a href="/lpCRUDFAQ/Edit?idlp=' + retorno.dados[i].idlp + '&id=' + retorno.dados[i].id + '" class="btn btn-primary btn-pequeno lpcrud-novo-menu"><i class="far fa-edit"></i></a>';
                        //    _item += '        <a href="javascript:ExcluirRegistro(\'LandsPag_FAQ\', ' + retorno.dados[i].id + ', \'faq\', ' + retorno.dados[i].idlp + ');" class="btn btn-danger btn-pequeno"><i class="fa fa-trash"></i></a>';
                        //    _item += '    </td>';
                        //    _item += '    <td>';
                        //    _item += retorno.dados[i].ordem;
                        //    _item += '    </td>';
                        //    _item += '    <td>';
                        //    _item += retorno.dados[i].pergunta;
                        //    _item += '    </td>';
                        //    _item += '    <td>';
                        //    _item += retorno.dados[i].resposta;
                        //    _item += '    </td>';
                        //    _item += '</tr>';
                        //}
                        //else if (tp === 'contatos') {
                        //    _item += '<tr>';
                        //    _item += '    <td scope="row">';
                        //    _item += '        <a href="/lpCRUDContatos/View?idlp=' + retorno.dados[i].idlp + '&id=' + retorno.dados[i].id + '" class="btn btn-primary btn-pequeno lpcrud-novo-menu"><i class="far fa-eye"></i></a>';
                        //    _item += '    </td>';
                        //    _item += '    <td>';
                        //    _item += retorno.dados[i].data;
                        //    _item += '    </td>';

                        //    //_item += '    <td>';
                        //    //_item += retorno.dados[i].corpo_bruto;
                        //    //_item += '    </td>';

                        //    _item += '    <td>';
                        //    _item += retorno.dados[i].corpo_seria;
                        //    _item += '    </td>';

                        //    _item += '</tr>';
                        //}

                    }
                }
            },
            error: function (error) { }
        });

    } catch (e) { console.log(e.message); }
}
function StatusLancamento(id, tp) {
    $.SmartMessageBox({
        title: "<i class='medium mdi-action-check'></i> <b class='titulomessagox'>Mudar status lançamento</b>",
        content: "Deseja realmente alterar o status do lançamento de ID <b>" + id + "</b>?",
        buttons: '[Não][Sim]',
        classe: 'msgboxcntvermelho',
        sound: 0,
        closeOnConfirm: false,
        showLoaderOnConfirm: true
    },
        function (ButtonPressed) {
            $("body").removeClass('impedirscroll');
            $("#navprincadm").removeClass('bluraliza');
            $("#main").removeClass('bluraliza');

            if (ButtonPressed === "Sim") {
                $("#imagem-aguarde-cms").removeClass("invisivel");
                jQuery.ajax({
                    url: "/api/sistema/aprovalanc?codigo=" + id + "&tp=" + tp,
                    complete: function () { },
                    success: function (retorno) {
                        $("#imagem-aguarde-cms").addClass("invisivel");
                        swal({ title: "Aprovação de lançamento", html: retorno.mens, type: retorno.mens === "ok" ? "success" : "warning" }, function () { window.location.reload(); });

                        //if (retorno.mens === "ok") {
                        //    window.location.reload();
                        //} else {
                        //    $("#imagem-aguarde-cms").addClass("invisivel");
                        //    swal({ title: "Aprovação de lançamento", html: retorno.mens, type: "error" }, function () { window.location.reload(); });
                        //}
                    },
                    error: function (error) {
                        $("#imagem-aguarde-cms").addClass("invisivel");
                    }
                });
            }
        });
}
function AcaoContaUsuario(id, idhtml, acao) {
    var chkValor = $('#' + idhtml + ':checked').val();
    if (!chkValor)
        chkValor = "off";

    jQuery.ajax({
        url: "/api/sistema/acaocontausuario?id=" + id + "&tp=" + chkValor + "&acao=" + acao,
        complete: function () { },
        success: function (retorno) {
            if (retorno.mens === "ok") {
                //window.location.reload();
                //swal("ACESSO BLOQUEADO", retorno.mens, "success");
            } else {
                //$("#imagem-aguarde-cms").addClass("invisivel");
                //swal("Aprovação de lançamento", retorno.mens, "error");
                //swal("ACESSO BLOQUEADO", retorno.mens, "error");
            }
        },
        error: function (error) {
            //$("#imagem-aguarde-cms").addClass("invisivel");
        }
    });
}

$("#notifications").on("click", function () {
    $("#icone-fa-comentario").css("color", "#ced4da");
    $("#total_lista_push_notificacoes").addClass("invisivel");
    $("#total_lista_push_notificacoes").html("0");
});
function Notificacoes() {
    var _item = '';
    try {
        $.ajax({
            type: "POST",
            url: "/api/hubmens/mensagensnaolidas",
            complete: function () { },
            success: function (result) {
                if (result.status === 'ok') {
                    $("#total_lista_push_notificacoes").html(result.dados.length);
                    for (var i = 0; i < result.dados.length; i++) {
                        _item += '<a id="notif_corpo_push_' + result.dados[i].de + '" name="notif_corpo_push_' + result.dados[i].de + '" href="/Correio/Conversas?uid=' + result.dados[i].de + '" class="dropdown-item">';
                        _item += '   <div class="d-flex align-items-center">';
                        _item += '       <div class="icon icon-sm text-white">';
                        _item += '           <img src="' + result.dados[i].de_avatar + '" style="max-width:100%;max-height:48px;" />';
                        _item += '       </div>';
                        _item += '       <div class="text ml-2" style="width:100%;">';
                        _item += '           <p class="mb-0">';
                        _item += '               <b style="font-size:8px;color:grey;display:block;text-align:right;font-stretch:normal;">';
                        _item += result.dados[i].dthr;
                        _item += '               </b>';
                        _item += '               <b style="font-size:13px;color:grey;display:block;width:100%;">';
                        _item += result.dados[i].de_nome;
                        _item += '               </b>';
                        _item += '               <div style="font-size:10px;color:grey;white-space:initial;padding-left:5px;padding-top:3px;line-height:11px;" title="' + result.dados[i].mens + '">';
                        _item += result.dados[i].menscortada;
                        _item += '               </div>';
                        _item += '           </p>';
                        _item += '       </div>';
                        _item += '   </div>';
                        _item += '</a>';
                    }

                    if (result.dados.length > 0) {
                        _item += '<div id="divisor_lista_pushs" name="divisor_lista_pushs" class="dropdown-divider"></div>';
                        var _totnlidasgeral = parseInt($("#total_lista_push_notificacoes").html()) + 1;
                        if (_totnlidasgeral > 0) {
                            $("#total_lista_push_notificacoes").removeClass("invisivel");
                            $("#icone-fa-comentario").css("color", "#e45050");
                        }
                    } else {
                        $("#total_lista_push_notificacoes").addClass("invisivel");
                        $("#icone-fa-comentario").css("color", "#ced4da");
                        _item += '<div id="divisor_lista_pushs" name="divisor_lista_pushs" class="dropdown-divider invisivel"></div>';
                    }

                    _item += '<a href="/Correio/Conversas" class="dropdown-item text-center">';
                    _item += '   <small class="font-weight-bold headings-font-family text-uppercase">';
                    _item += '       Todas as conversas';
                    _item += '   </small>';
                    _item += '</a>';
                    $("#lista_pushs").html(_item);
                }
            }
        });
    } catch (e) { console.log(e.message); }
}
function Historico(de) {
    var _item = '';
    try {
        $.ajax({
            type: "POST",
            url: "/api/hubmens/historico?de=" + de,
            complete: function () { },
            success: function (result) {
                if (result.status === 'ok') {
                    for (var i = 0; i < result.dados.length; i++) {
                        //newMessage(result.dados[i].mens, result.dados[i].flag === "R" ? "received" : "sent", result.dados[i].dthr);
                        newMessage(result.dados[i].mens, result.dados[i].flag === "R" ? "sent" : "replies", result.dados[i].dthr);

                        //_item += '<li class="' + (result.dados[i].flag === "R" ? "sent" : "replies") + '">';
                        ////_item += '<img src="/images/sem-imagem.png" alt="">';
                        //_item += '<p>' + result.dados[i].mens + '</p>';
                        //_item += '</li>';

                        //_item += '<div class="message ' + (result.dados[i].flag === "R" ? "received" : "sent") + '">';
                        //_item += result.dados[i].mens;
                        //_item += '<span class="metadata">';
                        //_item += '<span class="time">' + result.dados[i].dthr + '</span>';
                        //_item += '</span>';
                        //_item += '</div>';
                    }

                    Notificacoes();

                    //$("#salachat_quadromens_" + $('#salachat_remet_uid').val() + "_" + $('#salachat_dest_uid').val()).html(_item);
                    ////document.getElementById("salachat_quadromens_" + $('#salachat_remet_uid').val() + "_" + $('#salachat_dest_uid').val()).innerHTML = _item;
                    //var objDiv = document.getElementById("salachat_quadromens_" + $('#salachat_remet_uid').val() + "_" + $('#salachat_dest_uid').val());
                    //objDiv.scrollTop = objDiv.scrollHeight;

                    var _divscroll = document.querySelector('.messages');
                    _divscroll.scrollTop = _divscroll.scrollHeight;
                }
            }
        });
    } catch (e) { console.log(e.message); }
}

function StatusOferta(id, tp) {
    $.SmartMessageBox({
        title: "<i class='medium mdi-action-check'></i> <b class='titulomessagox'>Mudar status da OFERTA</b>",
        content: "Deseja realmente alterar o status da Oferta de ID <b>" + id + "</b>?",
        buttons: '[Não][Sim]',
        classe: 'msgboxcntvermelho',
        sound: 0,
        closeOnConfirm: false,
        showLoaderOnConfirm: true
    },
        function (ButtonPressed) {
            $("body").removeClass('impedirscroll');
            $("#navprincadm").removeClass('bluraliza');
            $("#main").removeClass('bluraliza');

            if (ButtonPressed === "Sim") {
                $("#imagem-aguarde-cms").removeClass("invisivel");

                jQuery.ajax({
                    url: "/api/sistema/alterstatusoferta?codigo=" + id + "&tp=" + tp,
                    complete: function () { },
                    success: function (retorno) {
                        $("#imagem-aguarde-cms").addClass("invisivel");

                        //swal("STATUS da OFERTA", retorno.mens, retorno.status === "ok" ? "success" : "warning");

                        if (retorno.status === "ok") {
                            window.location.reload();
                        } else {
                            $("#imagem-aguarde-cms").addClass("invisivel");
                            //swal("STATUS da OFERTA", retorno.mensagem, retorno.status === "ok" ? "success" : "warning");
                            console.log(retorno.mensagem);
                        }
                    },
                    error: function (error) {
                        $("#imagem-aguarde-cms").addClass("invisivel");
                    }
                });
            }
        });
}
function Revogar(id) {
    $.SmartMessageBox({
        title: "<i class='medium mdi-action-check'></i> <b class='titulomessagox'>Revogar lançamento?</b>",
        content: "Deseja realmente revogar este lançamento?",
        buttons: '[Não][Sim]',
        classe: 'msgboxcntvermelho',
        sound: 0,
        closeOnConfirm: false,
        showLoaderOnConfirm: true
    },
        function (ButtonPressed) {
            $("body").removeClass('impedirscroll');
            $("#navprincadm").removeClass('bluraliza');
            $("#main").removeClass('bluraliza');

            if (ButtonPressed === "Sim") {
                $("#imagem-aguarde-cms").removeClass("invisivel");

                jQuery.ajax({
                    url: "/api/sistema/revogar?codigo=" + id,
                    complete: function () { },
                    success: function (retorno) {
                        $("#imagem-aguarde-cms").addClass("invisivel");

                        //swal("STATUS da OFERTA", retorno.mens, retorno.status === "ok" ? "success" : "warning");

                        if (retorno.status === "ok") {
                            window.location.reload();
                        } else {
                            $("#imagem-aguarde-cms").addClass("invisivel");
                            swal("REVOGAÇÃO DO LANÇAMENTO", retorno.mens, retorno.status === "ok" ? "success" : "warning");
                        }
                    },
                    error: function (error) {
                        $("#imagem-aguarde-cms").addClass("invisivel");
                    }
                });
            }
        });
}

function CancelarInvestimento(id) {
    $.SmartMessageBox({
        title: "<i class='medium mdi-action-check'></i> <b class='titulomessagox'>Cancelar lançamento?</b>",
        content: "Deseja realmente cancelar este lançamento?",
        buttons: '[Não][Sim]',
        classe: 'msgboxcntvermelho',
        sound: 0,
        closeOnConfirm: false,
        showLoaderOnConfirm: true
    },
        function (ButtonPressed) {
            $("body").removeClass('impedirscroll');
            $("#navprincadm").removeClass('bluraliza');
            $("#main").removeClass('bluraliza');

            if (ButtonPressed === "Sim") {
                $("#imagem-aguarde-cms").removeClass("invisivel");

                jQuery.ajax({
                    url: "/api/sistema/cancelarlancamento?codigo=" + id,
                    complete: function () { },
                    success: function (retorno) {
                        $("#imagem-aguarde-cms").addClass("invisivel");
                        if (retorno.status === "ok") {
                            window.location.reload();
                        } else {
                            $("#imagem-aguarde-cms").addClass("invisivel");
                            swal("CANCELAMENTO DO LANÇAMENTO", retorno.mens, retorno.status === "ok" ? "success" : "warning");
                        }
                    },
                    error: function (error) {
                        $("#imagem-aguarde-cms").addClass("invisivel");
                    }
                });
            }
        });
}

function ReenviarEmailLog(id) {
    $.SmartMessageBox({
        title: "<i class='medium mdi-action-check'></i> <b class='titulomessagox'>Reenviar email?</b>",
        content: "Deseja realmente reenviar este email?",
        buttons: '[Não][Sim]',
        classe: 'msgboxcntvermelho',
        sound: 0,
        closeOnConfirm: false,
        showLoaderOnConfirm: true
    },
        function (ButtonPressed) {
            $("body").removeClass('impedirscroll');
            $("#navprincadm").removeClass('bluraliza');
            $("#main").removeClass('bluraliza');

            if (ButtonPressed === "Sim") {
                $("#imagem-aguarde-cms").removeClass("invisivel");

                jQuery.ajax({
                    url: "/api/sistema/reenviaremaillog?codigo=" + id,
                    complete: function () { },
                    success: function (retorno) {
                        $("#imagem-aguarde-cms").addClass("invisivel");
                        if (retorno.status === "ok") {
                            window.location.reload();
                        } else {
                            $("#imagem-aguarde-cms").addClass("invisivel");
                            swal("REENVIO DE EMAIL", retorno.mens, retorno.status === "ok" ? "success" : "warning");
                        }
                    },
                    error: function (error) {
                        $("#imagem-aguarde-cms").addClass("invisivel");
                    }
                });
            }
        });
}