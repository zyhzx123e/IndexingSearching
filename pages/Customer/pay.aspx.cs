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

public partial class pages_Customer_pay : System.Web.UI.Page
{


    public static db_connection dbRef = new db_connection();
    public SqlCommand performQuery(String query)
    {
        dbRef.open();
        SqlCommand cmd = new SqlCommand(query, dbRef.connection);
        return cmd;
    }
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["id"] != null)
        {


            if (!IsPostBack)
            {
                Label_name.Text = Session["username"].ToString();
                Label_credits.Text = Session["credits"].ToString();
                item_name.Text = Session["item_name"].ToString();


            } 


            string venue = Session["venue"].ToString();
            string description = Session["description"].ToString();
            string seller_available_time = Session["seller_available_time"].ToString();

            string belongs_to_whom = Session["belongs_to_whom"].ToString();

            //!postback info
            string itemName = Session["item_name"].ToString();
            double unit_price = Double.Parse(Session["unit_price"].ToString());



            txt_item_name.Text = itemName;
            txt_item_venue.Text = venue;
            txt_item_description.Text = description;
            txt_item_unit_price.Text = unit_price.ToString();
            txt_item_available.Text = seller_available_time;
            txt_item_owner.Text = belongs_to_whom;

        }

     
 
       


    }
    public string getSellerBalance(int uid)
    {
        string sellerBalance;
        string query = "SELECT credits FROM _user WHERE user_id=" + uid + "";

        sellerBalance = performQuery(query).ExecuteScalar().ToString();
        dbRef.close();
        return sellerBalance;
    }




    protected void Button1_Click(object sender, EventArgs e)
    {
        int belongs_to_whom = Int16.Parse(Session["belongs_to_whom"].ToString());

        double oldBalance;
        if (txt_item_name.Text == "" || txt_item_venue.Text == ""  ||txt_item_unit_price.Text == "" || txt_item_available.Text == "" || txt_item_owner.Text == "" || txt_item_quantity.Text == "" )
        {
            msg.Text = "Please fill in all the information!";
        }
        else
        {
            msg.Text = "Your payment is been progressing... please wait";
            System.Threading.Thread.Sleep(8000);

            string id = Session["user_code"].ToString();
            oldBalance = Convert.ToDouble(Session["credits"]);

            double qty = Double.Parse(txt_item_quantity.Text);
           
 double total_price= qty * Double.Parse(Session["unit_price"].ToString());

 double newBalance = oldBalance - total_price;

            if (newBalance >= 0)
            {
                
                string query = "UPDATE _user SET credits=" + newBalance + " WHERE user_code='"+id+"';";
                performQuery(query).ExecuteNonQuery();
                dbRef.close();

               double sellerCurrentBalance= Double.Parse(getSellerBalance(belongs_to_whom));
               double sellerFinalBalance = sellerCurrentBalance + total_price;
              
                string queryAddMoney = "UPDATE _user SET credits=" + sellerFinalBalance + " WHERE user_id=" + belongs_to_whom + ";";
               performQuery(queryAddMoney).ExecuteNonQuery();

                Literal litServices = new Literal();

                litServices.Text = "<img src='/images/qr.png' />  ";

                servicesCounts_ph.Controls.Add(litServices);
               



                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Congrats! You have paid successful with credits :" + total_price + ", now Your New Balance is :RM" + newBalance + "..');", true);
                Session["credits"] = newBalance.ToString();//update session
                msg.Text = "Congrats! You have paid successful with credits :" + total_price + ", and seller has received the credits, now Your New Balance is :RM" + newBalance+"..";
                
               
            }
            else
            {

                string query = "UPDATE _user SET credits=" + oldBalance + " WHERE user_code='"+id+"';";
                performQuery(query).ExecuteNonQuery();
                dbRef.close();

                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Sorry your payment did not pay successful and your credit balance still intact! because the amount you tring to pay are:" + total_price + ",but your balance are only left :" + oldBalance + " ...');", true);
           
                
               
            }

        }
    }
}