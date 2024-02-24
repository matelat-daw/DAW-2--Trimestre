<?php
include "includes/conn.php";
$title = "Usuario " . $_POST["username"] . " Registrado";
include "includes/header.php";
include "includes/modal-index.html";
 if (isset($_POST["username"]))
 {
    $dni = $_POST["dni"];
    $name = $_POST["username"];
    $surname1 = $_POST["surname1"];
    $surname2 = $_POST["surname2"];
    if ($surname2 == "")
    {
        $surname2 = NULL;
    }
    $phone = $_POST["phone"];
    $email = $_POST["email"];
    $pass = password_hash($_POST["pass"], PASSWORD_DEFAULT);

    $sql = "INSERT INTO user VALUES (:dni, :name, :surname1, :surname2, :phone, :email, :pass);";
    $stmt = $conn->prepare($sql);
    $stmt->execute([':dni' => $dni, ':name' => $name, ':surname1' => $surname1, ':surname2' => $surname2, ':phone' => $phone, ':email' => $email, ':pass' => $pass]);
    // echo "<script>if (!alert('Se ha Agregado el Usuario: " . $name . " " . $surname1 . " a la Base de Datos.')) window.open('index.php', '_self');</script>";
    echo "<script>toast(0, 'Usuario Agregado:', 'Se ha Agregado el Usuario: " . $name . " " . $surname1 . " a la Base de Datos.');</script>";
 }