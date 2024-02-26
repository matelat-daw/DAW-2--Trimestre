<?php // Documento de script php
include "includes/conn.php";
if (isset($_POST['email'])) // Si recibe datos por POST en la variable array $_POST["email"].
{
    $ok = false;
	$email = $_POST['email']; // Asigna a la variable $user el contenido del array $_POST["email"].
	$pass = $_POST['pass']; // Lo mismo con $_POST["pass"].
    $sql = "SELECT * FROM user WHERE email='$email';";
    $stmt = $conn->prepare($sql);
    $stmt->execute();
    if ($stmt->rowCount() > 0)
    {
        $row = $stmt->fetch(PDO::FETCH_OBJ);
        if (password_verify($pass, $row->pass))
        {
            $ok = true;
        }
    }
}
$title = "Bienvenido " . $email;
include "includes/header.php";
include "includes/modal-index.html";
?>
<section class="container-fluid pt-3">
    <div class="row">
        <div class="col-md-1"></div>
            <div class="col-md-10">
                <div id="view1">
                    <br><br><br><br>
                    <?php
                    if ($ok)
                    {
                        $_SESSION["id"] = $email;
                        echo "<script>toast(0, 'LogIn Correcto', 'Bienvendo " . $email . " Haz Click en los botones de Cerrar para Volver al Inicio.');</script>";
                    }
                    else
                    {
                        echo '<script>toast(2, "DATOS INCORRECTOS", "Las Credenciales Introducidas no Corresponden a Ningún Usuario Registrado o Validado.<br>Haz Activado tu Registro?. Verifica el E-mail que te Enviamos, Puede Estar en la Carpeta de Correo no Deseado.<br>Verifica los datos y Vuelve a Intentar el Login.");</script>';
                    }
                    ?>
                </div>
            </div>
        <div class="col-md-1"></div>
    </div>
</section>