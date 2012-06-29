<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPages/AdminMasterPage.master" AutoEventWireup="true" CodeBehind="frmTemplateManager.aspx.cs" Inherits="TG.ExpressCMS.AdminPages.frmTemplateManager" %>
<%@ Register src="../UI/TemplatesandPages/TemplateAdmin_UC.ascx" tagname="TemplateAdmin_UC" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:TemplateAdmin_UC ID="TemplateAdmin_UC1" runat="server" />
</asp:Content>
