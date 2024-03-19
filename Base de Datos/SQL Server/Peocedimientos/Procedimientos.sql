-- PRACTICA Nº 1 SQLS: PROCEDIMIENTOS ALMACENADOS
-- Una empresa almacena los datos de sus empleados en una tabla llamada "empleados".
-- 1- Eliminamos la tabla, si existe y la creamos:
if object_id('empleados') is not null
drop table empleados;
create table empleados(
documento char(8),
nombre varchar(20),
apellidos varchar(20),
sueldo decimal(6,2),
nhijos tinyint,
departamento varchar(20),
primary key(documento)
);
-- 2- Inserte algunos registros:
insert into empleados values('22222222','Juan','Pérez',1300,2,'Contabilidad'),
('22333333','Luís','López',1300,0,'Contabilidad'),
('22444444','Marta','Pérez',1500,1,'Sistemas'),
('22555555','Susana','García',1400,2,'Secretaría'),
('22666666','José María','Morales',1400,3,'Secretaría');
-- 3- Elimine el procedimiento llamado "pa_empleados_sueldo" si existe:
if object_id('pa_empleados_sueldo') is not null
drop procedure pa_empleados_sueldo;
-- 4- Cree un procedimiento almacenado llamado "pa_empleados_sueldo" que seleccione los nombres, apellidos y sueldos de los empleados.

CREATE or ALTER PROC pa_empleados_sueldo
AS
SELECT e.nombre, e.apellidos, e.sueldo
FROM empleados e;

-- 5- Ejecute el procedimiento creado anteriormente.

exec pa_empleados_sueldo;


-- 6- Elimine el procedimiento llamado "pa_empleados_hijos" si existe:

if object_id('pa_empleados_hijos') is not null
drop procedure pa_empleados_hijos;

-- 7- Cree un procedimiento almacenado llamado "pa_empleados_hijos" que seleccione los nombres, apellidos y cantidad de hijos de los empleados con hijos.

Create Proc pa_empleados_hijos
AS
SELECT e.nhijos
FROM empleados e;

-- 8- Ejecute el procedimiento creado anteriormente.

exec pa_empleados_hijos;

-- 9- Actualice la cantidad de hijos de algún empleado sin hijos y vuelva a ejecutar el procedimiento para verificar que ahora si aparece en la lista.

UPDATE empleados set nhijos=1 where documento='22222222';