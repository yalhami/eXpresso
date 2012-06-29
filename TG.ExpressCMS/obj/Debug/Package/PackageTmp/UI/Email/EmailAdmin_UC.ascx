<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="EmailAdmin_UC.ascx.cs"
    Inherits="TG.ExpressCMS.UI.Email.EmailAdmin_UC" %>
<div class="header">
    <h3>
        <asp:Label ID="lblEmailPage" runat="server" Text='<%$Resources:ExpressCMS,lblEmailPage %>'></asp:Label>
    </h3>
</div>
<asp:UpdatePanel ID="upnall" runat="server">
    <ContentTemplate>
        <div id="dvProblems" runat="server">
        </div>
        <asp:PlaceHolder ID="plcGridView" runat="server">
            <div class="imgbtn">
                <asp:ImageButton ID="ibtnDelete" runat="server" ToolTip='<%$Resources:ExpressCMS,ibtnDelete %>'
                    ImageUrl="~/App_Themes/AdminSide2/Images/delete.png" Visible="true" OnClientClick="return ConfirmDelete();">
                </asp:ImageButton>
                <asp:ImageButton ID="ibtnadd" runat="server" ToolTip='<%$Resources:ExpressCMS,ibtnadd %>'
                    CausesValidation="False" ImageUrl="~/App_Themes/AdminSide2/Images/add.png"></asp:ImageButton>
                <asp:ImageButton ID="ibtntoExcel" runat="server" Width="17" Height="17" ImageUrl="~/App_Themes/AdminSide2/Images/xls.png"
                    ToolTip="Export to Excel" />
            </div>
            <div class="gridTitle">
                <asp:Label ID="lblGrdTitleEmail" runat="server" Text='<%$Resources:ExpressCMS,lblGrdTitleEmail %>'></asp:Label>
            </div>
            <div style="background: white; overflow: auto; width: 100%; height: 100%;">
                <asp:GridView ID="gvEmail" runat="server" AllowPaging="true" PageSize="10" AutoGenerateColumns="false"
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
                                E-Mail
                                <%--<asp:Label ID="lblH" runat="server" Text="<%Resources:ExpressCMS,drNameHeaderinGrid %>"></asp:Label>--%>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:LinkButton ID="lblgvDoctorName" runat="server" Text='<%#DataBinder.Eval(Container,"DataItem.Name") %>'
                                    CommandArgument='<%#DataBinder.Eval(Container,"DataItem.ID") %>' CommandName="EditMail"></asp:LinkButton>
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
                            ValidationGroup="AddEditEmail" Text="*" Display="Dynamic" ErrorMessage='<%$Resources:ExpressCMS,lblDoctorName %>'></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblDetails" runat="server" Text='<%$Resources:ExpressCMS,lblDetails %>'></asp:Label>
                    </td>
                    <td>
                        <telerik:RadEditor runat="server" ID="txtDetails" SkinID="DefaultSetOfTools" Height="515">
                            <ImageManager ViewPaths="~/Upload/Files/EditorImage/" UploadPaths="~/Upload/Files/EditorImage/"
                                DeletePaths="~/Upload/Files/EditorImage/"></ImageManager>
                        </telerik:RadEditor>
                        <asp:RequiredFieldValidator ID="rfvDetails" runat="server" ControlToValidate="txtDetails"
                            ValidationGroup="AddEditMenu" Text="*" Display="Dynamic" ErrorMessage='<%$Resources:ExpressCMS,lblDetails %>'></asp:RequiredFieldValidator>
                    </td>
                </tr>
            </table>
            <div class="btns">
                <asp:Button CssClass="btn" ID="btnExit" runat="server" Width="60px" CausesValidation="false"
                    Text='<%$Resources:ExpressCMS, btnExit %>' />
                <asp:Button CssClass="btn" ID="btnReset" runat="server" Width="60px" CausesValidation="false"
                    Text='<%$Resources:ExpressCMS, btnReset %>' />
                <asp:Button CssClass="btn" ID="btnSaveUpdate" runat="server" Width="60px" ValidationGroup="AddEditEmail"
                    Text='<%$Resources:ExpressCMS, btnSaveUpdate %>' />
            </div>
            <asp:ValidationSummary ID="valsummaryEmail" runat="server" ValidationGroup="AddEditEmail"
                HeaderText='<%$Resources:ExpressCMS, valSummHeader %>' DisplayMode="BulletList"
                ShowMessageBox="true" ShowSummary="false" />
        </asp:PlaceHolder>
    </ContentTemplate>
    <Triggers>
        <asp:PostBackTrigger ControlID="ibtntoExcel" />
    </Triggers>
</asp:UpdatePanel>
