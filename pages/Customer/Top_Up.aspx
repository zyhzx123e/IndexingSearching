<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/master/main.master" CodeFile="Top_Up.aspx.cs" Inherits="pages_Customer_Top_Up" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>



<asp:Content ID="Content1" ContentPlaceHolderID="page_head" Runat="Server">
    <!--

        *****************t

    -->

     <!--init_fade_in-->
<script type="text/javascript" src="js/jquery-1.12.3.js"></script>
   
             <style type="text/css">
.modalBackground
{
    background-color:blueviolet;
    filter:alpha(opacity=70);
    opacity:0.7;
}
     #mp1 
{
    background-color:orange; 
   
}
       .popForm 
{
    background-color:orange; 
   
}
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


    <!---->
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="pageContent" Runat="Server">
    <!--

        *****************t

    -->



    <title>Member Top Up $$</title>
 




         <br/><hr />

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         <img src="../../images/topup.png" /><br />
        <hr />

    <div class="col-md-12">
        Welcom
        <asp:Label ID="Label_name" runat="server"></asp:Label>
        , Your remaining Credits:<asp:Label ID="Label_credits" runat="server"></asp:Label>
       </div>

         <br />
        <br />
        <br />
        <h3>>>  Fill the form below to Top Up Your Balance:<br/></h3>
        
    <asp:Panel ID="topup_panel" runat="server" CssClass="popForm"  align="center" ScrollBars="Vertical" >      
         Top Up-&gt;<br />
        <br /><div class="form-group"> 
        Credit Card/Debit Card Number&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :<asp:TextBox ID="txt_card_num"  CssClass="form-control" placeholder="Your Card Number" runat="server" ></asp:TextBox>
      </div>  <br />

            <div class="form-group">
        3-Digit Secure Number&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :<asp:TextBox ID="txt_3_digit"  CssClass="form-control" placeholder="3 digit code" runat="server"></asp:TextBox>
        </div> 
            
            <br /> <div class="form-group">
        Account Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :<asp:TextBox ID="txt_acct_name" CssClass="form-control" placeholder="Your Account Name" runat="server"></asp:TextBox>
       </div> <br />
                 <div class="form-group">
        Account Number&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :<asp:TextBox ID="txt_acct_num" CssClass="form-control" placeholder="Your Account Number" runat="server" ></asp:TextBox>
    </div>
           <br /> <div class="form-group">
            Bank Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :<asp:TextBox ID="txt_bank_name" CssClass="form-control" placeholder="Your Bank Name" runat="server"></asp:TextBox>
        </div><br /> <div class="form-group">
        Date of Birth&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :<asp:TextBox ID="txt_dob" placeholder="eg. 1996-06-30" CssClass="form-control"  runat="server"></asp:TextBox>
       </div> <br /> <div class="form-group">
        Nationality&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :<asp:TextBox ID="txt_nationality" CssClass="form-control" placeholder="Card Issue Country" runat="server"></asp:TextBox>
        </div><br /> <div class="form-group">
        Card Expiration Date&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :<asp:TextBox ID="txt_expire" CssClass="form-control" placeholder="eg. 09/22 ->year2022,month09" runat="server"></asp:TextBox>
        </div><br />
             <div class="form-group">
        Top Up Amount&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :<asp:TextBox ID="txt_topup" CssClass="form-control" placeholder="Amount to Top up (RM)" runat="server"></asp:TextBox>
      </div>
            
             <br />
        <br /> 
               
        <asp:Button ID="Button1"  runat="server" Text="Top Up" CssClass="center col-md-4 btn btn-success" Height="40px" Width="180px" OnClick="Button1_Click" />
           
       
              <br /> <div class="form-group">
            <asp:Label ID="msg" runat="server"></asp:Label>
            </div>

       </asp:Panel> 

    
   


    </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" Runat="Server">
</asp:Content> 