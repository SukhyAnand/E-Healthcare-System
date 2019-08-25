using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DMS.User
{
    public partial class UserProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string UserName = txtUserName.Text.Trim();
            string UniRoll = txtUniRoll.Text.Trim();
            string Dept = drpDept.SelectedItem.Value;
            string UserId = Context.User.Identity.Name;

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {

        }
    }
}