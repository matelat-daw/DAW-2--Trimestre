<?php
include "includes/conn.php";
$title = "Activando el Perfil";
include "includes/header.php";
include "includes/modal-index.html";

$activate = $_SERVER["REQUEST_URI"];
$urlArray = explode('/', $activate);
$hash = $urlArray[4];
$id = $urlArray[5];

$stmt = $conn->prepare("SELECT * FROM user WHERE id=$id;");
$stmt->execute();
if ($stmt->rowCount() > 0)
{
    $row = $stmt->fetch(PDO::FETCH_OBJ);
    if ($row->hash == $hash)
    {		
        $stmt = $conn->prepare("UPDATE user SET hash=NULL, active=1 WHERE id=$id;");
        $stmt->execute();
        echo '<script>toast(0, "Perfil Activado:", "Gracias por Activar tu Cuenta.\nYa puedes Loguearte y Empezar a Usar el Sitio.")) window.close("_self");</script>';
    }
    else
    {
        echo '<script>toast(1, "Perfil Ya Activado:", "Tu Perfil ya está Activado. Por Favor Entra con tu E-mail y Contraseña y Elimina el E-mail de Confirmación.")) window.close("_self");</script>';
    }
}
?>