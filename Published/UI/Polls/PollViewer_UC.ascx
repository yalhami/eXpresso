<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="PollViewer_UC.ascx.cs"
    Inherits="TG.ExpressCMS.UI.PollViewer_UC" %>
<script type="text/javascript">
    function CheckFields(msg) {
        var rdb = document.getElementById('<%=rdblstAnswers.ClientID %>');
        if (null != rdb) {
            var flag = 0;
            for (i = 0; i < rdb.cells.length; i++) {
                if (rdb.cells[i].all[0].checked == true)
                    flag = 1;
            }
            if (flag == 0) {
                alert(msg);
                return false;
            }
        }

    }
</script>
<asp:Label ID="lblPollQuestion" runat="server"></asp:Label>
<br />
<div id="dvmessages" runat="server">
</div>
<asp:RadioButtonList ID="rdblstAnswers" runat="server" RepeatColumns="1" RepeatDirection="Vertical">
</asp:RadioButtonList>
<br />
<asp:UpdatePanel ID="upnlVote" runat="server">
    <ContentTemplate>
        <%-- Text='<%$Resources:ExpressCMS,btnVote %>' Text='<%$Resources:ExpressCMS,btnViewResult %>'--%>
        <asp:Button ID="btnVote" runat="server" CssClass="pollbtn" />
        <asp:Button ID="btnViewResult" runat="server" CssClass="pollShowResult" />
        <Ajax:ModalPopupExtender ID="mpeShowResult" runat="server" TargetControlID="btnViewResult"
            PopupControlID="pnlResult" CancelControlID="ibtnClose" BackgroundCssClass="backModal">
        </Ajax:ModalPopupExtender>
        <asp:Panel ID="pnlResult" runat="server" CssClass="PollContainer">
            <table width="100%">
                <tr>
                    <td class="PollTitle">
                     <span>نتائج التصويت</span>   
                    
                    <div style="float: left;">
                        <asp:ImageButton ID="ibtnClose" runat="server" ToolTip='<%#GetCloseToolTip() %>'
                            ImageUrl="~/App_Themes/DrNouh1/images/PollClose.png" /></div>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="lblPollName" runat="server" Text='<%#GetPollName() %>'></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <table width="340" border="0" cellpadding="0" cellspacing="0" class="pollresult">
                            <asp:DataList ID="dtlst" runat="server" RepeatColumns="1" RepeatDirection="Vertical"
                                RepeatLayout="Flow" Width="100%" >
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblPollDetail" runat="server" Text='<%#DataBinder.Eval(Container,"DataItem.Name")%>'></asp:Label>
                                        </td>
                                        <td  align="right">
                                            <asp:Image ID="ibtnResult" runat="server" Width='<%#GetWidth(Convert.ToInt32( DataBinder.Eval(Container,"DataItem.Count")))%>'
                                                ImageUrl="~/App_Themes/DrNouh1/images/resbar.png" Height="19" />
                                        </td>
                                        <td>
                                            <asp:Label ID="lblCount" runat="server" Text='<%#DataBinder.Eval(Container,"DataItem.Count")%>'></asp:Label>
                                            <asp:Label ID="lblVoteCulCode" runat="server" Text='<%#GetVoteCultureCode() %>'></asp:Label>
                                            (
                                            <asp:Label ID="lblPercentage" runat="server" Text='<%#GetPercentage(Convert.ToInt32(DataBinder.Eval(Container,"DataItem.Count")))%>'></asp:Label>
                                            )%
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:DataList>
                        </table>
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
