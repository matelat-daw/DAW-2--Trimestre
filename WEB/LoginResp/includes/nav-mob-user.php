<nav class="mini navbar fixed-top bg-white"> <!-- Menú de usuario de dispositivos móviles. -->
    <h3 style="display: inline-block">Te damos la Bienvenida: <span><?php echo  $row->name . " " . $row->surname; ?></span></h3>
    <img alt="Foto de Perfil" src="<?php echo $row->path; ?>" width="160" height="120">
    <a class="nav-link" aria-current="page" href="logout.php" aria-selected="false" role="tab" aria-controls="nav-contact">Cierro Sesión</a></li>
</nav>