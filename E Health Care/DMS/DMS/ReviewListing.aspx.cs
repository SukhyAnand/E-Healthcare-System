using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DMS
{
    public partial class ReviewListing : System.Web.UI.Page
    {
        Transaction tran = new Transaction();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                gvReviewList.DataSource = tran.GetAllReview();
                gvReviewList.DataBind();

            }

        }
    }
}