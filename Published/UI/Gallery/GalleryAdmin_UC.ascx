<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="GalleryAdmin_UC.ascx.cs"
    Inherits="TG.ExpressCMS.UI.Gallery.GalleryAdmin_UC" %>
<script type="text/javascript">
    function CheckAll(oCheckbox) {
        var GridView2 = document.getElementById("<%=gvGallery.ClientID %>");
        for (i = 1; i < GridView2.rows.length; i++) {
            if (null != GridView2.rows[i].cells[0].getElementsByTagName("INPUT")[0])
                GridView2.rows[i].cells[0].getElementsByTagName("INPUT")[0].checked = oCheckbox.checked;
        }
    }
</script>
<div class="header">
    <h3>
        <asp:Label ID="lblGalleryPage" runat="server" Text="Gallery Manager"></asp:Label>
    </h3>
</div>
<asp:UpdatePanel ID="upnlall" runat="server">
    <ContentTemplate>
        <telerik:RadProgressArea runat="server" ID="ProgressArea1">
        </telerik:RadProgressArea>
        <telerik:RadProgressManager ID="Radprogressmanager1" runat="server" />
        <table>
            <tr>
                <td>
                    <asp:Label ID="lblSearch" runat="server" Text="Keyword"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtSearch" Width="250px" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblSearchCat" runat="server" Text="Category"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlSearchCategories" runat="server" Width="254">
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
        <div class="actions">
            <asp:Button ID="btnSearch" runat="server" Text="Search" CausesValidation="true" CssClass="btn"
                Height="21" />
        </div>
        <br />
        <div id="dvProblems" runat="server" class="dvmessages">
        </div>
        <asp:PlaceHolder ID="plcGridView" runat="server">
            <div class="imgbtn">
                <asp:ImageButton ID="ibtnDelete" runat="server" ToolTip="Delete" ImageUrl="~/App_Themes/AdminSide2/Images/delete.png"
                    Visible="true" OnClientClick="return ConfirmDelete();"></asp:ImageButton>
                <asp:ImageButton ID="ibtnadd" runat="server" ToolTip="Add " CausesValidation="False"
                    ImageUrl="~/App_Themes/AdminSide2/Images/add.png"></asp:ImageButton></div>
            <div class="gridTitle">
                <asp:Label ID="lblGrdTitleGallery" runat="server" Text="Gallery Entries"></asp:Label>
            </div>
            <div style="background: white; overflow: auto; width: 100%; height: 100%;">
                <asp:GridView ID="gvGallery" runat="server" AllowPaging="true" PageSize="6" AutoGenerateColumns="false"
                    CssClass="grd" Height="20px" Width="100%">
                    <EmptyDataTemplate>
                        <a>No data returned,please select search criterea </a>
                    </EmptyDataTemplate>
                    <Columns>
                        <asp:TemplateField>
                            <HeaderStyle Width="5%" />
                            <HeaderTemplate>
                                <asp:CheckBox ID="chkItemheader" onclick="CheckAll(this);" runat="server" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkItemUnique" runat="server" />
                                <input type="hidden" id="hdnID" runat="server" value='<%#DataBinder.Eval(Container,"DataItem.ID")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:Label ID="lblImage" runat="server" Text="Thumbnail"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Image Height="40" Width="40" runat="server" ImageUrl='<%#GetImageUrl(DataBinder.Eval(Container,"DataItem.Path").ToString()) %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:Label ID="lblName" runat="server" Text="Name"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:LinkButton ID="lbGaleryName" runat="server" Text='<%#DataBinder.Eval(Container,"DataItem.Name")%>'
                                    CommandArgument='<%#DataBinder.Eval(Container,"DataItem.ID")%>' CommandName="EditgalleryItems"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:Label ID="lblType" runat="server" Text="Type"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:LinkButton ID="lblGalleryType" CommandArgument='<%#DataBinder.Eval(Container,"DataItem.ID")%>'
                                    CommandName="EditgalleryItems" runat="server" Text='<%#DataBinder.Eval(Container,"DataItem.Type")%>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="plcControls" runat="server">
            <table width="100%">
                <tr>
                    <td style="width: 20%">
                        <asp:Label ID="lblGalleryName" runat="server" Text="Name"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox Width="250" ID="txtName" Text="Dummy" runat="server" MaxLength="50"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvName" Enabled="false" runat="server" ControlToValidate="txtName"
                            ValidationGroup="AddEditGallery" Text="*" Display="Dynamic" ErrorMessage="Name "></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblDescription" runat="server" Text="Description "></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox Width="250" ID="txtDesc" Text="Dummy" runat="server" TextMode="MultiLine"
                            Height="60px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvSpecilization" Enabled="false" runat="server"
                            ControlToValidate="txtDesc" ValidationGroup="AddEditGallery" Text="*" Display="Dynamic"
                            ErrorMessage="Description "></asp:RequiredFieldValidator>
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
                            ValidationGroup="AddEditGallery" Text="*" Display="Dynamic" InitialValue="" ErrorMessage="Category "></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblGalleryType" runat="server" Text="Type"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlGalleryType" runat="server" Width="254" AutoPostBack="false">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvGalleryType" runat="server" ControlToValidate="ddlGalleryType"
                            ValidationGroup="AddEditGallery" Text="*" Display="Dynamic" InitialValue="" ErrorMessage="Type "></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblImage" runat="server" Text="File"></asp:Label>
                    </td>
                    <td>
                        <telerik:RadUpload runat="server" ID="fUploader" InitialFileInputsCount="2" MaxFileInputsCount="12"
                            AllowedFileExtensions=".jpg,.jpeg,.pmb,.png" MaxFileSize="90485760" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblDate" runat="server" Text="Date"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox Width="135" ID="txtDate" runat="server" MaxLength="50"></asp:TextBox>
                        <Ajax:CalendarExtender ID="calDate" runat="server" TargetControlID="txtDate" CssClass="cal_Theme1"
                            Format="dd/MM/yyyy" PopupButtonID="ibtnFrom" />
                        <asp:ImageButton ID="ibtnFrom" Width="23" Height="23" runat="server" ImageUrl="~/App_Themes/AdminSide2/Images/calendar.png" />
                        <asp:RequiredFieldValidator ID="rfvDate" runat="server" ControlToValidate="txtDate"
                            ValidationGroup="AddEditGallery" Text="*" Display="Dynamic" ErrorMessage="Date"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr runat="server" id="trdetails" style="display: none;">
                    <td>
                        <asp:Label ID="lblTags" runat="server" Text="Tags "></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox Width="250" ID="txtTags" runat="server" TextMode="MultiLine" Height="60px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvTags" runat="server" ControlToValidate="txtTags"
                            ValidationGroup="AddEditGallery" Enabled="false" Text="*" Display="Dynamic" ErrorMessage="Tags"></asp:RequiredFieldValidator>
                    </td>
                </tr>
            </table>
            <div class="btns">
                <asp:Button CssClass="btn" ID="btnExit" runat="server" Width="60px" CausesValidation="false"
                    Text='<%$Resources:ExpressCMS, btnExit %>' />
                <asp:Button CssClass="btn" ID="btnReset" runat="server" Width="60px" CausesValidation="false"
                    Text='<%$Resources:ExpressCMS, btnReset %>' />
                <asp:Button CssClass="btn" ID="btnSaveUpdate" runat="server" Width="60px" ValidationGroup="AddEditGallery"
                    Text='<%$Resources:ExpressCMS, btnSaveUpdate %>' />
            </div>
            <asp:ValidationSummary ID="valsummaryContact" runat="server" ValidationGroup="AddEditGallery"
                HeaderText='<%$Resources:ExpressCMS, valSummHeader %>' DisplayMode="BulletList"
                ShowMessageBox="true" ShowSummary="false" />
        </asp:PlaceHolder>
    </ContentTemplate>
    <Triggers>
        <asp:PostBackTrigger ControlID="btnSaveUpdate" />
    </Triggers>
</asp:UpdatePanel>
