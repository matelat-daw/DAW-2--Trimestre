<?php
$title = "Simple CRUD";
include "includes/header.php";
?>
    <section class="container-fluid pt-3">
        <div class="row">
            <div class="col-md-1"></div>
            <div class="col-md-10">
                <div id="view1">
                    <div class="row">
                    <div class="col-md-7">
                        <br><br><br>
                        <h1>Crud a la base de datos</h1>
                        <br><br>
                        <h3>Formulario de Registro</h3>
                        <br>
                        <form action="logon.php" method="post">
                            <label><input type="text" name="nick"> Nombre de Usuario(Nick)</label>
                            <br><br>
                            <label><input type="text" name="user"> Nombre</label>
                            <br><br>
                            <label><input type="text" name="address"> Dirección</label>
                            <br><br>
                            <label><input type="text" name="email"> E-mail</label>
                            <br><br>
                            <label><input type="password" name="pass"> Contraseña</label>
                            <br><br>
                            <input type="submit" value="Regístrame" class="btn btn-primary btn-lg">
                        </form>
                    </div>
                    <div class="col-md-1 thin"></div>
                    <div class="col-md-4">
                        <br><br><br><br><br><br><br>
                        <h3>Formulario de Entrada</h3>
                        <br>
                        <form action="login.php" method="post">
                            <label><input type="text" name="nick"> Nombre de Usuario(Nick)</label>
                            <br><br>
                            <label><input type="password" name="pass"> Contraseña</label>
                            <br><br>
                            <input type="submit" value="Login" class="btn btn-success btn-lg">
                        </form>
                    </div>
                </div>
                </div>
            </div>
            <div class="col-md-1"></div>
        </div>
    </section>
<?php
include "includes/footer.html";
?>