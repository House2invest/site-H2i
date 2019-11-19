// TROCA ABAS SIDEBAR USUARIO
$(".troca-aba").on('click', function () {
    var _aba = $(this).attr('data-aba');
    if (_aba !== '') {
        $('#' + _aba + "-tab").click();
    }
});