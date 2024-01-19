CREATE database contactos;

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

ALTER TABLE agenda ADD CONSTRAINT pk1 PRIMARY KEY(telefono); -- Agrega la Restricción Clave Primaria a la Columna telefono con el nombre pk1.


ALTER TABLE agenda ADD COLUMN edad tinyint, DROP COLUMN apellidos; -- Agrega la Columna edad y quita la Columna apellidos.


ALTER TABLE agenda DROP COLUMN nombre; -- Borra la Columna nombre.


ALTER TABLE agenda ADD COLUMN nombre varchar(10) -- Agrega la Columna nombre.


ALTER TABLE agenda ADD COLUMN apellidos varchar(30) NOT NULL; -- Agrega la Columna apellidos que no puede ser NULL.


ALTER TABLE agenda CHANGE nombre nombre varchar(10) NOT NULL; -- Cmabia la Columna nombre, Tipo de dato, tamaño y no null.


ALTER TABLE agenda MODIFY nombre varchar(15) NOT NULL; -- Modifica la columna nombre para que no pueda ser NULL.


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

