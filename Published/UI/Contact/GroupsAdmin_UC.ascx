<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="GroupsAdmin_UC.ascx.cs"
    Inherits="TG.ExpressCMS.UI.Contact.GroupsAdmin_UC" %>
<div class="header">
    <h3>
        <asp:Label ID="lblGroupPage" runat="server" Text="Group Page"></asp:Label>
    </h3>
</div>
<asp:UpdatePanel ID="upnall" runat="server">
    <ContentTemplate>
        <div id="dvProblems" runat="server">
        </div>
        <asp:PlaceHolder ID="plcGridView" runat="server">
            <div class="imgbtn">
                <asp:ImageButton ID="ibtnDelete" runat="server" ToolTip='<%$Resources:ExpressCMS,ibtnDelete %>'
                    ImageUrl="~/App_Themes/AdminSide2/Images/delete.png" Visible="true" OnClientClick="return ConfirmDelete();" />
                <asp:ImageButton ID="ibtnadd" runat="server" Text="Add" CausesValidation="False"
                    ImageUrl="~/App_Themes/AdminSide2/Images/add.png"></asp:ImageButton></div>
            <div class="gridTitle">
                <asp:Label ID="lblGrdTitleGroup" runat="server" Text="Groups"></asp:Label>
            </div>
            <div style="background: white; overflow: auto; width: 100%; height: 100%;">
                <asp:GridView ID="gvGroup" runat="server" AutoGenerateColumns="false" AllowPaging="true"
                    PageSize="10" CssClass="grd" Height="20px" Width="100%">
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
                                <asp:Label ID="lblH" runat="server" Text="Name"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:LinkButton ID="lblgvDoctorName" runat="server" Text='<%#DataBinder.Eval(Container,"DataItem.Name") %>'
                                    CommandArgument='<%#DataBinder.Eval(Container,"DataItem.ID") %>' CommandName="EditGroup"></asp:LinkButton>
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
                        <asp:Label ID="lblDoctorName" runat="server" Text="Name"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox Width="250" ID="txtName" runat="server" MaxLength="50"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName"
                            ValidationGroup="AddEditGroup" Text="*" Display="Dynamic" ErrorMessage="Name"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblDescription" runat="server" Text="Description"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox Width="250" ID="txtDesc" runat="server" TextMode="MultiLine" Height="70"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvSpecilization" runat="server" ControlToValidate="txtDesc"
                            ValidationGroup="AddEditGroup" Text="*" Display="Dynamic" ErrorMessage="Description"></asp:RequiredFieldValidator>
                    </td>
                </tr>
            </table>
            <div class="btns">
                <asp:Button CssClass="btn" ID="btnExit" runat="server" Width="60px" CausesValidation="false"
                    Text='<%$Resources:ExpressCMS, btnExit %>' />
                <asp:Button CssClass="btn" ID="btnReset" runat="server" Width="60px" CausesValidation="false"
                    Text='<%$Resources:ExpressCMS, btnReset %>' />
                <asp:Button CssClass="btn" ID="btnSaveUpdate" runat="server" Width="60px" ValidationGroup="AddEditGroup"
                    Text='<%$Resources:ExpressCMS, btnSaveUpdate %>' />
            </div>
            <asp:ValidationSummary ID="valsummaryGroup" runat="server" ValidationGroup="AddEditGroup"
                HeaderText='<%$Resources:ExpressCMS, valSummHeader %>' DisplayMode="BulletList"
                ShowMessageBox="true" ShowSummary="false" />
        </asp:PlaceHolder>
    </ContentTemplate>
</asp:UpdatePanel>
