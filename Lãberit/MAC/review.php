<?php
include "includes/conn.php";
$title = "Detección de Intrusión";
include "includes/header.php";
include "includes/modal_index.html";

if (isset($_POST["ip"])) // Recibe la IP desde el script index.php por POST.
{
    $ip = $_POST['ip']; // Se la Asigna a $ip.
    exec('rustscan -a ' . $ip . ' > data.txt'); // Ejecuta la aplicación rustscan pasandole la IP con el modificador -a y redirecciona la salida al fichero data.txt.

    $mac = loadFile($ip); // Asgina a $mac el Resultado que Devuelve la Llamada a la Función loadFile Pasándole la IP.

    if ($mac != "") // Si $mac no Está Vacia.
    {
        $mac_result = explode(" ", $mac); // Se Explota la Cadena $mac en la Variable Array $mac_result y en la Posición 2 se Obtiene la MAC.
    }
    else // Si Está Vacia.
    {
        exec('nmap ' . $ip . ' > data.txt'); // Ejecuta la aplicación nmap pasandole la IP y redirecciona la salida al fichero data.txt.
        $mac = loadFile($ip); // Asgina a $mac el Resultado que Devuelve la Llamada a la Función loadFile Pasándole la IP.
        $mac_result = explode(" ", $mac); // Se Explota la Cadena $mac en la Variable Array $mac_result y en la Posición 2 se Obtiene la MAC.
    }

    echo '<fieldset>
            <legend>Datos de la MAC Sospechosa y su IP</legend>
            <form action="review.php" method="post">
            <label><input type="text" name="mac" value="' . $mac_result[2] . '" required> MAC Address</label>
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
    getOui($conn, $mac, $ip); // Llama a la Función getOui(), Pasándole la conexión con la base de datos, la MAC y la IP.
}

function loadFile($ip) // Carga el Fichero data.txt en Memoria y Obtiene los Datos.
{
    $filename = "data.txt"; // Asigna a $filename el valor data.txt, el nombre del fichero con los datos.
    $file = fopen($filename, "r"); // Abre pata lectura el fichero data.txt.
    if ($file) // Si se leyo.
    {
        $mac = "";
        $port_index = 0; // Índice para los Puertos.
        while (!feof($file)) // Mientras lea del fichero.
        {
            $string = fgets($file); // Asigna a $string la línea de texto leida desde el fichero.
            if (str_starts_with($string, "Open")) // Si la Línea contiene la palabra Open.
            {
                $ports[$port_index] = $string; // Asigna el Contenido de la Línea al Array de Puertos $ports[$port_index], por si hay más de un Puerto Abierto, ¡OJO! Aun no Usado.
                $port_index++; // Incrementa el Índice para los Puertos.
            }
            else if (str_starts_with($string, "MAC Address:")) // Si la string Contiene la Frase MAC Address:
            {
                $mac = $string; // Asigna $string a la Variable $mac.
            }
        }   
        fclose($file); // Cierra el Fichero.
    }
    return $mac; // Retorna la variable $mac.
}

function getOui($conn, $mac, $ip) // Verfifica si la MAC es Pequeña, Mediana o Grande.
{
    $ma_s = substr($mac, 0, 13); // Parte la Cadena $mac y Obtiene la OUI de una MAC Pequeña.
    $ma_m = substr($mac, 0, 10); // Parte la Cadena $mac y Obtiene la OUI de una MAC Mediana.
    $ma_l = substr($mac, 0, 8); // Parte la Cadena $mac y Obtiene la OUI de una MAC Grande.
    $ok = search($conn, $ma_s, $mac, $ip); // Verifica si es una MAC Pequeña.
    if (!$ok) // Si Devuelve false.
    {
        $ok = search($conn, $ma_m, $mac, $ip); // Verifica si es una MAC Mediana.
        if (!$ok) // Si Devuelve false.
        {
            $ok = search($conn, $ma_l, $mac, $ip); // Verifica si es una MAC Grande.
            if (!$ok) // Si se Devuelve false, Igual se Almacena la MAC y la IP en la Base de Datos, Pero se Avisa que Puede ser una MAC Aleatoria o Virtual.
            {
                echo "<script>toast(2, 'CUIDADO:', 'La MAC Detectada no es Valida, puede tratarse de una MAC Virtual o Randomizada, Android, IOS o Virtual.');</script>";
                date_default_timezone_set('Europe/London');
                $date = date('Y/m/d H:i:s A', time());
                $sql = "INSERT INTO intruder VALUES(:oui, :mac, :ip, :mark, :private, :type, :up_date, :date, :attacks);";
                $stmt = $conn->prepare($sql);
                $stmt->execute([':oui' => $ma_l, ':mac' => $mac, ':ip' => $ip, ':mark' => "Android, IOS, Virtual", ':private' => 1, ':type' => "MA_L", ':up_date' => "1970-01-01", ':date' => $date, ':attacks' => 1]);
            }
        }
    }
}

function search($conn, $oui, $mac, $ip)
{
    date_default_timezone_set('Europe/London');
    $date = date('Y/m/d H:i:s A', time());
    $sql = "SELECT * FROM mac WHERE macPrefix='$oui'";
    $stmt = $conn->prepare($sql);
    $stmt->execute();
    if ($stmt->rowCount() > 0)
    {
        $row = $stmt->fetch(PDO::FETCH_OBJ);
        $oui = $row->macPrefix;
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
                $sql = "INSERT INTO intruder VALUES(:oui, :mac, :ip, :mark, :private, :type, :up_date, :date, :attacks);";
                $stmt = $conn->prepare($sql);
                $stmt->execute([':oui' => $row->macPrefix, ':mac' => $mac, ':ip' => $ip, ':mark' => $row->vendorName, ':private' => $row->private, ':type' => $row->blockType, ':up_date' => $row->lastUpdate, ':date' => $date, ':attacks' => 1]);
                echo "<script>toast(1, 'ALERTA:', 'Se Ha Detectado un Ataque de una IP ya Registrada pero asignada a otra MAC.<br>Tomen las Precauciones Necesarias.');</script>";
            }
            else
            {
                $result = $row->macPrefix . " - " . $row->vendorName . " - " . $row->private . " - " . $row->blockType . " - " . $row->lastUpdate;
                echo "<script>toast(0, 'Resultado:', 'Se ha Encontrado la MAC en la Base de Datos.<br>Estos son los datos de la MAC:<br>$result<br><br>Se Han Agregado los Datos a la Base de Datos.');</script>";
                $sql = "INSERT INTO intruder VALUES(:oui, :mac, :ip, :mark, :private, :type, :up_date, :date, :attacks);";
                $stmt = $conn->prepare($sql);
                $stmt->execute([':oui' => $row->macPrefix, ':mac' => $mac, ':ip' => $ip, ':mark' => $row->vendorName, ':private' => $row->private, ':type' => $row->blockType, ':up_date' => $row->lastUpdate, ':date' => $date, ':attacks' => 1]);
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