<?php
session_start();
session_destroy();
$title = "Cerrando Sesión.";
include "includes/header.php";
include "includes/modal-index.html";
echo '<script>toast(0, "Has Cerrado Sesión.", "Gracias por tu Visita.")</script>';
?>