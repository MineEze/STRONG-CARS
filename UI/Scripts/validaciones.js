function validateEmail(controlId) {
    var elem = document.getElementById(controlId);
    const regularExpression = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    var isValid = regularExpression.test(elem.value);
    return isValid;
}

function validarFormRegistrarUsuario() {
    var validacionCorrecta = true;

    var nombre = document.getElementById("MainContent_TextBoxNombre").value;

    if (nombre.length < 2 || nombre.length > 100) {
        document.getElementById("MainContent_LabelValidacionNombre").style.display = "inline-block";
        validacionCorrecta = false;
    } else {
        document.getElementById("MainContent_LabelValidacionNombre").style.display = "none";
    }

    var apellido = document.getElementById("MainContent_TextBoxApellido").value;

    if (apellido.length < 2 || apellido.length > 100) {
        document.getElementById("MainContent_LabelValidacionApellido").style.display = "inline-block";
        validacionCorrecta = false;
    } else {
        document.getElementById("MainContent_LabelValidacionApellido").style.display = "none";
    }

    var dni = document.getElementById("MainContent_TextBoxDNI").value;

    if (dni.length < 2 || dni.length > 15) {
        document.getElementById("MainContent_LabelValidacionDNI").style.display = "inline-block";
        validacionCorrecta = false;
    } else {
        document.getElementById("MainContent_LabelValidacionDNI").style.display = "none";
    }

    if (!validateEmail("MainContent_TextBoxEmail")) {
        document.getElementById("MainContent_LabelValidacionEmail").style.display = "inline-block";
        validacionCorrecta = false;
    } else {
        document.getElementById("MainContent_LabelValidacionEmail").style.display = "none";
    }

    var calle = document.getElementById("MainContent_TextBoxCalle").value;

    if (calle.length < 2 || calle.length > 100) {
        document.getElementById("MainContent_LabelValidacionCalle").style.display = "inline-block";
        validacionCorrecta = false;
    } else {
        document.getElementById("MainContent_LabelValidacionCalle").style.display = "none";
    }

    var altura = document.getElementById("MainContent_TextBoxAltura").value;

    if (altura.length < 1 || altura.length > 6) {
        document.getElementById("MainContent_LabelValidacionAltura").style.display = "inline-block";
        validacionCorrecta = false;
    } else {
        document.getElementById("MainContent_LabelValidacionAltura").style.display = "none";
    }

    if (isNaN(altura)) {
        document.getElementById("MainContent_LabelValidacionAlturaNumerica").style.display = "inline-block";
        validacionCorrecta = false;
    } else {
        document.getElementById("MainContent_LabelValidacionAlturaNumerica").style.display = "none";
    }

    var codigoPostal = document.getElementById("MainContent_TextBoxCodigoPostal").value;

    if (codigoPostal.length < 2 || codigoPostal.length > 15) {
        document.getElementById("MainContent_LabelValidacionCodigoPostal").style.display = "inline-block";
        validacionCorrecta = false;
    } else {
        document.getElementById("MainContent_LabelValidacionCodigoPostal").style.display = "none";
    }

    var usuario = document.getElementById("MainContent_TextBoxUsuario").value;

    if (usuario.length < 4 || usuario.length > 30) {
        document.getElementById("MainContent_LabelValidacionUsuario").style.display = "inline-block";
        validacionCorrecta = false;
    } else {
        document.getElementById("MainContent_LabelValidacionUsuario").style.display = "none";
    }

    var password = document.getElementById("MainContent_TextBoxPassword").value;

    if (password.length < 8 || password.length > 30) {
        document.getElementById("MainContent_LabelValidacionPassword").style.display = "inline-block";
        validacionCorrecta = false;
    } else {
        document.getElementById("MainContent_LabelValidacionPassword").style.display = "none";
    }

    var passwordRepetido = document.getElementById("MainContent_TextBoxPasswordRepetido").value;

    if (password != passwordRepetido) {
        document.getElementById("MainContent_LabelValidacionPasswordRepetido").style.display = "inline-block";
        validacionCorrecta = false;
    } else {
        document.getElementById("MainContent_LabelValidacionPasswordRepetido").style.display = "none";
    }

    var checkboxesPermisos = $("input[type='checkbox']");

    if (!checkboxesPermisos.is(":checked")) {
        document.getElementById("MainContent_LabelValidacionPermisos").style.display = "inline-block";
        validacionCorrecta = false;
    } else {
        document.getElementById("MainContent_LabelValidacionPermisos").style.display = "none";
    }

    return validacionCorrecta;
}

