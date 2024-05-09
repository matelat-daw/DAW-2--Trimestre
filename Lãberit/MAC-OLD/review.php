<?php
require "vendor/autoload.php";
include "includes/conn.php";
$title = "Detección de Intrusión";
include "includes/header.php";
include "includes/modal_index.html";

use InfluxDB2\Model\WritePrecision;

if (isset($_POST["ip"])) // Recibe la IP desde el script index.php por POST.
{
    $ip = $_POST['ip']; // Se la Asigna a $ip.
    $mac = $_POST["mac"];
    $local_port = $_POST["local_port"];
    $remote_port = $_POST["remote_port"];
    $protocol = $_POST["protocol"];
    $length = $_POST["packet"];

    $oui = get_device($conn, $mac); // Llama a la Función get_device($conn, $mac), Pasándole la conexión con la base de datos y la MAC.

    $sql = "SELECT vendorName FROM mac WHERE macPrefix='$oui'"; // Obtenemos la Marca del Dispositivo de la Base de Datos MariaDB.
    $stmt = $conn->prepare($sql);
    $stmt->execute();
    if ($stmt->rowCount() > 0)
    {
        $row = $stmt->fetch(PDO::FETCH_OBJ);
        $mark = $row->vendorName;
        $private = false;
    }
    else
    {
        $mark = "Android, IOS, Virtual";
        $oui = $mac;
        $private = true;
    }

    $query = "from(bucket: \"MACDB\") |> range(start: -6d) |> filter(fn: (r) => r._measurement == \"intruder\")"; // Consulta a InfluxDB.
    $tables = $client->createQueryApi()->query($query, $org); // Ejecuta la Consulta.
    $records = [];
    foreach ($tables as $table)
    {
        foreach ($table->records as $record)
        {
            $tag = ["ip" => $record->getRecordValue("ip"), "mac" => $record->getRecordValue("mac")]; // En la Varible de tipo array $tag, pusimos todos los tags y sus valores.
            $row = key_exists($record->getTime(), $records) ? $records[$record->getTime()] : []; // Este operador ternario asigna a $row los datos en InfluxDB.
            $records[$record->getTime()] = array_merge($row, $tag); // Hacemos un array_merge con los datos de toda la tupla.
        }
    }

    $i = 0;
    $j = 0;
    $odd = 0;
    $z = 0;
    $array_key = [];
    $array_value = [];
    foreach($records as $key) // Bucle para Obtener las Keys.
    {
        $z++;
        foreach ($key as $value) // Bucle para Obtener los Valores.
        {
            if ($z == 1)
            {
                $array_key[$i] = key($key); // Las Tags.
            }
            if ($odd % 2 == 0)
            {
                $array_ip[$i] = $value; // Los Valores.
                next($key); // Siguiente Clave.
                $i++; // Siguiente Índice.
                $odd++;
            }
            else
            {
                $array_mac[$j] = $value; // Los Valores.
                next($key); // Siguiente Clave.
                $j++; // Siguiente Índice.
                $odd++;
            }
        }
    }

    $same_mac = false;
    $same_mac_ip = false;
    $time_index = 0;

    for ($i = 0; $i < count($array_ip); $i++)
    {
        if ($mac == $array_mac[$i])
        {
            $same_mac = true;
            $time_index = $i;
            if ($ip == $array_ip[$i])
            {
                $same_mac_ip = true;
                $time_index = $i;
            }
        }
    }

    if ($same_mac && $same_mac_ip)
    {
        echo "EUREKA, Has Detectado Un Nuevo Ataque de una MAC con la Misma IP.";
        $time = getTime($time_index, $records);
        $sec_time = date("U", strtotime($time));
        $writeApi = $client->createWriteApi();
        $data = "intruder,ip=$ip,mac=$mac,protocol=$protocol,localPort=$local_port,remotePort=$remote_port,oui=$oui mark=\"$mark\",length=$length,attack=2 $sec_time"; // Los Tags en Influx no pueden tener espacios.
        $writeApi->write($data, WritePrecision::S, $bucket, $org);
    }
    else if ($same_mac)
    {
        echo "Nuevo Ataque de una Misma MAC";
        $time = getTime($time_index, $records);
        $sec_time = date("U", strtotime($time));
        $writeApi = $client->createWriteApi();
        $data = "intruder,ip=$ip,mac=$mac,protocol=$protocol,localPort=$local_port,remotePort=$remote_port,oui=$oui mark=\"$mark\",length=$length,attack=2 $sec_time"; // Los Tags en Influx no pueden tener espacios.
        $writeApi->write($data, WritePrecision::S, $bucket, $org);
    }
    else
    {
        $writeApi = $client->createWriteApi();
        $data = "intruder,ip=$ip,mac=$mac,protocol=$protocol,localPort=$local_port,remotePort=$remote_port,oui=$oui mark=\"$mark\",length=$length,attack=1"; // Los Tags en Influx no pueden tener espacios.
        $writeApi->write($data, WritePrecision::S, $bucket, $org);
    }

    /* $writeApi = $client->createWriteApi();
    $data = "intruder,ip=$ip,mac=$mac,protocol=$protocol,localPort=$local_port,remotePort=$remote_port,oui=$oui mark=\"$mark\",length=$length,attack=1"; // Los Tags en Influx no pueden tener espacios.
    $writeApi->write($data, WritePrecision::S, $bucket, $org); */

    $client->close();

    // echo "<script>toast(0, 'Datos Agregados', 'Se Han Agregado Datos a InfluxDB.');</script>";
}

