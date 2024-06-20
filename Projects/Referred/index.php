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
                <div id="view1">
                    <?php
                        include "includes/nav_index_top.html";
                        include "includes/slide.php";
                    ?>
                </div>
                <div id="view2">
                    <?php
                        include "includes/nav_index.html";
                    ?>
                    <br><br>
                    <div id="login">
                        <?php
                            include "includes/login.php";
                        ?>
                    </div>
                    <div id="logon">
                        <?php
                            include "includes/logon.php";
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