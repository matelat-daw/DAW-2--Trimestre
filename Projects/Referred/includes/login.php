<h1>Formulario de Entrada de Usuario</h1>
<br>
<form action="profile.php" method="post">
    <legend>Ingresa tus Credenciales</legend>
    <label><input type="text" name="email"> E-mail</label>
    <br><br>
    <label><input type="password" name="pass"> Contraseña</label>
    <br><br>
    <input type="submit" value="Quiero Entrar en mi Perfil" class="btn btn-success btn-lg">
</form>
<a href='recover.php'><small>Olvidé mi Contraseña</small></a><span class='separator'>No estoy Dado de Alta, <a href='javascript:show(document.getElementById("login"));'>Quiero Regístrarme</a></span>