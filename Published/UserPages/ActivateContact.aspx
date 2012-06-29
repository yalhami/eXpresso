<%@ Page Title="" Language="C#" MasterPageFile="~/UserPages/UserSide.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TG.ExpressCMS.UserPages.Default" %>
<%@ Register src="~/UI/Contact/ActivateNewsLetterRegistration_UC.ascx" tagname="ActivateNewsLetterRegistration_UC" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <uc1:ActivateNewsLetterRegistration_UC ID="ActivateNewsLetterRegistration_UC1" 
        runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
