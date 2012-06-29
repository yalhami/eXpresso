<%@ Page Title="" Language="C#" MasterPageFile="~/UserPages/UserSide.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="TG.ExpressCMS.UserPages.Default" %>

<%@ Register Src="../UI/Custums/Fatwa/FatwaRequest_UC.ascx" TagName="FatwaRequest_UC"
    TagPrefix="uc1" %>
<%@ Register Src="../UI/Html/HtmlViewer_UC.ascx" TagName="HtmlViewer_UC" TagPrefix="uc7" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="ContentTitle">
        <asp:Label ID="lblFatawaPage" runat="server" Text='<%$Resources:ExpressCMS,lblRequestFatwa %>'></asp:Label>
    </div>
    <uc7:HtmlViewer_UC HashName="FatwaRequestHeader" runat="server" ID="htmlTopHeader" />
    <uc1:FatwaRequest_UC ID="FatwaRequest_UC1" runat="server" />
</asp:Content>
