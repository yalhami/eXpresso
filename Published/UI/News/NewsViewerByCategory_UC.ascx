<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="NewsViewerByCategory_UC.ascx.cs"
    Inherits="TG.ExpressCMS.UI.News.NewsViewerByCategory_UC" %>
<%@ Register Src="../Comment/CommentsUserSide_UC.ascx" TagName="CommentsUserSide_UC"
    TagPrefix="uc1" %>
<%@ Register Src="../Controls/CustomPager_UC.ascx" TagName="CustomPager_UC" TagPrefix="uc2" %>
<%@ Register Src="../Html/HtmlViewer_UC.ascx" TagName="HtmlViewer_UC" TagPrefix="uc3" %>
<asp:UpdatePanel ID="upnlAll" runat="server">
    <ContentTemplate>
        <div style="float: right;" class="ContentTitle">
            <uc3:HtmlViewer_UC ID="HtmlViewer_UC1" runat="server" HashName="Articles" />
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
                WatermarkText="ابحث في الدراسات..." />
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                DisplayMode="BulletList" ShowSummary="False" ValidationGroup="SearchValG" HeaderText='<%$Resources:ExpressCMS, valSummHeader %>' />
        </div>
        <asp:Button ID="btnSearch" CssClass="btn" runat="server" ValidationGroup="SearchValG"
            Width="26" Height="22" Style="border-style: solid; border: 0; background: url(../App_Themes/DrNouh1/images/SearchButton.jpg);"
            OnClick="btnSearch_Click" />
        <br />
        <br />
        <div class="SideContentInside" style="float: right; width: 100%">
            <strong style="float: right;"><a runat="server" id="lblTitle">الدراسات</a> </strong>
        </div>
        <br />
        <br />
        <div id="dvProblems" runat="server">
        </div>
        <div id="divMessages" runat="server">
        </div>
        <div id="dvData" runat="server" class="dvData">
        </div>
        <uc2:CustomPager_UC ID="CustomPager_UC1" runat="server" />
    </ContentTemplate>
</asp:UpdatePanel>
