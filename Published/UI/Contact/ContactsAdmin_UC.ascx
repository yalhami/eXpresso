<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="ContactsAdmin_UC.ascx.cs"
    Inherits="TG.ExpressCMS.UI.Contact.ContactsAdmin_UC" %>
<div class="header">
    <h3>
        <asp:Label ID="lblContactPage" runat="server" Text='<%$Resources:ExpressCMS,lblContactPage %>'></asp:Label>
    </h3>
</div>
<asp:UpdatePanel ID="upnlGird" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <div id="dvProblems" runat="server">
        </div>
        <asp:PlaceHolder ID="plcGridView" runat="server">
            <div class="imgbtn">
                <asp:ImageButton ID="ibtnDelete" runat="server" ToolTip='<%$Resources:ExpressCMS,ibtnDelete %>'
                    ImageUrl="~/App_Themes/AdminSide2/Images/delete.png" Visible="true" OnClientClick="return ConfirmDelete2('gvContact');">
                </asp:ImageButton>
                <asp:ImageButton ID="ibtnadd" runat="server" ToolTip='<%$Resources:ExpressCMS,ibtnadd %>'
                    CausesValidation="False" ImageUrl="~/App_Themes/AdminSide2/Images/add.png"></asp:ImageButton>
                <asp:ImageButton ID="ibtntoExcel" runat="server" Width="17" Height="17" ImageUrl="~/App_Themes/AdminSide2/Images/xls.png"
                    ToolTip="Export to Excel" />
            </div>
            <div class="gridTitle">
                <asp:Label ID="lblGrdTitleContact" runat="server" Text='<%$Resources:ExpressCMS,lblGrdTitleContact %>'></asp:Label>
            </div>
            <div style="background: white; overflow: auto; width: 100%; height: 100%;">
                <asp:GridView ID="gvContact" runat="server" AllowPaging="true" PageSize="10" AutoGenerateColumns="false"
                    CssClass="grd" Height="20px" Width="100%">
                    <EmptyDataTemplate>
                        <a>No data returned,please select search criterea </a>
                    </EmptyDataTemplate>
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
                                <asp:LinkButton ID="lblgvDoctorName" runat="server" Text='<%#GetName( DataBinder.Eval(Container,"DataItem.FirstName").ToString(),DataBinder.Eval(Container,"DataItem.SurName").ToString() ) %>'
                                    CommandArgument='<%#DataBinder.Eval(Container,"DataItem.ID") %>' CommandName="EditContact"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Email" HeaderText="e-Mail" />
                        <asp:TemplateField>
                            <HeaderTemplate>
                                Type
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblStatus" runat="server" Text='<%#GetStatus(Convert.ToInt32(DataBinder.Eval(Container,"DataItem.Status"))) %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
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
                    <td style="width: 70%">
                        <table width="100%">
                            <tr>
                                <td>
                                    <asp:Label ID="lblName" runat="server" Text='<%$Resources:ExpressCMS,lblName %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox Width="120" ID="txtName" runat="server" MaxLength="50"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName"
                                        ValidationGroup="AddEditContact" Text="*" Display="Dynamic" ErrorMessage='<%$Resources:ExpressCMS,lblName %>'></asp:RequiredFieldValidator>
                                    <asp:TextBox Width="120" ID="txtSurname" runat="server" MaxLength="50"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvSurName" runat="server" ControlToValidate="txtSurname"
                                        ValidationGroup="AddEditContact" Text="*" Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblEmail" runat="server" Text='<%$Resources:ExpressCMS,lblEmail %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox Width="250" ID="txtEmail" runat="server" MaxLength="50"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail"
                                        ValidationGroup="AddEditContact" Text="*" Display="Dynamic" ErrorMessage='<%$Resources:ExpressCMS,lblEmail %>'></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail"
                                        ValidationGroup="AddEditContact" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                        ErrorMessage='<%$Resources:ExpressCMS,validEmail %>'>*</asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblPhone" runat="server" Text='<%$Resources:ExpressCMS,lblPhone %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox Width="250" ID="txtPhone" runat="server" MaxLength="50"></asp:TextBox>
                                    <Ajax:FilteredTextBoxExtender ID="ftbe" runat="server" TargetControlID="txtPhone"
                                        FilterType="Numbers" ValidChars="" />
                                    <asp:RequiredFieldValidator ID="rfvPhone" runat="server" ControlToValidate="txtPhone"
                                        ValidationGroup="AddEditContact" Text="*" Display="Dynamic" ErrorMessage='<%$Resources:ExpressCMS,lblPhone %>'></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblMobile" runat="server" Text='<%$Resources:ExpressCMS,lblMobile %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox Width="250" ID="txtMobile" runat="server" MaxLength="50"></asp:TextBox>
                                    <Ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtMobile"
                                        FilterType="Numbers" ValidChars="" />
                                    <asp:RequiredFieldValidator ID="rfvMobile" runat="server" ControlToValidate="txtPhone"
                                        ValidationGroup="AddEditContact" Text="*" Display="Dynamic" ErrorMessage='<%$Resources:ExpressCMS,lblMobile %>'></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblZipCode" runat="server" Text='<%$Resources:ExpressCMS,lblZipCode %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox Width="250" ID="txtZipCode" runat="server" MaxLength="50"></asp:TextBox>
                                    <Ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtZipCode"
                                        FilterType="Numbers" ValidChars="" />
                                    <asp:RequiredFieldValidator ID="rfvZipCode" runat="server" ControlToValidate="txtZipCode"
                                        ValidationGroup="AddEditContact" Text="*" Display="Dynamic" ErrorMessage='<%$Resources:ExpressCMS,lblZipCode %>'></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblCountry" runat="server" Text='<%$Resources:ExpressCMS,lblCountry %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox Width="250" ID="txtCountry" runat="server" MaxLength="50"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvCountry" runat="server" ControlToValidate="txtCountry"
                                        ValidationGroup="AddEditContact" Text="*" Display="Dynamic" ErrorMessage='<%$Resources:ExpressCMS,lblCountry %>'></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblCompany" runat="server" Text='<%$Resources:ExpressCMS,lblCompany %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox Width="250" ID="txtCompany" runat="server" MaxLength="50"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfv" runat="server" ControlToValidate="txtCompany"
                                        ValidationGroup="AddEditContact" Text="*" Display="Dynamic" ErrorMessage='<%$Resources:ExpressCMS,lblCompany %>'></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblStatus" runat="server" Text='<%$Resources:ExpressCMS,lblStatus %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:RadioButton ID="rdbActive" runat="server" Text='<%$Resources:ExpressCMS,lblActive %>'
                                        GroupName="A" />
                                    <asp:RadioButton ID="rdbInActive" runat="server" Text='<%$Resources:ExpressCMS,lblInActive %>'
                                        GroupName="A" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblDescription" runat="server" Text='<%$Resources:ExpressCMS,lblNotes %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox Width="250" ID="txtDescription" runat="server" TextMode="MultiLine"
                                        Height="75px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvDescription" runat="server" ControlToValidate="txtDescription"
                                        ValidationGroup="AddEditContact" Text="*" Display="Dynamic" ErrorMessage='<%$Resources:ExpressCMS,lblNotes %>'></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td valign="top">
                        <h3>
                            <asp:Label ID="lblGroups" runat="server" Text='<%$Resources:ExpressCMS,lblGroups %>'></asp:Label>
                        </h3>
                        <br />
                        <asp:CheckBoxList ID="chkGroups" runat="server" RepeatColumns="1" RepeatDirection="Vertical">
                        </asp:CheckBoxList>
                    </td>
                </tr>
            </table>
            <div class="btns">
                <asp:Button CssClass="btn" ID="btnExit" runat="server" Width="60px" CausesValidation="false"
                    Text='<%$Resources:ExpressCMS, btnExit %>' />
                <asp:Button CssClass="btn" ID="btnReset" runat="server" Width="60px" CausesValidation="false"
                    Text='<%$Resources:ExpressCMS, btnReset %>' />
                <asp:Button CssClass="btn" ID="btnSaveUpdate" runat="server" Width="60px" ValidationGroup="AddEditContact"
                    Text='<%$Resources:ExpressCMS, btnSaveUpdate %>' />
            </div>
            <asp:ValidationSummary ID="valsummaryContact" runat="server" ValidationGroup="AddEditContact"
                HeaderText='<%$Resources:ExpressCMS, valSummHeader %>' DisplayMode="BulletList"
                ShowMessageBox="true" ShowSummary="false" />
        </asp:PlaceHolder>
    </ContentTemplate>
    <Triggers>
        <asp:PostBackTrigger ControlID="ibtntoExcel" />
    </Triggers>
</asp:UpdatePanel>
