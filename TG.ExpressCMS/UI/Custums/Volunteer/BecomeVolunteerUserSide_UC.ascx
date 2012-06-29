<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BecomeVolunteerUserSide_UC.ascx.cs"
    Inherits="TG.ExpressCMS.UI.Custums.Volunteer.BecomeVolunteerUserSide_UC" %>
<asp:UpdatePanel ID="upnlalla" runat="server">
    <ContentTemplate>
        <div id="dvMessages" runat="server">
        </div>
        <asp:TextBox ID="txtName" runat="server" class="txt" Width="200px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvVolunteerName" runat="server" Text="*" ErrorMessage="Name"
            ControlToValidate="txtName" ValidationGroup="becomevol" class="alrt"></asp:RequiredFieldValidator>
        <Ajax:TextBoxWatermarkExtender ID="TBWE2" runat="server" TargetControlID="txtName"
            WatermarkText="Name" />
        <br />
        <asp:TextBox ID="txtEmail" runat="server" class="txt" Width="200px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvEmail" runat="server" Text="*" ErrorMessage="e-Mail"
            ControlToValidate="txtEmail" ValidationGroup="becomevol" class="alrt"></asp:RequiredFieldValidator>
        <Ajax:TextBoxWatermarkExtender ID="tbEmail" runat="server" TargetControlID="txtEmail"
            WatermarkText="e-Mail" />
        <br />
        <asp:FileUpload ID="fbupload" runat="server" Width="180" />
        <br />
        <asp:TextBox ID="txtMessage" runat="server" class="txt" Width="200px" TextMode="MultiLine"
            Height="60"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvmessage" runat="server" Text="*" ErrorMessage="Message"
            ControlToValidate="txtMessage" ValidationGroup="becomevol" class="alrt"></asp:RequiredFieldValidator>
        <Ajax:TextBoxWatermarkExtender ID="rbMessage" runat="server" TargetControlID="txtMessage"
            WatermarkText="Message" />
        <asp:ValidationSummary ID="valsummaryCat" runat="server" ValidationGroup="becomevol"
            HeaderText='<%$Resources:ExpressCMS, valSummHeader %>' DisplayMode="BulletList"
            ShowMessageBox="true" ShowSummary="false" />
        <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="becomevol" CausesValidation="true"
            OnClick="btnSave_Click" CssClass="btn btnsml" />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
    </ContentTemplate>
    <Triggers>
    <asp:PostBackTrigger ControlID="btnSave" />
    </Triggers>
</asp:UpdatePanel>
