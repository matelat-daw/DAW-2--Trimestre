-- 1-.
CREATE TABLE `nuevaempleados` (
  `num` tinyint(4) NOT NULL DEFAULT 0,
  `nombre` varchar(50) DEFAULT NULL,
  `edad` tinyint(4) DEFAULT 0,
  `oficina` tinyint(4) DEFAULT 0,
  `cargo` varchar(20) DEFAULT NULL,
  `fcontrato` datetime DEFAULT NULL,
  `superior` tinyint(4) DEFAULT NULL,
  `minimo` decimal(19,4) DEFAULT 0.0000,
  `ventas` decimal(19,4) DEFAULT 0.0000
);

ALTER TABLE `nuevaempleados`
  ADD PRIMARY KEY (`num`);


-- 2-.
CREATE TABLE `nuevaoficinas` (
  `numoficina` tinyint(4) NOT NULL,
  `localidad` varchar(50) DEFAULT NULL,
  `zona` varchar(50) DEFAULT NULL,
  `dir` tinyint(4) DEFAULT 0,
  `objetivo` decimal(19,4) DEFAULT 0.0000,
  `ventas` decimal(19,4) DEFAULT 0.0000
);

ALTER TABLE `nuevaoficinas`
  ADD PRIMARY KEY (`numoficina`);
  
-- Para Rellenar la Nueva Tabla:
INSERT INTO nuevaoficinas(numoficina, localidad, zona, dir, objetivo, ventas) SELECT * FROM oficinas;


-- 3-.
CREATE TABLE `nuevaproductos` (
  `idfab` varchar(3) DEFAULT NULL,
  `idproducto` varchar(5) DEFAULT NULL,
  `descripcion` varchar(50) DEFAULT NULL,
  `precio` decimal(19,4) DEFAULT 0.0000,
  `stock` int(11) DEFAULT 0
);

ALTER TABLE `nuevaproductos`
  ADD KEY `idfab` (`idfab`),
  ADD KEY `idproducto` (`idproducto`);

-- Para Rellenar la Nueva Tabla:
INSERT INTO `nuevaproductos`(`idfab`, `idproducto`, `descripcion`, `precio`, `stock`) SELECT * FROM productos;

-- 4-.
CREATE TABLE `nuevapedidos` (
  `codigo` int(11) NOT NULL,
  `numpedido` varchar(6) DEFAULT NULL,
  `fpedido` datetime DEFAULT NULL,
  `cliente` int(11) DEFAULT 0,
  `repre` tinyint(4) DEFAULT 0,
  `fab` varchar(3) DEFAULT NULL,
  `producto` varchar(5) DEFAULT NULL,
  `cantidad` int(11) DEFAULT 0
);

ALTER TABLE `nuevapedidos`
  ADD KEY `codigo` (`codigo`);


-- 5-.
UPDATE productos SET precio= precio * 1.05 WHERE idfab LIKE "aci";


-- 6-.
INSERT INTO `oficinas` (`numoficina`, `localidad`, `zona`, `objetivo`) VALUES ('30', 'Madrid', 'Centro', '100000.0000');


-- 7-.
UPDATE empleados SET oficina=30 WHERE oficina=21;


-- 8-.
DELETE FROM `pedidos` WHERE repre=105;


-- 9-.
DELETE FROM oficinas WHERE numoficina IN (SELECT oficinas.numoficina FROM oficinas LEFT JOIN empleados ON empleados.oficina=oficinas.numoficina WHERE empleados.oficina IS NULL);