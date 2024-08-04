<?php
session_start();
session_destroy(); // Destruye la sesión de usuario, muestra un mensaje que se ha cerrado la sesión y vuelve a index.php.
$title = "Cerrando Sesión.";
include "includes/header.php";
include "includes/modal-index.html";
echo '<script>toast(0, "Has Cerrado Sesión.", "Gracias por tu Visita.")</script>';
?>