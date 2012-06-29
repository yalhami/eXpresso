<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="SawwtyyatViewer_UC.ascx.cs"
    Inherits="TG.ExpressCMS.UI.Custums.Sawtyyat.SawwtyyatViewer_UC" %>
<%@ Register Src="../../Controls/CustomPager_UC.ascx" TagName="CustomPager_UC" TagPrefix="uc1" %>
<script type="text/javascript">
    function directlisten(soundid) {

        OpenWin = this.open('frmSoundsPlayer.aspx?SoundID=' + soundid, "DRMNouhWebSite", "toolbar=no,menubar=no,location=no,scrollbars=no,resizable=yes, width=" + 200 + ", height=" + 90 + ", left = 0, top = 0");
    } 
</script>
<asp:UpdatePanel ID="upnlAll" runat="server">
    <ContentTemplate>
        <div class="SideContentInside" style="float: right; width: 100%;">
            <table width="100%">
                <tr>
                    <td>
                        <div style="float: right;" class="ContentTitle">
                            صوتيات ومرئيات
                        </div>
                    </td>
                    <td align="left" style="float: left;">
                        اختر النوع:
                        <asp:DropDownList CssClass="SubscribeFieldStyle" AutoPostBack="true" ID="ddlfileType"
                            runat="server" Width="180" Height="22">
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div id="dvvideos" runat="server">
            <br />
            <table width="100%">
                <tr>
                    <td align="right">
                        اختر التصنيف:
                        <asp:DropDownList CssClass="SubscribeFieldStyle" AutoPostBack="true" ID="ddlVideosCategories"
                            runat="server" Width="180" Height="22">
                            <asp:ListItem>التصنيفات...</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
            <br />
            <strong>المرئيات </strong>
            <br />
            <br />
            <br />
            <div style="overflow: auto; width: 100%; height: 100%;">
                <asp:DataList RepeatLayout="Table" ID="DataList1" runat="server" RepeatColumns="2"
                    RepeatDirection="Horizontal" Width="100%">
                    <ItemTemplate>
                        <div id="embedInner" runat="server">
                        </div>
                        <asp:HiddenField ID="hdnPath" runat="server" Value='<%#(DataBinder.Eval(Container,"DataItem.Path")) %>' />
                        <br />
                        <asp:Label ID="lblFileName2" ToolTip='<%#(DataBinder.Eval(Container,"DataItem.Details")) %>'
                            runat="server" Text='<%#(DataBinder.Eval(Container,"DataItem.Name")) %>'></asp:Label>
                        <asp:Label ID="lblDate" runat="server" onclick="Unnamed30_Click" CommandArgument='<%#DataBinder.Eval(Container,"DataItem.ID") %>'
                            Text='<%#(DataBinder.Eval(Container,"DataItem.Date").ToString()) %>'></asp:Label>
                    </ItemTemplate>
                </asp:DataList>
            </div>
            <br />
            <br />
            <uc1:CustomPager_UC ID="ucVideosPager" runat="server" />
        </div>
        <br />
        <div id="dvAudios" runat="server">
            <br />
            <table width="100%">
                <tr>
                    <td align="left" style="float: right;">
                        اختر التصنيف:
                        <asp:DropDownList AutoPostBack="true" CssClass="SubscribeFieldStyle" ID="ddlAudioCategories"
                            runat="server" Width="180" Height="22">
                            <asp:ListItem>التصنيفات...</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
            <br />
            <strong>الصوتيات </strong>
            <br />
            <br />
            <center>
                <div runat="server" id="dvPlayNow" style="height: 100%">
                    <div runat="server" id="dvVoice">
                    </div>
                    <br />
                    <strong>
                        <div runat="server" id="dvName">
                        </div>
                    </strong>
                </div>
                <br />
            </center>
            <div id="dvMessages" runat="server">
            </div>
            <div style="overflow: auto; width: 100%; float: right; height: 100%;">
                <asp:DataList RepeatLayout="Table" ID="dtlstVideosAudios" runat="server" RepeatColumns="1"
                    RepeatDirection="Vertical" Width="100%">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <asp:Label ID="lblFileName" ToolTip='<%#(DataBinder.Eval(Container,"DataItem.Details")) %>'
                                    runat="server" Text='<%#(DataBinder.Eval(Container,"DataItem.Name")) %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblDate" runat="server" onclick="Unnamed30_Click" CommandArgument='<%#DataBinder.Eval(Container,"DataItem.ID") %>'
                                    Text='<%#(DataBinder.Eval(Container,"DataItem.Date").ToString()) %>'></asp:Label>
                            </td>
                            <td>
                                <img src="../../../Upload/Files/EditorImage/DownLoad.png" width="15" height="15" />
                                <asp:HyperLink ID="hypDownload" runat="server" NavigateUrl='<%#GetDownLoadUrl(DataBinder.Eval(Container,"DataItem.Path").ToString()) %>'>تحميل</asp:HyperLink>
                            </td>
                            <td>
                                <asp:ImageButton ImageUrl="../../../App_themes/AdminSide/images/play.png" Width="15"
                                    runat="server" Height="15" CommandName="PlPa" CommandArgument='<%#DataBinder.Eval(Container,"DataItem.Path").ToString() %>'
                                    ToolTip='<%#DataBinder.Eval(Container,"DataItem.Name").ToString() %>' />
                                <asp:LinkButton ID="HyperLink1" ToolTip='<%#DataBinder.Eval(Container,"DataItem.Name").ToString() %>'
                                    CommandName="PlPa" runat="server" CommandArgument='<%#DataBinder.Eval(Container,"DataItem.Path").ToString() %>'
                                    Text="استماع"></asp:LinkButton>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:DataList>
                <br />
                <br />
                <uc1:CustomPager_UC ID="ucAudios" runat="server" />
            </div>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