function getTime($index, $records)
{
    for ($i = 0; $i < $index; $i++)
    {
        next($records);
    }
    return key($records);
}

// function loadFile($ip) // Carga el Fichero data.txt en Memoria y Obtiene los Datos.
// {
//     $mac = [];
//     $ports = [];
//     $filename = "data.txt"; // Asigna a $filename el valor data.txt, el nombre del fichero con los datos.
//     $file = fopen($filename, "r"); // Abre pata lectura el fichero data.txt.
//     if ($file) // Si se leyo.
//     {
//         $port_index = 0; // Índice para los Puertos.
//         while (!feof($file)) // Mientras lea del fichero.
//         {
//             try
//             {
//                 $string = fgets($file); // Asigna a $string la línea de texto leida desde el fichero.
//                 if (str_starts_with($string, "Nmap scan")) // Si la cadena obtenida en $string empieza por la frase 'Nmap scan'.
//                 {
//                     $device = $string; // Asigna la cadena a la variable $device, la cadena contiene el nombre del dispositivo.
//                 }
//                 else if (str_starts_with($string, "PORT")) // Si la Línea contiene la palabra PORT, es que hay al menos un puerto abierto.
//                 {
//                     $port_bool = true; // Variable booleana $port, para comprobar cuando no hay más puertos abiertos.
//                     $ports[$port_index] = fgets($file); // Se asigna a $ports en el índice $port_index la lectura de la siguiente fila del Fichero data.txt, contiene un puerto abierto.
//                     while ($port_bool) // Mientras $port sea true
//                     {
//                         $port_index++; // Incrementa el Índice $port_index.
//                         $ports[$port_index] = fgets($file); // Se asigna a $ports en el índice $port_index la lectura de la siguiente fila del Fichero data.txt.
//                         if(str_starts_with($ports[$port_index], "MAC Address:")) // Si el contenido del Array $ports en el índice $port_index empieza por la frase 'MAC Address:'.
//                         {
//                             $port_bool = false; // Ya no hay más puertos abiertos, pongo $port a false, al volver al while como $port es false sale del bucle.
//                             $mac = explode(" ", $ports[$port_index]);
//                         }
//                     }
//                 }
//                 else if (str_starts_with($string, "MAC Address:")) // Si la string Contiene la Frase MAC Address:
//                 {
//                     $mac = explode(" ", $string); // Asigna $string a la Variable Array $mac explotándola por el espacio, obteniendo en la posición 2 del array la dirección MAC.
//                 }
//             }
//             catch(Exception $e)
//             {
//                 echo "<script>console.log('Algo Fallo.')</script>";
//                 fclose($file); // Cierra el Fichero.
//                 echo "<script>toast(1, 'Error con el Fichero:', 'Sucedió algo Inesperado, el Error es: ' + " . $e->getMessage() . ");</script>";
//             }
//         }   
//         fclose($file); // Cierra el Fichero.
//         $port_number = ""; // Asigna un valor vacio a la variable $port_number.
//         $device_name = explode(" ", $device); // Explota la cadena $device en la variable Array $device_name y obtiene en la posición 4 del array el nombre del dispositivo.
//         for ($i = 0; $i < count($ports); $i++) // Bucle al tamaño del Array $ports.
//         {
//             $port_number .= $ports[$i]; // Concatena en la variable $port_number los puertos en el Array $ports.
//         }
//         $mac[2] .= ";" . $device_name[4] . ";" . $port_number; // Concatena a la posición 2 del Array $mac, que contiene la dirección MAC, el contenido del Array $device_name en la posición 4 que es el nombre del dispositivo y la string $port_number que contiene los puertos abiertos en el dispositivo.
//     }
//     return $mac[2]; // Retorna la posición 2 variable Array $mac.
// }

