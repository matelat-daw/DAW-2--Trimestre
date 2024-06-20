<?php
include "includes/conn.php";
$title = "La WEB de Referidos - Perfil de Usuario";
include "includes/header.php";

// if (isset($_POST["email"])) // Si se recibe el email del cliente
// {
//     $ok = false; // Booleano para verificar si los datos son correctos.
//     $email = $_POST["email"]; // Lo asigno a la variable $email.
//     $pass = $_POST["pass"]; // Asigno la Password a la variable $pass.
//     $sql = "SELECT * FROM user WHERE email='$email';"; // Preparo la consulta con el email.
//     $stmt = $conn->prepare($sql); // Hago la consulta a la base de datos con la conexión y la consulta recibidas.
//     $stmt->execute(); // La ejecuto.
//     if ($stmt->rowCount() > 0) // Si hubo resultados.
//     {
//         $row = $stmt->fetch(PDO::FETCH_OBJ); // Cargo el resultado en $row.
//         if (password_verify($pass, $row->pass)) // Verifico la contraseña enviada con la de la base de datos descifrada.
//         {
//             echo "<script>console.log('Entró la Contraseña está bien.');</script>";
//             $_SESSION["user"] = $row->id; // Asigno a la variable de sesión client la id del cliente.
//             $_SESSION["name"] = $row->name; // Asigno a la variable de sesión name el nombre del cliente.
//         }
//         else // Si $ok es false.
//         {
//             echo "<script>console.log('Estoy en el else, algo salió mal.');</script>";
//             session_destroy(); // Destruyo la sesión.
//         }
//     }
// }

