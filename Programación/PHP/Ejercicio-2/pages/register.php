<?php
echo "Perfect I am here.";
?>
<h3>Registro de Clientes</h3>
<br>
<form action="logon.php" method="post" enctype="multipart/form-data" onsubmit="return verify()">
    <label><input type="text" name="username" required> Nombre</label>
    <br><br>
    <label><input type="text" name="surname" required> Apellido1</label>
    <br><br>
    <label><input type="text" name="surname2"> Apellido2</label>
    <br><br>
    <label><input id="dni" type="text" name="dni" required> D.N.I.</label>
    <br><br>
    <label><input type="text" name="phone" required> Teléfono</label>
    <br><br>
    <label><input type="email" name="email" required> E-mail</label>
    <br><br>
    <label><input type="password" name="pass" id="pass1" onkeypress="showEye(1)" required> Contraseña</label>
    <i onclick="spy(1)" class="far fa-eye" id="togglePassword1" style="margin-left: -140px; cursor: pointer; visibility: hidden;"></i>
    <br><br>
    <label><input type="password" id="pass2" onkeypress="showEye(2)" required> Repite Contraseña</label>
    <i onclick="spy(2)" class="far fa-eye" id="togglePassword2" style="margin-left: -205px; cursor: pointer; visibility: hidden;"></i>
    <br><br>
    <label><input type="date" name="bday" required> Cumpleaños</label>
    <br><br>
    <fieldset>
        <legend>Selecciona tu Género</legend>
        <label><input type="radio" name="gender" value="0" checked required> Mujer</label>
        <br><br>
        <label><input type="radio" name="gender" value="1" required> Varón</label>
        <br><br>
    </fieldset>
    <label><input type="file" name="profile"> Foto de Perfil<small>(opcional)</small></label>
    <br><br>
    <input type="submit" value="Regístrame!">
</form>