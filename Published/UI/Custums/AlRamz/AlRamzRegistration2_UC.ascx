<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="AlRamzRegistration2_UC.ascx.cs"
    Inherits="TG.ExpressCMS.UI.Custums.AlRamzRegistration2_UC" %>
<%@ Register Src="../../Html/HtmlViewer_UC.ascx" TagName="HtmlViewer_UC" TagPrefix="uc1" %>
<asp:Panel ID="pnlStep1" runat="server">
    <div class="ContentTitle" runat="server">
        <asp:Label ID="lblStepOnePersonalInformation" runat="server" Text='<%$Resources:ExpressCMS,lblStepOnePersonalInformation %>'></asp:Label>
        <br />
        <asp:Label ID="lblContactInformation" runat="server" Text='<%$Resources:ExpressCMS,lblContactInformation %>'></asp:Label>
    </div>
    <table width="100%">
        <tr>
            <td>
                <asp:Label ID="lblName" runat="server" Text='<%$Resources:ExpressCMS,lblName %>'></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtName" runat="server" Width="250" MaxLength="255"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName"
                    ValidationGroup="Step1" Text="*" ErrorMessage='<%$Resources:ExpressCMS,lblName %>'></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblTitle" runat="server" Text='<%$Resources:ExpressCMS,lblTitle %>'></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlTitle" runat="server" Width="254">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblIdentityType" runat="server" Text='<%$Resources:ExpressCMS,lblIdentityType %>'></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlIdentitytType" runat="server" Width="254">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblPassportNumber" runat="server" Text='<%$Resources:ExpressCMS,lblPassportNumber %>'></asp:Label>
            </td>
            <td>
                <asp:TextBox Width="250" ID="txtPassportNumber" runat="server" MaxLength="50" ValidationGroup="valIndividuals"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblIssueDate" runat="server" Text='<%$Resources:ExpressCMS,lblIssueDate %>'></asp:Label>
            </td>
            <td>
                <telerik:RadDatePicker ID="rtDateOfIssue" runat="server" Width="140px" AutoPostBack="false"
                    DateInput-EmptyMessage="Pick a Date" DateInput-DateFormat="dd/MM/yyyy" MinDate="01/01/1990"
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
                <asp:Label ID="lblDateofExpiry" runat="server" Text='<%$Resources:ExpressCMS,lblDateofExpiry %>'></asp:Label>
            </td>
            <td>
                <telerik:RadDatePicker ID="rdDateofExpiry" runat="server" Width="140px" AutoPostBack="false"
                    DateInput-EmptyMessage="Pick a Date" DateInput-DateFormat="dd/MM/yyyy" MinDate="01/01/1990"
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
                <asp:Label ID="lblidentityNumber" runat="server" Text='<%$Resources:ExpressCMS,lblidentityNumber %>'></asp:Label>
            </td>
            <td>
                <asp:TextBox Width="250" ID="txtIdentityNumber" runat="server" MaxLength="50" ValidationGroup="valIndividuals"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblNationality" runat="server" Text='<%$Resources:ExpressCMS,lblNationality %>'></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlNationality" runat="server" Width="254">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblGender" runat="server" Text='<%$Resources:ExpressCMS,lblGender %>'></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlGender" runat="server" Width="254">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblBoD" runat="server" Text='<%$Resources:ExpressCMS,lblBoD %>'></asp:Label>
            </td>
            <td>
                <telerik:RadDatePicker ID="rdBoD" runat="server" Width="140px" AutoPostBack="false"
                    DateInput-EmptyMessage="Pick a Date" DateInput-DateFormat="dd/MM/yyyy" MinDate="01/01/1990"
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
                <asp:Label ID="lblFamilyBookNumber" runat="server" Text='<%$Resources:ExpressCMS,lblFamilyBookNumber %>'></asp:Label>
            </td>
            <td>
                <asp:TextBox Width="250" ID="txtFamilyBookNumber" runat="server" MaxLength="50"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblCountry" runat="server" Text='<%$Resources:ExpressCMS,lblCountry %>'></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlCountry" runat="server" Width="254">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblCity" runat="server" Text='<%$Resources:ExpressCMS,lblCity %>'></asp:Label>
            </td>
            <td>
                <asp:TextBox Width="250" ID="txtCity" runat="server" MaxLength="50"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblPrMobile" runat="server" Text='<%$Resources:ExpressCMS,lblPrMobile  %>'></asp:Label>
            </td>
            <td>
                <asp:TextBox Width="250" ID="txtPrMobile" runat="server" MaxLength="50" ValidationGroup="vaProxyTrustee"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvPrProxeeTrustee" runat="server" ControlToValidate="txtPrMobile"
                    ValidationGroup="Step1" Text="*" ErrorMessage='<%$Resources:ExpressCMS,lblPrMobile %>'></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblPhone" runat="server" Text='<%$Resources:ExpressCMS,lblHomePhone  %>'></asp:Label>
            </td>
            <td>
                <asp:TextBox Width="250" ID="txtPhone" runat="server" MaxLength="50" ValidationGroup="vaProxyTrustee"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblOfficePhone" runat="server" Text='<%$Resources:ExpressCMS,lblOfficePhone  %>'></asp:Label>
            </td>
            <td>
                <asp:TextBox Width="250" ID="txtOfficePhone" runat="server" MaxLength="50"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblFax" runat="server" Text='<%$Resources:ExpressCMS,lblFax  %>'></asp:Label>
            </td>
            <td>
                <asp:TextBox Width="250" ID="txtFax" runat="server" MaxLength="50"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblPOBox" runat="server" Text='<%$Resources:ExpressCMS,lblPOBox  %>'></asp:Label>
            </td>
            <td>
                <asp:TextBox Width="250" ID="txtPoBox" runat="server" MaxLength="50"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblEmail" runat="server" Text='<%$Resources:ExpressCMS,lblEmail %>'></asp:Label>
            </td>
            <td>
                <asp:TextBox Width="250" ID="txtEmail" runat="server" MaxLength="50" ValidationGroup="valIndividuals"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail"
                    ValidationGroup="Step1" Text="*" ErrorMessage='<%$Resources:ExpressCMS,lblEmail %>'></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail"
                    ValidationGroup="Step1" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                    ErrorMessage='<%$Resources:ExpressCMS,validEmail %>'>*</asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblProfession" runat="server" Text='<%$Resources:ExpressCMS,lblProfession %>'></asp:Label>
            </td>
            <td>
                <asp:TextBox Width="250" ID="txtProfession" runat="server" MaxLength="50" ValidationGroup="valIndividuals"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblMaterialStatus" runat="server" Text='<%$Resources:ExpressCMS,lblMaterialStatus %>'></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlMaterialStatus" runat="server" Width="254">
                </asp:DropDownList>
            </td>
        </tr>
    </table>
    <div class="actions">
        <asp:Button ID="btnStart" runat="server" CausesValidation="true" ValidationGroup="Step1"
            CssClass="btn" Text='<%$Resources:ExpressCMS,btnStart %>' />
        <asp:ValidationSummary ID="valSummaryIndiv" runat="server" ValidationGroup="Step1"
            HeaderText='<%$Resources:ExpressCMS,valSummHeader %>' ShowMessageBox="true" ShowSummary="false"
            DisplayMode="BulletList" />
    </div>
