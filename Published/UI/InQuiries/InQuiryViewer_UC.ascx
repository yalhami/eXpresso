<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="InQuiryViewer_UC.ascx.cs"
    Inherits="TG.ExpressCMS.UI.InQuiries.InQuiryViewer_UC" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HTMLEditor"
    TagPrefix="HTMLEditor" %>
<h4>
    <asp:Label ID="lblInQuiryViewer" runat="server" Text='<%$Resources:ExpressCMS, lblInQuireisManager %>'></asp:Label>
</h4>
<asp:UpdatePanel ID="upnlgrid" runat="server" UpdateMode="Conditional">
    <Triggers>
        <asp:PostBackTrigger ControlID="ibtntoExcel" />
    </Triggers>
    <ContentTemplate>
        <div id="dvMessage" runat="server">
        </div>
        <div class="imgbtn">
            <asp:ImageButton ID="ibtnDelete" runat="server" ToolTip='<%$Resources:ExpressCMS,ibtnDelete %>'
                ImageUrl="~/App_Themes/AdminSide2/Images/delete.png" Visible="true" OnClientClick="return ConfirmDelete();">
            </asp:ImageButton>
            <asp:ImageButton ID="ibtntoExcel" runat="server" Width="17" Height="17" ImageUrl="~/App_Themes/AdminSide2/Images/xls.png"
                ToolTip="Export to Excel" />
        </div>
        <div class="gridTitle">
            <asp:Label ID="lblGrdTitleComment" runat="server" Text="In Quries"></asp:Label>
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
                            <asp:LinkButton ID="lblgvDoctorName" runat="server" Text='<%#DataBinder.Eval(Container,"DataItem.Name") %>'
                                CommandArgument='<%#DataBinder.Eval(Container,"DataItem.ID") %>' CommandName="EditInQuiry"></asp:LinkButton>
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
                            Status
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblStatusinGrid" runat="server" Text='<%#GetStatus(Convert.ToInt32(DataBinder.Eval(Container,"DataItem.Status"))) %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <br />
        <asp:CheckBox AutoPostBack="true" Text="Show Reviewed" ID="chkshowReviewed" runat="server" />
    </ContentTemplate>
</asp:UpdatePanel>
<asp:UpdatePanel ID="upnall" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:PlaceHolder ID="plControls" runat="server">
            <table>
                <tr>
                    <td>
                        <asp:Label ID="lblName" runat="server" Text='<%$Resources:ExpressCMS,lblName %>'></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox Width="250" ID="txtName" runat="server" MaxLength="50"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName"
                            ValidationGroup="ReviewInQuires" Text="*" Display="Dynamic" ErrorMessage='<%$Resources:ExpressCMS,lblName %>'></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblEmail" runat="server" Text='<%$Resources:ExpressCMS,lblEmail %>'></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox Width="250" ID="txtEmail" runat="server" MaxLength="50"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail"
                            ValidationGroup="ReviewInQuires" Text="*" Display="Dynamic" ErrorMessage='<%$Resources:ExpressCMS,lblEmail %>'></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail"
                            ValidationGroup="ReviewInQuires" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
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
                            ValidationGroup="ReviewInQuires" Text="*" Display="Dynamic" ErrorMessage='<%$Resources:ExpressCMS,lblPhone %>'></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblCountry" runat="server" Text='<%$Resources:ExpressCMS,lblCountry %>'></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox CssClass="SubscribeFieldStyle" Width="250" ID="txtCountry" runat="server"
                            MaxLength="50"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvCountry" runat="server" ControlToValidate="txtCountry"
                            ValidationGroup="ReviewInQuires" Text="*" Display="Dynamic" ErrorMessage='<%$Resources:ExpressCMS,lblCountry %>'></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr style="display: none;">
                    <td>
                        <asp:Label ID="lblCompany" runat="server" Text='<%$Resources:ExpressCMS,lblCompany %>'></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox CssClass="SubscribeFieldStyle" Width="250" ID="txtCompany" runat="server"
                            MaxLength="50"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv" runat="server" ControlToValidate="txtCompany"
                            ValidationGroup="ReviewInQuires" Text="*" Display="Dynamic" ErrorMessage='<%$Resources:ExpressCMS,lblCompany %>'></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblDescription" runat="server" Text='<%$Resources:ExpressCMS,lblNotes %>'></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox Width="380" ID="txtDescription" runat="server" TextMode="MultiLine"
                            Height="140px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvDescription" runat="server" ControlToValidate="txtDescription"
                            ValidationGroup="ReviewInQuires" Text="*" Display="Dynamic" ErrorMessage='<%$Resources:ExpressCMS,lblNotes %>'></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblReply" runat="server" Text='<%$Resources:ExpressCMS,lblReply %>'></asp:Label>
                    </td>
                    <td>
                        <HTMLEditor:Editor runat="server" Height="300px" Width="65%" AutoFocus="true" ID="txtReply" />
                    </td>
                </tr>
            </table>
            <div class="btns">
                <asp:Button CssClass="btn" ID="btnExit" runat="server" Width="60px" CausesValidation="false"
                    Text='<%$Resources:ExpressCMS, btnExit %>' />
                <asp:Button CssClass="btn" ID="btnReply" runat="server" Width="60px" CausesValidation="false"
                    Text='<%$Resources:ExpressCMS, lblReply %>' />
            </div>
        </asp:PlaceHolder>
    </ContentTemplate>
</asp:UpdatePanel>
<asp:ValidationSummary ID="valsummaryCat" runat="server" ValidationGroup="ReviewInQuires"
    HeaderText='<%$Resources:ExpressCMS, valSummHeader %>' DisplayMode="BulletList"
    ShowMessageBox="true" ShowSummary="false" />
