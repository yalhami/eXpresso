<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPages/AdminMasterPage.master"
    AutoEventWireup="true" CodeBehind="frmAdminLanding.aspx.cs" Inherits="TG.ExpressCMS.AdminPages.frmAdminLanding" %>

<%@ Register Src="../UI/AdminLandingDashBoard_UC.ascx" TagName="AdminLandingDashBoard_UC"
    TagPrefix="uc4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>
    </h3>
    <uc4:AdminLandingDashBoard_UC ID="AdminLandingDashBoard_UC1" xslid="10" XmlFileName="XmlDashBoard.xml" runat="server" />
</asp:Content>
