<?php
if (isset($_GET["id"]))
{
    $id = $_GET["id"];
    include "includes/conn.php";
    $title = "Eliminando Perfil de Usuario";
    include "includes/header.php";
    include "includes/modal-delete.php";
    echo '<script>toast(2, "Se Eliminará Tu Perfil:", "Estas Seguro que Quieres ELiminar tu Perfil del Sitio?");</script>';
}
?>