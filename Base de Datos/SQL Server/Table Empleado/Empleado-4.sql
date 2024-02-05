ALTER TABLE empleado ALTER COLUMN nombre varchar(50);

EXEC sp_columns 'empleado';

SELECT * from empleado;

ALTER TABLE empleado ADD sueldo decimal(5,2) CONSTRAINT df1 DEFAULT '';

ALTER TABLE empleado ALTER COLUMN documento varchar(8);

ALTER TABLE empleado ADD codigo int IDENTITY;

ALTER TABLE empleado ALTER COLUMN codigo tinyint;

insert into empleado values('22222222','Juan Perez','Colón 123','Córdoba',500,3), ('Con Nombre', 'Algo','La Milagrosa 56','Córdoba',600,2);


DELETE FROM empleado WHERE nombre IS NULL;

ALTER TABLE empleado ALTER COLUMN nombre varchar(50) NOT NULL;