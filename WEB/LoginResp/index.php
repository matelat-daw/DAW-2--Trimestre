<?php
$title = "Bienvenido Registarte para Usar el Sitio";
include "includes/header.php";
include "includes/modal.html";
include "includes/nav-pc-index.html";
?>
<section class="container-fluid pt-3">
    <div class="row">
        <div class="col-md-1"></div>
            <div class="col-md-10">
                <div id="view1">
                <h2>Te Damos la Bienvenida al Sitio</h2>
                <br>
                    <div class="great medium"> <!-- Contenedor de la vista para resoluciones de pantalla media y grande, PC Tablet. -->
                        <div id="login"><?php include "includes/login.html"; ?></div> <!-- Contiene el html login.html. -->
                        <div id="logon"><?php include "includes/logon.html"; ?></div> <!-- Contiene el html logon.html, es invisible al abrir la página. -->
                    </div>
                    <div class="mini"> <!-- Contenedor de la vista para resoluciones de pantalla media y grande, PC Tablet. -->
                        <div id="login"><?php include "includes/login.html"; ?></div> <!-- Contiene el html login.html. -->
                        <div id="logon"><?php include "includes/logon.html"; ?></div> <!-- Contiene el html logon.html, es invisible al abrir la página. -->
                    </div>
                </div>
            </div>
        <div class="col-md-1"></div>
    </div>
</section>
<br><br><br><br>
<?php
include "includes/footer.html";
?>