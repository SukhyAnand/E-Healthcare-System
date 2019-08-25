using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DMS.Admin
{
    public partial class DoctorMaster : System.Web.UI.Page
    {
        Transaction tran = new Transaction();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                List<AccountModel> model = tran.GetAllDocUser();
                ddlDocUser.DataSource = model;
                ddlDocUser.DataTextField = "username";
                ddlDocUser.DataValueField = "userid";
                ddlDocUser.DataBind();

                if (Request.QueryString["EditId"] != null)
                {
                    btnSubmit.Visible = false;
                    ddlDocUser.Enabled = false;
                    HidDocId.Value = Request.QueryString["EditId"].ToString();
                    int DocId = Convert.ToInt32(Request.QueryString["EditId"].ToString());
                    DoctorModel m = tran.GetDocDetailsById(DocId);
                    ddlDocUser.SelectedValue = m.User_IdM.ToString();
                    txtDocname.Text = m.Doc_NameM;
                    txtExpdate.Text = m.Doc_ExpM;
                    txtDocDetails.Text = m.Doc_DetailsM;
                    txtHomeFee.Text = m.Doc_Home_FeeM;
                    txtLicense.Text = m.Doc_RegIdM;
                    txtOnSiteFee.Text = m.Doc_OnSite_FeeM;
                    ddlSpecial.SelectedValue = m.Doc_SpecialistM;
                    ddlState.SelectedValue = m.Doc_StateM;
                   
                    List<HospitalModel> n = tran.GetHospitalByState(m.Doc_StateM);

                    lstHospital.DataSource = n;
                    lstHospital.DataTextField = "hosname";
                    lstHospital.DataValueField = "hosid";
                    lstHospital.DataBind();

                    string[] arr = m.Doc_HospitalM.Split(',');
                    foreach (string item in arr)
                    {
                        if (lstHospital.Items.FindByText(item) != null)
                            lstHospital.Items.FindByText(item).Selected = true;
                    }


                }
                else
                {
                    btnUpdate.Visible = false;

                }

                if (tran.GetAllDocDetails().Count > 0)
                {

                    gvDoctors.DataSource = tran.GetAllDocDetails();
                    gvDoctors.DataBind();

                }

            }
        }

        protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            List<HospitalModel> model= tran.GetHospitalByState(ddlState.SelectedValue);

            lstHospital.DataSource = model;
            lstHospital.DataTextField = "hosname";
            lstHospital.DataValueField = "hosid";
            lstHospital.DataBind();
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/DoctorMaster.aspx");
        }
        public string GetListBoxSelStringInComma(ListBox Listbox1)
        {
            string selectedItem = "";
            if (Listbox1.Items.Count > 0)
            {
                for (int i = 0; i < Listbox1.Items.Count; i++)
                {
                    if (Listbox1.Items[i].Selected)
                    {
                        if (selectedItem == "")
                            selectedItem = Listbox1.Items[i].Text;
                        else
                            selectedItem += "," + Listbox1.Items[i].Text;
                    }
                }
            }
            return selectedItem;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            // LINQ lambda syntax
            //IEnumerable<string> query = lstHospital.Items.Cast<ListItem>().Where(item => item.Selected).ToList<string>();

            string csv = GetListBoxSelStringInComma(lstHospital) ;

            DoctorModel model = new DoctorModel();
            model.User_IdM = Convert.ToInt32(ddlDocUser.SelectedValue);
            model.Doc_NameM = txtDocname.Text.Trim();
            model.Doc_ExpM = txtExpdate.Text.Trim();
            model.Doc_RegIdM = txtLicense.Text.Trim();
            model.Doc_SpecialistM = ddlSpecial.SelectedValue;
            model.Doc_StateM = ddlState.SelectedValue;
            model.Doc_CountryM = ddlCountry.SelectedValue;
            model.Doc_HospitalM = csv;
            model.Doc_Home_FeeM = txtHomeFee.Text.Trim();
            model.Doc_OnSite_FeeM = txtOnSiteFee.Text.Trim();
            model.Doc_DetailsM = txtDocDetails.Text.Trim();
            bool res=   tran.InsertDoctorDetails(model);

            Response.Redirect(Request.Url.AbsoluteUri);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string id = ((Button)sender).CommandArgument.ToString();
            bool res = tran.RemoveDoctorDetails(Convert.ToInt32(id));
            Response.Redirect("~/Admin/DoctorMaster.aspx");

        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            string id = ((Button)sender).CommandArgument.ToString();
            Response.Redirect("~/Admin/DoctorMaster.aspx?EditId=" + id);
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {

            string csv = GetListBoxSelStringInComma(lstHospital);

            DoctorModel model = new DoctorModel();
            model.User_IdM = Convert.ToInt32(ddlDocUser.SelectedValue);
            model.Doc_IdM = Convert.ToInt32(HidDocId.Value);
            model.Doc_NameM = txtDocname.Text.Trim();
            model.Doc_ExpM = txtExpdate.Text.Trim();
            model.Doc_RegIdM = txtLicense.Text.Trim();
            model.Doc_SpecialistM = ddlSpecial.SelectedValue;
            model.Doc_StateM = ddlState.SelectedValue;
            model.Doc_CountryM = ddlCountry.SelectedValue;
            model.Doc_HospitalM = csv;
            model.Doc_Home_FeeM = txtHomeFee.Text.Trim();
            model.Doc_OnSite_FeeM = txtOnSiteFee.Text.Trim();
            model.Doc_DetailsM = txtDocDetails.Text.Trim();
            bool res = tran.UpdateDoctorDetails(model);
            Response.Redirect("~/Admin/DoctorMaster.aspx");
        }

       
    }
}