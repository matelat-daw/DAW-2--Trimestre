<?php
$title = "Ejercicio para Razor, Pero en PHP.";
include "includes/header.php";
?>
    <div class="head">
        <img src="img/Carnet-fin.jpg" alt="Imagen de Perfil" width="160">
        <h3 class="padding">César Osvaldo Matelat Borneo</h3>
    </div>
    <div class="container">
        <?php
            for ($i = 0; $i < 7; $i++)
            {
                echo "<div class='goContainer' id='ex" . $i + 1 . "'>";
                include "pages/ex" . ($i + 1) . ".php";
                echo '</div>';
            }
        ?>
    </div>
    <div class="menu">
        <h3 class="align">Selecciona una Opción</h3>
        <br><br>
        <ol>
            <?php
                for ($i = 0; $i < 7; $i++)
                {
                    echo "<a href='javascript:show(document.getElementById(\"ex" . $i + 1 . "\"));'><li>Ejercicio " . $i + 1 . "</li></a>";
                    echo "<br>";
                }
            ?>
        </ol>
    </div>
    <div class="footer">
        <h3 id="date" class="h3footer"> - CIFP César Manrique - César Osvaldo Matelat Borneo - </h3>
    </div>
    <script>screen()</script>
</body>
</html>