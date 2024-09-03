<?php
include "includes/conn.php";
$title = "Eliminando una Mesa";
include "includes/header.php";

if (isset($_POST["table"]))
{
    $id = $_POST["table"];
    include "includes/modal-delete.php";
    $table = getTable($conn, $id);
    echo '<script>toast(0, "Eliminando Mesa: ' . $table . '", "Estás seguro que quieres Eliminar la Mesa ' . $table . '");</script>';
}

if (isset($_GET["id"]))
{
    include "includes/modal-dismiss.html";
    $id = $_GET["id"];
    $table = getTable($conn, $id);
    $sql = "DELETE FROM mesa WHERE id = $id;";
    $stmt = $conn->prepare($sql);
    $stmt->execute();
    $sql = "SET @count = 0; UPDATE mesa SET id = @count:= @count + 1; ALTER TABLE mesa AUTO_INCREMENT = 1;"; // Arreglo los índices de las Facturas.
    $stmt = $conn->prepare($sql);
    $stmt->execute();
    echo '<script>toast(0, "Mesa ' . $table . ' Eliminada", "Se ha Eliminado la Mesa ' . $table . '.");</script>';
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