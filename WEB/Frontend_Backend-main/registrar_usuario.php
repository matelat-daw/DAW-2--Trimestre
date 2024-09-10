<?php
    include "includes/head.php";
    include "includes/modal-registro.html";
    session_start();
?>

<?php
if (isset($_POST["registrar"])) { // esperando al botón
    $nombre = htmlspecialchars($_POST['nombre']);
    $apellido1 = htmlspecialchars($_POST['apellido1']);
    $apellido2 = htmlspecialchars($_POST['apellido2']);
    if ($apellido2 == "") // Si $apellido2 está vacio.
    {
        $surname2 = NULL; // $apellido2 es NULL.
    }
    $telefono = htmlspecialchars($_POST['telefono']);
    $email = htmlspecialchars($_POST['email']);
    $pass = htmlspecialchars($_POST['pass']);
    $encrypted = password_hash($pass, PASSWORD_DEFAULT); // Encripto la contraseña en $pass con la función password_hash de PHP y la asigno a la variable $encrypted.
    $fecha = htmlspecialchars($_POST['fecha']);
    $path = ""; // Asigno a la variable $path texto vacio.
    $img = htmlspecialchars($_FILES["profile"]["name"]); // Asigno a la variable $img la imagen que llega por POST.
    $tmp = htmlspecialchars($_FILES["profile"]["tmp_name"]); // Asigno a la variable tmp la ruta temporal del archivo enviado por POST.

    // Conecta con la BD
    include'includes/conexion.php';

    // sql para insertar un registro
    $sql = "INSERT INTO `vendedor` VALUES (null,'$nombre','$apellido1','$apellido2','$telefono','$email','$pass', '$fecha', '$path');";
    echo $sql;
    if (mysqli_query($conexion, $sql)) {

        if ($img != "") // Si se sube una imagen, $img será distinto de texto vacio.
        {
            if (!is_dir("alumno/" . $email . "/pic")) // Si no existe la carpeta alumno + ID del alumno + pic.
            {
                mkdir("alumno/" . $email . "/pic", 0777, true); // La creo con permiso de acceso total.
            }
            $path = "alumno/" . $email . "/pic/" . basename($img); // Asigno a $path la ruta a la imagen del alumno.
            move_uploaded_file($tmp, $path); // Mueve la imagen de la carpeta temporal($tmp), a la ruta $path, con el nombre original de la imagen.
        }
        else // Si no, no se sube una imagen
        {
            $path = "img/male.jpg"; // Imagen de mujer.
        }
        $id = mysqli_insert_id($conexion);
        $sql = "UPDATE vendedor SET path='$path' WHERE id=$id;";

        if (mysqli_query($conexion, $sql)) {
            mysqli_close($conexion);
        }
        echo '<script>
            toast(0, "Registro Usuario", "Muchacho");
        </script>';
    }
    else
    {
        echo "Error inténtelo más tarde: " . mysqli_error($conexion);
        session_destroy();
        mysqli_close($conexion);
    }
}
?>