<?php
require "Influx/autoload.php";
include "includes/conn.php";
$title = "Detección de Intrusión";
include "includes/header.php";
include "includes/modal_index.html";

use InfluxDB2\Model\WritePrecision;

if (isset($_POST["data"])) // Recibe la IP y los Demás Datos desde el script index.php por POST.
{
    $data = json_decode($_POST["data"]);
    $j = 0;

    for ($i = 0; $i < count($data); $i+=16)
    {
        $oui = get_device($conn, $data[$i][0]); // Llama a la Función get_device($conn, $mac), Pasándole la conexión con la base de datos y la MAC.

        if ($oui != null)
        {
            $sql = "SELECT vendorName FROM mac WHERE macPrefix='$oui'"; // Obtenemos la Marca del Dispositivo de la Base de Datos MariaDB.
            $stmt = $conn->prepare($sql);
            $stmt->execute();
            if ($stmt->rowCount() > 0)
            {
                $row = $stmt->fetch(PDO::FETCH_OBJ);
                $mark = $row->vendorName;
                $private = false;
            }
        }
        else
        {
            $mark = "Android, IOS, Virtual";
            $oui = $data[$j][$i];
            $private = true;
        }
        $writeApi = $client->createWriteApi();
        $save = 'aintrusa,mac=' . $data[$j][$i] . ' qtty=' . $data[$j][$i + 1] . ',uni=' . $data[$j][$i + 2] . ',multi=' . $data[$j][$i + 3] . ',broad=' . $data[$j][$i + 4] . ',arp=' . $data[$j][$i + 5] . ',traffic=' . $data[$j][$i + 6] . ',icmp=' . $data[$j][$i + 7] . ',tcp=' . $data[$j][$i + 8] . ',udp=' . $data[$j][$i + 9] . ',resto=' . $data[$j][$i + 10] . ',ipv6=' . $data[$j][$i + 11] . ',arp46=' . $data[$j][$i + 12] . ',badip=' . $data[$j][$i + 13] . ',ssdp=' . $data[$j][$i + 14] . ',icmp6=' . $data[$j][$i + 15]; // Los Tags en Influx no pueden tener espacios.
        $j++;
        $writeApi->write($save, WritePrecision::S, $bucket, $org);
    }

    $client->close();

    echo "<script>toast(0, 'Datos Agregados', 'Se Han Agregado Datos a InfluxDB.');</script>";
}

function get_device($conn, $mac)
{
    $ma_s = substr($mac, 0, 13); // Parte la Cadena $mac y Obtiene la OUI de una MAC Pequeña.
    $ma_m = substr($mac, 0, 10); // Parte la Cadena $mac y Obtiene la OUI de una MAC Mediana.
    $ma_l = substr($mac, 0, 8); // Parte la Cadena $mac y Obtiene la OUI de una MAC Grande.
    
    $sql = "SELECT * FROM mac WHERE macPrefix='$ma_s' UNION SELECT * FROM mac WHERE macPrefix='$ma_m' UNION SELECT * FROM mac WHERE macPrefix='$ma_l' LIMIT 1;"; // Reemplazo el Query SQL por un Storage Procedure.
    $stmt = $conn->prepare($sql); // Se prepara la Consulta.
    $stmt->execute(); // Se Ejecuta.
    if ($stmt->rowCount() > 0) // Si se Obtienen Resultados.
    {
        $row = $stmt->fetch(PDO::FETCH_OBJ);
        $oui = $row->macPrefix;
        return $oui;
    }
    else
    {
        return null;
    }
}
?>