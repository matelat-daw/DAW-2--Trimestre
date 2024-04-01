<?php
include "includes/conn.php";

if (isset($_POST["ID"]))
{
    $id = $_POST["ID"];
    $sql = "DELETE FROM usuario WHERE ID=$id";
    $stmt = $conn->prepare($sql);
    $stmt->execute();
    if ($stmt->rowCount() > 0)
    {
        echo "<script>if (!alert('Tus Datos se Han Eliminado de la Base de Datos.')) window.open('index.php', '_self');</script>";
    }
}
?>