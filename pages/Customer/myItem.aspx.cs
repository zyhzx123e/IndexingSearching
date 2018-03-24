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

public partial class goods : System.Web.UI.Page
{
    public  db_connection dbRef = new db_connection();
    public SqlCommand performQuery(String query)
    {
        dbRef.open();
        SqlCommand cmd = new SqlCommand(query, dbRef.connection);
        return cmd;
    }
     protected override void OnInit(EventArgs e)
    {/*
      * 
      Init is a good place to add dynamic controls to the page or user control 
      * If can, then those controls will have their ViewState restored automatically during postbacks 
      * 
      */
        //b4 page load
        base.OnInit(e);
        populate_goods();
        if (Session["id"] != null)
        {

            int user_id = int.Parse(Session["id"].ToString());
        }
		
        if (!IsPostBack)
        {
           
            populate_goods();
        }
        
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
   

   
  



    protected void populate_goods()
    {
      
            //c# dynamic table populate base on database Goods data

            Table itemTable = new Table();
            TableHeaderRow thr = new TableHeaderRow();
            itemTable.CssClass = "table table-bordered table-hover table-striped table-responsive thead-inverse";
             TableHeaderCell imgHeader = new TableHeaderCell();imgHeader.Text = "Image";thr.Cells.Add(imgHeader);

             TableHeaderCell thc_name = new TableHeaderCell(); thc_name.Text = "Name"; thr.Cells.Add(thc_name);
           
            TableHeaderCell thc_venue = new TableHeaderCell();thc_venue.Text = "Venue"; thr.Cells.Add(thc_venue);
            TableHeaderCell thc_price = new TableHeaderCell();thc_price.Text = "Price";thr.Cells.Add(thc_price);
            TableHeaderCell thc_desc = new TableHeaderCell(); thc_desc.Text = "Description"; thr.Cells.Add(thc_desc);
            TableHeaderCell thc_time = new TableHeaderCell();thc_time.Text = "Available"; thr.Cells.Add(thc_time);
            TableHeaderCell thc_date = new TableHeaderCell();thc_date.Text = "Date"; thr.Cells.Add(thc_date);
            TableHeaderCell thc_addedby = new TableHeaderCell(); thc_addedby.Text = "Posted by"; thr.Cells.Add(thc_addedby);
        
            TableHeaderCell thc_search = new TableHeaderCell();thc_search.Text = "Trade This"; thr.Cells.Add(thc_search);
            
            itemTable.Rows.Add(thr);

            /*
             How to: Add Rows and Cells Dynamically to a Table Web Server Control. 2016.
             * How to: Add Rows and Cells Dynamically to a Table Web Server Control. 
             * [ONLINE] Available at: https://msdn.microsoft.com/en-us/library/7bewx260.aspx. [Accessed 18 September 2017].
             */
            //get items from list<>  and loop through each item in items<> list
            foreach (item item in getitems())//return the object item and the obj item has all the attributes need to populate into table
            {   TableRow newRow = new TableRow();
                TableCell imgCell = new TableCell(); imgCell.Text = string.Format("<img src='/images/" + item.img + "' class='center-block' runat='server' Height='120px' Width='150px'/>");  newRow.Cells.Add(imgCell);
                /*
                 c# - How can I loop through a List and grab each item? - Stack Overflow. 2016. c# - How can I loop through a List and grab each item? - Stack Overflow.
                 * [ONLINE] Available at: http://stackoverflow.com/questions/18863187/how-can-i-loop-through-a-listt-and-grab-each-item. [Accessed 08 September 2017].
                 */
                TableCell nameCell = new TableCell(); nameCell.Text = item.ITEM; newRow.Cells.Add(nameCell);
           
                TableCell venueCell = new TableCell(); venueCell.Text = item.venue;  newRow.Cells.Add(venueCell);
                TableCell priceCell = new TableCell(); priceCell.Text = (item.unit_price).ToString(); newRow.Cells.Add(priceCell);
                TableCell descCell = new TableCell(); descCell.Text = item.description; newRow.Cells.Add(descCell);
                TableCell timeCell = new TableCell(); timeCell.Text = item.available; newRow.Cells.Add(timeCell);
           
                TableCell dateCell = new TableCell();dateCell.Text = item.date;     newRow.Cells.Add(dateCell);
                TableCell addedBy = new TableCell(); addedBy.Text = (item.posted_by).ToString(); newRow.Cells.Add(addedBy);
                TableCell itemBtnCell = new TableCell();
           
                Button itemBtn = new Button();
                itemBtn.Width = 100;
                itemBtn.Height = 100;
                
                itemBtn.BackColor = Color.Green;
                itemBtn.ForeColor = Color.Red;
                itemBtn.ID = item.id.ToString();
                itemBtn.Text = "Manage";
                itemBtn.CssClass = "btn-sm btn-success";
                itemBtnCell.Controls.Add(itemBtn);

                itemBtn.Click += new EventHandler(this.itemBtn_Click);
              
              
                if (Session["id"] != null)
                {
                    newRow.Cells.Add(itemBtnCell);
                }
                else {
                    thc_search.Visible = false;

                }
              
                //newRow.Cells.Add(imgCell);

                itemTable.Rows.Add(newRow);
            }
            
           
            good_ph.Controls.Add(itemTable);


      
    }


    public  List<item> getitems()
    {
        List<item> itemsList = new List<item>();
        //loop through list and populate data
        /*
                c# - How can I loop through a List and grab each item? - Stack Overflow. 2016. c# - How can I loop through a List and grab each item? - Stack Overflow.
                * [ONLINE] Available at: http://stackoverflow.com/questions/18863187/how-can-i-loop-through-a-listt-and-grab-each-item. [Accessed 08 September 2017].
                */
        if (Session["id"] != null)
        {
            string current_user_id = Session["id"].ToString();
       
        int int_user_id=Int16.Parse(current_user_id);
        string query = "SELECT item_id,venue,item_name,description,location_id,available_time,date,status,type,_user.user_name as posted_by,unit_price,img FROM item_services inner join _user on _user.user_id=item_services.added_by  WHERE item_services.added_by=" + int_user_id + "";
       

        SqlDataReader reader = performQuery(query).ExecuteReader();
        while (reader.Read())
        {
            item item = new item();
          
            item.id = int.Parse(reader["item_id"].ToString()); item.venue = reader["venue"].ToString();
            item.ITEM = reader["item_name"].ToString();item.description = reader["description"].ToString();
            item.location_id = int.Parse(reader["location_id"].ToString()); item.available = reader["available_time"].ToString();
            item.date = reader["date"].ToString(); item.status = char.Parse(reader["status"].ToString());
            item.type = char.Parse(reader["type"].ToString()); item.posted_by = reader["posted_by"].ToString();
            item.img = reader["img"].ToString();item.unit_price = float.Parse(reader["unit_price"].ToString());
            /*
             c# - Implementation of OOP for retrieving list of objects from database - Code Review Stack Exchange. 
             * . c# - Implementation of OOP for retrieving list of objects from database - Code Review Stack Exchange. [ONLINE] Available at: http://codereview.stackexchange.com/questions/33810/implementation-of-oop-for-retrieving-list-of-objects-from-database. 
             * [Accessed 08 September 2017].
             */
            itemsList.Add(item);
        }
        dbRef.close();
 }
        return itemsList;
    }

    public  List<item> getitems(int locationID, char type)
    {
        List<item> itemsList = new List<item>();
        /*
                c# - How can I loop through a List and grab each item? - Stack Overflow. 2016. c# - How can I loop through a List and grab each item? - Stack Overflow.
                * [ONLINE] Available at: http://stackoverflow.com/questions/18863187/how-can-i-loop-through-a-listt-and-grab-each-item. [Accessed 08 September 2017].
                */
        string current_user_id = Session["id"].ToString();
        int int_user_id = Int16.Parse(current_user_id);
        string query = "SELECT item_id,venue,item_name,description,location_id,available_time,date,status,type,_user.user_name as posted_by,unit_price,img FROM item_services inner join _user on _user.user_id=item_services.added_by  WHERE item_services.added_by=" + int_user_id + "";
       

        SqlDataReader reader = performQuery(query).ExecuteReader();
        while (reader.Read())
        {
            item item = new item();item.id = int.Parse(reader["item_id"].ToString());
            item.venue = reader["venue"].ToString();item.ITEM = reader["item_name"].ToString();
            item.description = reader["description"].ToString();item.location_id = int.Parse(reader["location_id"].ToString());
            item.available = reader["available_time"].ToString();item.date = reader["date"].ToString();
            item.status = char.Parse(reader["status"].ToString()); item.type = char.Parse(reader["type"].ToString());
            item.posted_by = reader["posted_by"].ToString(); item.img = reader["img"].ToString();  item.unit_price = float.Parse(reader["unit_price"].ToString());

            itemsList.Add(item);
            /*
            c# - Implementation of OOP for retrieving list of objects from database - Code Review Stack Exchange. 
            * . c# - Implementation of OOP for retrieving list of objects from database - Code Review Stack Exchange. [ONLINE] Available at: http://codereview.stackexchange.com/questions/33810/implementation-of-oop-for-retrieving-list-of-objects-from-database. 
            * [Accessed 08 September 2017].
            */
        }
        dbRef.close();
        /*
                c# - How can I loop through a List and grab each item? - Stack Overflow. 2016. c# - How can I loop through a List and grab each item? - Stack Overflow.
                * [ONLINE] Available at: http://stackoverflow.com/questions/18863187/how-can-i-loop-through-a-listt-and-grab-each-item. [Accessed 08 September 2017].
                */
        return itemsList;
    }



    protected void populate_goods(object sender, EventArgs e)
    {
        populate_goods();

    }


    protected void itemBtn_Click(object sender, EventArgs e)
    {
        Button itemBtn = sender as Button;
        Session["item_id"] = itemBtn.ID;
        Response.Redirect("manageMyItem.aspx");
    }

    protected void add_new_good_Click(object sender, EventArgs e)
    {

    }

  





	
    protected void add_new_good_Click1(object sender, EventArgs e)
    {
 Response.Redirect("goodPost.aspx");
    }
}