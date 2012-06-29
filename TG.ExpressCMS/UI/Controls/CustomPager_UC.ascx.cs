using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TG.ExpressCMS.UI.Controls
{
    public partial class CustomPager_UC : System.Web.UI.UserControl
    {
        #region Global Variables

        public int PageSize
        {
            set
            {
                //if (value <= 0)
                //throw new Exception("Page size must be greater than zero");
                ViewState["PageSize"] = value;
                To = value;
            }
            get
            {
                if (ViewState["PageSize"] != null)
                    return Convert.ToInt32(ViewState["PageSize"]);
                else
                    return 10;
            }
        }
        public int PageNumber
        {
            set
            {
                // if (value <= 0)
                //throw new Exception("Page number must be greater than zero");
                ViewState["PageNumber"] = value;

            }
            get
            {
                if (ViewState["PageNumber"] != null)
                    return Convert.ToInt32(ViewState["PageNumber"]);
                else
                    return 1;
            }
        }
        public int TotalPages
        {
            get
            {
                return Convert.ToInt32(Math.Ceiling((double)TotalRows / (double)PageSize));
            }
        }
        public int TotalRows
        {
            set
            {
                // if (value <= 0)
                // throw new Exception("Value must be more than Zero");
                ViewState["TotalRows"] = value;
                lblTotalPages.Text = TotalPages.ToString();
                if (TotalRows < PageSize)
                    this.Visible = false;
                else
                    this.Visible = true;

                Check();
            }
            get
            {
                if (ViewState["TotalRows"] != null)
                    return Convert.ToInt32(ViewState["TotalRows"]);
                else
                    return 1;
            }
        }
        public int From
        {
            private set
            {
                //    if (value <= 0)
                //   throw new Exception("Value must be more than Zero");
                ViewState["From"] = value;
            }
            get
            {
                if (ViewState["From"] != null)
                    return Convert.ToInt32(ViewState["From"]);
                else
                    return 1;
            }
        }
        public int To
        {
            private set
            {
                //  if (value <= 0)
                //     throw new Exception("Value must be more than Zero");
                ViewState["To"] = value;
            }
            get
            {
                if (ViewState["To"] != null)
                    return Convert.ToInt32(ViewState["To"]);
                else
                    return 10;
            }
        }

        #endregion

        public delegate void btnNext();
        public event btnNext NextClick;

        public delegate void btnBack();
        public event btnBack BackClick;

        public delegate void btnGo();
        public event btnGo btnGoClick;
        /// <summary>
        /// On Intilization.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Load += new EventHandler(CustomPager_UC_Load);
            this.imgNext.Click += new ImageClickEventHandler(imgNext_Click);
            this.imgPrevious.Click += new ImageClickEventHandler(imgPrevious_Click);
            this.ibtnJumptoPage.Click += new ImageClickEventHandler(ibtnJumptoPage_Click);
        }

        void ibtnJumptoPage_Click(object sender, ImageClickEventArgs e)
        {

            int _from = 11, _to = 1;

            int _pageNumber = 0;
            Int32.TryParse(txtCurrentPage.Text, out _pageNumber);
            if (_pageNumber == 0)
                PageNumber = 1;

            PageNumber = _pageNumber;

            _from = (1 + PageSize * (PageNumber - 1));
            _to = (PageSize * PageNumber);


            From = _from;
            To = _to;

            Check();
            if (null != btnGoClick)
                btnGoClick();
        }

        void imgPrevious_Click(object sender, ImageClickEventArgs e)
        {


            int _from = 11, _to = 1;

            int _pageNumber = 0;
            Int32.TryParse(txtCurrentPage.Text, out _pageNumber);
            _pageNumber--;
            PageNumber = _pageNumber;
            txtCurrentPage.Text = _pageNumber.ToString();

            _from = (1 + PageSize * (PageNumber - 1));
            _to = (PageSize * PageNumber);

            From = _from;
            To = _to;

            Check();
            if (BackClick != null)
                BackClick();

            int pagenumber = PageNumber - 1;
            PageNumber = pagenumber;

        }

        void imgNext_Click(object sender, ImageClickEventArgs e)
        {

            int _from = 1, _to = 11;

            int _pageNumber = 0;
            Int32.TryParse(txtCurrentPage.Text, out _pageNumber);
            _pageNumber++;
            PageNumber = _pageNumber;
            txtCurrentPage.Text = _pageNumber.ToString();

            _from = (1 + PageSize * (PageNumber - 1));
            _to = (PageSize * PageNumber);

            From = _from;
            To = _to;

            Check();
            if (null != NextClick)
                NextClick();

            int pagenumber = PageNumber + 1;
            PageNumber = pagenumber;
        }

        void CustomPager_UC_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtCurrentPage.Text = "1";
            }
            Check();
        }
        private void Check()
        {
            if (TotalRows <= PageSize)
            {
                imgPrevious.Enabled = imgNext.Enabled = ibtnJumptoPage.Enabled = false;
            }

            if (PageNumber >= TotalPages)
                imgNext.Enabled = false;
            else
                imgNext.Enabled = true;

            if (PageNumber <= 1)
                imgPrevious.Enabled = false;
            else
                imgPrevious.Enabled = true;

            int pagenu = 0;
            Int32.TryParse(txtCurrentPage.Text, out pagenu);
            if (pagenu <= 0)
                txtCurrentPage.Text = "1";
            if (pagenu > TotalPages)
                txtCurrentPage.Text = TotalPages.ToString();


        }
    }
}