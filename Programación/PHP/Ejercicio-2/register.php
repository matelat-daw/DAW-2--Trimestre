<?php
 // Formulario de Registro de Usuario con multipart/form-data para Enviar Ficheros, Foto en este Caso y con Verificación del Formulario del D.N.I. y las Contraseñas, si el D.N.I. no es Correcto o las Contraseñas no Coinciden la Función de Javascript verify() Devuelve false y el Formulario no se Envía.
?>
<h3>Registro de Usuario</h3>
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
    <i onclick="spy(1)" class="far fa-eye" id="togglePassword1" style="margin-left: -115px; cursor: pointer; visibility: hidden;"></i>
    <br><br>
    <label><input type="password" id="pass2" onkeypress="showEye(2)" required> Repite Contraseña</label>
    <i onclick="spy(2)" class="far fa-eye" id="togglePassword2" style="margin-left: -164px; cursor: pointer; visibility: hidden;"></i>
    <br><br>
    <label><input type="date" name="bday" required> Cumpleaños</label>
    <br><br>
    <fieldset>
        <legend>Selecciona tu Género</legend>
        <label><input type="radio" name="gender" value="0" checked required> Mujer</label>
        &nbsp;&nbsp;
        <label><input type="radio" name="gender" value="1" required> Varón</label>
    </fieldset>
    <br>
    <label><input type="file" name="profile"> Foto de Perfil<small>(opcional)</small></label>
    <br><br>
    <input type="submit" value="Regístrame!" class="button1"><span class="margin"><a href="index.php" target="_self">Volver a LogIn</a></span>
</form>