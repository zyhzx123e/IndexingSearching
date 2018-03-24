<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        // Code that runs on application startup

        Application["TotalApplications"] = 0;
        Application["TotalUserSessions"] = 0;
        //Reference from By: Suresh Dasari Nov 26, 2013 
        //it use the HttpApplicationState HttpApplication.Application to get the current state of web-app and save the sate 
        //refer from http://www.aspdotnet-suresh.com/2013/11/aspnet-count-number-of-online-users.html
    

        Application["TotalApplications"] = (int)Application["TotalApplications"] + 1;


      
    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // Code that runs when an unhandled error occurs

    }
    

    void Session_Start(object sender, EventArgs e) 
    {
        
        // Code that runs when a new session is started
        Application["TotalUserSessions"] = (int)Application["TotalUserSessions"] + 1;


    }

    void Session_End(object sender, EventArgs e) 
    {

        //Rferfenced from http://stackoverflow.com/questions/10481351/counting-online-users-using-asp-net
        //count online users when they access the page 
        //abandon the session when they leave the website
        Session.Clear();
        Session.Abandon();
        Session.RemoveAll();
        Application["TotalUserSessions"] = (int)Application["TotalUserSessions"] - 1;

        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }
       
</script>
