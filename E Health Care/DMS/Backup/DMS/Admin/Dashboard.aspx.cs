using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data;

namespace DMS.Admin
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                grdDashboard.DataSource = Membership.GetAllUsers();
                grdDashboard.DataBind();

                List<Transaction> trans = new List<Transaction>();
                DataSet ds = Transaction.SqlSelTransaction("spFileContentDashBoard", trans);

                Chart1.DataSource = ds;
                Chart1.Series["Series1"].XValueMember = "UserId";
                Chart1.Series["Series1"].YValueMembers = "UploadedFile";
                Chart1.DataBind();

            }

        }
       

        protected void grdGlobalList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdDashboard.PageIndex = e.NewPageIndex;
           // DataSet ds = Membership.GetAllUsers();
            grdDashboard.DataSource = Membership.GetAllUsers();
            grdDashboard.DataBind();
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
          
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            string UserName = ((ImageButton)sender).CommandArgument.ToString();
            Membership.DeleteUser(UserName);
            Response.Redirect(Request.RawUrl);

        }
    }
}