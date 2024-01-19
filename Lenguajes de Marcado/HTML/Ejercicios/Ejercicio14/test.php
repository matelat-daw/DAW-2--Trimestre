<?php
if (isset($_POST["name"]))
{
    $name = $_POPST["name"];
    echo "<h1>Hola $name</h1>";
}