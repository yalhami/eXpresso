<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SearchDetails_UC.ascx.cs"
    Inherits="TG.ExpressCMS.UI.SearchDetails_UC" %>
<%@ Register Src="../Controls/CustomPager_UC.ascx" TagName="CustomPager_UC" TagPrefix="uc1" %>
<div class="searchresult">
    <h3>
        <asp:Label ID="Label1" runat="server" Text='<%$Resources:ExpressCMS,lblNewsResult %>'></asp:Label>
    </h3>
   
   
    <div id="NoResultNees" runat="server">
    </div>
    <asp:DataList ID="dtNews" runat="server" RepeatColumns="1" RepeatDirection="Vertical"
        RepeatLayout="Table" Width="100%">
        <ItemTemplate>
            <div>
                <div>
                    <strong>
                        <asp:Label ID="lblNewsHeader" runat="server" Text='<%#DataBinder.Eval(Container,"DataItem.Name") %>'></asp:Label>
                    </strong>
                    <br />
                   
                    
                </div>
                <div >
                                       <asp:Label ID="lblNews" runat="server" Text='<%#MakeStringShorter(DataBinder.Eval(Container,"DataItem.Description").ToString()) %>'></asp:Label>

                    <asp:HyperLink ID="hypDetNews" runat="server" NavigateUrl='<%#DataBinder.Eval(Container,"DataItem.Url") %>'
                        Text='<%$Resources:ExpressCMS,lblDetailsSearch %>'></asp:HyperLink>
                </div>
        </ItemTemplate>
    </asp:DataList>
    <div class="pagerdv">
    <uc1:CustomPager_UC ID="ucNewsPager" runat="server" />
    </div>
    <hr />
    <h3>
        <asp:Label ID="lblMenu" runat="server" Text='<%$Resources:ExpressCMS,lblMenuResult %>'></asp:Label>
    </h3>
   
    <div id="dvMenuResult" runat="server">
    </div>
    <asp:DataList ID="dtMenus" runat="server" RepeatColumns="1" RepeatDirection="Vertical"
        RepeatLayout="Table" Width="100%">
        <ItemTemplate>
            <div>
                <strong>
                    <asp:Label ID="lblMenuHeader" runat="server" Text='<%#DataBinder.Eval(Container,"DataItem.Name") %>'></asp:Label>
                </strong>
                <br />
               
                
            </div>
            <div>
                               <asp:Label ID="lblMenu" runat="server" Text='<%#MakeStringShorter(DataBinder.Eval(Container,"DataItem.Description").ToString()) %>'></asp:Label>

                <asp:HyperLink ID="hypDetMenu" runat="server" NavigateUrl='<%#DataBinder.Eval(Container,"DataItem.Url") %>'
                    Text='<%$Resources:ExpressCMS,lblDetailsSearch %>'></asp:HyperLink>
            </div>
        </ItemTemplate>
    </asp:DataList>
    <br />
    <div class="pagerdv">
    <uc1:CustomPager_UC ID="ucMenuPager" runat="server" />
    </div>
</div>
