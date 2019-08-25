using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DMS.Patient
{
    public partial class AppointmentList : System.Web.UI.Page
    {
        Transaction tran = new Transaction();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gvAppoList.DataSource = tran.GetAllPatientByUsername(Session["uname"].ToString());
                gvAppoList.DataBind();
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int PatId = Convert.ToInt32(((Button)sender).CommandArgument.ToString());
            bool res = tran.RemoveAppointment(PatId);
            Response.Redirect("~/Patient/AppointmentList.aspx");
        }
    }
}