function validarFormEditarUsuario() {
    var validacionCorrecta = true;

    var nombre = document.getElementById("MainContent_TextBoxNombre").value;

    if (nombre.length < 2 || nombre.length > 100) {
        document.getElementById("MainContent_LabelValidacionNombre").style.display = "inline-block";
        validacionCorrecta = false;
    } else {
        document.getElementById("MainContent_LabelValidacionNombre").style.display = "none";
    }

    var apellido = document.getElementById("MainContent_TextBoxApellido").value;

    if (apellido.length < 2 || apellido.length > 100) {
        document.getElementById("MainContent_LabelValidacionApellido").style.display = "inline-block";
        validacionCorrecta = false;
    } else {
        document.getElementById("MainContent_LabelValidacionApellido").style.display = "none";
    }

    var dni = document.getElementById("MainContent_TextBoxDNI").value;

    if (dni.length < 2 || dni.length > 15) {
        document.getElementById("MainContent_LabelValidacionDNI").style.display = "inline-block";
        validacionCorrecta = false;
    } else {
        document.getElementById("MainContent_LabelValidacionDNI").style.display = "none";
    }

    if (!validateEmail("MainContent_TextBoxEmail")) {
        document.getElementById("MainContent_LabelValidacionEmail").style.display = "inline-block";
        validacionCorrecta = false;
    } else {
        document.getElementById("MainContent_LabelValidacionEmail").style.display = "none";
    }

    var calle = document.getElementById("MainContent_TextBoxCalle").value;

    if (calle.length < 2 || calle.length > 100) {
        document.getElementById("MainContent_LabelValidacionCalle").style.display = "inline-block";
        validacionCorrecta = false;
    } else {
        document.getElementById("MainContent_LabelValidacionCalle").style.display = "none";
    }

    var altura = document.getElementById("MainContent_TextBoxAltura").value;

    if (altura.length < 1 || altura.length > 6) {
        document.getElementById("MainContent_LabelValidacionAltura").style.display = "inline-block";
        validacionCorrecta = false;
    } else {
        document.getElementById("MainContent_LabelValidacionAltura").style.display = "none";
    }

    if (isNaN(altura)) {
        document.getElementById("MainContent_LabelValidacionAlturaNumerica").style.display = "inline-block";
        validacionCorrecta = false;
    } else {
        document.getElementById("MainContent_LabelValidacionAlturaNumerica").style.display = "none";
    }

    var codigoPostal = document.getElementById("MainContent_TextBoxCodigoPostal").value;

    if (codigoPostal.length < 2 || codigoPostal.length > 15) {
        document.getElementById("MainContent_LabelValidacionCodigoPostal").style.display = "inline-block";
        validacionCorrecta = false;
    } else {
        document.getElementById("MainContent_LabelValidacionCodigoPostal").style.display = "none";
    }

    var usuario = document.getElementById("MainContent_TextBoxUsuario").value;

    if (usuario.length < 4 || usuario.length > 30) {
        document.getElementById("MainContent_LabelValidacionUsuario").style.display = "inline-block";
        validacionCorrecta = false;
    } else {
        document.getElementById("MainContent_LabelValidacionUsuario").style.display = "none";
    }

    var checkboxesPermisos = $("input[type='checkbox']");

    if (!checkboxesPermisos.is(":checked")) {
        document.getElementById("MainContent_LabelValidacionPermisos").style.display = "inline-block";
        validacionCorrecta = false;
    } else {
        document.getElementById("MainContent_LabelValidacionPermisos").style.display = "none";
    }

    return validacionCorrecta;
}

