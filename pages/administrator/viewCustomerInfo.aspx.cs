using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

using Microsoft.Reporting.WebForms;
using Microsoft.Reporting.Common;
using Microsoft.Reporting;

using System.Data;


public partial class viewCustomer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            populateCustomer_namesList();
            displayAllUser();
        }


        if (Session["id"] == null) {

            /*
             c# - How to access session variables from any class in ASP.NET? - Stack Overflow. 2016. 
             * c# - How to access session variables from any class in ASP.NET? - Stack Overflow. 
             * [ONLINE] Available at: http://stackoverflow.com/questions/621549/how-to-access-session-variables-from-any-class-in-asp-net. [Accessed 01 Nov 2017].
             */

            Response.Redirect("~/pages/login.aspx");
        }

        if (Session["position"] == null)
        {
            Response.Redirect("~/pages/login.aspx");

        }
    }



    protected void displayAllCustomer(object sender, EventArgs e)
    {
        displayAllUser();
    }

    protected void displayAllUser()
    {
        db_connection db_obj = new db_connection();
        db_obj.open();

        //**********************
        userReport.ProcessingMode = ProcessingMode.Local;
        userReport.LocalReport.ReportPath = Server.MapPath("~/userReport.rdlc");

        userInfoDataSet userDataset = new userInfoDataSet();
        String s = "SELECT  [user_id],[user_name],[user_code],[private_email],[searching_email],[password],[dob],[gender],[nationality],[address],[achievements],[member_date],[contact_number],[active],[position_id],[credits] FROM [_user] ;";
        SqlDataAdapter da = new SqlDataAdapter(s, db_obj.connection);
        DataTable dt = new DataTable();

        da.Fill(userDataset, userDataset.Tables[0].TableName);

        dt = userDataset.Tables[0];
        //  //YouTube. 2016. crystal report,how to create crystal report in C# net using Dataset,visual studio - YouTube. [ONLINE] Available at: https://www.youtube.com/watch?v=uRICO1sZ3Hc. [Accessed 10 Nov 2017].

        ReportDataSource ReportDataSource = new ReportDataSource("_user", userDataset.Tables[0]);
        this.userReport.LocalReport.DataSources.Clear();
        this.userReport.LocalReport.DataSources.Add(ReportDataSource);
        this.userReport.LocalReport.Refresh();

        Generatereport(dt);


        db_obj.close();

    }



    protected void populateCustomer_namesList()
    {
        try
        {
            db_connection db_obj = new db_connection();
            db_obj.open();

            string query = "SELECT user_name AS user_name, user_code FROM _user;";
            SqlCommand cmd = new SqlCommand(query, db_obj.connection);
            SqlDataReader reader = cmd.ExecuteReader();

            namesDropList.DataSource = reader;
            namesDropList.DataTextField = "user_name";
            namesDropList.DataValueField = "user_code";
            namesDropList.DataBind();
            /*Mudassar Ahmed Khan. 2016. Bind (Populate) ASP.Net DropDownList using DataTable (DataSet) in C# and VB.Net. 
        * [ONLINE] Available at: http://www.aspsnippets.com/Articles/Bind-Populate-ASPNet-DropDownList-using-DataTable-DataSet-in-C-and-VBNet.aspx.
        * [Accessed 09 September 2017].*/
            namesDropList.Items.Insert(0, new ListItem("Choose a name to report....", "Null"));
            reader.Close();
            db_obj.close();
        }
        catch (Exception ex)
        {
            msg.Text = "Name list are not available now... Error : " + ex.Message;
        }
    }

 

    protected void searchByNameBtn_Click(object sender, EventArgs e)
    {
       
        try
        {

             reportUserById(idToFind.Text.Trim());

        }
        catch(Exception ex)
        {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('User ID Can not be found! Please try another one');", true);
           
            msg.Text = "User ID Can not be found! Please try another one";
        }
    }


    protected void reportUserById(String uid) {

       
            db_connection db_obj = new db_connection();
            db_obj.open();

            //**********************
            userReport.ProcessingMode = ProcessingMode.Local;
            userReport.LocalReport.ReportPath = Server.MapPath("~/userReport.rdlc");

            userInfoDataSet userDataset = new userInfoDataSet();
            String s = "SELECT  [user_id],[user_name],[user_code],[private_email],[searching_email],[password],[dob],[gender],[nationality],[address],[achievements],[member_date],[contact_number],[active],[position_id],[credits] FROM [_user] where [user_code] like '%" + uid + "%' ";
            SqlDataAdapter da = new SqlDataAdapter(s, db_obj.connection);
            DataTable dt = new DataTable();

            da.Fill(userDataset, userDataset.Tables[0].TableName);

            dt = userDataset.Tables[0];
            //  //YouTube. 2016. crystal report,how to create crystal report in C# net using Dataset,visual studio - YouTube. [ONLINE] Available at: https://www.youtube.com/watch?v=uRICO1sZ3Hc. [Accessed 10 Nov 2017].
       
            ReportDataSource ReportDataSource = new ReportDataSource("_user", userDataset.Tables[0]);
            this.userReport.LocalReport.DataSources.Clear();
            this.userReport.LocalReport.DataSources.Add(ReportDataSource);
            this.userReport.LocalReport.Refresh();

            Generatereport(dt);

            //***

            // this.userReport.ReportRefresh();
            //************************

            db_obj.close();
       
    
    }


    private void Generatereport(DataTable dt)
    {
        userReport.SizeToReportContent = true;
        userReport.LocalReport.ReportPath = Server.MapPath("~/userReport.rdlc");
        userReport.LocalReport.DataSources.Clear();
        ReportDataSource _rsource = new ReportDataSource("DataSet1", dt);
        userReport.LocalReport.DataSources.Add(_rsource);
        userReport.LocalReport.Refresh();
    }


    protected void namesDropList_SelectedIndexChanged(object sender, EventArgs e)
    {
        reportUserById((namesDropList.SelectedValue).ToString().Trim());
    }

}