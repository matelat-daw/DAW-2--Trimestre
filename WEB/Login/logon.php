<?php // Script de registro de usuario con confirmación por E-mail.
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
        $path = "imgs/female.jpg";
    }
    else
    {
        $path = "imgs/male.jpg";
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
    include "includes/modal-index.html";

    $sql = "INSERT INTO user VALUES(:id, :name, :surname, :surname2, :dni, :phone, :email, :pass, :bday, :gender, :path, :hash, :active)";
    $stmt = $conn->prepare($sql);
    $stmt->execute(array(':id' => NULL, ':name' => $user, ':surname' => $surname1, ':surname2' => $surname2, ':dni' => $dni, ':phone' => $phone, ':email' => $email, ':pass' => $encrypted, ':bday' => $bday, ':gender' => $gender, ':path' => $path, ':hash' => $hash, ':active' => 0));
    $id = $conn->lastInsertId(); // Asigno a la variable $id la última id guardada en la tabla.

    $subject = "Por Favor Contactame en Esta Dirección";
    $message = "<h3>Gracias por registrarte</h3><p>Por Favor haz Click en el Botón Activar mi Cuenta para Empezar a Usar el Sitio.</p><a href='http://" . $_SERVER['SERVER_NAME'] . "/web/Login/activate.php?hash=" . $hash . "&id=" . $id . "'><div style='background-color:aquamarine; border:thin; width:120px; height:60px; text-align:center;'>Quiero Activar mi Cuenta</div></a><br><br><small>Copyright © 2024 César Matelat <a href='mailto:matelat@gmail.com'>matelat@gmail.com</a></small>";
    $server_email = "matelat@gmail.com";
    $headers  = "From: $server_email\r\n";
    $headers .= "MIME-Version: 1.0\r\n";
    $headers .= "Content-type: text/html; charset=UTF-8\r\n";

    if(mail($email, $subject, $message, $headers))
    {
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
            $stmt = $conn->prepare("UPDATE user SET path='users/$path' WHERE id=$id;"); // Preparo una consulta para Actualizar la tabla.
            $stmt->execute(); // La Ejecuto.
        }
    }
    else
    {
        echo "<script>toast(2, 'ERROR:', 'Error al Enviar el Mensaje si Vuelves a Intentarlo y Sigue Dando Error, por Favor Escribe a matelat@gmail.com.');</script>";
    }
    echo "<script>toast(0, 'Ya Estás Dado de Alta', 'Consulta la Bandeja de Entrada de la Dirección Correo Electrónico que Usaste para Registrarte para confirmar tu Inscripción. Ten en Cuenta que el Mensaje Podría Estar en la Bandeja de Spam o Correo no Deseado.');</script>";
    include "includes/footer.html";
}
else
{
    $title = "Datos Ya Registrados";
    include "includes/header.php";
    include "includes/modal-index.html";
    echo "<script>toast(1, 'Ya Registrado', 'Tus Datos ya Están Registrados en este Sitio, Por Favor Accede con tus Credenciales Desde el Formulario de Login. Si has Olvidado la Contraseña Puedes Recuperarla Desde el Enlace Olvidé mi Contraseña en el Formulario de Login.');</script>";
}
?>