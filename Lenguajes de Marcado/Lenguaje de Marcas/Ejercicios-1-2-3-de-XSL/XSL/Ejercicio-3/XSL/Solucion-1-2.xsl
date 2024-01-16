<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
<xsl:strip-space elements="*"/>
  <xsl:template match="biblioteca">
  <html>
<head>
<title>Biblioteca</title>
</head>
<body>
<h1>Listado Libros</h1>
<ul>
<xsl:apply-templates/>
</ul>
</body>
</html>
  </xsl:template>
  <xsl:template match="libro">
    <li>Título-<xsl:value-of select="titulo"/>( <xsl:value-of select="autor"/> - <xsl:value-of select="fechaPublicacion/@año"/>)</li>  
  </xsl:template>
</xsl:stylesheet>