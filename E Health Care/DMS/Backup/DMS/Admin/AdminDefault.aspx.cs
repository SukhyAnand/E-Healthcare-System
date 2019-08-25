using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

namespace DMS.Admin
{
    public partial class AdminDefault : System.Web.UI.Page
    {
       protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                DataSet dsGlobalList = Getdata();
                grdGlobalList.DataSource = dsGlobalList;
                grdGlobalList.DataBind();
            }
        }
        private DataSet Getdata()
        {
            List<Transaction> trans = new List<Transaction>();
            trans.Add(new Transaction { Key = "@UserId", value = Context.User.Identity.Name });
            DataSet ds = Transaction.SqlSelTransaction("spGetFileContent", trans);
            DataView dv = ds.Tables[0].DefaultView;
           
            ds.Tables.Clear();

            ds.Tables.Add(dv.Table);
            return ds;
        }

        protected void imgDel_Click(object sender, ImageClickEventArgs e)
        {
            string ContentId = ((ImageButton)sender).CommandArgument.ToString();
            List<Transaction> trans = new List<Transaction>();
            trans.Add(new Transaction { Key = "@ContentId", value = ContentId });
            bool res = Transaction.SqlInUpDelTransaction("spDelFileContent", trans);
            Response.Redirect(Request.RawUrl);
            
        }

        protected void imgDownload_Click(object sender, ImageClickEventArgs e)
        {
            string ContentId = ((ImageButton)sender).CommandArgument.ToString();
            List<Transaction> trans = new List<Transaction>();
            trans.Add(new Transaction { Key = "@ContentId", value = ContentId });
            DataSet ds = Transaction.SqlSelTransaction("spGetFileContent", trans);
            string ContentPath = ds.Tables[0].Rows[0]["ContentPath"].ToString();
            string ContentName = ds.Tables[0].Rows[0]["ContentName"].ToString();
            //WebClient webClient = new WebClient();
            //webClient.DownloadFile(ContentPath, @"d:\"+ContentName+".pdf");

            try
            {

                string path = (ContentPath); //get physical file path from server
                string name = Path.GetFileName(path); //get file name
                string ext = Path.GetExtension(path); //get file extension
                string type = "";

                // set known types based on file extension
                if (ext != null)
                {
                    switch (ext.ToLower())
                    {
                        case ".htm":
                        case ".html":
                            type = "text/HTML";
                            break;

                        case ".txt":
                            type = "text/plain";
                            break;

                        case ".GIF":
                            type = "image/GIF";
                            break;

                        case ".pdf":
                            type = "Application/pdf";
                            break;

                        case ".doc":
                        case ".rtf":
                            type = "Application/msword";
                            break;
                    }
                }

                Response.AppendHeader("content-disposition", "attachment; filename=" + ContentName + "." + ext);

                if (type != "")
                    Response.ContentType = type;
                Response.WriteFile(path);

                Response.End(); //give POP to user for file downlaod
            }
            catch (Exception ex)
            {
            }
        }
        protected void grdGlobalList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdGlobalList.PageIndex = e.NewPageIndex;
            DataSet ds = Getdata();
            grdGlobalList.DataSource = ds;
            grdGlobalList.DataBind();
        }
    }
}