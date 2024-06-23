<h2>Aquí Podrás Modificar tus Datos.</h2>
<br>
<h3><span style="color: red; font-size: 1.5rem;">Atención: </span> por razones de seguridad la Contraseña no se muestra, si no quieres cambiarla deja ambas casillas en blanco y se mantendrá la contraseña que tenías.</h3>
<br>
<form action='modify_b.php' method='post' onsubmit='return verify()'>
<label><input type='text' name='username' value='<?php echo $name; ?>' required> Nombre de la Empresa</label>
<br><br>
<label><input type='text' name='address' value='<?php echo $address; ?>' required> Dirección</label>
<br><br>
<label><input type='text' name='phone' value='<?php echo $phone; ?>' required> Teléfono</label>
<br><br>
<label><input type='email' name='email' value='<?php echo $email; ?>' required> E-mail</label>
<br><br>
<label><input type='number' name='percentage' value='<?php echo $percentage; ?>' required> Porcentaje que Descontarás a tus Clientes por Refrido</label>
<br><br>
<label><input id='pass1' type='password' name='pass' onkeypress="showEye(1)"> Contraseña</label>
<i onclick="spy(1)" class="far fa-eye" id="togglePassword1" style="margin-left: -115px; cursor: pointer; visibility: hidden;"></i>
<br><br>
<label><input id='pass2' type='password' onkeypress="showEye(2)"> Repite Contraseña</label>
<i onclick="spy(2)" class="far fa-eye" id="togglePassword2" style="margin-left: -164px; cursor: pointer; visibility: hidden;"></i>
<br><br>
<input type='submit' value='Modifico los Datos' class="btn btn-primary btn-lg">
</form>