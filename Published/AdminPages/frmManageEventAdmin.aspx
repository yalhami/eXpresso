<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPages/AdminMasterPage.master" AutoEventWireup="true" CodeBehind="frmManageEventAdmin.aspx.cs" Inherits="TG.ExpressCMS.AdminPages.frmManageEventAdmin" %>
<%@ Register src="../UI/Event/EventAdmin_UC.ascx" tagname="EventAdmin_UC" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:EventAdmin_UC ID="EventAdmin_UC1" runat="server" />
</asp:Content>
