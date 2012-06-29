<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPages/AdminMasterPage.master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="frmInQuiresViewer.aspx.cs" Inherits="TG.ExpressCMS.AdminPages.frmInQuiresViewer" %>
<%@ Register src="../UI/InQuiries/InQuiryViewer_UC.ascx" tagname="InQuiryViewer_UC" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:InQuiryViewer_UC ID="InQuiryViewer_UC1" runat="server" />
</asp:Content>
