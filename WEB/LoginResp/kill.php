<?php // Script de eliminación del perfil del usuario, Aquí se eliminan los datos de la base de datos y se arreglan los índices de la tabla para que sigan siendo correlativos.
include "includes/conn.php";
$title = "Eliminando Perfil";
include "includes/header.php";
include "includes/modal-index.html";

if (isset($_POST["id"]))
{
    $id = $_POST["id"];
    $sql = "DELETE FROM user WHERE id=$id;";
    $stmt = $conn->prepare($sql);
    $stmt->execute();
    $sql = "SET @count = 0; UPDATE user SET id = @count:= @count + 1; ALTER TABLE user AUTO_INCREMENT = 1;"; // Arreglo los índices de las facturas.
    $stmt = $conn->prepare($sql);
    $stmt->execute();
    echo '<script>toast(0, "Tu Perfil Ha Sido Eliminado:", "Gracias por Haber Usado este Sitio.");</script>';
}
?>