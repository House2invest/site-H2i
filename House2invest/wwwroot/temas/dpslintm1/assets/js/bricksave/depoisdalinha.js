"use strict";
function numberWithCommas(t) {
    var i = t.toString().split(".");
    return i[0] = i[0].replace(/\B(?=(\d{3})+(?!\d))/g, ","), i.join(".");
}
function valorParaReal(numero) {
    var _numero = numero.toFixed(2).split('.');
    //_numero[0] = "R$ " + _numero[0].split(/(?=(?:...)*$)/).join('.');
    _numero[0] = _numero[0].split(/(?=(?:...)*$)/).join('.');
    return _numero.join(',');
}
jQuery.fn.ForceNumericOnly = function () {
    return this.each(function () {
        $(this).keydown(function (t) {
            var i = t.charCode || t.keyCode || 0;
            return 8 === i || 9 === i || 13 === i || 46 === i || 110 === i || 190 === i || 35 <= i && i <= 40 || 48 <= i && i <= 57 || 96 <= i && i <= 105;
        });
    });
};