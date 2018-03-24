using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using System.Data.SqlClient;
using System.Configuration;


using Microsoft.Reporting.WebForms;
using Microsoft.Reporting.Common;
using Microsoft.Reporting;
using System.Drawing;

public partial class pages_trading_process : System.Web.UI.Page
{
    public static db_connection dbRef = new db_connection();
    public SqlCommand performQuery(String query)
    {
        dbRef.open();

        SqlCommand cmd = new SqlCommand(query, dbRef.connection);
        return cmd;
    }
    protected void Page_Load(object sender, EventArgs e)
    {

        //check 
        if (!string.IsNullOrEmpty(Session["item_id"].ToString()))
        {
            int itemID = int.Parse(Session["item_id"].ToString());
            populateTradingDetails(getitem(itemID));
            populate_trading_table(itemID);
        }
    }
     protected void populateTradingDetails(item item)
    {//retrieve data from object and populate onto the screen
        id_lbl.Text = (item.id).ToString();
        pc_lbl.Text = item.ITEM;
        location_lbl.Text = getLocationName(item.location_id);
        venue_lbl.Text = item.venue;
        desc_lbl.Text = item.description;
        added_lbl.Text = DateTime.Parse(item.date).ToString("yyy-MM-dd") + " " + item.available;
        posted_by.Text = (item.added_by).ToString();
         type_lbl.Text = getTypeName(item.type);
        img.ImageUrl = @"~\images\"+item.img+"";
    }

    public  string getTypeName(char c)
    {
        string typeName;
        //check whether the item is good or service
        if (c == 's') {
            typeName = "Services";
        } else {
            typeName = "Goods";
        }
        
         return typeName;
    }

    public  string getLocationName(int locationID)
    {
        string locationName;
        string query = "SELECT name FROM location WHERE location_id=" + locationID + "";

        locationName = performQuery(query).ExecuteScalar().ToString();
        dbRef.close();
        return locationName;
    }

   

    public  void addTradingProcess(int itemID, int userID, string Date, char action, string content)
    {//the action is to be
        string query = "INSERT INTO item_user(item_id, user_id, date, action, content) VALUES (" + itemID + ", " + userID + ", '" + Date + "', '"+action+"', '"+content+"')";
        performQuery(query).ExecuteNonQuery();
        dbRef.close();
    }
    public  void soldItem(int itemID)
    {//
        string query = "UPDATE item_services SET status='s' WHERE item_id=" + itemID + "";
        performQuery(query).ExecuteNonQuery();
        dbRef.close();
    }



    //***pay
    protected void payBtn_Click(object sender, EventArgs e)
    {

        int itemID = int.Parse(Session["item_id"].ToString());
        int userID = int.Parse(Session["id"].ToString());

        string query = "SELECT * FROM item_services WHERE item_id=" + itemID + " ";
        SqlDataReader reader = performQuery(query).ExecuteReader();
        while (reader.Read())
        {
            Session["venue"] = reader["venue"].ToString();
            Session["item_name"] = reader["item_name"].ToString();
            Session["description"] = reader["description"].ToString();
            Session["seller_available_time"] = reader["available_time"].ToString();
            Session["belongs_to_whom"] = int.Parse(reader["added_by"].ToString());
            Session["unit_price"] = Double.Parse(reader["unit_price"].ToString());

        }
        dbRef.close();

        string date = DateTime.Now.ToString("yyy-MM-dd HH:mm:ss");
        
        string content = newTradingStep.Text;

        //t: to be continue
        addTradingProcess(itemID, userID, date, 't', content);

      
           
            System.Threading.Thread.Sleep(5000);
            msg.Text = "The deal is waiting to be processed...";

            Response.Redirect("../Customer/pay.aspx");
         
       

        Response.Redirect(Request.RawUrl);
    }
    //8888****

    protected void submutNewTradingBtn_Click(object sender, EventArgs e)
    { 
        
        int itemID = int.Parse(Session["item_id"].ToString());
        int userID = int.Parse(Session["id"].ToString());

        string query = "SELECT * FROM item_services WHERE item_id=" + itemID + " ";
         SqlDataReader reader = performQuery(query).ExecuteReader();
        while (reader.Read())
        {
            Session["venue"]=reader["venue"].ToString();
            Session["item_name"] = reader["item_name"].ToString();
            Session["description"] = reader["description"].ToString();
            Session["seller_available_time"] = reader["available_time"].ToString();
            Session["belongs_to_whom"] = int.Parse(reader["added_by"].ToString());
            Session["unit_price"] = Double.Parse(reader["unit_price"].ToString());
       
        }
        dbRef.close();

        string date = DateTime.Now.ToString("yyy-MM-dd HH:mm:ss");
      
        string content = newTradingStep.Text;
       
        
        addTradingProcess(itemID, userID, date, 't', content);

      
          msg.Text = "Thanks! The seller would repond soon...";

    }

