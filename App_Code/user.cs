using System;
using System.Collections.Generic;

using System.Web;
using System.Data.SqlClient;


public class _user
{
    public string user_name { get; set; }
    public string user_code { get; set; }

    public string private_email { get; set; }
    public string searching_email { get; set; }
    public string password { get; set; }
    public DateTime dob { get; set; }
    public char gender { get; set; }
    public string nationality { get; set; }
    public string address { get; set; }
    public string contact_number { get; set; }
    public int position_id { get; set; }
   
    public string achievement { get; set; }
    public DateTime member_date { get; set; }
    /*
     c# 3.0 - Store data into Objects based on the input C# - Stack Overflow. 
     * . c# 3.0 - Store data into Objects based on the input C# - Stack Overflow. [ONLINE] Available at: http://stackoverflow.com/questions/4209964/store-data-into-objects-based-on-the-input-c-sharp. 
     * [Accessed 08 September 2017].
     */

    public static db_connection dbRef = new db_connection();
    public  SqlCommand performQuery(String query)
    {
        dbRef.open();
        SqlCommand cmd = new SqlCommand(query, dbRef.connection);
        return cmd;
    }


	public _user()
	{
		
	}




  

}