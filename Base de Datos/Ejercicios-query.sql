-- 1 ¿Cuál es la cuota media y las ventas medias de todos los empleados?

SELECT AVG(e.minimo) "Cuota Media", AVG(e.ventas) "Total Ventas Media"
FROM empleados e;

-- 2 Hallar el importe medio de pedidos, el importe total de pedidos y el precio medio de venta (el precio de venta es el precio unitario en cada pedido).

SELECT AVG(e.ventas) "Media de las Ventas", SUM(e.ventas) "Total Ventas", AVG(p.precio) "Media de Precios"
FROM empleados e JOIN productos p;

-- 3 Hallar el precio medio de los productos del fabricante ACI.

SELECT idfab "Fabricante", AVG(p.precio) "Media de Precios"
FROM productos p
WHERE idfab="aci";

-- 4 ¿Cuál es la cantidad total de los pedidos realizados por el empleado Vicente Delgado?

SELECT e.nombre, COUNT(p.repre) "Cantidad de Pedidos"
FROM pedidos p JOIN empleados e ON p.repre=e.num
WHERE e.nombre LIKE "Vicente Delgado";

-- 5 Hallar en qué fecha se realizó el primer pedido (suponiendo que en la tabla de pedidos tenemos todos los pedidos realizados hasta la fecha).

SELECT p.fpedido "Fecha del Primer Pedido"
FROM pedidos p
ORDER BY p.fpedido LIMIT 1;

-- 6 Hallar cuántos productos tienen una cantidad de stockde más de 200.

SELECT COUNT(idproducto) "Productos con Stock Superior a 200 Unidades"
FROM productos p
WHERE stock > 200;

-- 7 Listar cuántos empleados están asignados a cada oficina, indicar el número de oficina y cuántos hay asignados.

SELECT e.oficina "Número de Oficina", COUNT(e.nombre) "Cantidad de Empleados"
FROM empleados e
GROUP BY e.oficina;

-- 8 Para cada empleado, obtener su número, nombre, e importe vendido por ese empleado a cada cliente indicando el número de cliente.

SELECT e.num "Código del Empleado", e.nombre "Nombre del Empleado", p.cantidad * pr.precio "Ventas del Empleado", c.clie "Número de Cliente", c.nombre "Nombre del Cliente"
FROM empleados e JOIN clientes c ON e.num=c.repre JOIN pedidos P ON e.num=p.repre JOIN productos pr ON p.producto=pr.idproducto
WHERE p.producto=pr.idproducto AND e.num=p.repre
ORDER BY e.num;

-- 9 Para cada empleado cuyos pedidos suman más de 50 unidades, hallar su cantidad media de pedidos. En el resultado indicar el número de empleado y su cantidad media de pedidos.

-- Cantidad de Pedidos de los Vendedores que vendieron más de 50 Artículos.
SELECT e.num, COUNT(p.codigo)
FROM pedidos p JOIN empleados e ON p.repre=e.num
GROUP BY p.repre
HAVING SUM(p.cantidad) > 50;

-- Media de la Cantidad de Artículos de los Pedidos de los Vendedores que vendieron más de 50 Artículos.
SELECT e.num, AVG(p.cantidad)
FROM pedidos p JOIN empleados e ON p.repre=e.num
GROUP BY p.repre
HAVING SUM(p.cantidad) > 50;

-- 10 Listar de cada producto, su descripción, precio y cantidad total pedida, incluyendo sólo los productos cuya cantidad total pedida sea superior al 75% del stock; y ordenado por cantidad total pedida.

SELECT p.descripcion, p.precio, pe.cantidad
FROM productos p JOIN pedidos pe ON p.idproducto=pe.producto
WHERE pe.cantidad > p.stock * .75
ORDER BY 3;

-- 11 Saber cuántas oficinas tienen empleados con ventas superiores a su cuota, no queremos saber cuales sino cuántas hay.

SELECT COUNT(e.oficina) "Cantidad de Oficinas Cuyos Empleados Venden Más que su Mínimo"
FROM empleados e
WHERE e.ventas > e.minimo;