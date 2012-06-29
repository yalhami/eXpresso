<%@ Page Title="" Language="C#" MasterPageFile="~/UserPages/UserSide.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="TG.ExpressCMS.UserPages.Default" %>

<%@ Register Src="../UI/Html/HtmlViewer_UC.ascx" TagName="HtmlViewer_UC" TagPrefix="uc7" %>
<%@ Register Src="../UI/Menus/MenuViewerxsl_UC.ascx" TagName="MenuViewerxsl_UC" TagPrefix="uc130" %>
<%@ Register Src="../UI/Categories/CategoryViewer_UC.ascx" TagName="CategoryViewer_UC"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table>
        <tr>
            <td>
                <uc7:HtmlViewer_UC runat="server" HashName="product" />
                <br />
                <uc1:CategoryViewer_UC Count="9" XSLID="18" Type="99" ID="CategoryViewer_UC1" runat="server" />
            </td>
            <td rowspan="2">
                <uc7:HtmlViewer_UC runat="server" HashName="productimg" />
            </td>
        </tr>
    </table>
</asp:Content>
