function open(valor) {
    if (valor == '') {
        valor.val = 'slow';
    }
    $('.ventana').slideDown(valor);
}

function cerrar() {
    $('.ventana').slideUp("fast");
    $('.formularioControl').val('');
    $('#Label1').val('');

}

function cerrarSesion() {
    var a = '';
    
    $('#uli').append('<li id="controlI11"><a id="controlI11" href="../form-hereda/Registro.aspx"><span class="glyphicon glyphicon-user"></span>Registrate</a></li>');
    $('#uli').append('<li id="controlI22"><a id="controlI22" href="javascript:open(' + a + ')"><span class="glyphicon glyphicon-log-in"></span>Iniciar sesión</a></li>');
    $('#l1').remove();
    $('#l2').remove();
    botonOcultoEliminar();
}
function botonOcultoEliminar() {

    var boton = document.getElementById('<%=btnEliminar.ClientID%>');

    boton.click();

}
function anadir(valor) {
    $('#'+valor+'').addClass('.izquierdaL');
}
function iniciarsesion(valor) {
    $('#controlI11').remove();
    $('#controlI22').remove();
    $('#uli').append('<li id="l1"><a>' + valor + '</a></li><li id="l2"><a href="javascript:cerrarSesion();">Cerrar Sesión</a></li><asp:Buttton id="btnEliminar1" runat="server" Text="Get" none" OnClick="btnEliminar_Click"/>');
    
}
$(".letras").keypress(function (key) {
    window.console.log(key.charCode)
    if ((key.charCode < 97 || key.charCode > 122)//letras mayusculas
        && (key.charCode < 65 || key.charCode > 90) //letras minusculas
        && (key.charCode != 45) //retroceso
        && (key.charCode != 241) //ñ
         && (key.charCode != 209) //Ñ
         && (key.charCode != 32) //espacio
         && (key.charCode != 225) //á
         && (key.charCode != 233) //é
         && (key.charCode != 237) //í
         && (key.charCode != 243) //ó
         && (key.charCode != 250) //ú
         && (key.charCode != 193) //Á
         && (key.charCode != 201) //É
         && (key.charCode != 205) //Í
         && (key.charCode != 211) //Ó
         && (key.charCode != 218) //Ú

        )
        return false;
});
$(function () {
$('.CheckBox1').click(function () {
    var thisCheck = $(this);

    if (thischeck.is(':checked')) {
        $('#ImageButton1').attr('disabled', 'disabled');
        $('#ImageButton2').attr('disabled', 'disabled');
    } else {
        $('#ImageButton1').attr('disabled', '');
        $('#ImageButton2').attr('disabled', '');
    }
});
});


