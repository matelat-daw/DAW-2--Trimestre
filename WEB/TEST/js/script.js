function change(data)
{
    h3.innerHTML = data;
    // btn.addEventListener("click", help);
}

let changer = true;
function help()
{
    if (changer)
    {
        change("ADIO");
        changer = false;
    }
    else
    {
        change("HOLA");
        changer = true;
    }
    btn.removeEventListener("click", help);
}