// function getOui($conn, $mac, $ip, $device, $port) // Verfifica si la MAC es Pequeña, Mediana o Grande.
// {
//     if ($port == "") // Si la variable que se pasa por parámetro $port está vacia, el dipositivo no tiene ningún peurto abierto.
//     {
//         $port = null; // Se pone la variable $port a null.
//     }
//     $ma_s = substr($mac, 0, 13); // Parte la Cadena $mac y Obtiene la OUI de una MAC Pequeña.
//     $ma_m = substr($mac, 0, 10); // Parte la Cadena $mac y Obtiene la OUI de una MAC Mediana.
//     $ma_l = substr($mac, 0, 8); // Parte la Cadena $mac y Obtiene la OUI de una MAC Grande.
//     $ok = search($conn, $ma_s, $mac, $ip, $device, $port); // Verifica si es una MAC Pequeña.
//     if (!$ok) // Si Devuelve false.
//     {
//         $ok = search($conn, $ma_m, $mac, $ip, $device, $port); // Verifica si es una MAC Mediana.
//         if (!$ok) // Si Devuelve false.
//         {
//             $ok = search($conn, $ma_l, $mac, $ip, $device, $port); // Verifica si es una MAC Grande.
//             if (!$ok) // Si se Devuelve false, Igual se Almacena la MAC, la IP y el nombre del dispositivo en la Base de Datos, Pero se Avisa que Puede ser una MAC Aleatoria o Virtual.
//             {
//                 $sql = "SELECT oui FROM intruder WHERE mac='$mac' AND ip='$ip';"; // Sentencia SQL para Verificar si la MAC y la IP del dispositivo ya habían intentado un ataque.
//                 $stmt = $conn->prepare($sql);
//                 $stmt->execute();
//                 if ($stmt->rowCount() > 0) // Si ya había un ataque de esa MAC con esa IP.
//                 {
//                     $oui = substr($mac, 0, -9);
//                     $sql = "UPDATE intruder SET attacks = attacks + 1, date = NOW() WHERE oui='$oui';"; // Se actualiza la tabla de Ataques incrementando el campo attacks y Actualizando la fecha y hora.
//                     $stmt = $conn->prepare($sql);
//                     $stmt->execute();
//                     echo "<script>toast(1, 'ALERTA:', 'Se Ha Detectado un Ataque de una MAC con una IP ya Registradas.<br>Tomen las Precauciones Necesarias.');</script>"; // Se muestra una alerta que se repite un ataque de un dispositvo que ya había atacado en el pasado.
//                 }
//                 else
//                 {
//                     echo "<script>toast(2, 'CUIDADO:', 'La MAC Detectada no es Valida, puede tratarse de una MAC Virtual o Randomizada, Android, IOS o Virtual.');</script>";
//                     date_default_timezone_set('Europe/London');
//                     $date = date('Y/m/d H:i:s A', time());
//                     $sql = "INSERT INTO intruder VALUES(:oui, :mac, :ip, :mark, :device, :open_ports, :private, :type, :up_date, :date, :attacks);";
//                     $stmt = $conn->prepare($sql);
//                     $stmt->execute([':oui' => $ma_l, ':mac' => $mac, ':ip' => $ip, ':mark' => "Android, IOS, Virtual", ':device' => $device, ':open_ports' => $port, ':private' => 1, ':type' => "MA_L", ':up_date' => "1970-01-01", ':date' => $date, ':attacks' => 1]);
//                 }
//             }
//         }
//     }
// }

