using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace DMS.User
{
    public partial class ViewDoc : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["ContentId"] != null)
                {
                    string ContentId = Request.QueryString["ContentId"].ToString();
                    List<Transaction> trans = new List<Transaction>();
                    trans.Add(new Transaction { Key = "@ContentId", value = ContentId });
                    DataSet ds = Transaction.SqlSelTransaction("spGetFileContent", trans);
                    string ContentPath = ds.Tables[0].Rows[0]["ContentPath"].ToString();
                    string ContentName = ds.Tables[0].Rows[0]["ContentName"].ToString();
                    string src = "http://docs.google.com/gview?url=" + ContentPath + "&embedded=true";
                    ViewFrame.Attributes.Add("src", ContentPath);
                }
            }

        }
    }
}