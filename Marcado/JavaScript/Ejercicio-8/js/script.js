function draw()
{
    let rowcol = document.getElementById("rowcol").value;
    let table = document.getElementById("table");

    let myTable = document.createElement("table");

    for (var i = 0; i < rowcol; i++)
    {
        let row = document.createElement("tr");
        myTable.appendChild(row);
        for (var j = 0; j < rowcol; j++)
        {
            let col = document.createElement("td");
            myTable.appendChild(col);
        }
    }
    table.appendChild(myTable);
}