function validarFormRegistrarse() {
    var validacionCorrecta = true;

    var nombre = document.getElementById("MainContent_TextBoxNombre").value;

    if (nombre.length < 2) {
        document.getElementById("MainContent_LabelValidacionNombre").style.display = "inline-block";
        validacionCorrecta = false;
    } else {
        document.getElementById("MainContent_LabelValidacionNombre").style.display = "none";
    }

    var apellido = document.getElementById("MainContent_TextBoxApellido").value;

    if (apellido.length < 2) {
        document.getElementById("MainContent_LabelValidacionApellido").style.display = "inline-block";
        validacionCorrecta = false;
    } else {
        document.getElementById("MainContent_LabelValidacionApellido").style.display = "none";
    }

    var dni = document.getElementById("MainContent_TextBoxDNI").value;

    if (dni.length < 2) {
        document.getElementById("MainContent_LabelValidacionDNI").style.display = "inline-block";
        validacionCorrecta = false;
    } else {
        document.getElementById("MainContent_LabelValidacionDNI").style.display = "none";
    }

    if (!validateEmail("MainContent_TextBoxEmail")) {
        document.getElementById("MainContent_LabelValidacionEmail").style.display = "inline-block";
        validacionCorrecta = false;
    } else {
        document.getElementById("MainContent_LabelValidacionEmail").style.display = "none";
    }

    var calle = document.getElementById("MainContent_TextBoxCalle").value;

    if (calle.length < 2) {
        document.getElementById("MainContent_LabelValidacionCalle").style.display = "inline-block";
        validacionCorrecta = false;
    } else {
        document.getElementById("MainContent_LabelValidacionCalle").style.display = "none";
    }

    var altura = document.getElementById("MainContent_TextBoxAltura").value;

    if (altura.length < 1) {
        document.getElementById("MainContent_LabelValidacionAltura").style.display = "inline-block";
        validacionCorrecta = false;
    } else {
        document.getElementById("MainContent_LabelValidacionAltura").style.display = "none";
    }

    if (isNaN(altura)) {
        document.getElementById("MainContent_LabelValidacionAlturaNumerica").style.display = "inline-block";
        validacionCorrecta = false;
    } else {
        document.getElementById("MainContent_LabelValidacionAlturaNumerica").style.display = "none";
    }

    var codigoPostal = document.getElementById("MainContent_TextBoxCodigoPostal").value;

    if (codigoPostal.length < 2) {
        document.getElementById("MainContent_LabelValidacionCodigoPostal").style.display = "inline-block";
        validacionCorrecta = false;
    } else {
        document.getElementById("MainContent_LabelValidacionCodigoPostal").style.display = "none";
    }

    var usuario = document.getElementById("MainContent_TextBoxUsuario").value;

    if (usuario.length < 4) {
        document.getElementById("MainContent_LabelValidacionUsuario").style.display = "inline-block";
        validacionCorrecta = false;
    } else {
        document.getElementById("MainContent_LabelValidacionUsuario").style.display = "none";
    }

    var password = document.getElementById("MainContent_TextBoxPassword").value;

    if (password.length < 8) {
        document.getElementById("MainContent_LabelValidacionPassword").style.display = "inline-block";
        validacionCorrecta = false;
    } else {
        document.getElementById("MainContent_LabelValidacionPassword").style.display = "none";
    }

    var passwordRepetido = document.getElementById("MainContent_TextBoxPasswordRepetido").value;

    if (password != passwordRepetido) {
        document.getElementById("MainContent_LabelValidacionPasswordRepetido").style.display = "inline-block";
        validacionCorrecta = false;
    } else {
        document.getElementById("MainContent_LabelValidacionPasswordRepetido").style.display = "none";
    }

    return validacionCorrecta;
}

