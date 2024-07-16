<?php
include "includes/conn.php"; // Incluye la Conexión con la Base de Datos.

$activate = $_SERVER["REQUEST_URI"]; // Asigna a $activate la URL Completa.
$urlArray = explode('/', $activate); // hace un explode de la URL en el Array $urlArray.
$hash = $urlArray[4]; // La URL es: localhost/Programación/PHP/Ejercicio-2/activate.php/#hash/ID - Por eso se toman los valores 5 y 6 del Array el hash es el Índice 5.
$id = $urlArray[5]; // La ID es el Índice 6.

$stmt = $conn->prepare("SELECT * FROM business WHERE id=$id;"); // Compruebo si la ID que Llego por la URL Está Registrada en la Base de Datos.
$stmt->execute();
if ($stmt->rowCount() > 0) // Si Está.
{
    $row = $stmt->fetch(PDO::FETCH_OBJ);
    if ($row->hash == $hash) // Verifico que el Hash esté en la Base de Datos.
    {		
        $stmt = $conn->prepare("UPDATE business SET hash=NULL, active=true WHERE id=$id;"); // Sentencia para Actualizar los Datos.
        $stmt->execute();
        echo '<script>if (!alert("Gracias por Activar tu Cuenta.\nYa puedes Loguearte y Empezar a Usar el Sitio.")) window.close("_self");</script>';
    }
    else // Si No Está.
    {
        echo '<script>if (!alert("Por Favor Entra con tu E-mail y Contraseña y Descarta el E-mail de Confirmación. Tu Cuenta ya está Activada.")) window.close("_self");</script>'; // Aviso que te Loguees con tu Datos y Borres el E-mail de Activación, La Cuenta ya está Activada o No Existe.
    }
}
?>