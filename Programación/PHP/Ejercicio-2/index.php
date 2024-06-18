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
            $path = "pages/*";
            $qtty = count(glob($path));
            for ($i = 0; $i < $qtty - 1; $i++)
            {
                echo "<div class='goContainer' id='ex" . $i + 1 . "'>";
                include "pages/ex" . ($i + 1) . ".php";
                echo '</div>';
            }

            echo "<div class='goContainer' id='reg" . $qtty . "'>";
                include "pages/register.php";
            echo '</div>';
        ?>
        <div id="login">
        <h3>Entrada de Usuario</h3>
        <br>
        <fieldset>
            <legend>Ingresa tu Credenciales</legend>
                <form action="login.php" method="post">
                    <label><input type="email" name="email" required> E-mail</label>
                    <br><br>
                    <label><input type="password" name="pass" id="pass3" onkeypress="showEye(3)" required> Contraseña</label>
                    <i onclick="spy(3)" class="far fa-eye" id="togglePassword3" style="margin-left: -140px; cursor: pointer; visibility: hidden;"></i>
                    <br><br>
                    <input type="submit" value="Login">
                    <br><br>
                </form>
                <?php
                    echo "<a href='recover.php'><small>Olvidaste tu Contraseña</small></a><span class='separator'>No estoy Dado de Alta, <a href='javascript:show(document.getElementById(\"reg" . $qtty . "\"), " . $qtty . ");'>Quiero Regístrarme</a></span>";
                ?>
        </fieldset>
        </div>
    </div>
    <div class="menu">
        <h3 class="align">Selecciona una Opción</h3>
        <br><br>
        <ol>
            <?php
                for ($i = 0; $i < $qtty; $i++)
                {
                    echo "<a href='javascript:show(document.getElementById(\"ex" . $i + 1 . "\"), " . $qtty . ");'><li>Ejercicio " . $i + 1 . "</li></a>";
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