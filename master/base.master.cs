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

public partial class Master_pages_base : System.Web.UI.MasterPage
{

    public string bg() {
       
        if (Session["id"] != null)
        {
            if (Session["position"].ToString().Equals("1"))
            {
                return "bg_admin.jpg";
            }
            else if (Session["position"].ToString().Equals("2"))
            {
                return "bg.jpg";
            }
            else
            {
                return "bg_mgr.jpg";
            }

        } return "bg.jpg";
        /*
         The Official Forums for Microsoft ASP.NET. . Set background-image of body in code-behind file | The ASP.NET Forums. [ONLINE] Available at: https://forums.asp.net/t/1878343.aspx?Set+background+image+of+body+in+code+behind+file. 
         * [Accessed 09 September 2017].
         */
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        homeLink.NavigateUrl = ResolveUrl("~/pages/home.aspx");
        
      //  System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('position:  " + Session["position"] + "y!');", true);
              
      //  Response.Write(Session["position"]);

      
    }


    

}
