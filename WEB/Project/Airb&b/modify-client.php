<?php
include "includes/conn.php";
$title = "Modificando los datos del Usuario";
include "includes/header.php";
include "includes/modal-index.html";

if (isset($_POST["username"])) // Si llegan datos por post.
{
    $ok = true; // Uso la variable $ok para verificar que no se repita el DNI ni el E-mail.
    $name = $_POST["username"]; // Asigno a variables lo recibido por post.
    $surname1 = $_POST["surname"];
    $surname2 = $_POST["surname2"];
    if ($surname2 == "")
    {
        $surname2 = null;
    }
    $dni = $_POST["dni"];
    $phone = $_POST["phone"];
    $email = $_POST["email"];
    $pass = $_POST["pass"];
    $bday = $_POST["bday"];
    $gender = $_POST["gender"];
    $path = $_POST["path"];
    $img = $_FILES["profile"]["name"];
    $tmp = $_FILES["profile"]["tmp_name"];

    $sql = "SELECT client_dni, client_email, client_phone FROM client;"; // Preparo la consulta de la ID, Teléfono y E-mail de toda la tabla clients.
    $stmt = $conn->prepare($sql);
    $stmt->execute();
    while($row = $stmt->fetch(PDO::FETCH_OBJ)) // Mientras reciba datos al asignar a la variable $row el resultado asociado a $stmt.
    {
        if ($dni != $row->client_dni)
        {
            if ($row->client_dni == $dni || $row->client_email == $email || $row->client_phone == $phone) // Si el dni, el email o el teléfono enviados por post están en la tabla.
            {
                $ok = false; // $ok es false.
            }
        }
    }
    if ($ok) // Si $ok está a true, no hubo coincidencias.
    {
        if ($img != "")
        {
            chdir("client");
            if (!file_exists($dni))
            {
                mkdir($dni . "/pic", 0777, true);
            }
            $path = $dni . "/pic/" . basename($img);
            move_uploaded_file($tmp, $path);
            if ($pass != "")
            {
                $hash = password_hash($pass, PASSWORD_DEFAULT);
                $sql = "UPDATE client SET client_dni='$dni', client_name='$name', client_surname='$surname1', client_surname2='$surname2', client_phone='$phone', client_email='$email', client_pass='$hash', client_bday='$bday', client_gender='$gender', client_path='client/$path' WHERE client_dni='$dni';"; // Preparo la Consulta Modificando Todo.
            }
            else
            {
                $sql = "UPDATE client SET client_dni='$dni', client_name='$name', client_surname='$surname1', client_surname2='$surname2', client_phone='$phone', client_email='$email', client_pass='$hash', client_bday='$bday', client_gender='$gender', client_path='client/$path' WHERE client_dni='$dni';"; // Preparo la Consulta Modificando Todo.
            }
        }
        else
        {
            if ($pass != "")
            {
                $hash = password_hash($pass, PASSWORD_DEFAULT);
                $sql = "UPDATE client SET client_dni='$dni', client_name='$name', client_surname='$surname1', client_surname2='$surname2', client_phone='$phone', client_email='$email', client_pass='$hash', client_bday='$bday', client_gender='$gender', client_path='$path' WHERE client_dni='$dni';"; // Preparo la Consulta Modificando Todo.
            }
            else
            {
                $sql = "UPDATE client SET client_dni='$dni', client_name='$name', client_surname='$surname1', client_surname2='$surname2', client_phone='$phone', client_email='$email', client_bday='$bday', client_gender='$gender', client_path='$path' WHERE client_dni='$dni';"; // Preparo la Consulta Modificando todo Excepto la Contraseña.
            }
        }

        $stmt = $conn->prepare($sql);
        $stmt->execute();
        if ($stmt->rowCount() > 0) // Ejecuto la consulta y compruebo si se modifico el campo.
        {
            session_destroy();
            echo "<script>toast(0, 'Todo ha ido Bien', 'Se han Modificado tus Datos $name, Vuelve a Iniciar Sesión con tus Nuevos Datos.');</script>";
            // Muestro el aviso que todo ha ido bien.
        }
        else // Si hubo algún error.
        {
            echo "<script>toast(1, 'Algo Ha Fallado', 'No se Han Podido Modificar tus Datos $name.');</script>";
            // Muestro el error de mysql, algo ha fallado
        }
    }
    else
    {
        echo "<script>toast(1, 'Ya Registrado:', 'El E-mail $email, el Teléfono $phone o el D.N.I. $dni, ya Están Registrados en Este Sitio. No puedes usar esos datos.');</script>"; // Muestro el error, el E-mail, etc. ya están registrados.
    }
}
?>