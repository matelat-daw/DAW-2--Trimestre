<nav class="navbar fixed-top bg-white" id="pc">
    <div class="col-md-6"> <!-- Columnas con el menú de navegación. -->
        <div class="nav nav-tabs" id="nav-tab" role="tablist" style="margin-top: 80px;">
            <a class="nav-link" aria-current="page" href="javascript:show('modify_owner')" aria-selected="false" role="tab" aria-controls="nav-contact">Modifico Mis Datos</a></li>
            <a class="nav-link" aria-current="page" href="javascript:show('quit_owner')" aria-selected="false" role="tab" aria-controls="nav-contact">Elimino Mi Perfil</a></li>
            <a class="nav-link" aria-current="page" href="logout.php" aria-selected="false" role="tab" aria-controls="nav-contact">Cierro Sesión</a></li>
        </div>
    </div>
    <div class="col-md-6 nav-tabs">
        <h3 style="display: inline-block">Te damos la Bienvenida: <span><?php echo  $row->owner_name . " " . $row->owner_surname; ?></span></h3>
        <img alt="Foto de Perfil" src="<?php echo $row->owner_path; ?>" width="160" height="120">
    </div>
</nav>