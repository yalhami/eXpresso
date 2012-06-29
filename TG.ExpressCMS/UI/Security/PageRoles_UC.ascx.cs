using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TG.ExpressCMS.DataLayer.Data;

namespace TG.ExpressCMS.UI.Security
{
    public partial class PageRoles_UC : System.Web.UI.UserControl
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Load += new EventHandler(PagesRoles_UC_Load);
            this.btnIn.Click += new EventHandler(btnIn_Click);
            this.btnOut.Click += new EventHandler(btnOut_Click);
            this.ddlPages.SelectedIndexChanged += new EventHandler(ddlPages_SelectedIndexChanged);
        }

        void ddlPages_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlPages.SelectedValue == "")
            {
                lstPageRoles.Items.Clear();
                return;
            }
            lstPageRoles.Items.Clear();
            lstPageRoles.DataSource = RolesManager.GetByPageID(Convert.ToInt32(ddlPages.SelectedValue));
            lstPageRoles.DataTextField = "Name";
            lstPageRoles.DataValueField = "ID";
            lstPageRoles.DataBind();
        }

        void PagesRoles_UC_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillDDL(); FillListBoxes();
            }
        }

        void btnOut_Click(object sender, EventArgs e)
        {
            RolesManager.DeletePageRole(Convert.ToInt32(ddlPages.SelectedValue), Convert.ToInt32(lstPageRoles.SelectedItem.Value));
            lstPageRoles.Items.Remove(lstPageRoles.SelectedItem);
        }

        void btnIn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lstRoles.Items.Count; i++)
            {
                if (lstRoles.Items[i].Selected)
                {
                    lstPageRoles.Items.Add(lstRoles.Items[i]);
                    //ADD to DB.
                    RolesManager.AssignRoletoPage(Convert.ToInt32(ddlPages.SelectedValue), Convert.ToInt32(lstRoles.Items[i].Value));
                    lstPageRoles.SelectedIndex = -1;
                }
            }
        }
        #region Fill List Boxes
        /// <summary>
        /// Fill Pages Drop down list
        /// </summary>
        private void FillDDL()
        {
            ddlPages.DataSource = CMSPageManager.GetAll().Where(t => t.Type == DataLayer.Enums.RootEnums.PageType.System).ToList();
            ddlPages.DataTextField = "Name";
            ddlPages.DataValueField = "ID";
            ddlPages.DataBind();

            ddlPages.Items.Insert(0, new ListItem());
        }
        #endregion
        #region Fill Drop down lists
        /// <summary>
        /// Fill List boxes.
        /// </summary>
        private void FillListBoxes()
        {
            lstRoles.DataSource = RolesManager.GetAll();
            lstRoles.DataTextField = "Name";
            lstRoles.DataValueField = "ID";
            lstRoles.DataBind();

        }
        #endregion
    }
}