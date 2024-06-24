<?php
include "includes/conn.php";
$title = "Main Page";
include "includes/header.php";
include "includes/modal.html";
?>
<section class="container-fluid pt-3">
    <div class="row">
        <div class="col-md-1"></div>
            <div class="col-md-10">
            <?php
                include "includes/nav_index_top.html"; // Menú de Index.
            ?>
                <div id="view1">
                    <?php
                        include "includes/slide.php";
                    ?>
                </div>
                <div id="view2">
                    <br><br>
                    <?php
                        include "includes/nav_index_u.html"; // Menú de la Vista de LogIn/Registro de Usuario.
                    ?>
                    <br><br>
                    <div id="login_u">
                        <?php
                            include "includes/login_u.php";
                        ?>
                    </div>
                    <div id="logon_u">
                        <?php
                            include "includes/logon_u.php";
                        ?>
                    </div>
                </div>
                <div id="view3">
                    <br><br>
                    <?php
                        include "includes/nav_index_b.html"; // Menú de la Vista de LogIn/Registro de Empresa.
                    ?>
                    <br><br>
                    <div id="login_b">
                        <?php
                            include "includes/login_b.php";
                        ?>
                    </div>
                    <div id="logon_b">
                        <?php
                            include "includes/logon_b.php";
                        ?>
                    </div>
                </div>
                <br><br>
            </div>
        <div class="col-md-1"></div>
    </div>
</section>
<?php
include "includes/footer.html";
?>