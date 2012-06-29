<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="ForumUserAdmin_UC.ascx.cs"
    Inherits="TG.ExpressCMS.UI.ForumUser.ForumUserAdmin_UC" %>
<div class="header">
    <h3>
        <asp:Label ID="lblForumUserPage" runat="server" Text='<%$Resources:ForumResource,ForumUserManager %>'></asp:Label>
    </h3>
</div>
<asp:UpdatePanel ID="upnlSearch" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <table>
            <tr>
                <td>
                    <asp:Label ID="lblSearch" runat="server" Text='<%$Resources:ForumResource,Keyword %>'></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtSearch" Width="250px" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="lblSearchUserType" runat="server" Text='<%$Resources:ForumResource,UserType %>'></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlSearchUserType" runat="server" Width="254">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblSearchTrusted" runat="server" Text='<%$Resources:ForumResource,Trusted %>'></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlSearchTrusted" runat="server" Width="254">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Label ID="lblSerarchBanned" runat="server" Text='<%$Resources:ForumResource,Banned %>'></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlSerarchBanned" runat="server" Width="254">
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
        <div class="actions">
            <asp:Button CssClass="btn" ID="btnSearch" runat="server" Text='<%$Resources:ForumResource,btnSearch %>' />
        </div>
        <br />
        <br />
    </ContentTemplate>
</asp:UpdatePanel>
<asp:UpdatePanel ID="upnlGrid" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <div id="dvProblems" runat="server" class="dvmessages">
        </div>
        <asp:PlaceHolder ID="plcGridView" runat="server">
            <div class="imgbtn">
                <asp:ImageButton ID="ibtnTrusted" runat="server" ToolTip='<%$Resources:ForumResource,Trusted %>'
                    ImageUrl="~/App_Themes/AdminSide2/Images/stock_new-meeting.png" Visible="true" OnClientClick="return ConfirmDelete();">
                </asp:ImageButton>
                <asp:ImageButton ID="ibtnNotTrusted" runat="server" ToolTip='<%$Resources:ForumResource,NotTrusted %>'
                    ImageUrl="~/App_Themes/AdminSide2/Images/delete.png" Visible="true" OnClientClick="return ConfirmDelete();">
                </asp:ImageButton>
                <asp:ImageButton ID="ibtnBanned" runat="server" ToolTip='<%$Resources:ForumResource,Banned %>'
                    ImageUrl="~/App_Themes/AdminSide2/Images/inactive.png" Width="15" Height="15"
                    Visible="true" OnClientClick="return ConfirmDelete();"></asp:ImageButton>
                <asp:ImageButton ID="ibtnNotBanned" runat="server" ToolTip='<%$Resources:ForumResource,NotBanned %>'
                    ImageUrl="~/App_Themes/AdminSide2/Images/active.png" Width="15" Height="15" Visible="true"
                    OnClientClick="return ConfirmDelete();"></asp:ImageButton>
                <asp:ImageButton ID="ibtnDelete" runat="server" ToolTip='<%$Resources:ForumResource,ibtnDelete %>'
                    ImageUrl="~/App_Themes/AdminSide2/Images/delete.png" Visible="true" OnClientClick="return ConfirmDelete();">
                </asp:ImageButton>
                <asp:ImageButton ID="ibtnAdd" runat="server" ToolTip='<%$Resources:ForumResource,ibtnadd %>'
                    CausesValidation="False" ImageUrl="~/App_Themes/AdminSide2/Images/add.png"></asp:ImageButton></div>
            <div class="gridTitle">
                <asp:Label ID="lblGrdTitleForumUser" runat="server" Text='<%$Resources:ForumResource,ForumUser %>'></asp:Label>
            </div>
            <div style="background: white; overflow: auto; width: 100%; height: 255px;">
                <asp:GridView ID="gvForumUser" runat="server" AllowPaging="true" PageSize="25" AutoGenerateColumns="false"
                    CssClass="grd" Height="20px" Width="100%">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkItem" runat="server" />
                                <input type="hidden" id="hdnID" runat="server" value='<%#DataBinder.Eval(Container,"DataItem.ID")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText='<%$Resources:ForumResource,Name %>'>
                            <ItemTemplate>
                                <asp:LinkButton ID="lblForumUserName" runat="server" Text='<%#DataBinder.Eval(Container,"DataItem.UserName")%>'
                                    CommandArgument='<%#DataBinder.Eval(Container,"DataItem.ID")%>' CommandName="EditForumUser"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText='<%$Resources:ForumResource,JoinDate %>' DataField="JoinDate" />
                        <asp:BoundField HeaderText='<%$Resources:ForumResource,IsTrusted %>' DataField="IsTrusted" />
                        <asp:BoundField HeaderText='<%$Resources:ForumResource,IsBanned %>' DataField="IsBanned" />
                        <asp:TemplateField HeaderText='<%$Resources:ForumResource,UserType %>'>
                            <ItemTemplate>
                                <asp:Label ID="lblUserType" runat="server" Text='<%#GetUserType(Convert.ToInt32(DataBinder.Eval(Container,"DataItem.ForumUserType")))%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        <asp:Label ID="lblNoItems" runat="server" Text='<%$Resources:ForumResource,NoItems %>'></asp:Label>
                    </EmptyDataTemplate>
                </asp:GridView>
            </div>
        </asp:PlaceHolder>
    </ContentTemplate>
