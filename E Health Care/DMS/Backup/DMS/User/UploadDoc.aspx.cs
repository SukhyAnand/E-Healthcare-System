using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Web.Profile;
using System.Web.Security;

namespace DMS
{
    public partial class UploadDoc : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataSet ds = new DataSet();
                List<Transaction> list = new List<Transaction>();
                list.Add(new Transaction {Key="@CurrentUser",value=Context.User.Identity.Name });
                ds = Transaction.SqlSelTransaction("spGetAllUser", list);
                lstUser.DataTextField = "UserName";
                lstUser.DataValueField = "UserName"; 
                lstUser.DataSource = ds.Tables[0];
                lstUser.DataBind();

                try
                {
                    txtUserName.Text = HttpContext.Current.Profile.GetPropertyValue("FullName").ToString();
                    txtUniRoll.Text = HttpContext.Current.Profile.GetPropertyValue("UserUniRoll").ToString();
                    drpDept.SelectedValue = HttpContext.Current.Profile.GetPropertyValue("UserDept").ToString(); 

                }
                catch
                {
                    txtUserName.Text = string.Empty;
                    txtUniRoll.Text = string.Empty;
                }

                if (Request.QueryString["ContentId"] != null)
                {
                    btnUpdate.Visible = true;
                    string ContentId = Request.QueryString["ContentId"].ToString();
                    hidContentId.Value = ContentId;
                    List<Transaction> trans = new List<Transaction>();
                    trans.Add(new Transaction { Key = "@ContentId", value = ContentId });
                    ds = Transaction.SqlSelTransaction("spGetFileContent", trans);
                    txtDocName.Text = ds.Tables[0].Rows[0]["ContentName"].ToString();
                    drpDocType.SelectedItem.Value = ds.Tables[0].Rows[0]["ContentType"].ToString();
                    txtDocDetails.Text = ds.Tables[0].Rows[0]["ContentDetails"].ToString();
                    string[] SelectedValuesArray = ds.Tables[0].Rows[0]["ShareWith"].ToString().Split(',');


                    foreach (string selectedValue in SelectedValuesArray)
                    {
                       
                      if(lstUser.Items.FindByValue(selectedValue) != null)
                        lstUser.Items.FindByValue(selectedValue).Selected = true;
                    }

                    


                }
                else
                {
                    btnUpdate.Visible = false;

                }
            }

        }

        protected void btnSubmit_Click1(object sender, EventArgs e)
        {

            MembershipUser u = Membership.GetUser(User.Identity.Name); 
            

            string ContentName = txtDocName.Text.Trim();
            string ContentType = drpDocType.SelectedValue.ToString();
            string ContentDetails = txtDocDetails.Text.Trim();
            string filename = Path.GetFileName(DocFileUpload.FileName);
            string UserId = Context.User.Identity.Name;
            string UploadDate = DateTime.Now.ToString("dd-MM-yyyy");
            var dir = @"D:\DCS-UploadedFile\" + UserId + "\\" + UploadDate;  // folder location

            string UserName = txtUserName.Text.Trim();
            string UniRoll = txtUniRoll.Text.Trim();
            string Dept = drpDept.SelectedItem.Value;

            string ShareWith = string.Empty;
            var selected = lstUser.GetSelectedIndices().ToList();
            var selectedValues = (from c in selected
                                  select lstUser.Items[c].Value).ToList();

            ShareWith = string.Join(",", Array.ConvertAll(selectedValues.ToArray(), x => x.ToString()));
            ShareWith += ShareWith + "," + Context.User.Identity.Name;

            if (!Directory.Exists(dir))  // if it doesn't exist, create
                Directory.CreateDirectory(dir);

            DocFileUpload.SaveAs(dir + "\\" + filename);

            try
            {
                ProfileBase curProfile = ProfileBase.Create(System.Web.Security.Membership.GetUser().UserName);
                curProfile.SetPropertyValue("FullName", UserName);
                curProfile.SetPropertyValue("UserDept", Dept);
                curProfile.SetPropertyValue("UserUniRoll", UniRoll);
                curProfile.Save();
            }
            catch
            {


            }

            
            

            List<Transaction> trans = new List<Transaction>();
            trans.Add(new Transaction { Key = "@ContentName", value = ContentName });
            trans.Add(new Transaction { Key = "@ContentType", value = ContentType });
            trans.Add(new Transaction { Key = "@ContentDetails", value = ContentDetails });
            trans.Add(new Transaction { Key = "@ContentPath", value = dir + "\\" + filename });
            trans.Add(new Transaction { Key = "@ShareWith", value = ShareWith });
            trans.Add(new Transaction { Key = "@UserId", value = UserId });

            //trans.Add(new Transaction { Key = "@UserGoodName", value = UserName });
            //trans.Add(new Transaction { Key = "@UserDept", value = Dept });
            //trans.Add(new Transaction { Key = "@UserUniRoll", value = UniRoll });
            bool response = Transaction.SqlInUpDelTransaction("spInsertUpdateFileContent", trans);
            if (response)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "err_msg", "alert('Data save Successfuly!');", true);
                Response.Redirect("UserDocList.aspx");
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "err_msg", "alert('Data not save!');", true);
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {


           

            string ContentId = hidContentId.Value;
            string ContentName = txtDocName.Text.Trim();
            string ContentType = drpDocType.SelectedValue.ToString();
            string ContentDetails = txtDocDetails.Text.Trim();
            string filename = Path.GetFileName(DocFileUpload.FileName);
            string UserId = Context.User.Identity.Name;
            string UploadDate = DateTime.Now.ToString("dd-MM-yyyy");
            var dir = @"D:\DCS-UploadedFile\" + UserId + "\\" + UploadDate;  // folder location

            string ShareWith = string.Empty;
            var selected = lstUser.GetSelectedIndices().ToList();
            var selectedValues = (from c in selected
                                  select lstUser.Items[c].Value).ToList();
            ShareWith = string.Join(",", Array.ConvertAll(selectedValues.ToArray(), x => x.ToString()));
            ShareWith += ShareWith + "," + Context.User.Identity.Name;

            string UserName = txtUserName.Text.Trim();
            string UniRoll = txtUniRoll.Text.Trim();
            string Dept = drpDept.SelectedItem.Value;
            

            if (!string.IsNullOrEmpty(filename))
            {
                if (!Directory.Exists(dir))  // if it doesn't exist, create
                    Directory.CreateDirectory(dir);

                DocFileUpload.SaveAs(dir + "\\" + filename);
            }


            

            List<Transaction> trans = new List<Transaction>();
            trans.Add(new Transaction { Key = "@ContentName", value = ContentName });
            trans.Add(new Transaction { Key = "@ContentType", value = ContentType });
            trans.Add(new Transaction { Key = "@ContentDetails", value = ContentDetails });
            if (!string.IsNullOrEmpty(filename))
            {
                trans.Add(new Transaction { Key = "@ContentPath", value = dir + "\\" + filename });
            }
            trans.Add(new Transaction { Key = "@UserId", value = UserId });
            trans.Add(new Transaction { Key = "@ContentId", value = ContentId });
            trans.Add(new Transaction { Key = "@ShareWith", value = ShareWith });

           

            //trans.Add(new Transaction { Key = "@UserGoodName", value = UserName });
            //trans.Add(new Transaction { Key = "@UserDept", value = Dept });
            //trans.Add(new Transaction { Key = "@UserUniRoll", value = UniRoll });
            bool response = Transaction.SqlInUpDelTransaction("spInsertUpdateFileContent", trans);
            
                if (ProfileManager.DeleteProfile(System.Web.Security.Membership.GetUser().UserName))
                {
                    ProfileBase curProfile = ProfileBase.Create(System.Web.Security.Membership.GetUser().UserName);
                    curProfile.SetPropertyValue("FullName", UserName);
                    curProfile.SetPropertyValue("UserDept", Dept);
                    curProfile.SetPropertyValue("UserUniRoll", UniRoll);
                    curProfile.Save();
                }

           

            if (response)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(),"err_msg","alert('Data update Successfuly!');",true);
                Response.Redirect("UserDocList.aspx");
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "err_msg", "alert('Data not update!');", true);
            }
        }
    }
}