</asp:Panel>
<asp:Panel ID="pnlStep2" runat="server">
    <div id="Div1" class="ContentTitle" runat="server">
        <asp:Label ID="lbllegaldocs" runat="server" Text='<%$Resources:ExpressCMS,lbllegaldocs %>'></asp:Label>
        <br />
        <asp:Label ID="lbllegalInformation" runat="server" Text='<%$Resources:ExpressCMS,lbllegalInformation %>'></asp:Label>
        <asp:Label ID="lblInCaseofGuardian" runat="server" Text='<%$Resources:ExpressCMS,lblInCaseofGuardian %>'></asp:Label>
        <br />
    </div>
    <table>
        <tr>
            <td>
                <asp:Label ID="lblAuthirzedManagerSignator" runat="server" Text='<%$Resources:ExpressCMS,lblAuthirzedManagerSignator %>'></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtAuthorizedSignatorManager" runat="server" MaxLength="255" Width="250"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblIssueDate2" runat="server" Text='<%$Resources:ExpressCMS,lblIssueDate %>'></asp:Label>
            </td>
            <td>
                <telerik:RadDatePicker ID="dpIssueDate1" runat="server" Width="140px" AutoPostBack="false"
                    DateInput-EmptyMessage="Pick a Date" DateInput-DateFormat="dd/MM/yyyy" MinDate="01/01/1990"
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
                <asp:Label ID="lblExpDate2" runat="server" Text='<%$Resources:ExpressCMS,lblDateofExpiry %>'></asp:Label>
            </td>
            <td>
                <telerik:RadDatePicker ID="dpExpDate2" runat="server" Width="140px" AutoPostBack="false"
                    DateInput-EmptyMessage="Pick a Date" DateInput-DateFormat="dd/MM/yyyy" MinDate="01/01/1990"
                    MaxDate="01/01/3000">
                    <Calendar>
                        <SpecialDays>
                            <telerik:RadCalendarDay Repeatable="Today" ItemStyle-CssClass="rcToday" />
                        </SpecialDays>
                    </Calendar>
                </telerik:RadDatePicker>
            </td>
        </tr>
    </table>
    <div class="actions">
        <asp:Button ID="btnNextStep2" runat="server" CausesValidation="true" ValidationGroup="Step2"
            CssClass="btn" Text='<%$Resources:ExpressCMS,btnStart %>' />
    </div>
