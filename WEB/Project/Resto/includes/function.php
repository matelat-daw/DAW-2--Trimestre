<?php
function result($conn, $row, $where, $how) // Función result recibe la conexión, las filas de la base de datos $row y un 1 o un 0 para saber de donde se llama y cómo se llamó.
{
    global $table_name, $client, $waiter, $price, $partial, $product, $qtty;
    $eacharticle = [];
    if ($how == 0)
    {
        $table_name = getTable($conn, $row["table_id"]);
        $client = getClient($conn, $row["client_id"]);
        $waiter = getWaiter($conn, $row["waiter_id"]);
    }
    else
    {
        $table_name = getTable($conn, $row->table_id);
        $client = getClient($conn, $row->client_id);
        $waiter = getWaiter($conn, $row->waiter_id);
    }

    $sql = "SELECT id FROM invoice ORDER BY id DESC LIMIT 1;";
    $stmt = $conn->prepare($sql);
    $stmt->execute();
    $row = $stmt->fetch(PDO::FETCH_OBJ);
    $id = $row->id;

    $i = 0;
    $sql  = "SELECT * FROM sold WHERE invoice_id=$id;";
    $stmt = $conn->prepare($sql);
    $stmt->execute();
    while ($row = $stmt->fetch(PDO::FETCH_OBJ))
    {
        $article[$i] = $row->food_id;
        $qtties[$i] = $row->qtty;
        $i++;
    }

    for ($i = 0; $i < count($article); $i++)
    {
        $sql_product = "SELECT name, price FROM food WHERE id=$article[$i];";
        $stmt = $conn->prepare($sql_product);
        $stmt->execute();
        $row_product = $stmt->fetch(PDO::FETCH_OBJ);
        $product_name = $row_product->name;
        $product_price = $row_product->price;
        $partials[$i] = $product_price * $qtties[$i];
        if ($i == count($article) - 1)
        {
            $product .= $product_name;
            $price .= number_format((float)$product_price, 2, ',', '.') . " $";
            $qtty .= $qtties[$i];
            $partial .= number_format((float)$partials[$i], 2, ',', '.') . " $";
        }
        else
        {
            if ($where == 1) // Si $where es 1, se llamo desde la tabla HTML.
            {
                $product .= $product_name . "<br>"; // Saltos de línea HTML.
                $price .= number_format((float)$product_price, 2, ',', '.') . " $<br>";
                $qtty .= $qtties[$i] . "<br>";
                $partial .= number_format((float)$partials[$i], 2, ',', '.') . " $<br>";
            }
            else // Si no es 1 se llamo desde la plantilla de Excel.
            {
                $product .= $product_name . "\n"; // Saltos de línea \n.
                $price .= number_format((float)$product_price, 2, ',', '.') . " $\n";
                $qtty .= $qtties[$i] . "\n";
                $partial .= number_format((float)$partials[$i], 2, ',', '.') . " $\n";
            }
        }
    }
}

function getClient($conn, $id)
{
    if ($id != null)
    {
        $sql = "SELECT name FROM client WHERE id=$id;";
        $stmt = $conn->prepare($sql);
        $stmt->execute();
        $row = $stmt->fetch(PDO::FETCH_OBJ);
        return $row->name;
    }
    else
    {
        return "Consumidor Final";
    }
}

function getWaiter($conn, $id)
{
    if ($id != null)
    {
        $sql = "SELECT name FROM waiter WHERE id=$id;";
        $stmt = $conn->prepare($sql);
        $stmt->execute();
        $row = $stmt->fetch(PDO::FETCH_OBJ);
        return $row->name;
    }
    else
    {
        return "Fonda 13";
    }
}

function getTable($conn, $id)
{
    $sql = "SELECT name FROM mesa WHERE id=$id;";
    $stmt = $conn->prepare($sql);
    $stmt->execute();
    $row = $stmt->fetch(PDO::FETCH_OBJ);
    return $row->name;
}
?>