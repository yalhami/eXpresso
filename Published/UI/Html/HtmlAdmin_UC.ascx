<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="HtmlAdmin_UC.ascx.cs"
    Inherits="TG.ExpressCMS.UI.HtmlAdmin_UC" %>
<asp:UpdatePanel ID="upnlAll" runat="server">
    <ContentTemplate>
        <div class="header">
            <h3>
                <asp:Label ID="lblHtml" runat="server" Text="Html  Manager"></asp:Label>
            </h3>
            <table>
                <tr>
                    <td>
                        Hash
                    </td>
                    <td>
                        <asp:TextBox ID="txtSearch" Width="250px" runat="server" ValidationGroup="SearchValG"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvsearch" runat="server" ControlToValidate="txtSearch"
                            ValidationGroup="SearchValG" Text="*" Display="Dynamic" ErrorMessage="* "></asp:RequiredFieldValidator>
                        <asp:Button ID="btnShowall" CssClass="btn" Height="21" runat="server" Text="Show All" />
                        <asp:Button ID="btnSearch" CssClass="btn" Height="21" runat="server" Text="Search"
                            ValidationGroup="SearchValG" />
                    </td>
                </tr>
            </table>
        </div>
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
                <asp:Label ID="lblGrdTitleHtml" runat="server" Text="Html s"></asp:Label>
            </div>
            <div style="background: white; overflow: auto; width: 100%; height: 100%;">
                <asp:GridView ID="gvHtml" runat="server" AutoGenerateColumns="false" CssClass="grd"
                    AllowPaging="true" PageSize="10" Width="100%">
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
                                <asp:LinkButton ID="lblgvName" runat="server" Text='<%#DataBinder.Eval(Container,"DataItem.Name") %>'
                                    CommandArgument='<%#DataBinder.Eval(Container,"DataItem.ID") %>' CommandName="EditHtml"></asp:LinkButton>
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
                            ValidationGroup="AddEditHtml" Text="*" Display="Dynamic" ErrorMessage="Name"></asp:RequiredFieldValidator>
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
                            ValidationGroup="AddEditHtml" Text="*" Display="Dynamic" ErrorMessage="Hash"></asp:RequiredFieldValidator>
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
                        <%-- <CE:Editor Visible="true" ID="txtDetails" runat="server" Width="97%" Height="300px"
                            EnableContextMenu="true" EditorWysiwygModeCss="example.css">
                        </CE:Editor>--%>
                        <asp:RequiredFieldValidator ID="rfvDetails" runat="server" ControlToValidate="txtDetails"
                            ValidationGroup="AddEditHtml" Text="*" Display="Dynamic" ErrorMessage="Details"></asp:RequiredFieldValidator>
                    </td>
                </tr>
            </table>
            <div class="btns">
                <asp:Button CssClass="btn" ID="btnExit" runat="server" Width="60px" CausesValidation="false"
                    Text='<%$Resources:ExpressCMS, btnExit %>' />
                <asp:Button CssClass="btn" ID="btnReset" runat="server" Width="60px" CausesValidation="false"
                    Text='<%$Resources:ExpressCMS, btnReset %>' />
                <asp:Button CssClass="btn" ID="btnSaveUpdate" runat="server" Width="60px" ValidationGroup="AddEditHtml"
                    Text='<%$Resources:ExpressCMS, btnSaveUpdate %>' />
            </div>
            <asp:ValidationSummary ID="valsummaryHtml" runat="server" ValidationGroup="AddEditHtml"
                HeaderText='<%$Resources:ExpressCMS, valSummHeader %>' DisplayMode="BulletList"
                ShowMessageBox="true" ShowSummary="false" />
        </asp:PlaceHolder>
    </ContentTemplate>
</asp:UpdatePanel>
