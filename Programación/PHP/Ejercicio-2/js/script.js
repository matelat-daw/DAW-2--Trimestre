function screen()
{
    let height = window.innerHeight;
    let date = document.getElementById("date");
    date.innerHTML += new Date(Date.now()).toLocaleString() + " -";
}

function show(id)
{
    let which = document.getElementsByClassName("goContainer");
    let qtty = document.getElementsByClassName("goContainer").length;
    let login = document.getElementById("login");
    if (login != null)
    {
        login.style.display = "none";
    }

    for (var i = 0; i < qtty; i++)
    {
        if (which[i].style.display != "none")
        {
            which[i].style.display = "none";
        }
    }
    id.style.display = "block";
}

function register()
{
    
}

function ej1Opera()
{
    let num1 = document.getElementById("num1").value;
    let num2 = document.getElementById("num2").value;
    let result = document.getElementById("result");

    result.innerHTML = "Suma:             <br>" + "<span class='margin'>" + num1 + " + " + num2 + " = " + (parseInt(num1) + parseInt(num2)) + "</span><br><br>" +
    "Resta:            <br>" + "<span class='margin'>" + num1 + " - " + num2 + " = " + (num1 - num2) + "<br><br>" +
    "Multiplicación:   <br>" + "<span class='margin'>" + num1 + " * " + num2 + " = " + num1 * num2 + "<br><br>" +
    "División:         <br>" + "<span class='margin'>" + num1 + " / " + num2 + " = " + num1 / num2;
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

function showEye(which) // Función para mostrar el ojo de los input de las contraseñas, recibe el número del elemento que contiene el ojo.
{
    let eye = document.getElementById("togglePassword" + which); // Asigno a eye la id del elemento que contiene el ojo.
    eye.style.visibility = "visible"; // Hago visible el elemento, el ojo.
}

function spy(which) // Función para el ojito de las Contraseñas al hacer click en el ojito, recibe el número de la ID del input de la password.
{
    const togglePassword = document.querySelector('#togglePassword' + which); // Asigno a la constante togglePassword el input con ID togglePassword + which.
    const password = document.querySelector('#pass' + which); // Asigno a password la ID del input con ID pass + which.
    
    const type = password.getAttribute('type') === 'password' ? 'text' : 'password'; // Asigno a type el resultado de un operador ternario, si presiono el ojito y el tipo del input es password
    // lo cambia a text, si es text lo cambia a password.
    password.setAttribute('type', type); // Le asigno el atributo al input password.
    togglePassword.classList.toggle('fa-eye-slash'); // Cambia el aspecto del ojito, al cambiar el input a tipo texto, el ojo aparece con una raya.
}

function verify() // Función para validar las contraseñas de registro de alumnos y las de modificación, también valida el D.N.I.
{
    let dnielement = document.getElementById("dni");
    let dni = dnielement.value;
    var numero, letra, letras;
    var expresion_regular_dni = /^[XYZ]?\d{1,9}[A-Z]$/;
    var pass = document.getElementById("pass1"); // pass es la ID del input pass0.
    var pass2 = document.getElementById("pass2"); // pass2 es la ID del input pass1.

    if(expresion_regular_dni.test(dni) === true)
    {
        numero = dni.substr(0, dni.length - 1);
        numero = numero.replace('X', 0);
        numero = numero.replace('Y', 1);
        numero = numero.replace('Z', 2);
        letra = dni.substr(dni.length - 1, 1);
        numero = numero % 23;
        // letras = 'TRWAGMYFPDXBNJZSQVHLCKET';
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

function closeSession()
{
    window.open("logout.php", "_self");
}