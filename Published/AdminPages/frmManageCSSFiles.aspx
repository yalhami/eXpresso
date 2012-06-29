<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPages/AdminMasterPage.master" AutoEventWireup="true" CodeBehind="frmManageCSSFiles.aspx.cs" Inherits="TG.ExpressCMS.AdminPages.frmManageCSSFiles" %>
<%@ Register src="../UI/CSS/CSSAdmin_UC.ascx" tagname="CSSAdmin_UC" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CSSAdmin_UC ID="CSSAdmin_UC1" runat="server" />
</asp:Content>
