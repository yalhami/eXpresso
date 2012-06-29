<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="FattoushContactUs_UC.ascx.cs"
    Inherits="TG.ExpressCMS.UI.Fattoush.ContactUs_UC" %>
<strong>
    <asp:Label ID="lblContactUS" runat="server" Text='<%$Resources:ExpressCMS, lblContactUS %>'></asp:Label>
</strong>
<asp:UpdatePanel ID="upnall" runat="server">
    <ContentTemplate>
        <div id="dvMessage" runat="server">
        </div>
        <table>
            <tr>
                <td>
                    <asp:TextBox CssClass="SubscribeFieldStyle" Width="260" ID="txtName" runat="server"
                        MaxLength="50"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName"
                        ValidationGroup="Submit" Text="*" Display="Dynamic" ErrorMessage='<%$Resources:ExpressCMS,lblName %>'></asp:RequiredFieldValidator>
                    <Ajax:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" runat="server" TargetControlID="txtName"
                        WatermarkText='<%$Resources:ExpressCMS,lblNamewm %>' />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox CssClass="SubscribeFieldStyle" Width="260" ID="txtEmail" runat="server"
                        MaxLength="50"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail"
                        ValidationGroup="Submit" Text="*" Display="Dynamic" ErrorMessage='<%$Resources:ExpressCMS,lblEmail %>'></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail"
                        ValidationGroup="Submit" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                        ErrorMessage='<%$Resources:ExpressCMS,validEmail %>'>*</asp:RegularExpressionValidator>
                    <Ajax:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" TargetControlID="txtEmail"
                        WatermarkText='<%$Resources:ExpressCMS,lblEmailwm %>' />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox CssClass="SubscribeFieldStyle" Width="260" ID="txtPhone" runat="server"
                        MaxLength="50"></asp:TextBox>
                    <Ajax:FilteredTextBoxExtender ID="ftbe" runat="server" TargetControlID="txtPhone"
                        FilterType="Numbers" ValidChars="" />
                    <asp:RequiredFieldValidator ID="rfvPhone" runat="server" ControlToValidate="txtPhone"
                        ValidationGroup="Submit" Text="*" Display="Dynamic" ErrorMessage='<%$Resources:ExpressCMS,lblPhone %>'></asp:RequiredFieldValidator>
                    <Ajax:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender3" runat="server" TargetControlID="txtPhone"
                        WatermarkText='<%$Resources:ExpressCMS,lblPhonewm %>' />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox CssClass="SubscribeFieldStyle" Width="260" ID="txtCountry" runat="server"
                        MaxLength="50"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvCountry" runat="server" ControlToValidate="txtCountry"
                        ValidationGroup="Submit" Text="*" Display="Dynamic" ErrorMessage='<%$Resources:ExpressCMS,lblCountry %>'></asp:RequiredFieldValidator>
                    <Ajax:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender4" runat="server" TargetControlID="txtCountry"
                        WatermarkText='<%$Resources:ExpressCMS,lblCountrywm %>' />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:RadioButton ID="cu" runat="server" Text="اقتراحات او سبب اخر" GroupName="A"
                        Checked="true" />
                    <asp:RadioButton ID="fa" runat="server" Text="طلب حمية غذائية" GroupName="A" />
                </td>
            </tr>
            <%--   <tr>
                <td>
                    <asp:Label ID="lblCompany" runat="server" Text='<%$Resources:ExpressCMS,lblCompany %>'></asp:Label>
                </td>
                <td>
                    <asp:TextBox Width="200" ID="txtCompany" runat="server" MaxLength="50"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv" runat="server" ControlToValidate="txtCompany"
                        ValidationGroup="Submit" Text="*" Display="Dynamic" ErrorMessage='<%$Resources:ExpressCMS,lblCompany %>'></asp:RequiredFieldValidator>
                </td>
            </tr>--%>
            <tr>
                <td>
                    <asp:TextBox Width="510" ID="txtDescription" runat="server" TextMode="MultiLine"
                        Height="140" CssClass="SubscribeFieldStyle"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvDescription" runat="server" ControlToValidate="txtDescription"
                        ValidationGroup="Submit" Text="*" Display="Dynamic" ErrorMessage='<%$Resources:ExpressCMS,lblNotes %>'></asp:RequiredFieldValidator>
                    <Ajax:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender5" runat="server" TargetControlID="txtDescription"
                        WatermarkText='<%$Resources:ExpressCMS,lblNoteswm %>' />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <Ajax:NoBot ID="NoBot2" runat="server" ResponseMinimumDelaySeconds="2" CutoffWindowSeconds="60"
                        CutoffMaximumInstances="5" />
                </td>
            </tr>
        </table>
        <div class="btns">
            <asp:Button CssClass="btn" ID="btnSaveUpdate" runat="server" Width="60px" ValidationGroup="Submit"
                Style="background-image: url(../../App_Themes/DrNouh1/images/Button-Submit.jpg);
                border: 0; float: left;" Height="22" />
        </div>
        <%-- Text='<%$Resources:ExpressCMS, btnSubmit %>'--%>
    </ContentTemplate>
</asp:UpdatePanel>
<asp:ValidationSummary ID="valsummaryCat" runat="server" ValidationGroup="Submit"
    HeaderText='<%$Resources:ExpressCMS, valSummHeader %>' DisplayMode="BulletList"
    ShowMessageBox="true" ShowSummary="false" />
