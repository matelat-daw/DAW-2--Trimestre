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

    if (id == login)
    {
        id.style.display = "none";
        logon.style.display = "block";
    }
    else
    {
        id.style.display = "none";
        login.style.display = "block";
    }
}