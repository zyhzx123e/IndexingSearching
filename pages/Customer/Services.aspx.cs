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

public partial class pages_services : System.Web.UI.Page
{

    public static db_connection dbRef = new db_connection();
    public SqlCommand performQuery(String query)
    {
        dbRef.open();
        SqlCommand cmd = new SqlCommand(query, dbRef.connection);
        return cmd;
    }



     protected override void OnInit(EventArgs e)
    { 
        base.OnInit(e);
        populate_items();

        if (Session["id"] != null)
        {
            int user_id = int.Parse(Session["id"].ToString());
        }
		
        if (!IsPostBack)
        {
            populate_items();
            populateCurrentLocationsList();
         
        }
        else
        {
            
            try
            {
                string test = Session["chosenServiceLocation"].ToString();
                populate_itemlems(test);
            }
            catch (Exception ex)
            {
                
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
       

    }

    protected void populateCurrentLocationsList()
    {
       
        string query = "SELECT * FROM location";
        SqlDataReader reader = performQuery(query).ExecuteReader();

        location_list.DataSource = reader;
        location_list.DataTextField = "name";
        /*Mudassar Ahmed Khan. 2016. Bind (Populate) ASP.Net DropDownList using DataTable (DataSet) in C# and VB.Net. 
         * [ONLINE] Available at: http://www.aspsnippets.com/Articles/Bind-Populate-ASPNet-DropDownList-using-DataTable-DataSet-in-C-and-VBNet.aspx.
         * [Accessed 09 September 2017].*/
        location_list.DataValueField = "location_id";
        location_list.DataBind();
        location_list.Items.Insert(0, new ListItem("Select a Location around you to start your trade! ", "Null"));
        reader.Close();

        dbRef.close();
    }

   
    protected void location_list_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        string selected_location = location_list.SelectedIndex.ToString();
        Session["chosenServiceLocation"] = selected_location;
        msg.Text = "";

        if (location_list.SelectedIndex == 0)
        {
            msg.Text = "Please select a location .";
        }
        else
        {
            string test = location_list.SelectedValue.ToString();
            populate_itemlems(test);
        }
    }


    protected void populate_items(object sender, EventArgs e)
    {
        if (Session["chosenServiceLocation"] != null)
        {
            string test = Session["chosenServiceLocation"].ToString();
            populate_itemlems(test);
        }
    }


    protected void populate_items()
    {
        if ( location_list.SelectedIndex <1 )
        {

            Table itemTable = new Table();  itemTable.CssClass = "table table-bordered table-hover table-striped table-responsive";

            TableHeaderRow thr = new TableHeaderRow();
            TableHeaderCell thc_image = new TableHeaderCell(); thc_image.Text = "Image";  thr.Cells.Add(thc_image);
            TableHeaderCell thc_name = new TableHeaderCell(); thc_name.Text = "Name"; thr.Cells.Add(thc_name);
       
            TableHeaderCell thc_venue = new TableHeaderCell(); thc_venue.Text = "venue";  thr.Cells.Add(thc_venue);
            TableHeaderCell thc_price = new TableHeaderCell(); thc_price.Text = "Price";  thr.Cells.Add(thc_price);
            TableHeaderCell thc_item = new TableHeaderCell();  thc_item.Text = "item"; thr.Cells.Add(thc_item);
            TableHeaderCell thc_desc = new TableHeaderCell(); thc_desc.Text = "Description";  thr.Cells.Add(thc_desc);
            TableHeaderCell thc_time = new TableHeaderCell(); thc_time.Text = "available time"; thr.Cells.Add(thc_time);
            TableHeaderCell thc_date = new TableHeaderCell(); thc_date.Text = "Date";  thr.Cells.Add(thc_date);
            TableHeaderCell thc_addedby = new TableHeaderCell(); thc_addedby.Text = "posted by"; thr.Cells.Add(thc_addedby);

            /*
             How to: Add Rows and Cells Dynamically to a Table Web Server Control. 2016.
             * How to: Add Rows and Cells Dynamically to a Table Web Server Control. 
             * [ONLINE] Available at: https://msdn.microsoft.com/en-us/library/7bewx260.aspx. [Accessed 18 September 2017].
             */
            TableHeaderCell thc_trading = new TableHeaderCell(); thc_trading.Text = "search";thr.Cells.Add(thc_trading);
             itemTable.Rows.Add(thr);

            foreach (item item in getitems('s'))
            {
                TableRow newRow = new TableRow();
                TableCell imgCell = new TableCell();
                imgCell.Text = string.Format("<img src='/images/" + item.img + "' class='center-block' runat='server' Height='120px' Width='150px'/>");  newRow.Cells.Add(imgCell);

                TableCell nameCell = new TableCell(); nameCell.Text = item.venue; newRow.Cells.Add(nameCell);
               
                TableCell venueCell = new TableCell(); venueCell.Text = item.venue;   newRow.Cells.Add(venueCell);
               
                
                TableCell priceCell = new TableCell(); priceCell.Text = (item.unit_price).ToString(); newRow.Cells.Add(priceCell);
                TableCell itemCell = new TableCell();itemCell.Text = item.ITEM; newRow.Cells.Add(itemCell);
                TableCell descCell = new TableCell();  descCell.Text = item.description; newRow.Cells.Add(descCell);
                TableCell timeCell = new TableCell(); timeCell.Text = item.available;newRow.Cells.Add(timeCell);
                TableCell dateCell = new TableCell(); dateCell.Text = item.date; newRow.Cells.Add(dateCell);
                TableCell addedBy = new TableCell(); addedBy.Text = (item.posted_by).ToString(); newRow.Cells.Add(addedBy);
              
                TableCell tradingBtnCell = new TableCell();

               
                Button tradingBtn = new Button();
                tradingBtn.ID = item.id.ToString();//****key to transfer item item later in to next page
                tradingBtn.Width = 100;
                tradingBtn.Height = 150;

                tradingBtn.BackColor = Color.Orange;
                tradingBtn.ForeColor = Color.MintCream;
                tradingBtn.Text = "Search";
                tradingBtn.CssClass = "btn-sm btn-warning";
                tradingBtnCell.Controls.Add(tradingBtn);

                tradingBtn.Click += new EventHandler(this.trade_Btn_Click);
              
                if (Session["id"] != null)
                {

                    newRow.Cells.Add(tradingBtnCell);
                }
                else
                {

                    thc_trading.Visible = false;
                }
               
               
                itemTable.Rows.Add(newRow);
            }
            services_ph.Controls.Clear();
            services_ph.Controls.Add(itemTable);

        }
        else
        {
            string test = location_list.SelectedIndex.ToString();
           
            populate_itemlems(test);
        }
    }


    protected void populate_itemlems(string location_id)
    {
        Table itemTable = new Table(); itemTable.CssClass = "table table-bordered table-hover table-striped table-responsive";

        TableHeaderRow thr = new TableHeaderRow();

        TableHeaderCell thc_image = new TableHeaderCell(); thc_image.Text = "Image"; thr.Cells.Add(thc_image);

        TableHeaderCell thc_name = new TableHeaderCell(); thc_name.Text = "Name"; thr.Cells.Add(thc_name);
       
        TableHeaderCell thc_venue = new TableHeaderCell();thc_venue.Text = "venue"; thr.Cells.Add(thc_venue);
        TableHeaderCell thc_price = new TableHeaderCell();thc_price.Text = "Price";thr.Cells.Add(thc_price);
        TableHeaderCell thc_item = new TableHeaderCell();thc_item.Text = "item"; thr.Cells.Add(thc_item);
        TableHeaderCell thc_desc = new TableHeaderCell();thc_desc.Text = "Description"; thr.Cells.Add(thc_desc);
        TableHeaderCell thc_time = new TableHeaderCell(); thc_time.Text = "available time"; thr.Cells.Add(thc_time);
        TableHeaderCell thc_date = new TableHeaderCell(); thc_date.Text = "Date";thr.Cells.Add(thc_date);
        TableHeaderCell thc_addedby = new TableHeaderCell(); thc_addedby.Text = "Posted by"; thr.Cells.Add(thc_addedby);
        
        TableHeaderCell thc_trading = new TableHeaderCell(); thc_trading.Text = "search"; thr.Cells.Add(thc_trading);
        itemTable.Rows.Add(thr);

        int locationID = int.Parse(location_id);
        /*. Looping through a LIST with for and foreach in C# - Forget Code. 20
       * [ONLINE] Available at: http://forgetcode.com/CSharp/1188-Looping-through-a-LIST-with-for-and-foreach. [Accessed 11 September 2017].*/

        foreach (item item in getitems(locationID, 's'))
        {
            TableRow newRow = new TableRow();
            TableCell imgCell = new TableCell(); 
            imgCell.Text = string.Format("<img src='/images/" + item.img + "' class='center-block' runat='server' Height='120px' Width='150px'/>");
            newRow.Cells.Add(imgCell);

            TableCell nameCell = new TableCell(); nameCell.Text = item.ITEM; newRow.Cells.Add(nameCell);
           
            TableCell venueCell = new TableCell();  venueCell.Text = item.venue;   newRow.Cells.Add(venueCell);
            TableCell priceCell = new TableCell(); priceCell.Text = (item.unit_price).ToString();  newRow.Cells.Add(priceCell);
            TableCell serviceCell = new TableCell(); serviceCell.Text = item.ITEM;  newRow.Cells.Add(serviceCell);
            TableCell descCell = new TableCell(); descCell.Text = item.description;  newRow.Cells.Add(descCell);
            TableCell timeCell = new TableCell();     timeCell.Text = item.available;  newRow.Cells.Add(timeCell);
            TableCell addedBy = new TableCell(); addedBy.Text = (item.posted_by).ToString(); newRow.Cells.Add(addedBy);
              
            TableCell dateCell = new TableCell();   dateCell.Text = item.date;   newRow.Cells.Add(dateCell);
            TableCell tradingBtnCell = new TableCell();

            /*C# Dynamic Table
             * 
             How to: Add Rows and Cells Dynamically to a Table Web Server Control. 2016.
             * How to: Add Rows and Cells Dynamically to a Table Web Server Control. 
             * [ONLINE] Available at: https://msdn.microsoft.com/en-us/library/7bewx260.aspx. [Accessed 18 September 2017].
             */

            Button tradingBtn = new Button();
  tradingBtn.ID = item.id.ToString();
  tradingBtn.Width = 100;
  tradingBtn.Height = 150;

  tradingBtn.BackColor = Color.Orange;
  tradingBtn.ForeColor = Color.MintCream;

            tradingBtn.Text = "Search";
            tradingBtn.CssClass = "btn-sm btn-warning";
            tradingBtnCell.Controls.Add(tradingBtn);
            tradingBtn.Click += new EventHandler(this.trade_Btn_Click);
            /*Directly use eventHandler for button click and run the  onBtnClick function
           * 
           How to: Add an Event Handler Using Code. 2016. How to: Add an Event Handler Using Code. 
           * [ONLINE] Available at: https://msdn.microsoft.com/en-us/library/ms743596(v=vs.110).aspx. 
           * [Accessed 21 September 2017].
           */
            if (Session["id"] != null)
            {

                newRow.Cells.Add(tradingBtnCell);
            }
            else
            {

                thc_trading.Visible = false;
            }
               
               
            itemTable.Rows.Add(newRow);

        } services_ph.Controls.Clear();
        services_ph.Controls.Add(itemTable);
    }

    protected void trade_Btn_Click(object sender, EventArgs e)
    {
        Button search_btn = sender as Button;
        Session["item_id"] = search_btn.ID;
        Session["chosenServiceLocation"] = null;
        Response.Redirect("selling_followup.aspx"); 
    }

    protected void add_new_itemlem_Click(object sender, EventArgs e)
    {

    }





    public List<item> getitems(char type)
    {
        List<item> itemsList = new List<item>();
        /*. Looping through a LIST with for and foreach in C# - Forget Code. 20
         * [ONLINE] Available at: http://forgetcode.com/CSharp/1188-Looping-through-a-LIST-with-for-and-foreach. [Accessed 11 September 2017].*/

        string query = "SELECT item_id,venue,item_name,description,location_id,available_time,date,status,type,_user.user_name as 'posted_by' ,unit_price,img FROM item_services inner join _user on _user.user_id=item_services.added_by WHERE type='" + type + "' AND status = 'p'";
        try {
            SqlDataReader reader = performQuery(query).ExecuteReader();
            while (reader.Read())
            {
                item item = new item();
                item.id = int.Parse(reader["item_id"].ToString());
                item.venue = reader["venue"].ToString();
                item.ITEM = reader["item_name"].ToString();
                item.description = reader["description"].ToString();
                item.location_id = int.Parse(reader["location_id"].ToString());
                item.available = reader["available_time"].ToString();
                item.date = reader["date"].ToString();
                item.status = char.Parse(reader["status"].ToString());
                item.type = char.Parse(reader["type"].ToString());
                item.posted_by = reader["posted_by"].ToString();
                item.img = reader["img"].ToString();
                item.unit_price = float.Parse(reader["unit_price"].ToString());
                /*
                c# - Implementation of OOP for retrieving list of objects from database - Code Review Stack Exchange. 
                * . c# - Implementation of OOP for retrieving list of objects from database - Code Review Stack Exchange. [ONLINE] Available at: http://codereview.stackexchange.com/questions/33810/implementation-of-oop-for-retrieving-list-of-objects-from-database. 
                * [Accessed 08 September 2017].
                */
                itemsList.Add(item);
            }
            reader.Close();
            dbRef.close();
  
        
        }catch(Exception e){}

      
        return itemsList;
    }

    public List<item> getitems(int locationID, char type)
    {
        List<item> itemsList = new List<item>();
        /*. Looping through a LIST with for and foreach in C# - Forget Code. 20
       * [ONLINE] Available at: http://forgetcode.com/CSharp/1188-Looping-through-a-LIST-with-for-and-foreach. [Accessed 11 September 2017].*/

        string query = "SELECT item_id,venue,item_name,description,location_id,available_time,date,status,type,_user.user_name as 'posted_by',unit_price,img FROM item_services inner join _user on _user.user_id=item_services.added_by WHERE location_id=" + locationID + " AND type='" + type + "' AND status = 'p'";
        SqlDataReader reader = performQuery(query).ExecuteReader();
        while (reader.Read())
        {
            item item = new item();
            item.id = int.Parse(reader["item_id"].ToString());
            item.venue = reader["venue"].ToString();
            item.ITEM = reader["item_name"].ToString();
            item.description = reader["description"].ToString();
            item.location_id = int.Parse(reader["location_id"].ToString());
            item.available = reader["available_time"].ToString();
            item.date = reader["date"].ToString();
            item.status = char.Parse(reader["status"].ToString());
            item.type = char.Parse(reader["type"].ToString());
            item.posted_by = reader["posted_by"].ToString();
            item.img = reader["img"].ToString();
            item.unit_price = float.Parse(reader["unit_price"].ToString());

            itemsList.Add(item);
        }
        /*
            c# - Implementation of OOP for retrieving list of objects from database - Code Review Stack Exchange. 
            * . c# - Implementation of OOP for retrieving list of objects from database - Code Review Stack Exchange. [ONLINE] Available at: http://codereview.stackexchange.com/questions/33810/implementation-of-oop-for-retrieving-list-of-objects-from-database. 
            * [Accessed 08 September 2017].
            */
        dbRef.close();

        return itemsList;
    }


    

   
    protected void add_new_itemlem_Command(object sender, CommandEventArgs e)
    {

    }
   

    protected void add_new_service_Click(object sender, EventArgs e)
    {
        Response.Redirect("servicePost.aspx"); 

    }
}

