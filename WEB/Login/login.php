<?php // Documento de script php
include "includes/conn.php";

if (isset($_POST['email'])) // Si recibe datos por POST en la variable array $_POST["email"].
{
    $ok = false;
    $id = "";
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
                    $ok = true;
                    $id = $row->id;
                    $_SESSION["id"] = $id;
                    $path = $row->path;
                }
            }
        }
    }
}
if (isset($_SESSION["id"]) || $ok)
{
    include "functions/getProfile.php";
    $title = "Bienvenido " . $row->email;
    include "includes/header.php";

echo '<section class="container-fluid pt-3">
    <div class="row">
        <div class="col-md-1"></div>
            <div class="col-md-10">
                <div id="view1">
                    <br><br><br><br>
                    <h3>Bienvenido Usuario ' . $row->email . '</h3>
                    <img alt="Foto de Perfil" src="' . $row->path . '" width="160" heigth="120">
                    <br><br>
                    <button onclick="remove(' . $row->id . ')" class="btn btn-danger btn-lg">Elimino mi Perfil</button>
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