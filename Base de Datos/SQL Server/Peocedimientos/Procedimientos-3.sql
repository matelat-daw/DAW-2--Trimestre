-- PRACTICA Nº 3 SQLS: PROCEDIMIENTOS ALMACENADOS CON PASO DE PARÁMETROS
-- Una empresa almacena los datos de sus empleados en una tabla llamada "empleados".
-- 1- Elimine el procedimiento llamado "pa_empleados_sueldo" si existe:

if object_id('pa_empleados_sueldo') is not null
drop procedure pa_empleados_sueldo;

-- 2- Cree un procedimiento almacenado llamado "pa_empleados_sueldo" que seleccione los nombres, apellidos y sueldos de los empleados que tengan un sueldo superior o igual al enviado como parámetro.

CREATE OR ALTER PROC pa_empleados_sueldo
@sueldo decimal(6,2)
AS
SELECT e.nombre, e.apellidos, e.sueldo
FROM empleados e
WHERE e.sueldo >= @sueldo;

-- 3- Ejecute el procedimiento creado anteriormente con distintos valores: sueldo 1400 y sueldo 1500.

exec pa_empleados_sueldo 1500;

-- 4- Ejecute el procedimiento almacenado "pa_empleados_sueldo" sin parámetros. Mostrará un mensaje de error.

exec pa_empleados_sueldo; -- ERROR.

-- 5- Elimine el procedimiento almacenado "pa_empleados_actualizar_sueldo" si existe:

if object_id('pa_empleados_actualizar_sueldo') is not null
drop procedure pa_empleados_actualizar_sueldo;

-- 6- Cree un procedimiento almacenado llamado "pa_empleados_actualizar_sueldo" que actualice los sueldos iguales al enviado como primer parámetro con el valor enviado como segundo parámetro.

CREATE PROC pa_empleados_actualizar_sueldo
@sueldo decimal(7.2)
AS
UPDATE empleados

-- 7- Ejecute el procedimiento creado anteriormente y verifique si se ha ejecutado correctamente: sueldo 1300, 1350.



-- 8- Ejecute el procedimiento "pa_empleados_actualizar_sueldo" enviando un solo parámetro.



-- 9- Ejecute el procedimiento almacenado "pa_empleados_actualizar_sueldo" enviando en primer lugar el parámetro @sueldonuevo y en segundo lugar @sueldoanterior (parámetros por nombre).



--10- Verifique el cambio.



--11- Elimine el procedimiento almacenado "pa_sueldototal", si existe:

if object_id('pa_sueldototal') is not null
drop procedure pa_sueldototal;

-- 12- Cree un procedimiento llamado "pa_sueldototal" que reciba el documento de un empleado y muestre su nombre, apellido y el sueldo total (resultado de la suma del sueldo y salario por hijo, que es de 200 € si el sueldo es menor a 1500 € y 100 €, si el sueldo es mayor o igual a 1500€). Coloque como valor por defecto para el parámetro el patrón "%".



-- 13- Ejecute el procedimiento anterior enviando diferentes valores: '22333333', '22444444' y '22666666'



-- 14- Ejecute el procedimiento sin enviar parámetro para que tome el valor por defecto.

