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
        myTable.appendChild(row);
        for (var j = 0; j < rowcol; j++)
        {
            let col = document.createElement("td");
            if (i == 0 && j == 0)
            {
                col.id = "circle";
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

}