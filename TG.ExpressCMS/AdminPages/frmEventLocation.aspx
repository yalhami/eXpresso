<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPages/AdminMasterPage.master" AutoEventWireup="true" CodeBehind="frmEventLocation.aspx.cs" Inherits="TG.ExpressCMS.AdminPages.frmEventLocation" %>
<%@ Register src="../UI/Event/EventLocationAdmin_UC.ascx" tagname="EventLocationAdmin_UC" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:EventLocationAdmin_UC ID="EventLocationAdmin_UC1" runat="server" />
</asp:Content>
