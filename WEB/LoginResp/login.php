<?php // Script de entrada de usuario, muestra el E-mail con la foto y el botón para eliminar el perfil.
include "includes/conn.php";

if (isset($_POST['email'])) // Si recibe datos por POST en la variable array $_POST["email"].
{
	$email = $_POST['email']; // Asigna a la variable $email el contenido del array $_POST["email"].
	$pass = $_POST['pass']; // Lo mismo con $_POST["pass"].
    $sql = "SELECT active FROM user WHERE email='$email';"; // Comprueba que el perfil esté activado.
    $stmt = $conn->prepare($sql);
    $stmt->execute();
    if ($stmt->rowCount() > 0)
    {
        $row = $stmt->fetch(PDO::FETCH_OBJ);
        if ($row->active) // Si el perfil está ativado
        {
            $sql = "SELECT * FROM user WHERE email='$email';"; // Obtiene todos los datos del usuario.
            $stmt = $conn->prepare($sql);
            $stmt->execute();
            if ($stmt->rowCount() > 0)
            {
                $row = $stmt->fetch(PDO::FETCH_OBJ);
                if (password_verify($pass, $row->pass)) // Comprueba si la Contraseña es correcta.
                {
                    $_SESSION["id"] = $row->id; // Si las Credenciales son correctas, inicia la sesión con $_SESSION["id"].
                }
            }
        }
    }
}
if (isset($_SESSION["id"])) // Si la sesión está iniciada, Muestra el perfil del usuario para Modificar o Eliminar.
{
    include "functions/getProfile.php"; // Incluye la función getProfile.php que obtiene en la variable $row todos los datos del usuario de la base de datos.
    $title = "Bienvenido " . $row->name;
    include "includes/header.php";
    include "includes/modal.html";
    include "includes/nav-pc-user.php";
    include "includes/nav-mob-user.php";
echo '<section class="container-fluid pt-3">
    <div class="row">
        <div class="col-md-1"></div>
            <div class="col-md-10">
                <div id="view1">
                    <br><br><br><br>
                    <div class="medium great">
                        <div id="modify">'; // Contenedor del script para modificar el perfil del usuario, el contenedor anterior es de la clase medium y great, PC y Tablet.
                            include "includes/change.php";
                        echo '</div>
                            <div id="quit">'; // Contenedor del script para Eliminar el perfil del usuario, es invisible al abrir la página.
                                include "includes/delete.php";
                            echo '</div></div>
                    <div class="mini">
                        <div id="modify">'; // Contenedor del script para modificar el perfil del usuario, el contenedor anterior es de la clase mini, Móvil.
                            include "includes/change.php";
                        echo '</div>
                        <div id="quit">'; // Contenedor del script para Eliminar el perfil del usuario, en esta resolución ambos formulario están visibles uno a continuación del otro.
                            include "includes/delete.php";
                    echo '</div></div>
                </div>
            </div>
        <div class="col-md-1"></div>
    </div>
</section><br><br>';
}
else // Si No está Iniciada la Sesión, Muestra un mensaje de error y vuelve a index.php.
{
    $title = "Nadie con ese E-mail";
    include "includes/header.php";
    include "includes/modal-index.html";
    echo '<script>toast(2, "DATOS INCORRECTOS", "Las Credenciales Introducidas no Corresponden a Ningún Usuario Registrado o Validado.<br>Haz Activado tu Registro?. Verifica el E-mail que te Enviamos, Puede Estar en la Carpeta de Correo no Deseado.<br>Verifica los datos y Vuelve a Intentar el Login.");</script>';
}
include "includes/footer.html";
?>