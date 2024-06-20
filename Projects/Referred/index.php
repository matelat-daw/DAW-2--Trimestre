<?php
include "includes/conn.php";
$title = "Main Page";
include "includes/header.php";
include "includes/modal.html";
?>
<section class="container-fluid pt-3">
    <div class="row">
        <div class="col-md-1"></div>
            <div class="col-md-10">
                <div id="view1">
                    <br><br>
                    <h1>Bienvenido a la WEB de Referidos</h1>
                    <br><br>
                    <h5>Si te Apuntas Podras Conseguir Importantes descuentos en tus tiendas Favoritas</h5>
                    <h5>Contamos con Miles de Tiendas Adheridas que Esperan que Tú las Recomiendes a tus Amigos, Por Cada Referido Tuyo que Haga una Compra en la Tienda, Esta te Acreditrará un 9% de Descuento del Valor de la Compra de tu Referido Acumulable hasta un 90%, es Decir un Máximo de 10 Referidos, Pero si tu le Envías 50 Amigos el Primer Mes, los 40 Referidos que Tienes se Convierten en Descuentos para el Mes Siguiente, Siempre como Máximo 10 Referidos por Mes</h5>
                    <h4>Aquí una Pequeña Muestra de las Empresas que Aceptan tus Referidos:</h4>
                    <div id="slide" class="carousel slide" data-bs-ride="carousel">
                        <div class="carousel-inner">
                            <div class="carousel-item active">
                                <img src="img/boeing.jpg" class="d-block w-100" alt="Aviones Boeing">
                            </div>
                            <div class="carousel-item">
                                <img src="img/coca.webp" class="d-block w-100" alt="Coca Cola">
                            </div>
                            <div class="carousel-item">
                                <img src="img/ferrari.jpg" class="d-block w-100" alt="Ferrari">
                            </div>
                            <div class="carousel-item">
                                <img src="img/lamborghini.webp" class="d-block w-100" alt="Lamborghini">
                            </div>
                            <div class="carousel-item">
                                <img src="img/lürssen.jpg" class="d-block w-100" alt="Yate Lürssen">
                            </div>
                            <div class="carousel-item">
                                <img src="img/rosa.jpg" class="d-block w-100" alt="Doña Rosa">
                            </div>
                        </div>
                        <button class="carousel-control-prev" type="button" data-bs-target="#slide" data-bs-slide="prev">
                        <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                        <span class="visually-hidden">Anterior</span>
                        </button>
                        <button class="carousel-control-next" type="button" data-bs-target="#slide" data-bs-slide="next">
                        <span class="carousel-control-next-icon" aria-hidden="true"></span>
                        <span class="visually-hidden">Siguiente</span>
                        </button>
                    </div>
                    <br><br><br><br><br>
                </div>
                <div id="view2">
                    <br><br>
                    <div id="login">
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
                        <a href='recover.php'><small>Olvidaste tu Contraseña</small></a><span class='separator'>No estoy Dado de Alta, <a href='javascript:show(document.getElementById("login"));'>Quiero Regístrarme</a></span>
                    </div>
                    <div id="logon">
                    <h1>Formulario de Registro de Usuarios</h1>
                    <br>
                    <form action="logon.php" method="post" enctype="multipart/form-data" onsubmit="return verify()">
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
                    <a href="javascript:show(document.getElementById('logon'));">Volver a LogIn</a>
                    </div>
                </div>
                <br><br>
            </div>
        <div class="col-md-1"></div>
    </div>
</section>
<?php
include "includes/footer.html";
?>