<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPages/AdminMasterPage.master" AutoEventWireup="true" CodeBehind="frmAlRamzVideos.aspx.cs" Inherits="TG.ExpressCMS.AdminPages.frmAlRamzVideos" %>
<%@ Register src="../UI/Custums/AlRamz/VideoAdmin_UC.ascx" tagname="VideoAdmin_UC" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:VideoAdmin_UC ID="VideoAdmin_UC1" runat="server" />
</asp:Content>
