<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="UserRegisUpdate_UC.ascx.cs"
    Inherits="TG.ExpressCMS.UI.Forum.UserRegisUpdate_UC" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HTMLEditor"
    TagPrefix="HTMLEditor" %>
<script type="text/javascript" language="javascript">
    var urlRedirectPage = '';
    function AfterRegisterForumUser(url, msg) {
        alert(msg);
        urlRedirectPage = url;
        //window.setTimeout(RedirectPage, 3000);
        RedirectPage();
    }
    function RedirectPage() {
        window.location = urlRedirectPage;
    }
</script>
<div class="ContentTitle">
    <asp:Label ID="Label1" runat="server" Text='<%$Resources:ForumResource,lblRegisterUsersForums %>'></asp:Label>
</div>
<asp:PlaceHolder ID="plcAddUser" runat="server">
    <div id="dvAddUserProblems" visible="false" runat="server">
    </div>
    <div id="dvAddUserSuccessfully" visible="false" runat="server">
        <div>
            <asp:Label ID="lblAddUserSuccessfully" runat="server" Text='<%$Resources:ForumResource,AddUserSuccessfully %>'></asp:Label>
        </div>
    </div>
    <div id="dvwelcome" runat="server">
        <br />
        <asp:Label ID="lblWelcome" runat="server" Text='<%$Resources:ForumResource,lblWelCome %>'></asp:Label>
        :<asp:Label ID="lblloggenInUsername" runat="server"></asp:Label>
        <br />
        <asp:Label ID="lblChangePassword" runat="server" Text='<%$Resources:ForumResource,lblChangePassword %>'></asp:Label>
        <br />
    </div>
    <div id="dvAddUser" runat="server">
        <table width="100%" cellpadding="0" cellspacing="5" class="registrtbl">
        <colgroup class="rig-lbl" />
        <colgroup ></colgroup>
        <colgroup class="rig-lbl" />
        <colgroup ></colgroup>
            <tr id="rowSecurity" runat="server">
                <td>
                    <asp:Label ID="lblName" runat="server" Text='<%$Resources:ForumResource,Name %>'></asp:Label>
                </td>
                <td>
                    <asp:TextBox CssClass="SubscribeFieldStyle" Width="138px" ID="txtName" runat="server"
                        MaxLength="50"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName"
                        ValidationGroup="AddEditForumUser" Text="*" Display="Dynamic" ErrorMessage='<%$Resources:ForumResource,Name %>'></asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:Label ID="lblUserName" runat="server" Text='<%$Resources:ForumResource,Email %>'></asp:Label>
                </td>
                <td>
                    <asp:TextBox CssClass="SubscribeFieldStyle" Width="138px" ID="txtEmail" runat="server"
                        MaxLength="50"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail"
                        ValidationGroup="AddEditForumUser" Text="*" Display="Dynamic" ErrorMessage='<%$Resources:ForumResource,Email %>'></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblPassword" runat="server" Text='<%$Resources:ForumResource,Password %>'></asp:Label>
                </td>
                <td>
                    <asp:TextBox CssClass="SubscribeFieldStyle" Width="138px" ID="txtPassword" TextMode="Password"
                        runat="server" MaxLength="50"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword"
                        ValidationGroup="AddEditForumUser" Text="*" Display="Dynamic" ErrorMessage='<%$Resources:ForumResource,Password %>'></asp:RequiredFieldValidator>
                        </td><td>
                    <asp:Label ID="lblConfirmPassword" runat="server" Text='<%$Resources:ForumResource,ConfirmPassword %>'></asp:Label>
                    </td><td>
                    <asp:TextBox CssClass="SubscribeFieldStyle" Width="138px" ID="txtConfirmPassword"
                        TextMode="Password" runat="server" MaxLength="50"></asp:TextBox>
                    <asp:CompareValidator ID="comPassword" runat="server" ControlToCompare="txtConfirmPassword"
                        Text="*" ControlToValidate="txtPassword" Operator="Equal" ErrorMessage='<%$Resources:ForumResource,PasswordFieldAndTheConfirmPasswordFieldEqual %>'
                        Type="String" ValidationGroup="AddEditForumUser"></asp:CompareValidator>
                    <asp:RequiredFieldValidator ID="rfvConfirmPassword" runat="server" ControlToValidate="txtConfirmPassword"
                        ValidationGroup="AddEditForumUser" Text="*" Display="Dynamic" ErrorMessage='<%$Resources:ForumResource,ConfirmPassword %>'></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblBirthDate" runat="server" Text='<%$Resources:ForumResource,BirthDate %>'></asp:Label>
                </td>
                <td>
                    <telerik:RadDatePicker ID="txtBirthDate" runat="server" Width="140px" AutoPostBack="false"
                        DateInput-EmptyMessage="Pick a Date" DateInput-DateFormat="dd/MM/yyyy" MinDate="01/01/1900"
                        MaxDate="01/01/3000">
                        <Calendar>
                            <SpecialDays>
                                <telerik:RadCalendarDay Repeatable="Today" ItemStyle-CssClass="rcToday" />
                            </SpecialDays>
                        </Calendar>
                    </telerik:RadDatePicker>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblPostsPerPage" runat="server" Text='<%$Resources:ForumResource,PostsPerPage %>'></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtPostsPerPage" runat="server" CssClass="SubscribeFieldStyle"></asp:TextBox>
                    <Ajax:NumericUpDownExtender ID="numPostsPerPage" runat="server" TargetControlID="txtPostsPerPage"
                        Width="50" RefValues="" ServiceDownMethod="" ServiceUpMethod="" TargetButtonDownID=""
                        TargetButtonUpID="" Minimum="5" Maximum="20" />
                </td>
                <td>
                    <asp:Label ID="lblThreadsPerPage" runat="server" Text='<%$Resources:ForumResource,ThreadsPerPage %>'></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtThreadsPerPage" runat="server" CssClass="SubscribeFieldStyle"></asp:TextBox>
                    <Ajax:NumericUpDownExtender ID="numThreadsPerPage" runat="server" TargetControlID="txtThreadsPerPage"
                        Width="50" RefValues="" ServiceDownMethod="" ServiceUpMethod="" TargetButtonDownID=""
                        TargetButtonUpID="" Minimum="5" Maximum="20" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblImage" runat="server" Text='<%$Resources:ForumResource,Image %>'></asp:Label>
                </td>
                <td colspan="3" background="white">
                    <asp:FileUpload ID="fUploader" runat="server" Width="260" />
                    <asp:CheckBox ID="chkChangeImage" runat="server" Text='<%$Resources:ForumResource,ChangeImage %>' />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblSignature" runat="server" Text='<%$Resources:ForumResource,Signature %>'></asp:Label>
                </td>
                <td colspan="3" background="white">
                    <asp:TextBox CssClass="SubscribeFieldStyle" Width="400px" ID="txtSignature" runat="server"
                        Height="110px" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
        </table>
        <div class="actions">
            <asp:Button CssClass="btn btnSubmit_reset" ID="btnReset" runat="server" Width="60px"
                CausesValidation="false" Text='<%$Resources:ForumResource, btnReset %>' />
            <asp:Button CssClass="btn btnSubmit_save" ID="btnSave" runat="server" Width="60px" ValidationGroup="AddEditForumUser"
                Text='<%$Resources:ForumResource, btnSave %>' />
            <asp:Button CssClass="btn btnSubmit_update" ID="btnUpdate" runat="server" Width="60px"
                ValidationGroup="AddEditForumUser" Text='<%$Resources:ForumResource, btnUpdate %>' />
        </div>
        <asp:ValidationSummary ID="valsummaryContact" runat="server" ValidationGroup="AddEditForumUser"
            HeaderText='<%$Resources:ForumResource, valSummHeader %>' DisplayMode="BulletList"
            ShowMessageBox="true" ShowSummary="false" />
    </div>
</asp:PlaceHolder>
