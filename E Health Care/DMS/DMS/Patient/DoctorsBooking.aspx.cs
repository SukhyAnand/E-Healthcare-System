using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DMS.Patient
{
    public partial class DoctorsBooking : System.Web.UI.Page
    {
        Transaction tran = new Transaction();
        protected void Page_Load(object sender, EventArgs e)
        {           

        }
        protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
        {

            List<HospitalModel> model = tran.GetHospitalByState(ddlState.SelectedValue);

            lstHospital.DataSource = model;
            lstHospital.DataTextField = "hosname";
            lstHospital.DataValueField = "hosid";
            lstHospital.DataBind();
            if (ddlState.SelectedItem != null && lstHospital.SelectedItem != null && ddlSpecial.SelectedItem != null)
            {
                List<DoctorModel> model1 = tran.GetDoctorByFilter(ddlState.SelectedValue, lstHospital.SelectedItem.Text, ddlSpecial.SelectedValue);
                if (model1.Any())
                {
                    gvDoctorDet.DataSource = model1;
                    gvDoctorDet.DataBind();
                }
                else
                {

                    gvDoctorDet.DataSource = null;
                    gvDoctorDet.DataBind();
                }
            }
        }

        protected void lstHospital_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (ddlState.SelectedItem != null && lstHospital.SelectedItem != null && ddlSpecial.SelectedItem != null)
            {
                List<DoctorModel> model1 = tran.GetDoctorByFilter(ddlState.SelectedValue, lstHospital.SelectedItem.Text, ddlSpecial.SelectedValue);
                if (model1.Any())
                {
                    gvDoctorDet.DataSource = model1;
                    gvDoctorDet.DataBind();
                }
                else
                {

                    gvDoctorDet.DataSource = null;
                    gvDoctorDet.DataBind();
                }
            }
        }
        private void GetSelectedRecord()
        {
            for (int i = 0; i < gvDoctorDet.Rows.Count; i++)
            {
                RadioButton rb = (RadioButton)gvDoctorDet.Rows[i]
                                .Cells[0].FindControl("RadioButton1");
                if (rb != null)
                {
                    if (rb.Checked)
                    {
                        HiddenField hf = (HiddenField)gvDoctorDet.Rows[i]
                                        .Cells[0].FindControl("HiddenField1");
                        if (hf != null)
                        {
                            ViewState["SelectedContact"] = hf.Value;
                        }

                        break;
                    }
                }
            }
        }

        private void SetSelectedRecord()
        {
            for (int i = 0; i < gvDoctorDet.Rows.Count; i++)
            {
                RadioButton rb = (RadioButton)gvDoctorDet.Rows[i].Cells[0]
                                                .FindControl("RadioButton1");
                if (rb != null)
                {
                    HiddenField hf = (HiddenField)gvDoctorDet.Rows[i]
                                        .Cells[0].FindControl("HiddenField1");
                    if (hf != null && ViewState["SelectedContact"] != null)
                    {
                        if (hf.Value.Equals(ViewState["SelectedContact"].ToString()))
                        {
                            rb.Checked = true;
                            break;
                        }
                    }
                }
            }
        }
        protected void ddlSpecial_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (ddlState.SelectedItem != null && lstHospital.SelectedItem != null && ddlSpecial.SelectedItem != null)
            {
                List<DoctorModel> model1 = tran.GetDoctorByFilter(ddlState.SelectedValue, lstHospital.SelectedItem.Text, ddlSpecial.SelectedValue);
                if (model1.Any())
                {
                    gvDoctorDet.DataSource = model1;
                    gvDoctorDet.DataBind();
                }
                else
                {

                    gvDoctorDet.DataSource = null;
                    gvDoctorDet.DataBind();
                }
            }

        }

       

        protected void btnAppointment_Click(object sender, EventArgs e)
        {
            PatientModel PModel = new PatientModel();
            PModel.IsActiveM = true;
            PModel.Patient_AgeM = txtPatAge.Text.Trim();
            PModel.Patient_CountryM = ddlCountry.SelectedValue;
            PModel.Patient_DiseaseM = ddlSpecial.SelectedValue;
            PModel.Patient_GenderM = drpGender.SelectedValue;
            PModel.Patient_NameM = txtPatFullName.Text.Trim();
            PModel.Patient_ReportM = txtDisease.Text.Trim();
            PModel.Patient_StateM = ddlState.SelectedValue;
            PModel.User_IdM = tran.GetUserIdByUsername(Session["uname"].ToString());
            PModel.Patient_HospitalM = lstHospital.SelectedItem.Text;
            
            for (int i = 0; i < gvDoctorDet.Rows.Count; i++)
            {
                RadioButton rb = (RadioButton)gvDoctorDet.Rows[i].Cells[0]
                                                .FindControl("RadioButton1");
                
                    if (rb != null)
                    {
                        if (rb.Checked)
                        {
                        HiddenField hf = (HiddenField)gvDoctorDet.Rows[i]
                                            .Cells[0].FindControl("HiddenField1");
                        PModel.Doc_IdM = Convert.ToInt32(hf.Value);

                        }
                   }
            }

            PModel.IsConfirmM = false;
            PModel.Appo_DateM = txtAppDate.Text.Trim();

            bool res = tran.InsertPatientDetails(PModel);
            if (res)
            {
                Response.Redirect("~/Patient/AppointmentList.aspx");

            }
        }
    }
}