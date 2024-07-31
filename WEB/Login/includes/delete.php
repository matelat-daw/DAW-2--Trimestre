<?php
echo '<h3>Aquí Puedes Eliminar Tu Perfil</h3>
<br><br>
<form action="delete.php" method="post">
    <input type="hidden" name="id" value="' . $_SESSION["id"] . '">
    <input type="submit" class="btn btn-danger btn-lg" value="Elimino mi Perfil">
</form>
<br>
<button onclick="show(\'modify\')" class="btn btn-link btn-lg">Voy a Modificar Mi Perfil</button>';
?>