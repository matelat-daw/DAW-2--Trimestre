function format()
{
    let here = document.getElementById("here");
    let frase = document.getElementById("frase").value;
    var cont = 0;
    here.innerHTML = "";

    if (frase == "")
    {
        frase = "No por Mucho Madrugar Amance más Temprano.";
    }
    for (var i = 0; i < frase.length; i++)
    {
        if (frase[i] != " ")
        {
            let border = document.createElement("span");
            border.id = "border";
            border.style.padding = "3px";
            border.innerHTML = frase[i];
            here.appendChild(border);
            cont++;
        }
        else
        {
            if (cont >= 60)
            {
                cont = 0;
                let breakit = document.createElement("br");
                here.appendChild(breakit);
                let breakit2 = document.createElement("br");
                here.appendChild(breakit2);
            }
            else
            {
                let space = document.createElement("span");
                space.style.padding = "7px";
                space.innerHTML = " ";
                here.appendChild(space);
            }
        }
    }
}