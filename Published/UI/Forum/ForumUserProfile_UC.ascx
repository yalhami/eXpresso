<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="ForumUserProfile_UC.ascx.cs"
    Inherits="TG.ExpressCMS.UI.Forum.ForumUserProfile_UC" %>
<asp:PlaceHolder ID="plcForumUser" runat="server">
    <div class="header">
        <h3>
            <asp:Label ID="lblForumUserPages" runat="server" Text='<%$Resources:ForumResource,lblForumUserPrfilePages %>'></asp:Label>
        </h3>
    </div>
    <table width="100%" cellpadding="0" cellspacing="5" class="registrtbl">
    <colgroup class="regist-td" />
    <colgroup />
        <tr>
            <td>
                <asp:Label ID="lblName" runat="server" Text='<%$Resources:ForumResource,Name %>'></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblNameValue" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblUserName" runat="server" Text='<%$Resources:ForumResource,Email %>'></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblEmailValue" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblBirthDate" runat="server" Text='<%$Resources:ForumResource,BirthDate %>'></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblBirthDateValue" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblImage" runat="server" Text='<%$Resources:ForumResource,Image %>'></asp:Label>
            </td>
            <td>
                <asp:Image ID="imgForumValue" CssClass="imguser" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblSignature" runat="server" Text='<%$Resources:ForumResource,Signature %>'></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblSignatureValue" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
           
            <td colspan="2" style="background:white">
                <asp:HyperLink ID="lblSecurityInformarion" runat="server" NavigateUrl="~/UserPages/ForumRegistration.aspx"
                    Text='<%$Resources:ForumResource,lblSecurityInformarion %>'></asp:HyperLink>
            </td>
        </tr>
    </table>
</asp:PlaceHolder>
