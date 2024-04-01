<?php
include "includes/conn.php";

if (isset($_POST["nick"]))
{
    $nick = $_POST["nick"];
    $user = $_POST["user"];
    $address = $_POST["address"];
    $email = $_POST["email"];
    $pass = $_POST["pass"];

    $sql = "INSERT INTO usuario (nick, name, address, email, pass) VALUES('$nick', '$user', '$address', '$email', '$pass');";
    $stmt = $conn->prepare($sql);
    $stmt->execute();
    if ($stmt->rowCount() > 0)
    {

        echo "<script>if (!alert('El Usuario $user se ha agregado a la Base de Datos.')) window.open('index.php', '_self');</script>";
    }
    else
    {
        echo "<h3>Error en el Registro, el Error es: $conn->error</h3>
            <button onclick='window.open(\"index.php\", \"_self\")'>Volver a Inicio</button>";
    }
      
    mysqli_close($conn);
}
?>