<?php // Script de confirmación de Eliminación del perfil del usuario.
if (isset($_POST["id"]))
{
    $id = $_POST["id"];
    $title = "Confirma Eliminación";
    include "includes/header.php";
    include "includes/modal-delete-owner.php";
    echo '<script>toast(2, "Se Borrará Tu Perfil:", "Estas Seguro que Quieres Eliminar tu Perfil del Sitio?");</script>';
}
?>