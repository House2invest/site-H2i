var searchVisible = 0;
var transparent = true;
var mobile_device = false;

$(document).ready(function () {
    $.material.init();
    $('[rel="tooltip"]').tooltip();

    var $validator = $('.wizard-card form').validate({
        rules: {
            Input_Email: {
                required: true,
                minlength: 3
            },
            Input_Password: {
                required: true,
                minlength: 3
            },
            Input_ConfirmPassword: {
                required: true,
                minlength: 3
            },
            Input_ImagemDocDigitalizado: {
                required: true
            },
            Input_ImagemSelfie: {
                required: true
            },
            //Input_ContatoAutenticacao_EmailAlternativo: {
            //    required: true
            //},
            Input_Contato_Fone_Celular: {
                required: true
            },
            Input_Nome: {
                required: true,
                minlength: 3
            }
        },
        errorPlacement: function (error, element) {
            $(element).parent('div').addClass('has-error');
        }
    });

    $('.wizard-card').bootstrapWizard({
        'tabClass': 'nav nav-pills',
        'nextSelector': '.btn-next',
        'previousSelector': '.btn-previous',
        onNext: function (tab, navigation, index) {
            var $valid = $('.wizard-card form').valid();
            if (!$valid) {
                $validator.focusInvalid();
                return false;
            }
        },
        onInit: function (tab, navigation, index) {
            var $total = navigation.find('li').length;
            var $wizard = navigation.closest('.wizard-card');
            $first_li = navigation.find('li:first-child a').html();
            $moving_div = $('<div class="moving-tab">' + $first_li + '</div>');
            $('.wizard-card .wizard-navigation').append($moving_div);
            refreshAnimation($wizard, index);
            $('.moving-tab').css('transition', 'transform 0s');
        },
        onTabClick: function (tab, navigation, index) {
            var $valid = $('.wizard-card form').valid();
            if (!$valid) {
                return false;
            } else {
                return true;
            }
        },
        onTabShow: function (tab, navigation, index) {
            var $total = navigation.find('li').length;
            var $current = index + 1;
            var $wizard = navigation.closest('.wizard-card');
            // If it's the last tab then hide the last button and show the finish instead
            if ($current >= $total) {
                $($wizard).find('.btn-next').hide();
                $($wizard).find('.btn-finish').show();
            } else {
                $($wizard).find('.btn-next').show();
                $($wizard).find('.btn-finish').hide();
            }
            button_text = navigation.find('li:nth-child(' + $current + ') a').html();
            setTimeout(function () {
                $('.moving-tab').text(button_text);
            }, 150);
            var checkbox = $('.footer-checkbox');
            if (!index === 0) {
                $(checkbox).css({
                    'opacity': '0',
                    'visibility': 'hidden',
                    'position': 'absolute'
                });
            } else {
                $(checkbox).css({
                    'opacity': '1',
                    'visibility': 'visible'
                });
            }
            refreshAnimation($wizard, index);
        }
    });

    //$("#wizard-picture").change(function(){
    $("#Input_ImagemSelfie").change(function () {
        readURL(this, 'wizardPicturePreview');
    });
    $("#Input_ImagemDocDigitalizado").change(function () {
        readURL(this, 'wizardPicturePreviewDOC');
    });
    $("#Input_ImagemComprovanteResidencia").change(function () {
        readURL(this, 'wizardPicturePreviewCOMPROVRESID');
    });

    $('[data-toggle="wizard-radio"]').click(function () {
        wizard = $(this).closest('.wizard-card');
        wizard.find('[data-toggle="wizard-radio"]').removeClass('active');
        $(this).addClass('active');
        $(wizard).find('[type="radio"]').removeAttr('checked');
        $(this).find('[type="radio"]').attr('checked', 'true');
    });
    $('[data-toggle="wizard-checkbox"]').click(function () {
        if ($(this).hasClass('active')) {
            $(this).removeClass('active');
            $(this).find('[type="checkbox"]').removeAttr('checked');
        } else {
            $(this).addClass('active');
            $(this).find('[type="checkbox"]').attr('checked', 'true');
        }
    });
    $('.set-full-height').css('height', 'auto');

    $('.campo_data').mask('00/00/0000');
    $("#Input_Contato_CEP").mask('00000-000');
    $("#Input_Email").inputmask({ alias: "email", casing: "lower" });
    $("#Input_ContatoAutenticacao_EmailAlternativo").inputmask({ alias: "email", casing: "lower" });
    $("#Input_Contato_FoneCelular").inputmask({ mask: ["(99) 9999-9999", "(99) 99999-9999"], keepStatic: true });
    $("#Input_Contato_FoneComercial").inputmask({ mask: ["(99) 9999-9999", "(99) 99999-9999"], keepStatic: true });
    $("#Input_Documentacao_CPF").mask('000.000.000/00');
    $("#Input_Documentacao_CNPJ").mask('00.000.000/0000-00');
    function limpa_formulario_cep() {
        $("#Input_Contato_Logradouro").val("");
        $("#Input_Contato_Bairro").val("");
        $("#Input_Contato_Cidade").val("");
        $("#Input_Contato_Estado").val("");
    }

    $("#Input_Contato_CEP").on('keyup', function () {
        if (!parseInt($(this).val().replace(/\D/g, ''))) {
            return;
        }
        var cep = $(this).val().replace(/\D/g, '');
        if (cep !== "") {
            var validacep = /^[0-9]{8}$/;
            if (validacep.test(cep)) {
                $("#Input_Contato_Logradouro").val("...");
                $("#Input_Contato_Bairro").val("...");
                $("#Input_Contato_Cidade").val("...");
                $("#Input_Contato_Estado").val("...");
                $.getJSON("https://viacep.com.br/ws/" + cep + "/json/?callback=?", function (dados) {
                    if (!("erro" in dados)) {
                        $("#Input_Contato_Logradouro").val(dados.logradouro);
                        $("#Input_Contato_Bairro").val(dados.bairro);
                        $("#Input_Contato_Cidade").val(dados.localidade);
                        $("#Input_Contato_Estado").val(dados.uf);
                    }
                    else {
                        limpa_formulario_cep();
                        //alert("CEP não encontrado.");
                    }
                });
            }
            else {
                limpa_formulario_cep();
                //alert("Formato de CEP inválido.");
            }
        }
        else {
            limpa_formulario_cep();
        }
    });
    $("#Input_Financeiro_Investidor_Perfil").on('change', function (e) {
        $('#hyperlink_anexo').attr('href', '/documentacao/documento?tp=anexo4' + $("#Input_Financeiro_Investidor_Perfil").val());
        $('#hyperlink_anexo').html($("#Input_Financeiro_Investidor_Perfil option:selected").text());
    });
    $("#Input_Financeiro_Investidor_Perfil").trigger('change');
});

