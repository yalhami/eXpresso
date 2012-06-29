<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SearchDetailsDrNouh_UC.ascx.cs"
    Inherits="TG.ExpressCMS.UI.SearchDetailsDrNouh_UC" %>
<%@ Register Src="../Controls/CustomPager_UC.ascx" TagName="CustomPager_UC" TagPrefix="uc1" %>
<asp:UpdateProgress ID="UpdateProgressAnimation" runat="server" DisplayAfter="0">
    <ProgressTemplate>
        <div class="loadingPanel">
            <img alt="Loading..." src="../App_Themes/AdminSide/images/ajax-loader(2).gif" />
        </div>
    </ProgressTemplate>
</asp:UpdateProgress>
<asp:UpdatePanel runat="server">
    <ContentTemplate>
        <div style="overflow: auto; height: 100%">
            <asp:Panel ID="pnlNews" runat="server">
                <strong>
                    <asp:Label ID="Label1" runat="server" Text='<%$Resources:ExpressCMS,lblNewsResult %>'></asp:Label>
                </strong>
                <div id="NoResultNees" runat="server" style="padding-bottom: 5px; padding-top: 5px;">
                </div>
                <asp:DataList ID="dtNews" runat="server" RepeatColumns="1" RepeatDirection="Vertical"
                    RepeatLayout="Table" Width="100%">
                    <ItemTemplate>
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
            </asp:Panel>
            <hr />
            <asp:Panel runat="server" ID="pnlMenus">
                <strong>
                    <asp:Label ID="lblMenu" runat="server" Text='<%$Resources:ExpressCMS,lblMenuResult %>'></asp:Label>
                </strong>
                <div id="dvMenuResult" runat="server" style="padding-bottom: 5px; padding-top: 5px;">
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
            </asp:Panel>
            <hr />
            <asp:Panel runat="server" ID="pnlFatawa">
                <strong>
                    <asp:Label ID="lblFatawa" runat="server" Text='<%$Resources:ExpressCMS,lblFatawa %>'></asp:Label>
                </strong>
                <div id="dvFatawaMessages" runat="server" style="padding-bottom: 5px; padding-top: 5px;">
                </div>
                <asp:DataList ID="dtFatawa" runat="server" RepeatColumns="1" RepeatDirection="Vertical"
                    RepeatLayout="Table" Width="100%">
                    <ItemTemplate>
                        <div style="float: right;">
                            <%--  <strong>
                            <asp:Label ID="lblFatwaHeader" runat="server" Text='<%#DataBinder.Eval(Container,"DataItem.Name") %>'></asp:Label>
                        </strong>--%>
                            <br />
                            <asp:Label ID="lblFatwaDetails" runat="server" Text='<%#MakeStringShorter(DataBinder.Eval(Container,"DataItem.Question").ToString()) %>'></asp:Label>
                            <br />
                        </div>
                        <div style="float: left;">
                            <br />
                            <asp:HyperLink ID="hypfatwadetails" runat="server" NavigateUrl='<%#GetFatawaUrl(DataBinder.Eval(Container,"DataItem.ID").ToString()) %>'
                                Text='<%$Resources:ExpressCMS,lblDetailsSearch %>'></asp:HyperLink>
                        </div>
                    </ItemTemplate>
                </asp:DataList>
                <br />
                <uc1:CustomPager_UC ID="ucFatwaPager" runat="server" />
            </asp:Panel>
            <hr />
            <asp:Panel runat="server" ID="pnlAudVide">
                <strong>
                    <asp:Label ID="lblAudVid" runat="server" Text='<%$Resources:ExpressCMS,lblAudVid %>'></asp:Label>
                </strong>
                <div id="dvAudVidMessages" runat="server" style="padding-bottom: 5px; padding-top: 5px;">
                </div>
                <asp:DataList ID="dtAudVid" runat="server" RepeatColumns="1" RepeatDirection="Vertical"
                    RepeatLayout="Table" Width="100%">
                    <ItemTemplate>
                        <div style="float: right;">
                            <asp:Label ID="lblItemName" runat="server" Text='<%#DataBinder.Eval(Container,"DataItem.Name") %>'></asp:Label>
                            &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                            <br />
                            <%-- <asp:Label ID="lblFatwaDetails" runat="server" Text='<%#MakeStringShorter(DataBinder.Eval(Container,"DataItem.Question").ToString()) %>'></asp:Label>
                        <br />--%>
                        </div>
                        <div style="float: left;">
                            <asp:Label ID="lblType" runat="server" Text='<%#GetType(Convert.ToInt32(DataBinder.Eval(Container,"DataItem.Type"))) %>'></asp:Label>
                            <br />
                            <br />
                            <asp:HyperLink ID="hypfatwadetails" runat="server" NavigateUrl='<%#GetAudVidUrl(DataBinder.Eval(Container,"DataItem.ID").ToString()) %>'
                                Text='<%$Resources:ExpressCMS,lblDetailsSearch %>'></asp:HyperLink>
                        </div>
                    </ItemTemplate>
                </asp:DataList>
                <br />
                <uc1:CustomPager_UC ID="ucAudVid" runat="server" />
            </asp:Panel>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
