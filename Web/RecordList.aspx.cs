using NLog;
using PetShop.DBUtility;
using PetShop.Model;
using PetShop.Web;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RecordList : System.Web.UI.Page
{
    private PetShop.BLL.Order gOrder = new PetShop.BLL.Order(); // create order

    protected void Page_Load(object sender, EventArgs e)
    {
        RenderList();
    }

    protected void gvRecord_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {   //gridView分頁用
        gvRecord.PageIndex = e.NewPageIndex;
        gvRecord.DataBind();
    }

    protected void gvRecord_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int orderId = (int)gvRecord.DataKeys[e.RowIndex].Value;
        //刪除資料
        gOrder.Delete(orderId);
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        RenderList();
    }

    private void RenderList()
    {
        //讀取個人紀錄
        string userId = Membership.GetUser().UserName.ToString();

        //讀取紀錄清單
        IList<OrderInfo> orderList = gOrder.GetOrderByUserId(userId);

        //欄位自動換行
        gvRecord.Attributes.Add("style", "word-break:break-all;word-wrap:break-word");

        //繫結data
        gvRecord.DataSource = orderList;
        gvRecord.DataBind();
    }
}