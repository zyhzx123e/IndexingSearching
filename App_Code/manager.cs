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


public class manager : _user
{




    db_connection dbRef = new db_connection();
	public manager()
	{
		
	}

    
    public void deleteUser(int id)
    {
        dbRef.open();

        string query = "UPDATE _user SET active=0 WHERE user_id=@id;";
        SqlCommand cmd = new SqlCommand(query, dbRef.connection);
        cmd.Parameters.AddWithValue("@id", id);
        /*
        MSDN.
        SqlParameterCollection.AddWithValue Method (String, Object) (System.Data.SqlClient). 2016.
         [ONLINE] Available at: https://msdn.microsoft.com/en-us/library/system.data.sqlclient.sqlparametercollection.addwithvalue(v=vs.110).aspx. [Accessed 05 September 2017].
        */
        cmd.ExecuteNonQuery();
        dbRef.close();
    }

    public void editUser(int id, object[] newInfo) 
    {
        /*
         c# - Pass Array Parameter in SqlCommand - Stack Overflow. 2016.
                 * Stack Overflow. 
         * [ONLINE] Available at: http://stackoverflow.com/questions/2377506/pass-array-parameter-in-sqlcommand. [Accessed 14 September 2017].
         */

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