</asp:Panel>
<asp:Panel ID="pnlStep3" runat="server">
    <div id="Div2" class="ContentTitle" runat="server">
        <asp:Label ID="lblStep3" runat="server" Text='<%$Resources:ExpressCMS,lblStep3 %>'></asp:Label>
        <br />
        <asp:Label ID="lblBankAccountInformation" runat="server" Text='<%$Resources:ExpressCMS,lblBankAccountInformation %>'></asp:Label>
        <asp:Label ID="lblPleaseGivePersonalAccountInfo" runat="server" Text='<%$Resources:ExpressCMS,lblPleaseGivePersonalAccountInfo %>'></asp:Label>
    </div>
    <table width="100%">
        <tr>
            <td>
                <asp:Label ID="lblAccountName" runat="server" Text='<%$Resources:ExpressCMS,lblAccountName %>'></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtAccountName" runat="server" MaxLength="255" Width="250"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblAccountNumber" runat="server" Text='<%$Resources:ExpressCMS,lblAccountNumber %>'></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtAccountNumber" runat="server" MaxLength="255" Width="250"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblBank" runat="server" Text='<%$Resources:ExpressCMS,lblBank %>'></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtBank" runat="server" MaxLength="255" Width="250"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblBranch" runat="server" Text='<%$Resources:ExpressCMS,lblBranch %>'></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtBranch" runat="server" MaxLength="255" Width="250"></asp:TextBox>
            </td>
        </tr>
    </table>
    <div class="actions">
        <asp:Button ID="btnNextStep3" runat="server" CausesValidation="true" ValidationGroup="Step3"
            CssClass="btn" Text='<%$Resources:ExpressCMS,btnStart %>' />
    </div>
