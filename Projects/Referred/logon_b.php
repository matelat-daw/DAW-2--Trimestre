<?php
include "includes/conn.php"; // Incluye la Conexión con la Base de Datos.

if (isset($_POST["business"])) // Si se ha Enviado por POST el username.
{
    $ok = false; // Asigno a la Variable $ok false.
    $name = $_POST["business"]; // Asigno a distintas Variables los Datos que Llegan por POST.
    $address = $_POST["address"];
    $phone = $_POST["phone"];
    $email = $_POST["email"];
    $pass = $_POST["pass"];
    $encrypted = password_hash($pass, PASSWORD_DEFAULT); // Se Encripta la Contraseña.
    $percentage = $_POST["percentage"];
    $path = "/business/img/logo.webp";
    $hash = hash("crc32", $email, false); // Se Genera un Hash que se Pasará Junto a la ID del Usuario para Activar la Cuenta por E-mail.
    $img = htmlspecialchars($_FILES["profile"]["name"]);
    $tmp = htmlspecialchars($_FILES["profile"]["tmp_name"]);
    $sql = "SELECT phone, email FROM business WHERE phone='$phone' OR email='$email';"; // Esta Sentencia SQL Verifica que no Estén ya Registrados Teléfono, E-mail o D.N.I.
    $stmt = $conn->prepare($sql);
    $stmt->execute();
    if ($stmt->rowCount() > 0) // Si Alguno de esos Datos ya Están Registrados.
    {
        $ok = false; // Asigno false a $ok.
    }
    else // Si no Están Registrados.
    {
        $ok = true; // Asigno true a $ok.
    }
}
if ($ok) // Si $ok es true.
{
    $title = "Registro de Empresa"; // Título de la Página
    include "includes/header.php"; // Incluyo el header.
    include "includes/modal_index.html"; // Incluyo el Diálogo para Mostrar Mensajes.

    $sql = "INSERT INTO business VALUES(:id, :name, :address, :phone, :email, :pass, :percentage, :path, :hash, :active)"; // Inserta en la Base de Datos.
    $stmt = $conn->prepare($sql);
    $stmt->execute(array(':id' => NULL, ':name' => $name, ':address' => $address, ':phone' => $phone, ':email' => $email, ':pass' => $encrypted, ':percentage' => $percentage, ':path' => $path, ':hash' => $hash, ':active' => false));
    $id = $conn->lastInsertId(); // Asigno a la variable $id la última id guardada en la tabla.

    $subject = "Si Tienes Algún Problema para Registrarte Contactame en Esta Dirección";
    $message = "<h3>Gracias por registrarte</h3><p>Por Favor haz Click en el Botón Activar mi Cuenta para Empezar a Usar el Sitio.</p><a href='http://" . $_SERVER['SERVER_NAME'] . "/Projects/Referred/activate.php/" . $hash . "/" . $id . "'><div style='background-color:aquamarine; border:thin; width:120px; height:60px; text-align:center;'>Activo mi Cuenta</div></a><br><br><small>Copyright © 2024 César Matelat <a href='mailto:matelat@gmail.com'>matelat@gmail.com</a></small>";
    $server_email = "matelat@gmail.com";
    $headers  = "From: $server_email" . "\r\n";
    $headers .= "X-Mailer: PHP/" . phpversion(). "\r\n";
    $headers .= 'MIME-Version: 1.0' . "\r\n";
    $headers .= 'Content-type: text/html; charset=UTF-8' . "\r\n";
    if(mail($email, $subject, $message, $headers)) // Comprueba si se ha Enviado el E-mail.
    {
        echo 'Se ha enviado un mensaje a tu cuenta de E-mail.';
        if (!file_exists("business"))
        {
            mkdir("business", 0777, true);
        }
        chdir ("business");
        if ($img != "")
        {
            if (!file_exists($id))
            {
                mkdir($id . "/pic", 0777, true);
            }
            $path = $id . "/pic/" . basename($img);
            move_uploaded_file($tmp, $path);
            $stmt = $conn->prepare("UPDATE business SET path='$path' WHERE id=$id;"); // Preparo una consulta para Actualizar la tabla.
            $stmt->execute(); // La Ejecuto.
        }
    }
    else // Si No se Pudo Enviar el Mensaje.
    {
        echo "<script>toast(2, 'ERROR del Servidor', 'Error al Enviar el Mensaje si Vuelves a Intentarlo y da Error Nuevamente, por Favor Escribe a <a href=\"mailto:matelat@gmail.com\">matelat@gmail.com</a>');</script>"; // Muestra el Diálogo que Hubo un Error, al Cerrar el Diálogo Vuelve a index.php.
    }
    echo "<script>toast(0, 'Activa tu Cuenta', 'Ya Estás Dado de Alta, Consulta tu E-mail para Confirmar tu Inscripción.');</script>"; // Si Todos ha Ido Bien, Muestra un Diálogo que Avisa que Tienes que Activar tu Cuenta, el Enlace de Activación te ha Llegado por E-mail.
}
else // Si No, si $ok es false.
{
    $title = "Tu Empresa ya Está Registrada";
    include "includes/header.php";
    include "includes/modal_index.html";
    echo "<script>toast(1, 'Datos Ya Registrados', 'Tus Datos ya Están Registrados en este Sitio, Por Favor Accede con tus Credenciales. Si has Olvidado la Contraseña Puedes Recuperarla Desde la Página de Login de Empresa.');</script>"; // Algún Dato ya Está en la Base de Datos, Tienes que Loguearte.
}
?>