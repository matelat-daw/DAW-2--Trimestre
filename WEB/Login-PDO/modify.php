<?php
include "includes/conn.php";

if (isset($_POST["ID"]))
{
    $id = $_POST["ID"];
    $nick = $_POST["nick"];
    $user = $_POST["user"];
    $address = $_POST["address"];
    $email = $_POST["email"];
    $pass = $_POST["pass"];

    $sql = "UPDATE usuario SET nick = '$nick', name = '$user', address = '$address', email = '$email', pass = '$pass' WHERE ID=$id;";
    $stmt = $conn->prepare($sql);
    $stmt->execute();

    if ($stmt->rowCount() > 0)
    {
        echo "<script>if (!alert('Tus Datos se Han Modificado Correctamente.')) window.open('index.php', '_self');</script>";
    }
    else
    {
        echo "<h3>Error en la Modificación, el Error es: $conn->error</h3>
            <button onclick='window.open(\"index.php\", \"_self\")'>Volver a Inicio</button>";
    }
}
?>