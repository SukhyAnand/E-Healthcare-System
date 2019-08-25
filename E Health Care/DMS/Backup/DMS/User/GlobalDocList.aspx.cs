using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

namespace DMS.User
{
    public partial class GlobalDocList : System.Web.UI.Page
    {
        string Sort_Direction = "UserId ASC";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["SortExpr"] = Sort_Direction;
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
            dv.Sort = ViewState["SortExpr"].ToString();
            ds.Tables.Clear();
            
            ds.Tables.Add(dv.Table);
            return ds;
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
        protected void imgView_Click(object sender, ImageClickEventArgs e)
        {
            string ContentId = ((ImageButton)sender).CommandArgument.ToString();
            List<Transaction> trans = new List<Transaction>();
            trans.Add(new Transaction { Key = "@ContentId", value = ContentId });
            DataSet ds = Transaction.SqlSelTransaction("spGetFileContent", trans);
            string ContentPath = ds.Tables[0].Rows[0]["ContentPath"].ToString();
            string ContentName = ds.Tables[0].Rows[0]["ContentName"].ToString();


            //System.IO.FileStream fs = new System.IO.FileStream(ContentPath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
            //byte[] ar = new byte[(int)fs.Length];
            //fs.Read(ar, 0, (int)fs.Length);
            //fs.Close();

            //Response.AddHeader("content-disposition", "attachment;filename=" + ContentName + ".pdf");
            //Response.ContentType = "application/octectstream";
            //Response.BinaryWrite(ar);
            //Response.End();
            string fileName = ContentName+".pdf";
            string filePath = ContentPath;
            Response.Clear();

            Response.AppendHeader("content-disposition", "attachment; filename=" + fileName);
            Response.ContentType = "application/force-download";
            Response.WriteFile(filePath);
            Response.Flush();
            Response.End();


           

            //register some javascript to open the new window
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenPDFScript", "window.open(\"ViewDoc.aspx?ContentId="+ContentId+"\");", true);
            //ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('ViewDoc.aspx?Param=" + ContentId + "','_blank');", true);
        }

        protected void grdGlobalList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdGlobalList.PageIndex = e.NewPageIndex;
            DataSet ds = Getdata();
            grdGlobalList.DataSource = ds;
            grdGlobalList.DataBind();
        }
        protected void Sorting(object sender, GridViewSortEventArgs e)
        {
            string[] SortOrder = ViewState["SortExpr"].ToString().Split(' ');
            if (SortOrder[0] == e.SortExpression)
            {
                if (SortOrder[1] == "ASC")
                {
                    ViewState["SortExpr"] = e.SortExpression + " " + "DESC";
                }
                else
                {
                    ViewState["SortExpr"] = e.SortExpression + " " + "ASC";
                }
            }
            else
            {
                ViewState["SortExpr"] = e.SortExpression + " " + "ASC";
            }
            grdGlobalList.DataSource = Getdata();
            grdGlobalList.DataBind();
        }
    }
}