using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UpdateOrder : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //string categoryId = Request.QueryString["categoryId"];
        //if (!string.IsNullOrEmpty(categoryId))
        //{
        //    //更新資料

        //}
    }

    protected void SqlDataSource1_Updated(object sender, SqlDataSourceStatusEventArgs e)
    {
        Response.Redirect("~/RecordList.aspx");
    }
    protected void SqlDataSource2_Updated(object sender, SqlDataSourceStatusEventArgs e)
    {
        Response.Redirect("~/RecordList.aspx");
    }
}