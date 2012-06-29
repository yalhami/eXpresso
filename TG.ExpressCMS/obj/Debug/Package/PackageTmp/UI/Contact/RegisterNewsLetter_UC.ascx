<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="RegisterNewsLetter_UC.ascx.cs"
    Inherits="TG.ExpressCMS.UI.Contact.RegisterNewsLetter_UC" %>
<%--<script language="javascript" type="text/javascript">
    function CallSubmit() {

        var objx = new MessageArea();
        objx.SaveData();
        return false;
    }
    function ShowResult(res) {
        var objx = new MessageArea();
        objx.SetMessage(res.value, 6000);
    }

    MessageArea = function () {
        var name = document.getElementById("<%=txtName.ClientID %>");
        var email = document.getElementById("<%=txtEmail.ClientID %>");
        var phone = document.getElementById("<%=txtPhone.ClientID %>");
        var country = document.getElementById("<%=txtCountry.ClientID %>");
        var company = document.getElementById("<%=txtCompany.ClientID %>");
        var surname = document.getElementById("<%=txtSurname.ClientID %>");
        var desc = document.getElementById("<%=txtDescription.ClientID %>");
        var div = document.getElementById("<%=dvMessage.ClientID %>");
        this.SaveData = function () {
            TG.ExpressCMS.UI.Contact.RegisterNewsLetter_UC.SubmitForm2(name.value, email.value, phone.value, company.value, country.value, desc.value, surname.value, ShowResult);
        }
        if (email.value == "") {
            alert("Please fill the fields");
            return 0;
        }
        this.SetMessage = function (msg, timeout) {
            div.innerHTML = msg;
            setTimeout("Hide();", timeout);
        }
        this.ClearData = function () {
            name.value = "";
            email.value = "";
            phone.value = "";
            country.value = "";
            company.value = "";
            desc.value = "";

        }
    }
    function Hide() {
        var div = document.getElementById("<%=dvMessage.ClientID %>");
        div.style.display = 'none';
    }
</script>--%>
<strong>
    <asp:Label ID="lblRegisterNewsletter" runat="server" Text='<%$Resources:ExpressCMS,lblRegisterNewsletter %>'></asp:Label>
</strong>
<asp:UpdatePanel ID="upnall" runat="server">
    <ContentTemplate>
        <div id="dvMessage" runat="server" style="color:Red;">
        </div>
        <table width="100%">
            <tr>
                <td>
                    <asp:TextBox CssClass="SubscribeFieldStyle" Width="130" ID="txtName" runat="server"
                        MaxLength="50"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName"
                        ValidationGroup="Regiter" Text="*" Display="Dynamic" ErrorMessage='<%$Resources:ExpressCMS,lblName %>'></asp:RequiredFieldValidator>
                    <asp:TextBox CssClass="SubscribeFieldStyle" Width="120" ID="txtSurname" runat="server"
                        MaxLength="50"></asp:TextBox>
                    <Ajax:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender7" runat="server" TargetControlID="txtSurname"
                        WatermarkText='<%$Resources:ExpressCMS,lblSurNamewm %>' />
                    <asp:RequiredFieldValidator ID="rfvSurName" runat="server" ControlToValidate="txtSurname"
                        ValidationGroup="Regiter" Text="*" Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator>
                    <Ajax:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" runat="server" TargetControlID="txtName"
                        WatermarkText='<%$Resources:ExpressCMS,lblNamewm %>' />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox CssClass="SubscribeFieldStyle" Width="260" ID="txtEmail" runat="server"
                        MaxLength="50"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail"
                        ValidationGroup="Regiter" Text="*" Display="Dynamic" ErrorMessage='<%$Resources:ExpressCMS,lblEmail %>'></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail"
                        ValidationGroup="Regiter" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
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
                        ValidationGroup="Regiter" Text="*" Display="Dynamic" ErrorMessage='<%$Resources:ExpressCMS,lblPhone %>'></asp:RequiredFieldValidator>
                    <Ajax:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender3" runat="server" TargetControlID="txtPhone"
                        WatermarkText='<%$Resources:ExpressCMS,lblPhonewm %>' />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox CssClass="SubscribeFieldStyle" Width="260" ID="txtCountry" runat="server"
                        MaxLength="50"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvCountry" runat="server" ControlToValidate="txtCountry"
                        ValidationGroup="Regiter" Text="*" Display="Dynamic" ErrorMessage='<%$Resources:ExpressCMS,lblCountry %>'></asp:RequiredFieldValidator>
                    <Ajax:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender4" runat="server" TargetControlID="txtCountry"
                        WatermarkText='<%$Resources:ExpressCMS,lblCountrywm %>' />
                </td>
            </tr>
            <tr style="display: none;" runat="server" visible="false">
                <td>
                    <asp:TextBox CssClass="SubscribeFieldStyle" Width="260" ID="txtCompany" runat="server"
                        MaxLength="50"></asp:TextBox>
                    <asp:RequiredFieldValidator Enabled="false" ID="rfv" runat="server" ControlToValidate="txtCompany"
                        ValidationGroup="Regiter" Text="*" Display="Dynamic" ErrorMessage='<%$Resources:ExpressCMS,lblCompany %>'></asp:RequiredFieldValidator>
                    <Ajax:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender5" runat="server" TargetControlID="txtCompany"
                        WatermarkText='<%$Resources:ExpressCMS,lblCompany %>' />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox CssClass="SubscribeFieldStyle" Width="510" ID="txtDescription" runat="server"
                        TextMode="MultiLine" Height="100"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvDescription" runat="server" ControlToValidate="txtDescription"
                        ValidationGroup="Submit" Text="*" Display="Dynamic" ErrorMessage='<%$Resources:ExpressCMS,lblNotes %>'></asp:RequiredFieldValidator>
                    <Ajax:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender6" runat="server" TargetControlID="txtDescription"
                        WatermarkText='<%$Resources:ExpressCMS,lblNoteswm %>' />
                </td>
            </tr>
        </table>
        <div class="btns">
            <%--Text='<%$Resources:ExpressCMS, btnSubmit %>'--%>
            <asp:Button ID="btnSaveUpdate" runat="server" Width="60px" ValidationGroup="Regiter"
                CssClass="btn btnsml" Style="background-image: url(../../App_Themes/DrNouh1/images/Button-Submit.jpg);
                border: 0; float: left;" Height="22" />
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
<asp:ValidationSummary ID="valsummaryCat" runat="server" ValidationGroup="Regiter"
    HeaderText='<%$Resources:ExpressCMS, valSummHeader %>' DisplayMode="BulletList"
    ShowMessageBox="true" ShowSummary="false" />
