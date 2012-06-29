using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TG.ExpressCMS.DataLayer.Entities;
using TG.ExpressCMS.DataLayer.Data;

namespace TG.ExpressCMS.UI.Custums
{
    public partial class AlRamzRegistration2_UC : System.Web.UI.UserControl
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Load += new EventHandler(AlRamzRegistration2_UC_Load);
            btnStart.Click += new EventHandler(btnStart_Click);
            btnNextStep2.Click += new EventHandler(btnNextStep2_Click);
            btnNextStep3.Click += new EventHandler(btnNextStep3_Click);
            btnnextStep4.Click += new EventHandler(btnnextStep4_Click);
            btnNextStep5.Click += new EventHandler(btnNextStep5_Click);
            btnNext6.Click += new EventHandler(btnNext6_Click);
            btnFinish.Click += new EventHandler(btnFinish_Click);
        }
        void btnNext6_Click(object sender, EventArgs e)
        {
            pnlStep6.Visible = false;
            pnlLastStep.Visible = true;


        }

        void btnNextStep5_Click(object sender, EventArgs e)
        {
            pnlStep5.Visible = false;
            pnlStep6.Visible = true;

            TempRegistration.Infomration _info = TempRegistration.GetInformation();
            _info.Step5_AccountOpeningFOrm = UtilitiesManager.GetSavedFile(rtAccountOpeningForm.UploadedFiles[0], true);
            _info.Step5_Passport = UtilitiesManager.GetSavedFile(rtUploadPassport.UploadedFiles[0], true);
            _info.Step5_Identity = UtilitiesManager.GetSavedFile(rtIdentity.UploadedFiles[0], true);
            _info.Step5_FamilyBook = UtilitiesManager.GetSavedFile(rtFamilyBook.UploadedFiles[0], true);
            _info.Step5_PowerofAttornary = UtilitiesManager.GetSavedFile(rtPowerofAttornary.UploadedFiles[0], true);
            _info.AllDocs = UtilitiesManager.GetSavedFile(rtAllPapers.UploadedFiles[0], true);

            TempRegistration.SaveInformation(_info);

         //   TG.ExpressCMS.UI.Custums.AlRamz.AlramzRegistrationDataContext context = new AlRamz.AlramzRegistrationDataContext();


            //context.REGISTRATION_INSERT(null, _info.Name, _info.title, _info.IdentityType, _info.PassportNumber, _info.IssueDate, _info.ExpDate, _info.IdentityType, _info.Nationlaity, _info.Gender, _info.DateOfBirth, _info.FamilyBookNumber, _info.Country, _info.City, _info.Mobile, _info.HomePhone, _info.OfficePhone, _info.Fax, _info.POBox, _info.Email, _info.Profeession, _info.materialStatus, _info.AuthorizedManagerSignatory, _info.Step2_IssueDate, _info.Step2_ExpDate, _info.step3_AccountName, _info.Step3_AccountNumber, _info.Step3_Bank, _info.Step3_Branch, _info.Step4_TotalYealryIncome, _info.Step4_TotalInvPortFoli, _info.step4_HowdoDescriptExperience, _info.Step4_Risk, _info.Step4_PurposeOfInvestment, _info.Step4_Strategy, _info.Step4_HowDouhear, _info.Step5_AccountOpeningFOrm, _info.Step5_Passport, _info.Step5_Identity, _info.Step5_FamilyBook, _info.Step5_PowerofAttornary, _info.AllDocs);


        }

        void btnnextStep4_Click(object sender, EventArgs e)
        {
            pnlStep4.Visible = false;
            pnlStep5.Visible = true;

            TempRegistration.Infomration _info = TempRegistration.GetInformation();
            _info.Step4_TotalYealryIncome = txtTotalYearlyIncome.Text;
            _info.Step4_PurposeOfInvestment = rdbPurposeBehindInvestment.SelectedValue;
            _info.step4_HowdoDescriptExperience = rdbExpereinceLevel.SelectedValue;
            _info.step4_whatisYourExpectedRev = rdbExpectedRateOfRevenue.SelectedValue;
            _info.Step4_Risk = rdbRiskDegree.SelectedValue;
            _info.Step4_TotalInvPortFoli = txtTotalInvProf.Text;
            _info.Step4_Strategy = rdbInvestMentStrategy.SelectedValue;
            _info.Step4_HowDouhear = rdbHowdouhearaboutAlramz.SelectedValue;

            TempRegistration.SaveInformation(_info);


        }

        void btnNextStep3_Click(object sender, EventArgs e)
        {
            pnlStep3.Visible = false;
            pnlStep4.Visible = true;

            TempRegistration.Infomration _info = TempRegistration.GetInformation();
            _info.step3_AccountName = txtAccountName.Text;
            _info.Step3_AccountNumber = txtAccountNumber.Text;
            _info.Step3_Bank = txtBank.Text;
            _info.Step3_Branch = txtBranch.Text;

            TempRegistration.SaveInformation(_info);
        }

        void btnNextStep2_Click(object sender, EventArgs e)
        {
            pnlStep2.Visible = false;
            pnlStep3.Visible = true;

            TempRegistration.Infomration _info = TempRegistration.GetInformation();
            _info.AuthorizedManagerSignatory = txtAuthorizedSignatorManager.Text;
            _info.Step2_IssueDate = dpIssueDate1.DbSelectedDate.ToString();
            _info.Step2_ExpDate = dpExpDate2.DbSelectedDate.ToString();

            TempRegistration.SaveInformation(_info);
        }

        void btnStart_Click(object sender, EventArgs e)
        {
            pnlStep1.Visible = false;
            pnlStep2.Visible = true;

            TempRegistration.Infomration _info = new TempRegistration.Infomration();

            _info.Name = txtName.Text;
            _info.title = (RegistrationEnums.Title)Convert.ToInt32(ddlTitle.SelectedValue);
            _info.IdentityType = (RegistrationEnums.IDType)Convert.ToInt32(ddlIdentitytType.SelectedValue);
            _info.PassportNumber = txtPassportNumber.Text;
            _info.IssueDate = rtDateOfIssue.DbSelectedDate.ToString();
            _info.ExpDate = rdDateofExpiry.DbSelectedDate.ToString();
            _info.IDNumber = txtIdentityNumber.Text;

            _info.Nationlaity = ddlNationality.SelectedValue;
            _info.Gender = (RegistrationEnums.Gender)Convert.ToInt32(ddlGender.SelectedValue);
            _info.DateOfBirth = rdBoD.DbSelectedDate.ToString();
            _info.FamilyBookNumber = txtFamilyBookNumber.Text;
            _info.Country = ddlCountry.SelectedValue;
            _info.City = txtCity.Text;
            _info.Mobile = txtPrMobile.Text;
            _info.HomePhone = txtPhone.Text;
            _info.OfficePhone = txtOfficePhone.Text;
            _info.Fax = txtFax.Text;
            _info.POBox = txtPoBox.Text;
            _info.Email = txtEmail.Text;
            _info.Profeession = txtProfession.Text;
            _info.materialStatus = (RegistrationEnums.MaterialStatus)Convert.ToInt32(ddlMaterialStatus.SelectedValue);


            TempRegistration.SaveInformation(_info);

        }

        void AlRamzRegistration2_UC_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillLists();
                PerformSettings();
                pnlStep1.Visible = true;
            }
        }

        void btnFinish_Click(object sender, EventArgs e)
        {

        }
        #region " Fill List "
        private void FillLists()
        {
            IList<LookupDetails> colLookups = VolunteerManager.GetAllCountries();
            ddlCountry.DataSource = colLookups;
            ddlCountry.DataTextField = "Name";
            ddlCountry.DataValueField = "ID";
            ddlCountry.DataBind();

            ddlCountry.Items.Insert(0, new ListItem("[Select Your Country]"));

            ddlGender.DataSource = UtilitiesManager.GetEnumDataSource(Resources.ExpressCMS.ResourceManager, typeof(RegistrationEnums.Gender));
            ddlGender.DataTextField = "Key";
            ddlGender.DataValueField = "Value";
            ddlGender.DataBind();

            ddlGender.Items.Insert(0, new ListItem("PleaseselectyourGender"));

            ddlIdentitytType.DataSource = UtilitiesManager.GetEnumDataSource(Resources.ExpressCMS.ResourceManager, typeof(RegistrationEnums.IDType));
            ddlIdentitytType.DataTextField = "Key";
            ddlIdentitytType.DataValueField = "Value";
            ddlIdentitytType.DataBind();

            ddlIdentitytType.Items.Insert(0, new ListItem("PleaseselectyourIdentityType"));

            ddlMaterialStatus.DataSource = UtilitiesManager.GetEnumDataSource(Resources.ExpressCMS.ResourceManager, typeof(RegistrationEnums.MaterialStatus));
            ddlMaterialStatus.DataTextField = "Key";
            ddlMaterialStatus.DataValueField = "Value";
            ddlMaterialStatus.DataBind();

            ddlIdentitytType.Items.Insert(0, new ListItem("PleaseselectyourmaterialStatus"));


            ddlNationality.DataSource = colLookups;
            ddlNationality.DataTextField = "Name";
            ddlNationality.DataValueField = "ID";
            ddlNationality.DataBind();

            ddlNationality.Items.Insert(0, new ListItem("SelectYourNationality"));


            rdbExpectedRateOfRevenue.DataSource = UtilitiesManager.GetEnumDataSource(Resources.ExpressCMS.ResourceManager, typeof(RegistrationEnums.ExpectedRateOfRevenue));
            rdbExpectedRateOfRevenue.DataTextField = "Key";
            rdbExpectedRateOfRevenue.DataValueField = "Value";
            rdbExpectedRateOfRevenue.DataBind();


            rdbExpereinceLevel.DataSource = UtilitiesManager.GetEnumDataSource(Resources.ExpressCMS.ResourceManager, typeof(RegistrationEnums.InvestMentExperience));
            rdbExpereinceLevel.DataTextField = "Key";
            rdbExpereinceLevel.DataValueField = "Value";
            rdbExpereinceLevel.DataBind();

            rdbHowdouhearaboutAlramz.DataSource = UtilitiesManager.GetEnumDataSource(Resources.ExpressCMS.ResourceManager, typeof(RegistrationEnums.HowdidyouhearedAboutAlRamz));
            rdbHowdouhearaboutAlramz.DataTextField = "Key";
            rdbHowdouhearaboutAlramz.DataValueField = "Value";
            rdbHowdouhearaboutAlramz.DataBind();


            rdbInvestMentStrategy.DataSource = UtilitiesManager.GetEnumDataSource(Resources.ExpressCMS.ResourceManager, typeof(RegistrationEnums.InvestmentStrategy));
            rdbInvestMentStrategy.DataTextField = "Key";
            rdbInvestMentStrategy.DataValueField = "Value";
            rdbInvestMentStrategy.DataBind();

            rdbPurposeBehindInvestment.DataSource = UtilitiesManager.GetEnumDataSource(Resources.ExpressCMS.ResourceManager, typeof(RegistrationEnums.PurposeOfInvestment));
            rdbPurposeBehindInvestment.DataTextField = "Key";
            rdbPurposeBehindInvestment.DataValueField = "Value";
            rdbPurposeBehindInvestment.DataBind();

            rdbRiskDegree.DataSource = UtilitiesManager.GetEnumDataSource(Resources.ExpressCMS.ResourceManager, typeof(RegistrationEnums.RiskRate));
            rdbRiskDegree.DataTextField = "Key";
            rdbRiskDegree.DataValueField = "Value";
            rdbRiskDegree.DataBind();

            ddlTitle.DataSource = UtilitiesManager.GetEnumDataSource(Resources.ExpressCMS.ResourceManager, typeof(RegistrationEnums.Title));
            ddlTitle.DataTextField = "Key";
            ddlTitle.DataValueField = "Value";
            ddlTitle.DataBind();
        }
        #endregion

        #region "PerformIntialSettings"
        /// <summary>
        /// 
        /// </summary>
        private void PerformSettings()
        {
            pnlStep1.Visible = false;
            pnlStep2.Visible = false;
            pnlStep3.Visible = false;
            pnlStep4.Visible = false;
            pnlStep5.Visible = false;
            pnlStep6.Visible = false;
        }
        #endregion
    }

    #region Enums
    public class RegistrationEnums
    {
        public enum MaterialStatus
        {
            Single = 1, Married = 2, Divorced = 3
        }
        public enum Title
        {
            Mr = 1, Dr = 2, FamilyBook = 3
        }
        public enum IDType
        {
            Passport = 1, UAEIDCard = 2, Other = 3
        }
        public enum Gender
        {
            Male = 1, Female = 2
        }
        public enum InvestMentExperience
        {
            Inexperienced = 1, SomewhatExpereinced = 2, Experienced = 3
        }
        public enum ExpectedRateOfRevenue
        {
            Lessthan15 = 1, from15to50 = 2, from50to100 = 3, Morethan100 = 4
        }
        public enum RiskRate
        {
            Low = 1, Moderate = 2, High = 3, Veryhigh = 4
        }
        public enum InvestmentStrategy
        {
            ShortTerm = 1, LongTerm = 2, DailyTerm = 3, Other = 4
        }

        public enum PurposeOfInvestment
        {
            Fastrevenue = 1, PeriodicalIncome = 2, CapitalIncome = 3, LongtermIncome = 4
        }
        public enum HowdidyouhearedAboutAlRamz
        {
            TV = 1, Radio = 2, Website = 3, Freind = 4, other = 5
        }
    }
    #endregion
    #region Temp Class
    public class TempRegistration
    {
        public class Infomration
        {
            public string Name
            {
                set;
                get;
            }
            public RegistrationEnums.Title title
            {
                set;
                get;
            }
            public RegistrationEnums.IDType IdentityType
            {
                set;
                get;
            }
            public string PassportNumber
            {
                set;
                get;
            }
            public string IssueDate
            {
                set;
                get;
            }
            public string ExpDate
            {
                set;
                get;
            }
            public string IDNumber
            {
                set;
                get;
            }
            public string Nationlaity
            {
                set;
                get;
            }
            public RegistrationEnums.Gender Gender
            {
                set;
                get;
            }
            public string DateOfBirth
            {
                set;
                get;
            }
            public string FamilyBookNumber
            {
                set;
                get;
            }
            public string Country
            {
                set;
                get;
            }
            public string City
            {
                set;
                get;
            }
            public string Mobile
            {
                set;
                get;
            }
            public string HomePhone
            {
                set;
                get;
            }
            public string OfficePhone
            {
                set;
                get;
            }
            public string Fax
            {
                set;
                get;
            }
            public string POBox
            {
                set;
                get;
            }
            public string Email
            {
                set;
                get;
            }
            public string Profeession
            {
                set;
                get;
            }
            public RegistrationEnums.MaterialStatus materialStatus
            {
                set;
                get;
            }
            public string AuthorizedManagerSignatory
            {
                set;
                get;
            }
            public string Step2_IssueDate
            {
                set;
                get;
            }
            public string Step2_ExpDate
            {
                set;
                get;
            }
            public string step3_AccountName
            {
                set;
                get;
            }
            public string Step3_AccountNumber
            {
                set;
                get;
            }
            public string Step3_Bank
            {
                set;
                get;
            }
            public string Step3_Branch
            {
                set;
                get;
            }
            public string Step4_TotalYealryIncome
            {
                set;
                get;
            }
            public string Step4_TotalInvPortFoli
            {
                set;
                get;
            }
            public string step4_HowdoDescriptExperience
            {
                set;
                get;
            }
            public string step4_whatisYourExpectedRev
            {
                set;
                get;
            }
            public string Step4_Risk
            {
                set;
                get;
            }
            public string Step4_PurposeOfInvestment
            {
                set;
                get;
            }
            public string Step4_Strategy
            {
                set;
                get;
            }
            public string Step4_HowDouhear
            {
                set;
                get;
            }
            public string Step5_AccountOpeningFOrm
            {
                set;
                get;
            }
            public string Step5_Passport
            {
                set;
                get;
            }
            public string Step5_Identity
            {
                set;
                get;
            }
            public string Step5_FamilyBook
            {
                set;
                get;
            }
            public string Step5_PowerofAttornary
            {
                set;
                get;
            }
            public string AllDocs
            {
                set;
                get;
            }

        }

        public static void SaveInformation(Infomration _info)
        {
            HttpContext.Current.Session["Information"] = _info;
        }
        public static Infomration GetInformation()
        {
            if (null == HttpContext.Current.Session["Information"])
                return null;
            return (Infomration)HttpContext.Current.Session["Information"];
        }
    }
    #endregion
}