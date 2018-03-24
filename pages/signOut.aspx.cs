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
public partial class signOut : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        HttpContext.Current.Session.Clear();
        HttpContext.Current.Session.Abandon();
        HttpContext.Current.User = null;
        System.Web.Security.FormsAuthentication.SignOut();
    }

    protected void register__btn_Click(object sender, EventArgs e) {
        Response.Redirect("~/pages/login.aspx");
    }
}