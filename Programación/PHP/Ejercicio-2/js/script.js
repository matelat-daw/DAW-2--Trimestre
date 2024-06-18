function screen()
{
    let height = window.innerHeight;
    let date = document.getElementById("date");
    date.innerHTML += new Date(Date.now()).toLocaleString() + " -";
}

function show(id, qtty)
{
    let which = document.getElementsByClassName("goContainer");
    let login = document.getElementById("login");
    login.style.display = "none";

    for (var i = 0; i < qtty; i++)
    {
        which[i].style.display = "none";
    }
    id.style.display = "block";
}

function register()
{
    
}

function ej1Opera()
{
    let num1 = document.getElementById("num1").value;
    let num2 = document.getElementById("num2").value;
    let result = document.getElementById("result");

    result.innerHTML = "Suma:             <br>" + "<span class='margin'>" + num1 + " + " + num2 + " = " + (parseInt(num1) + parseInt(num2)) + "</span><br><br>" +
    "Resta:            <br>" + "<span class='margin'>" + num1 + " - " + num2 + " = " + (num1 - num2) + "<br><br>" +
    "Multiplicación:   <br>" + "<span class='margin'>" + num1 + " * " + num2 + " = " + num1 * num2 + "<br><br>" +
    "División:         <br>" + "<span class='margin'>" + num1 + " / " + num2 + " = " + num1 / num2;
}