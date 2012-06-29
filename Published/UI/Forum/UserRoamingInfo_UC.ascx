<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="UserRoamingInfo_UC.ascx.cs"
    Inherits="TG.ExpressCMS.UI.UserRoamingInfo_UC" %>
<%@ Register Src="../Html/HtmlViewer_UC.ascx" TagName="HtmlViewer_UC" TagPrefix="uc7" %>
<div style="float: left;" runat="server" id="dvNotLoggedIn">
    <uc7:htmlviewer_uc id="HtmlViewer_UC2" runat="server" hashname="NewUser_RegisterNow_Forum">
    </uc7:htmlviewer_uc>
</div>
<div id="dvLoggedIn" runat="server">
    <table>
        <tr>
            <td>
                <asp:Label ID="lblWelcome" runat="server" Text='<%$Resources:ForumResource,lblWelCome %>'></asp:Label>
                :<asp:LinkButton ID="lblloggenInUsername" NavigateUrl="~/UserPages/ForumUserProfile.aspx"
                    runat="server"></asp:LinkButton>
            </td>
            <td>
                <asp:LinkButton ID="lblLogut" runat="server" Text='<%$Resources:ForumResource,lblLogut %>'></asp:LinkButton>
            </td>
        </tr>
    </table>
</div>