if (isset($_POST['email'])) // Si recibe datos por POST en la variable array $_POST["email"].
{
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
            $sql = "SELECT * FROM user WHERE email='$email';";
            $stmt = $conn->prepare($sql);
            $stmt->execute();
            if ($stmt->rowCount() > 0)
            {
                $row = $stmt->fetch(PDO::FETCH_OBJ);
                if (password_verify($pass, $row->pass))
                {
                    $_SESSION["user"] = $row->id; // Asigno a la variable de sesión client la id del cliente.
                    $_SESSION["name"] = $row->name; // Asigno a la variable de sesión name el nombre del cliente.
                    $path = $row->path;
                }
            }
        }
        else
        {
            include "includes/modal_index.html";
            echo "<script>toast(1, 'Cuenta NO Activada', 'Aun no Has Activado tu Cuenta. Revisa tu Correo Electrónico, Puede que el Mensaje Esté en la Carpeta de Correo no Deseados o Spam, Debes Hacer Click en el Botón Activo mi Cuenta del E-mail para Poder Usar el Sitio. Gracias.');</script>"; // No hay Registros.
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
    // include "includes/nav_profile.php";
    // include "includes/nav-mob-profile.php";
?>
<section class="container-fluid pt-3">
    <div class="row">
        <div class="col-md-1" style="width: 2%;"></div>
            <div class="col-md-10">
                <div id="view1">
                <br><br><br>
                <div class="row">
                    <div class="col-md-5">
                        <br>
                        <h2>Aquí Podrás Modificar tus Datos.</h2>
                        <br>
                        <h3><span style="color: red; font-size: 1.5rem;">Atención: </span> por razones de seguridad la Contraseña no se muestra, si no quieres cambiarla deja ambas casillas en blanco y se mantendrá la contraseña que tenías.</h3>
                        <br>
                        <form action='modify.php' method='post' onsubmit='return verify()'>
                        <label><input type='text' name='username' value='<?php echo $name; ?>' required> Nombre</label>
                        <br><br>
                        <label><input type='text' name='surname1' value='<?php echo $surname1; ?>' required> Apellido 1</label>
                        <br><br>
                        <label><input type='text' name='surname2' value='<?php echo $surname2; ?>' required> Apellido 2</label>
                        <br><br>
                        <label><input type='text' name='phone' value='<?php echo $phone; ?>' required> Teléfono</label>
                        <br><br>
                        <label><input type='email' name='email' value='<?php echo $email; ?>' required> E-mail</label>
                        <br><br>
                        <label><input type='date' name='bday' value='<?php echo $bday; ?>' required> Cumpleaños</label>
                        <br><br>
                        <label><input id='pass1' type='password' name='pass' onkeypress="showEye(1)"> Contraseña</label>
                        <i onclick="spy(1)" class="far fa-eye" id="togglePassword1" style="margin-left: -115px; cursor: pointer; visibility: hidden;"></i>
                        <br><br>
                        <label><input id='pass2' type='password' onkeypress="showEye(2)"> Repite Contraseña</label>
                        <i onclick="spy(2)" class="far fa-eye" id="togglePassword2" style="margin-left: -164px; cursor: pointer; visibility: hidden;"></i>
                        <br><br>
                        <input type='submit' value='Modificar' class="btn btn-primary btn-lg">
                        </form>
                    </div>
                    <div class="col-md-1" style="border: 1px solid grey; width: 1%;"></div>
                    <div class="col-md-6">
                        <div class="row">
                            <div class="col-md-12">
                                <h2>O Eliminar tu Perfil</h2>
                                <br><br><br>
                                <form action="delete.php" method="post">
                                    <input type="hidden" name="id" value="<?php echo $id; ?>">
                                    <input type="submit" value="Elimino Mi Perfil" class="btn btn-danger btn-lg">
                                </form>
                            </div>
                        </div>
                        <br><br>
                        <div class="row">
                            <div class="col-md-12">
                                <h2>Tus Referidos</h2>
                                <br><br>
                            <?php
                            /* $index = 0;
                            $ids = [];
                            $array = [];
                            $qtty = [];
                            $service = [];
                            $service[] = [];
                            $price = [];
                            $price[] = [];

                            $sql = "SELECT invoice_id FROM sold JOIN invoice ON sold.invoice_id=invoice.id WHERE invoice.client_id=$id GROUP BY invoice_id;";
                            $stmt = $conn->prepare($sql);
                            $stmt->execute();
                            if ($stmt->rowCount() > 0)
                            {
                                $ok = true;
                                while ($row = $stmt->fetch(PDO::FETCH_OBJ))
                                {
                                    $ids[$index] = $row->invoice_id;
                                    $index++;
                                }
                                $index = 0;
                                $sql = "SELECT invoice_id, invoice.total, invoice.inv_date, invoice.inv_time FROM sold JOIN invoice ON sold.invoice_id=invoice.id WHERE invoice.client_id=$id GROUP BY invoice_id;";
                                $stmt = $conn->prepare($sql);
                                $stmt->execute();
                                while ($row = $stmt->fetch(PDO::FETCH_OBJ))
                                {
                                    $total[$index] = $row->total;
                                    $date[$index] = $row->inv_date;
                                    $time[$index] = $row->inv_time;
                                    $index++;
                                }
                                $index = 0;
                                $array[] = [];
                                $qtty[] = [];
                                $sql = "SELECT * FROM sold INNER JOIN invoice WHERE invoice.client_id=$id AND invoice.id=sold.invoice_id;";
                                $stmt_sold = $conn->prepare($sql);
                                $stmt_sold->execute();
                                $ids2 = [];
                                $serv = [];
                                $qtt = [];
                                while ($row_sold = $stmt_sold->fetch(PDO::FETCH_OBJ))
                                {
                                    $ids2[$index] = $row_sold->invoice_id;
                                    $serv[$index] = $row_sold->service_id;
                                    $qtt[$index] = $row_sold->qtty . "<br>";
                                    $index++;
                                }
                                $i = 0;
                                $index = 0;
                                for ($z = 0; $z < count($ids); $z++)
                                {
                                    recursive($index, $serv, $qtt, $ids2, $i);
                                    $i++;
                                    $index++;
                                }
                                getService($conn, $array, "html");
                            }
                            else // Si no hay datos
                            {
                                echo "<script>toast(1, 'Aun sin Datos', 'No Hay Ningúna Factura Tuya Registrada.');</script>"; // No hay Registros.
                            }
                            if ($ok) // Si se encontraron Referidos.
                            {
                                echo "<script>var name = '';</script>
                                <script>var invoice = [];</script>
                                <script>var service = [];</script>
                                <script>var price = [];</script>
                                <script>var qtties = [];</script>
                                <script>var total = [];</script>
                                <script>var date = [];</script>
                                <script>var time = [];</script>
                                <script>name = '" . $name . "';</script>"; // Les asigno los datos de PHP.
                                for ($i = 0; $i < count($ids); $i++)
                                {
                                    echo "<script>invoice[" . $i . "] = " . $ids[$i] . ";</script>
                                    <script>total[" . $i . "] = '" . $total[$i] . "';</script>
                                    <script>date[" . $i . "] = '" . $date[$i] . "';</script>
                                    <script>time[" . $i . "] = '" . $time[$i] . "';</script>";
                                }
                                for ($i = 0; $i < count($service); $i++) // Bucle interno desde 0 al tamaño del doble array $service.
                                {
                                    echo "<script> service[" . $i . "] = [];
                                    price[" . $i . "] = [];
                                    qtties[" . $i . "] = [];</script>";
                                    for ($j = 0; $j < count($service[$i]); $j++)
                                    {
                                        echo "<script>qtties[" . $i . "][" . $j . "] = '" . $qtty[$i][$j] . "';</script>
                                        <script>service[" . $i . "][" . $j . "] = '" . $service[$i][$j] . "';</script>
                                        <script>price[" . $i . "][" . $j . "] = '" . $price[$i][$j] . "';</script>";
                                    }
                                }
                                echo '<div id="table"></div>
                                <br>
                                <span id="page"></span>&nbsp;&nbsp;&nbsp;&nbsp;
                                <button onclick="prev(false)" id="prev" class="btn btn-danger" style="visibility: hidden;">Anteriores Resultados</button>&nbsp;&nbsp;&nbsp;&nbsp;
                                <button onclick="next(false)" id="next" class="btn btn-primary" style="visibility: hidden;">Siguientes Resultados</button><br>
                                <script>change(1, 5, false);</script>';
                            } */
                            echo '<br><br><br><br><br>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        <div class="col-md-1" style="width: 2%;"></div>
    </div>
</section>';
}
else
{
    include "includes/modal_index.html";
    echo "<script>toast(1, 'Ha Habido un Error', 'Has Llegado Aquí por Error.');</script>"; // Error, has llegado por el camino equivocado.
}
include "includes/footer.html";
?>