using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DMS.Account
{
    public partial class Login : System.Web.UI.Page
    {
        Transaction tran = new Transaction();
        protected void page_PreInit(object sender, EventArgs e)
        {
            

        }
        protected void Page_Load(object sender, EventArgs e)
        {

            RegisterHyperLink.NavigateUrl = "~/Account/Register.aspx";
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            bool result = tran.IsAuthenticateUser(UserName.Text.Trim(), Password.Text.Trim());
            if (result == false)
                Response.Redirect("~/Account/Login.aspx");
            else
            {
                Session["uname"] = UserName.Text.Trim();
                Response.Redirect("~/Account/RegisterDetails.aspx");
            }
        }
    }
}
