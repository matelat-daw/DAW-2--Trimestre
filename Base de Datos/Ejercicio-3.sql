--							Ejercicios SELECT


-- 1-.

SELECT *
FROM alumno
WHERE alumno.CodigoGrupo = "811NMA";

-- 2-.

SELECT *
FROM alumno a
WHERE a.Municipio = "Tacoronte";

-- 3-.

SELECT *
FROM grupo g
WHERE g.CodigoTutor IS NULL;

-- 4-.

SELECT *
FROM alumno a
WHERE a.Direccion LIKE "%Calvario%";

-- 5-.

SELECT COUNT(Codigo)
FROM alumno a
WHERE a.CodigoPostal = 38350;

-- 6-.

SELECT COUNT(Codigo)
FROM alumno a
WHERE a.CodigoGrupo = "811NMA";

-- 7-.

SELECT COUNT(Codigo)
FROM grupo;

-- 8-.

SELECT asig.Denominacion
FROM asignatura asig INNER JOIN asignaturasgrupo asgr ON asig.Codigo=asgr.CodigoAsignatura INNER JOIN grupo g ON g.Codigo=asgr.CodigoGrupo INNER JOIN alumno a ON a.CodigoGrupo=g.Codigo
WHERE a.Nombre LIKE "PEPE" AND a.Apellidos LIKE "GARCIA SANCHEZ";

SELECT asig.Denominacion
FROM asignatura asig INNER JOIN asignaturasgrupo asgr ON asig.Codigo=asgr.CodigoAsignatura INNER JOIN alumno a ON a.CodigoGrupo=asgr.CodigoGrupo
WHERE a.Nombre LIKE "PEPE" AND a.Apellidos LIKE "GARCIA SANCHEZ";

-- 9-.

SELECT asig.Denominacion
FROM asignatura asig INNER JOIN alumnonota an ON asig.Codigo=an.CodigoAsignatura INNER JOIN alumno a ON a.Codigo=an.CodigoAlumno
WHERE a.Nombre LIKE "PEPE" AND a.Apellidos LIKE "GARCIA SANCHEZ" AND an.Nota >= 5;

-- 10-.

SELECT Nota
FROM alumnonota an INNER JOIN alumno a ON a.Codigo=an.CodigoAlumno
WHERE a.Nombre LIKE "PEPE" AND a.Apellidos LIKE "GARCIA SANCHEZ";

SELECT Nota
FROM alumnonota an INNER JOIN alumno a ON a.Codigo=an.CodigoAlumno
WHERE a.Nombre LIKE "PEPA" AND a.Apellidos LIKE "PEREZ DE LEON";

-- 11-.

SELECT asi.Denominacion
FROM asignatura asi INNER JOIN alumnonota an ON asi.Codigo=an.CodigoAsignatura INNER JOIN asignaturasgrupo asgr ON asgr.CodigoAsignatura=asi.Codigo
WHERE asgr.CodigoGrupo LIKE "811NMA" AND an.Nota >= 5
GROUP BY asi.Denominacion;

-- 12-.

SELECT a.Nombre, a.Apellidos
FROM alumno a INNER JOIN alumnonota an ON a.Codigo=an.CodigoAlumno INNER JOIN asignatura asi ON asi.Codigo=an.CodigoAsignatura
WHERE asi.Codigo=91302;

-- 13-.

SELECT a.Nombre, a.Apellidos
FROM alumno a INNER JOIN alumnonota an ON a.Codigo=an.CodigoAlumno INNER JOIN asignatura asi ON asi.Codigo=an.CodigoAsignatura
WHERE asi.Denominacion LIKE "CULTIVOS EN VIVEROS E INVERNADEROS" AND an.Nota >= 5;

-- 14-. Relación de los Grupos indicando el nombre del tutor

SELECT g.Codigo, p.nombre
FROM grupo g INNER JOIN profesor p ON g.CodigoTutor=p.Codigo;

-- 15-. Relación de los profesores que imparten las asignaturas de los grupos. Indicando nombre del profesor y nombre de la asignatura.

SELECT p.Nombre "Nombre del Profesor", a.denominacion "Asignatura que Imparte"
FROM asignatura a INNER JOIN asignaturasgrupo ag ON a.Codigo=ag.CodigoAsignatura INNER JOIN profesor p ON ag.CodigoProfesor=p.Codigo ORDER BY p.Nombre;

-- 16-. Relación de profesores por orden alfabético.

SELECT p.Nombre "Nombre del Profesor"
FROM profesor p ORDER BY p.Nombre;

-- 17-. Relación de asignaturas suspendidas del grupo 124NMA.

