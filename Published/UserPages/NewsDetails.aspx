<%@ Page Title="" Language="C#" MasterPageFile="~/UserPages/UserSide.Master" AutoEventWireup="true"  CodeBehind="Default.aspx.cs" Inherits="TG.ExpressCMS.UserPages.Default" %>
<%@ Register src="~/UI/News/NewsDetailsViewer_UC.ascx" tagname="NewsDetailsViewer_UC" tagprefix="uc1" %>
<%@ Register src="../UI/News/RelatedNews_UC.ascx" tagname="RelatedNews_UC" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:NewsDetailsViewer_UC XSLID="11" ID="NewsDetailsViewer_UC2" Visible="true" runat="server" />
    
    <br />
    <h1>
    مقالات ذات صلة
    </h1>
    <uc2:RelatedNews_UC ID="RelatedNews_UC1" runat="server" XSLID="16" />
</asp:Content>
