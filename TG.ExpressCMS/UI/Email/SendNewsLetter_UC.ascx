<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="SendNewsLetter_UC.ascx.cs"
    Inherits="TG.ExpressCMS.UI.Contact.SendNewsLetter_UC" %>
<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="mkb" %>
<script type="text/javascript">

    function HideMessage(timeout) {

        setTimeout("HideDiv1();", timeout);
    }
    function HideDiv1(dvmsg1) {

        var dvmsg = document.getElementById("<%=dverror.ClientID%>");
        dvmsg.style.display = 'none';
    }

</script>
<asp:UpdatePanel runat="server" ID="upnlall">
    <ContentTemplate>
        <div class="header">
            <h3>
                <asp:Label ID="lblEmailSender" runat="server" Text='<%$Resources:ExpressCMS,lblEmailSender %>'></asp:Label>
            </h3>
        </div>
        <div id="dverror" runat="server">
        </div>
        <table width="100%">
            <tr>
                <th align="left" class="gridTitle">
                    <asp:Label ID="lblGroups" runat="server" Text='<%$Resources:ExpressCMS,lblGroups %>'></asp:Label>
                </th>
            </tr>
            <tr>
                <td>
                    <asp:CheckBoxList ID="chkGroups" runat="server" Width="100%" RepeatColumns="4" RepeatDirection="Horizontal"
                        RepeatLayout="Table">
                    </asp:CheckBoxList>
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td>
                    <asp:Label ID="lblEmail" runat="server" Text='<%$Resources:ExpressCMS,lblEmailS %>'></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlEmails" runat="server" Width="254">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvEmails" runat="server" ControlToValidate="ddlEmails"
                        InitialValue="" ValidationGroup="SendEmail" Text="*" Display="Dynamic" ErrorMessage='<%$Resources:ExpressCMS,lblEmailS %>'></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr style="display: none;">
                <td>
                    <asp:Label ID="lblScheduleDate" runat="server" Text='<%$Resources:ExpressCMS,lblScheduleDate %>'></asp:Label>
                </td>
                <td>
                    <table>
                        <tr>
                            <td>
                                <asp:TextBox Width="100" ID="txtDateFrom" runat="server" MaxLength="50"></asp:TextBox>
                                <Ajax:CalendarExtender ID="calextenderfrom" runat="server" TargetControlID="txtDateFrom"
                                    CssClass="cal_Theme1" Format="dd/MM/yyyy" PopupButtonID="ibtnFrom" />
                                <asp:ImageButton ID="ibtnFrom" Width="23" Height="23" runat="server" ImageUrl="~/App_Themes/Adminside2/Images/calendar.png" />
                                <asp:RequiredFieldValidator ID="rfvDate" runat="server" ControlToValidate="txtDateFrom"
                                    ValidationGroup="SendEmail" Text="*" Display="Dynamic" ErrorMessage='<%$Resources:ExpressCMS,lblScheduleDate %>'></asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <mkb:TimeSelector ID="tmSelector" runat="server" AllowSecondEditing="false" DisplayButtons="true"
                                    SelectedTimeFormat="TwentyFour">
                                </mkb:TimeSelector>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <div class="btns">
            <asp:Button CssClass="btn" ID="btnSend" runat="server" Width="60px" ValidationGroup="SendEmail"
                Text='<%$Resources:ExpressCMS, btnSend %>' />
        </div>
        <asp:ValidationSummary ID="valsummaryContact" runat="server" ValidationGroup="AddEditContact"
            HeaderText='<%$Resources:ExpressCMS, valSummHeader %>' DisplayMode="BulletList"
            ShowMessageBox="true" ShowSummary="false" />
    </ContentTemplate>
</asp:UpdatePanel>
