using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DMS.Admin.Images
{
    public partial class HospitalMaster : System.Web.UI.Page
    {
        Transaction tran = new Transaction();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.BindData();
            }

        }
        private void BindData()
        {

            List<HospitalModel> model = tran.GetHospitalDetailsAll();
            gvHospitals.DataSource = model;
            gvHospitals.DataBind();
        }
        protected void EditCustomer(object sender, GridViewEditEventArgs e)
        {
            gvHospitals.EditIndex = e.NewEditIndex;
            BindData();
        }

        protected void CancelEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvHospitals.EditIndex = -1;
            BindData();
        }
        protected void RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && gvHospitals.EditIndex == e.Row.RowIndex)
            {

                DropDownList ddlCities = (DropDownList)e.Row.FindControl("ddlState");
                TextBox txtName = (TextBox)e.Row.FindControl("txtName");


                ddlCities.Items.FindByValue((e.Row.FindControl("lblState") as Label).Text).Selected = true;

                txtName.Text = (e.Row.FindControl("lblName") as Label).Text;

                

              
            }

            
           
        }
        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = Convert.ToInt32(e.RowIndex);
            int id = Convert.ToInt32(((Label)gvHospitals.Rows[index].Cells[0].FindControl("lblId")).Text);
            tran.RemoveHospital(id);
            Response.Redirect(Request.Url.AbsoluteUri);
            
        }

        protected void UpdateCustomer(object sender, GridViewUpdateEventArgs e)
        {
            string state = (gvHospitals.Rows[e.RowIndex].FindControl("ddlState") as DropDownList).SelectedItem.Value;
            string HosName = (gvHospitals.Rows[e.RowIndex].FindControl("txtName") as TextBox).Text.Trim();
            string HosId = gvHospitals.DataKeys[e.RowIndex].Value.ToString();
            string strConnString = ConfigurationManager.ConnectionStrings["EHealthCareConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(strConnString))
            {
                string query = "update HospitaMaster set State = @state,Hospital_Name=@HosName where Hospital_Id = @HosId";
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@state", state);
                    cmd.Parameters.AddWithValue("@HosId", HosId);
                    cmd.Parameters.AddWithValue("@HosName", HosName);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Redirect(Request.Url.AbsoluteUri);
                }
            }
        }

        protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            HospitalModel model = new HospitalModel();
            model.hosname = txtHosName.Text.Trim();
            model.hosstate = ddlHosState.SelectedValue;
            model.hoscountry = ddlCountry.SelectedValue;

            tran.AddHospital(model);
            Response.Redirect(Request.Url.AbsoluteUri);
        }
    }
}