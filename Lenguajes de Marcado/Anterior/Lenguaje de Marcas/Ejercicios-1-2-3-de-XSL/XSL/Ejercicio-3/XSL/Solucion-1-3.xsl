<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
<xsl:strip-space elements="*"/>
  <xsl:template match="biblioteca">
  <html>
<head>
<title>Biblioteca</title>
</head>
<body>
<h1>Libros con puntuación</h1>
<table>
<tr>
<th>Posición</th>
<th>Título</th>
<th>Puntos</th>
</tr>
<xsl:apply-templates/>
</table>
</body>
</html>
  </xsl:template>
  <xsl:template match="libro">
  <tr>
    <td><xsl:value-of select="position()"/></td>  
    <td><xsl:value-of select="titulo"/></td>
    <td><xsl:value-of select="puntos"/></td>
  </tr>
  </xsl:template>
</xsl:stylesheet>