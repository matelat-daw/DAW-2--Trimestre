-- Examen Base de Datos:

CREATE DATABASE examen_empresa;

USE examen_empresa;

CREATE TABLE Proyectos (
    cod_proy INT,
    cod_cliente INT,
    fecha_inicio DATE,
    tipo VARCHAR(9)
);

CREATE TABLE Personal (
    cod_func INT,
    nombre VARCHAR(20),
    fecha_ingreso DATE
);

CREATE TABLE Tareas (
    cod_tarea INT,
    descripcion VARCHAR(20),
    tipo VARCHAR(20)
);

CREATE TABLE Asignacion (
    cod_func INT,
    cod_proy INT,
    cod_tarea INT
);

CREATE TABLE Registro (
    cod_registro INT,
    cod_func INT,
    cod_proy INT,
    fecha DATE,
    cant_horas INT
);

CREATE TABLE Clientes (
    cod_cliente INT,
    nombre VARCHAR(20),
    direccion VARCHAR(20),
    poblacion VARCHAR(20),
    contacto VARCHAR(20),
    email VARCHAR(20),
    telefono VARCHAR(20),
    cod_func INT
);

sp_tables "Clientes";

sp_columns "Clientes";

-- 1.2. Añadir claves primarias y foráneas

ALTER TABLE Clientes ALTER COLUMN cod_cliente int NOT NULL; -- En SQL SERVER hay que Alterar la Columna para que no Admita NULL antes de Declararla Clave Primaria.

ALTER TABLE Clientes
ADD CONSTRAINT PK_Codigo PRIMARY KEY (cod_cliente);

ALTER TABLE Proyectos ALTER COLUMN cod_proy int NOT NULL;

ALTER TABLE Proyectos
ADD PRIMARY KEY (cod_proy);

ALTER TABLE Tareas ALTER COLUMN cod_tarea int NOT NULL;

ALTER TABLE Tareas
ADD PRIMARY KEY (cod_tarea);

ALTER TABLE Personal ALTER COLUMN cod_func int NOT NULL;

ALTER TABLE Personal
ADD PRIMARY KEY (cod_func);

ALTER TABLE Registro ALTER COLUMN cod_registro int NOT NULL;

ALTER TABLE Registro
ADD PRIMARY KEY (cod_registro);

ALTER TABLE Proyectos
ADD CONSTRAINT FK_Proyecto_Cliente FOREIGN KEY (cod_cliente) REFERENCES clientes(cod_cliente) ON DELETE NO ACTION ON UPDATE CASCADE;

ALTER TABLE Asignacion
ADD CONSTRAINT FK_Asignacion_Proyecto FOREIGN KEY (cod_proy) REFERENCES proyectos(cod_proy) ON DELETE NO ACTION ON UPDATE CASCADE,
CONSTRAINT FK_Asignacion_Personal FOREIGN KEY (cod_func) REFERENCES personal(cod_func) ON DELETE NO ACTION ON UPDATE CASCADE,
CONSTRAINT FK_Asignacion_Tarea FOREIGN KEY (cod_tarea) REFERENCES tareas (cod_tarea) ON DELETE NO ACTION ON UPDATE CASCADE; -- Agregada Posteriormente.


ALTER TABLE Asignacion
ADD CONSTRAINT FK_Asignacion_Personal FOREIGN KEY (cod_func) REFERENCES personal(cod_func) ON DELETE NO ACTION ON UPDATE CASCADE,
CONSTRAINT FK_Asignacion_Tarea FOREIGN KEY (cod_tarea) REFERENCES tareas (cod_tarea) ON DELETE NO ACTION ON UPDATE CASCADE; -- En SQL SERVER las Claves Foráneas Multiples se agregan con un solo ADD.


ALTER TABLE Asignacion DROP CONSTRAINT FK_Asignacion_Personal; -- Elimina la Restricción de Clave Foránea por el nombre de la Clave.

ALTER TABLE Asignacion DROP CONSTRAINT FK_Asignacion_Tarea;


ALTER TABLE Registro
ADD CONSTRAINT FK_Registro_Proyecto FOREIGN KEY (cod_proy) REFERENCES proyectos(cod_proy) ON DELETE NO ACTION ON UPDATE CASCADE,
CONSTRAINT FK_Registro_Funcionario FOREIGN KEY (cod_func) REFERENCES personal(cod_func) ON DELETE NO ACTION ON UPDATE CASCADE;


ALTER TABLE Clientes
ADD CONSTRAINT FK_Cliente_Personal FOREIGN KEY (cod_func) REFERENCES personal(cod_func) ON DELETE NO ACTION ON UPDATE NO ACTION;


-- 2. Relación entre empleados con nombre y tipo de proyecto trabajado
SELECT pe.nombre, pr.tipo
FROM Personal pe
INNER JOIN Asignacion asg ON pe.cod_func = asg.cod_func
INNER JOIN Proyectos pr ON asg.cod_proy = pr.cod_proy;

-- 3. Modificar la tabla proyecto en incluir el atributo descripcion con tamaño 50, único y obligatorio
ALTER TABLE proyectos
ADD Descripcion VARCHAR(50) UNIQUE NOT NULL;

