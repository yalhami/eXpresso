<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPages/AdminMasterPage.master" AutoEventWireup="true" CodeBehind="frmFileManager.aspx.cs" Inherits="TG.ExpressCMS.AdminPages.frmFileManager" %>
<%@ Register src="../UI/FileManager/FileManager_UC.ascx" tagname="FileManager_UC" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:FileManager_UC ID="FileManager_UC1" runat="server" />
</asp:Content>
