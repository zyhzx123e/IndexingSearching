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

            displayAllItem();

            //*****************


            populateItemID();
            populateLocationsList();
            displayAll();
          
        }

        if (Session["id"] == null)
        {
           
            Response.Redirect("~/pages/login.aspx");
        }
        if (Int32.Parse(Session["position"].ToString()) != 1) {
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
        String delete = "delete from item_services where item_id=" + txt_itemId.SelectedValue + " ; ";
        if (performQuery(delete) > 0)
        {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('You have delete item with id" + txt_itemId.SelectedValue + "');", true);
            msg.Text = "You have delete item with id" + txt_itemId.SelectedValue + "";
            this.AlertBoxMessage.InnerText = "You have delete item with id" + txt_itemId.SelectedValue + "";
            this.AlertBox.Visible = true;
            populateItemID();
            populateLocationsList();
            displayAllItem();
            displayAll();
        }
        else {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Error! Item with ID" + txt_itemId.SelectedValue + "' failed to delete, pls try again later!');", true);
        msg.Text = "Error! Item with ID" + txt_itemId.SelectedValue + "' failed to delete, pls try again later!";
        this.AlertBoxMessage.InnerText = "Error! Item with ID" + txt_itemId.SelectedValue + "' failed to delete, pls try again later!";
        this.AlertBox.Visible = true;

        }
        db_obj.close();
    }

    protected void itemNewType_click(object sender, EventArgs e)
    {
        String update = "update item_services set type='"+txt_newType.SelectedValue.ToString()+"' where item_id="+txt_newItemId.SelectedValue+" ; ";
        if (performQuery(update) > 0)
        {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('You have updated item with id" + txt_newItemId.SelectedValue + "');", true);
            msg.Text = "You have updated item with id" + txt_newItemId.SelectedValue + "";
            this.AlertBoxMessage.InnerText = "You have updated item with id -> " + txt_newItemId.SelectedValue + "";
            this.AlertBox.Visible = true;
            populateItemID();
            populateLocationsList();
            displayAllItem();
            displayAll();
        }
        else
        {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Error! Item with ID" + txt_newItemId.SelectedValue + "' failed to update, pls try again later!');", true);
            msg.Text = "Error! Item with ID" + txt_newItemId.SelectedValue + "' failed to update, pls try again later!";
            this.AlertBoxMessage.InnerText = "Error! Item with ID :" + txt_newItemId.SelectedValue + "' failed to update, pls try again later!";
            this.AlertBox.Visible = true;

        }
        db_obj.close();
    
    }
    protected void itemNewAvailable_click(object sender, EventArgs e)
    {
        String update = "update item_services set available_time='" + txt_newAvailable.SelectedValue.ToString() + "' where item_id=" + txt_newItemId.SelectedValue + " ; ";
        if (performQuery(update) > 0)
        {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('You have updated item with id" + txt_newItemId.SelectedValue + "');", true);
            msg.Text = "You have updated item with id" + txt_newItemId.SelectedValue + "";
            this.AlertBoxMessage.InnerText = "You have updated item with id -> " + txt_newItemId.SelectedValue + "";
            this.AlertBox.Visible = true;
            populateItemID();
            populateLocationsList();
            displayAllItem();
            displayAll();
        }
        else
        {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Error! Item with ID" + txt_newItemId.SelectedValue + "' failed to update, pls try again later!');", true);
            msg.Text = "Error! Item with ID" + txt_newItemId.SelectedValue + "' failed to update, pls try again later!";
            this.AlertBoxMessage.InnerText = "Error! Item with ID :" + txt_newItemId.SelectedValue + "' failed to update, pls try again later!";
            this.AlertBox.Visible = true;

        }
        db_obj.close();

    }
    protected void itemNewLocation_click(object sender, EventArgs e)
    {
        String update = "update item_services set location_id='" + txt_newLocation.SelectedValue.ToString() + "' where item_id=" + txt_newItemId.SelectedValue + " ; ";
        if (performQuery(update) > 0)
        {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('You have updated item with id" + txt_newItemId.SelectedValue + "');", true);
            msg.Text = "You have updated item with id" + txt_newItemId.SelectedValue + "";
            this.AlertBoxMessage.InnerText = "You have updated item with id -> " + txt_newItemId.SelectedValue + "";
            this.AlertBox.Visible = true;
            populateItemID();
            populateLocationsList();
            displayAllItem();
            displayAll();
        }
        else
        {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Error! Item with ID" + txt_newItemId.SelectedValue + "' failed to update, pls try again later!');", true);
            msg.Text = "Error! Item with ID" + txt_newItemId.SelectedValue + "' failed to update, pls try again later!";
            this.AlertBoxMessage.InnerText = "Error! Item with ID :" + txt_newItemId.SelectedValue + "' failed to update, pls try again later!";
            this.AlertBox.Visible = true;

        }
        db_obj.close();

    }
    protected void itemNewDetail_click(object sender, EventArgs e)
    {
        String update = "update item_services set description='" + txt_newDetail.Text.ToString() + "' where item_id=" + txt_newItemId.SelectedValue + " ; ";
        if (performQuery(update) > 0)
        {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('You have updated item with id" + txt_newItemId.SelectedValue + "');", true);
            msg.Text = "You have updated item with id" + txt_newItemId.SelectedValue + "";
            this.AlertBoxMessage.InnerText = "You have updated item with id -> " + txt_newItemId.SelectedValue + "";
            this.AlertBox.Visible = true;
            populateItemID();
            populateLocationsList();
            displayAllItem();
            displayAll();
        }
        else
        {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Error! Item with ID" + txt_newItemId.SelectedValue + "' failed to update, pls try again later!');", true);
            msg.Text = "Error! Item with ID" + txt_newItemId.SelectedValue + "' failed to update, pls try again later!";
            this.AlertBoxMessage.InnerText = "Error! Item with ID :" + txt_newItemId.SelectedValue + "' failed to update, pls try again later!";
            this.AlertBox.Visible = true;

        }
        db_obj.close();

    }
    protected void itemNewName_click(object sender, EventArgs e)
    {
        String update = "update item_services set item_name='" + txt_newName.Text.ToString() + "' where item_id=" + txt_newItemId.SelectedValue + " ; ";
        if (performQuery(update) > 0)
        {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('You have updated item with id" + txt_newItemId.SelectedValue + "');", true);
            msg.Text = "You have updated item with id" + txt_newItemId.SelectedValue + "";
            this.AlertBoxMessage.InnerText = "You have updated item with id -> " + txt_newItemId.SelectedValue + "";
            this.AlertBox.Visible = true;
            populateItemID();
            displayAllItem();
            populateLocationsList();
            displayAll();
        }
        else
        {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Error! Item with ID" + txt_newItemId.SelectedValue + "' failed to update, pls try again later!');", true);
            msg.Text = "Error! Item with ID" + txt_newItemId.SelectedValue + "' failed to update, pls try again later!";
            this.AlertBoxMessage.InnerText = "Error! Item with ID :" + txt_newItemId.SelectedValue + "' failed to update, pls try again later!";
            this.AlertBox.Visible = true;

        }

        db_obj.close();
    }
    protected void itemNewStatus_click(object sender, EventArgs e) {

        String update = "update item_services set status='" + txt_newStatus.SelectedValue.ToString() + "' where item_id=" + txt_newItemId.SelectedValue + " ; ";
        if (performQuery(update) > 0)
        {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('You have updated item with id" + txt_newItemId.SelectedValue + "');", true);
            msg.Text = "You have updated item with id" + txt_newItemId.SelectedValue + "";
            this.AlertBoxMessage.InnerText = "You have updated item with id -> " + txt_newItemId.SelectedValue + "";
            this.AlertBox.Visible = true;
            populateItemID();
            displayAllItem();
            populateLocationsList();
            displayAll();

        }
        else
        {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Error! Item with ID" + txt_newItemId.SelectedValue + "' failed to update, pls try again later!');", true);
            msg.Text = "Error! Item with ID" + txt_newItemId.SelectedValue + "' failed to update, pls try again later!";
            this.AlertBoxMessage.InnerText = "Error! Item with ID :" + txt_newItemId.SelectedValue + "' failed to update, pls try again later!";
            this.AlertBox.Visible = true;

        }
        db_obj.close();
    }

    protected void itemNewVenue_click(object sender, EventArgs e)
    {

        String update = "update item_services set venue='" + txt_newVenue.Text.ToString() + "' where item_id=" + txt_newItemId.SelectedValue + " ; ";
        if (performQuery(update) > 0)
        {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('You have updated item with id" + txt_newItemId.SelectedValue + "');", true);
            msg.Text = "You have updated item with id" + txt_newItemId.SelectedValue + "";
            this.AlertBoxMessage.InnerText = "You have updated item with id -> " + txt_newItemId.SelectedValue + "";
            this.AlertBox.Visible = true;
            populateItemID();
            displayAllItem();
            populateLocationsList();
            displayAll();
        }
        else
        {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Error! Item with ID" + txt_newItemId.SelectedValue + "' failed to update, pls try again later!');", true);
            msg.Text = "Error! Item with ID" + txt_newItemId.SelectedValue + "' failed to update, pls try again later!";
            this.AlertBoxMessage.InnerText = "Error! Item with ID :" + txt_newItemId.SelectedValue + "' failed to update, pls try again later!";
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
   


    protected void populateItemID() {
        db_connection db_obj = new db_connection();
        db_obj.open();

        string query = "SELECT item_id FROM item_services";


        SqlCommand cmd1 = new SqlCommand(query, db_obj.connection);
        SqlDataReader reader1 = cmd1.ExecuteReader();

        /*Mudassar Ahmed Khan. 2016. Bind (Populate) ASP.Net DropDownList using DataTable (DataSet) in C# and VB.Net. 
        * [ONLINE] Available at: http://www.aspsnippets.com/Articles/Bind-Populate-ASPNet-DropDownList-using-DataTable-DataSet-in-C-and-VBNet.aspx.
        * [Accessed 09 September 2017].*/

        txt_itemId.DataSource = reader1;
        txt_itemId.DataTextField = "item_id";
        txt_itemId.DataValueField = "item_id";
        txt_itemId.DataBind();
        txt_itemId.Items.Insert(0, new ListItem("Select item id", "Null"));
reader1.Close();
        SqlDataReader reader2 = cmd1.ExecuteReader();
        txt_newItemId.DataSource = reader2;
        txt_newItemId.DataTextField = "item_id";
        txt_newItemId.DataValueField = "item_id";
        txt_newItemId.DataBind();
        txt_newItemId.Items.Insert(0, new ListItem("Select item id", "Null"));
        reader2.Close();
        
        db_obj.close();
    }

    protected void populateLocationsList()
    {
        db_connection db_obj = new db_connection();
        db_obj.open();

        string query = "SELECT * FROM location";


        SqlCommand cmd1 = new SqlCommand(query, db_obj.connection);
        SqlDataReader reader1 = cmd1.ExecuteReader();

        /*Mudassar Ahmed Khan. 2016. Bind (Populate) ASP.Net DropDownList using DataTable (DataSet) in C# and VB.Net. 
        * [ONLINE] Available at: http://www.aspsnippets.com/Articles/Bind-Populate-ASPNet-DropDownList-using-DataTable-DataSet-in-C-and-VBNet.aspx.
        * [Accessed 09 September 2017].*/

        txt_location.DataSource = reader1;
        txt_location.DataTextField = "name";
        txt_location.DataValueField = "location_id";
        txt_location.DataBind();
        txt_location.Items.Insert(0, new ListItem("Select a location", "Null"));
        reader1.Close();
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
        displayAllItem();
        string query = "SELECT [item_id],[venue],[item_name],[description],[location_id],[available_time],[date],[status],[type],[added_by],[unit_price],[img] FROM [item_services];";

        bindTablePopulate(query);
                
    }

    public void displayAll() {
        
        string query = "SELECT [item_id],[venue],[item_name],[description],[location_id],[available_time],[date],[status],[type],[added_by],[unit_price],[img] FROM [item_services];";

        bindTablePopulate(query);
    
    }

    protected void displayAllItem()
    {
        db_connection db_obj = new db_connection();
        db_obj.open();

        //**********************
        itemReport.ProcessingMode = ProcessingMode.Local;
        itemReport.LocalReport.ReportPath = Server.MapPath("~/itemReport.rdlc");

        itemDataSet item_Dataset = new itemDataSet();
        string s = "SELECT [item_id],[venue],[item_name],[description],[location_id],[available_time],[date],[status],[type],[added_by],[unit_price],[img] FROM [item_services];";
        SqlDataAdapter da = new SqlDataAdapter(s, db_obj.connection);
        DataTable dt = new DataTable();

        da.Fill(item_Dataset, item_Dataset.Tables[0].TableName);

        dt = item_Dataset.Tables[0];
        //  //YouTube. 2016. crystal report,how to create crystal report in C# net using Dataset,visual studio - YouTube. [ONLINE] Available at: https://www.youtube.com/watch?v=uRICO1sZ3Hc. [Accessed 10 Nov 2017].

        ReportDataSource ReportDataSource = new ReportDataSource("item_services", item_Dataset.Tables[0]);
        this.itemReport.LocalReport.DataSources.Clear();
        this.itemReport.LocalReport.DataSources.Add(ReportDataSource);
        this.itemReport.LocalReport.Refresh();

        Generatereport(dt);

        //***

        // this.userReport.ReportRefresh();
        //************************

        db_obj.close();

    }



    protected void displayItemByQuery(String s)
    {
        db_connection db_obj = new db_connection();
        db_obj.open();

        //**********************
        itemReport.ProcessingMode = ProcessingMode.Local;
        itemReport.LocalReport.ReportPath = Server.MapPath("~/itemReport.rdlc");

        itemDataSet item_Dataset = new itemDataSet();
        
        SqlDataAdapter da = new SqlDataAdapter(s, db_obj.connection);
        DataTable dt = new DataTable();

        da.Fill(item_Dataset, item_Dataset.Tables[0].TableName);

        dt = item_Dataset.Tables[0];
        //  //YouTube. 2016. crystal report,how to create crystal report in C# net using Dataset,visual studio - YouTube. [ONLINE] Available at: https://www.youtube.com/watch?v=uRICO1sZ3Hc. [Accessed 10 Nov 2017].

        ReportDataSource ReportDataSource = new ReportDataSource("item_services", item_Dataset.Tables[0]);
        this.itemReport.LocalReport.DataSources.Clear();
        this.itemReport.LocalReport.DataSources.Add(ReportDataSource);
        this.itemReport.LocalReport.Refresh();

        Generatereport(dt);

        //***

        // this.userReport.ReportRefresh();
        //************************

        db_obj.close();

    }


    private void Generatereport(DataTable dt)
    {
        itemReport.SizeToReportContent = true;
        itemReport.LocalReport.ReportPath = Server.MapPath("~/itemReport.rdlc");
        itemReport.LocalReport.DataSources.Clear();
        ReportDataSource _rsource = new ReportDataSource("DataSet1", dt);
        itemReport.LocalReport.DataSources.Add(_rsource);
        itemReport.LocalReport.Refresh();
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

    protected void itemIDsearch_click(object sender, EventArgs e)
    {
        string query = "SELECT [item_id],[venue],[item_name],[description],[location_id],[available_time],[date],[status],[type],[added_by],[unit_price],[img] FROM [item_services] where item_services.item_id =" + txt_itemId.SelectedValue + " ;";
        displayItemByQuery(query);
        bindTablePopulate(query);

    }

    protected void itemVenue_click(object sender, EventArgs e)
    {
        string query = "SELECT [item_id],[venue],[item_name],[description],[location_id],[available_time],[date],[status],[type],[added_by],[unit_price],[img] FROM [item_services] where  item_services.venue like '%" + txt_itemVenue.Text.ToString() + "%'  ;";
        displayItemByQuery(query);
        bindTablePopulate(query);
    }
    protected void itemName_click(object sender, EventArgs e)
    {
        string query = "SELECT [item_id],[venue],[item_name],[description],[location_id],[available_time],[date],[status],[type],[added_by],[unit_price],[img] FROM [item_services] where item_services.item_name like '%" + txt_itemName.Text.ToString() + "%' ;";
        displayItemByQuery(query);
        bindTablePopulate(query);
    }
    protected void itemDetail_click(object sender, EventArgs e)
    {
        string query = "SELECT [item_id],[venue],[item_name],[description],[location_id],[available_time],[date],[status],[type],[added_by],[unit_price],[img] FROM [item_services] where item_services.description like '%" + txt_description.Text.ToString() + "%'  ;";
        displayItemByQuery(query);
        bindTablePopulate(query);

    }
    protected void itemLocation_click(object sender, EventArgs e)
    {
        string query = "SELECT [item_id],[venue],[item_name],[description],[location_id],[available_time],[date],[status],[type],[added_by],[unit_price],[img] FROM [item_services] where  item_services.location_id=" + txt_location.SelectedValue + " ;";
        displayItemByQuery(query);
        bindTablePopulate(query);
    }
    protected void itemAvailable_click(object sender, EventArgs e)
    {
        string query = "SELECT [item_id],[venue],[item_name],[description],[location_id],[available_time],[date],[status],[type],[added_by],[unit_price],[img] FROM [item_services] where  item_services.available_time='" + availableTime.SelectedValue.ToString() + "' ;";
        displayItemByQuery(query);
        bindTablePopulate(query);
    }
    protected void itemType_click(object sender, EventArgs e)
    {
        string query = "SELECT [item_id],[venue],[item_name],[description],[location_id],[available_time],[date],[status],[type],[added_by],[unit_price],[img] FROM [item_services] where  item_services.type='" + itemType.SelectedValue.ToString() + "'  ;";
        displayItemByQuery(query);
        bindTablePopulate(query);
    }

   
}