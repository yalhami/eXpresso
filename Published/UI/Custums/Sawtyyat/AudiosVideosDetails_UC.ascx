<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="AudiosVideosDetails_UC.ascx.cs"
    Inherits="TG.ExpressCMS.UI.Custums.AudiosVideosDetails_UC" %>
<asp:UpdatePanel runat="server">
    <ContentTemplate>
        <div class="ContentTitle">
            <asp:Label ID="lblAudVidDetails" runat="server"></asp:Label>
        </div>
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
        <div runat="server" id="dvMessages">
        </div>
        <asp:Panel ID="pnlAudio" runat="server">
            <table width="100%">
                <tr>
                    <th>
                        <asp:Label ID="lblFileName" runat="server"></asp:Label>
                    </th>
                    <td>
                        <img src="../../../Upload/Files/EditorImage/DownLoad.png" width="15" height="15" />
                        <asp:HyperLink ID="hypDownload" runat="server">تحميل</asp:HyperLink>
                    </td>
                    <td>
                        <img src="../../../Upload/Files/EditorImage/Listen.png" width="15" height="15" />
                        <asp:LinkButton ID="lbListen" runat="server" Style="cursor: pointer;" >استماع</asp:LinkButton>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <br />
        <asp:Panel runat="server" ID="pnlVideo">
            <center>
                <div id="embedInner" runat="server">
                </div>
                <br />
                <asp:Label ID="lblFileName2" runat="server"></asp:Label>
            </center>
        </asp:Panel>
        <br />
    </ContentTemplate>
</asp:UpdatePanel>
