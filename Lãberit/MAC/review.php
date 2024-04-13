<?php
include "includes/conn.php";
$title = "Detección de Intrusión";
include "includes/header.php";
include "includes/modal_index.html";

if (isset($_POST["ip"])) // Recibe la IP desde el script index.php por POST.
{
    $ip = $_POST['ip']; // Se la Asigna a $ip.

    exec('nmap ' . $ip . ' > data.txt'); // Ejecuta la aplicación nmap pasandole la IP y redirecciona la salida al fichero data.txt.
    $mac = loadFile($ip); // Asgina a $mac el Resultado que Devuelve la Llamada a la Función loadFile Pasándole la IP.
    if ($mac != null)
    {
        $mac_result = explode(";", $mac); // Se Explota la Cadena $mac en la Variable Array $mac_result y en la Posición 2 se Obtiene la MAC.
    }
    else
    {
        echo "<script>toast(2, 'ERROR:', 'No se Han Podido Obtener los Datos Verifica que el Disco no esté Lleno y si Tienes Permisos Para Escribir en la Carpeta del Proyecto.');</script>";
    }

    echo '<fieldset>
            <legend>Datos de la MAC Sospechosa y su IP</legend>
            <form action="review.php" method="post">
            <label><input type="text" name="mac" value="' . $mac_result[0] . '" required> MAC Address</label>
            <br><br>
            <label><input type="text" name="device" value="' . $mac_result[1] . '" required> Device Name</label>
            <br><br>
            <label><input type="text" name="port" value="' . $mac_result[2] . '"> Open Ports</label>
            <br><br>
            <label><input type="text" name="ip2" value="' . $ip . '" required> IP Address</label>
            <br><br>
            <input type="submit" value="Almacena la MAC y la IP">
            </form>
        </fieldset>';
}

if (isset($_POST["mac"])) // Entra Aquí Después de Hacer Click en el Botón Almacena la MAC y la IP de Este Mismo Script.
{
    $mac = $_POST["mac"]; // Alamcena la MAC en $mac.
    $ip = $_POST["ip2"]; // Almacena la IP en $ip.
    $device = $_POST["device"];
    $port = $_POST["port"];

    echo $mac . " - " . $ip . " - " . $port . " - " . $device;
    getOui($conn, $mac, $ip, $device, $port); // Llama a la Función getOui(), Pasándole la conexión con la base de datos, la MAC y la IP.
}

function loadFile($ip) // Carga el Fichero data.txt en Memoria y Obtiene los Datos.
{
    $mac = null;
    $filename = "data.txt"; // Asigna a $filename el valor data.txt, el nombre del fichero con los datos.
    $file = fopen($filename, "r"); // Abre pata lectura el fichero data.txt.
    if ($file) // Si se leyo.
    {
        $port_index = 0; // Índice para los Puertos.
        while (!feof($file)) // Mientras lea del fichero.
        {
            $string = fgets($file); // Asigna a $string la línea de texto leida desde el fichero.
            if (str_starts_with($string, "Nmap scan"))
            {
                $device = $string;
            }
            else if (str_starts_with($string, "PORT")) // Si la Línea contiene la palabra Open.
            {
                $port = true;
                $ports[$port_index] = fgets($file);
                while ($port)
                {
                    $port_index++;
                    $ports[$port_index] = fgets($file);
                    if(str_starts_with($ports[$port_index], "MAC Address:"))
                    {
                        $port = false;
                    }
                }
                $mac = explode(" ", $ports[$port_index]);
            }
            else if (str_starts_with($string, "MAC Address:")) // Si la string Contiene la Frase MAC Address:
            {
                $mac = explode(" ", $string); // Asigna $string a la Variable $mac.
            }
        }   
        fclose($file); // Cierra el Fichero.
        $port_number = "";
        $device_name = explode(" ", $device);
        for ($i = 0; $i < $port_index; $i++)
        {
            $port_number .= $ports[$i];
        }
        $mac[2] .= ";" . $device_name[4] . ";" . $port_number;
    }
    return $mac[2]; // Retorna la variable $mac.
}

