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

public partial class goodPost : System.Web.UI.Page
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

        if (Session["id"] == null)
        {


            Response.Redirect("~/pages/login.aspx");
        }
       
    }

    protected override void OnInit(EventArgs e)
    {

        base.OnInit(e);
       

        try
        {

            int user_id = int.Parse(Session["id"].ToString());
        }
        catch (Exception ex)
        {
            Response.Redirect("~/pages/signOut.aspx");
        }

        if (!IsPostBack)
        {

            populateCurrentLocationsList();
           
            popluateTimeList();
        }
     
    }
    protected void populateCurrentLocationsList()
    {
        

        string query = "SELECT * FROM location";

        SqlDataReader reader1 = performQuery(query).ExecuteReader();

        newGoodLocation.DataSource = reader1;
        newGoodLocation.DataTextField = "name";
        newGoodLocation.DataValueField = "location_id";
        newGoodLocation.DataBind();
        /*Mudassar Ahmed Khan. 2016. Bind (Populate) ASP.Net DropDownList using DataTable (DataSet) in C# and VB.Net. 
        * [ONLINE] Available at: http://www.aspsnippets.com/Articles/Bind-Populate-ASPNet-DropDownList-using-DataTable-DataSet-in-C-and-VBNet.aspx.
        * [Accessed 09 September 2017].*/
        newGoodLocation.Items.Insert(0, new ListItem("Select a location", "Null"));

        reader1.Close();
        dbRef.close();
    }

    protected void popluateTimeList()
    {
        
        string query = "SELECT * FROM available";

        SqlDataReader reader = performQuery(query).ExecuteReader();

        /*Mudassar Ahmed Khan. 2016. Bind (Populate) ASP.Net DropDownList using DataTable (DataSet) in C# and VB.Net. 
        * [ONLINE] Available at: http://www.aspsnippets.com/Articles/Bind-Populate-ASPNet-DropDownList-using-DataTable-DataSet-in-C-and-VBNet.aspx.
        * [Accessed 09 September 2017].*/
        goodtimeList.DataSource = reader;
        goodtimeList.DataTextField = "name";
        goodtimeList.DataValueField = "name";
        goodtimeList.DataBind();
        goodtimeList.Items.Insert(0, new ListItem("SELECT availability", "N/A"));

        reader.Close();
        dbRef.close();
    }

    protected bool chkAddingNewitemlem()
    {

        if (goodVenue.Text == "" || item_name.Text == "" || newGoodDescription.Text == "") {
            return false; }

        if (newGoodLocation.SelectedIndex == 0) { 
            return false; }

        if (goodtimeList.SelectedIndex == 0) { 
            return false; }

        return true;
    }




    protected void emptyGoodForm()
    {
        goodVenue.Text = "";
        newGoodLocation.SelectedIndex = 0;
        newGoodDescription.Text = "";
        goodtimeList.SelectedIndex = 0;
    }
  



    protected void submit_item_btn_Click(object sender, EventArgs e)
    {

        if (chkAddingNewitemlem() == false)
        {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('The GOOD was not added, please fill up all details');", true);
           
            msg.Text = "The GOOD was not added, please fill up all details";
        }
        else
        {
            string s = FileUpload2.FileName;
            string saveStr = @"~\images\" + FileUpload2.FileName;
            FileUpload2.PostedFile.SaveAs(Server.MapPath(saveStr));
            item item = new item();
            item.venue = goodVenue.Text;
            item.ITEM = item_name.Text;
            item.location_id = int.Parse(newGoodLocation.SelectedValue);
            item.description = newGoodDescription.Text;
            item.available = goodtimeList.SelectedValue;
            item.date = DateTime.Now.ToString("yyy-MM-dd");
            item.type = 'g';
            item.status = 'p';
            item.added_by = int.Parse(Session["id"].ToString());
            item.unit_price = Double.Parse(goodunit_price.Text);
            item.img = s;
            addNewitem(item);

            msg.Text = "The Good " + item_name.Text + " has been added, thank you";
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('The Good " + item_name.Text + " has been added, thank you');", true);
           
            emptyGoodForm();
        }

    }

    public  void addNewitem(item item)
    {
       
        string query = "INSERT INTO item_services (venue,item_name , description, location_id, available_time, date, status, type, added_by, unit_price, img) VALUES ('" + item.venue + "', '" + item.ITEM + "', '" + item.description + "', " + item.location_id + ", '" + item.available + "', '" + item.date + "', '" + item.status + "', '" + item.type + "', "+item.added_by+", "+item.unit_price+",'"+item.img+"')";
       
        performQuery(query).ExecuteNonQuery();

        dbRef.close();
    }


   
    protected void backBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("goods.aspx");
    }

    protected void back_Click(object sender, EventArgs e)
    {
        Response.Redirect("goods.aspx");
    }
}