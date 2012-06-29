<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PagesAdmin_UC.ascx.cs"
    Inherits="TG.ExpressCMS.UI.Security.PagesAdmin_UC" %>
<div class="header">
    <h3>
        <asp:Label ID="lblPagePage" runat="server" Text="Page Administration"></asp:Label>
    </h3>
</div>
<asp:UpdatePanel ID="upnall" runat="server">
    <ContentTemplate>
        <div id="dvProblems" runat="server" class="dvmessages">
        </div>
        <asp:PlaceHolder ID="plcGridView" runat="server">
            <div class="imgbtn">
                <asp:ImageButton ID="ibtnDelete" runat="server" ToolTip='<%$Resources:ExpressCMS,ibtnDelete %>'
                    ImageUrl="~/App_Themes/AdminSide2/Images/delete.png" Visible="true" OnClientClick="return ConfirmDelete();">
                </asp:ImageButton>
                <asp:ImageButton ID="ibtnadd" runat="server" ToolTip='<%$Resources:ExpressCMS,ibtnadd %>'
                    CausesValidation="False" ImageUrl="~/App_Themes/AdminSide2/Images/add.png"></asp:ImageButton>
                <a href="../../AdminPages/frmTemplateandPageEditor.aspx">
                    <img src="../../App_Themes/AdminSide/images/cog-icon-2-48x48.png" />
                </a>
            </div>
            <div class="gridTitle">
                <asp:Label ID="lblGrdTitlePage" runat="server" Text="Pages Administration"></asp:Label>
            </div>
            <div style="background: white; overflow: auto; width: 100%; height: 255px;">
                <asp:GridView ID="gvPage" runat="server" AllowPaging="true" PageSize="9" AutoGenerateColumns="false"
                    CssClass="grd" Height="20px" Width="100%">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkItem" runat="server" />
                                <input type="hidden" id="hdnID" runat="server" value='<%#DataBinder.Eval(Container,"DataItem.ID") %>' />
                                <input type="hidden" id="hdnType" runat="server" value='<%# Convert.ToInt32(DataBinder.Eval(Container,"DataItem.Type")) %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="ID" HeaderText="ID" />
                        <asp:TemplateField>
                            <HeaderTemplate>
                                Name
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:LinkButton ID="lblgvDoctorName" runat="server" Text='<%#DataBinder.Eval(Container,"DataItem.Name") %>'
                                    CommandArgument='<%#DataBinder.Eval(Container,"DataItem.ID") %>' CommandName="EditPage"></asp:LinkButton>
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
                        <asp:Label ID="lblDoctorName" runat="server" Text='<%$Resources:ExpressCMS,lblDoctorName %>'></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox Width="250" ID="txtName" runat="server" MaxLength="50"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName"
                            ValidationGroup="AddEditPage" Text="*" Display="Dynamic" ErrorMessage='<%$Resources:ExpressCMS,lblDoctorName %>'></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblTemplateName" runat="server" Text="Template Name"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlTemplateName" runat="server" Width="254">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblDescription" runat="server" Text='<%$Resources:ExpressCMS,lblDescription %>'></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox Width="250" ID="txtDesc" runat="server" TextMode="MultiLine" Height="70"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvSpecilization" runat="server" ControlToValidate="txtDesc"
                            ValidationGroup="AddEditPage" Text="*" Display="Dynamic" ErrorMessage='<%$Resources:ExpressCMS,lblDescription %>'></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblKeywords" runat="server" Text="Keywords"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox Width="250" ID="txtKeywords" runat="server" TextMode="MultiLine" Height="70"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDesc"
                            ValidationGroup="AddEditPage" Text="*" Display="Dynamic" ErrorMessage="Keywords"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblMetatag" runat="server" Text="Meta Tag"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox Width="250" ID="txtMetaTags" runat="server" TextMode="MultiLine" Height="70"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDesc"
                            ValidationGroup="AddEditPage" Text="*" Display="Dynamic" ErrorMessage="Meta Tags"></asp:RequiredFieldValidator>
                    </td>
                </tr>
            </table>
            <div class="btns">
                <asp:Button CssClass="btn" ID="btnExit" runat="server" Width="60px" CausesValidation="false"
                    Text='<%$Resources:ExpressCMS, btnExit %>' />
                <asp:Button CssClass="btn" ID="btnReset" runat="server" Width="60px" CausesValidation="false"
                    Text='<%$Resources:ExpressCMS, btnReset %>' />
                <asp:Button CssClass="btn" ID="btnSaveUpdate" runat="server" Width="60px" ValidationGroup="AddEditPage"
                    Text='<%$Resources:ExpressCMS, btnSaveUpdate %>' />
            </div>
            <asp:ValidationSummary ID="valsummaryPage" runat="server" ValidationGroup="AddEditPage"
                HeaderText='<%$Resources:ExpressCMS, valSummHeader %>' DisplayMode="BulletList"
                ShowMessageBox="true" ShowSummary="false" />
        </asp:PlaceHolder>
    </ContentTemplate>
</asp:UpdatePanel>
