<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="NewsAdmin_UC.ascx.cs"
    Inherits="TG.ExpressCMS.UI.News.NewsAdmin_UC" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HTMLEditor"
    TagPrefix="HTMLEditor" %>
<script type="text/javascript">

    function HideDiv1(dvmsg1) {

        var dvmsg = document.getElementById("<%=dvProblems.ClientID%>");
        dvmsg.style.display = 'none';
    }
    function CheckAll(oCheckbox) {
        var GridView2 = document.getElementById("<%=gvNews.ClientID %>");
        for (i = 1; i < GridView2.rows.length; i++) {
            if (null != GridView2.rows[i].cells[0].getElementsByTagName("INPUT")[0])
                GridView2.rows[i].cells[0].getElementsByTagName("INPUT")[0].checked = oCheckbox.checked;
        }
    }
    function ShowHideOptItem() {


        var mappedurl = document.getElementById('trMappedItem');
        var url = document.getElementById('<%=trURL.ClientID %>');

        if (mappedurl.style.display == "none") {
            mappedurl.style.display = "block";

        }
        else {
            mappedurl.style.display = "none";

        }

        if (url.style.display == "none") {
            url.style.display = "block";

        }
        else {
            url.style.display = "none";

        }
    }
</script>
<div class="header">
    <h3>
        <asp:Label ID="lblNewsPage" runat="server" Text="News Manager"></asp:Label>
    </h3>
</div>
<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <table>
            <tr>
                <td>
                    <asp:Label ID="lblSearch" runat="server" Text="Keyword"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtSearch" Width="250px" runat="server" ValidationGroup="SearchValG"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblSearchDate" runat="server" Text="Article Date"></asp:Label>
                </td>
                <td>
                    <telerik:RadDatePicker ID="dtSearch" runat="server" Width="140px" AutoPostBack="false"
                        DateInput-EmptyMessage="Pick a Date" DateInput-DateFormat="dd/MM/yyyy" MinDate="01/01/1900"
                        MaxDate="01/01/3000">
                        <Calendar>
                            <SpecialDays>
                                <telerik:RadCalendarDay Repeatable="Today" ItemStyle-CssClass="rcToday" />
                            </SpecialDays>
                        </Calendar>
                    </telerik:RadDatePicker>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblCatSearch" runat="server" Text="Category"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlSearchCategories" runat="server" Width="254">
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
        <div class="adminbtns">
            <asp:Button ID="btnSearch" runat="server" Text="Search" ValidationGroup="SearchValG"
                CausesValidation="true" CssClass="btn" Height="21" />
        </div>
        <br />
        <br />
        <br />
    </ContentTemplate>
