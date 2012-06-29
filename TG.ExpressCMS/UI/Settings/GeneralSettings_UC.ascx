<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="GeneralSettings_UC.ascx.cs"
    Inherits="TG.ExpressCMS.UI.GeneralSettings_UC" %>
<div class="header">
    <h3>
        <asp:Label ID="lblSettingPage" runat="server" Text="Settings Manager"></asp:Label>
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
                    CausesValidation="False" ImageUrl="~/App_Themes/AdminSide2/Images/add.png"></asp:ImageButton></div>
            <div class="gridTitle">
                <asp:Label ID="lblGrdTitleSetting" runat="server" Text="Settings"></asp:Label>
            </div>
            <div style="background: white; overflow: auto; width: 100%; height: 255px;">
                <asp:GridView ID="gvSetting" runat="server" AllowPaging="true" PageSize="9" AutoGenerateColumns="false"
                    CssClass="grd" Height="20px" Width="100%">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkItem" runat="server" />
                                <input type="hidden" id="hdnID" runat="server" value='<%#DataBinder.Eval(Container,"DataItem.ID") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="ID" HeaderText="ID" />
                        <asp:TemplateField>
                            <HeaderTemplate>
                                Name
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:LinkButton ID="lblgvDoctorName" runat="server" Text='<%#DataBinder.Eval(Container,"DataItem.Name") %>'
                                    CommandArgument='<%#DataBinder.Eval(Container,"DataItem.ID") %>' CommandName="EditSetting"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                Is Default
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblIsDefault" runat="server" Text='<%#GetIfDefault(Convert.ToBoolean( DataBinder.Eval(Container,"DataItem.IsDefault"))) %>'></asp:Label>
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
                        <asp:Label ID="lblIsDefault" runat="server" Text="Default"></asp:Label>
                    </td>
                    <td>
                        <asp:CheckBox ID="chkdefault" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblDoctorName" runat="server" Text="Name"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox Width="250" ID="txtName" runat="server" MaxLength="50"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName"
                            ValidationGroup="AddEditSetting" Text="*" Display="Dynamic" ErrorMessage="Name"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblDefaultCultureCode" runat="server" Text="Culture Code"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlCulturecodes" runat="server" Width="254">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvCulCode" runat="server" ControlToValidate="ddlCulturecodes"
                            ValidationGroup="AddEditSetting" Text="*" Display="Dynamic" ErrorMessage="Culture"
                            InitialValue=""></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblDefaultURL" runat="server" Text="Default URL"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox Width="250" ID="txtDefURL" runat="server" TextMode="MultiLine" Height="70"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvdefurl" runat="server" ControlToValidate="txtDefURL"
                            ValidationGroup="AddEditSetting" Text="*" Display="Dynamic" ErrorMessage="URL"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblPhysicalAddress" runat="server" Text="Physical Address"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox Width="250" ID="txtphaddress" runat="server" TextMode="MultiLine" Height="70"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvphysicaladdress" runat="server" ControlToValidate="txtphaddress"
                            ValidationGroup="AddEditSetting" Text="*" Display="Dynamic" ErrorMessage="Physical Address"></asp:RequiredFieldValidator>
                    </td>
                </tr>
            </table>
            <div class="btns">
                <asp:Button CssClass="btn" ID="btnExit" runat="server" Width="60px" CausesValidation="false"
                    Text='<%$Resources:ExpressCMS, btnExit %>' />
                <asp:Button CssClass="btn" ID="btnReset" runat="server" Width="60px" CausesValidation="false"
                    Text='<%$Resources:ExpressCMS, btnReset %>' />
                <asp:Button CssClass="btn" ID="btnSaveUpdate" runat="server" Width="60px" ValidationGroup="AddEditSetting"
                    Text='<%$Resources:ExpressCMS, btnSaveUpdate %>' />
            </div>
            <asp:ValidationSummary ID="valsummarySetting" runat="server" ValidationGroup="AddEditSetting"
                HeaderText='<%$Resources:ExpressCMS, valSummHeader %>' DisplayMode="BulletList"
                ShowMessageBox="true" ShowSummary="false" />
        </asp:PlaceHolder>
    </ContentTemplate>
</asp:UpdatePanel>
