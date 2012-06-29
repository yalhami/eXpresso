<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPages/AdminMasterPage.master" AutoEventWireup="true" CodeBehind="frmUsersRoles.aspx.cs" Inherits="TG.ExpressCMS.AdminPages.frmUsersRoles" %>
<%@ Register src="../UI/Security/UsersRoles_UC.ascx" tagname="UsersRoles_UC" tagprefix="uc1" %>
<%@ Register src="../UI/Security/PageRoles_UC.ascx" tagname="PageRoles_UC" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc2:PageRoles_UC ID="PageRoles_UC1" runat="server" />
    <uc1:UsersRoles_UC ID="UsersRoles_UC1" runat="server" />
</asp:Content>
