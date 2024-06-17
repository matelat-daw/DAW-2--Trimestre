function show()
{
    let keyboard = document.getElementById("keyboard");
    let container = document.getElementById("container");

    for (var i = 65; i < 91; i++)
    {
        let button = document.createElement("button");
        button.id = "button" + (i - 65);
        button.innerHTML = String.fromCharCode(i);
        button.className = "button";
        button.onclick = function(){disable(this.id);};
        keyboard.appendChild(button);
    }
}

function disable(id)
{
    let container = document.getElementById("container");
    let element = document.getElementById(id);

    let span = document.createElement("span");
    span.className = "span";
    span.innerHTML = element.innerHTML;
    container.appendChild(span);
    element.disabled = true;
    element.style.color = "lightgray";
    element.style.border = "1px solid gray";
    element.classList.remove("button");
}