<?php // Script de eliminación del perfil de Cliente.
include "includes/conn.php";
$title = "Eliminando Perfil";
include "includes/header.php";
include "includes/modal-index.html";

if (isset($_POST["id"]))
{
    $id = $_POST["id"];
    $sql = "DELETE FROM client WHERE client_dni='$id';";
    $stmt = $conn->prepare($sql);
    $stmt->execute();
    echo '<script>toast(0, "Tu Perfil Ha Sido Eliminado:", "Gracias por Haber Usado este Sitio.");</script>';
}
?>