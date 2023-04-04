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
    valores = ['TARJETA ACTIVA Y ASIGNADA', 'TARJETA REEMPLAZADA Y ACTIVA', 'TARJETA BLOQUEADA', 'VALIDAR CUENTA', 'DEPURADA TARJETA ENVIADA A CREDENCIALES','Bol. x tarjeta - Otros'];

    return valores[indice];

}

