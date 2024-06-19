<?php
include "includes/conn.php";
$title = "Ejercicios Varios, Para PHP.";
include "includes/header.php";
include "includes/modal.html";

    if (isset($_POST["email"]))
    {
        $email = $_POST["email"];
        $pass = $_POST["pass"];
        $path = "users/";

        $sql = "SELECT * FROM user WHERE email='$email'";
        $stmt = $conn->prepare($sql);
        $stmt->execute();
        if ($stmt->rowCount() > 0)
        {
            $row = $stmt->fetch(PDO::FETCH_OBJ);
            if ($row->active)
            {
                if (password_verify($pass, $row->pass))
                {
                    $_SESSION["user"] = $row->name;
                    $path .= $row->path;
                    echo "<script>console.log('Perfecto, Entró y se Logueó.');</script>";
                }
                else
                {
                    echo "<script>toast(1, 'ERROR de DATOS.', 'El E-mail o la Contraseña no son Correctos.<br>Intentalo de Nuevo.');</script>";
                }
            }
        }
        else
        {
            echo "<script>toast(1, 'ERROR de DATOS.', 'El E-mail o la Contraseña no son Correctos.<br>Intentalo de Nuevo.');</script>";
        }
    }

    echo '<div class="head">';
    if (isset($_SESSION["user"]))
    {
        echo '<div class="firstHalf"><img src="img/logo.jpg" alt="Logo del Sitio" width="160"><h3 class="padding">Bienvenido al Sitio</h3></div><div class="secondHalf"><img src="' . $path . '" alt="Imagen de Perfil" width="160"><h3 class="padding">' . $_SESSION["user"] . '</h3><br><select name="options" onchange="closeSession();"><option>Selecciona una Opción</option><option value="close">Cierro Sesión</option></select></div>';
    }
    else
    {
        echo '<div class="firstHalf"><img src="img/logo.jpg" alt="Logo del Sitio" width="160" style="padding: 2px;"><h3 class="padding">Por Favor Usa tus Credenciales para Entrar en el Sitio.</h3></div><div class="secondHalf"><h3 class="padding">Aquí van tus Datos.</h3></div>';
    }
    echo '</div>';

    echo '<div class="container">';
    if (isset($_SESSION["user"]))
    {
        $path = "pages/*";
        $qtty = count(glob($path));
        for ($i = 0; $i < $qtty; $i++)
        {
            echo "<div class='goContainer' id='ex" . $i + 1 . "'>";
            include "pages/ex" . ($i + 1) . ".php";
            echo '</div>';
        }
    }
    else
    {
        echo "<div class='goContainer' id='reg'>";
        include "register.php";
        echo '</div>';

        echo "<div id='login'>
            <h3>Entrada de Usuario</h3>
            <br>
            <fieldset>
                <legend>Ingresa tu Credenciales</legend>
                <br><br>
                    <form action='index.php' method='post'>
                        <label><input type='email' name='email' required> E-mail</label>
                        <br><br>
                        <label><input type='password' name='pass' id='pass3' onkeypress='showEye(3)' required> Contraseña</label>
                        <i onclick='spy(3)' class='far fa-eye' id='togglePassword3' style='margin-left: -140px; cursor: pointer; visibility: hidden;'></i>
                        <br><br><br>
                        <input type='submit' value='Login' class='button1'>
                        <br><br>
                    </form>
                        <a href='recover.php'><small>Olvidaste tu Contraseña</small></a><span class='separator'>No estoy Dado de Alta, <a href='javascript:show(document.getElementById(\"reg\"));'>Quiero Regístrarme</a></span>
            </fieldset>
        </div>";
    }
    echo "</div>";

    echo '<div class="menu">
        <h3 class="align">Selecciona una Opción</h3>
        <br><br>
        <ol>';
        if (isset($_SESSION["user"]))
        {
            for ($i = 0; $i < $qtty; $i++)
            {
                echo "<a href='javascript:show(document.getElementById(\"ex" . $i + 1 . "\"));'><li>Ejercicio " . $i + 1 . "</li></a>";
                echo "<br>";
            }
        }
        echo '</ol>
    </div>';
?>
    <div class="footer">
        <h3 id="date" class="h3footer"> - CIFP César Manrique - César Osvaldo Matelat Borneo - </h3>
    </div>
    <script>screen()</script>
</body>
</html>