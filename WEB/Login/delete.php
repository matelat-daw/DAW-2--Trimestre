<?php
if (isset($_POST["id"]))
{
    $id = $_POST["id"];
    include "includes/conn.php";
    $title = "Eliminando Perfil de Usuario";
    include "includes/header.php";
    include "includes/modal-delete.php";
    echo '<script>toast(2, "Se Borrará Tu Perfil:", "Estas Seguro que Quieres Eliminar tu Perfil del Sitio?");</script>';
}
?>