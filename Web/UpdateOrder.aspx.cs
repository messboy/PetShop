using PetShop.Model;
using PetShop.Web;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UpdateOrder : System.Web.UI.Page
{
    private int id { get; set; }
    private PetShop.BLL.Order gOrder = new PetShop.BLL.Order(); // create order

    protected void Page_Load(object sender, EventArgs e)
    {
        //取得get QueryString參數
        NameValueCollection collection = HttpUtility.ParseQueryString(Request.Url.Query);
        id = int.Parse(collection.Get("OrderId"));


        if (!IsPostBack)
        {
            //讀取資料
            OrderInfo order = gOrder.GetOrder(id);

            //資料繫結bill ship
            BillingAddressForm.Address = order.BillingAddress;
            ShippingAddressForm.Address = order.ShippingAddress;
        }
        
    }


    protected void SqlDataSource2_Updated(object sender, SqlDataSourceStatusEventArgs e)
    {
        //更新完成後導回紀錄清單
        Response.Redirect("~/RecordList.aspx");
    }
    protected void update_Click(object sender, EventArgs e)
    {
        OrderInfo order = new OrderInfo();
        //存放資料
        order.BillingAddress = BillingAddressForm.Address;
        order.ShippingAddress = ShippingAddressForm.Address;
        order.OrderId = id;
        //更新資料
        gOrder.Update(order);

        //導回列表
        Response.Redirect("~/RecordList.aspx");

    }
}