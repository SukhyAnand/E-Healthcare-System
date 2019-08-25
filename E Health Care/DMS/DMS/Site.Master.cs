using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DMS
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        Transaction tran = new Transaction();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["uname"] != null)
            {
                lblHeadLoginName.Text = Session["uname"].ToString();
                lnkHeadLoginStatus.Visible = false;
                lnkLogout.Visible = true;
                MenuItem m1 = new MenuItem("NavigationMenu");
                m1.NavigateUrl = "~/Account/RegisterDetails.aspx";
                m1.Text = "My Profile";
                NavigationMenu.Items.Add(m1);
                string Role = tran.GetRoleByUserName(Session["uname"].ToString());
                bool? IsActive = tran.IsActiveUser(Session["uname"].ToString());
                if (Role == "Admin" && IsActive== true)
                {
                    MenuItem m2 = new MenuItem("NavigationMenu");
                    m2.NavigateUrl = "~/Admin/UserDashboard.aspx";
                    m2.Text = "Admin Dashboard";
                    NavigationMenu.Items.Add(m2);

                    MenuItem m3 = new MenuItem("NavigationMenu");
                   // m3.NavigateUrl = "~/Admin/Master.aspx";
                    m3.Text = "Master Entry";
                    NavigationMenu.Items.Add(m3);

                    MenuItem sub1m3 = new MenuItem("NavigationMenu");
                    sub1m3.NavigateUrl = "~/Admin/HospitalMaster.aspx";
                    sub1m3.Text = "Hospital Master";
                    m3.ChildItems.Add(sub1m3);

                    MenuItem sub2m3 = new MenuItem("NavigationMenu");
                    sub2m3.NavigateUrl = "~/Admin/DoctorMaster.aspx";
                    sub2m3.Text = "Doctor Master";
                    m3.ChildItems.Add(sub2m3);

                    MenuItem sub3m3 = new MenuItem("NavigationMenu");
                    sub3m3.NavigateUrl = "~/Admin/MedicineMaster.aspx";
                    sub3m3.Text = "Medicine Master";
                    m3.ChildItems.Add(sub3m3);

                   

                     MenuItem m4 = new MenuItem("NavigationMenu");
                     m4.NavigateUrl = "~/ReviewListing.aspx";
                     m4.Text = "User Review";
                     NavigationMenu.Items.Add(m4);

                }
                else if (Role == "Doctor" && IsActive == true)
                {
                    MenuItem m3 = new MenuItem("NavigationMenu");
                    m3.NavigateUrl = "~/Doctor/MyAppointment.aspx";
                    m3.Text = "My Appointment";
                    NavigationMenu.Items.Add(m3);

                    MenuItem m6 = new MenuItem("NavigationMenu");
                    m6.NavigateUrl = "~/UserReview.aspx";
                    m6.Text = "Post Review";
                    NavigationMenu.Items.Add(m6);

                }
                else if (Role == "Patient" && IsActive == true)
                {
                    MenuItem m3 = new MenuItem("NavigationMenu");
                    m3.NavigateUrl = "~/Patient/DoctorsBooking.aspx";
                    m3.Text = "Doctor Appointment";
                    NavigationMenu.Items.Add(m3);
                    
                    MenuItem m4 = new MenuItem("NavigationMenu");
                    m4.NavigateUrl = "~/Patient/AppointmentList.aspx";
                    m4.Text = "My Appointments";
                    NavigationMenu.Items.Add(m4);

                    MenuItem m5 = new MenuItem("NavigationMenu");
                    m5.NavigateUrl = "~/UserReview.aspx";
                    m5.Text = "Post Review";
                    NavigationMenu.Items.Add(m5);


                }


            }
            else
            {
                lblHeadLoginName.Text = "Guest";
                lnkLogout.Visible = false;
                lnkHeadLoginStatus.Visible = true;
            }




    
        }

        protected void lnkHeadLoginStatus_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Account/Login.aspx");
        }

        protected void lnkLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Logout.aspx");
        }
    }
}
