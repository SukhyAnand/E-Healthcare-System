using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DMS.Admin
{
    public partial class admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //if (HttpContext.Current.User.Identity.IsAuthenticated)
            //{
            //    if (HttpContext.Current.User.Identity.Name == "admin") // For admin user
            //    {
                   

            //        MenuItem m1 = new MenuItem("NavigationMenu");
            //        m1.NavigateUrl = "~/Admin/Dashboard.aspx";
            //        m1.Text = "Admin Dashbord";
            //        NavigationMenu.Items.Add(m1);
            //        MenuItem m2 = new MenuItem("NavigationMenu");
            //        m2.NavigateUrl = "~/Admin/AdminDefault.aspx";
            //        m2.Text = "Admin Global Dashboard";
            //        NavigationMenu.Items.Add(m2);

            //        MenuItem m4 = new MenuItem("NavigationMenu");
            //        m4.NavigateUrl = "~/Account/ChangePassword.aspx";
            //        m4.Text = "Master Entry";
            //        NavigationMenu.Items.Add(m4);

            //        MenuItem sub1m4 = new MenuItem("NavigationMenu");
            //        sub1m4.NavigateUrl = "~/Account/Register.aspx";
            //        sub1m4.Text = "User Master";
            //        m4.ChildItems.Add(sub1m4);

            //        MenuItem sub2m4 = new MenuItem("NavigationMenu");
            //        sub2m4.NavigateUrl = "~/Admin/DocType.aspx";
            //        sub2m4.Text = "Doc Type Master";
            //        m4.ChildItems.Add(sub2m4);

            //        MenuItem m3 = new MenuItem("NavigationMenu");
            //        m3.NavigateUrl = "~/Admin/UserList.aspx";
            //        m3.Text = "Password Change";
            //        NavigationMenu.Items.Add(m3);

            //    }
            //    else // For normal user
            //    {
            //        MenuItem m1 = new MenuItem("NavigationMenu");
            //        m1.NavigateUrl = "~/User/UploadDoc.aspx";
            //        m1.Text = "Upload Document";
            //        NavigationMenu.Items.Add(m1);
            //        MenuItem m2 = new MenuItem("NavigationMenu");
            //        m2.NavigateUrl = "~/User/GlobalDocList.aspx";
            //        m2.Text = "Global Dashboard";
            //        NavigationMenu.Items.Add(m2);
            //        MenuItem m3 = new MenuItem("NavigationMenu");
            //        m3.NavigateUrl = "~/User/UserDocList.aspx";
            //        m3.Text = "My Dashboard";
            //        NavigationMenu.Items.Add(m3);
            //        MenuItem m4 = new MenuItem("NavigationMenu");
            //        m4.NavigateUrl = "~/Account/ChangePassword.aspx";
            //        m4.Text = "Password Change";
            //        NavigationMenu.Items.Add(m4);
            //    }
            //}
        }
    }
}