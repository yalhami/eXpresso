<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPages/AdminMasterPage.master"
    AutoEventWireup="true" CodeBehind="frmmViewPostedCareers.aspx.cs" Inherits="TG.ExpressCMS.AdminPages.frmmViewPostedCareers" %>

<%@ Register src="../UI/Careers/PostedCareerViewer_UC.ascx" tagname="PostedCareerViewer_UC" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:PostedCareerViewer_UC ID="PostedCareerViewer_UC1" runat="server" />
</asp:Content>
