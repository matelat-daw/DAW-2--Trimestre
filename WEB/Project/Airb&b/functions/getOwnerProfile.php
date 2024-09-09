<?php // Esta función recupera todos los datos del usuario según su ID, una vez abierta la sesión de usuario(una vez loguedo).
$sql = "SELECT * FROM owner WHERE owner_dni='" . $_SESSION['id'] . "';";
$stmt = $conn->prepare($sql);
$stmt->execute();
if ($stmt->rowCount() > 0)
{
    $row = $stmt->fetch(PDO::FETCH_OBJ);
}
?>