function validarFormAgregarIdioma() {
    validacionCorrecta = true;

    var nombreIdioma = document.getElementById("MainContent_TextBoxNombreNuevoIdioma").value;

    if (nombreIdioma.length < 1) {
        document.getElementById("MainContent_LabelValidacionNombreIdioma").style.display = "inline-block";
        validacionCorrecta = false;
    } else {
        document.getElementById("MainContent_LabelValidacionNombreIdioma").style.display = "none";
    }

    var oInputs = new Array();
    oInputs = document.getElementsByTagName('input')

    var idiomaIncompleto = false;

    for (i = 0; i < oInputs.length; i++) {
        if (oInputs[i].type == 'text') {
            if (oInputs[i].value.length < 1 && oInputs[i].id != 'MainContent_TextBoxNombreNuevoIdioma') {
                idiomaIncompleto = true;
                break;
            }
        }
    }

    if (idiomaIncompleto) {
        document.getElementById("MainContent_LabelValidacionIdiomaIncompleto").style.display = "inline-block";
        validacionCorrecta = false;
    } else {
        document.getElementById("MainContent_LabelValidacionIdiomaIncompleto").style.display = "none";
    }

    return validacionCorrecta;
}

function validarFormSucursal() {
    var validacionCorrecta = true;

    var calle = document.getElementById("MainContent_TextBoxCalle").value;

    if (calle.length < 2) {
        document.getElementById("MainContent_LabelValidacionCalle").style.display = "inline-block";
        validacionCorrecta = false;
    } else {
        document.getElementById("MainContent_LabelValidacionCalle").style.display = "none";
    }

    var altura = document.getElementById("MainContent_TextBoxAltura").value;

    if (altura.length < 1) {
        document.getElementById("MainContent_LabelValidacionAltura").style.display = "inline-block";
        validacionCorrecta = false;
    } else {
        document.getElementById("MainContent_LabelValidacionAltura").style.display = "none";
    }

    if (isNaN(altura)) {
        document.getElementById("MainContent_LabelValidacionAlturaNumerica").style.display = "inline-block";
        validacionCorrecta = false;
    } else {
        document.getElementById("MainContent_LabelValidacionAlturaNumerica").style.display = "none";
    }

    var codigoPostal = document.getElementById("MainContent_TextBoxCodigoPostal").value;

    if (codigoPostal.length < 2) {
        document.getElementById("MainContent_LabelValidacionCodigoPostal").style.display = "inline-block";
        validacionCorrecta = false;
    } else {
        document.getElementById("MainContent_LabelValidacionCodigoPostal").style.display = "none";
    }

    var telefonos = document.getElementById("MainContent_GridViewTelefonos");

    if (telefonos == null || telefonos.rows.length < 2) {
        document.getElementById("MainContent_LabelValidacionCantidadTelefonos").style.display = "inline-block";
        validacionCorrecta = false;
    } else {
        document.getElementById("MainContent_LabelValidacionCantidadTelefonos").style.display = "none";
    }


    var recargos = document.querySelectorAll('[id^="MainContent_GridViewSucursalesRecargos_TextBoxRecargo"]');

    var recargosInvalidos = false;

    for (i = 0; i < recargos.length; i++) {
        if (isNaN(recargos[i].value)) {
            recargosInvalidos = true;
            break;
        }
    }

    if (recargosInvalidos) {
        document.getElementById("MainContent_LabelValidacionRecargosNumericos").style.display = "inline-block";
        validacionCorrecta = false;
    }
    else {
        document.getElementById("MainContent_LabelValidacionRecargosNumericos").style.display = "none";

    }

    return validacionCorrecta;
}

