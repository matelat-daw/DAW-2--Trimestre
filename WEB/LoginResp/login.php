<?php // Script de entrada de usuario, muestra el E-mail con la foto y el botón para eliminar el perfil.
include "includes/conn.php";

if (isset($_POST['email'])) // Si recibe datos por POST en la variable array $_POST["email"].
{
	$email = $_POST['email']; // Asigna a la variable $user el contenido del array $_POST["email"].
	$pass = $_POST['pass']; // Lo mismo con $_POST["pass"].
    $sql = "SELECT active FROM user WHERE email='$email';";
    $stmt = $conn->prepare($sql);
    $stmt->execute();
    if ($stmt->rowCount() > 0)
    {
        $row = $stmt->fetch(PDO::FETCH_OBJ);
        if ($row->active)
        {
            $sql = "SELECT * FROM user WHERE email='$email';";
            $stmt = $conn->prepare($sql);
            $stmt->execute();
            if ($stmt->rowCount() > 0)
            {
                $row = $stmt->fetch(PDO::FETCH_OBJ);
                if (password_verify($pass, $row->pass))
                {
                    $_SESSION["id"] = $row->id;
                }
            }
        }
    }
}
if (isset($_SESSION["id"]))
{
    include "functions/getProfile.php";
    $title = "Bienvenido " . $row->name;
    include "includes/header.php";
    include "includes/modal.html";
    include "includes/nav-user.php";
echo '<section class="container-fluid pt-3">
    <div class="row">
        <div class="col-md-1"></div>
            <div class="col-md-10">
                <div id="view1">
                    <br><br><br><br><br><br>
                    <div class="medium great">
                        <div id="modify">';
                            include "includes/change.php";
                        echo '</div>
                            <div id="quit">';
                                include "includes/delete.php";
                            echo '</div></div>
                    <div class="mini">
                        <div id="modify">';
                            include "includes/change.php";
                        echo '</div>
                        <div id="quit">';
                            include "includes/delete.php";
                    echo '</div></div>
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