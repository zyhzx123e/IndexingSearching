using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Data;



using Microsoft.Reporting.WebForms;
using Microsoft.Reporting.Common;
using Microsoft.Reporting;
using System.Configuration;//send email

public partial class register : System.Web.UI.Page
{



    public static int randomInt ;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public static db_connection dbRef = new db_connection();
    public SqlCommand performQuery(String query)
    {
        dbRef.open();
        SqlCommand cmd = new SqlCommand(query, dbRef.connection);
        return cmd;
    }

    protected void validation_code(object sender, EventArgs e)
    {
        if (user_name.Text == "" || user_code.Text == "" || private_email.Text == "" || searching_email.Text == "" || password1.Text == "" || dob.Text == "" || gender.Text == "" || nationality.Text == "" || address.Text == "" || contact_number.Text == "")
        {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('In Order to register , Please fill up all details!!');", true);

        }
        else
        {

            Random r = new Random();
            randomInt = r.Next(1000, 10000);//4digit >=1000  and <=9999

            sendEmailToValidate(searching_email.Text.Trim(), randomInt);
        }/*
          
          Unique 4 digit random number in c# - Stack Overflow. 
          * . Unique 4 digit random number in c# - Stack Overflow. [ONLINE] Available at: http://stackoverflow.com/questions/33749543/unique-4-digit-random-number-in-c-sharp.
          * [Accessed 11 September 2017].
          */

    }
    protected void validate(object sender, EventArgs e) {

        if (Int32.Parse((code4digit.Text.Trim())) == randomInt)
        {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Congrats! "+user_name.Text+" You can click the register button to register now!');", true);
           
            register__btn.Visible = true;


        }
        else if (Int32.Parse((code4digit.Text.Trim())) != randomInt)
        {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('"+randomInt+"  "+code4digit.Text+" Sorry the 4 digit code does not match.. please check again or click to resend');", true);
           
            register__btn.Visible = false;
        }

    }


    protected void register__btn_Click(object sender, EventArgs e) {
        /* <!--user_name``user_code``private_email``searching_email` 
         * `password``dob``gender``nationality``address``contact_number`*/


        if (user_name.Text == "" || user_code.Text == "" || private_email.Text == "" || searching_email.Text=="" || password1.Text=="" || dob.Text=="" || gender.Text=="" || nationality.Text=="" || address.Text=="" || contact_number.Text=="")
        {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('In Order to register , Please fill up all details!!');", true);
              
              }
        else
        {
            _user USER = new _user();
           
            USER.user_name = user_name.Text; USER.user_code = user_code.Text;
            USER.private_email = private_email.Text; USER.searching_email = searching_email.Text.Trim();
            USER.password = password1.Text; USER.dob = DateTime.Parse(dob.Text);
            USER.gender = Char.Parse(gender.SelectedValue.ToString()); USER.nationality = nationality.Text;
            USER.address = address.Text; USER.contact_number = contact_number.Text;
            /*
             asp.net mvc 4 - C# Insert and Retrieve a model object data  to/fro database - Stack Overflow. 
             * . asp.net mvc 4 - C# Insert and Retrieve a model object data  to/fro database - Stack Overflow. [ONLINE] Available at: http://stackoverflow.com/questions/38380907/c-sharp-insert-and-retrieve-a-model-object-as-blob-to-fro-database.
             * [Accessed 14 September 2017].
             */

            addNewUser(USER);

            sendEmail(searching_email.Text.Trim());



            /*
             
             Sending e-mails - The complete ASP.NET Tutorial. 
             * . Sending e-mails - The complete ASP.NET Tutorial. [ONLINE] Available at: http://asp.net-tutorials.com/misc/sending-mails/.
             * [Accessed 16 September 2017].
             */
            Literal Literal1 = new Literal();
            Literal1.Text = "The New User " + user_name.Text + " with ID:" + user_code.Text + " has been added, thank you";
            
            Literal Literal2 = new Literal();
            Literal2.Text = "The New User " + user_name.Text + " with ID:" + user_code.Text + " has been added, thank you";
            /*
             
             Literal Example in ASP.NET using C#. . Literal Example in ASP.NET using C#. [ONLINE] Available at: http://www.devmanuals.com/tutorials/ms/aspdotnet/literal.html.
             * [Accessed 15 September 2017].
             */
            PlaceHolder1.Controls.Add(Literal1);
            PlaceHolder2.Controls.Add(Literal1);
            /*
             YouTube. . Literal control in asp.net Part 41 - YouTube. [ONLINE] Available at: https://www.youtube.com/watch?v=n3rJybeDl2U. 
             * [Accessed 15 September 2017].
             */
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('The New User " + user_name.Text + " with ID:" + user_code.Text + " registered successful , you can check your searching email to check your ID and Password, thank you!');", true);
              

            msg.Text = "The New User " + user_name.Text + " with ID:"+user_code.Text+" has been added, thank you";
            msg1.Text = "The New User " + user_name.Text + " with ID:" + user_code.Text + " has been added, thank you";
     
        }
         System.Threading.Thread.Sleep(3000);
        Response.Redirect("login.aspx");

    }

