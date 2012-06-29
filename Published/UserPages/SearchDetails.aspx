<%@ Page Title="" Language="C#" MasterPageFile="~/UserPages/UserSide.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="TG.ExpressCMS.UserPages.Default" %>

<%@ Register Src="../UI/Html/HtmlViewer_UC.ascx" TagName="HtmlViewer_UC" TagPrefix="uc7" %>
<%@ Register Src="../UI/Search/SearchDetails_UC.ascx" TagName="SearchDetails_UC"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="ContentTitle">
        <uc7:HtmlViewer_UC HashName="SearchDetailsHeader" runat="server" ID="HtmlViewer_UC299" />
    </div>
    <br />
    <uc2:SearchDetails_UC ID="SearchDetails_UC1" runat="server" />
</asp:Content>
