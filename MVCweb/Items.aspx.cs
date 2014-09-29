using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MVCweb
{
    public partial class Items : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //get page header and title
            Page.Title = WebUtility.GetProductName(Request.QueryString["productId"]);
        }
    }
}