<%@ Page Title="" Language="C#" MasterPageFile="~/UserPages/UserSide.Master" AutoEventWireup="true"
    CodeBehind="BannerDetails.aspx.cs" Inherits="TG.ExpressCMS.UserPages.BannerDetails" %>

<%@ Register Src="../UI/Banner/BannerDetailsViewer_UC.ascx" TagName="BannerDetailsViewer_UC"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:BannerDetailsViewer_UC XSLID="16" ID="BannerDetailsViewer_UC1" runat="server" />
</asp:Content>
