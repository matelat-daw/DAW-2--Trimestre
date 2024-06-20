<br><br>
<h1>Bienvenido a la WEB de Referidos</h1>
<br><br>
<h5>Si te Apuntas Podras Conseguir Importantes descuentos en tus tiendas Favoritas</h5>
<h5>Contamos con Miles de Tiendas Adheridas que Esperan que Tú las Recomiendes a tus Amigos, Por Cada Referido Tuyo que Haga una Compra en la Tienda, Esta te Acreditrará un 9% de Descuento del Valor de la Compra de tu Referido Acumulable hasta un 90%, es Decir un Máximo de 10 Referidos, Pero si tu le Envías 50 Amigos el Primer Mes, los 40 Referidos que Tienes se Convierten en Descuentos para el Mes Siguiente, Siempre como Máximo 10 Referidos por Mes</h5>
<h4>Aquí una Pequeña Muestra de las Empresas que Aceptan tus Referidos:</h4>
<div id="slide" class="carousel slide" data-bs-ride="carousel">
    <div class="carousel-inner">
        <?php
        $path = "img/slide/*"; // Asigno a $path todos los Ficheros que están en el Directorio pages.
        $qtty = count(glob($path));
        for ($i = 0; $i < $qtty; $i++)
        {
            if ($i == $qtty - 1)
            {
                $html = '<div class="carousel-item active">';
            }
            else
            {
                $html = '<div class="carousel-item">';
            }
            echo $html . '
                <img src="img/slide/img' . $i . '.jpg" class="d-block w-100" alt="Imagen-' . $i . '">
            </div>';
        }
        ?>
    </div>
</div>
<br><br><br><br><br>
    <button class="carousel-control-prev" type="button" data-bs-target="#slide" data-bs-slide="prev">
    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
    <span class="visually-hidden">Anterior</span>
    </button>
    <button class="carousel-control-next" type="button" data-bs-target="#slide" data-bs-slide="next">
    <span class="carousel-control-next-icon" aria-hidden="true"></span>
    <span class="visually-hidden">Siguiente</span>
    </button>