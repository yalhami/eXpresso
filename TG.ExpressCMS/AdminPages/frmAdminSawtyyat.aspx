<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPages/AdminMasterPage.master" EnableEventValidation="false" ValidateRequest="false" AutoEventWireup="true" CodeBehind="frmAdminSawtyyat.aspx.cs" Inherits="TG.ExpressCMS.AdminCustoms.frmAdminSawtyyat" %>
<%@ Register src="../UI/Custums/Sawtyyat/SawwtyyatAdmin_UC.ascx" tagname="SawwtyyatAdmin_UC" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:SawwtyyatAdmin_UC ID="SawwtyyatAdmin_UC1" runat="server" />
</asp:Content>
