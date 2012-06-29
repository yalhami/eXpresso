<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPages/AdminMasterPage.master"   EnableEventValidation ="false"  AutoEventWireup="true" CodeBehind="frmManageContacts.aspx.cs" Inherits="TG.ExpressCMS.AdminPages.frmManageContacts" %>
<%@ Register src="../UI/Contact/ContactsAdmin_UC.ascx" tagname="ContactsAdmin_UC" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:ContactsAdmin_UC ID="ContactsAdmin_UC1" runat="server" />
</asp:Content>
