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

public partial class pages_common_login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {


    }
   
    protected void log_Click(object sender, EventArgs e) {
        Response.Write("888");

        try
        {
            Response.Write("888");
            
            string input_code = iDNumber.Text;
            string input_pass = password.Text;
            if (string.IsNullOrEmpty(input_code) || string.IsNullOrEmpty(input_pass))
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('User Id and Password Can not be empty!');", true);
              
            }
            else
            {

                if (login(input_code, input_pass) == true)
                {
                    Response.Redirect("Home.aspx");
                }
                else
                {

                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('User Id and Password are not correct, pls check again!');", true);
                }
            }

        }
        catch (Exception ex)
        {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('The login process was unsuccessful, for more information please contact the administrator.');", true);
           
             }
    
    }


    public Boolean login(string id, string password)
    {
        db_connection dblog = new db_connection();
        dblog.open();
 bool i = false;
  string query = "SELECT user_id, user_name, user_code, password, active, position_id, credits FROM [_user] where active=1 and user_code=@user_code and password=@pwd";
        SqlCommand cmd = new SqlCommand(query, dblog.connection);

        cmd.Parameters.AddWithValue("@pwd", password);
        cmd.Parameters.AddWithValue("@user_code", id);
        cmd.ExecuteScalar();
        if (cmd.ExecuteScalar()!=null)
        {
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {/*
              
              Joydip Kanjilal. 
              * . How to work with Sessions in ASP.Net |
              * InfoWorld. [ONLINE] Available at: http://www.infoworld.com/article/3027516/application-development/how-to-work-with-sessions-in-aspnet.html.
              * [Accessed 12 September 2017].
              */
                System.Web.HttpContext.Current.Session["id"] = reader["user_id"];
                System.Web.HttpContext.Current.Session["username"] = reader["user_name"];
                System.Web.HttpContext.Current.Session["user_code"] = reader["user_code"];
                System.Web.HttpContext.Current.Session["position"] = reader["position_id"];
                System.Web.HttpContext.Current.Session["credits"] = reader["credits"];
                /*
                 
                 Lesson 04: Reading Data with the SqlDataReader – C# Station. 
                 * . Lesson 04: Reading Data with the SqlDataReader – C# Station. [ONLINE] Available at: http://csharp-station.com/Tutorial/AdoDotNet/Lesson04. 
                 * [Accessed 12 September 2017].
                 */
            }
            reader.Close(); dblog.close();i = true; return i;
 } 
        else 
        { i = false; return i; }
    }

    protected void register_Click(object sender, EventArgs e)
    {
        Response.Redirect("register.aspx");
    }

    protected void redirect_home(object sender, EventArgs e)
    {
        Response.Redirect("~/pages/home.aspx");
    }
}