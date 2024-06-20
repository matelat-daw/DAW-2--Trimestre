<?php
include "includes/conn.php";
$title = "Sitio - Recupera tu Contraseña";
include "includes/header.php";
include "includes/modal_index.html";

if (isset($_POST["email"]))
{
    $email = htmlspecialchars($_POST["email"]);
    $hash = substr(md5(uniqid($email, true)), 8, 8);
    $pass = password_hash($hash, PASSWORD_DEFAULT);
    $ok = false;
    $sql = "SELECT email FROM user;"; // Preparo una consulta de todos los E-mail de espectadores de la base de datos.
    $stmt = $conn->prepare($sql);
    $stmt->execute();
    while($row = $stmt->fetch(PDO::FETCH_OBJ)) // Asigno a la variable $row el contenido de la consulta.
    {
        if ($row->email == $email) // Si el E-mail está en la base de datos.
        {
            $ok = true; // $ok es true.
            break; // Rompo el bucle, si se encuentra el E-mail en los primeros resultados no hace falta seguir buscando, el E-mail es clave unica.
        }
    }
    if (!$ok) // Si $ok es false.
    {
        echo "<script>toast(2, 'Hay un Error', 'Lo Siento no Existe Ningún Cliente con E-mail: $email, Vuelve a Intentarlo con la Dirección con la que te Registrate.');</script>"; // Error.
    }
    else // Si el E-mail está en la base de datos.
    {
        $sql = "UPDATE user SET pass='$pass' WHERE email='$email'"; // Hago un update de la contraseña de ese E-mail.
        $stmt = $conn->prepare($sql);
        $stmt->execute();
        echo "<script>toast(0, 'Todo ha Ido Bien', 'Se ha Cambiado tu Contraseña a: $hash, Selecciónala, Cópiala y Pegala en un Texto, Después Vuelve a Iniciar Sesión con los Nuevos Datos. Te Recomendamos que Cambies la Contraseña, Gracias por Ser Parte de la WEB de Referidos.');</script>";
    }
}
?>
<section class="container-fluid pt-3">
    <div class="row">
        <div class="col-md-1"></div>
            <div class="col-md-10">
                <div id="view1">
                    <?php
                        include "includes/recover.php";
                    ?>
                </div>
            </div>
        <div class="col-md-1"></div>
    </div>
</section>
<?php
include "includes/footer.html";
?>