    public  List<string> getTradingProcess(int itemID)
    {
        List<string> tradingList = new List<string>();
        /*
                c# - How can I loop through a List and grab each item? - Stack Overflow. 2016. c# - How can I loop through a List and grab each item? - Stack Overflow.
                * [ONLINE] Available at: http://stackoverflow.com/questions/18863187/how-can-i-loop-through-a-listt-and-grab-each-item. [Accessed 08 September 2017].
                */
        string query = "SELECT content, date, _user.user_name as user_id FROM item_user inner join _user on _user.user_id=item_user.user_id  WHERE item_user.item_id=" + itemID + "";
        
        SqlDataReader reader = performQuery(query).ExecuteReader();
         while (reader.Read())
        {
            string trading = reader["content"].ToString() + "," + reader["date"].ToString() + "," + reader["user_id"];
            tradingList.Add(trading);
        }

        dbRef.close();
            return tradingList;
    }

    protected void populate_trading_table(int item_id)
    {
        Table tradingTable = new Table();
        tradingTable.CssClass = "table table-bordered table-striped panel-success";
        tradingTable.BackColor = Color.DarkSalmon;
        tradingTable.BorderColor = Color.Chocolate;
        tradingTable.Height = 150;
        
        tradingTable.ForeColor = Color.DarkSlateBlue;
        TableHeaderRow thr = new TableHeaderRow();
        TableHeaderCell thc_tradingInfo = new TableHeaderCell(); thc_tradingInfo.Text = "Trade Info"; thr.Cells.Add(thc_tradingInfo);
        TableHeaderCell thc_date = new TableHeaderCell();thc_date.Text = "Date"; thr.Cells.Add(thc_date);
        TableHeaderCell thc_by = new TableHeaderCell(); thc_by.Text = "Person"; thr.Cells.Add(thc_by);

        tradingTable.Rows.Add(thr);
        /*
                c# - How can I loop through a List and grab each item? - Stack Overflow. 2016. c# - How can I loop through a List and grab each item? - Stack Overflow.
                * [ONLINE] Available at: http://stackoverflow.com/questions/18863187/how-can-i-loop-through-a-listt-and-grab-each-item. [Accessed 08 September 2017].
            
         * foreach (var item in myMoney)
    Console.WriteLine("amount is {0}, and type is {1}", item.amount, item.type);

for (int i = 0; i < myMoney.Count; i++)
         * 
         * for(int i = 0; i < getTradingProcess(item_id).Count; i++)
         * 
         */
        foreach (string trading in getTradingProcess(item_id))
        {
            TableRow newRow = new TableRow();
            TableCell tradeInfoCell = new TableCell();
            TableCell onDayCell = new TableCell();
            TableCell byWhomCell = new TableCell();
            
            string[] tradingInfo = trading.Split(',');

            tradeInfoCell.Text = tradingInfo[0];
            onDayCell.Text = tradingInfo[1];
            string tmp = tradingInfo[2];

            byWhomCell.Text =tmp;

            newRow.Cells.Add(tradeInfoCell);
            newRow.Cells.Add(onDayCell);
            newRow.Cells.Add(byWhomCell);

            tradingTable.Rows.Add(newRow);
        }

        trading_ph.Controls.Add(tradingTable);
    }

    public  string getUserName(int userID)
    {
        string userName;
       string query = "SELECT user_name FROM _user WHERE user_id=" + userID + "";
       userName = performQuery(query).ExecuteScalar().ToString();
            dbRef.close();
        return userName;
    }


    public  item getitem(int itemID)
    {
        item _item = new item();
       string query = "SELECT * FROM item_services WHERE item_id=" + itemID + "";
        SqlDataReader reader = performQuery(query).ExecuteReader();

        while (reader.Read())
        {
            _item.id = int.Parse(reader["item_id"].ToString());
            _item.venue = reader["venue"].ToString();
            _item.ITEM = reader["item_name"].ToString();
            _item.description = reader["description"].ToString();
            _item.location_id = int.Parse(reader["location_id"].ToString());
            _item.available = reader["available_time"].ToString();
            _item.date = reader["date"].ToString();
            _item.status = char.Parse(reader["status"].ToString());
            _item.type = char.Parse(reader["type"].ToString());
            _item.added_by = int.Parse(reader["added_by"].ToString());
            _item.unit_price = float.Parse(reader["unit_price"].ToString());
            _item.img = reader["img"].ToString();
        }

        dbRef.close();
            return _item;
    }


    protected void backBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("Services.aspx");
    }
    protected void TradingBtn_Click(object sender, EventArgs e)
    {

    }
}