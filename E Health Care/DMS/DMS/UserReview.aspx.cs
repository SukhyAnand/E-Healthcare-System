using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DMS.Account
{
    public partial class UserReview : System.Web.UI.Page
    {
        Transaction tran = new Transaction();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnreset_Click(object sender, EventArgs e)
        {

        }

        protected void btnReview_Click(object sender, EventArgs e)
        {
            ReviewModel model = new ReviewModel();
            model.RatingM = Convert.ToInt32(drpRating.SelectedValue);
            model.Review_TextM = txtComment.Text.Trim();
            model.Review_DateM = DateTime.Now.ToString("dd/MM/yyyy");
            model.Raised_ByM = tran.GetUserIdByUsername(Session["uname"].ToString());
            model.User_RoleM = tran.GetRoleByUserName(Session["uname"].ToString());

            if(tran.InsertReviewDetails(model))
            {
                lblMsg.Text = "Your Review posted successfully!"; 
                

            }
            else
            {

                 lblMsg.Text = "Your Review post failure !";
            }

        }
    }
}