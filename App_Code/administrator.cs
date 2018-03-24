using System;
using System.Collections.Generic;

using System.Web;

using System.Data.Sql;
using System.Data.SqlClient;

public class administrator : _user
{
    db_connection dbRef = new db_connection();
	public administrator()
	{
		
	}

    
    public void deleteUser(int id)
    {
        dbRef.open();
        /*
         MSDN.
         SqlParameterCollection.AddWithValue Method (String, Object) (System.Data.SqlClient). 2016.
          [ONLINE] Available at: https://msdn.microsoft.com/en-us/library/system.data.sqlclient.sqlparametercollection.addwithvalue(v=vs.110).aspx. [Accessed 05 September 2017].
         */
        string query = "UPDATE _user SET active=0 WHERE user_id=@id;";
        SqlCommand cmd = new SqlCommand(query, dbRef.connection);
        cmd.Parameters.AddWithValue("@id", id);

        cmd.ExecuteNonQuery();
        dbRef.close();
    }

    public void editUser(int id, object[] newInfo) 
    {
       dbRef.open();

        string query = "UPDATE _user set position_id=@positionID,  password=@newPass, achievements=@achievement "
        + "WHERE user_id=@id;";
        SqlCommand cmd = new SqlCommand(query, dbRef.connection);

        /*
        MSDN.
        SqlParameterCollection.AddWithValue Method (String, Object) (System.Data.SqlClient). 2016.
         [ONLINE] Available at: https://msdn.microsoft.com/en-us/library/system.data.sqlclient.sqlparametercollection.addwithvalue(v=vs.110).aspx. [Accessed 05 September 2017].
        */
        cmd.Parameters.AddWithValue("@id", id);
        cmd.Parameters.AddWithValue("@positionID", newInfo[0]);
       
        cmd.Parameters.AddWithValue("@newPass", newInfo[1]);
        cmd.Parameters.AddWithValue("@achievement", newInfo[2]);
       
        cmd.ExecuteNonQuery();

        dbRef.close();
    }

  
}