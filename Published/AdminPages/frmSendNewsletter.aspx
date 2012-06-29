<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPages/AdminMasterPage.master" AutoEventWireup="true" CodeBehind="frmSendNewsletter.aspx.cs" Inherits="TG.ExpressCMS.AdminPages.frmSendNewsletter" %>
<%@ Register src="../UI/Email/SendNewsLetter_UC.ascx" tagname="SendNewsLetter_UC" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:SendNewsLetter_UC ID="SendNewsLetter_UC1" runat="server" />
</asp:Content>
