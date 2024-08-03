<?php
session_start();
session_destroy();
echo '<script>if (!alert("Has Cerrado Sesión. Gracias.")) window.open("index.php", "_self");</script>';
?>