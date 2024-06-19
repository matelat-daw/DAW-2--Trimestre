<?php
include "includes/conn.php";

if (isset($_POST["username"]))
{
    $ok = false;
    $user = $_POST["username"];
    $surname1 = $_POST["surname"];
    $surname2 = $_POST["surname2"];
    if ($surname2 == "")
    {
        $surname2 = NULL;
    }
    $dni = $_POST["dni"];
    $phone = $_POST["phone"];
    $email = $_POST["email"];
    $bday = $_POST["bday"];
    $gender = $_POST["gender"];
    if ($gender == 0)
    {
        $path = "img/female.jpg";
    }
    else
    {
        $path = "img/male.jpg";
    }
    $pass = $_POST["pass"];
    $encrypted = password_hash($pass, PASSWORD_DEFAULT);
    $hash = hash("crc32", $email, false);
    $img = htmlspecialchars($_FILES["profile"]["name"]);
    $tmp = htmlspecialchars($_FILES["profile"]["tmp_name"]);
    $sql = "SELECT dni, phone, email FROM user WHERE phone='$phone' OR email='$email' OR dni='$dni'";
    $stmt = $conn->prepare($sql);
    $stmt->execute();
    if ($stmt->rowCount() > 0)
    {
        $ok = false;
    }
    else
    {
        $ok = true;
    }
}
if ($ok)
{
    $title = "Registro de Usuario";
    include "includes/header.php";
    include "includes/modal_index.html";

    $sql = "INSERT INTO user VALUES(:id, :dni, :name, :surname, :surname2, :phone, :email, :pass, :bday, :path, :hash, :active)";
    $stmt = $conn->prepare($sql);
    $stmt->execute(array(':id' => NULL, ':dni' => $dni, ':name' => $user, ':surname' => $surname1, ':surname2' => $surname2, ':phone' => $phone, ':email' => $email, ':pass' => $encrypted, ':bday' => $bday, ':path' => $path, ':hash' => $hash, ':active' => false));
    $id = $conn->lastInsertId(); // Asigno a la variable $id la última id guardada en la tabla.

    $subject = "Por Favor, si Tienes Algún Problema para Registrarte Contactame en Esta Dirección";
    $message = "<h3>Gracias por registrarte</h3><p>Por Favor haz Click en el Botón Activar mi Cuenta para Empezar a Usar el Sitio.</p><a href='http://" . $_SERVER['SERVER_NAME'] . "/Programación/PHP/Ejercicio-2/activate.php/" . $hash . "/" . $id . "'><div style='background-color:aquamarine; border:thin; width:120px; height:60px; text-align:center;'>Activar mi Cuenta</div></a><br><br><small>Copyright © 2021 César Matelat <a href='mailto:matelat@gmail.com'>matelat@gmail.com</a></small>";
    $server_email = "matelat@gmail.com";
    $headers  = "From: $server_email" . "\r\n";
    $headers .= "X-Mailer: PHP/" . phpversion(). "\r\n";
    $headers .= 'MIME-Version: 1.0' . "\r\n";
    $headers .= 'Content-type: text/html; charset=UTF-8' . "\r\n";
    if(mail($email, $subject, $message, $headers))
    {
        echo 'Se ha enviado un mensaje a tu cuenta de E-mail.';
        if (!file_exists("users"))
        {
            mkdir("users", 0777, true);
        }
        chdir ("users");
        if ($img != "")
        {
            if (!file_exists($id))
            {
                mkdir($id . "/pic", 0777, true);
            }
            $path = $id . "/pic/" . basename($img);
            move_uploaded_file($tmp, $path);
            $stmt = $conn->prepare("UPDATE user SET path='$path' WHERE id=$id;"); // Preparo una consulta para Actualizar la tabla.
            $stmt->execute(); // La Ejecuto.
        }
    }
    else
    {
        echo "<script>toast(2, 'ERROR del Servidor', 'Error al Enviar el Mensaje si Vuelves a Intentarlo y da Error Nuevamente, por Favor Escribe a <a href=\"mailto:matelat@gmail.com\">matelat@gmail.com</a>');</script>";
    }
    echo "<script>toast(0, 'Activa tu Cuenta', 'Ya Estás Dado de Alta, Consulta tu E-mail para Confirmar tu Inscripción.');</script>";
}
else
{
    $title = "Usuario ya Registrado";
    include "includes/header.php";
    include "includes/modal_index.html";
    echo "<script>toast(1, 'Datos Ya Registrados', 'Tus Datos ya Están Registrados en este Sitio, Por Favor Accede con tus Credenciales. Si has Olvidado la Contraseña Puedes Recuperarla Desde la Página de Login.');</script>";
}
?>