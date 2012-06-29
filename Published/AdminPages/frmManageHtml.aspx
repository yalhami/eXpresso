<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPages/AdminMasterPage.master" AutoEventWireup="true" CodeBehind="frmManageHtml.aspx.cs" Inherits="TG.ExpressCMS.AdminPages.frmManageHtml" %>
<%@ Register src="../UI/Html/HtmlAdmin_UC.ascx" tagname="HtmlAdmin_UC" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:HtmlAdmin_UC ID="HtmlAdmin_UC1" runat="server" />
</asp:Content>