</asp:UpdatePanel>
<asp:UpdatePanel ID="goalways" runat="server">
    <ContentTemplate>
        <div id="dvProblems" runat="server" class="dvmessages">
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
<asp:UpdatePanel ID="upnlGrid" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:PlaceHolder ID="plcGridView" runat="server">
            <div class="imgbtn">
                <asp:ImageButton ID="ibtnPublish" runat="server" ToolTip="Publish" ImageUrl="~/App_Themes/AdminSide2/Images/up.png"
                    Visible="true" OnClientClick="return ConfirmPublish();return false;"></asp:ImageButton>
                <asp:ImageButton ID="ibtnDelete" runat="server" ToolTip="Delete" ImageUrl="~/App_Themes/AdminSide2/Images/delete.png"
                    Visible="true" OnClientClick="return ConfirmDelete();return false;"></asp:ImageButton>
                <asp:ImageButton ID="ibtnadd" runat="server" ToolTip="Add " CausesValidation="False"
                    ImageUrl="~/App_Themes/AdminSide2/Images/add.png"></asp:ImageButton>
                <asp:ImageButton ID="ibtntoExcel" runat="server" Width="17" Height="17" ImageUrl="~/App_Themes/AdminSide2/Images/xls.png"
                    ToolTip="Export to Excel" /></div>
            <div class="gridTitle">
                <asp:Label ID="lblGrdTitleNews" runat="server" Text="News Entries"></asp:Label>
            </div>
            <div style="background: white; overflow: auto; width: 100%; height: 100%;">
                <asp:GridView ID="gvNews" runat="server" AllowPaging="true" PageSize="15" AutoGenerateColumns="false"
                    CssClass="grd" Height="20px" Width="100%" PagerSettings-Mode="NumericFirstLast">
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
                            <HeaderStyle Width="10%" />
                            <HeaderTemplate>
                                <asp:Label ID="lblIsFeatured" runat="server" Text="Is Featured"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:ImageButton Width="15px" Height="15px" runat="server" ID="ibtnIsFeatured" CommandArgument='<%#DataBinder.Eval(Container,"DataItem.ID")%>'
                                    CommandName="ibtnIsFeatured" ImageUrl='<%#GetImageUrl(Convert.ToBoolean(DataBinder.Eval(Container,"DataItem.IsFeatured").ToString())) %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="ViewCount" HeaderText="View Count" />
                        <asp:TemplateField>
                            <HeaderStyle Width="40%" />
                            <HeaderTemplate>
                                <asp:Label ID="lblH" runat="server" Text="Title"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:LinkButton ID="lblgvMenuName" runat="server" Text='<%#DataBinder.Eval(Container,"DataItem.Name")%>'
                                    CommandArgument='<%#DataBinder.Eval(Container,"DataItem.ID")%>' CommandName="EditnewsItems"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderStyle Width="20%" />
                            <HeaderTemplate>
                                <asp:Label ID="lblUrl" runat="server" Text="URL"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:HyperLink runat="server" NavigateUrl='<%#DataBinder.Eval(Container,"DataItem.Url")%>'
                                    Text="View Item"></asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderStyle Width="20%" />
                            <HeaderTemplate>
                                <asp:Label ID="lblCategory" runat="server" Text="Category"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblCategory" Text='<%#GetCategory(DataBinder.Eval(Container,"DataItem.CategoryID").ToString())%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderStyle Width="10%" />
                            <HeaderTemplate>
                                <asp:Label ID="lblImage" runat="server" Text="Image"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:ImageButton ID="ibtnImage" Width="15" Height="15" runat="server" ImageUrl='<%#GetArticleImage(DataBinder.Eval(Container,"DataItem.Image").ToString()) %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderStyle Width="30%" />
                            <HeaderTemplate>
                                <asp:Label ID="lblArticleDate" runat="server" Text="Date"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblArticleDateValue" Text='<%#DataBinder.Eval(Container,"DataItem.Date")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </asp:PlaceHolder>
    </ContentTemplate>
