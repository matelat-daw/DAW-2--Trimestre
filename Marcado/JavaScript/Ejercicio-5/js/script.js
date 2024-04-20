function add_end()
{
    view();
    var p = document.createElement("p");
    p.innerHTML = tarea.value;
    tareas.append(p);
}

function add_start()
{
    view();
    var p = document.createElement("p");
    p.innerHTML = tarea.value;
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

function getQtty()
{
    let qtty = tareas.getElementsByTagName("p").length;
    if (qtty == 0)
    {
        hide();
    }
    else
    {
        return qtty;
    }
}