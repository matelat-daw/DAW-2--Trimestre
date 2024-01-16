-- 1. Libros comprados en 2011 de la editorial Anaya.

SELECT * FROM libro WHERE Editorial LIKE "%anaya%" AND Year(fechacompra)=2011;

-- 2. Libros de autores entre la C y la G.

SELECT l.Titulo
FROM libro l
WHERE l.Id_Libro IN (SELECT la.Id_Libro FROM libaut la WHERE la.Id_Autor IN (SELECT a.Id_Autor FROM autor a WHERE a.Nombre Between "J%" AND "M%"));


-- 3. Libros entre 2010 y 2014 o que el apellido del autor empiece por Z.

SELECT l.Titulo
FROM libro l
WHERE l.Id_Libro IN (SELECT la.Id_Libro FROM libaut la WHERE la.Id_Autor IN (SELECT a.Id_Autor FROM autor a WHERE a.Nombre LIKE "Z%") AND l.fechacompra BETWEEN "2010-01-01" AND "2014-01-01");


-- 4. Libros que cumplan lo siguiente: (Editorial=Cátedra OR (Editorial=Anaya AND Año=2011)) AND Autor=Benito Pérez Galdós

SELECT l.Titulo
FROM libro l
WHERE l.Editorial LIKE "Cátedra" OR (l.Editorial LIKE "Anaya" AND l.fechacompra BETWEEN "2011-01-01" AND "2011-12-31") AND (SELECT a.Nombre FROM autor a WHERE a.Nombre LIKE "Benito Pérez Galdós");


-- 5. Nº libros de cada editorial.

SELECT l.Editorial, Count(l.Id_Libro) "Cantidad de Libros Publicados"
FROM libro l
GROUP BY l.Editorial;


-- 6. Nº títulos de cada autor.

SELECT l.Titulo, a.Nombre, Count(l.Id_Libro) "Cantidad de Título del Autor"
FROM libro l INNER JOIN libaut la ON l.Id_Libro=la.Id_Libro INNER JOIN autor a ON la.Id_Autor=a.Id_Autor
GROUP BY a.Id_Autor;


-- 7. Nº libros del mismo autor y editorial. (AUN FALLA)

SELECT l.Titulo, COUNT(l.Id_Libro) "Cantidad de Libros"
FROM libro l INNER JOIN libaut la ON l.Id_Libro=la.Id_Libro INNER JOIN autor a ON la.Id_Autor=a.Id_Autor
WHERE (SELECT l.Editorial FROM libro l GROUP BY l.Editorial) AND (SELECT a.Nombre FROM autor a GROUP BY a.Nombre);


-- 8. Listar los nombres de los estudiantes a los que se les prestaron libros de base de datos.




-- 9. Listar el nombre del estudiante de menor edad.




-- 10. Que libros se prestó al lector “Raúl Valdez Alanes”.




-- 11. Que libros son del área de internet.




-- 12. Que autores son de nacionalidad Usa o Francia




-- 13. Quienes son los autores del libro “visual estudio net”, listar solamente los nombres.




-- 14. Listar los nombres de los estudiantes cuyo apellido comience con la letra g




-- 15. Listar los libros que pertenecen al autor Mario Benedetti




-- 16. Listar los datos de los estudiantes cuya edad es mayor al promedio




-- 17. Listar el ISBN y Título de todos aquellos libros que están en préstamo y ya deberían estar devueltos; visualizar también el identificador del alumno que lo tiene y las fechas de préstamo y de devolución. Ordenar la lista descendentemente por el tiempo que hace que lo tenía que haber devuelto (los que haga más tiempo que lo tenían que haber devuelto deben salir los primeros).




-- 18. Listar el Nombre de todos los alumnos que tienen algún libro en préstamo junto con el número total de libros que tienen en préstamo.




-- 19. Obtener el código y el nombre de aquellos autores que tengan libros comprados entre 01/01/2012 y 31/12/2015 y que nunca se han prestado.

