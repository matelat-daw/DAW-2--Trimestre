<?php
include "includes/conn.php";
$title = "Modificando Mesa";
include "includes/header.php";
include "includes/modal-dismiss.html";

if (isset($_POST["table"]))
{
    $id = $_POST["table"];
    $table = getTable($conn, $id);
    echo '<form method="post">
            <label><input type="text" name="modify" value="' . $table . '"> Nombre de la Mesa</label>
            <input type="hidden" name="id" value="' . $id . '">
            <br><br>
            <input type="submit" value="Modifico esta Mesa">
            </form>';
}
if (isset($_POST["modify"]))
{
    $id = $_POST["id"];
    $table = $_POST["modify"];
    $sql = "UPDATE mesa SET name = '$table' WHERE id=$id;";
    $stmt = $conn->prepare($sql);
    $stmt->execute();
    echo "<script>toast ('0', 'Mesa : " . $table . " Modificada.', 'La Mesa ha Sido Modificada Correctamente.');</script>";
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