// function search($conn, $oui, $mac, $ip, $device, $port) // Función para comprobar si la Dirección MAC pertenece a una MAC Registrada por el IEEE.
// {
//     date_default_timezone_set('Europe/London'); // Zona Horario Europa Londres.
//     $date = date('Y/m/d H:i:s A', time()); // Formato de Fecha para MariaDB.
//     if ($port == "") // Si la variable que se pasa por parámetro $port está vacia, el dipositivo no tiene ningún peurto abierto.
//     {
//         $port = null; // Se pone la variable $port a null.
//     }
//     $sql = "SELECT * FROM mac WHERE macPrefix='$oui'"; // Se obtienen todos los datos de las OUI (Organizationally Unique Identifier) que coicidan con la OUI pasada como parámetro.
//     $stmt = $conn->prepare($sql); // Se prepara la Consulta.
//     $stmt->execute(); // Se Ejecuta.
//     if ($stmt->rowCount() > 0) // Si se Obtienen Resultados.
//     {
//         $row = $stmt->fetch(PDO::FETCH_OBJ); // Se asigna la tupla a la variable $row.
//         $sql = "SELECT oui FROM intruder WHERE mac='$mac' AND ip='$ip';"; // Sentencia SQL para Verificar si la MAC y la IP del dispositivo ya habían intentado un ataque.
//         $stmt = $conn->prepare($sql);
//         $stmt->execute();
//         if ($stmt->rowCount() > 0) // Si ya había un ataque de esa MAC con esa IP.
//         {
//             $sql = "UPDATE intruder SET attacks = attacks + 1, date = NOW() WHERE oui='$oui';"; // Se actualiza la tabla de Ataques incrementando el campo attacks y Actualizando la fecha y hora.
//             $stmt = $conn->prepare($sql);
//             $stmt->execute();
//             echo "<script>toast(1, 'ALERTA:', 'Se Ha Detectado un Ataque de una MAC con una IP ya Registradas.<br>Tomen las Precauciones Necesarias.');</script>"; // Se muestra una alerta que se repite un ataque de un dispositvo que ya había atacado en el pasado.
//         }
//         else // Si no hay coicidencia.
//         {
//             $sql = "SELECT oui FROM intruder WHERE mac='$mac';"; // Se verifica si la MAC ya está en la Base de Datos de Ataques.
//             $stmt = $conn->prepare($sql);
//             $stmt->execute();
//             if ($stmt->rowCount() > 0) // Si hay resultados.
//             {
//                 $sql = "INSERT INTO intruder VALUES(:oui, :mac, :ip, :mark, :device, :open_ports, :private, :type, :up_date, :date, :attacks);"; // Se inserta como un nuevo dispositivo.
//                 $stmt = $conn->prepare($sql);
//                 $stmt->execute([':oui' => $row->macPrefix, ':mac' => $mac, ':ip' => $ip, ':mark' => $row->vendorName, ':device' => $device, ':open_ports' => $port, ':private' => $row->private, ':type' => $row->blockType, ':up_date' => $row->lastUpdate, ':date' => $date, ':attacks' => 1]);
//                 echo "<script>toast(1, 'ALERTA:', 'Se Ha Detectado un Ataque de una MAC ya Registrada pero con otra IP asignada.<br>Tomen las Precauciones Necesarias.');</script>"; // Se avisa que el ataque se produjo de una IP que ya estaba registrada.
//             }
//             else // Si No.
//             {
//                 $result = $row->macPrefix . " - " . $row->vendorName . " - " . $row->private . " - " . $row->blockType . " - " . $row->lastUpdate;
//                 echo "<script>toast(0, 'Resultado:', 'Se ha Encontrado la MAC en la Base de Datos.<br>Estos son los datos de la MAC:<br>$result<br><br>Se Han Agregado los Datos a la Base de Datos.');</script>"; // Se Muestra que la MAC está en la Base de Datos de Fabricantes conocidos y se agregan todos los datos.
//                 $sql = "INSERT INTO intruder VALUES(:oui, :mac, :ip, :mark, :device, :open_ports, :private, :type, :up_date, :date, :attacks);";
//                 $stmt = $conn->prepare($sql);
//                 $stmt->execute([':oui' => $row->macPrefix, ':mac' => $mac, ':ip' => $ip, ':mark' => $row->vendorName, ':device' => $device, ':open_ports' => $port, ':private' => $row->private, ':type' => $row->blockType, ':up_date' => $row->lastUpdate, ':date' => $date, ':attacks' => 1]);
//             }
//         }
//         return true; // Devuelve true si almecenó en la Base de Datos los datos Buscados.
//     }
//     else // Si No.
//     {
//         return false; // Devuelve False, se ha detectado una MAC Aleatoria o Virtual.
//     }
// }

function get_device($conn, $mac)
{
    $ma_s = substr($mac, 0, 13); // Parte la Cadena $mac y Obtiene la OUI de una MAC Pequeña.
    $ma_m = substr($mac, 0, 10); // Parte la Cadena $mac y Obtiene la OUI de una MAC Mediana.
    $ma_l = substr($mac, 0, 8); // Parte la Cadena $mac y Obtiene la OUI de una MAC Grande.
    
    $sql = "SELECT * FROM mac WHERE macPrefix='$ma_s' UNION SELECT * FROM mac WHERE macPrefix='$ma_m' UNION SELECT * FROM mac WHERE macPrefix='$ma_l' LIMIT 1;"; // Busco en la Base de Datos MariaDB.
    $stmt = $conn->prepare($sql); // Prepara la Consulta.
    $stmt->execute(); // La Ejecuta.
    if ($stmt->rowCount() > 0) // Si se Obtienen Resultados.
    {
        $row = $stmt->fetch(PDO::FETCH_OBJ);
        $oui = $row->macPrefix;
        return $oui; // Devuelva la OUI del Fabricante (la Marca del Dispositivo).
    }
    else // Si No.
    {
        return null;
    }
}
?>