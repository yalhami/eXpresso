<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPages/AdminMasterPage.master"   EnableEventValidation ="false"  AutoEventWireup="true" CodeBehind="frmManageCareers.aspx.cs" Inherits="TG.ExpressCMS.AdminPages.frmManageCareers" %>
<%@ Register src="../UI/Careers/ManagerCareers_UC.ascx" tagname="ManagerCareers_UC" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:ManagerCareers_UC ID="ManagerCareers_UC1" runat="server" />
</asp:Content>
