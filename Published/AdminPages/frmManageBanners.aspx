﻿<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPages/AdminMasterPage.master"
    AutoEventWireup="true" CodeBehind="frmManageBanners.aspx.cs" Inherits="TG.ExpressCMS.AdminPages.frmManageBanners" %>

<%@ Register Src="../UI/Banner/BannerAdmin_UC.ascx" TagName="BannerAdmin_UC" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:BannerAdmin_UC ID="BannerAdmin_UC1" runat="server" />
</asp:Content>
