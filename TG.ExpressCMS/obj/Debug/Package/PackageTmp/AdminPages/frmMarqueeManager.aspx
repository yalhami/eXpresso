<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPages/AdminMasterPage.master" AutoEventWireup="true" CodeBehind="frmMarqueeManager.aspx.cs" Inherits="TG.ExpressCMS.AdminPages.frmMarqueeManager" %>
<%@ Register src="../UI/Marquee/MarqueeAdmin_UC.ascx" tagname="MarqueeAdmin_UC" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:MarqueeAdmin_UC ID="MarqueeAdmin_UC1" runat="server" />
</asp:Content>
