<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
<xsl:strip-space elements="*"/>
  <xsl:template match="catalogo">
  <html>
<head><title>Resultado</title></head>
<body>
<table>
<xsl:attribute name="style">border: 1px solid red;</xsl:attribute>
 <tr>
  <th><xsl:attribute name="style">border: 1px solid blue;</xsl:attribute>Nombre</th>
  <th><xsl:attribute name="style">border: 1px solid blue;</xsl:attribute>Año de Nacimiento</th>
</tr>
<xsl:apply-templates select="libro/autores"/>
</table>
</body>
</html>
  </xsl:template>
  <xsl:template match="autor">
  <tr>
  <td><xsl:attribute name="style">border: 1px solid blue;</xsl:attribute><xsl:value-of select="."/></td>
  <td><xsl:attribute name="style">border: 1px solid blue;</xsl:attribute><xsl:value-of select="@nacimiento"/></td>
  </tr>
  </xsl:template>
</xsl:stylesheet>