<?php
include "includes/conn.php";

if (isset($_POST["table"]))
{
    $table = $_POST['table'];
    if (file_exists($table . ".txt"))
    {
        unlink($table . ".txt");
    }
    $table_id = getTableId($conn, $table);
    $client = $_POST["client"];
    if ($client == "")
    {
        $client = null;
    }
    $invoice = $_POST['invoice'];
    $waiter = $_POST["waiter"];
    if ($waiter == "")
    {
        $waiter = null;
    }
    $date = date("Y-m-d");
    $time = date("H:i:s");
    $article = "";
    $qtty1 = "";
    $prices = "";
    $part = "";
    $total = 0;
    $j = 0;

    $record = explode (",", $invoice);
    for ($i = 0; $i < count($record) - 1; $i+=4)
    {
        $id[$j] = $record[$i];
        $price[$j] = $record[$i + 2];
        $qtty[$j] = $record[$i + 3];
        $total += $price[$j] * $qtty[$j];
        $j++;
    }
}

function getTableId($conn, $table)
{
    $sql = "SELECT id FROM mesa WHERE name='$table';";
    echo "<h3>$table</h3>";
    $stmt = $conn->prepare($sql);
    $stmt->execute();
    $row = $stmt->fetch(PDO::FETCH_OBJ);
    $id = $row->id;
    return $id;
}

$title = "Guardando Factura";
include "includes/header.php";
include "includes/modal-invoice.html";
?>
<section class="container-fluid pt-3">
    <div class="row">
        <div class="col-md-1"></div>
            <div class="col-md-10">
                <div id="view1">
                    <?php
                    $stmt = $conn->prepare('INSERT INTO invoice VALUES(:id, :client_id, :waiter_id, :table_id, :total, :inv_date, :inv_time);');
                    $stmt->execute(array(':id' => null, ':client_id' => $client, ':waiter_id' => $waiter, ':table_id' => $table_id, ':total' => $total, ':inv_date' => $date, ':inv_time' => $time));
                    // $sql = "SELECT id FROM invoice ORDER BY id DESC LIMIT 1;";
                    // $stmt = $conn->prepare($sql);
                    // $stmt->execute();
                    // $row = $stmt->fetch(PDO::FETCH_OBJ);
                    // $invoice_id = $row->id;
                    $invoice_id = $conn->lastInsertId();

                    $sql = "INSERT INTO sold VALUES(:id, :invoice_id, :food_id, :qtty);";
                    $stmt = $conn->prepare($sql);
                    for ($i = 0; $i < count($id); $i++)
                    {
                        $stmt->execute(array(':id' => null, ':invoice_id' => $invoice_id, ':food_id' => $id[$i], ':qtty' => $qtty[$i]));
                    }
                    echo "<script>toast('0', 'Facturado', 'Factura de monto: " . $total . " Alamacenada en la Base de Datos Correctamente.');</script>";
                    ?>
                </div>
            </div>
        <div class="col-md-1"></div>
    </div>
</section>
<?php
include "includes/footer.html";
?>