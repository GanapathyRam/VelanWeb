<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
  <xsl:template match="/">
    <HTML>
      <HEAD>
        <STYLE>
          .HDR { background-color:bisque;font-weight:bold }
        </STYLE>
      </HEAD>
      <BODY>
        <TABLE border="1">
          <COLGROUP WIDTH="150" ALIGN="LEFT"></COLGROUP>
          <COLGROUP WIDTH="150" ALIGN="LEFT"></COLGROUP>
          <TD CLASS="HDR">Order No</TD>
          <TD CLASS="HDR">Customer Name</TD>
          <xsl:for-each select="NewDataSet/Table">
            <TR>
              <TD>
                <xsl:value-of select="OrderNo"/>
              </TD>
              <TD>
                <xsl:value-of select="CustomerName"/>
              </TD>
            </TR>
          </xsl:for-each>
        </TABLE>
      </BODY>
    </HTML>
  </xsl:template>
</xsl:stylesheet>