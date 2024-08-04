<nav class="madium great navbar fixed-top bg-white"> <!-- Menú de Usuario de PC o Tablet. -->
    <div class="row">
        <div class="col-md-6"> <!-- Columnas con el menú de navegación. -->
            <div class="nav nav-tabs" id="nav-tab" role="tablist" style="margin-top: 80px;">
                <a class="nav-link" aria-current="page" href="javascript:show('modify')" aria-selected="false" role="tab" aria-controls="nav-contact">Modifico Mis Datos</a></li>
                <a class="nav-link" aria-current="page" href="javascript:show('quit')" aria-selected="false" role="tab" aria-controls="nav-contact">Elimino Mi Perfil</a></li>
                <a class="nav-link" aria-current="page" href="logout.php" aria-selected="false" role="tab" aria-controls="nav-contact">Cierro Sesión</a></li>
            </div>
        </div>
        <div class="col-md-6 nav-tabs">
            <div style="float: right; margin-right: 15px;">
                <h3 style="display: inline-block">Te damos la Bienvenida: <span><?php echo  $row->name . " " . $row->surname; ?></span></h3>
                <img alt="Foto de Perfil" src="<?php echo $row->path; ?>" width="160" height="120">
            </div>
        </div>
    </div>
</nav>