function getOui($conn, $mac, $ip, $device, $port) // Verfifica si la MAC es Pequeña, Mediana o Grande.
{
    if ($port = "")
    {
        $port = null;
    }
    $ma_s = substr($mac, 0, 13); // Parte la Cadena $mac y Obtiene la OUI de una MAC Pequeña.
    $ma_m = substr($mac, 0, 10); // Parte la Cadena $mac y Obtiene la OUI de una MAC Mediana.
    $ma_l = substr($mac, 0, 8); // Parte la Cadena $mac y Obtiene la OUI de una MAC Grande.
    $ok = search($conn, $ma_s, $mac, $ip, $device, $port); // Verifica si es una MAC Pequeña.
    if (!$ok) // Si Devuelve false.
    {
        $ok = search($conn, $ma_m, $mac, $ip, $device, $port); // Verifica si es una MAC Mediana.
        if (!$ok) // Si Devuelve false.
        {
            $ok = search($conn, $ma_l, $mac, $ip, $device, $port); // Verifica si es una MAC Grande.
            if (!$ok) // Si se Devuelve false, Igual se Almacena la MAC y la IP en la Base de Datos, Pero se Avisa que Puede ser una MAC Aleatoria o Virtual.
            {
                echo "<script>toast(2, 'CUIDADO:', 'La MAC Detectada no es Valida, puede tratarse de una MAC Virtual o Randomizada, Android, IOS o Virtual.');</script>";
                date_default_timezone_set('Europe/London');
                $date = date('Y/m/d H:i:s A', time());
                $sql = "INSERT INTO intruder VALUES(:oui, :mac, :ip, :mark, :device, :open_ports, :private, :type, :up_date, :date, :attacks);";
                $stmt = $conn->prepare($sql);
                $stmt->execute([':oui' => $ma_l, ':mac' => $mac, ':ip' => $ip, ':mark' => "Android, IOS, Virtual", ':device' => $device, ':open_ports' => $port, ':private' => 1, ':type' => "MA_L", ':up_date' => "1970-01-01", ':date' => $date, ':attacks' => 1]);
            }
        }
    }
}

function search($conn, $oui, $mac, $ip, $device, $port)
{
    date_default_timezone_set('Europe/London');
    $date = date('Y/m/d H:i:s A', time());
    if ($port = "")
    {
        $port = null;
    }
    $sql = "SELECT * FROM mac WHERE macPrefix='$oui'";
    $stmt = $conn->prepare($sql);
    $stmt->execute();
    if ($stmt->rowCount() > 0)
    {
        $row = $stmt->fetch(PDO::FETCH_OBJ);
        $sql = "SELECT oui FROM intruder WHERE mac='$mac' AND ip='$ip';";
        $stmt = $conn->prepare($sql);
        $stmt->execute();
        if ($stmt->rowCount() > 0)
        {
            $sql = "UPDATE intruder SET attacks = attacks + 1, date = NOW() WHERE oui='$oui';";
            $stmt = $conn->prepare($sql);
            $stmt->execute();
            echo "<script>toast(1, 'ALERTA:', 'Se Ha Detectado un Ataque de una MAC ya Registrada.<br>Tomen las Precauciones Necesarias.');</script>";
        }
        else
        {
            $sql = "SELECT oui FROM intruder WHERE ip='$ip';";
            $stmt = $conn->prepare($sql);
            $stmt->execute();
            if ($stmt->rowCount() > 0)
            {
                $sql = "INSERT INTO intruder VALUES(:oui, :mac, :ip, :mark, :device, :open_ports, :private, :type, :up_date, :date, :attacks);";
                $stmt = $conn->prepare($sql);
                $stmt->execute([':oui' => $row->macPrefix, ':mac' => $mac, ':ip' => $ip, ':mark' => $row->vendorName, ':device' => $device, ':open_ports' => $port, ':private' => $row->private, ':type' => $row->blockType, ':up_date' => $row->lastUpdate, ':date' => $date, ':attacks' => 1]);
                echo "<script>toast(1, 'ALERTA:', 'Se Ha Detectado un Ataque de una IP ya Registrada pero asignada a otra MAC.<br>Tomen las Precauciones Necesarias.');</script>";
            }
            else
            {
                $result = $row->macPrefix . " - " . $row->vendorName . " - " . $row->private . " - " . $row->blockType . " - " . $row->lastUpdate;
                echo "<script>toast(0, 'Resultado:', 'Se ha Encontrado la MAC en la Base de Datos.<br>Estos son los datos de la MAC:<br>$result<br><br>Se Han Agregado los Datos a la Base de Datos.');</script>";
                $sql = "INSERT INTO intruder VALUES(:oui, :mac, :ip, :mark, :device, :open_ports, :private, :type, :up_date, :date, :attacks);";
                $stmt = $conn->prepare($sql);
                $stmt->execute([':oui' => $row->macPrefix, ':mac' => $mac, ':ip' => $ip, ':mark' => $row->vendorName, ':device' => $device, ':open_ports' => $port, ':private' => $row->private, ':type' => $row->blockType, ':up_date' => $row->lastUpdate, ':date' => $date, ':attacks' => 1]);
            }
        }
        return true; // Devuelve true si almecenó en la Base de Datos los datos Buscados.
    }
    else // So No.
    {
        return false; // Devuelve False, se ha detectado una MAC Aleatoria o Virtual.
    }
}
?>