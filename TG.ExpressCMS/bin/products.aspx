<%@ Page Title="" Language="C#" MasterPageFile="~/UserPages/UserSide.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="TG.ExpressCMS.UserPages.Default" %>

<%@ Register Src="../UI/News/NewsViewer_UC.ascx" TagName="NewsViewer_UC" TagPrefix="uc16" %>
<%@ Register Src="../UI/Html/HtmlViewer_UC.ascx" TagName="HtmlViewer_UC" TagPrefix="uc17" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc17:htmlviewer_uc ID="Htmlviewer_uc1" runat="server" hashname="Products" />
    <uc16:newsviewer_uc xslid="20" categoryid="42" runat="server" id="newsviewer" Count="39" />
</asp:Content>
