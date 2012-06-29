<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPages/AdminMasterPage.master" AutoEventWireup="true" CodeBehind="frmChangePassword.aspx.cs" Inherits="TG.ExpressCMS.AdminPages.frmChangePassword" %>
<%@ Register src="../UI/Security/ChangePassword_UC.ascx" tagname="ChangePassword_UC" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:ChangePassword_UC ID="ChangePassword_UC1" runat="server" />
</asp:Content>
