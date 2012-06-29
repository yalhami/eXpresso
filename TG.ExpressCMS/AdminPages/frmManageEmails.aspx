<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPages/AdminMasterPage.master"   EnableEventValidation ="false"  AutoEventWireup="true" CodeBehind="frmManageEmails.aspx.cs" Inherits="TG.ExpressCMS.AdminPages.frmManageEmails" %>
<%@ Register src="../UI/Email/EmailAdmin_UC.ascx" tagname="EmailAdmin_UC" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:EmailAdmin_UC ID="EmailAdmin_UC1" runat="server" />
</asp:Content>
