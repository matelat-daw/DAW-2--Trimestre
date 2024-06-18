let string = "Añadir al ejercicio 10 la posibilidad de solucionar el panel, escribiendo la frase en una caja de texto. Y comprobando que se ha acertado.";

function show()
{
    let keyboard = document.getElementById("keyboard");
    let container = document.getElementById("container");
    var cont = 0;

    for (var i = 65; i < 91; i++)
    {
        let button = document.createElement("button"); // Creo un Elemento Botón.
        button.id = "button" + (i - 65);
        button.innerHTML = String.fromCharCode(i);
        button.className = "button";
        // button.style.border = "1px solid black"; // Se Pueden Dar los Estilos Así, pero OJO, los Nombres Cambian Ligeramente.
        // button.style.padding = "10px";
        // button.style.margin = "5px";
        // button.style.borderRadius = "50%";
        button.setAttribute("style", "border: 1px solid black; border-radius: 50%; padding: 10px; margin: 5px;"); // Pero es Mejor Así, con los Nombres Originales.
        button.onclick = function(){disable(this.id);}; // Llama a la Fución disable y le pasa la ID del Botón Pulsado.
        keyboard.appendChild(button);
    }

    for (var i = 0; i < string.length; i++)
    {
        if (cont > 60)
        {
            breakit();
            cont = 0;
        }

        if (string[i] == "," || string[i] == ".")
        {
            let span1 = document.createElement("span");
            span1.innerHTML = string[i];
            span1.setAttribute("style", "font-size: 22px; vertical-align: bottom;");
            container.appendChild(span1);
        }
        else
        {
            if (string[i] == " ")
            {
                let span2 = document.createElement("span");
                span2.innerHTML = " ";
                span2.setAttribute("style", "padding: 5px; margin: 5px;");
                container.appendChild(span2);
            }
            else
            {
                let button = document.createElement("button");
                button.id = "button-2" + i;
                button.innerHTML = " ";
                button.setAttribute("style", "border: 1px solid black; width: 24px; height: 24px; margin-right: 5px;");
                container.appendChild(button);
            }
        }
        cont++;
    }
}

function disable(id)
{
    let element = document.getElementById(id);

    console.log("La Letra Seleccionada es: " + element.innerHTML);
    for (var i = 0; i < string.length; i++)
    {
        if (string[i] == element.innerHTML || string[i] == element.innerHTML.toLowerCase())
        {
            console.log("La Letra Seleccionada de la String es: " + string[i]);
            console.log("El valor de i es: " + i + " Tengo: button2" + i);
            document.getElementById("button-2" + i).textContent = string[i]; // Funciona y es la Forma Recomendada.
            // document.getElementById("button-2" + i).innerHTML = string[i]; // Funciona pero no lo Recomiendan por Problemas de Seguridad y de Renderizado.
            // var t = document.createTextNode(string[i]); // Esta es otra forma pero más larga.
            // document.getElementById("button-2" + i).appendChild(t);
        }
    }
    element.disabled = true;
    element.style.color = "lightgray";
    element.style.border = "1px solid gray";
    element.classList.remove("button");
}


function guess()
{
    // if (document.getElementById("frase").value.localeCompare(string) == 0) // Funciona de las dos Formas, si localCompare Retorna 0 es que las Cadenas son Identicas.
    if (document.getElementById("frase").value === string) // Funciona Bien.
    {
        if (!alert("Eres el PIII Amo.")) window.open("index.html", "_self");
    }
}

function breakit()
{
    let break1 = document.createElement("br");
    let break2 = document.createElement("br");
    container.appendChild(break1);
    container.appendChild(break2);
}