SELECT DISTINCT(a.Denominacion)
FROM asignatura a INNER JOIN asignaturasgrupo ag ON a.Codigo=ag.CodigoAsignatura INNER JOIN grupo g ON ag.CodigoGrupo=g.Codigo INNER JOIN alumno al ON g.Codigo=al.CodigoGrupo INNER JOIN alumnonota aln ON al.Codigo=aln.CodigoAlumno
WHERE aln.Nota < 5 AND G.Codigo LIKE "124NMA";

--18-. Relación de alumnos que han sacado un 6 en la nota de la asignatura de ‘TECNICAS BASICAS DE JARDINERIA’.

SELECT a.Nombre, a.Apellidos
FROM alumno a INNER JOIN alumnonota an ON a.Codigo=an.CodigoAlumno INNER JOIN asignatura asi ON asi.Codigo=an.CodigoAsignatura
WHERE an.Nota = 6 AND asi.Denominacion LIKE "TECNICAS BASICAS DE JARDINERIA";

-- 19-. Relación de asignaturas que imparte el profesor ‘ARRATE MARRERO, CARLOS’.

SELECT DISTINCT(asi.Denominacion)
FROM asignatura asi INNER JOIN asignaturasgrupo ag ON asi.Codigo=ag.CodigoAsignatura INNER JOIN profesor p ON ag.CodigoProfesor=p.Codigo
WHERE p.Nombre LIKE "ARRATE MARRERO, CARLOS";

-- 20-. Relación de alumnos que ha suspendido el profesor ‘VIZCAINO SOSA, JOAQUIN’.

SELECT a.Nombre, a.Apellidos
FROM alumno a INNER JOIN alumnonota an ON a.Codigo=an.CodigoAlumno INNER JOIN asignatura asi ON an.CodigoAsignatura=asi.Codigo INNER JOIN asignaturasgrupo ag ON asi.Codigo=ag.CodigoAsignatura INNER JOIN profesor p ON ag.CodigoProfesor=p.Codigo
WHERE an.Nota < 5 AND p.Nombre LIKE "VIZCAINO SOSA, JOAQUIN";

-- 21-. Relación de grupos a los que imparte clase el profesor ‘POLO ORTEGA, ANGEL’.

SELECT g.Codigo
FROM grupo g INNER JOIN asignaturasgrupo ag ON g.Codigo=ag.CodigoGrupo INNER JOIN profesor p ON ag.CodigoProfesor=p.Codigo
WHERE p.Nombre LIKE "POLO ORTEGA, ANGEL";

-- 22-. Relación de alumnos que son del SAUZAL y les da clase el profesor ‘PRIETO , RAMON’.

SELECT a.Nombre, a.Apellidos
FROM alumno a INNER JOIN grupo g ON a.CodigoGrupo=g.Codigo INNER JOIN asignaturasgrupo ag ON g.Codigo=ag.CodigoGrupo INNER JOIN profesor p ON ag.CodigoProfesor=p.Codigo
WHERE a.Municipio LIKE "EL SAUZAL" AND p.Nombre LIKE "PRIETO , RAMON";

-- 23-. Número de alumnos del grupo 913NMA.

SELECT COUNT(a.Codigo)
FROM alumno a
WHERE a.CodigoGrupo LIKE "913NMA";

-- 24-. Número de grupos que hay en este centro.

SELECT COUNT(g.Codigo) "Cantidad de Grupos"
FROM grupo g;

-- 25-. Número de alumnos que son del SAUZAL.

SELECT COUNT(a.Codigo) "Cantidad de Alumnos de EL SAUZAL"
FROM alumno a
WHERE a.Municipio LIKE "EL SAUZAL";

-- 26-. Número de alumnos que han suspendido la asignatura 91302.

SELECT COUNT(a.Codigo) "Cantidad de Alumnos Que han Suspendido la Asignatura 91302"
FROM alumno a INNER JOIN alumnonota an ON a.Codigo=an.CodigoAlumno INNER JOIN asignatura asi ON an.CodigoAsignatura=asi.Codigo
WHERE an.Nota < 5 AND asi.Codigo=91302;

-- 27-. Número de alumnos que han aprobado la asignatura 91302.

SELECT COUNT(a.Codigo) "Cantidad de Alumnos Que han Aprobado la Asignatura 91302"
FROM alumno a INNER JOIN alumnonota an ON a.Codigo=an.CodigoAlumno INNER JOIN asignatura asi ON an.CodigoAsignatura=asi.Codigo
WHERE an.Nota >= 5 AND asi.Codigo=91302;

-- 28-. Número de alumnos que tienen la asignatura 91302.

SELECT COUNT(a.Codigo) "Cantidad de Alumnos Que Tienen la Asignatura 91302"
FROM alumno a INNER JOIN alumnonota an ON a.Codigo=an.CodigoAlumno INNER JOIN asignatura asi ON an.CodigoAsignatura=asi.Codigo
WHERE asi.Codigo=91302;