$(window).resize(function () {
    $('.wizard-card').each(function () {
        $wizard = $(this);
        index = $wizard.bootstrapWizard('currentIndex');
        refreshAnimation($wizard, index);
        $('.moving-tab').css({
            'transition': 'transform 0s'
        });
    });
});

function readURL(input, id) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $('#' + id).attr('src', e.target.result).fadeIn('slow');
            $('.picture').removeClass("has-error");
        };
        reader.readAsDataURL(input.files[0]);
    }
}
function refreshAnimation($wizard, index) {
    $total = $wizard.find('.nav li').length;
    $li_width = 100 / $total;
    total_steps = $wizard.find('.nav li').length;
    move_distance = $wizard.width() / total_steps;
    index_temp = index;
    vertical_level = 0;
    mobile_device = $(document).width() < 600 && $total > 3;
    if (mobile_device) {
        move_distance = $wizard.width() / 2;
        index_temp = index % 2;
        $li_width = 50;
    }

    $wizard.find('.nav li').css('width', $li_width + '%');
    step_width = move_distance;
    move_distance = move_distance * index_temp;
    $current = index + 1;

    if ($current === 1 || (mobile_device === true && (index % 2 === 0))) {
        move_distance -= 8;
    } else if ($current === total_steps || (mobile_device === true && (index % 2 === 1))) {
        move_distance += 8;
    }

    if (mobile_device) {
        vertical_level = parseInt(index / 2);
        vertical_level = vertical_level * 38;
    }

    $wizard.find('.moving-tab').css('width', step_width);
    $('.moving-tab').css({
        'transform': 'translate3d(' + move_distance + 'px, ' + vertical_level + 'px, 0)',
        'transition': 'all 0.5s cubic-bezier(0.29, 1.42, 0.79, 1)'

    });
}
materialDesign = {
    checkScrollForTransparentNavbar: debounce(function () {
        if ($(document).scrollTop() > 260) {
            if (transparent) {
                transparent = false;
                $('.navbar-color-on-scroll').removeClass('navbar-transparent');
            }
        } else {
            if (!transparent) {
                transparent = true;
                $('.navbar-color-on-scroll').addClass('navbar-transparent');
            }
        }
    }, 17)
};
function debounce(func, wait, immediate) {
    var timeout;
    return function () {
        var context = this, args = arguments;
        clearTimeout(timeout);
        timeout = setTimeout(function () {
            timeout = null;
            if (!immediate) func.apply(context, args);
        }, wait);
        if (immediate && !timeout) func.apply(context, args);
    };
}