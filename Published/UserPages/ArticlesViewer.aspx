<%@ Page Title="" Language="C#" MasterPageFile="~/UserPages/UserSide.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="TG.ExpressCMS.UserPages.Default" %>

<%@ Register Src="../UI/Html/HtmlViewer_UC.ascx" TagName="HtmlViewer_UC" TagPrefix="uc7" %>
<%@ Register Src="../UI/News/NewsViewer_UC.ascx" TagName="NewsViewer_UC" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="ContentTitle">
        <uc7:HtmlViewer_UC HashName="Articles" runat="server" ID="HtmlViewer_UC2" />
    </div>
    <uc1:NewsViewer_UC ID="NewsViewer_UC1" CategoryID="18" XSLID="14" Count="8" runat="server" />
</asp:Content>
