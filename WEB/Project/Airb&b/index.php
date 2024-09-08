<?php
include "includes/conn.php";
$title = "Alquileres Vacacionales - Principal";
include "includes/header.php";
include "includes/modal-index.html";
include "includes/nav-index.html";
?>
<section class="container-fluid pt-3">
    <div class="row">
        <div class="col-md-1"></div>
            <div class="col-md-10">
                <div id="view1">
                    <br><br><br><br>
                    <h1>Busca el Sitio Donde Quedarte en Argentina</h1>
                    <br><br>
                    <form action="search.php" method="post">
                        <fieldset>
                            <legend>Destino</legend>
                            <div class="menu">
                            <p>Lugar</p><input type="text" name="place"></div>
                            <div class="menu">
                            <p>Llegada</p><input type="date" name="start"></div>
                            <div class="menu">
                            <p>Salida</p><input type="date" name="end"></div>
                            <div class="menu">
                            <p>Adultos</p><input type="number" name="adult" min="1" max="24"></div>
                            <div class="menu">
                            <p>Niños</p><input type="number" name="child" min="0" max="24"></div>
                            <div class="menu">
                            <p>Bebés</p><input type="number" name="baby" min="0" max="24"></div>
                            <div class="menu">
                            <p>Mascotas</p><input type="number" name="pet" min="0" max="24"></div>
                            <br><br>
                            <input type="submit" value="Busca" class="btn btn-success btn-lg">
                        </fieldset>
                </div>
            </div>
        <div class="col-md-1"></div>
    </div>
</section>
<?php
include "includes/footer.html";
?>