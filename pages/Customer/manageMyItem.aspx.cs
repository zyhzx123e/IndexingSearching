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

public partial class manageFunc : System.Web.UI.Page
{


    db_connection db_obj = new db_connection();
  
    protected void Page_Load(object sender, EventArgs e)
    {

        /*
         
         item_id] ,[venue] ,[item_name],[description],[location_id]
      ,[available_time],[date],[status] ,[type],[added_by],[unit_price],[img]
         */
        if (!this.IsPostBack)
        {


            string query = "SELECT [item_id],[venue],[item_name],[description],[location_id],[available_time],[date],[status],[type],[added_by],[unit_price],[img] FROM [item_services];";

          

            //*****************


            populateItemID();
            populateLocationsList();
            displayAll();
          
        }

        if (Session["id"] == null)
        {
           
            Response.Redirect("~/pages/login.aspx");
        }
       
    }




    DataSet GetData(String queryString)
    {
        

        // Retrieve the connection string stored in the Web.config file.
        String connectionString = ConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString;

        DataSet ds = new DataSet();

        try
        {
            // Connect to the database and run the query.
            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataAdapter adapter = new SqlDataAdapter(queryString, connection);

            // Fill the DataSet.
            adapter.Fill(ds);

        }
        catch (Exception ex)
        {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Unable to connect to the database.!');", true);
     
            // The connection failed. Display an error message.
            msg.Text = "Unable to connect to the database.";

        }

        return ds;

    }