    public void addNewUser(_user _user)
    {

        string time_now = DateTime.Now.ToString("yyyy-MM-dd");
        string dob = (_user.dob).ToString("yyyy-MM-dd");
        string query = "INSERT INTO _user (user_name,user_code,private_email,searching_email,password,dob,gender,nationality,address,member_date,contact_number,active,position_id,credits) VALUES ('" + _user.user_name + "', '" + _user.user_code + "', '" + _user.private_email + "', '" + _user.searching_email + "', '" + _user.password + "', '" + dob + "', '" + _user.gender + "', '" + _user.nationality + "', '" + _user.address + "', '" + time_now + "','" + _user.contact_number + "',1,2,0)";
        performQuery(query).ExecuteNonQuery();

        dbRef.close();
    }

    private void MessageBoxShow(string message)
    {
        this.AlertBoxMessage.InnerText = message;
        this.AlertBox.Visible = true;
    }

    protected void back_Click(object sender, EventArgs e)
    {
        Response.Redirect("login.aspx");
    }


    public void sendEmail(String email) {


                    string _id = "searchingaroundyou@gmail.com";
                    string _password = "zyhzx123e";
                    string subject = "Searching Around You ->  -WAPP Project- @2016 APU Zhang Yu Hao & Tareq Mohamed Abuzagia & Redwan Ahmed Nahian ";
                    string body = "Your<br/> UserId : <b>" + user_code.Text + "</b><br/>" + "Password : <b>" + password1.Text + "</b><hr/> <br/> If you are seeing this email, means that you can now login with your Searching Around You with the credential that you have received. This is an auto-generated non-reply email<br/><hr/> <br/><MyCloths.com.my>  Project Group Mates:<br/><br/>Zhang Yu Hao          [TP037390]  zyh860@gmail.com<br/><br/>Tareq Mohamed Abuzagia          [TP037368]  <br/>Redwan Ahmed Nahian          [TP037104]  <br/> <br/><hr/>All Rights Reserved || Searching Around You @ 2016 || Asia Pacific University || UC2F1605";
                    string smtpAddress = "smtp.gmail.com";
                    bool enableSSL = true;

                    /*
             
                       Sending e-mails - The complete ASP.NET Tutorial. 
                       * . Sending e-mails - The complete ASP.NET Tutorial. [ONLINE] Available at: http://asp.net-tutorials.com/misc/sending-mails/.
                       * [Accessed 16 September 2017].
                       */
                    try
                    {


                        using (MailMessage mail = new MailMessage())
                        {

                            mail.From = new MailAddress(_id);
                            mail.Sender = new MailAddress(_id);
                            mail.To.Add(email);
                            mail.Subject = subject;
                            mail.Body = body;
                            mail.IsBodyHtml = true;
                            mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

                            // Can set to false, if you are sending pure text.

                           // mail.Attachments.Add(new Attachment("E:\\ss\\ss\\ss\\.....txt"));


                            using (SmtpClient smtp = new SmtpClient(smtpAddress, 587))
                            {
                                smtp.Credentials = new System.Net.NetworkCredential(_id, _password);
                                smtp.EnableSsl = enableSSL;
                                smtp.Send(mail);
                                smtp.Timeout = 100000;
                            }
                        }

                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Welcome! Check Your Searching Around Email for password and Id');", true);
           
                        msg.Text = "Check Your Searching Around Email for password and Id";



                    }
                    catch (Exception ex)
                    {
                        msg.Text = "Could not send email\n\n" + ex.ToString();
                    }

    
    }

    public void sendEmailToValidate(String email,int digit)
    {


        string _id = "searchingaroundyou@gmail.com";
        string _password = "zyhzx123e";
        string subject = "Searching Around You ->  -WAPP Project- @2016 APU Zhang Yu Hao & Tareq Mohamed Abuzagia";
        string body = "Hi there! You have one step a head, Your<br/> 4 digit code is : <b>" + digit + "</b>. This is an auto-generated non-reply email<br/><hr/> <br/><MyCloths.com.my>  Project Group Mates:<br/><br/>Zhang Yu Hao          [TP037390]  zyh860@gmail.com<br/><br/> <br/><hr/>All Rights Reserved || Searching Around You @ 2016 || Asia Pacific University || UC2F1605";
        string smtpAddress = "smtp.gmail.com";
        bool enableSSL = true;


        try
        {

            /*
             
             CodeProject. . Send Mail / Contact Form using ASP.NET and C# - CodeProject. 
             * [ONLINE] Available at: https://www.codeproject.com/Tips/371417/Send-Mail-Contact-Form-using-ASP-NET-and-Csharp. 
             * [Accessed 13 September 2017].
             */
            using (MailMessage mail = new MailMessage())
            {

                mail.From = new MailAddress(_id);
                mail.Sender = new MailAddress(_id);
                mail.To.Add(email);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;
                mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

                // Can set to false, if you are sending pure text.

                // mail.Attachments.Add(new Attachment("E:\\ss\\ss\\ss\\.....txt"));


                using (SmtpClient smtp = new SmtpClient(smtpAddress, 587))
                {
                    smtp.Credentials = new System.Net.NetworkCredential(_id, _password);
                    smtp.EnableSsl = enableSSL;
                    smtp.Send(mail);
                    smtp.Timeout = 100000;
                }
            }

            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Check Your Searching Around Email and get the random generated 4 digit code for validation');", true);

            msg.Text = "Check Your Searching Around Email and get the random generated 4 digit code for validation";



        }
        catch (Exception ex)
        {
            msg.Text = "Could not send email\n\n" + ex.ToString();
        }


    }


}