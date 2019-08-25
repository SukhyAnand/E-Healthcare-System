using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DMS.Account
{
    public partial class RegisterDetails : System.Web.UI.Page
    {
        Transaction tran = new Transaction();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["uname"] != null)
                {
                   AccountModel model =  tran.GetAccountDetailsByUserName(Session["uname"].ToString());
                   UserNameView.Text = model.username;
                   MobilePINView.Text = model.mobile;
                   drpCountryView.SelectedValue = model.country;
                   imgPhotoView.ImageUrl = GetImage(model.photo);
                   Email.Text = model.email;
                   MobilePINView.Text = model.mobile;
                   drpRoleView.SelectedValue =(model.roleid).ToString();
                }



            }


        }

        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Account/Register.aspx");
        }
        public string GetImage(object img)
        {
            return "data:image/jpg;base64," + Convert.ToBase64String((byte[])img);
        }
    }
}