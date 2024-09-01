<?php
include "includes/conn.php";
include "includes/modal.html";
$title = "Ver Facturas por Mesas";
include "includes/header.php";
?>
<section class="container-fluid pt-3">
<div id="pc"></div>
    <div id="mobile"></div>
    <div class="row">
        <div class="col-md-1"></div>
            <div class="col-md-10">
                <div id="view1">
                    <br><br>
                    <div class="row">
						<div class="col-md-5">
						<h2>Ver Totales y Facturas</h2>
						<br>
						<h4>Selecciona el Trimestre y el Año para Descargar un Informe de las Facturas del Trimestre que Necesites y Haz Click en Ver Informe.</h4>
						<br>
						<form action="export.php" method="post" target="_blank">
							<label>
								<select name="date">
									<option value=1>1º Trimestre</option>
									<option value=2>2º Trimestre</option>
									<option value=3>3º Trimestre</option>
									<option value=4>4º Trimestre</option>
								</select> Selecciona el Trimestre a consultar
							</label>
							<br><br>
							<label><input type="number" id="year" name="year" min="2022" max="3000" step="1"> Selecciona el Año</label>
							<br><br>
							<input type="submit" value="Ver Informe" class="btn btn-info btn-lg">
						</form>
						<script>
							var date = document.getElementById("year");
							const d = new Date();
							let year = d.getFullYear();
							date.value = year;
						</script>
						<br>
						<br>
						<div>
							<button onclick="window.open('showtotal.php', '_blank')" class="btn btn-primary" style="height: 64px;">Mostrar el Total de Ventas del Año</button>
						</div>
						</div>
						<div class="col-md-1"></div>
						<div class="col-md-6">
                        <h1>Busqueda de Facturas por la Fecha, por la Mesa o por la Mesa y Fecha</h1>
					<form action="showtable.php" method="post" onsubmit="return verifyShow()">
                    <label><input id="date" type="date" name="date"> Selecciona la Fecha</label>
					<br>
					<br>
					<label><select id="table" name="table">
                        <option value="">Selecciona una Mesa</option>
                        <?php
                        $sql = "SELECT * FROM mesa;";
                        $stmt = $conn->prepare($sql);
                        $stmt->execute();
                        if ($stmt->rowCount() > 0)
                        {
                            while ($row = $stmt->fetch(PDO::FETCH_OBJ))
                            {
                                echo '<option value="' . $row->id . '">' . $row->name . '</option>';
                            }
                        }
                        ?>
					<select> Selecciona la Mesa</label>
					<br><br>
					<input class="btn btn-primary" type="submit" value="Ver Facturas" style="width:128px; height:64px;">
                    </form>
							<br><br>
                            <div>
                                <button onclick="window.open('invoice.php', '_blank')" class="btn btn-success" style="height: 64px;">Ver Última Factura</button>
                            </div>
                            <br><br>
							<div>
								<button onclick="window.open('db-backup.php', '_blank')" class="btn btn-secondary" style="height: 64px;">Copia de Respaldo de la Base de Datos</button>
							</div>
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