<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="RolesAdmin_UC.ascx.cs"
    Inherits="TG.ExpressCMS.UI.Security.RolesAdmin_UC" %>
<div class="header">
    <h3>
        <asp:Label ID="lblRoles" runat="server" Text="Roles Manager"></asp:Label>
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
                <asp:Label ID="lblGridTitle" runat="server" Text="Roles"></asp:Label>
            </div>
            <div style="background: white; overflow: auto; width: 100%; height: 220px;">
                <asp:GridView ID="gvRoles" runat="server" AllowPaging="true" PageSize="9" AutoGenerateColumns="false"
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
                                    CommandArgument='<%#DataBinder.Eval(Container,"DataItem.ID") %>' CommandName="EditCat"></asp:LinkButton>
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
                            ValidationGroup="AddEdirRoles" Text="*" Display="Dynamic" ErrorMessage='<%$Resources:ExpressCMS,lblDoctorName %>'></asp:RequiredFieldValidator>
                    </td>
                </tr>
            </table>
            <div class="btns">
                <asp:Button CssClass="btn" ID="btnExit" runat="server" Width="60px" CausesValidation="false"
                    Text='<%$Resources:ExpressCMS, btnExit %>' />
                <asp:Button CssClass="btn" ID="btnReset" runat="server" Width="60px" CausesValidation="false"
                    Text='<%$Resources:ExpressCMS, btnReset %>' />
                <asp:Button CssClass="btn" ID="btnSaveUpdate" runat="server" Width="60px" ValidationGroup="AddEdirRoles"
                    Text='<%$Resources:ExpressCMS, btnSaveUpdate %>' OnClientClick="HideMessage(2000);" />
            </div>
            <asp:ValidationSummary ID="valsummaryCat" runat="server" ValidationGroup="AddEdirRoles"
                HeaderText='<%$Resources:ExpressCMS, valSummHeader %>' DisplayMode="BulletList"
                ShowMessageBox="true" ShowSummary="false" />
        </asp:PlaceHolder>
    </ContentTemplate>
</asp:UpdatePanel>
