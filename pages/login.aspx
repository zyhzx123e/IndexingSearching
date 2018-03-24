<%@ Page Title="Login" Language="C#" MasterPageFile="~/master/base.master" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="pages_common_login" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
      <link href="css/login.css" type="text/css" rel="Stylesheet" />

    <!--init_fade_in-->
<script type="text/javascript" src="js/jquery-1.12.3.js"></script>
   
                             <style type="text/css">
.modalBackground
{
    background-color:olive;
    filter:alpha(opacity=50);

    opacity:0.5;
}
     #mp1 
{
    background-color:lightgray; 
   
}
       .popForm 
{
    background-color:lightgray; 
   
}
       </style>    

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="userMenuContent" Runat="Server">
     
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="content" Runat="Server">
  
    <div style="background-image:url(../images/bg.jpg);  " >      
        <div class="container row row-centered">
            <div class="col-md-6 col-centered" id="loginForm">
               <div class="row">
                   <hr /><br /><br />
                   <div class="col-md-12">
                     
                      <h2>  Welcome to the <div id="intro">Barter World</div></h2>
                      <hr />
                        <a href="~/pages/Home.aspx" runat="server" >
                      <img src="../images/login.PNG" class="frontImage" /></a>
                      <hr />
                      <div class="form-group">
                            <asp:TextBox ID="iDNumber" CssClass="form-control" placeholder="Your ID" runat="server"></asp:TextBox>
                       </div>
                       <div class="form-group">
                            <asp:TextBox ID="password" TextMode="Password" CssClass="form-control" placeholder="Password" runat="server"></asp:TextBox>
                 </div>
                      
                     
                <div class="form-group"> 
                    <asp:Button ID="login_btn" CssClass="center col-md-4 btn btn-success" Height="40px" Width="150px" Text="Login" OnClick="log_Click" runat="server" />
                      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="register_btn" CssClass="center col-md-4 btn btn-info" Height="40px" Width="150px" Text="Register" OnClick="register_Click" runat="server" />
         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                     <asp:Button ID="btn_browse"  OnClick="redirect_home" CssClass="center col-md-4 btn btn-warning" Height="40px" Text="Browse the Website 1st" runat="server"  ToolTip="Website without log in but cannot purchase and trade any thing" />
        <br /> 
                    </div>  
                    
                      <br /> 
                   
                           <asp:Label ID="msg" runat="server" CssClass="warningLbl alert-danger"></asp:Label>
                       <br />

                            
  
                   </div>
               </div>
            </div>
        </div>
    </div>
              
   
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="pageScripts" Runat="Server">
</asp:Content> 