</asp:Panel>
<asp:Panel ID="pnlStep4" runat="server">
    <div id="Div3" class="ContentTitle" runat="server">
        <asp:Label ID="lblStep4" runat="server" Text='<%$Resources:ExpressCMS,lblStep4 %>'></asp:Label>
        <br />
        <asp:Label ID="lblQuestionaries" runat="server" Text='<%$Resources:ExpressCMS,lblQuestionaries %>'></asp:Label>
    </div>
    <table>
        <tr>
            <td>
                <asp:Label ID="lblTotalYearlyIncome" runat="server" Text='<%$Resources:ExpressCMS,lblTotalYearlyIncome %>'></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtTotalYearlyIncome" runat="server" MaxLength="255" Width="250"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblTotalInvProf" runat="server" Text='<%$Resources:ExpressCMS,lblTotalInvProf %>'></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtTotalInvProf" runat="server" MaxLength="255" Width="250"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblHowDescriptyouKnowledge" runat="server" Text='<%$Resources:ExpressCMS,lblHowDescriptyouKnowledge %>'></asp:Label>
            </td>
            <td>
                <asp:RadioButtonList ID="rdbExpereinceLevel" runat="server" Width="100%" RepeatColumns="3"
                    RepeatDirection="Horizontal" RepeatLayout="Table">
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblExpectedRateofReveune" runat="server" Text='<%$Resources:ExpressCMS,lblExpectedRateofReveune %>'></asp:Label>
            </td>
            <td>
                <asp:RadioButtonList ID="rdbExpectedRateOfRevenue" runat="server" Width="100%" RepeatColumns="5"
                    RepeatDirection="Horizontal" RepeatLayout="Table">
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbRiskDesgree" runat="server" Text='<%$Resources:ExpressCMS,lbRiskDesgree %>'></asp:Label>
            </td>
            <td>
                <asp:RadioButtonList ID="rdbRiskDegree" runat="server" Width="100%" RepeatColumns="5"
                    RepeatDirection="Horizontal" RepeatLayout="Table">
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblPurposeBehindInvestment" runat="server" Text='<%$Resources:ExpressCMS,lblPurposeBehindInvestment %>'></asp:Label>
            </td>
            <td>
                <asp:RadioButtonList ID="rdbPurposeBehindInvestment" runat="server" Width="100%"
                    RepeatColumns="5" RepeatDirection="Horizontal" RepeatLayout="Table">
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblInvestmentStrategy" runat="server" Text='<%$Resources:ExpressCMS,lblInvestmentStrategy %>'></asp:Label>
            </td>
            <td>
                <asp:RadioButtonList ID="rdbInvestMentStrategy" runat="server" Width="100%" RepeatColumns="5"
                    RepeatDirection="Horizontal" RepeatLayout="Table">
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblHowDouHearAboutAlRamz" runat="server" Text='<%$Resources:ExpressCMS,lblHowDouHearAboutAlRamz %>'></asp:Label>
            </td>
            <td>
                <asp:RadioButtonList ID="rdbHowdouhearaboutAlramz" runat="server" Width="100%" RepeatColumns="5"
                    RepeatDirection="Horizontal" RepeatLayout="Table">
                </asp:RadioButtonList>
            </td>
        </tr>
    </table>
    <div class="actions">
        <asp:Button ID="btnnextStep4" runat="server" CausesValidation="true" ValidationGroup="Step4"
            CssClass="btn" Text='<%$Resources:ExpressCMS,btnNext %>' />
    </div>
</asp:Panel>
<asp:Panel ID="pnlStep5" runat="server">
    <uc1:HtmlViewer_UC ID="HtmlViewer_UC1" runat="server" HashName="Step5" />
    <div class="actions">
        <asp:Button ID="btnNextStep5" runat="server" CausesValidation="true" ValidationGroup="Step5"
            CssClass="btn" Text='<%$Resources:ExpressCMS,btnNext %>' />
    </div>
