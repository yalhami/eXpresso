<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="EventAdmin_UC.ascx.cs"
    Inherits="TG.ExpressCMS.UI.Event.EventAdmin_UC" %>
<script type="text/javascript" language="javascript">
    function OnSelectedChangeRepeatOptions() {
        var ddlRepeatOptions = document.getElementById('<%=ddlRepeatOptions.ClientID %>');
        var dvRepeatDaily = document.getElementById('<%=dvRepeatDaily.ClientID %>');
        var dvRepeatWeekly = document.getElementById('<%=dvRepeatWeekly.ClientID %>');
        var dvRepeatMonthly = document.getElementById('<%=dvRepeatMonthly.ClientID %>');
        var dvRepeatYearly = document.getElementById('<%=dvRepeatYearly.ClientID %>');

        dvRepeatDaily.style.display = "none";
        dvRepeatWeekly.style.display = "none";
        dvRepeatMonthly.style.display = "none";
        dvRepeatYearly.style.display = "none";

        switch (ddlRepeatOptions.value) {
            case '<%=(int)(TG.ExpressCMS.DataLayer.Enums.RootEnums.EventRepeatType.DoNotRepeat) %>':
                break;
            case '<%=(int)(TG.ExpressCMS.DataLayer.Enums.RootEnums.EventRepeatType.Daily) %>':
                dvRepeatDaily.style.display = "block";
                break;
            case '<%=(int)(TG.ExpressCMS.DataLayer.Enums.RootEnums.EventRepeatType.Weekly) %>':
                dvRepeatWeekly.style.display = "block";
                break;
            case '<%=(int)(TG.ExpressCMS.DataLayer.Enums.RootEnums.EventRepeatType.Monthly) %>':
                dvRepeatMonthly.style.display = "block";
                break;
            case '<%=(int)(TG.ExpressCMS.DataLayer.Enums.RootEnums.EventRepeatType.Yearly) %>':
                dvRepeatYearly.style.display = "block";
                break;
        }
        return false;
    }
</script>
<div class="header">
    <h3>
        <asp:Label ID="lblEventPage" runat="server" Text='<%$Resources:EventResource, EventManager %>'></asp:Label>
    </h3>
</div>
<asp:UpdatePanel ID="upnlSearch" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <table>
            <tr>
                <td>
                    <asp:Label ID="lblSearch" runat="server" Text='<%$Resources:EventResource,Keyword %>'></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtSearch" Width="250px" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="lblSearchCategory" runat="server" Text='<%$Resources:EventResource,EventCategory %>'></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlSearchCategory" runat="server" Width="254">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width: 20%">
                    <asp:Label ID="lblSearchFrom" runat="server" Text='<%$Resources:EventResource, FromDate %>'></asp:Label>
                </td>
                <td>
                    <div>
                        <asp:TextBox Width="135" ID="txtSearchFrom" runat="server" MaxLength="50"></asp:TextBox>
                    </div>
                    <div style="margin-top: -23px; margin-left: 142px;">
                        <Ajax:CalendarExtender ID="calndtxtSearchFrom" PopupButtonID="ibtnSearchFrom" runat="server"
                            TargetControlID="txtSearchFrom" CssClass="cal_Theme1" Format="dd/MM/yyyy" />
                        <asp:ImageButton ID="ibtnSearchFrom" Width="23" Height="23" runat="server" ImageUrl="~/App_Themes/AdminSide2/Images/calendar.png" />
                    </div>
                </td>
                <td style="width: 20%">
                    <asp:Label ID="Label2" runat="server" Text='<%$Resources:EventResource, ToDate %>'></asp:Label>
                </td>
                <td>
                    <div>
                        <asp:TextBox Width="135" ID="txtSearchTo" runat="server" MaxLength="50"></asp:TextBox>
                    </div>
                    <div style="margin-top: -23px; margin-left: 142px;">
                        <Ajax:CalendarExtender ID="calndtxtSearchTo" PopupButtonID="ibtnSearchTo" runat="server"
                            TargetControlID="txtSearchTo" CssClass="cal_Theme1" Format="dd/MM/yyyy" />
                        <asp:ImageButton ID="ibtnSearchTo" Width="23" Height="23" runat="server" ImageUrl="~/App_Themes/AdminSide2/Images/calendar.png" />
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblSearchLocation" runat="server" Text='<%$Resources:EventResource,EventLocation %>'></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlSearchLocation" runat="server" Width="254">
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
        <div class="actions" style="padding-top: 25px;">
            <asp:Button CssClass="btn" ID="btnSearch" runat="server" Text='<%$Resources:EventResource,Search %>' />
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
<asp:UpdatePanel ID="upnlGrid" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <div id="dvProblems" runat="server" class="dvmessages">
        </div>
        <asp:PlaceHolder ID="plcGridView" runat="server">
            <div class="imgbtn">
                <asp:ImageButton ID="ibtnDelete" runat="server" ToolTip='<%$Resources:EventResource, Delete %>'
                    ImageUrl="~/App_Themes/AdminSide2/Images/delete.png" Visible="true" OnClientClick="return ConfirmDelete();">
                </asp:ImageButton>
                <asp:ImageButton ID="ibtnAdd" runat="server" ToolTip='<%$Resources:EventResource, Add %>'
                    CausesValidation="False" ImageUrl="~/App_Themes/AdminSide2/Images/add.png"></asp:ImageButton></div>
            <div class="gridTitle">
                <asp:Label ID="lblGrdTitleEvent" runat="server" Text='<%$Resources:EventResource, Events %>'></asp:Label>
            </div>
            <div style="background: white; overflow: auto; width: 100%; height: 150px;">
                <asp:GridView ID="gvEvent" runat="server" AllowPaging="true" PageSize="25" AutoGenerateColumns="false"
                    CssClass="grd" Height="20px" Width="100%">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkItem" runat="server" />
                                <input type="hidden" id="hdnID" runat="server" value='<%#DataBinder.Eval(Container,"DataItem.ID")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText='<%$Resources:EventResource, Name %>'>
                            <ItemTemplate>
                                <asp:LinkButton ID="lblGroupName" runat="server" Text='<%#DataBinder.Eval(Container,"DataItem.Name")%>'
                                    CommandArgument='<%#DataBinder.Eval(Container,"DataItem.ID")%>' CommandName="EditEvent"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="FromDate" HeaderText='<%$Resources:EventResource, FromDate %>' />
                        <asp:BoundField DataField="ToDate" HeaderText='<%$Resources:EventResource, ToDate %>' />
                    </Columns>
                    <EmptyDataTemplate>
                        <asp:Label ID="lblNoEvents" runat="server" Text='<%$Resources:EventResource, NoEvents %>'></asp:Label>
                    </EmptyDataTemplate>
                </asp:GridView>
            </div>
        </asp:PlaceHolder>
    </ContentTemplate>
