<h1>Formulario de Registro de Usuario</h1>
<br>
<form action="logon_u.php" method="post" enctype="multipart/form-data" onsubmit="return verify()">
    <fieldset>
        <legend>Ingresa tus Datos Para Registrarte</legend>
        <br>
        <label><input type="text" name="username" required> Nombre</label>
        <br><br>
        <label><input type="text" name="surname1" required> Apellido 1</label>
        <br><br>
        <label><input type="text" name="surname2" required> Apellido 2</label>
        <br><br>
        <label><input type="text" name="phone" required> Teléfono</label>
        <br><br>
        <label><input type="email" name="email" required> E-mail</label>
        <br><br>
        <label><input id='pass1' type='password' name='pass' onkeypress="showEye(1)"> Contraseña</label>
        <i onclick="spy(1)" class="far fa-eye" id="togglePassword1" style="margin-left: -115px; cursor: pointer; visibility: hidden;"></i>
        <br><br>
        <label><input id='pass2' type='password' onkeypress="showEye(2)"> Repite Contraseña</label>
        <i onclick="spy(2)" class="far fa-eye" id="togglePassword2" style="margin-left: -164px; cursor: pointer; visibility: hidden;"></i>
        <br><br>
        <label><input type="date" name="bday" required> Fecha de Nacimiento</label>
        <br><br>
        <fieldset>
            <legend>Como te Identificas</legend>
            <label><input type="radio" name="gender" value="0" checked required> Mujer</label>
            <label><input type="radio" name="gender" value="1" required> Varón</label>
        </fieldset>
        <br><br>
        <label><input type="file" name="profile"> Foto de Perfil<small>(Opcional)</small></label>
        <br><br>
        <input type="submit" value="Me Quiero Registrar" class="btn btn-primary btn-lg">
    </fieldset>
</form>
<a href="javascript:show_u(document.getElementById('login_u'));">Volver a LogIn</a>
<br><br><br>