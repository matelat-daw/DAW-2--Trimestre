<?php // Declara Documento de script PHP
if (json_decode(file_get_contents('php://input'), true)) // Esta linea es usada por IOS, la app para iPhone, android no la necesita, si el script está recibiendo datos, ya sea por GET o por POST.
{
	$_POST = json_decode(file_get_contents('php://input'), true); // Asigna los datos a la variable $_POST de tipo array.
}
$n = 0; // la variable $n se utiliza para multiples entradas.
if (isset($_POST["user"])) // Verifico si ha llegado algo por POST en el array $_POST["user"].
{
	// $id = $_POST["id"]; // Si hay datos, asigna a la variable $user el contenido del array $_POST["user"].
	$id = $_POST["user"]; // Hace lo mismo con el contenido de $_POST["pass"] en la variable $pass.
    $dni = $_POST["dni"];
    $surname = $_POST["surname"];
    $surname2 = $_POST["surname2"];
    $phone = $_POST["phone"];
    $email = $_POST["email"];
    $pass = $_POST["pass"];
    $bday = $_POST["bday"];
    $img = $_POST["img"];
    // move_uploaded_file($tmp, $path);
	$name = "user" . $id . ".txt"; // asigna a la variable $name un nombre de archivo "user.txt", tambien se puesde usar la variable $user y sería $name = $user . ".txt".
	$file = fopen($name, "w") or die("Unable to open file!"); // Craa un archivo para escribir en Él, con el nombre del contenido de la variable $name.
	fwrite($file, $id); // Escribe el contenido de la variable $user.
	fwrite($file, "¡"); // Escribe : en el archivo a continuación del nombre de usuario, se separa por los : para poder hacer un split posteriormente.
	fwrite($file, $dni); // Escribe la contraseña en el archivo a continuación.
    fwrite($file, "¡"); // Escribe : en el archivo a continuación del nombre de usuario, se separa por los : para poder hacer un split posteriormente.
    fwrite($file, $surname); // Escribe la contraseña en el archivo a continuación.
    fwrite($file, "¡"); // Escribe : en el archivo a continuación del nombre de usuario, se separa por los : para poder hacer un split posteriormente.
    fwrite($file, $surname2); // Escribe la contraseña en el archivo a continuación.
    fwrite($file, "¡"); // Escribe : en el archivo a continuación del nombre de usuario, se separa por los : para poder hacer un split posteriormente.
	fwrite($file, $phone); // Escribe la contraseña en el archivo a continuación.
    fwrite($file, "¡"); // Escribe : en el archivo a continuación del nombre de usuario, se separa por los : para poder hacer un split posteriormente.
	fwrite($file, $email); // Escribe la contraseña en el archivo a continuación.
    fwrite($file, "¡"); // Escribe : en el archivo a continuación del nombre de usuario, se separa por los : para poder hacer un split posteriormente.
	fwrite($file, $pass); // Escribe la contraseña en el archivo a continuación.
    fwrite($file, "¡"); // Escribe : en el archivo a continuación del nombre de usuario, se separa por los : para poder hacer un split posteriormente.
	fwrite($file, $bday); // Escribe la contraseña en el archivo a continuación.
	fclose($file); // Cierra el archivo, siempre que se abre un archivo para escritura, lectura o agregado hay que cerrarlo al final.
	$response["error"] = false; // Asigna al array $response["error"] el booleano false, será la respuesta a la llamada al servidor desde la app.;
	echo json_encode($response); // Devuelve un Jason con el array $response.
	exit(); // sale de la llamada de la app al servidor.
}
$files = glob('*.txt'); // Esta variable se usa para comprobar todos los archivos .txt que hay en la ruta actual.
while ($n < count($files)) // Mientras $n sea menor que la cantidad de archivos .txt, hace lo que está entre llaves.
{
	$name = $files[$n]; // Asigna el primer archivo .txt encontrado a la variable $name.
	$file = fopen($name, "r") or die("Unable to open file!"); // Abre el archivo para leer.
	$register = fread($file, filesize($name)); // Carga todo el contenido del archivo .txt en la variable $login.
	$array[$n] = explode("¡", $register); // crea un array que es la variable $array y le va asignando el contenido del archivo .txt según la cantidad de archivos $n, separando por los : el contenido.
	fclose($file); // Se cierra el archivo de lectura.
	echo '<form name="data' . $n . '" method="post" action="register.php">'; // Crea un formulario html con el nombre data y le concatena el número de archivos que hay $n, con el method="post" y llama al archivo login.php con action="login.php".
	echo '<input type="hidden" name="username" value="' . $array[$n][0] . '">'; // crea un input type="hidden", oculto y le pone el valor del nombre de usuario que está en la primera posición del array $array en la posición $n.
    echo '<input type="hidden" name="dni" value="' . $array[$n][1] . '">';
    echo '<input type="hidden" name="surname" value="' . $array[$n][2] . '">';
    echo '<input type="hidden" name="surname2" value="' . $array[$n][3] . '">';
    echo '<input type="hidden" name="phone" value="' . $array[$n][4] . '">';
    echo '<input type="hidden" name="email" value="' . $array[$n][5] . '">';
	echo '<input type="hidden" name="pass" value="' . $array[$n][6] . '">'; // Lo mismo con la contraseña.
    echo '<input type="hidden" name="bday" value="' . $array[$n][7] . '">';
	echo '</form>'; // Cierra la etiqueta form.
	echo '<script type="text/javascript">document.forms["data' . $n . '"].submit();</script>'; // Este script de Javascript hace un auto envío del formulario, document.forms["data' . $n . '"].submit();.
	$n++; // incrementa $n.
}
$title = "Recibiendo los Datos de Registro";
include "includes/header.php";
if ($n == 0) // Verifica en todo momento si la variable $n es 0.
{
	echo '<h1 class="color">Esperando Datos</h1>'; // Si es 0, espera datos desde la app.
}
else // Si no.
{
	echo '<h1 class="badColor">Procesando datos recibidos...</h1>'; // Informa que se están procesdando los datos recibidos.
}
?>
<button onclick="window.open('index.html')" style="width:250px; height:128px">Abrir página principal del Sitio</button> <!-- Este botón abre la página principal del sitio index.html. -->
<?php
include "includes/footer.html";
?>