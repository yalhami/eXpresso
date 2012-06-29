<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ManagerCareers_UC.ascx.cs"
    Inherits="TG.ExpressCMS.UI.Careers.ManagerCareers_UC" %>
<div class="header">
    <h3>
        <asp:Label ID="lblCareer" runat="server" Text="Career  Manager"></asp:Label>
    </h3>
</div>
<asp:UpdatePanel ID="upnall" runat="server">
    <ContentTemplate>
        <div id="dvProblems" runat="server">
        </div>
        <asp:PlaceHolder ID="plcGridView" runat="server">
            <div class="imgbtn">
                <asp:ImageButton ID="ibtnDelete" runat="server" OnClientClick="return ConfirmDelete();"
                    ToolTip='<%$Resources:ExpressCMS,ibtnDelete %>' ImageUrl="~/App_Themes/Adminside2/Images/delete.png"
                    Visible="true"></asp:ImageButton>
                <asp:ImageButton ID="ibtnadd" runat="server" ToolTip='<%$Resources:ExpressCMS,ibtnadd %>'
                    CausesValidation="False" ImageUrl="~/App_Themes/Adminside2/Images/add.png"></asp:ImageButton></div>
            <div class="gridTitle">
                <asp:Label ID="lblGrdTitleCareer" runat="server" Text="Career s"></asp:Label>
            </div>
            <div style="background: white; overflow: auto; width: 100%; height: 255px;">
                <asp:GridView ID="gvCareer" runat="server" AutoGenerateColumns="false" CssClass="grd"
                    Height="20px" Width="100%">
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
                                <asp:LinkButton ID="lblgvName" runat="server" Text='<%#DataBinder.Eval(Container,"DataItem.Name") %>'
                                    CommandArgument='<%#DataBinder.Eval(Container,"DataItem.ID") %>' CommandName="EditCareer"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Date" HeaderText="Date" />
                    </Columns>
                </asp:GridView>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="plcControls" runat="server">
            <table width="100%">
                <tr>
                    <td>
                        <asp:Label ID="lblName" runat="server" Text="Name"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox Width="250" ID="txtName" runat="server" MaxLength="50"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName"
                            ValidationGroup="AddEditCareer" Text="*" Display="Dynamic" ErrorMessage="Name"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblHash" runat="server" Text="Hash"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox Width="250" Height="70" TextMode="MultiLine" ID="txtHash" runat="server"
                            MaxLength="50"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvAttributes" runat="server" ControlToValidate="txtHash"
                            ValidationGroup="AddEditCareer" Text="*" Display="Dynamic" ErrorMessage="Hash"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblState" runat="server" Text="Status"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlStatus" runat="server" Width="254">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvStatus" runat="server" ControlToValidate="ddlStatus"
                            ValidationGroup="AddEditCareer" Text="*" Display="Dynamic" ErrorMessage="Status"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblDetails" runat="server" Text="Details"></asp:Label>
                    </td>
                    <td>
                        <telerik:RadEditor runat="server" ID="txtDetails" SkinID="DefaultSetOfTools" Height="515">
                            <ImageManager ViewPaths="~/Upload/Files/EditorImage/" UploadPaths="~/Upload/Files/EditorImage/"
                                DeletePaths="~/Upload/Files/EditorImage/"></ImageManager>
                        </telerik:RadEditor>
                        <asp:RequiredFieldValidator ID="rfvDetails" runat="server" ControlToValidate="txtDetails"
                            ValidationGroup="AddEditCareer" Text="*" Display="Dynamic" ErrorMessage="Details"></asp:RequiredFieldValidator>
                    </td>
                </tr>
            </table>
            <div class="btns">
                <asp:Button CssClass="btn" ID="btnExit" runat="server" Width="60px" CausesValidation="false"
                    Text='<%$Resources:ExpressCMS, btnExit %>' />
                <asp:Button CssClass="btn" ID="btnReset" runat="server" Width="60px" CausesValidation="false"
                    Text='<%$Resources:ExpressCMS, btnReset %>' />
                <asp:Button CssClass="btn" ID="btnSaveUpdate" runat="server" Width="60px" ValidationGroup="AddEditCareer"
                    Text='<%$Resources:ExpressCMS, btnSaveUpdate %>' />
            </div>
            <asp:ValidationSummary ID="valsummaryCareer" runat="server" ValidationGroup="AddEditCareer"
                HeaderText='<%$Resources:ExpressCMS, valSummHeader %>' DisplayMode="BulletList"
                ShowMessageBox="true" ShowSummary="false" />
        </asp:PlaceHolder>
    </ContentTemplate>
</asp:UpdatePanel>
