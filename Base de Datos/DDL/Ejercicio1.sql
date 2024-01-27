CREATE database contactos;

USE contactos;

CREATE TABLE agenda(
    nombre varchar(10),
    apellidos varchar(30),
    telefono varchar(9) PRIMARY KEY
);

DROP TABLE agenda;

-- Otra Opción
CREATE TABLE agenda(
    nombre varchar(10),
    apellidos varchar(30),
    telefono varchar(9)
);

ALTER TABLE agenda ADD CONSTRAINT PK_phone PRIMARY KEY(telefono); -- Agrega la Restricción Clave Primaria a la Columna telefono con el Nombre pk1.


ALTER TABLE agenda ADD COLUMN edad tinyint, DROP COLUMN apellidos; -- Agrega la Columna edad y Quita la Columna apellidos.


ALTER TABLE agenda DROP COLUMN nombre; -- Borra la Columna nombre.


ALTER TABLE agenda ADD COLUMN nombre varchar(10) -- Agrega la Columna nombre y le Asigna un Tipo y Tamaño.


ALTER TABLE agenda ADD COLUMN apellidos varchar(30) NOT NULL; -- Agrega la Columna apellidos, Tipo y Tamaño y no Puede Ser NULL.


ALTER TABLE agenda CHANGE nombre nombre varchar(10) NOT NULL; -- Cmabia la Columna nombre, Tipo de Dato, Tamaño y no NULL.


ALTER TABLE agenda MODIFY nombre varchar(15) NOT NULL; -- Modifica la Columna nombre para que no pueda ser NULL, Hay que Volver a Asignar el Tipo de Dato y el Tamaño.


CREATE DATABASE nuevaempresa;

USE nuevaempresa;

CREATE TABLE empleados(
    num int PRIMARY KEY DEFAULT 0,
    nombre varchar(50),
    edad tinyint(4) DEFAULT 0,
    oficina tinyint(4) DEFAULT 0,
    cargo varchar(20),
    fcontrato DATETIME,
    superior tinyint(4),
    minimo decimal(19,4) DEFAULT 0.0000,
    ventas decimal(19,4) DEFAULT 0.0000
);

-- el Tamaño decimal 19,4 es Extremadamente Exagerado es = 999999999999999.9999 (15 9 Parte Entera y 4 9 Después de la ,)

CREATE TABLE oficinas(
    numoficina tinyint(4) PRIMARY KEY,
    localidad varchar(50),
    zona varchar(50),
    dir tinyint(4) DEFAULT 0,
    objetivo decimal(19,4) DEFAULT 0.0000,
    ventas decimal(19,4) DEFAULT 0.0000
);

CREATE TABLE productos(
    idfab varchar(3),
    idproducto varchar(5),
    descripcion varchar(50),
    precio decimal(19,4) DEFAULT 0.0000,
    stock int DEFAULT 0,
    INDEX (idfab),
    INDEX (idproducto)
);