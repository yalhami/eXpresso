<%@ Page Title="" Language="C#" MasterPageFile="~/UserPages/UserSide.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="TG.ExpressCMS.UserPages.Default" %>

<%@ Register Src="../UI/Contact/RegisterNewsLetter_UC.ascx" TagName="RegisterNewsLetter_UC"
    TagPrefix="uc6" %>
<%@ Register Src="../UI/Html/HtmlViewer_UC.ascx" TagName="HtmlViewer_UC" TagPrefix="uc7" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc7:HtmlViewer_UC runat="server" ID="contactusheader" HashName="contactusheader" />

    <uc6:RegisterNewsLetter_UC ID="regnewsletter" runat="server" />
</asp:Content>
