<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="ForumAdmin_UC.ascx.cs"
    Inherits="TG.ExpressCMS.UI.Forum.ForumAdmin_UC" %>
<div class="header">
    <h3>
        <asp:Label ID="lblForumPage" runat="server" Text='<%$Resources:ForumResource,ForumManager %>'></asp:Label>
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
                    <asp:Label ID="lblSearchGroup" runat="server" Text='<%$Resources:ForumResource,ForumGroup %>'></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlSearchGroup" runat="server" Width="254">
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
                <asp:ImageButton ID="ibtnActive" runat="server" ToolTip='<%$Resources:ForumResource,Active %>'
                    ImageUrl="~/App_Themes/AdminSide2/Images/active.png" Width="15" Height="15" Visible="true"
                    OnClientClick="return ConfirmDelete();"></asp:ImageButton>
                <asp:ImageButton ID="ibtnInActive" runat="server" ToolTip='<%$Resources:ForumResource,InActive %>'
                    ImageUrl="~/App_Themes/AdminSide2/Images/inactive.png" Width="15" Height="15"
                    Visible="true" OnClientClick="return ConfirmDelete();"></asp:ImageButton>
                <asp:ImageButton ID="ibtnDelete" runat="server" ToolTip='<%$Resources:ForumResource,ibtnDelete %>'
                    ImageUrl="~/App_Themes/AdminSide2/Images/delete.png" Visible="true" OnClientClick="return ConfirmDelete();">
                </asp:ImageButton>
                <asp:ImageButton ID="ibtnAdd" runat="server" ToolTip='<%$Resources:ForumResource,ibtnadd %>'
                    CausesValidation="False" ImageUrl="~/App_Themes/AdminSide2/Images/add.png"></asp:ImageButton></div>
            <div class="gridTitle">
                <asp:Label ID="lblGrdTitleForum" runat="server" Text='<%$Resources:ForumResource,Forum %>'></asp:Label>
            </div>
            <div style="background: white; overflow: auto; width: 100%; height: 100%;">
                <asp:GridView ID="gvForum" runat="server" AllowPaging="true" PageSize="10" AutoGenerateColumns="false"
                    CssClass="grd" Height="20px" Width="100%">
                    <EmptyDataTemplate>
                        <a>No data returned,please select search criterea </a>
                    </EmptyDataTemplate>
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkItem" runat="server" />
                                <input type="hidden" id="hdnID" runat="server" value='<%#DataBinder.Eval(Container,"DataItem.ID")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText='<%$Resources:ForumResource,Name %>'>
                            <ItemTemplate>
                                <asp:LinkButton ID="lblForumName" runat="server" Text='<%#DataBinder.Eval(Container,"DataItem.Name")%>'
                                    CommandArgument='<%#DataBinder.Eval(Container,"DataItem.ID")%>' CommandName="EditForum"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText='<%$Resources:ForumResource,CreationDate %>' DataField="CreationDate" />
                        <asp:BoundField HeaderText='<%$Resources:ForumResource,NumberForumViews %>' DataField="NumberForumViews" />
                        <asp:BoundField HeaderText='<%$Resources:ForumResource,IsActive %>' DataField="IsActive" />
                    </Columns>
                    <EmptyDataTemplate>
                        <asp:Label ID="lblNoForum" runat="server" Text='<%$Resources:ForumResource,NoForum %>'></asp:Label>
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
                            ValidationGroup="AddEditForum" Text="*" Display="Dynamic" ErrorMessage='<%$Resources:ForumResource,Name %>'></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td style="width: 20%">
                        <asp:Label ID="lblDetails" runat="server" Text='<%$Resources:ForumResource,Details %>'></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox Width="250" ID="txtDetails" runat="server" TextMode="MultiLine"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvDetails" runat="server" ControlToValidate="txtDetails"
                            ValidationGroup="AddEditForum" Text="*" Display="Dynamic" ErrorMessage='<%$Resources:ForumResource,Details %>'></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblIsActive" runat="server" Text='<%$Resources:ForumResource,IsActive %>'></asp:Label>
                    </td>
                    <td>
                        <asp:CheckBox ID="chkIsActive" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 20%">
                        <asp:Label ID="lblForumGroup" runat="server" Text='<%$Resources:ForumResource,ForumGroup %>'></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlForumGroup" runat="server" Width="254">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvForumGroup" runat="server" ControlToValidate="ddlForumGroup"
                            ValidationGroup="AddEditForum" Text="*" Display="Dynamic" ErrorMessage='<%$Resources:ForumResource,ForumGroup %>'></asp:RequiredFieldValidator>
                    </td>
                </tr>
            </table>
            <div class="btns">
                <asp:Button CssClass="btn" ID="btnExit" runat="server" Width="60px" CausesValidation="false"
                    Text='<%$Resources:ForumResource, btnExit %>' />
                <asp:Button CssClass="btn" ID="btnReset" runat="server" Width="60px" CausesValidation="false"
                    Text='<%$Resources:ForumResource, btnReset %>' />
                <asp:Button CssClass="btn" ID="btnSave" runat="server" Width="60px" ValidationGroup="AddEditForum"
                    Text='<%$Resources:ForumResource, btnSave %>' />
                <asp:Button CssClass="btn" ID="btnUpdate" runat="server" Width="60px" ValidationGroup="AddEditForum"
                    Text='<%$Resources:ForumResource, btnUpdate %>' />
            </div>
            <asp:ValidationSummary ID="valsummaryContact" runat="server" ValidationGroup="AddEditForum"
                HeaderText='<%$Resources:ForumResource, valSummHeader %>' DisplayMode="BulletList"
                ShowMessageBox="true" ShowSummary="false" />
        </asp:PlaceHolder>
    </ContentTemplate>
</asp:UpdatePanel>
