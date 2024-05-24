<?php
include "includes/conn.php";

if (isset($_POST["nick"]))
{
    $nick = $_POST["nick"];
    $pass = $_POST["pass"];

    $sql = "SELECT * FROM usuario WHERE nick='$nick' AND pass= BINARY '$pass';";
    $stmt = $conn->prepare($sql);
    $stmt->execute();
    if ($stmt->rowCount() > 0)
    {
        $row = $stmt->fetch(PDO::FETCH_OBJ);
        $title = "Perfil de Usuaio";
        include "includes/header.php";
        echo '
                <section class="container-fluid pt-3">
                    <div class="row">
                        <div class="col-md-1"></div>
                        <div class="col-md-10">
                            <div id="view1">
                            <br><br>
                            <div class="row">
                            <div class="col-md-7">
                            <h3>Perfil de Usuario</h3>
                            <br><br>
                            <form action="modify.php" method="post">
                                <label><input type="text" name="nick" value="' . $nick . '"> Nombre de Usuario(Nick)</label>
                                <br><br>
                                <label><input type="text" name="user" value="' . $row->name . '"> Nombre</label>
                                <br><br>
                                <label><input type="text" name="address" value="' . $row->address . '"> Dirección</label>
                                <br><br>
                                <label><input type="text" name="email" value="' . $row->email . '"> E-mail</label>
                                <br><br>
                                <label><input type="password" name="pass" value="' . $pass . '"> Contraseña</label>
                                <br><br>
                                <input type="hidden" name="ID" value="' . $row->id . '">
                                <input type="submit" value="Modifico mis Datos" class="btn btn-success btn-lg">
                            </form>
                            </div>
                            <div class="col-md-1 thin"></div>
                            <div class="col-md-4">
                                <h3>Elimino mi Perfil</h3>
                                <br><br><br>
                                <form action="delete.php" method="post">
                                    <input type="hidden" name="ID" value="' . $row->id . '">
                                    <input type="submit" value="Elimino" class="btn btn-danger btn-lg">
                                </form>
                            </div>
                            </div>
                        </div>
                        <div class="col-md-1"></div>
                    </div>
                </section>
        ';
        include "includes/footer.html";
    }
    else
    {
        echo "<script>if (!alert('Error, No hay Ningún Usuario con esos Datos.')) window.open('index.php', '_self')</script>";
    }
}
?>