<%@ Page Title="Manage Users" Language="C#" MasterPageFile="~/master/main.master" AutoEventWireup="true" CodeFile="manageUser.aspx.cs" Inherits="manageUser" %>

<asp:Content ID="Content2" ContentPlaceHolderID="page_head" Runat="Server">
     <!-- CSS for datepicker JQuery item -->
     <link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css">
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
       .addForm 
{
    background-color:lightgray; 
   
}
            .updateForm 
{
    background-color:orange; 
   
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

<asp:Content ID="Content1" ContentPlaceHolderID="pageContent" Runat="Server">
       
    <div class="col-md-6" >
            
         <asp:Panel ID="Panel1" runat="server" Width="600" height="680" CssClass="updateForm" align="center"  >      
         
        <div class="row row-centered">
            <div class="col-md-8 col-centered" >
               <div class="row">
                    <h2>Manage Users</h2>
                        <hr />
                <div class="form-group">
                    <asp:DropDownList CssClass="form-control" AutoPostBack="true" ID="userDropList" runat="server" OnSelectedIndexChanged="userDropList_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
           
                
           
                <h3>User details:</h3>
                <div class="form-group form-inline">
                    <asp:Label AssociatedControlID="usernameText" CssClass="col-md-3" Text="Full Name" runat="server"></asp:Label>
                    <asp:TextBox ID="usernameText" CssClass="form-control" Enabled="false" runat="server"></asp:TextBox>
               <br/>
                      <asp:Button Text="Delete This User" ID="delete" CssClass="btn btn-danger pull-right" runat="server" Enabled="false" OnClick="delete_Click" />
                      
                </div>
                    
                <div class="form-group form-inline">
                    <asp:Label AssociatedControlID="userRoleDropList" CssClass="col-md-3" Text="Role" runat="server"></asp:Label>
                    <asp:DropDownList ID="userRoleDropList" CssClass="form-control" runat="server">
                        <asp:ListItem>Role</asp:ListItem>
                    </asp:DropDownList><br/>
                     <asp:Button Text="Submit Changes" ID="save" CssClass="btn btn-primary pull-right" Enabled="false" runat="server" OnClick="save_Click" />
                      
                </div>
               
                <div class="form-group form-inline">
                    <asp:Label AssociatedControlID="userPassword" CssClass="col-md-3" Text="Passowrd" runat="server"></asp:Label>
                    <asp:TextBox ID="userPassword" CssClass="form-control" runat="server"></asp:TextBox>
               </div>
                <div class="form-group form-inline">
                    <asp:Label AssociatedControlID="achievements" CssClass="col-md-3" Text="Sales Achievemnet" runat="server"></asp:Label>
                    <asp:TextBox ID="achievements" CssClass="form-control"  TextMode="MultiLine" runat="server"></asp:TextBox>
                </div>
                
                <div class="form-group">
                    <div class="container">
                          <asp:Label ID="msg" runat="server"></asp:Label>
                    </div>
                </div>
                  
                   
                     </div>
            </div>


        </div>
   </asp:Panel>
    </div>




    <div class="col-md-6" >
               <div class="row">
          <asp:Panel ID="register_panel" runat="server" Width="700" height="680" CssClass="addForm" align="center" ScrollBars="Vertical" >      
            <h2> ||Add a New User||</h2>
            <hr />
            <div class="form-group form-inline">
                <asp:Label Text="User Real Name" runat="server"></asp:Label>
                <asp:TextBox ID="user_name" placeholder="Enter User Full Name" CssClass="form-control" runat="server"></asp:TextBox>
            </div>

            <div class="form-group form-inline">
                <asp:Label Text="User ID" runat="server"></asp:Label>
                <asp:TextBox ID="user_code" placeholder="User Id that User would use to sign in" CssClass="form-control" runat="server"></asp:TextBox>
           <br/>
                  <asp:Label Text="Password" runat="server"></asp:Label>
                <asp:TextBox ID="password1" placeholder="Enter Password" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox>
            <br/>
             <asp:Label Text="Confirm Password" runat="server"></asp:Label>
                <asp:TextBox ID="password2" placeholder="Confirm User password!" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox>
           <br/>
          <asp:CompareValidator ID="CompareValidator1" runat="server" 
     ControlToValidate="password1"
     CssClass="ValidationError"
     ControlToCompare="password2"
     ErrorMessage="Both Password Not Match!!!" 
     ToolTip="Password must be the same" />
                <br/>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
     ErrorMessage="&laquo; (Password are Required)" 
     ControlToValidate="password2"
     CssClass="ValidationError"
     ToolTip="Compare Password is a REQUIRED field">
    </asp:RequiredFieldValidator>
                 </div>

            <div class="form-group form-inline">
                <asp:Label Text="User Frequently Use Email" runat="server"></asp:Label>
                <asp:TextBox ID="private_email" placeholder="Enter User frequently used email" CssClass="form-control" runat="server"></asp:TextBox>
           <br/>
                <asp:Label Text="'Searching Email' use in this website" runat="server"></asp:Label>
                <asp:TextBox ID="searching_email" placeholder="Enter the email that User would use in Searching Around You" CssClass="form-control" runat="server"></asp:TextBox>
          <br/>
                  <asp:Label Text="Contact Number" runat="server"></asp:Label>
                <asp:TextBox ID="contact_number" placeholder="Enter User Contact Number" CssClass="form-control" runat="server"></asp:TextBox>
          
                <br />
                 <asp:Label Text="Position" runat="server"></asp:Label>
                <asp:DropDownList ID="position_txt" placeholder="(1:admin || 2:customer || 3:manager)" CssClass="form-control" runat="server">
                     <asp:ListItem Value="1">Administrator</asp:ListItem>
                     <asp:ListItem Value="2">Customer</asp:ListItem>
                     <asp:ListItem Value="3">Manager</asp:ListItem>
                </asp:DropDownList>
                  </div>
        
              

                <div class="form-group form-inline">
                <asp:Label Text="Date of Birth" runat="server"></asp:Label>
          <asp:TextBox ID="dob" placeholder="eg. 1996-06-30  " CssClass="datepicker form-control" runat="server"></asp:TextBox>
                   <br/>
                <asp:Label Text="Gender" runat="server"></asp:Label>
                <asp:DropDownList ID="gender" placeholder="eg. M (M:Male, F:Female||Only Single Character is accepted!)" CssClass="form-control" runat="server">
                     <asp:ListItem Value="M">Male</asp:ListItem>
                     <asp:ListItem Value="F">Female</asp:ListItem>
                </asp:DropDownList>
                    <br/>
                <asp:Label Text="Nationality" runat="server"></asp:Label>
                <asp:TextBox ID="nationality" placeholder="Enter User motherland Country name" CssClass="form-control" runat="server"></asp:TextBox>
           <br/>
                <asp:Label Text="Address" runat="server"></asp:Label>
                <asp:TextBox ID="address" TextMode="MultiLine" Columns="30" Rows="3" placeholder="Enter User current address" CssClass="form-control" runat="server"></asp:TextBox>
            </div>

         
               

        <div class="form-group form-inline">
        <asp:PlaceHolder ID="PlaceHolder2" runat="server"></asp:PlaceHolder>
            </div>
       

            <div class="form-group form-inline">
                <asp:Button ID="register__btn" CssClass="btn btn-success" Text="Add this User" runat="server" OnClick="add_user__btn_Click"  />
     
            
                <asp:Label ID="msg1" runat="server" CssClass="warningLbl alert-danger"></asp:Label>
             
                 </div><br/>
         
                 <div runat="server" id="AlertBox" class="alertBox" Visible="false">
    <div runat="server" id="AlertBoxMessage"></div>
    <button onclick="closeAlert.call(this, event)">Ok</button>
</div>
        </asp:Panel> 

                                </div>
            </div>
      
           
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="scripts" Runat="Server">
   
</asp:Content> 