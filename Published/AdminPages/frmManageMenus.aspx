<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPages/AdminMasterPage.master" AutoEventWireup="true" CodeBehind="frmManageMenus.aspx.cs" Inherits="TG.ExpressCMS.AdminPages.frmManageMenus" %>
<%@ Register src="../UI/Menus/MenuAdmins_UC.ascx" tagname="MenuAdmins_UC" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:MenuAdmins_UC ID="MenuAdmins_UC1" runat="server" />
</asp:Content>
