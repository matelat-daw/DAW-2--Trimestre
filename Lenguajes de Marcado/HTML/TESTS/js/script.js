let already = false;

function change()
{
    if (!already)
    {
        already = true;
        subtitle.innerHTML = "Este es el Subtítulo.";
        btn1.innerHTML = "Press Me Again!";
    }
    else
    {
        already = false;
        subtitle.innerHTML = "Presiona el Botón para Cambiar este Subtítulo.";
        btn1.innerHTML = "Press Me!";
    }
}

function color()
{
    btn1.style.color = "teal";
    btn1.style.backgroundColor = "cyan";
}

function uncolor()
{
    btn1.style.color = "cyan";
    btn1.style.backgroundColor = "teal";
}