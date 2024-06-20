<?php // Script que destruye la sesión.
session_start();
session_destroy(); // Cierra la Sesión de Usuario, para Poder Cerrar la Sesión hay que Usar session_start() para Mantener la Sesión que se Inició en Otro Script.
$title = "Has Cerrado Sesión, Hasta Pronto";
include "includes/header.php";
?>
<section class="container-fluid pt-3">
    <div class="row">
        <div class="col-md-10">
            <div id="view1">
                <br><br><br><br>
                <h1>Has Cerrado Sesión Vuelve a la Página de Inicio.</h1>
                <br>
                <button class="btn btn-primary" onclick="window.open('index.php', '_self')">Vuelve al Inicio</button>
            </div>
        </div>
    </div>
</section>