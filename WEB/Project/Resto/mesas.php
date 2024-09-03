<?php
include "includes/conn.php";
$title = "Mesas del Restaurante";
include "includes/header.php";
?>
<section class="container-fluid pt-3">
<div id="pc"></div>
    <div id="mobile"></div>
    <div class="row">
        <div class="col-md-1"></div>
            <div class="col-md-10">
                <div id="view1">
                    <br><br><br>
                    <form action="mesa.php" methos="post">
                        <lable><select name="table">
                            <option value="">Selecciona la Mesa a Facturar</option>
                            <?php
                            $sql = "SELECT * FROM mesa;";
                            $stmt = $conn->prepare($sql);
                            $stmt->execute();
                            while ($row = $stmt->fetch(PDO::FETCH_OBJ))
                            {
                                echo '<option value="' . $row->name . '">' . $row->name . '</option>';
                            }
                            ?>
                        </select> Mesa del Restaurante</label>
                        <br><br>
                        <input type="submit" value="Factura" class="btn btn-primary btn-lg">
                    </form>
				</div>
            </div>
        <div class="col-md-1"></div>
    </div>
</section>
<?php
include "includes/footer.html";
?>