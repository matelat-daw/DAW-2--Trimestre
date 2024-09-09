<?php // Script de entrada de Cliente, muestra el E-mail con la foto y el botón para eliminar el perfil.
include "includes/conn.php";

if (isset($_POST['email'])) // Si recibe datos por POST en la variable array $_POST["email"].
{
	$email = $_POST['email']; // Asigna a la variable $user el contenido del array $_POST["email"].
	$pass = $_POST['pass']; // Lo mismo con $_POST["pass"].
    $sql = "SELECT client_active FROM client WHERE client_email='$email';";
    $stmt = $conn->prepare($sql);
    $stmt->execute();
    if ($stmt->rowCount() > 0)
    {
        $row = $stmt->fetch(PDO::FETCH_OBJ);
        if ($row->client_active)
        {
            $sql = "SELECT * FROM client WHERE client_email='$email';";
            $stmt = $conn->prepare($sql);
            $stmt->execute();
            if ($stmt->rowCount() > 0)
            {
                $row = $stmt->fetch(PDO::FETCH_OBJ);
                if (password_verify($pass, $row->client_pass))
                {
                    $_SESSION["id"] = $row->client_dni;
                }
            }
        }
    }
}
if (isset($_SESSION["id"]))
{
    include "functions/getClientProfile.php";
    $title = "Bienvenido " . $row->client_name;
    include "includes/header.php";
    include "includes/modal.html";
    include "includes/nav-client.php";
echo '<section class="container-fluid pt-3">
    <div class="row">
        <div class="col-md-1"></div>
            <div class="col-md-10">
                <div id="view1">
                <br><br><br><br><br><br>
                <div id="modify_client">';
                        include "includes/change-client.php";
                echo '</div>
                    <div id="quit_client">';
                            include "includes/delete-client.php";
                    echo '</div>
                </div>
            </div>
        <div class="col-md-1"></div>
    </div>
</section>';
}
else
{
    $title = "Nadie con ese E-mail";
    include "includes/header.php";
    include "includes/modal-index.html";
    echo '<script>toast(2, "DATOS INCORRECTOS", "Las Credenciales Introducidas no Corresponden a Ningún Usuario Registrado o Validado.<br>Haz Activado tu Registro?. Verifica el E-mail que te Enviamos, Puede Estar en la Carpeta de Correo no Deseado.<br>Verifica los datos y Vuelve a Intentar el Login.");</script>';
}
include "includes/footer.html";
?>