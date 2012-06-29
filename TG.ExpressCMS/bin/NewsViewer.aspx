<%@ Page Title="" Language="C#" MasterPageFile="~/UserPages/UserSide.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="TG.ExpressCMS.UserPages.Default" %>

<%@ Register Src="../UI/News/NewsViewer_UC.ascx" TagName="NewsViewer_UC" TagPrefix="uc16" %>
<%@ Register Src="../UI/Html/HtmlViewer_UC.ascx" TagName="HtmlViewer_UC" TagPrefix="uc7" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%">
        <tr>
            <td>
                <uc7:htmlviewer_uc runat="server" id="contactusheader" hashname="NewsEvent" />
                <uc16:newsviewer_uc xslid="7" count="99999" categoryid="49" runat="server" id="newsviewer" />
            </td>
            <td>
                <uc7:htmlviewer_uc runat="server" id="htmNewsImage" hashname="NewsImage" />
            </td>
        </tr>
    </table>
</asp:Content>
