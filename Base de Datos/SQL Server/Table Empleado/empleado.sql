if object_id('empleado') is not null
drop table empleado;

CREATE TABLE empleado (
	nombre varchar(20) NOT NULL,
	Apellido1 varchar(20) NOT NULL,
	Apellido2 varchar(20),
	direccion varchar(128) NOT NULL,
);

ALTER TABLE empleado ADD fecha_ingreso varchar(9);

INSERT INTO empleado (nombre, Apellido1, direccion) VALUES ('Pepe', 'Rodríguez', 'Su Casa');

ALTER TABLE empleado ADD codigo int IDENTITY;

ALTER TABLE empleado ADD documento varchar(9) NOT NULL; -- Si Hay Datos no se pueden agregar campos NOT NULL.

ALTER TABLE empleado ADD documento varchar(9) CONSTRAINT df1 DEFAULT ''; -- Si hay datos hay que crear el campo con CONSTRAINT.

ALTER TABLE empleado ADD documento varchar(9); -- Y también se puede crear así, NULL directamente sin CONSTRAINT.

ALTER TABLE empleado ADD sueldo decimal(5,2);

INSERT INTO empleado VALUES ('Pepe', 'Rodríguez', 'González', 'Su Casa', '12345678Z'); -- OJO Comillas Simples (').

SELECT * FROM empleado;

EXEC sp_columns 'empleado';

INSERT INTO empleado VALUES ('Pepe', 'Rodríguez', 'González', 'Su Casa', '12345678Z', 950.50);

ALTER TABLE empleado DROP column sueldo;

ALTER TABLE empleado DROP CONSTRAINT df1; -- Si se creo con CONSTRAINT hay que eliminar la CONSTRAINT primero.

ALTER TABLE empleado DROP column documento; -- Y después Eliminar el campo documento.

ALTER TABLE empleado DROP column codigo, fecha_ingreso;