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

public partial class pages_Home : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["username"] != null) { 
            username_lbl.Text = Session["username"].ToString();
           //retreive user data from session and display its name on the screen
        }
        else {  
            //non_register_user
            
        }
           
       }

   
    protected void serviceLinkBtn_Click(object sender, EventArgs e)
    {
       
    }
}