    protected void itemDelete_click(object sender, EventArgs e)
    {
        String delete = "delete from item_services where item_id=" + txt_newItemId.Text + " ; ";
        if (performQuery(delete) > 0)
        {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('You have deleted your item with id" + txt_newItemId.Text + "');", true);
            msg.Text = "You have delete your item with id" + txt_newItemId.Text + "";
            this.AlertBoxMessage.InnerText = "You have delete your item with id" + txt_newItemId.Text + "";
            this.AlertBox.Visible = true;
            populateItemID();
            populateLocationsList();
        
            displayAll();
        }
        else {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Error! Item with ID" + txt_newItemId.Text + "' failed to delete, pls try again later!');", true);
            msg.Text = "Error! Item with ID" + txt_newItemId.Text + "' failed to delete, pls try again later!";
            this.AlertBoxMessage.InnerText = "Error! Item with ID" + txt_newItemId.Text + "' failed to delete, pls try again later!";
        this.AlertBox.Visible = true;

        }
        db_obj.close();
    }



    protected void itemNewType_click(object sender, EventArgs e)
    {
        String update = "update item_services set type='"+txt_newType.SelectedValue.ToString()+"' where item_id="+txt_newItemId.Text+" ; ";
        if (performQuery(update) > 0)
        {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('You have updated item with id" + txt_newItemId.Text + "');", true);
            msg.Text = "You have updated item with id" + txt_newItemId.Text + "";
            this.AlertBoxMessage.InnerText = "You have updated item with id -> " + txt_newItemId.Text + "";
            this.AlertBox.Visible = true;
            populateItemID();
            populateLocationsList();
         
            displayAll();
        }
        else
        {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Error! Item with ID" + txt_newItemId.Text + "' failed to update, pls try again later!');", true);
            msg.Text = "Error! Item with ID" + txt_newItemId.Text + "' failed to update, pls try again later!";
            this.AlertBoxMessage.InnerText = "Error! Item with ID :" + txt_newItemId.Text + "' failed to update, pls try again later!";
            this.AlertBox.Visible = true;

        }
        db_obj.close();
    
    }
    protected void itemNewAvailable_click(object sender, EventArgs e)
    {
        String update = "update item_services set available_time='" + txt_newAvailable.SelectedValue.ToString() + "' where item_id=" + txt_newItemId.Text + " ; ";
        if (performQuery(update) > 0)
        {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('You have updated item with id" + txt_newItemId.Text + "');", true);
            msg.Text = "You have updated item with id" + txt_newItemId.Text + "";
            this.AlertBoxMessage.InnerText = "You have updated item with id -> " + txt_newItemId.Text + "";
            this.AlertBox.Visible = true;
            populateItemID();
            populateLocationsList();
           
            displayAll();
        }
        else
        {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Error! Item with ID" + txt_newItemId.Text + "' failed to update, pls try again later!');", true);
            msg.Text = "Error! Item with ID" + txt_newItemId.Text + "' failed to update, pls try again later!";
            this.AlertBoxMessage.InnerText = "Error! Item with ID :" + txt_newItemId.Text + "' failed to update, pls try again later!";
            this.AlertBox.Visible = true;

        }
        db_obj.close();

    }
    protected void itemNewLocation_click(object sender, EventArgs e)
    {
        String update = "update item_services set location_id='" + txt_newLocation.SelectedValue.ToString() + "' where item_id=" + txt_newItemId.Text + " ; ";
        if (performQuery(update) > 0)
        {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('You have updated item with id" + txt_newItemId.Text + "');", true);
            msg.Text = "You have updated item with id" + txt_newItemId.Text + "";
            this.AlertBoxMessage.InnerText = "You have updated item with id -> " + txt_newItemId.Text + "";
            this.AlertBox.Visible = true;
            populateItemID();
            populateLocationsList();
       
            displayAll();
        }
        else
        {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Error! Item with ID" + txt_newItemId.Text + "' failed to update, pls try again later!');", true);
            msg.Text = "Error! Item with ID" + txt_newItemId.Text + "' failed to update, pls try again later!";
            this.AlertBoxMessage.InnerText = "Error! Item with ID :" + txt_newItemId.Text + "' failed to update, pls try again later!";
            this.AlertBox.Visible = true;

        }
        db_obj.close();

    }
    protected void itemNewDetail_click(object sender, EventArgs e)
    {
        String update = "update item_services set description='" + txt_newDetail.Text.ToString() + "' where item_id=" + txt_newItemId.Text + " ; ";
        if (performQuery(update) > 0)
        {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('You have updated item with id" + txt_newItemId.Text + "');", true);
            msg.Text = "You have updated item with id" + txt_newItemId.Text + "";
            this.AlertBoxMessage.InnerText = "You have updated item with id -> " + txt_newItemId.Text + "";
            this.AlertBox.Visible = true;
            populateItemID();
            populateLocationsList();
        
            displayAll();
        }
        else
        {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Error! Item with ID" + txt_newItemId.Text + "' failed to update, pls try again later!');", true);
            msg.Text = "Error! Item with ID" + txt_newItemId.Text + "' failed to update, pls try again later!";
            this.AlertBoxMessage.InnerText = "Error! Item with ID :" + txt_newItemId.Text + "' failed to update, pls try again later!";
            this.AlertBox.Visible = true;

        }
        db_obj.close();

    }
    protected void itemNewName_click(object sender, EventArgs e)
    {
        String update = "update item_services set item_name='" + txt_newName.Text.ToString() + "' where item_id=" + txt_newItemId.Text + " ; ";
        if (performQuery(update) > 0)
        {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('You have updated item with id" + txt_newItemId.Text + "');", true);
            msg.Text = "You have updated item with id : " + txt_newItemId.Text + "";
            this.AlertBoxMessage.InnerText = "You have updated item with id -> " + txt_newItemId.Text + "";
            this.AlertBox.Visible = true;
            populateItemID();
       
            populateLocationsList();
            displayAll();
        }
        else
        {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Error! Item with ID" + txt_newItemId.Text + "' failed to update, pls try again later!');", true);
            msg.Text = "Error! Item with ID" + txt_newItemId.Text + "' failed to update, pls try again later!";
            this.AlertBoxMessage.InnerText = "Error! Item with ID :" + txt_newItemId.Text + "' failed to update, pls try again later!";
            this.AlertBox.Visible = true;

        }

        db_obj.close();
    }
    protected void itemNewStatus_click(object sender, EventArgs e) {

        String update = "update item_services set status='" + txt_newStatus.SelectedValue.ToString() + "' where item_id=" + txt_newItemId.Text + " ; ";
        if (performQuery(update) > 0)
        {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('You have updated item with id" + txt_newItemId.Text + "');", true);
            msg.Text = "You have updated item with id" + txt_newItemId.Text + "";
            this.AlertBoxMessage.InnerText = "You have updated item with id -> " + txt_newItemId.Text + "";
            this.AlertBox.Visible = true;
            populateItemID();
           
            populateLocationsList();
            displayAll();

        }
        else
        {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Error! Item with ID" + txt_newItemId.Text + "' failed to update, pls try again later!');", true);
            msg.Text = "Error! Item with ID" + txt_newItemId.Text + "' failed to update, pls try again later!";
            this.AlertBoxMessage.InnerText = "Error! Item with ID :" + txt_newItemId.Text + "' failed to update, pls try again later!";
            this.AlertBox.Visible = true;

        }
        db_obj.close();
    }

    protected void itemNewVenue_click(object sender, EventArgs e)
    {

        String update = "update item_services set venue='" + txt_newVenue.Text.ToString() + "' where item_id=" + txt_newItemId.Text + " ; ";
        if (performQuery(update) > 0)
        {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('You have updated item with id" + txt_newItemId.Text + "');", true);
            msg.Text = "You have updated item with id" + txt_newItemId.Text + "";
            this.AlertBoxMessage.InnerText = "You have updated item with id -> " + txt_newItemId.Text + "";
            this.AlertBox.Visible = true;
            populateItemID();
          
            populateLocationsList();
            displayAll();
        }
        else
        {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Error! Item with ID" + txt_newItemId.Text + "' failed to update, pls try again later!');", true);
            msg.Text = "Error! Item with ID" + txt_newItemId.Text + "' failed to update, pls try again later!";
            this.AlertBoxMessage.InnerText = "Error! Item with ID :" + txt_newItemId.Text + "' failed to update, pls try again later!";
            this.AlertBox.Visible = true;

        }
        db_obj.close();
    }

    public int performQuery(String query)
    {
        
        db_obj.open();

     
        SqlCommand cmd1 = new SqlCommand(query, db_obj.connection);
        if (cmd1.ExecuteNonQuery() > 0)
        {
            return 1;
            
        }
        else
        {
            return 0;
           
        }

        
    }
   
  /*Mudassar Ahmed Khan. 2016. Bind (Populate) ASP.Net DropDownList using DataTable (DataSet) in C# and VB.Net. 
        * [ONLINE] Available at: http://www.aspsnippets.com/Articles/Bind-Populate-ASPNet-DropDownList-using-DataTable-DataSet-in-C-and-VBNet.aspx.
        * [Accessed 09 September 2017].*/

    protected void populateItemID() {
          if (Session["id"] != null && Session["item_id"] != null)
        {

       


            string item_id = Session["item_id"].ToString();


            txt_newItemId.Text = item_id;

        }
    }

    protected void populateLocationsList()
    {
        db_connection db_obj = new db_connection();
        db_obj.open();

        string query = "SELECT * FROM location";


        SqlCommand cmd1 = new SqlCommand(query, db_obj.connection);
   
        /*Mudassar Ahmed Khan. 2016. Bind (Populate) ASP.Net DropDownList using DataTable (DataSet) in C# and VB.Net. 
        * [ONLINE] Available at: http://www.aspsnippets.com/Articles/Bind-Populate-ASPNet-DropDownList-using-DataTable-DataSet-in-C-and-VBNet.aspx.
        * [Accessed 09 September 2017].*/

     
        SqlDataReader reader2 = cmd1.ExecuteReader();
        txt_newLocation.DataSource = reader2;
        txt_newLocation.DataTextField = "name";
        txt_newLocation.DataValueField = "location_id";
        txt_newLocation.DataBind();
        txt_newLocation.Items.Insert(0, new ListItem("Select a location", "Null"));



        reader2.Close();
        db_obj.close();
    }

    protected void populateAll(object sender, EventArgs e)
    {
        if (Session["id"] != null && Session["item_id"] != null)
        {
            string item_id = Session["item_id"].ToString();
            string current_user_id = Session["id"].ToString();
            int int_user_id = Int16.Parse(current_user_id);
            string query = "SELECT [item_id],[venue],[item_name],[description],[location_id],[available_time],[date],[status],[type],[added_by],[unit_price],[img] FROM [item_services] where [item_id]=" + item_id + " AND [added_by]=" + int_user_id + " ;";


            db_connection db_obj = new db_connection();
            db_obj.open();

      
            SqlCommand cmd1 = new SqlCommand(query, db_obj.connection);

            /*Mudassar Ahmed Khan. 2016. Bind (Populate) ASP.Net DropDownList using DataTable (DataSet) in C# and VB.Net. 
            * [ONLINE] Available at: http://www.aspsnippets.com/Articles/Bind-Populate-ASPNet-DropDownList-using-DataTable-DataSet-in-C-and-VBNet.aspx.
            * [Accessed 09 September 2017].*/


            SqlDataReader reader2 = cmd1.ExecuteReader();

            while (reader2.Read())
            {
                txt_newVenue.Text = reader2["venue"].ToString();
                txt_newName.Text = reader2["item_name"].ToString();
                txt_newDetail.Text = reader2["description"].ToString();
                txt_newLocation.SelectedIndex = Int16.Parse(reader2["location_id"].ToString());
                txt_newAvailable.SelectedValue = reader2["available_time"].ToString();
                txt_newStatus.SelectedValue = reader2["status"].ToString();
                txt_newType.SelectedValue = reader2["type"].ToString();
            }

            reader2.Close();
            bindTablePopulate(query);
        }
    }

    public void displayAll() {

        if (Session["id"] != null && Session["item_id"] != null)
        {
            string item_id = Session["item_id"].ToString();
            string current_user_id = Session["id"].ToString();
            int int_user_id = Int16.Parse(current_user_id);
            string query = "SELECT [item_id],[venue],[item_name],[description],[location_id],[available_time],[date],[status],[type],[added_by],[unit_price],[img] FROM [item_services] where [item_id]=" + item_id + " AND [added_by]=" + int_user_id + " ;";



            db_connection db_obj = new db_connection();
            db_obj.open();


            SqlCommand cmd1 = new SqlCommand(query, db_obj.connection);

            /*Mudassar Ahmed Khan. 2016. Bind (Populate) ASP.Net DropDownList using DataTable (DataSet) in C# and VB.Net. 
            * [ONLINE] Available at: http://www.aspsnippets.com/Articles/Bind-Populate-ASPNet-DropDownList-using-DataTable-DataSet-in-C-and-VBNet.aspx.
            * [Accessed 09 September 2017].*/


            SqlDataReader reader2 = cmd1.ExecuteReader();

            while (reader2.Read())
            {
                txt_newVenue.Text = reader2["venue"].ToString();
                txt_newName.Text = reader2["item_name"].ToString();
                txt_newDetail.Text = reader2["description"].ToString();
                txt_newLocation.SelectedIndex = Int16.Parse(reader2["location_id"].ToString());
                txt_newAvailable.SelectedValue = reader2["available_time"].ToString();
                txt_newStatus.SelectedValue = reader2["status"].ToString();
                txt_newType.SelectedValue = reader2["type"].ToString();
            }

            reader2.Close();

            bindTablePopulate(query);
        }
    }



    public void bindTablePopulate(String query) {
        string constr = ConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString;
        //db_obj.getConnectionString();//ConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString;
       
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand(query))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    /*Mudassar Ahmed Khan. 2016. Bind (Populate) GridView using DataSet in ASP.Net using C# and VB.Net. 
                     * [ONLINE] Available at: http://www.aspsnippets.com/Articles/Bind-Populate-GridView-using-DataSet-in-ASPNet-using-C-and-VBNet.aspx. [Accessed 11 September 2017].*/

                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (DataSet ds = new DataSet())
                    {
                        //Response.Write("2000000000000000000000000000111111");
                        sda.Fill(ds); //Response.Write("20000000000000000000000000000222222");
                        stuff.DataSource = ds; //Response.Write("20000000000000000000000000000333333");
                        stuff.DataBind(); //Response.Write("20000000000000000000000000000444444");

                    }
                }
            }
        }
    }

   
}