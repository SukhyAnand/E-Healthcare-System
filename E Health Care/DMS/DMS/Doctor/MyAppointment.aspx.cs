using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DMS.Doctor
{
    public partial class MyAppointment : System.Web.UI.Page
    {
        Transaction tran = new Transaction();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gvAppoList.DataSource = tran.GetAllPatientByDocUsername(Session["uname"].ToString());
                gvAppoList.DataBind();
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int PatId = Convert.ToInt32(((Button)sender).CommandArgument.ToString());
            bool res = tran.UpdateAppointmentConfirmation(PatId);
            Response.Redirect("~/Doctor/MyAppointment.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int PatId;
            for (int i = 0; i < gvAppoList.Rows.Count; i++)
            {
                RadioButton rb = (RadioButton)gvAppoList.Rows[i].Cells[0]
                                                .FindControl("RadioButton1");

                if (rb != null)
                {
                    if (rb.Checked)
                    {
                        HiddenField hf = (HiddenField)gvAppoList.Rows[i]
                                            .Cells[0].FindControl("HiddenField1");
                        PatId = Convert.ToInt32(hf.Value);

                    }
                }
            }


        }
    }
}