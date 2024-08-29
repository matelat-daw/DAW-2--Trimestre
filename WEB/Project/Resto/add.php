<?php
$title = "Pedidos del Restauramte";
include "includes/header.php";
?>
<section class="container-fluid pt-3">
<div id="pc"></div>
    <div id="mobile"></div>
    <div class="row">
        <div class="col-md-1"></div>
            <div class="col-md-10">
                <div id="view1">
                    <br><br><br><br>
                    <div>
                        <button onclick="window.open('adding.php?id=0')" class="size btn btn-primary btn-lg">Agregar Platos</button>
                        <button onclick="window.open('adding.php?id=1')" class="size marg btn btn-success btn-lg">Agregar Bebidas</button>
                        <button onclick="window.open('adding.php?id=2')" class="size marg btn btn-danger btn-lg">Agregar Postres</button>
                        <button onclick="window.open('adding.php?id=3')" class="size marg btn btn-secondary btn-lg">Agregar Café</button>
                        <button onclick="window.open('adding.php?id=4')" class="size marg btn btn-info btn-lg">Agregar Vino</button>
                        <br><br>
                        <button onclick="window.close()" style="width:112px; height:48px; float:right; margin-top:15%" class="btn btn-secondary btn-lg">Cierra esta Ventana</button>
                    </div>
                </div>
            </div>
        <div class="col-md-1"></div>
    </div>
</section>
<?php
include "includes/footer.html";
?>