<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="BannerAdmin_UC.ascx.cs"
    Inherits="TG.ExpressCMS.UI.BannerAdmin_UC" %>
<asp:UpdatePanel ID="upnall" runat="server">
    <ContentTemplate>
        <div class="header">
            <h3>
                <asp:Label ID="lblBanners" runat="server" Text="Banner Manager"></asp:Label>
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
                <asp:Label ID="lblGrdTitleBanners" runat="server" Text="Banners"></asp:Label>
            </div>
            <div style="background: white; overflow: auto; width: 100%; height: 100%;">
                <asp:GridView ID="gvBanners" runat="server" AutoGenerateColumns="false" AllowPaging="true"
                    PageSize="9" CssClass="grd" Width="100%">
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
                                    CommandArgument='<%#DataBinder.Eval(Container,"DataItem.ID") %>' CommandName="EditBanners"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                Category
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblCategoryI" runat="server" Text='<%#GetCategoryName(DataBinder.Eval(Container,"DataItem.CategoryID").ToString()) %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </asp:PlaceHolder>
    </ContentTemplate>
</asp:UpdatePanel>
<asp:UpdatePanel ID="upnlControls" runat="server">
    <ContentTemplate>
        <asp:PlaceHolder ID="plcControls" runat="server">
            <table width="100%">
                <tr>
                    <td>
                        <asp:Label ID="lblDoctorName" runat="server" Text="Name"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox Width="250" ID="txtName" runat="server" MaxLength="50"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName"
                            ValidationGroup="AddEditBanners" Text="*" Display="Dynamic" ErrorMessage="Name"></asp:RequiredFieldValidator>
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
                            ValidationGroup="AddEditBanners" Text="*" Display="Dynamic" ErrorMessage="Hash"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblCategory" runat="server" Text="Category "></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlCategories" runat="server" Width="254">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlCategories"
                            ValidationGroup="AddEditBanners" Text="*" Display="Dynamic" ErrorMessage="Category "></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblUrlType" runat="server" Text="URL Type"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlUrlType" runat="server" Width="254" AutoPostBack="true">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvUrlType" runat="server" ControlToValidate="ddlUrlType"
                            ValidationGroup="AddEditBanners" Text="*" Display="Dynamic" ErrorMessage="URL Type"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblUrl" runat="server" Text="URL"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtUrl" runat="server" TextMode="MultiLine" Width="250" Height="60"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvUrl" runat="server" ControlToValidate="ddlUrlType"
                            ValidationGroup="AddEditBanners" Text="*" Display="Dynamic" ErrorMessage="URL Type"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr style="display: none;">
                    <td style="width: 0%">
                    </td>
                    <td style="width: 100%">
                        <asp:RadioButtonList ID="rdblstTypes" runat="server" Width="100%" RepeatColumns="3"
                            RepeatLayout="Table" RepeatDirection="Horizontal" AutoPostBack="true">
                            <asp:ListItem Text="Clicks" Value="0"></asp:ListItem>
                            <asp:ListItem Text="Views" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Static" Value="2" Selected="True"></asp:ListItem>
                        </asp:RadioButtonList>
                        Count
                        <asp:TextBox ID="txtCount" runat="server" Width="50" MaxLength="4" Text="9999"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvCount" runat="server" ControlToValidate="txtCount"
                            ValidationGroup="AddEditBanners" Text="*" Display="Dynamic" ErrorMessage="Count"
                            Enabled="false"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblPublishFrom" runat="server" Text="Publish from "></asp:Label>
                    </td>
                    <td>
                        <telerik:RadDatePicker ID="txtPublishFrom" DateInput-DateFormat="dd/MM/yyyy" runat="server"
                            Width="140px" AutoPostBack="false" DateInput-EmptyMessage="Pick Date" MinDate="01/01/2000"
                            MaxDate="01/01/3000">
                            <Calendar>
                                <SpecialDays>
                                    <telerik:RadCalendarDay Repeatable="Today" ItemStyle-CssClass="rcToday" />
                                </SpecialDays>
                            </Calendar>
                        </telerik:RadDatePicker>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPublishFrom"
                            ValidationGroup="AddEditBanners" Text="*" Display="Dynamic" ErrorMessage="Publish From"
                            InitialValue=""></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblPublishTo" runat="server" Text="Publish to"></asp:Label>
                    </td>
                    <td>
                        <telerik:RadDatePicker DateInput-DateFormat="dd/MM/yyyy" ID="txtDateTo" runat="server"
                            ZIndex="10000" Width="140px" AutoPostBack="false" DateInput-EmptyMessage="Pick Date"
                            MinDate="01/01/2000" MaxDate="01/01/3000">
                            <Calendar>
                                <SpecialDays>
                                    <telerik:RadCalendarDay Repeatable="Today" ItemStyle-CssClass="rcToday" />
                                </SpecialDays>
                            </Calendar>
                        </telerik:RadDatePicker>
                        <asp:RequiredFieldValidator ID="rfvtodate" runat="server" ControlToValidate="txtDateTo"
                            ValidationGroup="AddEditBanners" Text="*" Display="Dynamic" ErrorMessage="Publish To"
                            InitialValue=""></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        User Side View
                    </td>
                    <td>
                        <telerik:RadEditor runat="server" ID="txtUserSide" SkinID="DefaultSetOfTools" Height="515">
                            <ImageManager ViewPaths="~/Upload/Files/EditorImage/" UploadPaths="~/Upload/Files/EditorImage/"
                                DeletePaths="~/Upload/Files/EditorImage/"></ImageManager>
                        </telerik:RadEditor>
                        <asp:RequiredFieldValidator ID="rfvUserSide" runat="server" ControlToValidate="txtUserSide"
                            ValidationGroup="AddEditBanners" Text="*" Display="Dynamic" ErrorMessage="UserSIde"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr runat="server" id="trDetails">
                    <td>
                        <asp:Label ID="lblDetails" runat="server" Text="Details"></asp:Label>
                    </td>
                    <td>
                        <telerik:RadEditor runat="server" ID="txtDetails" SkinID="DefaultSetOfTools" Height="515">
                            <ImageManager ViewPaths="~/Upload/Files/EditorImage/" UploadPaths="~/Upload/Files/EditorImage/"
                                DeletePaths="~/Upload/Files/EditorImage/"></ImageManager>
                            <asp:RequiredFieldValidator ID="rfvDetails" runat="server" ControlToValidate="txtDetails"
                                ValidationGroup="AddEditBanners" Text="*" Display="Dynamic" ErrorMessage="Details">
                            </asp:RequiredFieldValidator>
                    </td>
                </tr>
            </table>
            <div class="btns">
                <asp:Button CssClass="btn" ID="btnExit" runat="server" Width="60px" CausesValidation="false"
                    Text='<%$Resources:ExpressCMS, btnExit %>' />
                <asp:Button CssClass="btn" ID="btnReset" runat="server" Width="60px" CausesValidation="false"
                    Text='<%$Resources:ExpressCMS, btnReset %>' />
                <asp:Button CssClass="btn" ID="btnSaveUpdate" runat="server" Width="60px" ValidationGroup="AddEditBanners"
                    Text='<%$Resources:ExpressCMS, btnSaveUpdate %>' />
            </div>
            <asp:ValidationSummary ID="valsummaryBanners" runat="server" ValidationGroup="AddEditBanners"
                HeaderText='<%$Resources:ExpressCMS, valSummHeader %>' DisplayMode="BulletList"
                ShowMessageBox="true" ShowSummary="false" />
        </asp:PlaceHolder>
    </ContentTemplate>
</asp:UpdatePanel>
