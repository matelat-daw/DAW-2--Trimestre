<?php
session_start();
ob_start();
try
{
	$conn = new PDO('mysql:host=localhost;dbname=resto', "root", $_ENV["MySQL"]);
	$conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
}
catch(PDOException $e)
{
	echo 'Error: ' . $e->getMessage();
}
?>