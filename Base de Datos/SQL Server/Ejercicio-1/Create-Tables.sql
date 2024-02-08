CREATE DATABASE academia;

USE academia;

CREATE TABLE profesor (
	dni varchar(9) PRIMARY KEY,
	name varchar(20),
	surname1 varchar(20),
	surname2 varchar(20),
	especiality varchar(64),
	gain decimal(5,2)
);

ALTER TABLE profesor ALTER COLUMN name varchar(20) NOT NULL;
ALTER TABLE profesor ALTER COLUMN surname1 varchar(20) NOT NULL;
ALTER TABLE profesor ALTER COLUMN especiality varchar(64) NOT NULL;
ALTER TABLE profesor ALTER COLUMN gain decimal(5,2) NOT NULL;

CREATE TABLE curso (
	cod_curso int IDENTITY PRIMARY KEY,
	name varchar(64),
	pupil_qtty tinyint NOT NULL,
	hours_qtty smallint NOT NULL,
	start_date date,
	end_date date,
	dni_profe varchar(9)
);

CREATE INDEX FK_dni_profe ON curso (dni_profe);

ALTER TABLE curso ADD FOREIGN KEY (dni_profe) REFERENCES profesor(dni) ON DELETE NO ACTION ON UPDATE CASCADE;

CREATE TABLE alumno (
	dni varchar(9) PRIMARY KEY,
	name varchar(20) NOT NULL,
	surname1 varchar(20) NOT NULL,
	surname2 varchar(20),
	address varchar(128)NOT NULL,
	phone varchar(9) UNIQUE NOT NULL,
	email varchar(32) UNIQUE NOT NULL,
	bday date NOT NULL,
	curso int NOT NULL
);

-- CREATE INDEX FK_cod_curso ON alumno (curso); -- Esta Línea no es Necesaria Para Relacionar las Tablas.

ALTER TABLE alumno ADD CONSTRAINT FK_alumno_curso FOREIGN KEY (curso) REFERENCES curso (cod_curso) ON DELETE CASCADE ON UPDATE CASCADE;



ALTER TABLE curso DROP CONSTRAINT FK__curso__dni_profe__4BAC3F29;

ALTER TABLE profesor DROP CONSTRAINT PK__profesor__D87608A618CBDC12;

ALTER TABLE profesor ALTER COLUMN dni varchar(9) NOT NULL;

ALTER TABLE profesor ADD PRIMARY KEY (dni);



INSERT INTO profesor VALUES ('12345678Z', 'Fulano', 'García', 'Gracía', 'Maestro Chocolatero', 20.25),
							('25775147J', 'Mengano', 'Rodríguez', NULL, 'Profesor HTML', 40.50);




DROP INDEX FK_dni_profe ON curso;

ALTER TABLE curso ALTER COLUMN dni_profe varchar(9);

ALTER TABLE curso ADD CONSTRAINT FK_curso_profe FOREIGN KEY (dni_profe) REFERENCES profesor(dni) ON DELETE NO ACTION ON UPDATE CASCADE;



INSERT INTO curso VALUES ('Maquetación HTML, CSS y JAVASCRIPT', 16, 600, '2024-02-05', '2024-08-30', '25775147J');


INSERT INTO alumno VALUES ('42268151Q', 'César Osvaldo', 'Matelat', 'Borneo', 'Mi Casa, Como E.T.', '664774821', 'cesarmatelat@gmail.com', '1968-04-05', 1);

SELECT * FROM alumno;