-- 29-. Número de alumnos a los que les da clase el profesor ‘POLO ORTEGA, ANGEL’.

SELECT COUNT(a.Codigo) "Cantidad de Alumnos a los que les da Clases POLO ORTEGA, ÁNGEL"
FROM alumno a INNER JOIN grupo g ON a.CodigoGrupo=g.Codigo INNER JOIN asignaturasgrupo ag ON g.Codigo=ag.CodigoGrupo INNER JOIN profesor p ON ag.CodigoProfesor=p.Codigo
WHERE p.Nombre LIKE "POLO ORTEGA, ANGEL";

-- 30-. Nota media del alumno ‘PEPE GARCIA SANCHEZ’  (Nota convertir el campo notas a numérico)

SELECT AVG(an.Nota) "La Media de PEPE GARCIA SANCHEZ"
FROM alumnonota an INNER JOIN alumno a ON an.CodigoAlumno=a.Codigo
WHERE a.Nombre LIKE "PEPE" AND a.Apellidos LIKE "GARCIA SANCHEZ";

-- 31-. Nota media del grupo 913NMA en la asignatura 91303.

SELECT AVG(an.Nota) "Nota Media del Grupo 913NMA en la Asignatura 91303"
FROM alumnonota an INNER JOIN alumno a ON an.CodigoAlumno=a.Codigo INNER JOIN grupo g ON g.Codigo=a.CodigoGrupo INNER JOIN asignaturasgrupo ag ON g.Codigo=ag.CodigoGrupo INNER JOIN asignatura asi ON ag.CodigoAsignatura=asi.Codigo
WHERE g.Codigo LIKE "913NMA" AND asi.Codigo=91303;

-- 32-. Nota media de la asignatura 91303 de todos los grupos.

SELECT AVG(an.Nota) "Nota Media de la Asignatura 91303"
FROM alumnonota an INNER JOIN alumno a ON an.CodigoAlumno=a.Codigo INNER JOIN grupo g ON g.Codigo=a.CodigoGrupo INNER JOIN asignaturasgrupo ag ON g.Codigo=ag.CodigoGrupo INNER JOIN asignatura asi ON ag.CodigoAsignatura=asi.Codigo
WHERE asi.Codigo=91303;

-- 33-. Nota media de los alumnos que se matricularon por primera vez el año 96.

SELECT AVG(n97.Nota) "Nota Media de los Alumnos Matriculados en 1996"
FROM notas_del_curso_97 n97;

-- 34-. Cual es la nota máxima en la asignatura 91304.

SELECT MAX(an.Nota) "Nota Máxima de los Alumnos en la Asignatura 91304"
FROM alumnonota an
WHERE an.CodigoAsignatura=91304;

-- 35-. Cual es la nota mínima en la asignatura 91302.

SELECT MIN(an.Nota) "Nota Mínima de los Alumnos en la Asignatura 91302"
FROM alumnonota an
WHERE an.CodigoAsignatura=91302;


--							Ejercicios INNER JOIN


-- 1-. Utilizando  una fila para cada profesor: hacer número de asignaturas que imparten los profesores ‘VIZCAINO SOSA, JOAQUIN’   y ‘RAMOS FERNANDEZ, JOSEFA’.

SELECT Distinct p.Nombre, asi.Denominacion
FROM asignatura asi INNER JOIN asignaturasgrupo ag ON asi.Codigo=ag.CodigoAsignatura INNER JOIN profesor p ON ag.CodigoProfesor=p.Codigo
WHERE p.Nombre LIKE "VIZCAINO SOSA, JOAQUIN" OR p.Nombre LIKE "RAMOS FERNANDEZ, JOSEFA";

-- 2-. Nota media de los alumnos del SAUZAL y nota media de los alumnos de TACORONTE.

SELECT a.Nombre, a.Apellidos, a.Municipio
FROM alumno a
WHERE a.Municipio LIKE "EL SAUZAL" OR a.Municipio LIKE "TACORONTE";

-- 3-. Relación de notas del curso actual y del curso 97 (tabla notas97) del alumno ‘PEPA CHAVEZ DOMINGUEZ’.

SELECT an.Nota
FROM alumno a INNER JOIN alumnonota an ON a.Codigo=an.CodigoAlumno INNER JOIN notas_del_curso_97 n97 ON an.CodigoAsignatura=n97.CodAsignatura
WHERE a.Nombre LIKE "PEPA" AND a.Apellidos LIKE "CHAVEZ DOMINGUEZ";

-- 4-. Relación de alumnos del grupo 913NMB incluyendo las bajas.

SELECT a.Nombre, a.Apellidos
FROM alumno a INNER JOIN grupo g ON a.CodigoGrupo=g.Codigo INNER JOIN alumnos_de_baja ab ON a.Telefono=ab.Telefono
WHERE g.Codigo LIKE "913NMB";


