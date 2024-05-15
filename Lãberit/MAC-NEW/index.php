<?php
require "Influx/autoload.php";
include "includes/conn.php";
$title = "Verificador de Direcciones MAC Intrusas.";
include "includes/header.php";
include "includes/modal.html";
include "includes/nav_index.html";
?>
<section class="container-fluid pt-3">
    <div class="row" id="pc">
        <div class="col-md-1" id="mobile"></div>
            <div class="col-md-10">
                <div id="view1">
                    <br><br><br><br>
                    <h1>Verificador de MACS</h1>
                    <?php
                        $line = [];
                        $each = [];
                        $i = 0;
                        $file = fopen("data.txt", "r") or die("Unable to open file!");
                        while(!feof($file))
                        {
                            $line[$i] = fgets($file);
                            $each[$i] = explode(";", $line[$i]);
                            $i++;
                        }
                        fclose($file);

                        print_r($each);


                        echo '
                            <h3>Los Datos ya Están Listos, Haz Click en el Botón Enviar para Almacenarlos en la Base de Datos</h3>
                            <br><br>
                            <form action="review.php" method="post">
                            <input type="hidden" name="data" value="'. htmlspecialchars(json_encode($each)) . '">
                            <input type="submit" value="Enviar" class="btn btn-primary btn-lg">
                            </form>
                        ';
                    ?>
                </div>
                <div id="view2">
                    <br><br><br><br>
                    <h3>Lista de datos en InfluxDB:</h3>
                    <br><br>
                    <?php
                    $query = "from(bucket: \"$bucket\") |> range(start: -7d) |> filter(fn: (r) => r._measurement == \"aintruder\")"; // Consulta a InfluxDB.
                    $tables = $client->createQueryApi()->query($query, $org); // Ejecuta la Consulta Asignado el Resutlado a la Variable $tables.
                    $records = []; // $records Contendrá todos los Resultados de la Tabla intruder de la Base de Datos MACDB.
                    $i = 0;
                    foreach ($tables as $table) // Obtiene cada Tabla de las Tablas de la Variable $tables(Solo Obtiene la Tabla intruder).
                    {
                        foreach ($table->records as $record) // De la Tabla intruder Obtiene cada Campo Almacenado en la Varaible $record.
                        {
                            $tag = ["mac" => $record->getRecordValue("mac"), "time" => $record->getTime()];
                            // $tag = ["mac" => $record->getRecordValue("mac"), "qtty" => $record->getRecordValue("qtty"), "uni" => $record->getRecordValue("uni"), "multi" => $record->getRecordValue("multi"), "broad" => $record->getRecordValue("broad"), "arp" => $record->getRecordValue("arp"), "traffic" => $record->getRecordValue("traffic"), "icmp" => $record->getRecordValue("icmp"), "tcp" => $record->getRecordValue("tcp"), "udp" => $record->getRecordValue("udp"), "resto" => $record->getRecordValue("resto"), "ipv6" => $record->getRecordValue("ipv6"), "arp46" => $record->getRecordValue("arp46"), "badip" => $record->getRecordValue("badip"), "ssdp" => $record->getRecordValue("ssdp"), "icmp6" => $record->getRecordValue("icmp6")]; // En la Varible de tipo array $tag, pusimos todos los tags y sus valores.
                            $row = key_exists($record->getTime(), $records) ? $records[$record->getTime()] : []; // Este operador ternario asigna a $row los datos en InfluxDB.
                            $records[$record->getTime()] = array_merge($row, $tag, [$record->getField() => $record->getValue()]); // Hacemos un array_merge con los datos de toda la Tupla y los Tags.
                        }
                    }

                    if (count($records) > 0) // Si hay Datos.
                    {
                        $data = [];
                        $time = array_column($records, 'time'); // Obtengo la KEY time del Array $records.

                        array_multisort($time, SORT_DESC, $records); // Ordena el Array $records por la Columna time, en Orden Descendiente.

                        $i = 0; // Índice de Todos los Datos de Todas las Tuplas.
                        $z = 0; // Se usa para almacenar los Tags Solo una Vez.
                        echo "<script>var array_key = [];
                                    var array_value = [];</script>"; // Creo las Variables de Tipo Array de Javascript.
                        foreach($records as $key) // Bucle para Obtener las Keys.
                        {
                            $z++; // Incremento $z.
                            foreach ($key as $value) // Bucle para Obtener los Valores de cada Clave.
                            {
                                if ($z == 1) // Si $z es 1.
                                {
                                    echo "<script>array_key[" . $i . "] = '" . key($key) . "';</script>"; // Almaceno Las Tags en el Array de Tags de Javascript.
                                }
                                echo "<script>array_value[" . $i . "] = '" . $value . "';</script>"; // Almaceno Los Valores en el Array de Valores de Javascript.
                                $data[$i] = $value;
                                next($key); // Siguiente Clave.
                                $i++; // Siguiente Índice.
                            }
                        }
                    }
                    else // Si No Hay Datos.
                    {
                        echo "<script>toast(0, 'Sin Datos Aun', 'No Hay Datos de la Última Hora.');</script>"; // Mensaje No Hay Datos.
                    }
                    /* for ($j = 0; $j < $i / 9; $j++)
                    {
                        echo "<script>console.log('Las Tags Son: ' + array_key[" . $j . "]);</script>";
                    }
                    for ($j = 0; $j < $i; $j++)
                    {
                        echo "<script>console.log('Los Datos Son: ' + array_value[" . $j . "]);</script>";
                    } */
                    ?>
                    <div id="table"></div>
                    <br>
                    <span id="pages"></span>&nbsp;&nbsp;&nbsp;&nbsp;
                    <button onclick="prev()" id="prev_btn" class="btn btn-danger" style="visibility: hidden;">Anteriores Resultados</button>&nbsp;&nbsp;&nbsp;&nbsp;
                    <button onclick="next()" id="next_btn" class="btn btn-primary" style="visibility: hidden;">Siguientes Resultados</button><br>
                    <script>change(1, 8);</script>
                    <br><br><br><br>
                </div>
                <div id="view3">
                    <br><br><br><br>
                    <h3>Gráfica de Nivel de Ataque de las Conexiones Intrusas.</h3>
                    <br>

                    <div id="chart_div"></div>
                    <script>google.charts.load('current', {packages: ['corechart', 'bar']});
                        google.charts.setOnLoadCallback(drawBars);</script>

                    <div id="donutchart" style="width: 960px; height: 500px;"></div>
                    <script>google.charts.load("current", {packages:["corechart"]});
                        google.charts.setOnLoadCallback(drawDonut);</script>
                    <br><br><br>
                </div>
                <div id="view4">
                    <br><br><br><br><br><br><br>
                    <?php
                        if (isset($data))
                        {
                            echo '<h3>Exportando los Datos a Excel o CSV</h3>
                            <br>
                            <div class="col-md-5">
                            <h4>Haz Click en Ver Informe.</h4>
                            <br>
                            <form action="export.php" method="post" target="_blank">
                                <input type="hidden" name="data" value="' . htmlspecialchars(json_encode($data)) . '">
                                <input type="submit" name="index" value="Ver Informe" class="btn btn-info btn-lg">
                            </form>';
                        }
                    ?>
                    <br><br>
                    </div>
                </div>
            </div>
        <div class="col-md-1"></div>
    </div>
</section>
<?php
include "includes/footer.html";
?>