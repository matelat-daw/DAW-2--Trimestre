<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
  <xsl:strip-space elements="*"/>
  <xsl:template match="/">
    <html>
    <h1>Ciclos formativos del CIFP Cesar Manrique</h1>
    <ul>
      <xsl:apply-templates/>
      </ul>
    </html>
  </xsl:template>
  <xsl:template match="ciclo">
    <li>
      <xsl:value-of select="@id"/><br/>
      <xsl:value-of select="nombre"/>
    </li>
  </xsl:template>
</xsl:stylesheet>