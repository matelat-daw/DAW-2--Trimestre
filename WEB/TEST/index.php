<?php
include "includes/conn.php";
?>
<!DOCTYPE html>
<html lang="es">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Testing Things</title>
    <link rel="stylesheet" href="css/style.css">
    <script src="js/script.js"></script>
</head>
<body>
    <?php
        // $sql = "INSERT INTO test VALUES(true);";
        // $stmt = $conn->prepare($sql);
        // $stmt->execute();
    ?>
    <div style="padding: 5%;">
        <span class="small">César Título</span>
        <span class="med">123456</span>
        <span class="large">7890</span>
        <span class="xlarge">Ñandú</span>
        <h3 id="h3">HOLA</h3>
        <button id="btn" onclick="change('CHAU')">Cambia el Saludo</button>
    </div>
</body>
</html>