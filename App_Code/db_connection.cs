using System;
using System.Collections.Generic;

using System.Web;
using System.Data.Sql;
using System.Data.SqlClient;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using System.Data.SqlClient;
using System.Configuration;


using Microsoft.Reporting.WebForms;
using Microsoft.Reporting.Common;
using Microsoft.Reporting;

public class db_connection
{
    public SqlConnection connection;
    string connectionString;
	public db_connection()
	{
        search_db_init();
	}

    public void open(){

        try
        {
            connection.Open();

        }
        catch (Exception ex)
        {
           
        }
    }
     public void close(){connection.Close();}
    private void search_db_init()
    {//connectionString="Data Source=JASON-ESCOBAR;Initial Catalog=search;Integrated Security=True;Pooling=False;MultipleActiveResultSets=True" providerName="System.Data.SqlClient" />
    connectionString = "Data Source=JASON-ESCOBAR;Initial Catalog=search;Integrated Security=True;Pooling=False;MultipleActiveResultSets=True";
        connection = new SqlConnection(connectionString);
    }

    public String getConnectionString(){return this.connectionString;}
    


}