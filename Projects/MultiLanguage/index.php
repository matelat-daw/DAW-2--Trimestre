<?php

echo '<!DOCTYPE html>
<html lang="es">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title id="title">Título de la Página</title>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap/5.3.3/css/bootstrap.min.css" integrity="sha512-jnSuA4Ss2PkkikSOLtYs8BlYIeeIK1h99ty4YfvRPAlzr377vr3CXDb7sb7eEEBYjDtcYj+AjBH3FLv5uSJuXg==" crossorigin="anonymous" referrerpolicy="no-referrer" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap/5.3.3/js/bootstrap.min.js" integrity="sha512-ykZ1QQr0Jy/4ZkvKuqWn4iF3lqPZyij9iRv6sGqLRdTPkY69YX6+7wvVGmsdBbiIfN/8OdsI7HABjvEok6ZopQ==" crossorigin="anonymous" referrerpolicy="no-referrer"></script>
    <script src="js/Language.js"></script>
    <script src="js/script.js"></script>
</head>';
echo '<body>
<nav>
    <div class="col-md-12"> <!-- Columnas con el menú de navegación. -->
        <div class="nav nav-tabs" id="nav-tab" role="tablist" >
            <select id="language" onchange="language(this.value)">
            <option>Selecciona tu Idioma</option>
            <option value="spanish">Español</option>
            <option value="english">English</option>
            <option value="portuguese">Português</option>
            <option value="german">Deutsch</option>
            <option value="chinese">中國人</option>
            </select>
        </div>
    </div>
</nav>

<h1 id="html_title">Título</h1>
<br><br>
<h3 id="subtitle">SubTítulo</h3>
    <h3 id="result"></h3>
    <footer>
        <h4 id="footer_first">Primero del Footer</h4>
        <h5 id="footer_second">Segundo del Footer</h5>
    </footer>
    <script>language("spanish");</script>
</body>
</html>';
?>