</asp:Panel>
<asp:Panel ID="pnlStep6" runat="server">
    <div id="Div4" class="ContentTitle" runat="server">
        <asp:Label ID="lblStep6" runat="server" Text='<%$Resources:ExpressCMS,lblStep6 %>'></asp:Label>
        <br />
        <asp:Label ID="lblUploadControl" runat="server" Text='<%$Resources:ExpressCMS,lblUploadControl %>'></asp:Label>
    </div>
    <table>
        <tr>
            <td>
                <asp:Label ID="lblAccountOpeningForm" runat="server" Text='<%$Resources:ExpressCMS,lblAccountOpeningForm %>'></asp:Label>
            </td>
            <td>
                <telerik:RadUpload ControlObjectsVisibility="None" runat="server" MaxFileInputsCount="1"
                    InitialFileInputsCount="1" AllowedFileExtensions="{.doc,.docx,.pdf}" MaxFileSize="200000000"
                    TargetPhysicalFolder="~/Upload/Files/" ID="rtAccountOpeningForm">
                </telerik:RadUpload>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblPassport" runat="server" Text='<%$Resources:ExpressCMS,lblPassport %>'></asp:Label>
            </td>
            <td>
                <telerik:RadUpload ID="rtUploadPassport" ControlObjectsVisibility="None" runat="server"
                    MaxFileInputsCount="1" InitialFileInputsCount="1" AllowedFileExtensions="{.jpg,.jpeg,.pmp,.tiff,.bmp}"
                    MaxFileSize="200000000" TargetPhysicalFolder="~/Upload/Files/">
                </telerik:RadUpload>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblIdentity" runat="server" Text='<%$Resources:ExpressCMS,lblIdentity %>'></asp:Label>
            </td>
            <td>
                <telerik:RadUpload ID="rtIdentity" ControlObjectsVisibility="None" runat="server"
                    MaxFileInputsCount="1" InitialFileInputsCount="1" AllowedFileExtensions="{.jpg,.jpeg,.pmp,.tiff,.bmp}"
                    MaxFileSize="200000000" TargetPhysicalFolder="~/Upload/Files/">
                </telerik:RadUpload>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblFamilyBook" runat="server" Text='<%$Resources:ExpressCMS,lblFamilyBook %>'></asp:Label>
            </td>
            <td>
                <telerik:RadUpload ID="rtFamilyBook" ControlObjectsVisibility="None" runat="server"
                    MaxFileInputsCount="1" InitialFileInputsCount="1" AllowedFileExtensions="{.jpg,.jpeg,.pmp,.tiff,.bmp}"
                    MaxFileSize="200000000" TargetPhysicalFolder="~/Upload/Files/">
                </telerik:RadUpload>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblPowerofAttornary" runat="server" Text='<%$Resources:ExpressCMS,lblPowerofAttornary %>'></asp:Label>
            </td>
            <td>
                <telerik:RadUpload ID="rtPowerofAttornary" ControlObjectsVisibility="None" runat="server"
                    MaxFileInputsCount="1" InitialFileInputsCount="1" AllowedFileExtensions="{.jpg,.jpeg,.pmp,.tiff,.bmp}"
                    MaxFileSize="200000000" TargetPhysicalFolder="~/Upload/Files/">
                </telerik:RadUpload>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblAllPapers" runat="server" Text='<%$Resources:ExpressCMS,lblAllPapers %>'></asp:Label>
            </td>
            <td>
                <telerik:RadUpload ID="rtAllPapers" ControlObjectsVisibility="None" runat="server"
                    MaxFileInputsCount="1" InitialFileInputsCount="1" AllowedFileExtensions="{.jpg,.jpeg,.pmp,.tiff,.bmp}"
                    MaxFileSize="200000000" TargetPhysicalFolder="~/Upload/Files/">
                </telerik:RadUpload>
            </td>
        </tr>
    </table>
    <uc1:HtmlViewer_UC ID="HtmlViewer_UC2" runat="server" HashName="Step6" />
    <br />
    <div class="actions">
        <asp:Button ID="btnNext6" runat="server" CausesValidation="true" ValidationGroup="Step5"
            CssClass="btn" Text='<%$Resources:ExpressCMS,btnNext %>' />
    </div>
</asp:Panel>
<asp:Panel ID="pnlLastStep" runat="server">
    <uc1:HtmlViewer_UC ID="HtmlViewer_UC3" runat="server" HashName="LastStep" />
    <div class="actions" style="display: none;">
        <asp:Button ID="btnFinish" runat="server" CausesValidation="true" ValidationGroup="Step5"
            CssClass="btn" Text='<%$Resources:ExpressCMS,btnFinish %>' />
    </div>
</asp:Panel>
