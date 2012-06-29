<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPages/AdminMasterPage.master" AutoEventWireup="true" CodeBehind="frmGalleryAdmin.aspx.cs" Inherits="TG.ExpressCMS.AdminPages.frmGalleryAdmin" %>
<%@ Register src="../UI/Gallery/GalleryAdmin_UC.ascx" tagname="GalleryAdmin_UC" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:GalleryAdmin_UC ID="GalleryAdmin_UC1" runat="server" />
</asp:Content>
