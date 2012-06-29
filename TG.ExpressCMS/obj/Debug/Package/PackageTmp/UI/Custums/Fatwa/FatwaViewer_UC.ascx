<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FatwaViewer_UC.ascx.cs"
    Inherits="TG.ExpressCMS.UI.Fatwa.FatwaViewer_UC" %>
<%@ Register Src="../../Controls/CustomPager_UC.ascx" TagName="CustomPager_UC" TagPrefix="uc2" %>
<asp:UpdatePanel ID="upnlall" runat="server">
    <ContentTemplate>
        <div style="float: right;" class="ContentTitle">
            فتاوى
        </div>
        <div style="float: left;">
            اختر التصنيف:
            <asp:DropDownList ID="ddlCategories" CssClass="SubscribeFieldStyle" runat="server"
                Width="180px" Height="22" AutoPostBack="true" OnSelectedIndexChanged="ddlCategories_SelectedIndexChanged">
            </asp:DropDownList>
        </div>
        <br />
        <br />
        <br />
        <div style="width: 145px; float: right;">
            <asp:TextBox CssClass="SubscribeFieldStyle" ID="txtKeyword" runat="server" Width="165"
                ValidationGroup="SearchValG"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvKeyword" runat="server" ControlToValidate="txtKeyword"
                ErrorMessage="كلمة البحث" Text="*" ValidationGroup="SearchValG"></asp:RequiredFieldValidator>
            <Ajax:TextBoxWatermarkExtender ID="rbMessage" runat="server" TargetControlID="txtKeyword"
                WatermarkText="ابحث في الفتاوى..." />
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                DisplayMode="BulletList" ShowSummary="False" ValidationGroup="SearchValG" HeaderText='<%$Resources:ExpressCMS, valSummHeader %>' />
        </div>
        <asp:Button ID="btnSearch" CssClass="btn" runat="server" ValidationGroup="SearchValG"
            Width="26" Height="22" Style="border-style: solid; border: 0; background: url(../App_Themes/DrNouh1/images/SearchButton.jpg);" />
        <div class="BoldLink">
            <strong><a href="ContactUs.aspx">اطلب فتوى</a> </strong>
        </div>
        <br />
        <br />
        <br />
        <div class="SideContentInside" style="float: right; width: 100%;">
            <div class="SideContent2">
                <strong><a runat="server" id="lblTitle">الفتاوى </a></strong>
            </div>
        </div>
        <br />
        <br />
        <div style="float: right;">
            <div id="dvMessages" runat="server">
            </div>
            <asp:DataList ID="dtlstFatawa" runat="server" RepeatColumns="1" RepeatDirection="Vertical">
                <ItemTemplate>
                    <table>
                        <tr>
                            <th style="float: right; padding-top: 5px; padding-bottom: 5px;">
                                السؤال
                            </th>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lbFatwa" runat="server" CommandArgument='<%#DataBinder.Eval(Container,"DataItem.ID") %>'
                                    Text='<%#MakeStringShorter(DataBinder.Eval(Container,"DataItem.Question").ToString()) %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th style="float: right; padding-top: 5px; padding-bottom: 5px;">
                                الاجابه
                            </th>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lbAnswer" runat="server" CommandArgument='<%#DataBinder.Eval(Container,"DataItem.ID") %>'
                                    Text='<%#MakeStringShorter(DataBinder.Eval(Container,"DataItem.Answer").ToString()) %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="float: left;">
                                <asp:HyperLink ID="hypDetails" runat="server" NavigateUrl='<%#GetDetailsUrl(DataBinder.Eval(Container,"DataItem.ID").ToString()) %>'>التفاصيل...</asp:HyperLink>
                            </td>
                        </tr>
                    </table>
                    <br />
                </ItemTemplate>
            </asp:DataList>
            <br />
            <uc2:CustomPager_UC ID="CustomPager_UC1" runat="server" />
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