function validarAgregarTelefono() {
    var validacionCorrecta = true;

    var caracteristica = document.getElementById("MainContent_TextBoxTelefonoCaracteristica").value;

    if (caracteristica.length < 2) {
        document.getElementById("MainContent_LabelValidacionTelefonoCaracteristica").style.display = "inline-block";
        validacionCorrecta = false;
    } else {
        document.getElementById("MainContent_LabelValidacionTelefonoCaracteristica").style.display = "none";
    }

    if (isNaN(caracteristica)) {
        document.getElementById("MainContent_LabelValidacionTelefonoCaracteristicaNumerica").style.display = "inline-block";
        validacionCorrecta = false;
    } else {
        document.getElementById("MainContent_LabelValidacionTelefonoCaracteristicaNumerica").style.display = "none";
    }

    var numero = document.getElementById("MainContent_TextBoxTelefonoNumero").value;

    if (numero.length < 7) {
        document.getElementById("MainContent_LabelValidacionTelefonoNumero").style.display = "inline-block";
        validacionCorrecta = false;
    } else {
        document.getElementById("MainContent_LabelValidacionTelefonoNumero").style.display = "none";
    }

    if (isNaN(numero)) {
        document.getElementById("MainContent_LabelValidacionTelefonoNumeroNumerico").style.display = "inline-block";
        validacionCorrecta = false;
    } else {
        document.getElementById("MainContent_LabelValidacionTelefonoNumeroNumerico").style.display = "none";
    }

    return validacionCorrecta;
}s

function validarFormRegistrarChofer() {
    var validacionCorrecta = true;

    var nombre = document.getElementById("MainContent_TextBoxNombre").value;

    if (nombre.length < 2) {
        document.getElementById("MainContent_LabelValidacionNombre").style.display = "inline-block";
        validacionCorrecta = false;
    } else {
        document.getElementById("MainContent_LabelValidacionNombre").style.display = "none";
    }

    var apellido = document.getElementById("MainContent_TextBoxApellido").value;

    if (apellido.length < 2) {
        document.getElementById("MainContent_LabelValidacionApellido").style.display = "inline-block";
        validacionCorrecta = false;
    } else {
        document.getElementById("MainContent_LabelValidacionApellido").style.display = "none";
    }

    var dni = document.getElementById("MainContent_TextBoxDNI").value;

    if (dni.length < 2) {
        document.getElementById("MainContent_LabelValidacionDNI").style.display = "inline-block";
        validacionCorrecta = false;
    } else {
        document.getElementById("MainContent_LabelValidacionDNI").style.display = "none";
    }

    if (!validateEmail("MainContent_TextBoxEmail")) {
        document.getElementById("MainContent_LabelValidacionEmail").style.display = "inline-block";
        validacionCorrecta = false;
    } else {
        document.getElementById("MainContent_LabelValidacionEmail").style.display = "none";
    }

    var calle = document.getElementById("MainContent_TextBoxCalle").value;

    if (calle.length < 2) {
        document.getElementById("MainContent_LabelValidacionCalle").style.display = "inline-block";
        validacionCorrecta = false;
    } else {
        document.getElementById("MainContent_LabelValidacionCalle").style.display = "none";
    }

    var altura = document.getElementById("MainContent_TextBoxAltura").value;

    if (altura.length < 1) {
        document.getElementById("MainContent_LabelValidacionAltura").style.display = "inline-block";
        validacionCorrecta = false;
    } else {
        document.getElementById("MainContent_LabelValidacionAltura").style.display = "none";
    }

    if (isNaN(altura)) {
        document.getElementById("MainContent_LabelValidacionAlturaNumerica").style.display = "inline-block";
        validacionCorrecta = false;
    } else {
        document.getElementById("MainContent_LabelValidacionAlturaNumerica").style.display = "none";
    }

    var codigoPostal = document.getElementById("MainContent_TextBoxCodigoPostal").value;

    if (codigoPostal.length < 2) {
        document.getElementById("MainContent_LabelValidacionCodigoPostal").style.display = "inline-block";
        validacionCorrecta = false;
    } else {
        document.getElementById("MainContent_LabelValidacionCodigoPostal").style.display = "none";
    }

    var caracteristica = document.getElementById("MainContent_TextBoxTelefonoCaracteristica").value;

    if (caracteristica.length < 2) {
        document.getElementById("MainContent_LabelValidacionTelefonoCaracteristica").style.display = "inline-block";
        validacionCorrecta = false;
    } else {
        document.getElementById("MainContent_LabelValidacionTelefonoCaracteristica").style.display = "none";
    }

    if (isNaN(caracteristica)) {
        document.getElementById("MainContent_LabelValidacionTelefonoCaracteristicaNumerica").style.display = "inline-block";
        validacionCorrecta = false;
    } else {
        document.getElementById("MainContent_LabelValidacionTelefonoCaracteristicaNumerica").style.display = "none";
    }

    var numero = document.getElementById("MainContent_TextBoxTelefonoNumero").value;

    if (numero.length < 7) {
        document.getElementById("MainContent_LabelValidacionTelefonoNumero").style.display = "inline-block";
        validacionCorrecta = false;
    } else {
        document.getElementById("MainContent_LabelValidacionTelefonoNumero").style.display = "none";
    }

    if (isNaN(numero)) {
        document.getElementById("MainContent_LabelValidacionTelefonoNumeroNumerico").style.display = "inline-block";
        validacionCorrecta = false;
    } else {
        document.getElementById("MainContent_LabelValidacionTelefonoNumeroNumerico").style.display = "none";
    }

    return validacionCorrecta;
}

