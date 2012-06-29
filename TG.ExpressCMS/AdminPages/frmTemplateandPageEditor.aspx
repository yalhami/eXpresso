<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPages/AdminMasterPage.master"
    AutoEventWireup="true" CodeBehind="frmTemplateandPageEditor.aspx.cs" Inherits="TG.ExpressCMS.AdminPages.frmTemplateandPageEditor"
    ValidateRequest="false" %>

<%@ Register Src="../UI/TemplatesandPages/PagesTemplatesEditor_UC.ascx" TagName="PagesTemplatesEditor_UC"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:PagesTemplatesEditor_UC ID="PagesTemplatesEditor_UC1" runat="server" />
</asp:Content>
