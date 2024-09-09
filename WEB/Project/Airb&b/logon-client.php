<?php // Script de registro de Cliente con confirmación por E-mail.
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
    $sql = "SELECT client_dni, client_phone, client_email FROM client WHERE client_phone='$phone' OR client_email='$email' OR client_dni='$dni'";
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
    $title = "Registro de Cliente";
    include "includes/header.php";
    include "includes/modal-index.html";

    $sql = "INSERT INTO client VALUES(:client_dni, :client_name, :client_surname, :client_surname2, :client_phone, :client_email, :client_pass, :client_bday, :client_gender, :client_path, :client_hash, :client_active)";
    $stmt = $conn->prepare($sql);
    $stmt->execute(array(':client_dni' => $dni, ':client_name' => $user, ':client_surname' => $surname1, ':client_surname2' => $surname2, ':client_phone' => $phone, ':client_email' => $email, ':client_pass' => $encrypted, ':client_bday' => $bday, ':client_gender' => $gender, ':client_path' => $path, ':client_hash' => $hash, ':client_active' => 0));

    $subject = "Por Favor Contactame en Esta Dirección";
    $message = "<h3>Gracias por registrarte</h3><p>Por Favor haz Click en el Botón Activar mi Cuenta para Empezar a Usar el Sitio.</p><a href='http://" . $_SERVER['SERVER_NAME'] . "/web/Project/Airb&b/activate-client.php?hash=" . $hash . "&id=" . $dni . "'><div style='background-color:aquamarine; border:thin; width:120px; height:60px; text-align:center;'>Quiero Activar mi Cuenta</div></a><br><br><small>Copyright © 2024 César Matelat <a href='mailto:matelat@gmail.com'>matelat@gmail.com</a></small>";
    $server_email = "matelat@gmail.com";
    $headers  = "From: $server_email\r\n";
    $headers .= "MIME-Version: 1.0\r\n";
    $headers .= "Content-type: text/html; charset=UTF-8\r\n";

    if(mail($email, $subject, $message, $headers))
    {
        if (!file_exists("client"))
        {
            mkdir("client", 0777, true);
        }
        chdir ("client");
        if ($img != "")
        {
            if (!file_exists($dni))
            {
                mkdir($dni . "/pic", 0777, true);
            }
            $path = $dni . "/pic/" . basename($img);
            move_uploaded_file($tmp, $path);
            $stmt = $conn->prepare("UPDATE client SET client_path='client/$path' WHERE client_dni='$dni';"); // Preparo una consulta para Actualizar la tabla.
            $stmt->execute(); // La Ejecuto.
        }
    }
    else
    {
        echo "<script>toast(2, 'ERROR:', 'Error al Enviar el Mensaje si Vuelves a Intentarlo y Sigue Dando Error, por Favor Escribe a matelat@gmail.com.');</script>";
    }
    echo "<script>toast(0, 'Ya Estás Dado de Alta', 'Consulta la Bandeja de Entrada de la Dirección de Correo Electrónico que Usaste para Registrarte para confirmar tu Inscripción. Ten en Cuenta que el Mensaje Podría Estar en la Bandeja de Spam o Correo no Deseado.');</script>";
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