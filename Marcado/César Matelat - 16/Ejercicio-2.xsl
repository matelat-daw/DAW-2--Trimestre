<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
  <xsl:strip-space elements="*"/>
  <xsl:template match="Articulos">
  <articulos>
    <xsl:apply-templates/>
  </articulos>
  </xsl:template>
  <xsl:template match="Articulo">
  <articulo>
      <xsl:attribute name="identificador"/>
      <xsl:value-of select="Articulo/issn"/>
      <xsl:attribute name="año"/>
      <xsl:value-of select="Articulo/fecha"/>
      <titulo>
        <xsl:value-of select="Articulo/nombre"/>
      </titulo>
      <institucion>
        <xsl:value-of select="Articulo/editor"/>
      </institucion>
        <autores>
          <xsl:apply-templates/>
        </autores>
    </articulo>
    <autor><xsl:value-of select="autor"/></autor>
  </xsl:template>
</xsl:stylesheet>