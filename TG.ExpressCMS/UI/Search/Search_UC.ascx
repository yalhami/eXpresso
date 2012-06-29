<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="Search_UC.ascx.cs"
    Inherits="TG.ExpressCMS.UI.Search_UC" %>
<div class="SearchArea">
    <div style="float:left">
        <asp:TextBox ID="txtKeyword" runat="server" class="SearchField"></asp:TextBox>
    </div>
    <div style="float:left">
        <asp:ImageButton ID="btnSearch" runat="server" ValidationGroup="txtSearch" CausesValidation="true"
            Width="11" Height="36" ImageUrl="~/UPLOAD/Files/srchbtn.png"/>
    </div>
    <Ajax:TextBoxWatermarkExtender ID="rbMessage" runat="server" TargetControlID="txtKeyword"
        WatermarkText=" " />
    <asp:RequiredFieldValidator ID="rfvKeyword" runat="server" ControlToValidate="txtKeyword"
        ValidationGroup="txtSearch" Display="Dynamic" Text="*" ErrorMessage='<%$Resources:ExpressCMS, lblSearch %>'></asp:RequiredFieldValidator>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
        DisplayMode="BulletList" ShowSummary="False" ValidationGroup="txtSearch" HeaderText='<%$Resources:ExpressCMS, valSummHeader %>' />
</div>
