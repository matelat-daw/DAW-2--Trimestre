<?php
include "includes/conn.php";
$title = "Alquileres Vacacionales - Principal";
include "includes/header.php";
include "includes/modal-dismiss.html";
include "includes/nav-index.html";
?>
<section class="container-fluid pt-3">
    <div class="row">
        <div class="col-md-1"></div>
            <div class="col-md-10">
                <div id="view1">
                    <br><br>
                    <h1>Busca el Sitio Donde Quedarte en Argentina</h1>
                    <br><br>
                    <form action="search.php" method="post">
                        <fieldset>
                            <legend>Destino</legend>
                            <div class="inline">
                            <p>Lugar</p><p><input type="text" name="place"></p></div>
                            <div class="inline">
                            <p>Llegada</p><p><input type="date" name="start"></p></div>
                            <div class="inline">
                            <p>Salida</p><p><input type="date" name="end"></p></div>
                            <div class="inline">
                            <p>Adultos</p><p><input type="number" name="adult" min="1" max="24"></p></div>
                            <div class="inline">
                            <p>Niños</p><p><input type="number" name="child" min="0" max="24"></p></div>
                            <div class="inline">
                            <p>Bebés</p><p><input type="number" name="baby" min="0" max="24"></p></div>
                            <div class="inline">
                            <p>Mascotas</p><p><input type="number" name="pet" min="0" max="24"></p></div>
                            <br><br>
                            <input type="submit" value="Busca" class="btn btn-success btn-lg">
                        </fieldset>
                    </form>
                </div>
                <div id="view2">
                    <br><br>
                    <div id="client_on"><?php include "includes/client-logon.html"; ?></div>
                    <div id="owner_on"><?php include "includes/owner-logon.html"; ?></div>
                    <div id="client_in"><?php include "includes/client-login.html"; ?></div>
                    <div id="owner_in"><?php include "includes/owner-login.html"; ?></div>
                </div>
            </div>
        <div class="col-md-1"></div>
    </div>
</section>
<?php
include "includes/footer.html";
?>