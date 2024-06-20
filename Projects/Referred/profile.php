<?php
include "includes/conn.php";
$title = "La WEB de Referidos - Perfil de Usuario";
include "includes/header.php";
$noActive = false;

if (isset($_POST['email'])) // Si recibe datos por POST en la variable array $_POST["email"].
{
    include "includes/modal_index.html";
    $ok = false;
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
            $active = true;
            $sql = "SELECT * FROM user WHERE email='$email';";
            $stmt = $conn->prepare($sql);
            $stmt->execute();
            if ($stmt->rowCount() > 0)
            {
                $row = $stmt->fetch(PDO::FETCH_OBJ);
                if (password_verify($pass, $row->pass))
                {
                    $_SESSION["user"] = $row->id; // Asigno a la variable de sesión user la id del cliente.
                    $_SESSION["name"] = $row->name; // Asigno a la variable de sesión name el nombre del cliente.
                    $path = $row->path;
                }
                else
                {
                    echo "<script>toast(1, 'Ha Habido un Error', 'Has Llegado Aquí por Error.');</script>"; // Error, has llegado por el camino equivocado.
                }
            }
        }
        else
        {
            $noActive = true;
            echo "<script>toast(1, 'Cuenta NO Activada', 'Aun no Has Activado tu Cuenta. Revisa tu Correo Electrónico, Puede que el Mensaje Esté en la Carpeta de Correos no Deseados o Spam, Debes Hacer Click en el Botón Activo mi Cuenta del E-mail que te Enviamos para Poder Usar el Sitio. Gracias.');</script>"; // No hay Registros.
        }
    }
}

if (isset($_SESSION["user"])) // Verifico si la sesión no está vacia.
{
    include "includes/modal.html";
    $ok = false; // Booleano para verificar si los datos son correctos.
    $id = $_SESSION["user"]; // Asigno a la variable $id el valor de la sesión client.
    $sql = "SELECT * FROM user WHERE id=$id;"; // Preparo una consulta por la ID.
    $stmt = $conn->prepare($sql);
    $stmt->execute();
    $row = $stmt->fetch(PDO::FETCH_OBJ); // Asigno el resultado a la variable $row.
    $name = $row->name; // Asigno el contenido de $row a variables.
    $surname1 = $row->surname1;
    $surname2 = $row->surname2;
    $phone = $row->phone;
    $email = $row->email;
    $bday = $row->bday;
    $b_day = strtotime($bday);
    $bday = date("Y-m-d", $b_day);
?>
<section class="container-fluid pt-3">
    <div class="row">
        <div class="col-md-1"></div>
            <div class="col-md-10">
                <div id="view1">
                    <?php
                        include "includes/nav_profile.php";
                    ?>
                    <br><br><br>
                    <div id="modify">
                        <?php
                            include "includes/modify.php";
                        ?>
                    </div>
                    <div id="delete">
                        <?php
                            include "includes/delete.php";
                        ?>
                    </div>
                </div>
            </div>
        <div class="col-md-1"></div>
    </div>
</section>
<?php
}
else
{
    if (!$noActive) // Entro en la página sin Estar Logueado ni Através del Formulario.
    {
        include "includes/modal_index.html";
        echo "<script>toast(1, 'Ha Habido un Error', 'Has Llegado Aquí por Error.');</script>"; // Error, has llegado por el camino equivocado.
    }
}
include "includes/footer.html";
?>