<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPages/AdminMasterPage.master" ValidateRequest="false"  AutoEventWireup="true" CodeBehind="frmManageXSL.aspx.cs" Inherits="TG.ExpressCMS.AdminPages.frmManageXSL" %>
<%@ Register src="../UI/XSL/XslTemplateAdmin_UC.ascx" tagname="XslTemplateAdmin_UC" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:XslTemplateAdmin_UC ID="XslTemplateAdmin_UC1" runat="server" />
</asp:Content>
