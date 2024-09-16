function verify() // Función para validar las contraseñas, también valida el D.N.I o N.I.E.
{
    let dnielement = document.getElementById("dni");
    let dnio = document.getElementById("dnio");
    let dni = dnielement.value;
    let dni_o = dnio.value;
    var dni_client, dni_owner, dni_letra, dni_letra_owner, letras1, letras2;
    var expresion_regular_dni = /^[XYZ]?\d{1,9}[A-Z]$/;
    var pass = document.getElementById("pass1"); // pass es la ID del input pass0.
    var pass2 = document.getElementById("pass2"); // pass2 es la ID del input pass1.
    var pass3 = document.getElementById("pass1o"); // pass es la ID del input pass0.
    var pass4 = document.getElementById("pass2o"); // pass2 es la ID del input pass1.
    let letras = 'TRWAGMYFPDXBNJZSQVHLCKE';

    if(expresion_regular_dni.test(dni) === true)
    {
        dni_client = dni.substr(0, dni.length - 1);
        dni_client = dni_client.replace('X', 0);
        dni_client = dni_client.replace('Y', 1);
        dni_client = dni_client.replace('Z', 2);
        dni_letra_client = dni.substr(dni.length - 1, 1);
        dni_client = dni_client % 23;
        letras = letras.substring(dni_client, dni_client + 1);
        if (letras != dni_letra_client.toUpperCase())
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
        if (expresion_regular_dni.test(dni_o) === true)
        {
            dni_owner = dni_o.substr(0, dni_o.length - 1);
            dni_owner = dni_owner.replace('X', 0);
            dni_owner = dni_owner.replace('Y', 1);
            dni_owner = dni_owner.replace('Z', 2);
            dni_letra_owner = dni_o.substr(dni_o.length - 1, 1);
            dni_owner = dni_owner % 23;
            letras = letras.substring(dni_owner, dni_owner + 1);
            if (letras != dni_letra_owner.toUpperCase())
            {
                toast(2, 'El D.N.I. o N.I.E. es Incorrecto', 'Verifica que los Números y la Letra o Letras Estén Bien.');
                return false;
            }
            else
            {
                if (pass3.value != pass4.value) // Verifico si los valores en los input pass y pass2 no coinciden.
                {
                    toast(1, "Hay un Error", "Las contraseñas no coinciden, has escrito: " + pass3.value + " y " + pass4.value); // Si no coinciden muestro error.
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

function screen() // Establece el tamaño de las vistas en la pantalla.
{
    let view1 = document.getElementById("view1"); // Recoge las ID de todas las vistas.
    let view2 = document.getElementById("view2");
    let view3 = document.getElementById("view3");
    let view4 = document.getElementById("view4");
    let screen = window.innerHeight; // Obtiene el tamaño vertical de la pantalla.
    // var body = document.body, html2 = document.documentElement; // Asigno a la variable body el body y a html2 el contenido.
    // var height = Math.max(body.scrollHeight, body.offsetHeight, html2.clientHeight, html2.scrollHeight, html2.offsetHeight); // Asigno a la variable height el valor máximo de la pantalla con todo el contenido.

    if (view1.offsetHeight < screen) // Si el tamaño vertical de la vista es menor que el tamaño vertical de la pantalla.
    {
        view1.style.height = screen + "px"; // Le asigno el tamaño de la pantalla a la vista 1, si es mayor lo dejo como está.
    }

    if (view2 != null) // Si existe el div view2
    {
        if (view2.offsetHeight < screen) // Si el tamaño vertical de la vista es menor que el tamaño vertical de la pantalla.
        {
            view2.style.height = screen + "px"; // Le asigno el tamaño de la pantalla a la vista 2, si es mayor lo dejo como está.
        }
        if (view3 != null)
        {
            if (view3.offsetHeight < screen)
            {
                view3.style.height = screen + "px";
            }
            if (view4 != null)
            {
                if (view4.offsetHeight < screen)
                {
                    view4.style.height = screen - 200 + "px";
                }
            }
            
        }
    }
    else // Si la vista 2 no existe.
    {
        view1.style.height = height - 80 + "px"; // Le asigno a la vista 1 el tamaño de todo el contenido de la pantalla menos 80 pixels.
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

function capture(number) // Crea una imagen de la factura del cliente, para descargarla y enviarla por E-mail, Whatsapp, etc.
{
    const print = document.getElementById("printable" + number);
    const image = document.getElementById("image" + number); // Div con ID printable0, contiene la factura.

    html2canvas(print).then((canvas) => {
        const base64image = canvas.toDataURL('image/png'); // genera la imagen base64image a partir del contenido de print, el div que contiene la factura.
        image.setAttribute("href", base64image);
        const img = document.createElement("img");
        img.id = "img" + number;
        img.src = base64image;
        img.alt = "Factura: " + number;
        print.remove();
        image.appendChild(img);
    })
}

function printIt(number) // Función que imprime la imagen en panatalla, recibe el numero de factura a imprimir.
{
    if (number != -1) // Si el numero que llega es distinto de -1.
    {
        var img = document.getElementById("img" + number); // Asigno a la variable img la ID del elemento img + numero de factura.
    }
    else // Si llega -1.
    {
        var img = document.getElementById("img0"); // Estoy viedo la última factura, es la imagen 0, Asigno a la variable img la ID del elemento img0.
    }
    const src = img.src; // Asigno a la constante src la imagen.
    const win = window.open(''); // Asigno a la constante win una nueva ventana abierta.
    win.document.write('<img src="' + src + '" onload="window.print(); window.close();">'); // Escribo en la ventana abierta un elemento img con la imagen a imprimir y la envía a la impresora y al terminar cierra la ventana.
}

function pdfDown(number)
{
    const image = document.getElementById("img" + number); // Div con ID printable0, contiene la factura.

    var doc = new jsPDF();
    doc.addImage(image, 'png', 10, 10, 240, 120, '', 'FAST');
    doc.save();
}

function show(what)
{
    let client_in = document.getElementById("client_in");
    let client_on = document.getElementById("client_on");
    let owner_in = document.getElementById("owner_in");
    let owner_on = document.getElementById("owner_on");
    let modify_client = document.getElementById("modify_client");
    let quit_client = document.getElementById("quit_client");
    let modify_owner = document.getElementById("modify_owner");
    let quit_owner = document.getElementById("quit_owner");
    let client = document.getElementById("client");
    let owner = document.getElementById("owner");
    let contact = document.getElementById("contact");

    switch (what)
    {
        case "client_login":
            owner_on.style.display = "none";
            owner_in.style.display = "none";
            client_on.style.display = "none";
            client_in.style.display = "block";
            document.location.hash = "#view2";
            

            break;
        case "client_logon":
            owner_on.style.display = "none";
            owner_in.style.display = "none";
            client_in.style.display = "none";
            client_on.style.display = "block";
            document.location.hash = "#view2";
            break;
        case "owner_login":
            owner_on.style.display = "none";
            client_in.style.display = "none";
            client_on.style.display = "none";
            owner_in.style.display = "block";
            document.location.hash = "#view2";
            break;
        case "owner_logon":
            owner_in.style.display = "none";
            client_in.style.display = "none";
            client_on.style.display = "none";
            owner_on.style.display = "block";
            document.location.hash = "#view2";
            break;
        case "quit_client":
            modify_client.style.display = "none";
            quit_client.style.display = "block";
            break;
        case "modify_client":
            quit_client.style.display = "none";
            modify_client.style.display = "block";
            break;
        case "quit_owner":
            modify_owner.style.display = "none";
            quit_owner.style.display = "block";
            break;
        case "modify_owner":
            quit_owner.style.display = "none";
            modify_owner.style.display = "block";
            break;
        case "email":
            window.location.href = "mailto:matelat@gmail.com";
            break;
        case "whatsapp":
            let num = 664774821;
            var win = window.open('https://wa.me/' + num + '?text=Por Favor contactame por: WhatsApp a este Número, Mi nombre es: ', '_blank');
            break;
    }
    client.selectedIndex = 0;
    owner.selectedIndex = 0;
    contact.selectedIndex = 0;
}

function language(lang)
{
    let language = document.getElementById("language");

    switch (lang)
    {
        case "es":
            language.src = "img/esp.png";
            break;
        case "en":
            language.src = "img/eng.png";
            break;
        case "pt":
            language.src = "img/ptg.png";
            break;
    }
}