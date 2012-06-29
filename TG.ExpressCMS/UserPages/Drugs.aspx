<%@ Page Title="" Language="C#" MasterPageFile="~/UserPages/UserSide.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TG.ExpressCMS.UserPages.Default" %>

<%@ Register Src="../UI/News/NewsViewer_UC.ascx" TagName="NewsViewer_UC" TagPrefix="uc16" %>
<%@ Register Src="../UI/Html/HtmlViewer_UC.ascx" TagName="HtmlViewer_UC" TagPrefix="uc17" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<uc17:htmlviewer_uc runat="server" hashname="Drugs" />
    <uc16:newsviewer_uc xslid="13" categoryid="33" runat="server" id="newsviewer" count="40" />
</asp:Content>
