<?php // Script con un formulario con los datos del usuario, para modificar su perfil.
echo '<h3>Aquí Puedes Modificar Tus Datos</h3>
<br>
<form action="modify.php" method="post" enctype="multipart/form-data" onsubmit="return verify()">
<fieldset>
<legend>Formulario Para Modificar Datos</legend>
<input type="hidden" name="id" value="' . $_SESSION["id"] . '">
<label><input type="text" name="username" value="' . $row->name . '" required> Nombre</label>
<br><br>
<label><input type="text" name="surname" value="' . $row->surname . '" required> Primer Apellido</label>
<br><br>
<label><input type="text" name="surname2" value="' . $row->surname2 . '"> Segundo Apellido</label>
<br><br>
<label><input id="dni" type="text" name="dni" value="' . $row->dni . '" required> D.N.I.</label>
<br><br>
<label><input type="text" name="phone" value="' . $row->phone . '" required> Teléfono</label>
<br><br>
<label><input type="email" name="email" value="' . $row->email . '" required> E-mail</label>
<br><br>
<label><input id="pass1" type="password" name="pass" onkeypress="showEye(1)"> Contraseña</label>
<i id="togglePassword1" onclick="spy(1)" class="far fa-eye" style="margin-left: -140px; cursor: pointer; visibility: hidden;"></i>
<br><br>
<label><input id="pass2" type="password" onkeypress="showEye(2)"> Repite Contraseña</label>
<i id="togglePassword2" onclick="spy(2)" class="far fa-eye" style="margin-left: -205px; cursor: pointer; visibility: hidden;"></i>
<br><br>
<label><input type="date" name="bday" value="' . $row->bday . '" required> Cumpleaños</label>
<br><br>
<fieldset>
        <legend>¿Cual es tu Genero?</legend>';
if ($row->gender == 0)
{
    echo '<label><input type="radio" name="gender" value="0" checked> Mujer</label>
        <br><br>
        <label><input type="radio" name="gender" value="1"> Varón</label>
        <br>';
}
else
{
    echo '<label><input type="radio" name="gender" value="0"> Mujer</label>
        <br><br>
        <label><input type="radio" name="gender" value="1" checked> Varón</label>
        <br>';
}
echo '</fieldset><br>
<input type="hidden" name="path" value="' . $row->path . '">
<label><input type="file" name="profile" class="btn btn-secondary btn-lg"> Foto de Perfil<small>(opcional)</small></label>
<br><br>
<input type="submit" value="Modifico Mis Datos" class="btn btn-info btn-lg">
</fieldset>
</form>
<br>
<button id="modifybtn" onclick="show(\'quit\')" class="btn btn-link btn-lg">Quiero Eliminar Mi Perfil</button>
<br><br>';
?>