<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="FatwaRequest_UC.ascx.cs"
    Inherits="TG.ExpressCMS.UI.Fatwa.FatwaRequest_UC" %>
<asp:UpdatePanel ID="upnlAll" runat="server">
    <ContentTemplate>
        <div id="dvMessages" runat="server">
        </div>
        <table width="100%">
            <tr>
                <td>
                    <asp:TextBox ID="txtName" CssClass="SubscribeFieldStyle" runat="server" Width="260"
                        MaxLength="60"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName"
                        ValidationGroup="reqFatwa" Text="*" ErrorMessage='<%$Resources:ExpressCMS,lblName %>'></asp:RequiredFieldValidator>
                    <Ajax:TextBoxWatermarkExtender ID="rbMessage" runat="server" TargetControlID="txtName"
                        WatermarkText="الاسم..." />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtEmail" CssClass="SubscribeFieldStyle" runat="server" Width="260"
                        MaxLength="60"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfveMail" runat="server" ControlToValidate="txtEmail"
                        ValidationGroup="reqFatwa" Text="*" ErrorMessage='<%$Resources:ExpressCMS,lblEmail %>'></asp:RequiredFieldValidator>
                    <Ajax:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" TargetControlID="txtEmail"
                        WatermarkText="العنوان الالكتروني..." />
                    <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail"
                        ValidationGroup="reqFatwa" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                        ErrorMessage='<%$Resources:ExpressCMS,validEmail %>'>*</asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtQuestion" CssClass="SubscribeFieldStyle" runat="server" Width="520"
                        TextMode="MultiLine" Height="170"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvQuestion" runat="server" ControlToValidate="txtQuestion"
                        ValidationGroup="reqFatwa" Text="*" ErrorMessage='<%$Resources:ExpressCMS,lblQuestion %>'></asp:RequiredFieldValidator>
                    <Ajax:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" runat="server" TargetControlID="txtQuestion"
                        WatermarkText="السؤال..." />
                </td>
            </tr>
        </table>
        <div style="float: left;">
            <asp:Button CssClass="btnSubmit" ID="btnSend" runat="server" Width="60px" CausesValidation="true"
                ValidationGroup="reqFatwa" />
        </div><%--Text='<%$Resources:ExpressCMS, btnSend1 %>'--%>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
            DisplayMode="BulletList" ShowSummary="False" ValidationGroup="reqFatwa" HeaderText='<%$Resources:ExpressCMS, valSummHeader %>' />
    </ContentTemplate>
</asp:UpdatePanel>