</asp:UpdatePanel>
<asp:UpdatePanel ID="upnlControls" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:PlaceHolder ID="plcControls" runat="server">
            <table width="100%">
                <tr>
                    <td style="width: 20%">
                        <asp:Label ID="lblName" runat="server" Text='<%$Resources:EventResource, Name %>'></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox Width="250" ID="txtName" runat="server" MaxLength="50"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName"
                            ValidationGroup="AddEditEvent" Text="*" Display="Dynamic" ErrorMessage='<%$Resources:EventResource, Name %>'></asp:RequiredFieldValidator>
                    </td>
                    <td style="width: 20%">
                        <asp:Label ID="lblImage" runat="server" Text='<%$Resources:EventResource, Image %>'></asp:Label>
                    </td>
                    <td>
                        <asp:FileUpload ID="fUploader" runat="server" />
                        <asp:CheckBox ID="chkChangeImage" runat="server" Text='<%$Resources:EventResource, ChangeImage %>' />
                    </td>
                </tr>
                <tr>
                    <td style="width: 20%">
                        <asp:Label ID="lblEventCategory" runat="server" Text='<%$Resources:EventResource, EventCategory %>'></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlEventCategory" runat="server">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvEventCategory" runat="server" ControlToValidate="ddlEventCategory"
                            ValidationGroup="AddEditEvent" Text="*" Display="Dynamic" ErrorMessage='<%$Resources:EventResource, EventCategory %>'></asp:RequiredFieldValidator>
                    </td>
                    <td style="width: 20%">
                        <asp:Label ID="lblEventLocation" runat="server" Text='<%$Resources:EventResource, EventLocation %>'></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlEventLocation" runat="server">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvEventLocation" runat="server" ControlToValidate="ddlEventLocation"
                            ValidationGroup="AddEditEvent" Text="*" Display="Dynamic" ErrorMessage='<%$Resources:EventResource, EventLocation %>'></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td style="width: 20%">
                        <asp:Label ID="lblFromDate" runat="server" Text='<%$Resources:EventResource, FromDate %>'></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox Width="135" ID="txtFromDate" runat="server" MaxLength="50" Enabled="false"></asp:TextBox>
                        <asp:ImageButton ID="ibtnFromDate" Width="23" Height="23" runat="server" ImageUrl="~/App_Themes/AdminSide2/Images/calendar.png" />
                        <Ajax:CalendarExtender ID="calndtxtFromDate" PopupButtonID="ibtnFromDate" runat="server"
                            TargetControlID="txtFromDate" CssClass="cal_Theme1" Format="dd/MM/yyyy" />
                        <asp:RequiredFieldValidator ID="rfvFromDate" runat="server" ControlToValidate="txtFromDate"
                            ValidationGroup="AddEditEvent" Text="*" Display="Dynamic" ErrorMessage='<%$Resources:EventResource, FromDate %>'></asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:Label ID="lblFromTime" runat="server" Text='<%$Resources:EventResource, Time %>'></asp:Label>
                    </td>
                    <td>
                        <table>
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtFromTimeHour" runat="server"></asp:TextBox>
                                    <Ajax:NumericUpDownExtender ID="numFromTimeHour" runat="server" TargetControlID="txtFromTimeHour"
                                        Width="120" RefValues="" ServiceDownMethod="" ServiceUpMethod="" TargetButtonDownID=""
                                        TargetButtonUpID="" Minimum="00" Maximum="23" />
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <asp:TextBox ID="txtFromTimeMminute" runat="server"></asp:TextBox>
                                    <Ajax:NumericUpDownExtender ID="numFromTimeMminute" runat="server" TargetControlID="txtFromTimeMminute"
                                        Width="120" RefValues="" ServiceDownMethod="" ServiceUpMethod="" TargetButtonDownID=""
                                        TargetButtonUpID="" Minimum="00" Maximum="59" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="width: 20%">
                        <asp:Label ID="lblToDate" runat="server" Text='<%$Resources:EventResource, ToDate %>'></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox Width="135" ID="txtToDate" runat="server" MaxLength="50" Enabled="false"></asp:TextBox>
                        <Ajax:CalendarExtender ID="calndtxtToDate" PopupButtonID="ibtnToDate" runat="server"
                            TargetControlID="txtToDate" CssClass="cal_Theme1" Format="dd/MM/yyyy" />
                        <asp:ImageButton ID="ibtnToDate" Width="23" Height="23" runat="server" ImageUrl="~/App_Themes/AdminSide2/Images/calendar.png" />
                        <asp:RequiredFieldValidator ID="rfvToDate" runat="server" ControlToValidate="txtToDate"
                            ValidationGroup="AddEditEvent" Text="*" Display="Dynamic" ErrorMessage='<%$Resources:EventResource, ToDate %>'></asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:Label ID="lblToTime" runat="server" Text='<%$Resources:EventResource, Time %>'></asp:Label>
                    </td>
                    <td>
                        <table>
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtToTimeHour" runat="server"></asp:TextBox>
                                    <Ajax:NumericUpDownExtender ID="numToTimeHour" runat="server" TargetControlID="txtToTimeHour"
                                        Width="120" RefValues="" ServiceDownMethod="" ServiceUpMethod="" TargetButtonDownID=""
                                        TargetButtonUpID="" Minimum="00" Maximum="23" />
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <asp:TextBox ID="txtToTimeMminute" runat="server"></asp:TextBox>
                                    <Ajax:NumericUpDownExtender ID="numToTimeMminute" runat="server" TargetControlID="txtToTimeMminute"
                                        Width="120" RefValues="" ServiceDownMethod="" ServiceUpMethod="" TargetButtonDownID=""
                                        TargetButtonUpID="" Minimum="00" Maximum="59" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="width: 20%">
                        <asp:Label ID="lblEvent" runat="server" Text='<%$Resources:EventResource, RepeatOptions %>'></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlRepeatOptions" onChange="return OnSelectedChangeRepeatOptions();"
                            runat="server">
                        </asp:DropDownList>
                        <div id="dvRepeatDaily" runat="server" style="display: none">
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblRepeatDailyEvery" Text='<%$Resources:EventResource, RepeatDailyEvery %>'
                                            runat="server" />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtRepeatDailyEvery" runat="server"></asp:TextBox>
                                        <Ajax:NumericUpDownExtender ID="ajaxRepeatDailyEvery" runat="server" TargetControlID="txtRepeatDailyEvery"
                                            Width="120" RefValues="" ServiceDownMethod="" ServiceUpMethod="" TargetButtonDownID=""
                                            TargetButtonUpID="" Minimum="1" Maximum="999" />
                                    </td>
                                    <td>
                                        <asp:Label ID="lblRepeatDailyDaysTitle" Text='<%$Resources:EventResource, Days %>'
                                            runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div id="dvRepeatWeekly" runat="server" style="display: none">
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblRepeatWeeklyEvery" Text='<%$Resources:EventResource, RepeatWeeklyEvery %>'
                                            runat="server" />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtRepeatWeeklyEvery" runat="server"></asp:TextBox>
                                        <Ajax:NumericUpDownExtender ID="ajaxRepeatWeeklyEvery" runat="server" TargetControlID="txtRepeatWeeklyEvery"
                                            Width="120" RefValues="" ServiceDownMethod="" ServiceUpMethod="" TargetButtonDownID=""
                                            TargetButtonUpID="" Minimum="1" Maximum="999" />
                                    </td>
                                    <td>
                                        <asp:Label ID="lblRepeatDailyWeeksTitle" Text='<%$Resources:EventResource, Weeks %>'
                                            runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:CheckBoxList runat="server" ID="chklRepeatWeeklyDays" RepeatDirection="Horizontal"
                                            RepeatLayout="Table" RepeatColumns="4">
                                        </asp:CheckBoxList>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div id="dvRepeatMonthly" runat="server" style="display: none">
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblRepeatMonthlyEvery" Text='<%$Resources:EventResource, RepeatMonthlyEvery %>'
                                            runat="server" />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtRepeatMonthlyEvery" runat="server"></asp:TextBox>
                                        <Ajax:NumericUpDownExtender ID="ajaxRepeatMonthlyEvery" runat="server" TargetControlID="txtRepeatMonthlyEvery"
                                            Width="120" RefValues="" ServiceDownMethod="" ServiceUpMethod="" TargetButtonDownID=""
                                            TargetButtonUpID="" Minimum="1" Maximum="999" />
                                    </td>
                                    <td>
                                        <asp:Label ID="lblRepeatDailyMonthsTitle" Text='<%$Resources:EventResource, Months %>'
                                            runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblTitleOnThe" Text='<%$Resources:EventResource, OnThe %>' runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlRepeatMonthlyPeriod" runat="server">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblTitleOfTheMonth" Text='<%$Resources:EventResource, OfTheMonth %>'
                                            runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div id="dvRepeatYearly" runat="server" style="display: none">
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblRepeatYearlyEvery" Text='<%$Resources:EventResource, RepeatYearlyEvery %>'
                                            runat="server" />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtRepeatYearlyEvery" runat="server"></asp:TextBox>
                                        <Ajax:NumericUpDownExtender ID="ajaxRepeatYearlyEvery" runat="server" TargetControlID="txtRepeatYearlyEvery"
                                            Width="120" RefValues="" ServiceDownMethod="" ServiceUpMethod="" TargetButtonDownID=""
                                            TargetButtonUpID="" Minimum="1" Maximum="999" />
                                    </td>
                                    <td>
                                        <asp:Label ID="lblRepeatYearlyTitle" Text='<%$Resources:EventResource, Years %>'
                                            runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td style="width: 20%">
                        <asp:Label ID="lblEventDetails" runat="server" Text='<%$Resources:EventResource, Details %>'></asp:Label>
                    </td>
                    <td colspan="3">
                      <telerik:RadEditor runat="server" ID="txtDetails" SkinID="DefaultSetOfTools" Height="515">
                            <ImageManager ViewPaths="~/Upload/Files/EditorImage/" UploadPaths="~/Upload/Files/EditorImage/"
                                DeletePaths="~/Upload/Files/EditorImage/"></ImageManager>
                               <MediaManager ViewPaths="~/Upload/Files/EditorImage/" UploadPaths="~/Upload/Files/EditorImage/"
                                DeletePaths="~/Upload/Files/EditorImage/"></MediaManager>
                        </telerik:RadEditor>
                        <asp:RequiredFieldValidator ID="rfvDetails" runat="server" ControlToValidate="txtDetails"
                            ValidationGroup="AddEditEvent" Text="*" Display="Dynamic" ErrorMessage='<%$Resources:EventResource, Details %>'></asp:RequiredFieldValidator>
                    </td>
                </tr>
            </table>
            <div class="btns">
                <asp:Button CssClass="btn" ID="btnExit" runat="server" Width="60px" CausesValidation="false"
                    Text='<%$Resources:EventResource, btnExit %>' />
                <asp:Button CssClass="btn" ID="btnReset" runat="server" Width="60px" CausesValidation="false"
                    Text='<%$Resources:EventResource, btnReset %>' />
                <asp:Button CssClass="btn" ID="btnSave" runat="server" Width="60px" ValidationGroup="AddEditEvent"
                    Text='<%$Resources:EventResource, btnSave %>' />
                <asp:Button CssClass="btn" ID="btnUpdate" runat="server" Width="60px" ValidationGroup="AddEditEvent"
                    Text='<%$Resources:EventResource, btnUpdate %>' />
            </div>
            <asp:ValidationSummary ID="valsummaryContact" runat="server" ValidationGroup="AddEditEvent"
                HeaderText='<%$Resources:EventResource, valSummHeader %>' DisplayMode="BulletList"
                ShowMessageBox="true" ShowSummary="false" />
        </asp:PlaceHolder>
    </ContentTemplate>
</asp:UpdatePanel>
