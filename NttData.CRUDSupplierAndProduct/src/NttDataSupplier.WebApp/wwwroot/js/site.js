// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {   

    $('#juridical-tab').click(function () {
        $('#juridicalAttribute').val("Juridical");
    });

    $('#physical-tab').click(function () {
        $('#physicalAttribute').val("Physical");
    });

});

$(document).ready(function () {

    //abre a janela do windows para procurar uma foto
    $('.img-upload').click(function () {
        $(this).parent().find('.input-file').click();
    });

    $('.input-file').change(function () {
        var file = new FormData();

        file.append('file', $(this)[0].files[0]);
        var image = $(this).parent().find('.img-upload');

        image.attr("src", data.caminho);
    });   

});




//Mask igorescobar
//Doc https://igorescobar.github.io/jQuery-Mask-Plugin/
$(document).ready(function () {
    $('.date').mask('00/00/0000');
    $('.time').mask('00:00:00');
    $('.date_time').mask('00/00/0000 00:00:00');
    $('.cep').mask('00000-000');
    $('.mask_fixo').mask('(00) 0000-0000');
    $('.mask_celular').mask('(00) 0.0000-0000');
    $('.phone_us').mask('(000) 000-0000');
    $('.mixed').mask('AAA 000-S0S');
    $('.cpf').mask('000.000.000-00', { reverse: true });
    $('.cnpj').mask('00.000.000/0000-00', { reverse: true });
    $('.money').mask('000.000.000.000.000,00', { reverse: true });
    $('.money2').mask("#.##0,00", { reverse: true });
    $('.ip_address').mask('0ZZ.0ZZ.0ZZ.0ZZ', {
        translation: {
            'Z': {
                pattern: /[0-9]/, optional: true
            }
        }
    });
    $('.ip_address').mask('099.099.099.099');
    $('.percent').mask('##0,00%', { reverse: true });
    $('.clear-if-not-match').mask("00/00/0000", { clearIfNotMatch: true });
    $('.placeholder').mask("00/00/0000", { placeholder: "__/__/____" });
    $('.fallback').mask("00r00r0000", {
        translation: {
            'r': {
                pattern: /[\/]/,
                fallback: '/'
            },
            placeholder: "__/__/____"
        }
    });
    $('.selectonfocus').mask("00/00/0000", { selectOnFocus: true });
});


//Pre visualização da imagem

document.getElementById("ImageOne").onchange = function () {
    var reader = new FileReader();

    reader.onload = function (e) {
        // get loaded data and render thumbnail.
        document.getElementById("previewImageOne").src = e.target.result;
    };

    // read the image file as a data URL.
    reader.readAsDataURL(this.files[0]);
};

document.getElementById("ImageTwo").onchange = function () {
    var reader = new FileReader();

    reader.onload = function (e) {
        // get loaded data and render thumbnail.
        document.getElementById("previewImageTwo").src = e.target.result;
    };

    // read the image file as a data URL.
    reader.readAsDataURL(this.files[0]);
};

document.getElementById("ImageTree").onchange = function () {
    var reader = new FileReader();

    reader.onload = function (e) {
        // get loaded data and render thumbnail.
        document.getElementById("previewImageTree").src = e.target.result;
    };

    // read the image file as a data URL.
    reader.readAsDataURL(this.files[0]);
};

document.getElementById("ImageFor").onchange = function () {
    var reader = new FileReader();

    reader.onload = function (e) {
        // get loaded data and render thumbnail.
        document.getElementById("previewImageFor").src = e.target.result;
    };

    // read the image file as a data URL.
    reader.readAsDataURL(this.files[0]);
};

document.getElementById("ImageFive").onchange = function () {
    var reader = new FileReader();

    reader.onload = function (e) {
        // get loaded data and render thumbnail.
        document.getElementById("previewImageFive").src = e.target.result;
    };

    // read the image file as a data URL.
    reader.readAsDataURL(this.files[0]);
};