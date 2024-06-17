<?php

?>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Probando Cosas</title>
    <link rel="stylesheet" href="css/style.css">
</head>
<body>
    <?php
        const CONSTANT = 3.14159; // Constante en PHP.
        define ("NEPER", 2.718281828); // Constante en PHP.
        $string = "Hola Mundo!";
        $first = $string[0];
        echo $first;
        echo "<br>";
        echo strlen($string);
        print "<ul>\n<li>Uno</li>\n<li>Dos</li>\n</ul>";
        print "<ul><li>Uno</li><li>Dos</li></ul>";
        echo CONSTANT;
        echo "<br>" . NEPER;
    ?>
    <footer class="bottom">
        <hr SIZE=11 NOSHADE WIDTH="95%">
        <i>Copyright © 2019-2020 Alguien</i></font><br>
        <i>ES MIO</i></font><br>
        <i>URL: http://www.miweb.es</i></font><br>
    </footer>
</body>
</html>