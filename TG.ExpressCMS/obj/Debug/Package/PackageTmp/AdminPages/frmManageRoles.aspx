<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPages/AdminMasterPage.master" AutoEventWireup="true" CodeBehind="frmManageRoles.aspx.cs" Inherits="TG.ExpressCMS.AdminPages.frmManageRoles" %>
<%@ Register src="../UI/Security/RolesAdmin_UC.ascx" tagname="RolesAdmin_UC" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:RolesAdmin_UC ID="RolesAdmin_UC1" runat="server" />
</asp:Content>