</asp:UpdatePanel>
<asp:UpdatePanel ID="upnlControls" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:PlaceHolder ID="plcControls" runat="server">
            <table width="100%">
                <tr id="rowSecurityAdd" runat="server">
                    <td style="width: 20%">
                        <asp:Label ID="lblSecurityUser" runat="server" Text='<%$Resources:ForumResource,SecurityUser %>'></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlSecurityUser" runat="server" Width="254">
                        </asp:DropDownList>
                        <Ajax:CascadingDropDown ID="ajaxSecurityUser" runat="server" TargetControlID="ddlSecurityUser"
                            Category="Forum" PromptText='<%$Resources:ForumResource,PleaseSelectUser %>'
                            LoadingText='<%$Resources:ForumResource,Loading %>' ServicePath="~/Services/ForumService.asmx"
                            ServiceMethod="GetDropDownSecurityUserNotInForum" SelectedValue="ID" />
                        <asp:RequiredFieldValidator ID="rfvSecurityUser" runat="server" ControlToValidate="ddlSecurityUser"
                            ValidationGroup="AddEditForumUser" Text="*" Display="Dynamic" ErrorMessage='<%$Resources:ForumResource,SecurityUser %>'></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr id="rowSecurityEdit" runat="server">
                    <td>
                        <asp:Label ID="lblSecurityUserInfo" Text='<%$Resources:ForumResource,SecurityUserID %>'
                            runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblSecurityUserID" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblSecurityUserEmail" Text='<%$Resources:ForumResource,SecurityUserEmail %>'
                            runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblSecurityUserEmailValue" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width: 20%">
                        <asp:Label ID="lblName" runat="server" Text='<%$Resources:ForumResource,Name %>'></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox Width="250" ID="txtName" runat="server" MaxLength="50"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName"
                            ValidationGroup="AddEditForumUser" Text="*" Display="Dynamic" ErrorMessage='<%$Resources:ForumResource,Name %>'></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td style="width: 20%">
                        <asp:Label ID="lblUserType" runat="server" Text='<%$Resources:ForumResource,UserType %>'></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlUserType" runat="server" Width="254">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvUserType" runat="server" ControlToValidate="ddlUserType"
                            ValidationGroup="AddEditForumUser" Text="*" Enabled="false" Display="Dynamic"
                            ErrorMessage='<%$Resources:ForumResource,UserType %>'></asp:RequiredFieldValidator>
                    </td>
                    <td style="width: 20%">
                        <asp:Label ID="lblRole" runat="server" Text='<%$Resources:ForumResource,Role %>'></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlRole" runat="server" Width="254">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvRole" runat="server" ControlToValidate="ddlRole"
                            ValidationGroup="AddEditForumUser" Text="*" Display="Dynamic" ErrorMessage='<%$Resources:ForumResource,Role %>'></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td style="width: 20%">
                        <asp:Label ID="lblIsTrusted" runat="server" Text='<%$Resources:ForumResource,IsTrusted %>'></asp:Label>
                    </td>
                    <td>
                        <asp:CheckBox ID="chkIsTrusted" runat="server" />
                    </td>
                    <td style="width: 20%">
                        <asp:Label ID="lblIsBanned" runat="server" Text='<%$Resources:ForumResource,IsBanned %>'></asp:Label>
                    </td>
                    <td>
                        <asp:CheckBox ID="chkIsBanned" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 20%">
                        <asp:Label ID="lblPostsPerPage" runat="server" Text='<%$Resources:ForumResource,PostsPerPage %>'></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPostsPerPage" runat="server"></asp:TextBox>
                        <Ajax:NumericUpDownExtender ID="numPostsPerPage" runat="server" TargetControlID="txtPostsPerPage"
                            Width="120" RefValues="" ServiceDownMethod="" ServiceUpMethod="" TargetButtonDownID=""
                            TargetButtonUpID="" Minimum="5" Maximum="20" />
                    </td>
                    <td style="width: 20%">
                        <asp:Label ID="lblThreadsPerPage" runat="server" Text='<%$Resources:ForumResource,ThreadsPerPage %>'></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtThreadsPerPage" runat="server"></asp:TextBox>
                        <Ajax:NumericUpDownExtender ID="numThreadsPerPage" runat="server" TargetControlID="txtThreadsPerPage"
                            Width="120" RefValues="" ServiceDownMethod="" ServiceUpMethod="" TargetButtonDownID=""
                            TargetButtonUpID="" Minimum="5" Maximum="20" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 20%">
                        <asp:Label ID="lblImage" runat="server" Text='<%$Resources:ForumResource,Image %>'></asp:Label>
                    </td>
                    <td>
                        <asp:FileUpload ID="fUploader" runat="server" />
                        <asp:CheckBox ID="chkChangeImage" runat="server" Text='<%$Resources:ForumResource,ChangeImage %>' />
                    </td>
                    <td style="width: 20%">
                        <asp:Label ID="lblBirthDate" runat="server" Text='<%$Resources:ForumResource,BirthDate %>'></asp:Label>
                    </td>
                    <td>
                        <div>
                            <asp:TextBox Width="135" ID="txtBirthDate" runat="server" MaxLength="50" Enabled="false"></asp:TextBox>
                        </div>
                        <div style="margin-top: -23px; margin-left: 142px;">
                            <Ajax:CalendarExtender ID="calndtxtBirthDate" PopupButtonID="ibtnBirthDate" runat="server"
                                TargetControlID="txtBirthDate" CssClass="cal_Theme1" Format="dd/MM/yyyy" />
                            <asp:ImageButton ID="ibtnBirthDate" Width="23" Height="23" runat="server" ImageUrl="~/App_Themes/AdminSide2/Images/calendar.png" />
                            <asp:RequiredFieldValidator ID="rfvBirthDate" runat="server" ControlToValidate="txtBirthDate"
                                ValidationGroup="AddEditForumUser" Text="*" Display="Dynamic" ErrorMessage='<%$Resources:ForumResource,BirthDate %>'></asp:RequiredFieldValidator>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td style="width: 20%">
                        <asp:Label ID="lblUserRateValue" runat="server" Text='<%$Resources:ForumResource,UserRateValue %>'></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtUserRateValue" runat="server"></asp:TextBox>
                        <Ajax:NumericUpDownExtender ID="numUserRateValue" runat="server" TargetControlID="txtUserRateValue"
                            Width="120" RefValues="" ServiceDownMethod="" ServiceUpMethod="" TargetButtonDownID=""
                            TargetButtonUpID="" Minimum="0" Maximum="100" />
                    </td>
                    <td style="width: 20%">
                        <asp:Label ID="lblSignature" runat="server" Text='<%$Resources:ForumResource,Signature %>'></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox Width="250" ID="txtSignature" runat="server" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <div class="btns">
                <asp:Button CssClass="btn" ID="btnExit" runat="server" Width="60px" CausesValidation="false"
                    Text='<%$Resources:ForumResource, btnExit %>' />
                <asp:Button CssClass="btn" ID="btnReset" runat="server" Width="60px" CausesValidation="false"
                    Text='<%$Resources:ForumResource, btnReset %>' />
                <asp:Button CssClass="btn" ID="btnSave" runat="server" Width="60px" ValidationGroup="AddEditForumUser"
                    Text='<%$Resources:ForumResource, btnSave %>' />
                <asp:Button CssClass="btn" ID="btnUpdate" runat="server" Width="60px" ValidationGroup="AddEditForumUser"
                    Text='<%$Resources:ForumResource, btnUpdate %>' />
            </div>
            <asp:ValidationSummary ID="valsummaryContact" runat="server" ValidationGroup="AddEditForumUser"
                HeaderText='<%$Resources:ForumResource, valSummHeader %>' DisplayMode="BulletList"
                ShowMessageBox="true" ShowSummary="false" />
        </asp:PlaceHolder>
    </ContentTemplate>
    <Triggers>
        <asp:PostBackTrigger ControlID="btnSave" />
        <asp:PostBackTrigger ControlID="btnUpdate" />
    </Triggers>
</asp:UpdatePanel>
