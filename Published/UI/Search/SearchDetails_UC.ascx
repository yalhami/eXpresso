<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SearchDetails_UC.ascx.cs"
    Inherits="TG.ExpressCMS.UI.SearchDetails_UC" %>
<%@ Register Src="../Controls/CustomPager_UC.ascx" TagName="CustomPager_UC" TagPrefix="uc1" %>
<asp:UpdatePanel runat="server">
    <ContentTemplate>
        <div style="overflow: auto; height: 700px">
            <strong>
                <asp:Label ID="Label1" runat="server" Text='<%$Resources:ExpressCMS,lblNewsResult %>'></asp:Label>
            </strong>
            <br />
            <br />
            <div id="NoResultNees" runat="server">
            </div>
            <asp:DataList ID="dtNews" runat="server" RepeatColumns="1" RepeatDirection="Vertical"
                RepeatLayout="Table" Width="100%">
                <ItemTemplate>
                    <div>
                        <div style="float: right;">
                            <strong>
                                <asp:Label ID="lblNewsHeader" runat="server" Text='<%#DataBinder.Eval(Container,"DataItem.Name") %>'></asp:Label>
                            </strong>
                            <br />
                            <br />
                            <asp:Label ID="lblNews" runat="server" Text='<%#MakeStringShorter(DataBinder.Eval(Container,"DataItem.Description").ToString()) %>'></asp:Label>
                            <br />
                        </div>
                        <div style="float: left;">
                            <br />
                            <asp:HyperLink ID="hypDetNews" runat="server" NavigateUrl='<%#DataBinder.Eval(Container,"DataItem.Url") %>'
                                Text='<%$Resources:ExpressCMS,lblDetailsSearch %>'></asp:HyperLink>
                        </div>
                </ItemTemplate>
            </asp:DataList>
            <br />
            <uc1:CustomPager_UC ID="ucNewsPager" runat="server" />
            <hr />
            <strong>
                <asp:Label ID="lblMenu" runat="server" Text='<%$Resources:ExpressCMS,lblMenuResult %>'></asp:Label>
            </strong>
            <br />
            <div id="dvMenuResult" runat="server">
            </div>
            <asp:DataList ID="dtMenus" runat="server" RepeatColumns="1" RepeatDirection="Vertical"
                RepeatLayout="Table" Width="100%">
                <ItemTemplate>
                    <div style="float: right;">
                        <strong>
                            <asp:Label ID="lblMenuHeader" runat="server" Text='<%#DataBinder.Eval(Container,"DataItem.Name") %>'></asp:Label>
                        </strong>
                        <br />
                        <br />
                        <asp:Label ID="lblMenu" runat="server" Text='<%#MakeStringShorter(DataBinder.Eval(Container,"DataItem.Description").ToString()) %>'></asp:Label>
                        <br />
                    </div>
                    <div style="float: left;">
                        <br />
                        <asp:HyperLink ID="hypDetMenu" runat="server" NavigateUrl='<%#DataBinder.Eval(Container,"DataItem.Url") %>'
                            Text='<%$Resources:ExpressCMS,lblDetailsSearch %>'></asp:HyperLink>
                    </div>
                </ItemTemplate>
            </asp:DataList>
            <br />
            <uc1:CustomPager_UC ID="ucMenuPager" runat="server" />
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
