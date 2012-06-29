using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TG.ExpressCMS.DataLayer.Data;

namespace TG.ExpressCMS.UI.Security
{
    public partial class UsersRoles_UC : System.Web.UI.UserControl
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Load += new EventHandler(UsersRoles_UC_Load);
            this.btnIn.Click += new EventHandler(btnIn_Click);
            this.btnOut.Click += new EventHandler(btnOut_Click);
            this.ddlUsers.SelectedIndexChanged += new EventHandler(ddlUsers_SelectedIndexChanged);
        }

        void ddlUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlUsers.SelectedValue == "")
            {
                lstUserRoles.Items.Clear();
                return;
            }
            lstUserRoles.Items.Clear();
            lstUserRoles.DataSource = RolesManager.GetByUserID(Convert.ToInt32(ddlUsers.SelectedValue));
            lstUserRoles.DataTextField = "Name";
            lstUserRoles.DataValueField = "ID";
            lstUserRoles.DataBind();
        }

        void UsersRoles_UC_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillDDL(); FillListBoxes();
            }
        }

        void btnOut_Click(object sender, EventArgs e)
        {
            RolesManager.DeleteUserRole(Convert.ToInt32(ddlUsers.SelectedValue), Convert.ToInt32(lstUserRoles.SelectedItem.Value));
            lstUserRoles.Items.Remove(lstUserRoles.SelectedItem);            
        }

        void btnIn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lstRoles.Items.Count; i++)
            {
                if (lstRoles.Items[i].Selected)
                {
                    lstUserRoles.Items.Add(lstRoles.Items[i]);
                    //ADD to DB.
                    RolesManager.AssignRoletoUser(Convert.ToInt32(ddlUsers.SelectedValue), Convert.ToInt32(lstRoles.Items[i].Value));
                    lstUserRoles.SelectedIndex = -1;
                }
            }
        }
        #region Fill List Boxes
        /// <summary>
        /// Fill Users Drop down list
        /// </summary>
        private void FillDDL()
        {
            ddlUsers.DataSource = UsersManager.GetAll().Where(t => t.Type != DataLayer.Enums.RootEnums.UserType.SuperAdmin).ToList();
            ddlUsers.DataTextField = "Name";
            ddlUsers.DataValueField = "ID";
            ddlUsers.DataBind();

            ddlUsers.Items.Insert(0, new ListItem());
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