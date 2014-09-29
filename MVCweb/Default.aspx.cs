using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MVCweb
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Redirect to Search page
        /// </summary>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            WebUtility.SearchRedirect(txtSearch.Text);
        }
    }
}