using System;
using System.Collections.Generic;

using System.Web;
using System.Data.SqlClient;

public class customer : _user
{
	public customer()
	{
		
	}

    public object[] viewProfile(int cus_id)
    {
        object[] customer_profile_info = new object[8];

        db_connection db_obj = new db_connection();
        db_obj.open();

        string query = "SELECT user_name, user_code, private_email, searching_email, contact_number, dob,  address, achievements  FROM _user WHERE user_id = @userID; ";
        SqlCommand cmd = new SqlCommand(query, db_obj.connection);
        /*
        MSDN.
        SqlParameterCollection.AddWithValue Method (String, Object) (System.Data.SqlClient). 2016.
         [ONLINE] Available at: https://msdn.microsoft.com/en-us/library/system.data.sqlclient.sqlparametercollection.addwithvalue(v=vs.110).aspx. [Accessed 05 September 2017].
        */
        cmd.Parameters.AddWithValue("@userID", cus_id);
        SqlDataReader reader = cmd.ExecuteReader();
        while(reader.Read())
        {//obj array store and pass data by obj array
            customer_profile_info[0] = reader["user_name"];
            customer_profile_info[1] = reader["user_code"];
          
            customer_profile_info[2] = reader["private_email"];

            customer_profile_info[3] = reader["contact_number"];
            customer_profile_info[4] = reader["searching_email"];
            customer_profile_info[5] = reader["dob"];
        
            customer_profile_info[6] = reader["address"];
            customer_profile_info[7] = reader["achievements"];
        
        }
        
        db_obj.close();

        return customer_profile_info;
    }
    /*
     C# function parameter Array vs List - Stack Overflow. 2016. 
     * [ONLINE] Available at: http://stackoverflow.com/questions/29896045/c-sharp-function-parameter-array-vs-list. [Accessed 23 September 2017].
     */
    public void editProfile(int id, object[] newInfo)
    {
        db_connection db_obj = new db_connection();
        db_obj.open();

        string query = "UPDATE _user SET private_email = @newPrivateEmail, address=@newAddress,  contact_number=@newNumber WHERE user_id = @userID;";
        /*
        MSDN.
        SqlParameterCollection.AddWithValue Method (String, Object) (System.Data.SqlClient). 2016.
         [ONLINE] Available at: https://msdn.microsoft.com/en-us/library/system.data.sqlclient.sqlparametercollection.addwithvalue(v=vs.110).aspx. [Accessed 05 September 2017].
        */
        SqlCommand cmd = new SqlCommand(query, db_obj.connection);
        cmd.Parameters.AddWithValue("@newPrivateEmail", newInfo[0]);
        cmd.Parameters.AddWithValue("@newAddress",newInfo[1] );
         
        cmd.Parameters.AddWithValue("@newNumber",newInfo[2]);
        cmd.Parameters.AddWithValue("@userID", id);

        cmd.ExecuteNonQuery();

        db_obj.close();
    }

   

}