<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="PagePath_UC.ascx.cs"
    Inherits="TG.ExpressCMS.UI.Controls.PagePath_UC" %>
<asp:DataList ID="dlPath" runat="server" CssClass="PagePath" RepeatDirection="Horizontal"
    RepeatLayout="Flow">
    <ItemTemplate>
        <asp:HyperLink ID="hypItemPath" Text='<%#DataBinder.Eval(Container,"DataItem.Name") %>'
            NavigateUrl='<%#DataBinder.Eval(Container,"DataItem.Url") %>' runat="server"></asp:HyperLink>
    </ItemTemplate>
    <ItemStyle CssClass="cssItemPath" />
    <SeparatorTemplate>
        >>
    </SeparatorTemplate>
    <SeparatorStyle CssClass="cssSeparatorPath" />
</asp:DataList>