</asp:UpdatePanel>
<asp:UpdatePanel ID="upnlControls" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:PlaceHolder ID="plcControls" runat="server">
            <table width="100%">
                <tr class="3alFade">
                    <td style="width: 20%">
                        <asp:Label ID="lblShowComment" runat="server" Text="Show Comments"></asp:Label>
                    </td>
                    <td>
                        <asp:CheckBox ID="chkShowComments" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 20%">
                        <asp:Label ID="lblIsFeatured" runat="server" Text="Is Featured"></asp:Label>
                    </td>
                    <td>
                        <asp:CheckBox ID="chkIsFeatured" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 20%">
                        <asp:Label ID="lblOrderNumber" runat="server" Text="Order Number"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtOrderNumber" runat="server" Width="50" MaxLength="3"></asp:TextBox>
                        <Ajax:FilteredTextBoxExtender FilterType="Numbers" runat="server" TargetControlID="txtOrderNumber">
                        </Ajax:FilteredTextBoxExtender>
                    </td>
                </tr>
                <tr>
                    <asp:UpdatePanel runat="server" ID="upnlkeywords">
                        <ContentTemplate>
                            <td style="width: 20%">
                                <asp:Label ID="lblNewsName" runat="server" Text="Title"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox Width="250" ID="txtName" runat="server" MaxLength="500"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName"
                                    ValidationGroup="AddEditNews" Text="*" Display="Dynamic" ErrorMessage="Title "></asp:RequiredFieldValidator>
                                <asp:Button runat="server" Text="Generate Keywords" ID="btnGenerateKeywords" />
                            </td>
                            <td>
                                <asp:CheckBoxList runat="server" ID="chklstkeywrds" RepeatColumns="3" RepeatDirection="Horizontal"
                                    RepeatLayout="Table">
                                </asp:CheckBoxList>
                            </td>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblDescription" runat="server" Text="Description"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox Width="250" ID="txtDesc" runat="server" TextMode="MultiLine" Height="60px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvSpecilization" runat="server" ControlToValidate="txtDesc"
                            ValidationGroup="AddEditNews" Enabled="false" Text="*" Display="Dynamic" ErrorMessage="Description "></asp:RequiredFieldValidator>
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
                            ValidationGroup="AddEditNews" Text="*" Display="Dynamic" ErrorMessage="Category"
                            InitialValue=""></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <asp:LinkButton ID="lbShoHideMappedItem" runat="server" OnClientClick="ShowHideOptItem();">Show/Hide Optional Items</asp:LinkButton>
                <tr style="display: none;" id="trMappedItem">
                    <td>
                        Mapped Item
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlMappedLanguageID" runat="server" Width="254">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblNewsType" runat="server" Text="Type "></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlNewsType" runat="server" Width="254" AutoPostBack="true">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvNewsType" runat="server" ControlToValidate="ddlNewsType"
                            ValidationGroup="AddEditNews" Text="*" Display="Dynamic" ErrorMessage="Type "
                            InitialValue=""></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr runat="server" id="trURL" visible="false" style="display: none;">
                    <td>
                        <asp:Label ID="lblURL" runat="server" Text="URL"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox Width="250" Height="70" TextMode="MultiLine" ID="txtURL" runat="server"
                            MaxLength="50"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvURL" runat="server" ControlToValidate="txtURL"
                            ValidationGroup="AddEditNews" Text="*" Display="Dynamic" ErrorMessage="URL "></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblImage" runat="server" Text="Image "></asp:Label>
                    </td>
                    <td>
                        <asp:Image ID="imguploaded" runat="server" Width="70" Height="70" />
                        <asp:FileUpload ID="fUploader" runat="server" />
                        <asp:CheckBox ID="chkUpdateImage" runat="server" Text="Update Image" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblNewsDate" runat="server" Text="Date"></asp:Label>
                    </td>
                    <td>
                        <telerik:RadDatePicker ID="dtDate" runat="server" Width="140px" AutoPostBack="false"
                            DateInput-EmptyMessage="Pick a Date" DateInput-DateFormat="dd/MM/yyyy" MinDate="01/01/1990"
                            MaxDate="01/01/3000">
                            <Calendar>
                                <SpecialDays>
                                    <telerik:RadCalendarDay Repeatable="Today" ItemStyle-CssClass="rcToday" />
                                </SpecialDays>
                            </Calendar>
                        </telerik:RadDatePicker>
                        <asp:RequiredFieldValidator ID="rfvArticleDate" runat="server" ControlToValidate="dtDate"
                            ValidationGroup="AddEditNews" Text="*" Display="Dynamic" ErrorMessage="Article Date"
                            InitialValue=""></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <asp:RadioButton ID="rdbNow" GroupName="publish" runat="server" Value="1" Text="Publish Now"
                            AutoPostBack="true" Checked="true" />
                        <asp:RadioButton ID="rdblater" GroupName="publish" runat="server" Value="2" Text="Publish Interval"
                            AutoPostBack="true" />
                        <asp:RadioButton ID="rdbUnpublish" GroupName="publish" runat="server" Value="3" Text="Unpublish"
                            AutoPostBack="true" />
                    </td>
                </tr>
                <tr runat="server" id="trDatesFrom">
                    <td>
                        <asp:Label ID="lblPublishFrom" runat="server" Text="Publish from "></asp:Label>
                    </td>
                    <td>
                        <telerik:RadDatePicker ID="txtPublishFrom" runat="server" Width="140px" AutoPostBack="false"
                            DateInput-EmptyMessage="Pick a Date" DateInput-DateFormat="dd/MM/yyyy" MinDate="01/01/1990"
                            MaxDate="01/01/3000">
                            <Calendar>
                                <SpecialDays>
                                    <telerik:RadCalendarDay Repeatable="Today" ItemStyle-CssClass="rcToday" />
                                </SpecialDays>
                            </Calendar>
                        </telerik:RadDatePicker>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPublishFrom"
                            ValidationGroup="AddEditNews" Text="*" Display="Dynamic" ErrorMessage="Publish From"
                            InitialValue=""></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr runat="server" id="trDatesto">
                    <td>
                        <asp:Label ID="lblPublishTo" runat="server" Text="Publish to"></asp:Label>
                    </td>
                    <td>
                        <telerik:RadDatePicker DateInput-DateFormat="dd/MM/yyyy" ID="txtDateTo" runat="server"
                            ZIndex="10000" Width="140px" AutoPostBack="false" DateInput-EmptyMessage="Pick a Date"
                            MinDate="01/01/1990" MaxDate="01/01/3000">
                            <Calendar>
                                <SpecialDays>
                                    <telerik:RadCalendarDay Repeatable="Today" ItemStyle-CssClass="rcToday" />
                                </SpecialDays>
                            </Calendar>
                        </telerik:RadDatePicker>
                        <asp:RequiredFieldValidator ID="rfvtodate" runat="server" ControlToValidate="txtDateTo"
                            ValidationGroup="AddEditNews" Text="*" Display="Dynamic" ErrorMessage="Publish To"
                            InitialValue=""></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr runat="server" id="trdetails">
                    <td>
                        <asp:Label ID="lblDetails" runat="server" Text="Details "></asp:Label>
                    </td>
                    <td>
                        <telerik:RadEditor runat="server" ID="txtDetails" SkinID="DefaultSetOfTools" Height="515">
                            <ImageManager ViewPaths="~/Upload/Files/EditorImage/" UploadPaths="~/Upload/Files/EditorImage/"
                                DeletePaths="~/Upload/Files/EditorImage/"></ImageManager>
                            <MediaManager DeletePaths="~/Upload/Files/Videos/" MaxUploadFileSize="250000000"
                                UploadPaths="~/Upload/Files/Videos/" ViewPaths="~/Upload/Files/Videos/" />
                        </telerik:RadEditor>
                        <%-- <CE:Editor Visible="true" ID="txtDetails" runat="server" Width="97%" Height="300px"
                            EnableContextMenu="true" EditorWysiwygModeCss="example.css">
                        </CE:Editor>--%>
                        <asp:RequiredFieldValidator ID="rfvDetails" runat="server" ControlToValidate="txtDetails"
                            ValidationGroup="AddEditNews" Text="*" Display="Dynamic" ErrorMessage="txtDetails "></asp:RequiredFieldValidator>
                    </td>
                </tr>
            </table>
            <div class="btns">
                <asp:Button CssClass="btn" ID="btnExit" runat="server" Width="60px" CausesValidation="false"
                    Text='<%$Resources:ExpressCMS, btnExit %>' />
                <asp:Button CssClass="btn" ID="btnReset" runat="server" Width="60px" CausesValidation="false"
                    Text='<%$Resources:ExpressCMS, btnReset %>' />
                <asp:Button CssClass="btn" ID="btnSaveUpdate" runat="server" Width="60px" ValidationGroup="AddEditNews"
                    Text='<%$Resources:ExpressCMS, btnSaveUpdate %>' />
            </div>
            <asp:ValidationSummary ID="valsummaryContact" runat="server" ValidationGroup="AddEditNews"
                HeaderText='<%$Resources:ExpressCMS, valSummHeader %>' DisplayMode="BulletList"
                ShowMessageBox="true" ShowSummary="false" />
        </asp:PlaceHolder>
    </ContentTemplate>
    <Triggers>
        <asp:PostBackTrigger ControlID="btnSaveUpdate" />
        <asp:PostBackTrigger ControlID="ibtntoExcel" />
    </Triggers>
</asp:UpdatePanel>
