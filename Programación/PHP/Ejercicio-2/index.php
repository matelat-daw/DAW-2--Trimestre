<?php
include "includes/conn.php"; // Incluye la Conexión con la Base de Datos.
$title = "Ejercicios Varios, Para PHP."; // Título de la Página.
include "includes/header.php"; // Incluye el header con los CSS y JS de Bootstrap y de la Página.
include "includes/modal.html"; // Incluye el Diálogo que Muestra Mensajes.

    if (isset($_POST["email"])) // Comprueba que se ha Enviado por Post el E-mail del Usuario.
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

    echo '<div class="head">'; // Encabezado de la Página.
    if (isset($_SESSION["user"])) // Si se Abrió la Sesión de Usuario, Un Usuario se Logueó.
    {
        echo '<div class="firstHalf"><img src="img/logo.jpg" alt="Logo del Sitio" width="160"><h3 class="padding">Bienvenido al Sitio</h3></div><div class="secondHalf"><img src="' . $path . '" alt="Imagen de Perfil" width="160"><h3 class="padding">' . $_SESSION["user"] . '</h3><br><select name="options" onchange="closeSession();"><option>Selecciona una Opción</option><option value="close">Cierro Sesión</option></select></div>'; // Muestra el Logo de la Página, la Foto y Nombre del Usuario.
    }
    else // Si no se Logueó Ningún Usuario.
    {
        echo '<div class="firstHalf"><img src="img/logo.jpg" alt="Logo del Sitio" width="160" style="padding: 2px;"><h3 class="padding">Por Favor Usa tus Credenciales para Entrar en el Sitio.</h3></div><div class="secondHalf"><h3 class="padding">Aquí van tus Datos.</h3></div>'; // Muestra el Logo de la Página.
    }
    echo '</div>'; // Cierra el Encabezado.

    echo '<div class="container">'; // Abre el Contenedor, aquí se mostrarán todos los scripts, los Ejercicios, Juegos, Login y Registro.
    if (isset($_SESSION["user"])) // Vuelvo a Comprobar si ya se Inició la Sesión de Usuario.
    {
        $path = "pages/*"; // Asigno a $path todos los Ficheros que están en el Directorio pages.
        $qtty = count(glob($path)); // Asigno a $qtty la Cantidad de Ficheros.
        for ($i = 0; $i < $qtty; $i++) // Hago un Bucle a la Cantidad de Ficheros en el Directorio pages, son las páginas que se Abrirán, Dentro del div Contenedor container.
        {
            echo "<div class='goContainer' id='ex" . $i + 1 . "'>"; // Creo un div de la clase goContainer que Tiene la Propiedad Display a None.
            include "pages/ex" . ($i + 1) . ".php"; // Incluyo Todos los Scripts de PHP que hay en el Directorio pages, Todos Estarán con la Propiedad Display None.
            echo '</div>'; // Cierro el div.
        }
    }
    else // Si NO se Inició la Sesión de Usuario.
    {
        echo "<div class='goContainer' id='reg'>"; // Creo un div de la clase goContainer que Tiene la Propiedad Display a None.
        include "register.php"; // Incluyo el Script register.php
        echo '</div>'; // Cierro el div.

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
                        <i onclick='spy(3)' class='far fa-eye' id='togglePassword3' style='margin-left: -115px; cursor: pointer; visibility: hidden;'></i>
                        <br><br><br>
                        <input type='submit' value='Login' class='button1'>
                        <br><br>
                    </form>
                        <a href='recover.php'><small>Olvidaste tu Contraseña</small></a><span class='separator'>No estoy Dado de Alta, <a href='javascript:show(document.getElementById(\"reg\"));'>Quiero Regístrarme</a></span>
            </fieldset>
        </div>"; // Creo el div con ID login, Contiene el Formulario para la Entrada de Usuario y lo Cierro.
    }
    echo "</div>"; // Cierro el div container.

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
    </div>'; // Creo el div menu que solo Mostrará las Opciones que hay si el Usuario Está Logueado, Si hay un Usuario se Hace un Bucle a la Cantidad de Scripts en el Directorio pages y se Crea un Enlace que Llama a una Función de Javascript a la que se le pasa la ID del Script Seleccionado y la Función se Encarga de Mostrarlo en el div Contenedor.
?>
    <div class="footer">
        <h3 id="date" class="h3footer"> - CIFP César Manrique - César Osvaldo Matelat Borneo - </h3>
    </div>
    <script>date()</script>
    <!-- Por Último se crea un footer y Llamando a la Función date() de Javascript se Muestra la Fecha y la Hora en el Footer. -->
</body>
</html>