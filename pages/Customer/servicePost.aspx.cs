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

public partial class servicePost : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {


        if (Session["id"] == null)
        {


            Response.Redirect("~/pages/login.aspx");
        }
       
    }
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
        /*Mudassar Ahmed Khan. 2016. Bind (Populate) ASP.Net DropDownList using DataTable (DataSet) in C# and VB.Net. 
        * [ONLINE] Available at: http://www.aspsnippets.com/Articles/Bind-Populate-ASPNet-DropDownList-using-DataTable-DataSet-in-C-and-VBNet.aspx.
        * [Accessed 09 September 2017].*/
        newitemLocation.DataSource = reader1;
        newitemLocation.DataTextField = "name";
        newitemLocation.DataValueField = "location_id";
        newitemLocation.DataBind();
        newitemLocation.Items.Insert(0, new ListItem("SELECT LOCATION", "N/A"));



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
        timeList.DataSource = reader;
        timeList.DataTextField = "name";
        timeList.DataValueField = "name";
        timeList.DataBind();
        timeList.Items.Insert(0, new ListItem("SELECT availability", "N/A"));

        reader.Close();
        dbRef.close();
    }

    protected bool chkAddingNewitemlem()
    {

        if (venueTxt.Text == "" || service_name.Text=="" || servicesDescription.Text=="")
        {return false;}
         if (newitemLocation.SelectedIndex == 0) { return false; }

        if (timeList.SelectedIndex == 0) return false;

        return true;
    }



    protected void submit_item_btn_Click(object sender, EventArgs e)
    {

        if (chkAddingNewitemlem() == false)
        {
            msg.Text = "The service was not added, please fill up all details";
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('The service " + service_name.Text + "  was not added, please fill up all details');", true);
           
        }
        else
        {
            string s = FileUpload1.FileName;
            string saveStr = @"~\images\" + FileUpload1.FileName;
            FileUpload1.PostedFile.SaveAs(Server.MapPath(saveStr));
            item item = new item();
            item.venue = venueTxt.Text;
            item.ITEM = service_name.Text;
            item.location_id = int.Parse(newitemLocation.SelectedValue);
            item.description = servicesDescription.Text;
            item.available = timeList.SelectedValue;
            item.date = DateTime.Now.ToString("yyy-MM-dd");
            item.type = 's';

            /*
             Sam Saffron. . That annoying INSERT problem, getting data into the DB . [ONLINE] Available at: https://samsaffron.com/archive/2012/01/16/that-annoying-insert-problem-getting-data-into-the-db-using-dapper. 
             * [Accessed 15 September 2017].
             */


            item.status = 'p';
            item.added_by = int.Parse(Session["id"].ToString());
            item.unit_price = Double.Parse(unit_price.Text);
            item.img = s;
            addNewitem(item);

            msg.Text = "The service " + service_name.Text + " has been added, thank you";
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('The service " + service_name.Text + " has been added, thank you');", true);
           
            emptyServicePopUpFrom();
        }

    }
    public  void addNewitem(item item)
    {
        string query = "INSERT INTO item_services (venue,item_name , description, location_id, available_time, date, status, type, added_by, unit_price, img) VALUES ('" + item.venue + "', '" + item.ITEM + "', '" + item.description + "', "+item.location_id+", '"+item.available+"', '"+item.date+"', '"+item.status+"', '"+item.type+"', "+item.added_by+", "+item.unit_price+",'"+item.img+"')";
       
        performQuery(query).ExecuteNonQuery();

        dbRef.close();
    }


    protected void emptyServicePopUpFrom()
    {
        venueTxt.Text = "";
        service_name.Text = "";
        newitemLocation.SelectedIndex = 0;
        servicesDescription.Text = "";
        timeList.SelectedIndex = 0;
    }

    protected void backBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("Services.aspx");
    }

    protected void back_Click(object sender, EventArgs e)
    {
        Response.Redirect("Services.aspx");
    }
}