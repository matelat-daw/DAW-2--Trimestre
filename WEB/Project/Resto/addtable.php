<?php
include "includes/conn.php";
include "includes/modal.html";
$title = "Formulario para Agregar Mesa";
include "includes/header.php";

if (isset($_POST["table"]))
{
    $table = $_POST["table"];
    $i = 1;
    $sql = "SELECT name from mesa;";
    $stmt = $conn->prepare($sql);
    $stmt->execute();
    while ($row = $stmt->fetch(PDO::FETCH_OBJ))
    {
        if ($i <= $stmt->rowCount() && $row->name != $table)
        {
            $i++;
        }
    }
    if ($i > $stmt->rowCount())
    {
        $sql = "INSERT INTO mesa VALUES(:id, :name);";
        $stmt = $conn->prepare($sql);
        $stmt->execute([':id' => null, ':name' => $table]);
        echo "<script>toast ('0', 'Mesa : " . $table . " Agregada Correctamente.', 'Se ha Agregado la Mesa a la Base de Datos.');</script>";
    }
    else
    {
        echo "<script>toast ('0', 'Mesa : " . $table . " Repetida.', 'Esa Mesa ya Existe, Verifica los Nombres e Intentalo de Nuevo.');</script>";
    }
}
?>
<section class="container-fluid pt-3">
<div id="pc"></div>
    <div id="mobile"></div>
    <div class="row">
        <div class="col-md-1"></div>
            <div class="col-md-10">
                <div id="view1">
                    <div class="row">
                        <div class="col-md-5">
                        <h1>Administración de Mesas</h1>
                        <br>
                        <form method="post" onsubmit="return verify()">
                        <label><input type="text" name="table" required> Nombre de la Mesa</label>
                        <br><br>
                        <input type="submit" class="btn btn-primary btn-lg" value="Agrega">
                        </form>
                        </div>
                        <div class="col-md-1"></div>
                        <div class="col-md-6">
                            <h1>Modificar los Datos de una Mesa</h1>
                            <br>
                            <form action="modifytable.php" method="post">
                            <label><select name="table" required>
                                <option value=""> Selecciona una Mesa</option>
                                <?php
                                getTable($conn);
                                ?>
                            </select> Modifica Los Datos de Esta Mesa</label>
                            <br><br>
                            <input class="btn btn-secondary" type="submit" value="Modifica los Datos">
                            </form>
                            <br><hr><br>
                            <h1>Elimina una Mesa</h1>
                            <br>
                            <form action="deletetable.php" method="post">
                            <label><select name="table" required>
                                <option value=""> Selecciona una Mesa</option>
                                <?php
                                getTable($conn);

                                function getTable($conn)
                                {
                                    $sql = "SELECT * from mesa;";
                                    $stmt = $conn->prepare($sql);
                                    $stmt->execute();
                                    if ($stmt->rowCount() > 0)
                                    {
                                        while ($row = $stmt->fetch(PDO::FETCH_OBJ))
                                        {
                                            echo '<option value=' . $row->id . '>' . $row->name . '</option>';
                                        }
                                    }
                                }
                                ?>
                            </select> Elimina Esta Mesa</label>
                            <br><br>
                            <input class="btn btn-danger btn-lg" type="submit" value="Elimina los Datos de Esta Mesa">
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