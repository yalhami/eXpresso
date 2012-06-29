<?xml version="1.0" encoding="utf-8" ?>
<xsl:stylesheet version="1.0"
xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
xmlns:msxsl="urn:schemas-microsoft-com:xslt"
xmlns:CategoryViewer="obj:CategoryViewer">
  
  <xsl:output method="html" indent="yes"/>
  <xsl:template match="/">
    <xsl:call-template name="CreateGallery">
    </xsl:call-template>
  </xsl:template>
  <xsl:template name="CreateGallery" xml:space="default">
    <div class="jMyCarousel highslide-gallery">
      <div class="show-area">
        <ul>
          <xsl:for-each select="/Parent/Item">
            <li style="width:119px; height:104px;">
              <a href="{CategoryViewer:GetImageUrl(@Path)}" class="highslide" onclick="return hs.expand(this)" style="width:119px; height:104px;">
                <img alt="{@Name}" src="{CategoryViewer:GetImageUrl(@Path)}" />
              </a>
            </li>
          </xsl:for-each>
        </ul>
      </div>
    </div>
  </xsl:template>
</xsl:stylesheet>

