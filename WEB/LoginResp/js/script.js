function show(what) // Función que muestra la pantalla de login o la de logon según seleccione el usuario.
{
    switch (what)
    {
        case "logon": // Si llega logon.
            login.style.display = "none"; // Oculta login.
            logon.style.display = "block"; // Muestra logon.
            break;
        case "login":
            logon.style.display = "none"; // Oculta logon.
            login.style.display = "block"; // Muestra login.
            break;
        case "quit":
            modify.style.display = "none"; // Oculta modify.
            quit.style.display = "block"; // Muestra delete.
            break;
        case what.currentTarget.param:
            login.style.display = "none"; // Oculta login.
            logon.style.display = "block"; // Muestra logon.
            break;
        default:
            quit.style.display = "none"; // Oculta delete.
            modify.style.display = "block"; // Muestra modify.
            break;
    }
}

function screen() // Verifica si las vistas existen y llama a la función views para establecer el tamaño.
{
    let viewheight = window.innerHeight; // Obtiene el tamaño vertical de la pantalla.

    if (typeof(view1) != "undefined") // Si el div con ID view existe.
    {
        views(view1, view1.offsetHeight, viewheight); // Llama a la función views y le pasa la vista, el tamaño vertical de la vista y el tamaño vertical de la pantalla.
        if (typeof(view2) != "undefined") // Si existe el div view2
        {
            views(view2, view2.offsetHeight, viewheight);
            if (typeof(view3) != "undefined")
            {
                views(view3, view3.offsetHeight, viewheight);
                if (typeof(view4) != "undefined")
                {
                    views(view4, view4.offsetHeight, viewheight);
                }   
            }
        }
    }
}

function views(view, heights, viewheight) // Establece el tamaño de las vistas en la pantalla.
{
    if (heights < viewheight) // Si la altura vertical de la vista es menor que la altura total de la pantalla.
    {
        view.style.height = viewheight + "px"; // Le da el tamaño de la pantalla.
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

function verify() // Función para validar las contraseñas, también valida el D.N.I o N.I.E.
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
                console.log("Ya que devuelve true quiero saber si entra acá.");
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

function showEye(which) // Función para mostrar el ojo de los input de las contraseñas, recibe el número del elemento que contiene el ojo.
{
    let eye = document.getElementById("togglePassword" + which); // Asigno a eye la id del elemento que contiene el ojo.
    eye.style.visibility = "visible"; // Hago visible el elemento, el ojo.
}

function spy(which) // Función para el ojo de las Contraseñas al hacer click en el ojo, recibe el número de la ID del input de la password.
{
    const togglePassword = document.querySelector('#togglePassword' + which); // Asigno a la constante togglePassword el input con ID togglePassword + which.
    const password = document.querySelector('#pass' + which); // Asigno a password la ID del input con ID pass + which.
    
    const type = password.getAttribute('type') === 'password' ? 'text' : 'password'; // Asigno a type el resultado de un operador ternario, si presiono el ojito y el tipo del input es password
    // lo cambia a text, si es text lo cambia a password.
    password.setAttribute('type', type); // Le asigno el atributo al input password.
    togglePassword.classList.toggle('fa-eye-slash'); // Cambia el aspecto del ojo, al cambiar el input a tipo texto, el ojo aparece con una raya.
}