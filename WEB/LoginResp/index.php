<?php
$title = "Bienvenido Registarte para Usar el Sitio";
include "includes/header.php";
include "includes/modal.html";
?>
<section class="container-fluid pt-3">
    <div class="row">
        <div class="col-md-1"></div>
            <div class="col-md-10">
                <div id="view1">
                    <div class="medium great">
                        <div id="login"><?php include "includes/login.html"; ?></div> <!-- Contiene el html login.html. -->
                        <div id="logon"><?php include "includes/logon.html"; ?></div> <!-- Contiene el html logon.html, es invisible al abrir la página. -->
                    </div>
                    <div class="mini">
                        <div id="login"><?php include "includes/login.html"; ?></div> <!-- Contiene el html login.html. -->
                        <div id="logon"><?php include "includes/logon.html"; ?></div> <!-- Contiene el html logon.html, es invisible al abrir la página. -->
                        <script>let btn = document.getElementById("btn");
                            btn.addEventListener("click", show, true);
                            btn.param = "logon";
                        </script>
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