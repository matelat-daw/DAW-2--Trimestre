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
    include "includes/nav-user.php";

echo '<section class="container-fluid pt-3">
    <div class="row">
        <div class="col-md-1"></div>
            <div class="col-md-10">
                <div id="view1">
                    <br><br><br><br><br>
                    <div class="row">
                    <div class="col-md-7">
                    <h3>Aquí Puedes Modificar Tus Datos</h3>
                    <form action="modify.php" method="post" enctype="multipart/form-data" onsubmit="return verify()>
                    <input type="hidden" name="id" value="' . $_SESSION["id"] . '">
                    <label><input type="text" name="username" value=' . $row->name . ' required> Nombre</label>
                    <br><br>
                    <label><input type="text" name="surname" value=' . $row->surname . ' required> Primer Apellido</label>
                    <br><br>
                    <label><input type="text" name="surname2" value=' . $row->surname2 . '> Segundo Apellido</label>
                    <br><br>
                    <label><input id="dni" type="text" name="dni" value=' . $row->dni . ' required> D.N.I.</label>
                    <br><br>
                    <label><input type="text" name="phone" value=' . $row->phone . ' required> Teléfono</label>
                    <br><br>
                    <label><input type="email" name="email" value=' . $row->email . ' required> E-mail</label>
                    <br><br>
                    <label><input type="password" name="pass" id="pass1" onkeypress="showEye(1)" required> Contraseña</label>
                    <i onclick="spy(1)" class="far fa-eye" id="togglePassword1" style="margin-left: -140px; cursor: pointer; visibility: hidden;"></i>
                    <br><br>
                    <label><input type="password" id="pass2" onkeypress="showEye(2)" required> Repite Contraseña</label>
                    <i onclick="spy(2)" class="far fa-eye" id="togglePassword2" style="margin-left: -205px; cursor: pointer; visibility: hidden;"></i>
                    <br><br>
                    <label><input type="date" name="bday" value=' . $row->bday . ' required> Cumpleaños</label>
                    <br><br>';
                    if ($row->gender == 0)
                    {
                        echo '<label><input type="radio" name="gender" value="0" checked> Mujer</label>
                        <br><br>
                        <label><input type="radio" name="gender" value="1"> Varón</label>
                        <br><br>';
                    }
                    else
                    {
                        echo '<label><input type="radio" name="gender" value="0"> Mujer</label>
                        <br><br>
                        <label><input type="radio" name="gender" value="1" checked> Varón</label>
                        <br><br>';
                    }
                    echo '<label><input type="file" name="profile" class="btn btn-secondary btn-lg"> Foto de Perfil<small>(opcional)</small></label>
                    <br><br>
                    <input type="submit" value="Modifico Mis Datos" class="btn btn-info btn-lg">
                </form>
                </div>
                <div class="col-md-5">
                <h3>Aquí Puedes Eliminar Tu Perfil</h3>
                <form action="delete.php" method="post">
                    <input type="hidden" name="id" value="' . $_SESSION["id"] . '">
                    <input type="submit" class="btn btn-danger btn-lg" value="Elimino mi Perfil">
                </form>
                </div>
                </div>
                </div>
            </div>
        <div class="col-md-1"></div>
    </div>
</section><br><br><br><br>';

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