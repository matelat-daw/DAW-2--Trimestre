<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
  <xsl:strip-space elements="*"/>
  <xsl:template match="Articulos">
  <html>
  <xsl:apply-templates select="Articulo/nombre"/>
  </html>
  </xsl:template>
  <xsl:template match="nombre">
    <p><xsl:value-of select="."/></p>
    <ul><li><xsl:value-of select="autor"/></li></ul>
  </xsl:template>
</xsl:stylesheet>