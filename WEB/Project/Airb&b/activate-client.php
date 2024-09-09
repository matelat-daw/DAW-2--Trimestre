<?php // Este script activa el perfil del usuario que se registró en el sitio, llega el enlace por E-mail.
include "includes/conn.php";
$title = "Activando Perfil de Propietario";
include "includes/header.php";
include "includes/modal-active.html";

if (isset($_GET["hash"]))
{
    $hash = $_GET["hash"];
    $id = $_GET["id"];

    $stmt = $conn->prepare("SELECT * FROM client WHERE client_dni='$id';");
    $stmt->execute();
    if ($stmt->rowCount() > 0)
    {
        $row = $stmt->fetch(PDO::FETCH_OBJ);
        if ($row->client_hash == $hash)
        {		
            $stmt = $conn->prepare("UPDATE client SET client_hash=NULL, client_active=1 WHERE client_dni='$id';");
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