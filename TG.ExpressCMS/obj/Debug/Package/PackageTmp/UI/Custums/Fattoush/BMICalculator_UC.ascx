<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="BMICalculator_UC.ascx.cs"
    Inherits="TG.ExpressCMS.UI.Custums.Fattoush.BMICalculator_UC" %>
<script type="text/javascript">
    function Calculate() {

        var height = document.getElementById('<%=txtlength.ClientID %>');
        var result = document.getElementById('<%=dvresult.ClientID %>');
        var tblresult = document.getElementById('<%=tblMass.ClientID %>');

        var width = document.getElementById('<%=txtWidth.ClientID %>');

        if (width.value == "") {
            alert("يرجى ادخال الوزن");
            return;
        }
        if (height.value == "") {
            alert("يرجى ادخال الطول");
            return;
        }

        if (null != width && null != height && null != result) {
            result.innerHTML = Math.round(width.value / Math.pow(height.value / 100, 2));
            var res = document.getElementById('<%=dvresult.ClientID %>');
            if (result.innerHTML >= 28) {

                res.style.backgroundColor = "#F78181";
            }
            else
                res.style.backgroundColor = "#2EFE9A";
            tblresult.style.display = "block";
        }
    }
</script>
<asp:LinkButton ID="lbCalculate" runat="server" Text="حساب مقياس الكتلة للجسم"></asp:LinkButton>
<Ajax:ModalPopupExtender ID="mpeCalc" runat="server" PopupControlID="pnlModal" TargetControlID="lbCalculate"
    BackgroundCssClass="modalBGCss" CancelControlID="ibtnClose">
</Ajax:ModalPopupExtender>
<asp:Panel ID="pnlModal" runat="server" CssClass="modalpopup" Style="display: none;">
    <div class="headerandClose" runat="server">
        <div class="ContentTitle">
            حساب مقياس الكتلة للجسم
            <br />
        </div>
        <div class="headerclose">
            <asp:ImageButton ID="ibtnClose" Width="17" Height="17" runat="server" ImageUrl="~/App_Themes/AdminSide/images/Delete_01.png"
                ToolTip="إغلاق" />
        </div>
    </div>
    <table>
        <tr>
            <td colspan="2" style="color: Black;">
                <a href="/UserPages/NewsDetails.aspx?NewsID=154" style="color: Black;" target="_blank">
                    ما هو مقياس الكتلة؟ </a>
            </td>
        </tr>
        <tr>
            <td>
                الطول
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtlength" MaxLength="4" Width="65"></asp:TextBox>
                سم
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                الوزن
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtWidth" MaxLength="4" Width="65"></asp:TextBox>
                كغ
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <div class="actions" style="font-family: Tahoma;">
                    <asp:Button runat="server" ID="btnCalc" Width="80%" Style="font-family: Tahoma; margin-left: 40px;
                        font-size: 10px;" CssClass="btn" Text="احسب النتيجة ؟" OnClientClick="Calculate();return false;" />
                </div>
            </td>
        </tr>
    </table>
    <div id="tblMass" runat="server" style="display: none; width: 100%">
        <table width="90%" cellpadding="0" cellspacing="0" border="0">
            <tr>
                <th>
                    معدل قياس الكتلة هو:
                </th>
                <td>
                    <div class="result" runat="server" id="dvresult" runat="server">
                    </div>
                </td>
            </tr>
        </table>
        <table width="98%" cellpadding="0" cellspacing="0" border="0" style="margin-top: 15px;
            margin-bottom: 15px;">
            <tr>
                <th>
                    الحد الادنى
                </th>
                <th>
                    الحد الاعلى
                </th>
                <th>
                    الوصف
                </th>
            </tr>
            <tr>
                <td colspan="3">
                    ........................................................................
                </td>
            </tr>
            <tr>
                <td>
                    17.5
                </td>
                <td>
                    18.5
                </td>
                <td>
                    تحت الوزن الطبيعي
                </td>
            </tr>
            <tr>
                <td>
                    25
                </td>
                <td>
                    18.5
                </td>
                <td>
                    الوزن المثالي
                </td>
            </tr>
            <tr>
                <td>
                    25
                </td>
                <td>
                    27
                </td>
                <td>
                    اعلى من الحد الطبيعي
                </td>
            </tr>
            <tr>
                <td>
                    28
                </td>
                <td>
                    35
                </td>
                <td>
                    سمين
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    35 فما فوق
                </td>
                <td>
                    سمنة مرضية
                </td>
            </tr>
        </table>
    </div>
</asp:Panel>
