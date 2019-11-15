var credito_dias_txt = document.getElementById("tp_lcd_txt");
var credito_dis_txt = document.getElementById("tp_lc_txt");
var credito_dias_txtarea = document.getElementById("tp_lcd_ta");
var credito_dis_txtarea = document.getElementById("tp_lc_ta");
var municipio_select = document.getElementById("municipio_sel");
function show_credito() {
    credito_dias_txt.style.display = "inline";
    credito_dis_txt.style.display = "inline";
    credito_dias_txtarea.style.display = "inline";
    credito_dis_txtarea.style.display = "inline";
}
function hide_credito() {
    credito_dias_txt.style.display = "none";
    credito_dis_txt.style.display = "none";
    credito_dias_txtarea.style.display = "none";
    credito_dis_txtarea.style.display = "none";
}

function show_municipio(tipo) {
    municipio_select.style.display = "inline";
    clean_municipios();
    var municipios;
    switch (tipo) {
        case 1:
            municipios = ["--Municipios--", "Toluca", "Metepec", "Zinacatepec", "Texcoco", "Jijilpilco", "Ixtlahuaca"];
            break;
        case 2:
            municipios = ["--Municipios--", "Ensenada", "Mexicali", "Tecate", "Tijuana", "Playas de Rosarito"];
            break;
        case 3:
            municipios = ["--Municipios--", "Tequizteapan", "Santiago de Queretaro", "La cuenca", "El campanario"];
            break;
        case 4:
            municipios = ["--Municipios--", "Calkiní", "Campeche", "Carmen", "Champotón"];
            break;
        default:
            municipios = ["--Municipios--"];
    }
    var i = 0;
    while (i < municipios.length) {
        var option = document.createElement("option");
        option.text = municipios[i];
        option.value = municipios[i];
        municipio_select.add(option);
        i++;
    }

}
function hide_municipio() {
    municipio_select.style.display = "none";
}
function clean_municipios() {
    for (i = municipio_select.options.length - 1; i >= 0; i--) {
        municipio_select.remove(i);
    }
}