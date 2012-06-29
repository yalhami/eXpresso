<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="ForumThreadAdmin_UC.ascx.cs"
    Inherits="TG.ExpressCMS.UI.ForumThread.ForumThreadAdmin_UC" %>
<div class="header">
    <h3>
        <asp:Label ID="lblForumThreadPage" runat="server" Text='<%$Resources:ForumResource,ForumThreadManager %>'></asp:Label>
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
                    <asp:Label ID="lblSearchForum" runat="server" Text='<%$Resources:ForumResource,Forum %>'></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlSearchForum" runat="server" Width="254">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblSerarchStatus" runat="server" Text='<%$Resources:ForumResource,Status %>'></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlSearchStatus" runat="server" Width="254">
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
                <asp:ImageButton ID="ibtnApproved" runat="server" ToolTip='<%$Resources:ForumResource,Approved %>'
                    ImageUrl="~/App_Themes/AdminSide2/Images/active.png" Width="15" Height="15" Visible="true" OnClientClick="return ConfirmDelete();">
                </asp:ImageButton>
                <asp:ImageButton ID="ibtnDisApproved" runat="server" ToolTip='<%$Resources:ForumResource,DisApproved %>'
                    ImageUrl="~/App_Themes/AdminSide2/Images/inactive.png" Visible="true" Width="15" Height="15" OnClientClick="return ConfirmDelete();">
                </asp:ImageButton>
                <asp:ImageButton ID="ibtnDelete" runat="server" ToolTip='<%$Resources:ForumResource,ibtnDelete %>'
                    ImageUrl="~/App_Themes/AdminSide2/Images/delete.png" Visible="true" OnClientClick="return ConfirmDelete();">
                </asp:ImageButton>
                <asp:ImageButton ID="ibtnAdd" Visible="false" runat="server" ToolTip='<%$Resources:ForumResource,ibtnadd %>'
                    CausesValidation="False" ImageUrl="~/App_Themes/AdminSide2/Images/add.png"></asp:ImageButton></div>
            <div class="gridTitle">
                <asp:Label ID="lblGrdTitleForumThread" runat="server" Text='<%$Resources:ForumResource,ForumThread %>'></asp:Label>
            </div>
            <div style="background: white; overflow: auto; width: 100%; height: 255px;">
                <asp:GridView ID="gvForumThread" runat="server" AllowPaging="true" PageSize="25"
                    AutoGenerateColumns="false" CssClass="grd" Height="20px" Width="100%">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkItem" runat="server" />
                                <input type="hidden" id="hdnID" runat="server" value='<%#DataBinder.Eval(Container,"DataItem.ID")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText='<%$Resources:ForumResource,Name %>'>
                            <ItemTemplate>
                                <asp:LinkButton ID="lblForumThreadName" runat="server" Text='<%#DataBinder.Eval(Container,"DataItem.Name")%>'
                                    CommandArgument='<%#DataBinder.Eval(Container,"DataItem.ID")%>' CommandName="EditForumThread"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText='<%$Resources:ForumResource,CreationDate %>' DataField="CreationDate" />
                        <asp:BoundField HeaderText='<%$Resources:ForumResource,NumberThreadViews %>' DataField="NumberThreadViews" />
                        <asp:TemplateField HeaderText='<%$Resources:ForumResource,Status %>'>
                            <ItemTemplate>
                                <asp:Label ID="lblThreadStatus" runat="server" Text='<%#GetThreadStatus(Convert.ToInt32(DataBinder.Eval(Container,"DataItem.Status")))%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText='<%$Resources:ForumResource,User %>'>
                            <ItemTemplate>
                                <asp:Label ID="lblThreadUserName" runat="server" Text='<%#DataBinder.Eval(Container,"DataItem.UserSummary.UserName")%>'></asp:Label>
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
                <tr>
                    <td style="width: 20%">
                        <asp:Label ID="lblName" runat="server" Text='<%$Resources:ForumResource,Name %>'></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox Width="250" ID="txtName" runat="server" MaxLength="50"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName"
                            ValidationGroup="AddEditForumThread" Text="*" Display="Dynamic" ErrorMessage='<%$Resources:ForumResource,Name %>'></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td style="width: 20%">
                        <asp:Label ID="lblForum" runat="server" Text='<%$Resources:ForumResource,Forum %>'></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlForum" runat="server" Width="254">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvForum" runat="server" ControlToValidate="ddlForum"
                            ValidationGroup="AddEditForumThread" Text="*" Display="Dynamic" ErrorMessage='<%$Resources:ForumResource,Forum %>'></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td style="width: 20%">
                        <asp:Label ID="lblStatus" runat="server" Text='<%$Resources:ForumResource,Status %>'></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlStatus" runat="server" Width="254">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvStatus" runat="server" ControlToValidate="ddlStatus"
                            ValidationGroup="AddEditForumThread" Text="*" Display="Dynamic" ErrorMessage="Status"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td style="width: 20%">
                        <asp:Label ID="lblDetails" runat="server" Text='<%$Resources:ForumResource,Details %>'></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox Width="250" ID="txtDetails" runat="server" TextMode="MultiLine"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvDetails" runat="server" ControlToValidate="txtDetails"
                            ValidationGroup="AddEditForumThread" Text="*" Display="Dynamic" ErrorMessage='<%$Resources:ForumResource,Details %>'></asp:RequiredFieldValidator>
                    </td>
                </tr>
            </table>
            <div class="btns">
                <asp:Button CssClass="btn" ID="btnExit" runat="server" Width="60px" CausesValidation="false"
                    Text='<%$Resources:ForumResource, btnExit %>' />
                <asp:Button CssClass="btn" ID="btnReset" runat="server" Width="60px" CausesValidation="false"
                    Text='<%$Resources:ForumResource, btnReset %>' />
                <asp:Button CssClass="btn" ID="btnSave" runat="server" Width="60px" ValidationGroup="AddEditForumThread"
                    Text='<%$Resources:ForumResource, btnSave %>' />
                <asp:Button CssClass="btn" ID="btnUpdate" runat="server" Width="60px" ValidationGroup="AddEditForumThread"
                    Text='<%$Resources:ForumResource, btnUpdate %>' />
            </div>
            <asp:ValidationSummary ID="valsummaryContact" runat="server" ValidationGroup="AddEditForumThread"
                HeaderText='<%$Resources:ForumResource, valSummHeader %>' DisplayMode="BulletList"
                ShowMessageBox="true" ShowSummary="false" />
        </asp:PlaceHolder>
    </ContentTemplate>
</asp:UpdatePanel>
