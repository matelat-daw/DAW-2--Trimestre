<?php
include "includes/conn.php";

$activate = $_SERVER["REQUEST_URI"];
$urlArray = explode('/', $activate);
$hash = $urlArray[3];
$dni = $urlArray[4];

$stmt = $conn->prepare("SELECT * FROM user WHERE dni='$dni';");
$stmt->execute();
if ($stmt->rowCount() > 0)
{
    $row = $stmt->fetch(PDO::FETCH_OBJ);
    if ($row->hash == $hash)
    {		
        $stmt = $conn->prepare("UPDATE user SET hash=NULL, active=true WHERE dni='$dni';");
        $stmt->execute();
        echo '<script>if (!alert("Gracias por Activar tu Cuenta.\nYa puedes Loguearte y Empezar a Usar el Sitio.")) window.close("_self");</script>';
    }
    else
    {
        echo '<script>if (!alert("Por Favor Entra con tu E-mail y Contraseña y Descarta el E-mail de Confirmación.")) window.close("_self");</script>';
    }
}
?>