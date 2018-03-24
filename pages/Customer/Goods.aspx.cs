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
           
            populateCurrentLocationsList();
            populate_goods();
        }
        else
        {
            try
            {
                string test = Session["chosenItemlocation"].ToString();
                populate_goods(test);
            }
            catch (Exception ex)
            {

            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

        if (IsPostBack & (location_list.SelectedIndex != -1 & location_list.SelectedIndex != 0))
        {
            
        }
    }
   

    protected void populateCurrentLocationsList()
    {
       

        string query = "SELECT * FROM location";

        SqlDataReader reader = performQuery(query).ExecuteReader();
        /*Mudassar Ahmed Khan. 2016. Bind (Populate) ASP.Net DropDownList using DataTable (DataSet) in C# and VB.Net. 
        * [ONLINE] Available at: http://www.aspsnippets.com/Articles/Bind-Populate-ASPNet-DropDownList-using-DataTable-DataSet-in-C-and-VBNet.aspx.
        * [Accessed 09 September 2017].*/
        location_list.DataSource = reader;
        location_list.DataTextField = "name";
        location_list.DataValueField = "location_id";
        location_list.DataBind();
        location_list.Items.Insert(0, new ListItem("Select a Place that you would like to trade your stuff!", "Null"));
        reader.Close();

        dbRef.close();
    }

  

    protected void location_list_SelectedIndexChanged(object sender, EventArgs e)
    {
        string selected_location = location_list.SelectedIndex.ToString();
        Session["chosenItemlocation"] = selected_location;
        msg.Text = "";

        if (location_list.SelectedIndex == 0)
        {
            msg.Text = "Please select a location .";
        }
        else
        {
            string test = location_list.SelectedValue.ToString();
            good_ph.Controls.Clear();
            populate_goods(test);
        }
      
    }

    protected void populate_goods(string location_id)
    {    Table itemTable = new Table();
       TableHeaderRow thr = new TableHeaderRow();
      
        itemTable.CssClass = "table table-bordered table-hover table-striped table-responsive thead-inverse";
        TableHeaderCell imgHeader = new TableHeaderCell();imgHeader.Text = "Image";thr.Cells.Add(imgHeader);
        TableHeaderCell thc_name = new TableHeaderCell(); thc_name.Text = "Name"; thr.Cells.Add(thc_name);
       
        TableHeaderCell thc_venue = new TableHeaderCell();thc_venue.Text = "Venue"; thr.Cells.Add(thc_venue);
        TableHeaderCell thc_price = new TableHeaderCell();thc_price.Text = "Price"; thr.Cells.Add(thc_price);
        TableHeaderCell thc_desc = new TableHeaderCell();thc_desc.Text = "Description"; thr.Cells.Add(thc_desc);
        TableHeaderCell thc_time = new TableHeaderCell();thc_time.Text = "Available";thr.Cells.Add(thc_time);
        TableHeaderCell thc_date = new TableHeaderCell();thc_date.Text = "Date";thr.Cells.Add(thc_date);
        TableHeaderCell thc_addedby = new TableHeaderCell(); thc_addedby.Text = "Posted by"; thr.Cells.Add(thc_addedby);
        
        TableHeaderCell thc_search = new TableHeaderCell();thc_search.Text = "Search";thr.Cells.Add(thc_search);


        /*
         How to: Add Rows and Cells Dynamically to a Table Web Server Control. 2016.
         * How to: Add Rows and Cells Dynamically to a Table Web Server Control. 
         * [ONLINE] Available at: https://msdn.microsoft.com/en-us/library/7bewx260.aspx. [Accessed 18 September 2017].
         */
       
        itemTable.Rows.Add(thr);
        int locationID = int.Parse(location_id);

       
        foreach (item item in getitems(locationID, 'g'))
        {   TableRow newRow = new TableRow();
            TableCell imgCell = new TableCell();imgCell.Text = string.Format("<img src='/images/"+item.img+"' class='center-block' runat='server' Height='120px' Width='150px'/>");  newRow.Cells.Add(imgCell);

            TableCell nameCell = new TableCell(); nameCell.Text = item.ITEM; newRow.Cells.Add(nameCell);
               
            TableCell venueCell = new TableCell(); venueCell.Text = item.venue;newRow.Cells.Add(venueCell);
            TableCell priceCell = new TableCell();priceCell.Text = (item.unit_price).ToString();newRow.Cells.Add(priceCell);
            
           
            TableCell descCell = new TableCell();  descCell.Text = item.description;newRow.Cells.Add(descCell);
            TableCell timeCell = new TableCell();timeCell.Text = item.available; newRow.Cells.Add(timeCell);
            TableCell dateCell = new TableCell();dateCell.Text = item.date; newRow.Cells.Add(dateCell);
            TableCell addedBy = new TableCell(); addedBy.Text = (item.posted_by).ToString(); newRow.Cells.Add(addedBy);
               
            TableCell itemBtnCell = new TableCell();
          
            Button itemBtn = new Button();
            itemBtn.Width = 200;
            itemBtn.Height = 60;
            itemBtn.BackColor = Color.Gold;
            itemBtn.ForeColor = Color.DarkGray;

            itemBtn.ID = item.id.ToString();
            itemBtn.Text = "Search";
            itemBtn.CssClass = "btn-sm btn-success";
            itemBtnCell.Controls.Add(itemBtn);

            itemBtn.Click += new EventHandler(this.itemBtn_Click);
            /*Directly use eventHandler for button click and run the  onBtnClick function
             * 
             How to: Add an Event Handler Using Code. 2016. How to: Add an Event Handler Using Code. 
             * [ONLINE] Available at: https://msdn.microsoft.com/en-us/library/ms743596(v=vs.110).aspx. 
             * [Accessed 21 September 2017].
             */


            if (Session["id"] != null)
            {
                newRow.Cells.Add(itemBtnCell);
            }
            else
            {
                thc_search.Visible = false;

            }


          

            itemTable.Rows.Add(newRow);
        }
        good_ph.Controls.Clear();
        good_ph.Controls.Add(itemTable);
    }




    protected void populate_goods()
    {
        if (location_list.SelectedIndex < 1 )
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
            foreach (item item in getitems('g'))//return the object item and the obj item has all the attributes need to populate into table
            {   TableRow newRow = new TableRow();
                TableCell imgCell = new TableCell(); imgCell.Text = string.Format("<img src='/images/" + item.img + "' class='center-block' runat='server' Height='120px' Width='150px'/>");  newRow.Cells.Add(imgCell);
                TableCell nameCell = new TableCell(); nameCell.Text = item.ITEM; newRow.Cells.Add(nameCell);
               
                /*
                 c# - How can I loop through a List and grab each item? - Stack Overflow. 2016. c# - How can I loop through a List and grab each item? - Stack Overflow.
                 * [ONLINE] Available at: http://stackoverflow.com/questions/18863187/how-can-i-loop-through-a-listt-and-grab-each-item. [Accessed 08 September 2017].
                 */
                TableCell venueCell = new TableCell(); venueCell.Text = item.venue;  newRow.Cells.Add(venueCell);

                TableCell priceCell = new TableCell(); priceCell.Text = (item.unit_price).ToString(); newRow.Cells.Add(priceCell);
                TableCell descCell = new TableCell(); descCell.Text = item.description; newRow.Cells.Add(descCell);
                TableCell timeCell = new TableCell(); timeCell.Text = item.available; newRow.Cells.Add(timeCell);
           
                TableCell dateCell = new TableCell();dateCell.Text = item.date;     newRow.Cells.Add(dateCell);
                TableCell addedBy = new TableCell(); addedBy.Text = (item.posted_by).ToString(); newRow.Cells.Add(addedBy);
                TableCell itemBtnCell = new TableCell();
           
                Button itemBtn = new Button();
                itemBtn.Width = 200;
                itemBtn.Height = 150;
                
                itemBtn.BackColor = Color.Salmon;
                itemBtn.ForeColor = Color.Yellow;
                itemBtn.ID = item.id.ToString();
                itemBtn.Text = "Search";
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
        else
        {
            string test = location_list.SelectedIndex.ToString();
           //
            populate_goods(test);
        }
    }


    public  List<item> getitems(char type)
    {
        List<item> itemsList = new List<item>();
        //loop through list and populate data
        /*
                c# - How can I loop through a List and grab each item? - Stack Overflow. 2016. c# - How can I loop through a List and grab each item? - Stack Overflow.
                * [ONLINE] Available at: http://stackoverflow.com/questions/18863187/how-can-i-loop-through-a-listt-and-grab-each-item. [Accessed 08 September 2017].
                */

        string query = "SELECT item_id,venue,item_name,description,location_id,available_time,date,status,type,_user.user_name as posted_by,unit_price,img FROM item_services inner join _user on _user.user_id=item_services.added_by  WHERE type='" + type + "' AND status = 'p'";
       

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

        return itemsList;
    }

    public  List<item> getitems(int locationID, char type)
    {
        List<item> itemsList = new List<item>();
        /*
                c# - How can I loop through a List and grab each item? - Stack Overflow. 2016. c# - How can I loop through a List and grab each item? - Stack Overflow.
                * [ONLINE] Available at: http://stackoverflow.com/questions/18863187/how-can-i-loop-through-a-listt-and-grab-each-item. [Accessed 08 September 2017].
                */
        string query = "SELECT item_id,venue,item_name,description,location_id,available_time,date,status,type,_user.user_name as posted_by,unit_price,img FROM item_services inner join _user on _user.user_id=item_services.added_by  WHERE location_id=" + locationID + " AND type='" + type + "' AND status = 'p'";
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
        if (Session["chosenItemlocation"] != null)
        {
            string test = Session["chosenItemlocation"].ToString();
            populate_goods(test);
        }

    }


    protected void itemBtn_Click(object sender, EventArgs e)
    {
        Button itemBtn = sender as Button;
        Session["item_id"] = itemBtn.ID;
        Session["chosenItemlocation"] = null;
        Response.Redirect("selling_followup.aspx");
    }

    protected void add_new_good_Click(object sender, EventArgs e)
    {

    }

  





	
    protected void add_new_good_Click1(object sender, EventArgs e)
    {
 Response.Redirect("goodPost.aspx");
    }
}