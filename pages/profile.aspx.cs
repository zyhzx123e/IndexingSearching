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
public partial class profile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            populateFields();
        }        
    }

    private void populateFields()
    {
        string hr_count, item_count,position_name,member_date;

        try
        {
            customer cus = new customer();

            int id = Int32.Parse(Session["id"].ToString());
            object[] info = new object[8];
            Array.Copy(cus.viewProfile(id), info, 8);


         
            db_connection db_obj = new db_connection();
            db_obj.open();

            int userID = Int32.Parse(Session["id"].ToString());


            
           
            string query1 = " SELECT Count(item_user.user_id) AS 'Number of dealed item' FROM " +
        " item_user  WHERE item_user.user_id='" + userID + "' AND item_user.action = 's'  ;";

            string query2 = " SELECT position.title from position inner join _user on _user.position_id=position.position_id where _user.user_id='"+userID+"' ";

            string query3 = " SELECT member_date from _user where _user.user_id='" + userID + "' ";


          
            SqlCommand cmd1 = new SqlCommand(query1, db_obj.connection);
            cmd1.Parameters.AddWithValue("@userID", userID);

            SqlCommand cmd2 = new SqlCommand(query2, db_obj.connection);
            cmd2.Parameters.AddWithValue("@userID", userID);

            SqlCommand cmd3 = new SqlCommand(query3, db_obj.connection);
            cmd3.Parameters.AddWithValue("@userID", userID);



            if ( (null != cmd1.ExecuteScalar()) || (null != cmd2.ExecuteScalar()) || (null != cmd3.ExecuteScalar()))
            {/*
              
              
              Multiple SQL queries asp.net c# - Stack Overflow. 
              * . Multiple SQL queries asp.net c# - Stack Overflow. 
              * [ONLINE] Available at: http://stackoverflow.com/questions/5877584/multiple-sql-queries-asp-net-c-sharp.
              * q[Accessed 04 January 2017].
              */


                item_count = cmd1.ExecuteScalar().ToString();

                position_name = cmd2.ExecuteScalar().ToString();

                member_date = cmd3.ExecuteScalar().ToString();
            
            
            items.Text = item_count;
            position_id.Text = position_name;
            member_date_lb.Text = member_date;
            }

          

            db_obj.close();

            name.Text = info[0].ToString();
            id_number.Text = info[1].ToString();
           
            privateEmail.Text = info[2].ToString();
            contactNumber.Text = info[3].ToString();
           
            dob.Text = info[5].ToString();
           
            achievements.Text = info[7].ToString();
            address.Text = info[6].ToString();
        }
        catch(Exception ex)
        {
            msg.Text = "There was something wrong.";
        }
    }
    protected void save_btn_Click(object sender, EventArgs e)
    {





        customer cus_obj = new customer();
        
        object[] cus_newInfo = new object[3];
        cus_newInfo[0]= privateEmail.Text;
        cus_newInfo[1] = address.Text;
    
        cus_newInfo[2] = contactNumber.Text;
        int userID = Int32.Parse(Session["id"].ToString());
        /*
         Passing Arrays as Arguments (C# Programming Guide).
         * Passing Arrays as Arguments (C# Programming Guide). [ONLINE] Available at: https://msdn.microsoft.com/en-us/library/hyfeyz71.aspx. 
         * [Accessed 31ffffffffffffffffffffffeeeeeeeeee September 2017].
         */
        try
        {
            cus_obj.editProfile(userID, cus_newInfo);

            msg.Text = "Your details has been updated, thank you!";
        } 
        catch(Exception ex)
        {
            msg.Text = "Information could not be updated, error: " + ex.Message;
        }
        
  
    }


   

    protected void working_hr_Click(object sender, EventArgs e)
    {
        
    
    }
    protected void item_count_btn_Click(object sender, EventArgs e)
    {

        string item_count;
        db_connection db_obj = new db_connection();
        db_obj.open();

        string fromDate = item_countfromDate.Text;
        string toDate = item_counttoDate.Text;
        int userID = Int32.Parse(Session["id"].ToString());



        //
        string query = " SELECT Count(user_id) AS 'Number of dealed items' FROM " +
        " item_user  WHERE item_user.user_id='" + userID + "' AND item_user.action = 's' AND date between '" + fromDate + " 00:00:00' and '" + toDate + " 23:59:00' ;";
        /*
         get the number of items in count in time range 
         * Selecting records between two date range query.
         * . Selecting records between two date range query. [ONLINE] Available at: http://www.plus2net.com/sql_tutorial/between-date.php.
         * [Accessed 23 September 2017].
         
         */
        SqlCommand cmd = new SqlCommand(query, db_obj.connection);
        cmd.Parameters.AddWithValue("@userID", userID);

        if ((null != cmd.ExecuteScalar()) && (cmd.ExecuteScalar().ToString() != "0"))
        {
            item_count = cmd.ExecuteScalar().ToString() + " deals were donw by you";
        }
        else
        {
            item_count = "You did not deal any deals from the duration!";
        }
        item_count_label.Text = item_count;

        db_obj.close();
    }
}