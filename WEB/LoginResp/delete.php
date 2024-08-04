<?php // Script de confirmación de Eliminación del perfil del Usuario, Pide confirmación al Usuario para Eliminar el perfil.
if (isset($_POST["id"]))
{
    $id = $_POST["id"];
    $title = "Confirma Eliminación";
    include "includes/header.php";
    include "includes/modal-delete.php";
    echo '<script>toast(2, "Se Borrará Tu Perfil:", "Estas Seguro que Quieres Eliminar tu Perfil del Sitio?");</script>';
}
?>