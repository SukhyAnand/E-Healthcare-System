using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace DMS.User
{
    public partial class UserDocList : System.Web.UI.Page
    {
        string Sort_Direction = "UserId ASC";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["SortExpr"] = Sort_Direction;
                DataSet dsGlobalList = Getdata();
                grdUserList.DataSource = dsGlobalList;
                grdUserList.DataBind();
            }
        }

        protected void grdGlobalList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdUserList.PageIndex = e.NewPageIndex;
            DataSet ds = Getdata();
            grdUserList.DataSource = ds;
            grdUserList.DataBind();
        }
        private DataSet Getdata()
        {
            List<Transaction> trans = new List<Transaction>();
            trans.Add(new Transaction { Key = "@UserId", value = Context.User.Identity.Name });
            trans.Add(new Transaction { Key = "@ContentId", value = -1 });
            DataSet ds = Transaction.SqlSelTransaction("spGetFileContent", trans);
            DataView dv = ds.Tables[0].DefaultView;
            dv.Sort = ViewState["SortExpr"].ToString();
            ds.Tables.Clear();

            ds.Tables.Add(dv.Table);
            return ds;
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            string ContentId = ((ImageButton)sender).CommandArgument.ToString();
            Response.Redirect("UploadDoc.aspx?ContentId=" + ContentId);
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            string ContentId = ((ImageButton)sender).CommandArgument.ToString();
            List<Transaction> trans = new List<Transaction>();
            trans.Add(new Transaction { Key = "@ContentId", value = ContentId });
            bool res =  Transaction.SqlInUpDelTransaction("spDelFileContent", trans);
        }
    }
}