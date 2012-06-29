<%@ Page Title="" Language="C#" MasterPageFile="~/UserPages/UserSide.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="TG.ExpressCMS.UserPages.Default" %>

<%@ Register Src="~/UI/Custums/Fattoush/BMICalculator_UC.ascx" TagName="BMICalculator_UC"
    TagPrefix="uc4" %>
<%@ Register Src="~/UI/Custums/Fattoush/FattoushContactUs_UC.ascx" TagName="FattoushContactUs_UC"
    TagPrefix="uc5" %>
<%@ Register Src="../UI/Html/HtmlViewer_UC.ascx" TagName="HtmlViewer_UC" TagPrefix="uc7" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc7:HtmlViewer_UC runat="server" HashName="CommentBeforeHeader" />
    <uc5:FattoushContactUs_UC ID="FattoushContactUs_UC1" runat="server" />
</asp:Content>
