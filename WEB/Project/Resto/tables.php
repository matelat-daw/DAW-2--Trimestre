<?php
if (json_decode(file_get_contents('php://input'), true))
{
	$_POST = json_decode(file_get_contents('php://input'), true);
}
include "includes/conn.php";

$tables = array();
$stmt = $conn->prepare("SELECT * FROM mesa;");
$stmt->execute();
while($row = $stmt->fetch(PDO::FETCH_OBJ))
{
    $temp = array();
    $temp['name'] = $row->name;
    array_push($tables, $temp);
}
echo json_encode($tables);
exit();

$title = "Enviando Datos a Android";
include "includes/header.php";
?>
<section class="container-fluid pt-3">
<div id="pc"></div>
    <div id="mobile"></div>
    <div class="row">
        <div class="col-md-1"></div>
            <div class="col-md-10">
                <div id="view1">
                </div>
            </div>
        <div class="col-md-1"></div>
    </div>
</section>
<?php
include "includes/footer.html";
?>