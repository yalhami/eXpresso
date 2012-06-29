<%@ Page Title="" Language="C#" MasterPageFile="~/UserPages/UserSide.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="TG.ExpressCMS.UserPages.Default" %>

<%@ Register Src="../UI/Gallery/GalleryViewer_UC.ascx" TagName="GalleryViewer_UC"
    TagPrefix="uc1" %>
<%@ Register Src="../UI/Html/HtmlViewer_UC.ascx" TagName="HtmlViewer_UC" TagPrefix="uc7" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="ContentTitle">
        укбж Чсецб</div>
    <uc1:GalleryViewer_UC CategoryID="17" PageSize="2" runat="server" />
</asp:Content>
