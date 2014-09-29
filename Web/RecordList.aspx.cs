using NLog;
using PetShop.DBUtility;
using PetShop.Model;
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
        private const string SQL_SELECT_ORDER = @"SELECT DISTINCT o.OrderId, o.OrderDate, o.UserId,  o.BillToFirstName, 
    o.BillToLastName, o.BillAddr1, o.BillAddr2, 
    o.BillCity, o.BillState, BillZip, o.BillCountry, 
    o.ShipToFirstName, o.ShipToLastName, o.ShipAddr1, 
    o.ShipAddr2, o.ShipCity, o.ShipState, o.ShipZip, 
    o.ShipCountry, o.TotalPrice
    FROM Orders as o
    WHERE o.UserId = @UserId ";

        Logger logger = LogManager.GetCurrentClassLogger();

    protected void Page_Load(object sender, EventArgs e)
    {
        //
        
        //讀取個人紀錄

        IList<OrderInfo> orderList = new List<OrderInfo>();

        //Create a parameter
        MembershipUser user = Membership.GetUser();
        SqlParameter parm = new SqlParameter("@UserId", SqlDbType.VarChar);
        parm.Value = user.UserName.ToString();

        //Execute a query to read the categories
        try
        {
            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringOrderDistributedTransaction, CommandType.Text, SQL_SELECT_ORDER, parm))
            {
                while (rdr.Read())
                {
                    //Generate an order header from the first row
                    AddressInfo billingAddress = new AddressInfo(null, null, rdr.GetString(5), null, null, null, null, null, null, "email");
                    AddressInfo shippingAddress = new AddressInfo(null, null, rdr.GetString(13), null, null, null, null, null, null, "email");

                    OrderInfo cat = new OrderInfo(rdr.GetInt32(0), rdr.GetDateTime(1), rdr.GetString(2), null, billingAddress, shippingAddress, rdr.GetDecimal(19), null, null);
                    orderList.Add(cat);
                }
            }  

        }
        catch (Exception)
        {
            
            throw;
        }

        //欄位自動換行
        gvRecord.Attributes.Add("style", "word-break:break-all;word-wrap:break-word");

        //繫結data
        gvRecord.DataSource = orderList;
        gvRecord.DataBind();

    }

    protected void gvRecord_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {   //gridView分頁用
        gvRecord.PageIndex = e.NewPageIndex;
        gvRecord.DataBind();
    }

    protected void gvRecord_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int orderId = (int)gvRecord.DataKeys[e.RowIndex].Value;

        string str1 = @"DELETE LineItem where OrderId = @OrderId;"; // SQL command 1
 
        string str2 = @"DELETE OrderStatus where OrderId = @OrderId;"; // SQL command 2
 
        string str3 = @"DELETE Orders where OrderId = @OrderId;"; // SQL command 3
 
 
        SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringOrderDistributedTransaction);
        SqlCommand delCommand = new SqlCommand(str1, conn);
        SqlParameter param = new SqlParameter("@OrderId", orderId);
        delCommand.Parameters.Add(param);
 
        conn.Open();
        SqlTransaction trans = conn.BeginTransaction();
        delCommand.Transaction = trans;
 
        try
        {
            delCommand.ExecuteNonQuery();
            delCommand.CommandText = str2;
            delCommand.CommandType = CommandType.Text;
            delCommand.ExecuteNonQuery();
            delCommand.CommandText = str3;
            delCommand.CommandType = CommandType.Text;
            delCommand.ExecuteNonQuery();
 
            trans.Commit();
        } // try
        catch (Exception excep)
        {
            trans.Rollback();  // 出現例外就ROLLBACK
            logger.Debug(excep.Message);
        } // catch
        finally
        {
            conn.Close();
            delCommand.Dispose();
            conn.Dispose();
            trans.Dispose();
        } // finally

    }
}