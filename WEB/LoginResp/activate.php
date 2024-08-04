<?php // Este script activa el perfil del usuario que se registró en el sitio, llega el enlace por E-mail y le pasa por GET el hash y la ID del usuario.
include "includes/conn.php";
$title = "Activando Perfil";
include "includes/header.php";
include "includes/modal-active.html";

if (isset($_GET["hash"]))
{
    $hash = $_GET["hash"];
    $id = $_GET["id"];

    $stmt = $conn->prepare("SELECT * FROM user WHERE id=$id;"); // Selecciona todos los datos del Usuario.
    $stmt->execute();
    if ($stmt->rowCount() > 0) // Si Existe la ID.
    {
        $row = $stmt->fetch(PDO::FETCH_OBJ); // Asigna a $row todos los datos del Usuario.
        if ($row->hash == $hash) // Si el Hash que llego por GET es igual al que está en la base de datos.
        {		
            $stmt = $conn->prepare("UPDATE user SET hash=NULL, active=1 WHERE id=$id;"); // Actualiza el campo active poniendoló a 1 y pone hash a null.
            $stmt->execute();
            echo '<script>toast(0, "Perfil Activado:", "Gracias por Activar tu Cuenta.<br>Ya Puedes Loguearte y Empezar a Usar el Sitio.");</script>';
        }
        else
        {
            echo '<script>toast(1, "Perfil Ya Activado:", "Ya Habías Activado tu Perfil. Por Favor Entra con tu E-mail y Contraseña y Elimina el E-mail de Confirmación.");</script>';
        }
    }
    else
    {
        echo '<script>toast(2, "ERROR:", "No Hay Ningúin Usuario con Esos Datos, Posiblemente Hayas Eliminado tu Perfil.");</script>';
    }
}
?>