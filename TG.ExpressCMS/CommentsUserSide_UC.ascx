<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CommentsUserSide_UC.ascx.cs"
    Inherits="TG.ExpressCMS.UI.Comment.CommentsUserSide_UC" %>
<script language="javascript" type="text/javascript">
    function CallSubmit() {
        var name = document.getElementById("<%=txtName.ClientID %>");
        var email = document.getElementById("<%=txtEmail.ClientID %>");
        var txtSubject = document.getElementById("<%=txtSubject.ClientID %>");
        var desc = document.getElementById("<%=txtDetails.ClientID %>");
        var div = document.getElementById("<%=dvMessage.ClientID %>");
        var ipaddress = document.getElementById('<%=hdnIPAddress.ClientID %>');
        var objectid = document.getElementById('<%=hdnObjectID.ClientID %>');
        var msg = document.getElementById('<%=hdnSuccessMsg.ClientID %>');

        if (name.value == "" || email.value == "" || txtSubject.value == "" || desc.value == "") {
            alert("Please review the field(s) below.");
            return false;
        }
        var objx = new MessageArea();
        objx.SaveData(); objx.ClearData();
        return false;
    }
    function ShowResult(res) {
        var objx = new MessageArea();
        objx.SetMessage(res.value, 6000);
    }

    MessageArea = function () {
        var name = document.getElementById("<%=txtName.ClientID %>");
        var email = document.getElementById("<%=txtEmail.ClientID %>");
        var txtSubject = document.getElementById("<%=txtSubject.ClientID %>");
        var desc = document.getElementById("<%=txtDetails.ClientID %>");
        var div = document.getElementById("<%=dvMessage.ClientID %>");
        var ipaddress = document.getElementById('<%=hdnIPAddress.ClientID %>');
        var objectid = document.getElementById('<%=hdnObjectID.ClientID %>');
        var msg = document.getElementById('<%=hdnSuccessMsg.ClientID %>');

     
        this.SaveData = function () {
          
            TG.ExpressCMS.UI.Comment.CommentsUserSide_UC.SubmitForm2(name.value, email.value, desc.value, txtSubject.value, ipaddress.value, objectid.value);
        }

        this.SetMessage = function (msg, timeout) {
            div.innerHTML = msg;
            setTimeout("Hide();", timeout);
        }
        alert(msg.value);
        this.ClearData = function () {
            name.value = "";
            email.value = "";
            txtSubject.value = "";
            desc.value = "";


        }
    }
    function Hide() {
        var div = document.getElementById("<%=dvMessage.ClientID %>");
        div.style.display = 'none';
    }
</script>
<input type="hidden" id="hdnIPAddress" runat="server" />
<input type="hidden" id="hdnObjectID" runat="server" />
<input type="hidden" id="hdnSuccessMsg" runat="server" />
<asp:UpdatePanel ID="upnlDataList" runat="server">
    <ContentTemplate>
        <asp:DataList ID="dtComments" runat="server">
            <HeaderTemplate>
                <asp:Label ID="lblName" runat="server" Text=''></asp:Label>
            </HeaderTemplate>
            <ItemTemplate>
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="lblName" runat="server" Text='<%#DataBinder.Eval(Container,"DataItem.Name") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text='<%#DataBinder.Eval(Container,"DataItem.ModifiedValue") %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                            ___________________________________________
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:DataList>
    </ContentTemplate>
</asp:UpdatePanel>
<asp:UpdatePanel ID="upnall" runat="server">
    <ContentTemplate>
        <asp:Label ID="lblAddComment" runat="server" Text='<%$Resources:ExpressCMS,lblAddComment %>'></asp:Label>
        <div id="dvMessage" runat="server">
        </div>
        <table>
            <tr>
                <td>
                    <asp:Label ID="lblName" runat="server" Text='<%$Resources:ExpressCMS,lblName %>'></asp:Label>
                </td>
                <td>
                    <asp:TextBox Width="250" ID="txtName" runat="server" MaxLength="50"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName"
                        ValidationGroup="Comment" Text="*" Display="Dynamic" ErrorMessage='<%$Resources:ExpressCMS,lblName %>'></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblSubject" runat="server" Text='<%$Resources:ExpressCMS,lblSubject %>'></asp:Label>
                </td>
                <td>
                    <asp:TextBox Width="250" ID="txtSubject" runat="server" MaxLength="50"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvPhone" runat="server" ControlToValidate="txtSubject"
                        ValidationGroup="Comment" Text="*" Display="Dynamic" ErrorMessage='<%$Resources:ExpressCMS,lblPhone %>'></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblEmail" runat="server" Text='<%$Resources:ExpressCMS,lblEmail %>'></asp:Label>
                </td>
                <td>
                    <asp:TextBox Width="250" ID="txtEmail" runat="server" MaxLength="50"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail"
                        ValidationGroup="Comment" Text="*" Display="Dynamic" ErrorMessage='<%$Resources:ExpressCMS,lblEmail %>'></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail"
                        ValidationGroup="Comment" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                        ErrorMessage='<%$Resources:ExpressCMS,validEmail %>'>*</asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblDetails" runat="server" Text='<%$Resources:ExpressCMS,lblDetails %>'></asp:Label>
                </td>
                <td>
                    <asp:TextBox Width="250" ID="txtDetails" runat="server" TextMode="MultiLine" Height="90"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvDescription" runat="server" ControlToValidate="txtDetails"
                        ValidationGroup="Submit" Text="*" Display="Dynamic" ErrorMessage='<%$Resources:ExpressCMS,lblDetails %>'></asp:RequiredFieldValidator>
                </td>
            </tr>
        </table>
        <div class="btns">
            <asp:Button CssClass="btn" ID="btnSaveUpdate" runat="server" Width="60px" ValidationGroup="Comment"
                Text='<%$Resources:ExpressCMS, btnSubmit %>' OnClientClick="CallSubmit(); return false;" />
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
<asp:ValidationSummary ID="valsummaryCat" runat="server" ValidationGroup="Comment"
    HeaderText='<%$Resources:ExpressCMS, valSummHeader %>' DisplayMode="BulletList"
    ShowMessageBox="true" ShowSummary="false" />
