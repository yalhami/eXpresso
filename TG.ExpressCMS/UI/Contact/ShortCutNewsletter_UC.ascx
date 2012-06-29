<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="ShortCutNewsletter_UC.ascx.cs"
    Inherits="TG.ExpressCMS.UI.Contact.ShortCutNewsletter_UC" %>
<div class="SubscribeField">
    <asp:TextBox ID="txtEmailA" runat="server" CssClass="SubscribeFieldStyle" Width="138px"></asp:TextBox>
    <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator1" runat="server"
        ControlToValidate="txtEmailA" Text="*" ErrorMessage='<%$Resources:ExpressCMS, lblEmail %>'
        ValidationGroup="ABCD"></asp:RequiredFieldValidator>
    <Ajax:TextBoxWatermarkExtender ID="rbMessage" runat="server" TargetControlID="txtEmailA"
        WatermarkText='<%$Resources:ExpressCMS, lblEmail %>' />
    <asp:RegularExpressionValidator Display="Dynamic" ID="RegularExpressionValidator1"
        runat="server" ControlToValidate="txtEmailA" Text="*" ErrorMessage='<%$Resources:ExpressCMS, lblEmail %>'
        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="ABCD"></asp:RegularExpressionValidator>
</div>
<div class="SubmitArea">
    <asp:ImageButton CausesValidation="true" ValidationGroup="ABCD" ID="ibtnSubscribe"
        ImageUrl="../../App_Themes/DrNouh1/images/Button-Submit.jpg" Width="48" Height="22"
        runat="server" OnClick="ibtnSubscribe_Click" /></div>
<asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
    DisplayMode="BulletList" ShowSummary="False" ValidationGroup="ABCD" HeaderText='<%$Resources:ExpressCMS, valSummHeader %>' />
<asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmailA"
    ValidationGroup="ABCD" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
    ErrorMessage='<%$Resources:ExpressCMS,validEmail %>'>*</asp:RegularExpressionValidator>
