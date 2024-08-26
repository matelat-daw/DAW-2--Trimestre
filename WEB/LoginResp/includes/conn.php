<?php // Conexión con la base de datos.
session_start();
try
{
    $conn = new PDO('mysql:host=localhost;dbname=users', "root", $_ENV["MySQL"]);
    // $conn = new PDO('mysql:host=localhost;dbname=users', "orion", "Anubis@68"); // Ubuntu Server
	$conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
}
catch(PDOException $e)
{
	echo 'Error: ' . $e->getMessage();
}
?>