SELECT * FROM proyectos;

sp_columns 'proyectos';

-- 4. Insertar simultáneamente los siguientes empleados en la tabla personal:
-- · 221, Pepe, 02/03/2024
-- · 222, Teresa
-- · 223, Pepi, 02/03/2024
-- · 224,, 02/03/2024
INSERT INTO Personal VALUES
(221, 'Pepe', '2024-03-02'),
(223, 'Teresa', NULL),
(224, 'Pepi', '2024-03-02'),
(225, NULL, '2024-03-02');

INSERT INTO Personal VALUES
(221, 'Pepe', '2024-03-02'),
(223, 'Teresa', NULL),
(224, 'Pepi', '2024-03-02'),
(225, '', '2024-03-02');

SELECT * FROM Personal;

DELETE FROM Personal;

-- 5. Para cada proyecto presente en la base de datos, obtener cuántas personas están trabajando en cada proyecto, aparecerá el proyecto y el número de empleados que están trabajando en él.
SELECT COUNT(per.cod_func) 'Cantidad de Proyectos', pro.Descripcion
FROM personal per
INNER JOIN asignacion asig ON asig.cod_func = per.cod_func
INNER JOIN proyectos pro ON pro.cod_proy = asig.cod_proy
WHERE per.cod_func=asig.cod_func;

--6. Modificar el registro del empleado Teresa colocando la fecha de ingreso a la actual utilizando la función que te da la fecha actual.

UPDATE personal SET fecha_ingreso=getdate() WHERE personal.cod_func=223; -- En SQL SERVER la Fecha de hoy se consigue con getdate().
-- o
UPDATE personal SET fecha_ingreso=getdate() WHERE personal.nombre='TERESA';

-- 7. Obtener el código del proyecto y su tipo que más horas tienen computadas sus empleados (Notar que no necesariamente por una única persona).
SELECT pro.cod_proy "Código de Proyecto", pro.tipo "Tipo de Proyecto"
FROM proyectos pro
INNER JOIN registro reg ON pro.cod_proy=reg.cod_proy
INNER JOIN personal per ON reg.cod_func=per.cod_func
WHERE reg.cant_horas = (SELECT reg.cant_horas FROM registro reg ORDER BY cant_horas DESC LIMIT 1);

-- 8. Obtener los códigos de los proyectos que tienen personal asignado y que en ninguna fecha fueron trabajadas más de 40 horas en él. (Notar que no necesariamente por una única persona).
SELECT pro.cod_proy "Código de Proyecto"
FROM proyectos pro
INNER JOIN registro reg ON pro.cod_proy=reg.cod_proy
INNER JOIN personal per ON reg.cod_func=per.cod_func
WHERE reg.cant_horas < 40;

-- 9. Mostrar el nombre del empleado que mas horas a trabajado en enero de 2024.
SELECT per.nombre
FROM personal per
INNER JOIN registro reg ON per.cod_func=reg.cod_func
WHERE reg.cant_horas = (SELECT reg.cant_horas FROM registro reg WHERE reg.fecha BETWEEN "2024-01-01" AND "2024-01-31" ORDER BY reg.cant_horas DESC LIMIT 1);

-- 10. Realizar un listado de los proyectos realizados desde 01/01/2023 hasta la fecha actual, indicando el código del cliente, la fecha de inicio y su tipo.
SELECT cl.cod_cliente "Código de Cliente", pro.fecha_inicio "Fecha de Inicio", pro.tipo "Tipo de Proyecto"
FROM clientes cl INNER JOIN personal per ON cl.cod_func=per.cod_func
INNER JOIN asignacion asg ON asg.cod_func=per.cod_func
INNER JOIN proyectos pro ON asg.cod_proy=pro.cod_proy
WHERE pro.fecha_inicio BETWEEN "2023-01-01" AND NOW();

-- 11. Eliminar los clientes que no han solicitado ningún proyecto desde 2020 hasta ahora.
DELETE cli FROM clientes cli LEFT JOIN proyectos pro ON pro.cod_cliente=cli.cod_cliente WHERE pro.cod_cliente IS NULL AND pro.fecha_inicio>='2020-01-01';
--Sí o Sí hay que escribir DELETE y cli no se puede dejar en blanco.


-- 12. Mostrar en la misma consulta el nombre del primer y del ultimp empleado de nuestra base de datos (UNION)
SELECT per.nombre FROM personal per WHERE per.cod_func = (SELECT per.cod_func FROM personal per ORDER BY per.cod_func LIMIT 1)
UNION
SELECT per.nombre FROM personal per WHERE per.cod_func = (SELECT per.cod_func FROM personal per ORDER BY per.cod_func DESC LIMIT 1);


-- 13. Realizar un listado ordenado de los códigos de clientes que no han solicitado cinco o más proyectos
SELECT cli.cod_cliente
FROM clientes cli
INNER JOIN proyectos pro ON pro.cod_cliente=cli.cod_cliente
WHERE (SELECT COUNT(pro.cod_cliente) FROM proyectos pro) < 5 GROUP BY cli.cod_cliente;