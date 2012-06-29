<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPages/AdminMasterPage.master" AutoEventWireup="true" CodeBehind="frmManageSmtpandMailSettings.aspx.cs" Inherits="TG.ExpressCMS.AdminPages.frmManageSmtpandMailSettings" %>
<%@ Register src="../UI/Email/SmtpandEmailAdmin_UC.ascx" tagname="SmtpandEmailAdmin_UC" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:SmtpandEmailAdmin_UC ID="SmtpandEmailAdmin_UC1" runat="server" />
</asp:Content>
