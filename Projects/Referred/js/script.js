function screen() // Establece el tamaño de las vistas en la pantalla.
{
    let view1 = document.getElementById("view1"); // Recoge las ID de todas las vistas.
    let view2 = document.getElementById("view2");
    let view3 = document.getElementById("view3");
    let view4 = document.getElementById("view4");
    let view5 = document.getElementById("view5");
    let viewheight = window.innerHeight; // Obtiene el tamaño vertical de la pantalla.

    views(view1, viewheight);

    if (view2 != null) // Si existe el div view2
    {
        views(view2, viewheight);
        if (view3 != null)
        {
            views(view3, viewheight);
            if (view4 != null)
            {
                views(view4, viewheight);
                if (view5 != null)
                {
                    views(view5, viewheight);
                }
            }   
        }
    }
}

function views(view, viewheight)
{
    height = view.offsetHeight
    if (height < viewheight)
    {
        view.style.height = viewheight + "px";
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

function show(id)
{
    let login = document.getElementById("login");
    let logon = document.getElementById("logon");
    let modify = document.getElementById("modify");
    let quit = document.getElementById("delete");

    switch (id)
    {
        case login:
            id.style.display = "none";
            logon.style.display = "block";
            break;
        case logon:
            id.style.display = "none";
            login.style.display = "block";
            break;
        case modify:
            id.style.display = "block";
            quit.style.display = "none";
            break;
        default:
            id.style.display = "block";
            modify.style.display = "none";
    }
    // if (id == login)
    // {
    //     id.style.display = "none";
    //     logon.style.display = "block";
    // }
    // else
    // {
    //     id.style.display = "none";
    //     login.style.display = "block";
    // }
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
    var pass1 = document.getElementById("pass1").value; // pass es la ID del input pass0.
    var pass2 = document.getElementById("pass2").value; // pass2 es la ID del input pass1.

    if (pass1 != pass2) // Verifico si los valores en los input pass y pass2 no coinciden.
    {
        toast(1, "Hay un Error", "Las contraseñas no coinciden, has Escrito: " + pass1 + " y " + pass2); // Si no coinciden muestro error.
        return false; // devulvo false, el formulario no se envía.
    }
    else // Si son iguales.
    {
        return true; // Devuelvo true, envía el formulario.
    }
}

function QRGen() // Función para generar el código QR, directamente desde una API de google, (seguramente durará muy poco), recibe el numero de entradas compradas, del script checkout.php.
{
    let code = document.getElementById("code"); // Obtengo la ID del <input> oculto que contiene la url con los datos de las entradas compradas, lo asigno al array code[i].
    let qr = document.getElementById("here"); // Obtengo las ID de los input que contendrán la URL completa del código QR.
    let btn = document.getElementById("btn"); // ID del input type submit para enviar los datos, está oculto (hidden)
    
    finalURL ='https://chart.googleapis.com/chart?cht=qr&chl=' + code.value + '&chs=160x160&chld=L|0'; // Se lo paso a Google y asigno el resultado a la variable finalURL.
    qr.value = finalURL; // Lo pongo en el input con ID qr[i].

    setTimeout(function() // La función para esperar 2 segundos.
    {
        btn.style.visibility = "visible"; // Después de 2 segundos se hace visible el botón. Espero 2 segundos para dar tiempo a Google a Crear el QR.
    }, 2000);
}

function closeSession()
{
    window.open("logout.php", "_self");
}