using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DMS.Account
{
    public partial class Register : System.Web.UI.Page
    {
        Transaction tran = new Transaction();
        AccountModel model = new AccountModel();
        protected void page_PreInit(object sender, EventArgs e)
        {
           

        }
        protected void Page_Load(object sender, EventArgs e)
        {
          
                if (!IsPostBack)
                {
                    if (Session["uname"] != null)
                    {
                        model = tran.GetAccountDetailsByUserName(Session["uname"].ToString());
                        UserName.Text = model.username;
                        UserName.Enabled = false;
                        Password.Attributes.Add("value", "12345678910");
                        Password.Enabled = false;
                        Email.Text = model.email;
                        MobilePIN.Text = model.mobile;
                        drpCountry.SelectedValue = model.country;
                        drpGender.SelectedValue = model.gender;
                        drpRole.SelectedValue = (model.roleid).ToString();
                        imgPhotoView.ImageUrl = GetImage(model.photo);
                        CreateUserButton.Visible = false;
                        ConfirmPassword.Attributes.Add("value", "12345678910");
                        ConfirmPassword.Enabled = false;
                        UpdateUserButton.Visible = true;
                    }
                    else
                    {
                        UserName.Enabled = true;
                        Password.Enabled = true;
                        CreateUserButton.Visible = true;
                        ConfirmPassword.Enabled = true;
                        UpdateUserButton.Visible = false;
                        UpdPanel.Visible = false;

                    }

                }

            
           
        }
        public string GetImage(object img)
        {
            return "data:image/jpg;base64," + Convert.ToBase64String((byte[])img);
        }
        
        protected void CreateUserButton_Click(object sender, EventArgs e)
        {
            

            model.username = UserName.Text.Trim();
            bool IsExist = tran.IsUsernameExist(UserName.Text.Trim());
            if (IsExist == true)
            {
                lblError.Text = "This User name already Exist!";
            }
            else
            {
                model.email = Email.Text.Trim();
                model.mobile = MobilePIN.Text.Trim();
                model.password = Password.Text.Trim();
                model.country = drpCountry.SelectedValue;
                model.gender = drpGender.SelectedValue;
                model.roleid = Convert.ToInt32(drpRole.SelectedValue);


                if (FilePhoto.HasFile)
                {
                    //try
                    //{
                        int length = FilePhoto.PostedFile.ContentLength;
                        byte[] pic = new byte[length];

                        FilePhoto.PostedFile.InputStream.Read(pic, 0, length);

                        model.photo = pic;


                    //}
                    //catch (Exception ex)
                    //{

                    //}
                }

                if (tran.InsertAccountDetails(model))
                {
                    Session["uname"] = UserName.Text.Trim();
                    Response.Redirect("~/Account/RegisterDetails.aspx");
                }
                else
                {
                    Response.Redirect("~/Account/Register.aspx");

                }
            }
        }

        protected void Password_TextChanged(object sender, EventArgs e)
        {

        }

        protected void UpdateUserButton_Click(object sender, EventArgs e)
        {
            model.username = UserName.Text.Trim();
            model.email = Email.Text.Trim();
            model.mobile = MobilePIN.Text.Trim();
            model.country = drpCountry.SelectedValue;
            model.gender = drpGender.SelectedValue;
            model.roleid = Convert.ToInt32(drpRole.SelectedValue);


            if (FilePhoto.HasFile)
            {
                //try
                //{
                    int length = FilePhoto.PostedFile.ContentLength;
                    byte[] pic = new byte[length];

                    FilePhoto.PostedFile.InputStream.Read(pic, 0, length);

                    model.photo = pic;


                //}
                //catch (Exception ex)
                //{

                //}
            }

            if (tran.UpdateAccountDetails(model))
            {
                Response.Redirect("~/Account/RegisterDetails.aspx");

            }
            else
            {
                Response.Redirect("~/Account/Register.aspx");

            }



        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }


    }
}
