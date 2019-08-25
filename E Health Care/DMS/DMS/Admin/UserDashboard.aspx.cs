using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DMS.Admin
{
    public partial class UserDashboard : System.Web.UI.Page
    {
        Transaction tran = new Transaction();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                grdUserDetails.DataSource = tran.GetAccountDetailsAll();
                grdUserDetails.DataBind();


            }
        }

        protected void btnActivate_Click(object sender, EventArgs e)
        {
            string UserName = ((Button)sender).CommandArgument.ToString();
            tran.ActivatorByUserName(UserName, true);
            Response.Redirect("~/Admin/UserDashboard.aspx");
        }

        protected void btnDeactivate_Click(object sender, EventArgs e)
        {
            string UserName = ((Button)sender).CommandArgument.ToString();
            tran.ActivatorByUserName(UserName, false);
            Response.Redirect("~/Admin/UserDashboard.aspx");
        }
    }
}