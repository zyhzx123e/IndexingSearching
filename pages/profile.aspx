<%@ Page Title="My Profile" Language="C#" MasterPageFile="~/master/main.master" AutoEventWireup="true" CodeFile="profile.aspx.cs" Inherits="profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="page_head" Runat="Server">
          <link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="pageContent" Runat="Server">
          <link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css">
   <script type="text/javascript" src="js/jquery-1.12.3.js"></script>
    
    <hr />
   

    
                   <br /><br />
         <div class="container">      
        <div class="row row-centered">
            <div class="col-md-12 col-centered" >
               <div class="row">        
                       <h2>My Profile</h2>
                   <hr />
         <p style="font-family:Coalition"> 
            <!--
                Total items  that have published  for  within specific period of time
                 -->
          
            <div class="form-group">
        <p style="font-family:Coalition">Full Name:</p>
                <asp:label ID="name" runat="server">test</asp:label>
                 <asp:Label AssociatedControlID="address" runat="server">Address</asp:Label>
                <asp:TextBox TextMode="MultiLine" Rows="4" ID="address" CssClass="form-control" runat="server"></asp:TextBox>
           
            </div>

             <div class="form-horizontal pull-right">
                <asp:Label runat="server"  AssociatedControlID="privateEmail">Private email</asp:Label>
                <asp:TextBox ID="privateEmail" TextMode="Email" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
             <br/>
            <div class="form-group ">
           <p style="font-family:Coalition">      Position: </p>
                <asp:label ID="position_id" runat="server"></asp:label>
            </div>

             <div class="form-horizontal pull-right">
           <p style="font-family:Coalition">Date of Registration : </p>
                <asp:label ID="member_date_lb" runat="server"></asp:label>
            </div> 
              <div class="form-group">
                <b> <p style="font-family:Coalition">You have dealed totally  </p></b>    <asp:label ID="items" runat="server"></asp:label>deals till now        
            </div> 

            

            <div class="form-group">
              <p style="font-family:Coalition">   Your ID Number: </p>
                <asp:label ID="id_number" runat="server"></asp:label>
            </div>


             <div class="form-group pull-right">
                <em><b> <p style="font-family:Coalition">Your total items that have been sold </p></b></em> from      
               <span>  <asp:TextBox ID="item_countfromDate" placeholder="From" CssClass="datepicker form-control" runat="server" Width="120px"></asp:TextBox>
                       to<asp:TextBox ID="item_counttoDate" placeholder="To" CssClass="datepicker form-control" runat="server" Width="120px"></asp:TextBox> &nbsp; :  <asp:label ID="item_count_label" runat="server"></asp:label>
       <asp:Button ID="item_count_btn" CssClass="btn btn-block" Text="Display item sold count" runat="server"  Width="170px" OnClick="item_count_btn_Click" />
          </span>       
            </div> 




           
            
            <div class="form-group form-inline">
                <asp:Label runat="server"  AssociatedControlID="contactNumber">Contact Number</asp:Label>
                <asp:TextBox ID="contactNumber" TextMode="Number" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            

            <div class="form-group">
               <p style="font-family:Coalition">  Date of birth: </p>
                <asp:label ID="dob" runat="server"></asp:label>
            </div>
       
            

         
            <div class="form-group">
              <p style="font-family:Coalition">Sales Achievements </p>
                <asp:label ID="achievements" runat="server"></asp:label>
            </div> 

            
               
     
            <br /><br /><br /><br />
             </p>
            
                   
                   <div class="form-group">
                <asp:Button Text="Save" ID="save_btn" CssClass="btn btn-default" runat="server" OnClick="save_btn_Click" />
                <asp:Label ID="msg" runat="server"></asp:Label>
            </div>
             
             
              
            </div>
        </div>
    </div>
    
</div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="scripts" Runat="Server">
    <script>
       
        $(function () {
            $(".datepicker").datepicker({ dateFormat: 'yy-mm-dd' });
        });



    </script>
</asp:Content>

 