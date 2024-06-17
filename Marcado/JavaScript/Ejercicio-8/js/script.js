var vertical = 1;
var horizontal = 1;
var length = 0;
var size = 0;

function draw()
{
    let rowcol = document.getElementById("rowcol").value;
    window.size = rowcol;
    let table = document.getElementById("table");
    table.innerHTML = "";

    let myTable = document.createElement("table");
    myTable.setAttribute("width", 600 + size * 10 + "px");
    myTable.setAttribute("height", 600 + size * 10 + "px");
    mySize = (600 + size * 10) / size + "px";

    for (var i = 0; i < rowcol; i++)
    {
        let row = document.createElement("tr");
        myTable.appendChild(row);
        for (var j = 0; j < rowcol; j++)
        {
            let col = document.createElement("td");
            col.style.width = mySize;
            col.style.height = mySize;
            if (i == 0 && j == 0)
            {
                let circulo = document.createElement("div");
                circulo.id = "circulo";
                circulo.setAttribute("class", "circle");
                circulo.style.backgroundColor = "black";
                circulo.style.width = mySize;
                circulo.style.height = mySize;
                col.appendChild(circulo);
            }
            row.appendChild(col);
        }
    }
    table.appendChild(myTable);
    document.getElementById("color").value = "black";
    vertical = 1;
    horizontal = 1;
}

function change()
{
    var td = document.getElementsByClassName("circle");
    td[0].style.backgroundColor = document.getElementById("color").value;
}

function circleSize()
{
    let sizeSelected = document.getElementById("mySize");
    var circulo = document.getElementById("circulo");

    switch(sizeSelected.value)
    {
        case "big":
            circulo.style.width = (600 + size * 10) / size + "px";
            circulo.style.height = (600 + size * 10) / size + "px";
            circulo.style.marginLeft = 0;
            break;
        case "med":
            circulo.style.width = ((600 + size * 10) / size) * .6 + "px";
            circulo.style.height = ((600 + size * 10) / size) * .6 + "px";
            circulo.style.marginLeft = 20 + "%";
            break;
        default:
            circulo.style.width = ((600 + size * 10) / size) * .3 + "px";
            circulo.style.height = ((600 + size * 10) / size) * .3 + "px";
            circulo.style.marginLeft = 35 + "%";
    }
}

function right()
{
    if (horizontal < size)
    {
        var circulo = document.getElementById("circulo");
        var row = document.querySelectorAll("tr")[vertical - 1];
        row.querySelectorAll("td")[horizontal - 1].nextElementSibling.appendChild(circulo);
        horizontal++;
    }
}

function left()
{
    if (horizontal > 1)
    {
        var circulo = document.getElementById("circulo");
        var row = document.querySelectorAll("tr")[vertical - 1];
        row.querySelectorAll("td")[horizontal - 1].previousElementSibling.appendChild(circulo);
        horizontal--;
    }
}

function down()
{
    if (vertical < size)
    {
        var circulo = document.getElementById("circulo");
        var row = document.querySelectorAll("tr")[vertical];
        row.querySelectorAll("td")[horizontal - 1].appendChild(circulo);
        vertical++;
    }
}

function up()
{
    if (vertical > 1)
    {
        var circulo = document.getElementById("circulo");
        var row = document.querySelectorAll("tr")[vertical - 2];
        row.querySelectorAll("td")[horizontal - 1].appendChild(circulo);
        vertical--;
    }
}