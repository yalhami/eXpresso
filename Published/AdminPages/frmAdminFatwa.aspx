﻿<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPages/AdminMasterPage.master"
    AutoEventWireup="true" CodeBehind="frmAdminFatwa.aspx.cs" Inherits="TG.ExpressCMS.AdminPages.frmAdminFatwa" %>

<%@ Register Src="../UI/Custums/Fatwa/FatwaAdmin_UC.ascx" TagName="FatwaAdmin_UC"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:FatwaAdmin_UC ID="FatwaAdmin_UC1" runat="server" />
</asp:Content>
