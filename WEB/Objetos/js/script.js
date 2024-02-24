function checkPasswords()
{
    var numero, letra, letras;
    var expresion_regular_dni = /^[XYZ]?\d{1,9}[A-Z]$/;
    var dni_n = dni.value;

    if(expresion_regular_dni.test(dni_n) === true)
    {
        numero = dni_n.substr(0, dni_n.length - 1);
        numero = numero.replace('X', 0);
        numero = numero.replace('Y', 1);
        numero = numero.replace('Z', 2);
        letra = dni_n.substr(dni_n.length - 1, 1);
        numero = numero % 23;
        letras = 'TRWAGMYFPDXBNJZSQVHLCKE';
        letras = letras.substring(numero, numero + 1);
        if (letras != letra.toUpperCase())
        {
            toast(2, 'El D.N.I. o N.I.E. es Incorrecto', 'Verifica que los Números y la Letra o Letras Estén Bien.');
            return false;
        }
        else
        {
            if (pass.value != pass2.value) // Verifico si los valores en los input pass y pass2 no coinciden.
            {
                toast(1, "Hay un Error", "Las contraseñas no coinciden, has escrito: " + pass.value + " y " + pass2.value); // Si no coinciden muestro error.
                return false; // devulvo false, el formulario no se envía.
            }
            else // Si son iguales.
            {
                return true; // Devuelvo true, envía el formulario.
            }
        }
    }
    else
    {
        toast(2, 'El D.N.I. o N.I.E. es Incorrecto', 'Verifica que los Números y la Letra o Letras Estén Bien.');
        return false;
    }
}

function toast(warn, ttl, msg) // Función para mostrar el Dialogo con los mensajes de alerta, recibe, Código, Título y Mensaje.
{
    var alerta = document.getElementById("alerta"); // La ID del botón del dialogo.
    var title = document.getElementById("title"); // Asigno a la variable title el h4 con id title.
    var message = document.getElementById("message"); // Asigno a la variable message el h5 con id message;
    if (warn == 1) // Si el código es 1, es una alerta.
    {
        title.style.backgroundColor = "#000000"; // Pongo los atributos, color de fondo negro.
        title.style.color = "yellow"; // Y color del texto amarillo.
    }
    else if (warn == 0) // Si no, si el código es 0 es un mensaje satisfactorio.
    {
        title.style.backgroundColor = "#FFFFFF"; // Pongo los atributos, color de fondo blanco.
        title.style.color = "blue"; // Y el color del texto azul.
    }
    else // Si no, viene un 2, es una alerta de error.
    {
        title.style.backgroundColor = "#000000"; // Pongo los atributos, color de fondo negro.
        title.style.color = "red"; // Y color del texto rojo.
    }
    title.innerHTML = ttl; // Muestro el Título del dialogo.
    message.innerHTML = msg; // Muestro los mensajes en el diálogo.
    alerta.click(); // Lo hago aparecer pulsando el botón con ID alerta.
}