--							GROUP BY


-- 1-. Relación de notas medias de los alumnos del grupo 913NMB.

SELECT AVG(an.Nota) "Nota Media del Grupo 913NMB"
FROM alumnonota an INNER JOIN alumno a ON an.CodigoAlumno=a.Codigo INNER JOIN grupo g ON a.CodigoGrupo=g.Codigo
WHERE g.Codigo LIKE "913NMB"
GROUP BY g.Codigo;

-- 2-. Número de asignaturas que imparte cada profesor del centro.

SELECT p.Nombre, COUNT(asi.Codigo) "Cantidad de Asignaturas"
FROM asignatura asi INNER JOIN asignaturasgrupo ag ON asi.Codigo=ag.CodigoAsignatura INNER JOIN profesor p ON ag.CodigoProfesor=p.Codigo
GROUP BY p.Codigo;

-- 3-. Nota media de los alumnos de cada municipio.

SELECT a.Municipio, AVG(an.Nota) Promedio
FROM alumno a INNER JOIN alumnonota an ON a.Codigo=an.CodigoAlumno
GROUP BY a.Municipio;

-- 4-. Nota media de los alumnos por profesor.

SELECT p.Nombre, AVG(an.Nota) Promedio
FROM alumno a INNER JOIN alumnonota an ON a.Codigo=an.CodigoAlumno INNER JOIN asignaturasgrupo ag ON an.CodigoAsignatura=ag.CodigoAsignatura INNER JOIN profesor p ON p.Codigo=ag.CodigoProfesor
GROUP BY p.Codigo;

-- 5-. Relación de alumnos del SAUZAL cuya nota media este entre 2 y 6.

SELECT a.Nombre, a.Apellidos, AVG(an.Nota)
FROM alumno a INNER JOIN alumnonota an ON a.Codigo=an.CodigoAlumno
WHERE a.Municipio LIKE "EL SAUZAL" AND an.Nota >= 2 AND an.Nota <= 6
GROUP BY a.Codigo;

-- 6-. Relación de nota media por profesor y asignatura.

SELECT p.Nombre, asi.Denominacion, AVG(an.Nota) Promedio
FROM alumno a INNER JOIN alumnonota an ON a.Codigo=an.CodigoAlumno INNER JOIN asignaturasgrupo ag ON an.CodigoAsignatura=ag.CodigoAsignatura INNER JOIN asignatura asi ON ag.CodigoAsignatura=asi.Codigo INNER JOIN profesor p ON p.Codigo=ag.CodigoProfesor
GROUP BY p.Codigo, asi.Codigo;

-- 7-. Relación de nota media por asignatura.

SELECT asi.Denominacion, AVG(an.Nota) Promedio
FROM alumno a INNER JOIN alumnonota an ON a.Codigo=an.CodigoAlumno INNER JOIN asignaturasgrupo ag ON an.CodigoAsignatura=ag.CodigoAsignatura INNER JOIN asignatura asi ON ag.CodigoAsignatura=asi.Codigo
GROUP BY asi.Codigo;

-- 8-. Relación de nota media por asignatura del grupo 913NMA.



-- 9-. Relación alumnos con sus notas medias que son de TACORONTE y tienen de nota media entre un 5 y un 9.



-- 10-. Relación del número de bajas de cada grupo.



--						SUBCONSULTAS.


SELECT e.num, e.nombre, (SELECT MIN(p.fpedido)
                         FROM pedidos p
                         WHERE p.repre=e.num) "Fecha de Pedido"
FROM empleados e;


SELECT e.nombre, e.num
FROM empleados e 
WHERE num=(SELECT DISTINCT p.repre
           FROM pedidos p
           WHERE cliente=(SELECT clie
                          FROM clientes c
                          WHERE c.nombre LIKE "Juan Mora"));
						  
						  
						  
SELECT o.numoficina, o.localidad
FROM oficinas o
WHERE objetivo > (SELECT SUM(o.ventas)
                 FROM empleados e
                 WHERE e.oficina=o.numoficina);
				 
				 
				 
SELECT o.numoficina, o.localidad
FROM oficinas o
WHERE objetivo > ANY (SELECT SUM(e.minimo)
                     FROM empleados e
                     GROUP BY e.oficina);
					 
					 
					 
SELECT o.numoficina, o.localidad
FROM oficinas o
WHERE objetivo > ALL (SELECT SUM(e.minimo)
                     FROM empleados e
                     GROUP BY e.oficina);
					 
					 
					 
SELECT e.num, e.nombre, e.oficina
FROM empleados e
WHERE oficina IN (SELECT o.numoficina
                 FROM oficinas o WHERE zona = 'este');