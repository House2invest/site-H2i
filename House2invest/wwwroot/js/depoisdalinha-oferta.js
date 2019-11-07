"use strict";
var KTWizard2 = function () {
    var wizardEl;
    var formEl;
    var validator;
    var wizard;
    var initWizard = function () {
        wizard = new KTWizard('kt_wizard_v2', {
            startStep: 1
        });
        wizard.on('beforeNext', function (wizardObj) {
            if (validator.form() !== true) {
                wizardObj.stop();
            }
        });
        wizard.on('change', function (wizard) {
            //KTUtil.scrollTop();
        });
    };
    var initValidation = function () {
        validator = formEl.validate({
            //ignore: ":hidden",
            rules: {
                oferta_form_valor: {
                    required: true
                }
                //,
                //lname: {
                //    required: true
                //},
                //phone: {
                //    required: true
                //},
                //emaul: {
                //    required: true,
                //    email: true
                //},
                //address1: {
                //    required: true
                //},
                //postcode: {
                //    required: true
                //},
                //city: {
                //    required: true
                //},
                //state: {
                //    required: true
                //},
                //country: {
                //    required: true
                //},
                //delivery: {
                //    required: true
                //},
                //packaging: {
                //    required: true
                //},
                //preferreddelivery: {
                //    required: true
                //},
                //locaddress1: {
                //    required: true
                //},
                //locpostcode: {
                //    required: true
                //},
                //loccity: {
                //    required: true
                //},
                //locstate: {
                //    required: true
                //},
                //loccountry: {
                //    required: true
                //},
                //ccname: {
                //    required: true
                //},
                //ccnumber: {
                //    required: true,
                //    creditcard: true
                //},
                //ccmonth: {
                //    required: true
                //},
                //ccyear: {
                //    required: true
                //},
                //cccvv: {
                //    required: true,
                //    minlength: 2,
                //    maxlength: 3
                //}
            },
            invalidHandler: function (event, validator) {
                //KTUtil.scrollTop();
                swal.fire({
                    "title": "",
                    "text": "Existem alguns erros no seu envio. Por favor, corrija-os.",
                    "type": "error",
                    "confirmButtonClass": "btn btn-secondary"
                });
            },
            submitHandler: function (form) {
                console.log(form);
            }
        });
    };
    var initSubmit = function () {
        var btn = formEl.find('[data-ktwizard-type="action-submit"]');
        btn.on('click', function (e) {
            e.preventDefault();
            if (validator.form()) {
                KTApp.progress(btn);
                //KTApp.block(formEl);
                // See: http://malsup.com/jquery/form/#ajaxSubmit
                formEl.ajaxSubmit({
                    success: function () {
                        KTApp.unprogress(btn);
                        //KTApp.unblock(formEl);
                        swal.fire({
                            "title": "",
                            "text": "Parabéns! Vc. fez um investimento",
                            "type": "success",
                            "confirmButtonClass": "btn btn-secondary"
                        });
                    }
                });
            }
        });
    };
    return {
        init: function () {
            wizardEl = KTUtil.get('kt_wizard_v2');
            formEl = $('#kt_form');
            initWizard();
            initValidation();
            initSubmit();
        }
    };
}();
jQuery(document).ready(function () {
    KTWizard2.init();
});