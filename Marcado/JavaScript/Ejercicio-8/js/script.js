function draw()
{
    let rowcol = document.getElementById("rowcol").value;
    let table = document.getElementById("table");
    table.innerHTML = "";

    let myTable = document.createElement("table");
    myTable.setAttribute("width", 600 + rowcol * 10 + "px");
    myTable.setAttribute("height", 600 + rowcol * 10 + "px");

    for (var i = 0; i < rowcol; i++)
    {
        let row = document.createElement("tr");
        row.id = i + 1;
        myTable.appendChild(row);
        for (var j = 0; j < rowcol; j++)
        {
            let col = document.createElement("td");
            col.id = j + 1;
            if (i == 0 && j == 0)
            {
                col.setAttribute("class", "circle");
                // let div = document.createElement("span");
                // div.setAttribute("class", "circle");
                // div.setAttribute("style", "display: inline-block; width:" + 600 / rowcol + "px; height:" + 600 / rowcol + "px;");
                // col.appendChild(div);
            }
            row.appendChild(col);
        }
    }
    table.appendChild(myTable);
}

function right()
{

}

function left()
{

}

function down()
{

}

function up()
{
    let tr = document.getElementsByTagName("tr");
    let td = document.getElementByTagName("td");
    
    if (tr.childNodes[0])
    {
        if (td.childNodes[0])
        {

        }
    }
}