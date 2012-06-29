<%@ Page Title="ÞÓã ÇáÝÊÇæì" Language="C#" MasterPageFile="~/UserPages/UserSide.Master"
    AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TG.ExpressCMS.UserPages.Default" %>

<%@ Register Src="../UI/Html/HtmlViewer_UC.ascx" TagName="HtmlViewer_UC" TagPrefix="uc7" %>
<%@ Register Src="../UI/Custums/Fatwa/FatwaRequest_UC.ascx" TagName="FatwaRequest_UC"
    TagPrefix="uc1" %>
<%@ Register Src="../UI/Custums/Fatwa/FatwaViewer_UC.ascx" TagName="FatwaViewer_UC"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <%-- <div class="ContentTitle">
        <uc7:HtmlViewer_UC HashName="FatwaSection" runat="server" ID="fatwaSection" />
        <a href="FatwaRequest.aspx"></a>
    </div>--%>
   <%-- <br />--%>
    <uc2:FatwaViewer_UC ID="FatwaViewer_UC1" runat="server" />
</asp:Content>
