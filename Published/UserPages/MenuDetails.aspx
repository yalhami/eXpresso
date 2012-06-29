<%@ Page Title="" Language="C#" MasterPageFile="~/UserPages/UserSide.Master" AutoEventWireup="true"  CodeBehind="Default.aspx.cs" Inherits="TG.ExpressCMS.UserPages.Default" %>

<%@ Register src="../UI/Menus/MenuDetailsViewer_UC.ascx" tagname="MenuDetailsViewer_UC" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc2:MenuDetailsViewer_UC xslid="12" ID="MenuDetailsViewer_UC1" runat="server" />
</asp:Content>
