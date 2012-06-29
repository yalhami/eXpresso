<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPages/AdminMasterPage.master" AutoEventWireup="true" CodeBehind="frmPageAdmin.aspx.cs" Inherits="TG.ExpressCMS.AdminPages.frmPageAdmin" %>
<%@ Register src="../UI/TemplatesandPages/PagesAdmin_UC.ascx" tagname="PagesAdmin_UC" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:PagesAdmin_UC ID="PagesAdmin_UC1" runat="server" />
</asp:Content>
