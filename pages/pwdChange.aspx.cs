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

public partial class pwdChange : System.Web.UI.Page
{

    _user userObject = new _user();
    public static db_connection dbRef = new db_connection();
    public static SqlCommand performQuery(String query)
    {

        dbRef.open();
        SqlCommand cmd = new SqlCommand(query, dbRef.connection);
        return cmd;
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void changePassword(int id, string newPassword)
    {


        string query = "UPDATE _user SET password='" + newPassword + "' WHERE user_id=" + id + ";";

        performQuery(query).ExecuteNonQuery();

        dbRef.close();
    }

    protected void change_password_btn_Click(object sender, EventArgs e)
    {
       
        int user_id = Int32.Parse(Session["id"].ToString());
        if (old_pass.Text != verifyPassword(user_id))
        {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Your original password is incorrect, please provide the correct password in order to be able to change your password.');", true);
           
            msg.Text = "Your original password is incorrect, please provide the correct password in order to be able to change your password.";
        }else
        {
            try
            {
                if(new_pass.Text == verify_new_pass.Text)
                {
                    changePassword(user_id, new_pass.Text);
                    emptyForm();
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Your password has been changed.');", true);
           
                    msg.Text = "Your password has been changed.";
                }else
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Your new passwords do not match!, please retype again..');", true);
           
                    msg.Text = "Your new passwords do not match!, please retype again.";
                }
            }
            catch(Exception ex)
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('There was something wrong, error: " + ex.Message + "..');", true);
           
                msg.Text = "There was something wrong, error: " + ex.Message+" " ;
            }
        }
    }

    protected string verifyPassword(int id)
    {
        string old_password = "";
       

        string query = "SELECT password FROM _user WHERE user_id="+id+"";

        SqlDataReader reader = performQuery(query).ExecuteReader();
        while(reader.Read())
        {
            old_password = reader["password"].ToString();
        }

        dbRef.close();
        return old_password;
    }

    protected void emptyForm()
    {
        old_pass.Text = "";
        new_pass.Text = "";
        verify_new_pass.Text = "";
    }
}