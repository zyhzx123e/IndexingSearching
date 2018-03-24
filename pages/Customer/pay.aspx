<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/master/main.master"  CodeFile="pay.aspx.cs" Inherits="pages_Customer_pay" %>


<asp:Content ID="Content1" ContentPlaceHolderID="page_head" Runat="Server">
    <!--


        *****************t

    -->



    <!---->
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="pageContent" Runat="Server">
    <!--

  -->
    <p style="font-family:Coalition">
         <br />  <hr /><br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <img src="../../images/pay.png" />  <br />
      <br />  <hr /><br />
    <div class="col-lg-4 col-lg-4 col-lg-4">
    Hi <asp:Label ID="Label_name" runat="server"></asp:Label>
&nbsp;Welcome to The Paying Page of Searching Around~</div>
     </p>
           <br /><hr /><br />
     <p style="font-family:Calibri">
         <div class="col-lg-4 col-lg-4 col-lg-4">
             Your credit remains: 
             <asp:Label ID="Label_credits" runat="server"></asp:Label>
            <br /><br />
              Your selected item name: 
             <asp:Label ID="item_name" runat="server"></asp:Label>
            
       </p>
              </div>

         <br /><hr /><br />

<asp:Panel ID="pay_panel" runat="server" CssClass="popForm"  align="center" ScrollBars="Vertical" >      
       <p style="font-family:Cambria">
         <div class="col-lg-4 col-lg-4 col-lg-4">

             Your Selected Item-&gt;<br />

             <br />
             <div class="form-group">
          Item Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;   <asp:TextBox ID="txt_item_name" runat="server"  CssClass="form-control" ReadOnly="True"></asp:TextBox>
                 </div>


             <br />



             <br /><div class="form-group">
             Item Available Venue&nbsp;&nbsp; <asp:TextBox ID="txt_item_venue" runat="server"  CssClass="form-control" ReadOnly="True"></asp:TextBox>
                 </div>


             <br />



             <br /><div class="form-group">
             Item Description&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txt_item_description" TextMode="multiline" runat="server" Enabled="False" CssClass="form-control bg-info"  Width="300px" Rows="5"></asp:TextBox>
           </div>  <br />
             <br /><div class="form-group">
             Item Unit Price&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txt_item_unit_price" runat="server"  CssClass="form-control" ReadOnly="True"></asp:TextBox>
</div>


             <br />
             <br /><div class="form-group">
             Owner Available Time <asp:TextBox ID="txt_item_available" runat="server"  CssClass="form-control" ReadOnly="True"></asp:TextBox>
</div>


             <br />



             <br /><div class="form-group">
             Owner ID&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txt_item_owner" runat="server"  CssClass="form-control"  ReadOnly="True"></asp:TextBox>
                 </div>


             <br />



             <br /><div class="form-group">
             Quantity&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txt_item_quantity"  CssClass="form-control" placeholder="Item Quantity" runat="server"></asp:TextBox>
             </div>
           

             <br />
             <br /><div class="form-group">
             <asp:Button ID="Button1" runat="server" Text="Pay" CssClass="center col-md-4 btn btn-warning" Height="40px" Width="329px" OnClick="Button1_Click" />
            </div> <br />
             <br />
             <br />
             <asp:PlaceHolder ID="servicesCounts_ph" runat="server"></asp:PlaceHolder>
             <br />
             <asp:Label ID="msg" runat="server"></asp:Label>



             </div>
         <br /><hr /><br /> </p>
      </asp:Panel> 


    </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" Runat="Server">
</asp:Content> 