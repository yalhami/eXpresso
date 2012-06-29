<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPages/AdminMasterPage.master" AutoEventWireup="true" CodeBehind="frmManageContactsGroups.aspx.cs" Inherits="TG.ExpressCMS.AdminPages.frmManageContactsGroups" %>
<%@ Register src="../UI/Contact/GroupsAdmin_UC.ascx" tagname="GroupsAdmin_UC" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:GroupsAdmin_UC ID="GroupsAdmin_UC1" runat="server" />
</asp:Content>
