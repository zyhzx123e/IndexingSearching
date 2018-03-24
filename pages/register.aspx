<%@ Page Title="Register" Language="C#" MasterPageFile="~/master/base.master" AutoEventWireup="true" CodeFile="register.aspx.cs" Inherits="register" %>
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
    <style type="text/css">
            .alertBox
            {
                position: absolute;
                top: 100px;
                left: 50%;
                width: 500px;
                margin-left: -250px;
                background-color: #fff;
                border: 1px solid #ccc;
                border-radius: 4px;
                box-sizing: border-box;
                padding: 4px 8px;
            }
        </style>
        <script type="text/javascript">
            function closeAlert(e) {
                e.preventDefault();
                this.parentNode.style.display = "none";
            }
        </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="userMenuContent" Runat="Server">
     
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="content" Runat="Server">
  
    <div class="container">      
        <div class="row row-centered">
            <div class="col-md-6 col-centered" id="loginForm">
               <div class="row">
                   <hr /><br /><br />
                   <div class="col-md-12">
                     
                      <h2>  Welcome to the Registration Page of Search Around You</h2>
                      <hr />
                      <img src="../../images/login.PNG" class="frontImage" />
                      <hr />
                      <div id="intro">

                            <h3>>>  Click Here to Register:<br/>
                               <div class="col-md-12 col-centered" >  <asp:Button ID="register_btn" CssClass="center col-md-4 btn btn-info" Height="100px" Text="Register" runat="server" Font-Size="XX-Large" ForeColor="Yellow" />
        </div> 
                            </h3>
                       
                       </div> 

                    <hr/>
                      <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>

                      <br /> 
                           <asp:Label ID="msg" runat="server" CssClass="warningLbl alert-danger"></asp:Label>
                       <br />

                            
  
                   </div>
               </div>
            </div>
        </div>
    </div>
              

   <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

   <!--
       modal popup control example referenced from
       https://www.codeproject.com/Articles/34996/ASP-NET-AJAX-Control-Toolkit-ModalPopupExtender-Co
       
       -->
    <cc1:modalpopupextender ID="mp1" runat="server" PopupControlID="register_panel" TargetControlID="register_btn" CancelControlID="btnClose" BackgroundCssClass="modalBackground"></cc1:modalpopupextender>
      
    <asp:Panel ID="register_panel" runat="server" CssClass="popForm" style ='display:none' align="center" ScrollBars="Vertical" >      
            <h2>Registration Page</h2>
            <hr />
            <div class="form-group form-inline">
                <asp:Label Text="User Real Name" runat="server"></asp:Label>
                <asp:TextBox ID="user_name" placeholder="Enter Your Full Name" CssClass="form-control" runat="server"></asp:TextBox>
            </div>

            <div class="form-group form-inline">
                <asp:Label Text="User ID" runat="server"></asp:Label>
                <asp:TextBox ID="user_code" placeholder="User Id that you would use to sign in" CssClass="form-control" runat="server"></asp:TextBox>
           
                  <asp:Label Text="Password" runat="server"></asp:Label>
                <asp:TextBox ID="password1" placeholder="Enter Password" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox>
            
             <asp:Label Text="Confirm Password" runat="server"></asp:Label>
                <asp:TextBox ID="password2" placeholder="Confirm your password!" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox>
           
          <asp:CompareValidator ID="CompareValidator1" runat="server" 
     ControlToValidate="password1"
     CssClass="ValidationError"
     ControlToCompare="password2"
     ErrorMessage="Both Password Not Match!!!" 
     ToolTip="Password must be the same" />

    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
     ErrorMessage="&laquo; (Password are Required)" 
     ControlToValidate="password2"
     CssClass="ValidationError"
     ToolTip="Compare Password is a REQUIRED field">
    </asp:RequiredFieldValidator>
                 </div>

            <div class="form-group form-inline">
                <asp:Label Text="User Frequently Use Email" runat="server"></asp:Label>
                <asp:TextBox ID="private_email" placeholder="Enter your frequently used email" CssClass="form-control" runat="server"></asp:TextBox>
           
                <asp:Label Text="'Searching Email' use in this website" runat="server"></asp:Label>
                <asp:TextBox ID="searching_email" placeholder="Enter the email that you would use here" CssClass="form-control" runat="server"></asp:TextBox>
          
                  <asp:Label Text="Contact Number" runat="server"></asp:Label>
                <asp:TextBox ID="contact_number" placeholder="Enter Your Contact Number" CssClass="form-control" runat="server"></asp:TextBox>
          
                  </div>
        
              

                <div class="form-group form-inline">
                <asp:Label Text="Date of Birth" runat="server"></asp:Label>
          <asp:TextBox ID="dob" placeholder="eg. 1996-06-30  " CssClass="datepicker form-control" runat="server"></asp:TextBox>
                   
                <asp:Label Text="Gender" runat="server"></asp:Label>
                <asp:DropDownList ID="gender" placeholder="eg. M (M:Male, F:Female||Only Single Character is accepted!)" CssClass="form-control" runat="server">
                     <asp:ListItem Value="M">Male</asp:ListItem>
                     <asp:ListItem Value="F">Female</asp:ListItem>
                </asp:DropDownList>

                <asp:Label Text="Nationality" runat="server"></asp:Label>
                <asp:TextBox ID="nationality" placeholder="Enter Your motherland Country name" CssClass="form-control" runat="server"></asp:TextBox>
           
                <asp:Label Text="Address" runat="server"></asp:Label>
                <asp:TextBox ID="address" TextMode="MultiLine" Columns="30" Rows="3" placeholder="Enter Your current address" CssClass="form-control" runat="server"></asp:TextBox>
            </div>

         
               

        <div class="form-group form-inline">
        <asp:PlaceHolder ID="PlaceHolder2" runat="server"></asp:PlaceHolder>
            </div>
       

            <div class="form-group form-inline">
                <asp:Button ID="register__btn" CssClass="btn btn-success" Text="Register Now!" runat="server" OnClick="register__btn_Click" Visible="False" />
               
                 <asp:Button ID="btnClose" runat="server" CssClass="btn btn-danger" Text="Cancel" />
            
                <asp:Label ID="msg1" runat="server" CssClass="warningLbl alert-danger"></asp:Label>
             
                 </div><br/>
         <div class="form-group center-block">
          <asp:Button ID="sendcode" CssClass="btn btn-info" Text="send the 4 digit code to my searching email" runat="server" OnClick="validation_code" Visible="True" />
              <asp:TextBox ID="code4digit" placeholder="Enter the 4 digit code here..." CssClass="form-control" runat="server"></asp:TextBox>
           
                  <asp:Button ID="validateBtn" CssClass="btn btn-info" Text="Click me to check the 4Digit code for registration!" runat="server" OnClick="validate" Visible="True" />
            </div>    
                 <div runat="server" id="AlertBox" class="alertBox" Visible="false">
    <div runat="server" id="AlertBoxMessage"></div>
    <button onclick="closeAlert.call(this, event)">Ok</button>
</div>
        </asp:Panel> 
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="pageScripts" Runat="Server">
</asp:Content> 