<?php
$sql = "SELECT * FROM user WHERE id=" . $_SESSION['id'] . ";";
$stmt = $conn->prepare($sql);
$stmt->execute();
if ($stmt->rowCount() > 0)
{
    $row = $stmt->fetch(PDO::FETCH_OBJ);
}
?>