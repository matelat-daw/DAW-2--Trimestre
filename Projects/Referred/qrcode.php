<form action="exit.php" method="post">
<?php


$good_url = urlencode('http://localhost/Referrer/server.php?user=' . $id_user . '&business=' . $id_business . '&ammount=' . $ammount . '&invoice='. $invoice);
    // A la variable $good_url le asigno la url, urlencode, que se enviará al servicio que recoge las entradas a medida que van entrando al evento los espectadores.

echo '<input id="code" type="hidden" name="qr" value="' . $good_url . '">
    <input id="here" type="hidden" name="code">
    <input type="hidden" name="id_user" value="' . $id_user . '">
    <input type="hidden" name="id_business" value="' . $id_business . '">
    <input type="hidden" name="ammount' . $i . '" value="' . $ammount . '">
    <input type="hidden" name="invoice" value="' . $invoice . '">
    <input id="btn" type="submit" value="Aquí están tus Entradas" style="visibility: hidden;" class="btn btn-primary btn-lg">
    <script>QRGen();</script>"'; // Llamo a la función que obtiene el código QR desde el servicio que ofrece Google.
?>
</form>