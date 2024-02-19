ALTER TABLE empleado ALTER COLUMN nombre varchar(50);

EXEC sp_columns 'empleado';

SELECT * from empleado;

ALTER TABLE empleado ADD sueldo decimal(5,2) CONSTRAINT df1 DEFAULT '';

ALTER TABLE empleado ALTER COLUMN documento varchar(8);

ALTER TABLE empleado ADD codigo int IDENTITY;

ALTER TABLE empleado ALTER COLUMN codigo tinyint;

insert into empleado values('22222222','Juan Perez','Colón 123','Córdoba',500,3), ('Con Nombre', 'Algo','La Milagrosa 56','Córdoba',600,2);

DELETE FROM empleado WHERE nombre IS NULL; -- nombre no puede ser NULL ya que se creo la tabla con el campo nombre NOT NULL.

ALTER TABLE empleado ALTER COLUMN nombre varchar(50) NOT NULL; -- Modifico el Tamaño de la Columna nombre para que Soporte 50 Carateres.

ALTER TABLE empleado ADD ciudad varchar(20); -- Agrega a la Tabla empleado el campo/columna/atributo ciudad de Tipo Varchar 20.

Alter Table empleado ALTER COLUMN ciudad varchar(10); -- Lo Modifico Para que Acepte Solo 10 Caracteres.

ALTER TABLE empleado ADD CONSTRAINT DF_City DEFAULT 'Buena Vista del Norte' FOR ciudad; -- Modifico la Columna ciudad con el Valor por Defecto 'Buena Vista del Norte'.

insert into empleado values('Juan', 'Perez', 'García','La Candelaria 56', '12345678', 500.5, default); -- Intento Insertar da Error de Tamaño y no se Inserta.

Alter Table empleado ALTER COLUMN ciudad varchar(25); -- Modifico la Longitud del Campo ciudad a 25 Caracteres.

insert into empleado values('Juan', 'Perez', 'García','La Candelaria 56', '12345678', 500.5, default); -- Inserto el Valor por Defecto.