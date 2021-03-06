﻿<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="Search_UC.ascx.cs"
    Inherits="TG.ExpressCMS.UI.Search_UC" %>
<asp:UpdatePanel runat="server">
    <ContentTemplate>
        <div class="SearchArea">
            <div style="width: 145px; float: right;">
                <asp:TextBox ID="txtKeyword" runat="server" class="SearchField"></asp:TextBox>
            </div>
            <div style="width: 26px; float: left; margin-top: 08px;">
                <asp:ImageButton ID="btnSearch" runat="server" ValidationGroup="txtSearch" CausesValidation="true"
                    Width="26" Height="26" ImageUrl="~/App_Themes/DrNouh1/images/SearchButton.jpg" />
            </div>
            <Ajax:TextBoxWatermarkExtender ID="rbMessage" runat="server" TargetControlID="txtKeyword"
                WatermarkText='<%$Resources:ExpressCMS,lblSearchwatermark %>' />
            <asp:RequiredFieldValidator ID="rfvKeyword" runat="server" ControlToValidate="txtKeyword"
                ValidationGroup="txtSearch" Display="Dynamic" Text="*" ErrorMessage='<%$Resources:ExpressCMS, lblSearch %>'></asp:RequiredFieldValidator>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                DisplayMode="BulletList" ShowSummary="False" ValidationGroup="txtSearch" HeaderText='<%$Resources:ExpressCMS, valSummHeader %>' />
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
