<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="CommentsAdmin_UC.ascx.cs"
    Inherits="TG.ExpressCMS.UI.Comment.CommentsAdmin_UC" %>
<div class="header">
    <h3>
        <asp:Label ID="lblCommentPage" runat="server" Text='<%$Resources:ExpressCMS,lblCommentPage %>'></asp:Label>
    </h3>
</div>
<asp:UpdatePanel ID="upnall" runat="server">
    <ContentTemplate>
        <div id="dvProblems" runat="server" class="dvmessages">
        </div>
        <table>
            <tr>
                <td>
                    <asp:Label ID="lblSearch" runat="server" Text="News Category"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlNewsCategory" AutoPostBack="true" runat="server" Width="254">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblNewsItem" runat="server" Text="News Item"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlNews" runat="server" Width="254">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="right">
                    <asp:Button ID="btnSearch" runat="server" Text="Search" CausesValidation="true" CssClass="btn"
                        Height="21" />
                </td>
            </tr>
        </table>
        <asp:PlaceHolder ID="plcGridView" runat="server">
            <div class="imgbtn">
                <asp:ImageButton ID="ibtnDelete" runat="server" ToolTip='<%$Resources:ExpressCMS,ibtnDelete %>'
                    ImageUrl="~/App_Themes/AdminSide2/Images/delete.png" Visible="true" OnClientClick="return ConfirmDelete();">
                </asp:ImageButton>
            </div>
            <div class="gridTitle">
                <asp:Label ID="lblGrdTitleComment" runat="server" Text='<%$Resources:ExpressCMS,lblGrdTitleComment %>'></asp:Label>
            </div>
            <div style="background: white; overflow: auto; width: 100%; height: 255px;">
                <asp:GridView ID="gvComment" runat="server" AllowPaging="true" PageSize="25" AutoGenerateColumns="false"
                    CssClass="grd" Height="20px" Width="100%">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkItem" runat="server" />
                                <input type="hidden" id="hdnID" runat="server" value='<%#DataBinder.Eval(Container,"DataItem.ID") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                Name
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:LinkButton ID="lblgvDoctorName" runat="server" Text='<%#DataBinder.Eval(Container,"DataItem.Subject") %>'
                                    CommandArgument='<%#DataBinder.Eval(Container,"DataItem.ID") %>' CommandName="EditComment"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                E-Mail
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblEmail" runat="server" Text='<%#DataBinder.Eval(Container,"DataItem.Email") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                URL
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:HyperLink Text="URL" runat="server" NavigateUrl='<%#GetURL(Convert.ToInt32(DataBinder.Eval(Container,"DataItem.ObjectID"))) %>'></asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                Status
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblStatusinGrid" runat="server" Text='<%#GetStatus(Convert.ToInt32(DataBinder.Eval(Container,"DataItem.Status"))) %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="plcControls" runat="server">
            <table width="100%">
                <tr>
                    <td>
                        <asp:Label ID="lblIPAddress" runat="server" Text='<%$Resources:ExpressCMS,lblIPAddress %>'></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox Width="250" ID="txtIPAddress" runat="server" MaxLength="50" ReadOnly="true"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtIPAddress"
                            ValidationGroup="Comment" Text="*" Display="Dynamic" ErrorMessage='<%$Resources:ExpressCMS,lblIPAddress %>'></asp:RequiredFieldValidator>
                    </td>
                </tr>
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
                <tr>
                    <td>
                        <asp:Label ID="lblModifiedDetails" runat="server" Text='<%$Resources:ExpressCMS,lblModifiedDetails %>'></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox Width="250" ID="txtModifiedDetails" runat="server" TextMode="MultiLine"
                            Height="90"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvModifiedDetails" runat="server" ControlToValidate="txtModifiedDetails"
                            ValidationGroup="Submit" Text="*" Display="Dynamic" ErrorMessage='<%$Resources:ExpressCMS,lblModifiedDetails %>'></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblStatus" runat="server" Text='<%$Resources:ExpressCMS,lblStatus %>'></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlStatus" runat="server" Width="254">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvStatus" runat="server" ControlToValidate="ddlStatus"
                            ValidationGroup="Submit" Text="*" Display="Dynamic" ErrorMessage='<%$Resources:ExpressCMS,lblStatus %>'></asp:RequiredFieldValidator>
                    </td>
                </tr>
            </table>
            <div class="btns">
                <asp:Button CssClass="btn" ID="btnExit" runat="server" Width="60px" CausesValidation="false"
                    Text='<%$Resources:ExpressCMS, btnExit %>' />
                <asp:Button CssClass="btn" ID="btnReset" runat="server" Width="60px" CausesValidation="false"
                    Text='<%$Resources:ExpressCMS, btnReset %>' />
                <asp:Button CssClass="btn" ID="btnSaveUpdate" runat="server" Width="60px" ValidationGroup="AddEditComment"
                    Text='<%$Resources:ExpressCMS, btnSaveUpdate %>' />
            </div>
            <asp:ValidationSummary ID="valsummaryComment" runat="server" ValidationGroup="AddEditComment"
                HeaderText='<%$Resources:ExpressCMS, valSummHeader %>' DisplayMode="BulletList"
                ShowMessageBox="true" ShowSummary="false" />
        </asp:PlaceHolder>
    </ContentTemplate>
</asp:UpdatePanel>
