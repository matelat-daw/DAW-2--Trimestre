var index = 0;

function add_end()
{
    view();
    var p = document.createElement("p");
    p.innerHTML = tarea.value;
    p.id = "p" + index;
    p.setAttribute("onclick","deleteIt(this.id)");
    index++;
    tareas.append(p);
}

function add_start()
{
    view();
    var p = document.createElement("p");
    p.innerHTML = tarea.value;
    p.id = "p" + index;
    p.setAttribute("onclick","deleteIt(this.id)");
    index++;
    tareas.prepend(p);
}

function delete_start()
{
    if (getQtty() > 0)
    {
        tareas.removeChild(tareas.firstChild);
        getQtty();
    }
}

function delete_end()
{
    if (getQtty() > 0)
    {
        tareas.removeChild(tareas.lastChild);
        getQtty();
    }
}

function delete_all()
{
    let qtty = getQtty();

    for (i = 0; i < qtty; i++)
    {
        tareas.removeChild(tareas.firstChild);
    }
    getQtty();
}

function view()
{
    let title = document.getElementsByClassName("hidden");
    title[0].style.visibility = "visible";
}

function hide()
{
    let title = document.getElementsByClassName("hidden");
    title[0].style.visibility = "hidden";
}

function deleteIt(id) // Detecta el doble click en el Elemento.
{
    var element = document.getElementById(id);
    element.onclick = event => {
        if (event.detail === 2) // Si se Hace Doble CLick.
        {
            tareas.removeChild(element); // Remueve el Elemento.
            getQtty(); // Comprueba si quedan Elementos.
        }
    };
}

function getQtty()
{
    let qtty = tareas.getElementsByTagName("p").length;
    if (qtty == 0) // Si no hay más Elementos.
    {
        hide(); // Esconde el H3 LISTA.
    }
    else
    {
        return qtty;
    }
}