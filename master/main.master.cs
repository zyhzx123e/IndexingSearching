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

public partial class Master_pages_main : System.Web.UI.MasterPage
{

    public Literal user_li { get; set; }
    public string place_user { get; set; }
    public string application { get; set; }
    public string users_online { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {




        if(Session["id"] != null)
        {
            
            hideDiv.Visible = true;
            userMenu_btn.Text = Session["username"].ToString() + " Your Remaining Credits : RM"+Session["credits"].ToString();
            populateFunc();

            if (Session["position"] == "1")
            {
                btn_func.Visible = true;
                btn_viewCustomer.Visible = false;
                btn_manageUser.Visible = false;

            }
            if (Session["position"] == "2")
            {
                btn_func.Visible = false;
                btn_viewCustomer.Visible = false;
                btn_manageUser.Visible = false;

            }
            if (Session["position"] == "3")
            {//manager page with user management 

                btn_func.Visible = false;
                btn_viewCustomer.Visible = true;
                btn_manageUser.Visible = true;

              //  main.Attributes.Add("bgcolor","#2e6095");
            }

        }
        else
        {
           

            btn_func.Visible = false;
            btn_viewCustomer.Visible = false;
            btn_manageUser.Visible = false;
            userMenu_btn.Text = "Hi friend! You havent sign in...";
            hideDiv.Visible = false;
         
          //  Response.Redirect("~/pages/Home.aspx");
        }

     
 PlaceHolder_user.Visible = true;
       

        user_li = new Literal();
        application = Application["TotalApplications"].ToString();
        users_online = Application["TotalUserSessions"].ToString();

        user_li.Text = "<h5>Number of Users Online :  " + users_online + "</h5>";
        ////  Response.Write("Number of Applications : " + Application["TotalApplications"]+" || ");
      string place_user = user_li.Text;
        // Response.Write("Number of Users Online : " + Application["TotalUserSessions"]);


        PlaceHolder_user.Controls.AddAt(0, user_li);

    }

    protected void btn_viewServices_click(object sender, EventArgs e)
    {
        Response.Redirect("~/pages/Customer/Services.aspx");
    }
    protected void btn_viewGoods_click(object sender, EventArgs e)
    {
        Response.Redirect("~/pages/Customer/goods.aspx");
    }

    protected void btn_manageControl_click(object sender, EventArgs e)
    {
        Response.Redirect("~/pages/administrator/manageFunc.aspx");
    }
    protected void btn_viewCustomer_click(object sender, EventArgs e)
    {
        Response.Redirect("~/pages/administrator/viewCustomerInfo.aspx");
    
    }
    protected void btn_manageUser_click(object sender, EventArgs e)
    {

        Response.Redirect("~/pages/administrator/manageUser.aspx");
    }

    protected void DisplayTimeEvent(object sender, EventArgs e)
    {

        user_li = new Literal();
        application = Application["TotalApplications"].ToString();
        users_online = Application["TotalUserSessions"].ToString();
        user_li.Text = "<h5>No. of Users Online :  " + users_online + "</h5>";
       
        PlaceHolder_user.Controls.AddAt(0, user_li);
    }


    protected void populateIni(object sender, EventArgs e) {
        if (Session["username"] != null && Session["position"] != null)
        {
            userMenu_btn.Text = Session["username"].ToString() + " Your Remaining Credits : RM" + Session["credits"].ToString();
            populateFunc();
        }
        else { 
        
        //do nothing
        }
    }

    protected void populateFunc() {
        if (Int32.Parse(Session["position"].ToString()) == 1)
        {
            btn_func.Visible = true;
            btn_viewCustomer.Visible = false;
            btn_manageUser.Visible = false;
            userMenu_btn.Text = "Hi Administrator "+Session["username"].ToString() + ", Your  Credits Balance : RM" + Session["credits"].ToString();
           
        }
        else if (Int32.Parse(Session["position"].ToString()) == 3)
        {
            btn_func.Visible = false;
            btn_viewCustomer.Visible = true;
            btn_manageUser.Visible = true;
            userMenu_btn.Text = "Hi Manager " + Session["username"].ToString() + ", Your  Credits Balance: RM" + Session["credits"].ToString();
           
        }
        else {


            btn_func.Visible = false;
            btn_viewCustomer.Visible = false;
            btn_manageUser.Visible = false;
        }
        
    
    }

    protected void search_Click(object sender, EventArgs e)
    {
        try
        {
            string text = string.Empty;
            System.Text.StringBuilder txtaddress = new System.Text.StringBuilder();
            txtaddress.Append("https://www.shop.com/search/");
            if (searchtxt.Text != string.Empty)
            {
                text = searchtxt.Text.Replace(' ', '+');
                txtaddress.Append(text + ' ' + '+');
            }
            string url = txtaddress.ToString();
           // Response.Redirect(url, false);

            Literal litServices = new Literal();
            litServices.Text = "<div><iframe src='" + url + "' runat ='server' scrolling='yes' width = '1100' height = '500' frameborder='1' style='border:1' allowfullscreen> </iframe> </div>";
            link_services.Controls.Add(litServices);
        }
        catch (Exception ex)
        {
            Response.Redirect(ex.ToString());
        }
    }
}
