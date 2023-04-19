function SALUDAR() {
    console.log("hola prueba exitosa");
}
function mapeo(data2) {
    console.log(data2.customer_form.customer.customer_accounts[0].account_number);
    console.log(data2);
    document.getElementById('label1').innerHTML = data2.customer_form.customer.customer_name.first_name1;
    document.getElementById('label2').innerHTML = data2.customer_form.customer.customer_name.last_name1;
    document.getElementById('label3').innerHTML = data2.customer_form.customer.customer_accounts[0].account_number;
    document.getElementById('label4').innerHTML = data2.customer_form.customer.customer_accounts[0].card_number;

    document.getElementById('label6').innerHTML = data2.customer_form.customer.customer_accounts[0].product_legend;
}
function reemplazar(account, value) {
    document.getElementById('value').innerHTML = parametros(value);
    document.getElementById('account').innerHTML = account
}
function parametros(indice) {
    valores = ['TARJETA ACTIVA Y ASIGNADA', 'TARJETA REEMPLAZADA Y ACTIVA', 'TARJETA BLOQUEADA', 'VALIDAR CUENTA O ID', 'DEPURADA TARJETA ENVIADA A CREDENCIALES', 'Bol. x tarjeta - Otros', 'Bol. x tarjeta - Extravío', 'INACTIVA O DEPURADA', 'BLOQUEADO', 'Bol. x tarjeta - ROBO','Bol. x tarjeta - Referida'];

    return valores[indice];

}

function cargar_Agencias() {
    var array = ["Airpak Nicaragua S.A", "Airpak Tipitapa", "Airpak Metrocentro", "Airpak La Colonia C. Jardin", "Airpak Pali Zumen", "Airpak Pali Linda Vista", "Airpak Pali C. Sandino"];
    var arra = ["1", "2", "31", "4", "5", "6", "7"];

    for (var i in array, arra) {
        document.getElementById("Agencia").innerHTML += "<option value='" + arra[i] + "'>" + array[i] + "</option>";
    }
}
cargar_Agencias();

function loginvalidation(url) {
    let encriptado = document.getElementById("Agencia").value;
    let usuario = document.getElementById("Usuario").value;
    let contrasena = document.getElementById("Contraseña").value;
   
    if ((encriptado == "") || (usuario == "") || (contrasena == "")) {
        Swal.fire(
            'Inicio De Sesion Incorrecto',
            'Ingrese sus credenciales',
            'question'
        )

    } else {


        var data = { header: encriptado, user: usuario, pwd: contrasena };
        console.log(url);

        $.post(url, data).done(function (data) {
            console.log(data);
            if (data == "True") {
                 return true;
            } else {
                Swal.fire(
                    'Inicio De Sesion Incorrecto',
                    'Valide Sus Credenciales',
                    'warning'
                )

            }

        });
    }
}

