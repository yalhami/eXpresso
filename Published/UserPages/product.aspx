<%@ Page Title="" Language="C#" MasterPageFile="~/UserPages/UserSide.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TG.ExpressCMS.UserPages.Default" %>
<%@ Register Src="../UI/Html/HtmlViewer_UC.ascx" TagName="HtmlViewer_UC" TagPrefix="uc7" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<uc7:HtmlViewer_UC runat="server" HashName="product" />
<link rel="stylesheet" type="text/css" href="/slideshow/style.css" />
<div id="gallery">
  <div id="imagearea">
    <div id="image">
      <a href="javascript:slideShow.nav(-1)" class="imgnav " id="previmg"></a>
      <a href="javascript:slideShow.nav(1)" class="imgnav " id="nextimg"></a>
    </div>
  </div>
  <div id="thumbwrapper">
    <div id="thumbarea">
      <ul id="thumbs">
        <li value="1"><img src="/slideshow/thumbs/1.jpg" width="86" height="63" alt="" /></li>
        <li value="2"><img src="/slideshow/thumbs/2.jpg" width="86" height="63" alt="" /></li>
        <li value="3"><img src="/slideshow/thumbs/3.jpg" width="86" height="63" alt="" /></li>
        <li value="4"><img src="/slideshow/thumbs/4.jpg" width="86" height="63" alt="" /></li>
        <li value="5"><img src="/slideshow/thumbs/5.jpg" width="86" height="63" alt="" /></li>
      </ul>
    </div>
  </div>
</div>

<script type="text/javascript">
var imgid = 'image';
var imgdir = '/slideshow/fullsize';
var imgext = '.jpg';
var thumbid = 'thumbs';
var auto = true;
var autodelay = 5;
</script>
<script type="text/javascript" src="/js/slide.js"></script>
</asp:Content>