function validarFormRegistrarCliente() {
    var validacionCorrecta = validarFormRegistrarChofer();

    var licencia = document.getElementById("MainContent_TextBoxLicencia").value;

    if (licencia.length > 0 && licencia.length < 6) {
        document.getElementById("MainContent_LabelValidacionLicencia").style.display = "inline-block";
        validacionCorrecta = false;
    } else {
        document.getElementById("MainContent_LabelValidacionLicencia").style.display = "none";
    }

    return validacionCorrecta;
}

function validarFormRegistrarVehiculo() {
    var validacionCorrecta = true;

    var patente = document.getElementById("MainContent_TextBoxPatente").value;

    if (patente.length < 6) {
        document.getElementById("MainContent_LabelValidacionPatente").style.display = "inline-block";
        validacionCorrecta = false;
    } else {
        document.getElementById("MainContent_LabelValidacionPatente").style.display = "none";
    }

    var kilometraje = document.getElementById("MainContent_TextBoxKilometraje").value;

    if (kilometraje.length < 1) {
        document.getElementById("MainContent_LabelValidacionKilometraje").style.display = "inline-block";
        validacionCorrecta = false;
    } else {
        document.getElementById("MainContent_LabelValidacionKilometraje").style.display = "none";
    }

    if (isNaN(kilometraje)) {
        document.getElementById("MainContent_LabelValidacionKilometrajeNumerico").style.display = "inline-block";
        validacionCorrecta = false;
    } else {
        document.getElementById("MainContent_LabelValidacionKilometrajeNumerico").style.display = "none";
    }

    var precioDiarioBase = document.getElementById("MainContent_TextBoxPrecioDiarioBase").value;

    if (precioDiarioBase.length < 1) {
        document.getElementById("MainContent_LabelValidacionPrecioDiarioBase").style.display = "inline-block";
        validacionCorrecta = false;
    } else {
        document.getElementById("MainContent_LabelValidacionPrecioDiarioBase").style.display = "none";
    }

    if (isNaN(precioDiarioBase)) {
        document.getElementById("MainContent_LabelValidacionPrecioDiarioBaseNumerico").style.display = "inline-block";
        validacionCorrecta = false;
    } else {
        document.getElementById("MainContent_LabelValidacionPrecioDiarioBaseNumerico").style.display = "none";
    }

    var precioPorKm = document.getElementById("MainContent_TextBoxPrecioPorKm").value;

    if (precioPorKm.length < 1) {
        document.getElementById("MainContent_LabelValidacionPrecioPorKm").style.display = "inline-block";
        validacionCorrecta = false;
    } else {
        document.getElementById("MainContent_LabelValidacionPrecioPorKm").style.display = "none";
    }

    if (isNaN(precioPorKm)) {
        document.getElementById("MainContent_LabelValidacionPrecioPorKmNumerico").style.display = "inline-block";
        validacionCorrecta = false;
    } else {
        document.getElementById("MainContent_LabelValidacionPrecioPorKmNumerico").style.display = "none";
    }

    return validacionCorrecta;
}