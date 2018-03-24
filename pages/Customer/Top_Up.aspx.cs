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

public partial class pages_Customer_Top_Up : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["id"] != null)
        {
            Label_name.Text = Session["username"].ToString();
            Label_credits.Text = Session["credits"].ToString();

        }
        else {  
            Response.Redirect("~/pages/login.aspx");
        }
       
        

    }
    protected override void OnInit(EventArgs e)
    {

        base.OnInit(e);
        Label_name.Text = Session["username"].ToString();
        Label_credits.Text = Session["credits"].ToString();

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

            Label_name.Text = Session["username"].ToString();
            Label_credits.Text = Session["credits"].ToString();
        }

    }
    


    protected void Button1_Click(object sender, EventArgs e)
    {
        
        int newTopup;
        if (txt_card_num.Text == "" || txt_3_digit.Text == "" || txt_acct_name.Text == "" || txt_acct_num.Text == "" || txt_bank_name.Text == "" || txt_dob.Text == "" || txt_nationality.Text == "" || txt_expire.Text == "" || txt_topup.Text == "")
        {
            msg.Text = "Please fill in all the information!";
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please fill in all the information!');", true);
           
        }
        else
        {
            msg.Text = "Your Top-Up is progressing...";
            System.Threading.Thread.Sleep(5000);

            string id = Session["user_code"].ToString();
             newTopup = Convert.ToInt32(Session["credits"]);
            newTopup = newTopup + Convert.ToInt32(txt_topup.Text);
            db_connection db = new db_connection();
            db.open();
            System.Web.HttpContext.Current.Session["credits"] = newTopup;
                   
            string query = "UPDATE _user SET credits=@newCredits WHERE user_code=@userID;";
            SqlCommand cmd = new SqlCommand(query, db.connection);
            cmd.Parameters.AddWithValue("@newCredits", newTopup);
            cmd.Parameters.AddWithValue("@userID", id);

            cmd.ExecuteNonQuery();
            Session["credits"] = newTopup.ToString();
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Congrats! You have Top-Uped" + txt_topup.Text + ", now Your New Balance is :RM" + newTopup.ToString() + " ');", true);
           
  msg.Text = "Congrats! You have Top-Uped" + txt_topup.Text + ", now Your New Balance is :RM" + newTopup.ToString()+" ";
    
            db.close();

        }
      
    }
}