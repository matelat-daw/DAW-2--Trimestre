<?php
include "includes/conn.php";
include "classes/User.php";
$title = "Registro de Usuario";
include "includes/header.php";
include "includes/modal.html";
?>
<section class="container-fluid pt-3">
    <div class="row">
        <div class="col-md-1"></div>
            <div class="col-md-10">
                <div id="view1">
                    <div class="row">
                        <div class="col-md-7">
                        <h3 class="center">Registro y Login de Usuario</h3>
                        <fieldset>
                            <legend>Formulario de Registro</legend>
                            <form action="logon.php" method="post" onsubmit="return checkPasswords()">
                                <label><input id="dni" type="text" name="dni" required> D.N.I.</label>
                                <br><br>
                                <label><input type="text" name="username" required> Nombre</label>
                                <br><br>
                                <label><input type="text" name="surname1" required> Primer Apellido</label>
                                <br><br>
                                <label><input type="text" name="surname2"> Segundo Apellido</label>
                                <br><br>
                                <label><input type="text" name="phone" required> Teléfono</label>
                                <br><br>
                                <label><input type="email" name="email" required> E-Mail</label>
                                <br><br>
                                <label><input id="pass" type="password" name="pass"> Contraseña</label>
                                <br><br>
                                <label><input id="pass2" type="password" name="pass2"> Repite Contraseña</label>
                                <br><br>
                                <input type="submit" value="Me Registro!">
                            </form>
                        </div>
                        <div class="col-md-5">
                            <h3>Entrada de Clientes para Solicitar un Turno</h3>
                            <br>
                            <form action="login.php" method="post">
                                <label><input type="email" name="email" required> E-mail</label>
                                <br><br>
                                <label><input type="password" name="pass" id="pass3" onkeypress="showEye(3)" required> Contraseña</label>
                                <i onclick="spy(3)" class="far fa-eye" id="togglePassword3" style="margin-left: -140px; cursor: pointer; visibility: hidden;"></i>
                                <br><br>
                                <input type="submit" value="Login">
                            </form>
                            <a href="recover.php"><small>Olvidaste tu Contraseña</small></a>
                        </div>
                        </fieldset>
                    </div>
                    <br><br>
                    <div class="row">
                        <div class="column-md-12">
                        <fieldset>
                            <legend>Lista de Usuarios</legend>
                            <table>
                                <tr>
                                    <th>D.N.I</th>
                                    <th>Nombre</th>
                                    <th>Primer Apellido</th>
                                    <th>Segundo Apellido</th>
                                    <th>Teléfono</th>
                                    <th>E-mail</th>
                                </tr>
                                <?php
                                $index = 0;
                                $sql = "SELECT * FROM user ORDER BY email;";
                                $stmt = $conn->prepare($sql);
                                $stmt->execute();
                                if ($stmt->rowCount() > 0)
                                {
                                    while ($row = $stmt->fetch(PDO::FETCH_OBJ))
                                    {
                                        $user[$index] = new User($row->dni, $row->name, $row->surname1, $row->surname2, $row->phone, $row->email);
                                        echo "<tr><td>" . $user[$index]->getDni() . "</td>
                                                <td>" . $user[$index]->getName() . "</td>
                                                <td>" . $user[$index]->getSurname1() . "</td>
                                                <td>" . $user[$index]->getSurname2() . "</td>
                                                <td>" . $user[$index]->getPhone() . "</td>
                                                <td>" . $user[$index]->getEmail() . "</td></tr>";
                                        $index++;
                                    }
                                }
                                ?>
                        </table>
                    </fieldset>
                        </div>
                    </div>
                </div>
            </div>
        <div class="col-md-1"></div>
    </div>
</section>
<br><br><br><br>
</body>
</html>