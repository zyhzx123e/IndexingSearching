using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data;

using System.Data.SqlClient;
using System.Configuration;


using Microsoft.Reporting.WebForms;
using Microsoft.Reporting.Common;
using Microsoft.Reporting;
public partial class manageUser : System.Web.UI.Page
{
    db_connection db_obj = new db_connection();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            populateUserList();
            populateListBox();
        }

        if (Session["id"] == null)
        {
            Response.Redirect("~/pages/login.aspx");   /*
             c# - How to access session variables from any class in ASP.NET? - Stack Overflow. 2016. 
             * c# - How to access session variables from any class in ASP.NET? - Stack Overflow. 
             * [ONLINE] Available at: http://stackoverflow.com/questions/621549/how-to-access-session-variables-from-any-class-in-asp-net. [Accessed 01 Nov 2017].
             */
        }
    }

    public static db_connection dbRef = new db_connection();
    public SqlCommand performQuery(String query)
    {
        dbRef.open();
        SqlCommand cmd = new SqlCommand(query, dbRef.connection);
        return cmd;
    }


    protected void add_user__btn_Click(object sender, EventArgs e)
    {


        if (user_name.Text == "" || user_code.Text == "" || private_email.Text == "" || searching_email.Text == "" || password1.Text == "" || dob.Text == "" || gender.Text == "" || nationality.Text == "" || address.Text == "" || contact_number.Text == "")
        {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert(' Please fill up all details!!');", true);

        }
        else
        {
            _user USER = new _user();
          
            USER.user_name = user_name.Text; USER.user_code = user_code.Text;
            USER.private_email = private_email.Text; USER.searching_email = searching_email.Text.Trim();
            USER.password = password1.Text; USER.dob = DateTime.Parse(dob.Text);
            USER.gender = Char.Parse(gender.SelectedValue.ToString());
            USER.nationality = nationality.Text;
            USER.position_id = Convert.ToInt16(position_txt.SelectedValue);
            USER.address = address.Text;
            USER.contact_number = contact_number.Text;


            addNewUser(USER);

         


            Literal Literal1 = new Literal();
            Literal1.Text = "The New User " + user_name.Text + " with ID:" + user_code.Text + " has been added, thank you";

            Literal Literal2 = new Literal();
            Literal2.Text = "The New User " + user_name.Text + " with ID:" + user_code.Text + " has been added, thank you";

           // PlaceHolder1.Controls.Add(Literal1);
            PlaceHolder2.Controls.Add(Literal1);

          

            msg.Text = "The New User " + user_name.Text + " with ID:" + user_code.Text + " has been added, thank you";
            msg1.Text = "The New User " + user_name.Text + " with ID:" + user_code.Text + " has been added, thank you";

        }
        System.Threading.Thread.Sleep(3000);

}


    public void addNewUser(_user _user)
    {

        string time_now = DateTime.Now.ToString("yyyy-MM-dd");
       
        string dob = (_user.dob).ToString("yyyy-MM-dd");
        string query = "INSERT INTO _user (user_name,user_code,private_email,searching_email,password,dob,gender,nationality,address,member_date,contact_number,active,position_id,credits) VALUES ('" + _user.user_name + "', '" + _user.user_code + "', '" + _user.private_email + "', '" + _user.searching_email + "', '" + _user.password + "', '" + dob + "', '" + _user.gender + "', '" + _user.nationality + "', '" + _user.address + "', '" + time_now + "','" + _user.contact_number + "',1,"+_user.position_id+",0)";
        performQuery(query).ExecuteNonQuery();

        dbRef.close();
        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('User has been Added');", true);
           
    }


   
    protected void populateUserList()
    {
        /*Mudassar Ahmed Khan. 2016. Bind (Populate) ASP.Net DropDownList using DataTable (DataSet) in C# and VB.Net. 
         * [ONLINE] Available at: http://www.aspsnippets.com/Articles/Bind-Populate-ASPNet-DropDownList-using-DataTable-DataSet-in-C-and-VBNet.aspx.
         * [Accessed 09 September 2017].*/
        db_obj.open();
        string query = "SELECT user_id, user_name FROM _user WHERE active=1";
        SqlCommand cmd = new SqlCommand(query, db_obj.connection);//only show active users

        SqlDataReader reader = cmd.ExecuteReader();

        userDropList.DataSource = reader;
        userDropList.DataTextField = "user_name";
        userDropList.DataValueField = "user_id";
        userDropList.DataBind();
        userDropList.Items.RemoveAt(0);
        userDropList.Items.Insert(0, new ListItem("SELECT", "N/A"));
        db_obj.close();
    }

     protected void userDropList_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (userDropList.SelectedIndex != 0)
        {
            int user_id = int.Parse(userDropList.SelectedValue);
            Session["selectedUser"] = user_id;
            try
            {
                db_obj.open();
                string query = "SELECT user_name, position_id, password, achievements FROM _user WHERE user_id=@id ;";
                SqlCommand cmd = new SqlCommand(query, db_obj.connection);
                cmd.Parameters.AddWithValue("@id", user_id);
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();

                usernameText.Text = reader["user_name"].ToString();
                userRoleDropList.SelectedValue = reader["position_id"].ToString();
              
                userPassword.Text = reader["password"].ToString();
                achievements.Text = reader["achievements"].ToString();
               

                reader.Close();
                db_obj.close();

                delete.Enabled = true;
                save.Enabled = true;
            }
            catch (Exception ex)
            {
                msg.Text = "There was something wrong while retrieveing the user details. Error: " + ex.Message;
            }
        }
        
    }

    //populate positions list box with values from DB
    protected void populateListBox()
    {
        /*Mudassar Ahmed Khan. 2016. Bind (Populate) ASP.Net DropDownList using DataTable (DataSet) in C# and VB.Net. 
          * [ONLINE] Available at: http://www.aspsnippets.com/Articles/Bind-Populate-ASPNet-DropDownList-using-DataTable-DataSet-in-C-and-VBNet.aspx.
          * [Accessed 09 September 2017].*/
        db_obj.open();

        string query = "SELECT * FROM position";
        SqlCommand cmd = new SqlCommand(query, db_obj.connection);
        SqlDataReader reader = cmd.ExecuteReader();

        userRoleDropList.DataSource = reader;
        userRoleDropList.DataTextField = "title";
        userRoleDropList.DataValueField = "position_id";
        userRoleDropList.DataBind();

        reader.Close();
        db_obj.close();
    }

    protected void delete_Click(object sender, EventArgs e)
    {
        administrator admin = new administrator();
        int user_id = int.Parse(userDropList.SelectedValue);
        try
        {
            if(user_id==1)
            {
                msg.Text = "Administrator account cannot be deleted!";
            }
            else
            {
                admin.deleteUser(user_id);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('You have just deleted user " + usernameText.Text+ "');", true);
           
                Response.Redirect(Request.RawUrl);
            }
        } 
        catch(Exception ex)
        {
            msg.Text = "User could not be deleted, error: " + ex.Message;
        }
    }

    protected void save_Click(object sender, EventArgs e)
    {
        administrator admin = new administrator();
        int user_id = int.Parse(Session["selectedUser"].ToString());

        try
        {
            object[] updated_info = new object[3];
            updated_info[0] = userRoleDropList.SelectedValue;
          
            updated_info[1] = userPassword.Text;
            updated_info[2] = achievements.Text;
            

            admin.editUser(user_id, updated_info);
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('You have saved User info');", true);
           
            Response.Redirect(Request.RawUrl);
            
        }
        catch(Exception ex)
        {
            msg.Text = "User details cannot be updated, error: "+ ex.Message;
        }
    }

   
}