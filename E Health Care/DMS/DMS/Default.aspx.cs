using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DMS
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void page_PreInit(object sender, EventArgs e)
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                if (HttpContext.Current.User.Identity.Name == "admin") // For admin user
                {
                    this.MasterPageFile = "~/admin.Master";
                }
            }

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            // Delete all user for this application

            //foreach (MembershipUser u in Membership.GetAllUsers())
            //{
            //    Membership.DeleteUser(u.UserName, true);
            //}

           
        }
    }
}
