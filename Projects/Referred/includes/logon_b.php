<h1>Formulario de Registro de Empresa</h1>
<br>
<form action="logon_b.php" method="post" enctype="multipart/form-data" onsubmit="return verify()">
    <fieldset>
        <legend>Ingresa tus Datos Para Registrarte</legend>
        <br>
        <label><input type="text" name="business" required> Nombre de la Empresa</label>
        <br><br>
        <label><input type="text" name="address" required> Dirección</label>
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
        <label><input type="number" name="percentage" required> Porcentaje de Descuento que Aplicarás a tus Clientes por Referido</label>
        <br><br>
        <label><input type="file" name="profile"> Logo de la Empresa<small>(Opcional)</small></label>
        <br><br>
        <input type="submit" value="Me Quiero Registrar" class="btn btn-primary btn-lg">
    </fieldset>
</form>
<a href="javascript:show(document.getElementById('logon_b'));">Volver a LogIn</a>