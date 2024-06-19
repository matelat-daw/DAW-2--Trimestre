<?php
session_start(); // Se Usa para Iniciar la Sesión de Usuario.
try // Intenta la Conexión
{
	$conn = new PDO('mysql:host=localhost;dbname=users', "root", $_ENV["MySQL"]); // Crea la Conexión con la Base de Datos.
	$conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
}
catch(PDOException $e) // Si Hay Algún Error.
{
	echo 'Error: ' . $e->getMessage(); // Lo Muestra en Pantalla.
}
?>