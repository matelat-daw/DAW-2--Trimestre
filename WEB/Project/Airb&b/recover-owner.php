<?php // Script para recuperar la contraseña, se genera una contraseña aleatoria de 8 caracteres, y se envía por E-mail para mayor seguridad.
include "includes/conn.php";
$title = "Recupera tu Contraseña";
include "includes/header.php";
include "includes/modal-index.html";

if (isset($_POST["email"]))
{
    $email = htmlspecialchars($_POST["email"]);

    $sql = "SELECT owner_email FROM owner WHERE owner_email='$email';"; // Preparo una consulta del E-mail del usuario.
    $stmt = $conn->prepare($sql);
    $stmt->execute();
    if ($stmt->rowCount() > 0) // Si el E-mail está en la base de datos, se prepara y se envía la contraseña por E-mail.
    {
        $hash = substr(md5(uniqid($email, true)), 8, 8);
        $pass = password_hash($hash, PASSWORD_DEFAULT);
        $subject = "Solicitaste Modificar tu Contraseña";
        $message = "<h3>Contraseña Cambiada:</h3><p>Has Pedido Cambiar tu Contraseña, se ha Generado una al Azar, por Favor Entra al Sitio, Logueate con la Nueva Contraseña y Cambiala por una que te sea Familiar.<br>Tu Nueva Contraseña es: " . $hash . "</p><a href='http://" . $_SERVER['SERVER_NAME'] . "/web/Project/Airb&b/index.php'><div style='background-color:aquamarine; border:thin; width:120px; height:60px; text-align:center;'>Entro en mi Perfil</div></a><br><br><small>Copyright © 2024 César Matelat <a href='mailto:matelat@gmail.com'>matelat@gmail.com</a></small>";
        $server_email = "matelat@gmail.com";
        $headers  = "From: $server_email\r\n";
        $headers .= "MIME-Version: 1.0\r\n";
        $headers .= "Content-type: text/html; charset=UTF-8\r\n";

        if(mail($email, $subject, $message, $headers)) // Si el mensaje se envía con exito.
        {
            $stmt = $conn->prepare("UPDATE owner SET owner_pass='$pass' WHERE owner_email='$email';"); // Preparo una consulta para Actualizar la tabla.
            $stmt->execute(); // La Ejecuto.
        }
        else // Si No
        {
            echo "<script>toast(2, 'ERROR:', 'Error al Enviar el Mensaje si Vuelves a Intentarlo y Sigue Dando Error, por Favor Escribe a matelat@gmail.com.');</script>"; // Error y vuelve a index.php.
        }
        echo "<script>toast(0, 'Contraseña Cambiada:', 'Te Hemos Enviado un E-mail a tu Dirección de Correo Electrónico con la Nueva Contraseña.<br>Recuerda Entrar en tu Perfil y Modificarla  por una que te sea Familiar. Gracias por Usar el Sitio.');</script>"; // Muestro un aviso que se ha enviado la contraseña por E-mail.
    }
    else // Si la dirección de E-mail no está en la base de datos.
    {
        echo "<script>toast(2, 'Hay un Error', 'Lo Siento no Existe Ningún Usuario con E-mail: $email, Vuelve a Intentarlo con la Dirección con la que te Registrate.');</script>"; // Error.
    }
}
?>
<!-- Entra en la página y muestra este script html. -->
<section class="container-fluid pt-3">
    <div class="row">
        <div class="col-md-1"></div>
            <div class="col-md-10">
                <div id="view1">
                <br><br><br><br>
                    <h1>Vas a Modificar tu Contraseña por una Provisoria</h1>
                    <br><br>
                    <h2>Por Favor Después de Loguearte Modifícala Entrando en tu Perfil</h2>
                    <br><br>
                    <form method="post">
                        <label><input type="text" name="email"> Danos el E-mail con el que te Registraste</label>
                        <br><br>
                        <input type="submit" value="Modifico mi Contraseña" class="btn btn-secondary btn-lg">
                    </form>
                </div>
            </div>
        <div class="col-md-1"></div>
    </div>
</section>
</body>
</html>