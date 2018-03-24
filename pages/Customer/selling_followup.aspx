<%@ Page Title="Trading" Language="C#" MasterPageFile="~/master/main.master" AutoEventWireup="true" CodeFile="selling_followup.aspx.cs" Inherits="pages_trading_process" %>

<asp:Content ID="Content1" ContentPlaceHolderID="page_head" Runat="Server">

    <style type="text/css">

        b{
            font-family:Coalition;
            font-size:20px;
        }
        h3{
 font-family:'Bleeding Cowboys';
            font-size:40px;

        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pageContent" Runat="Server">
    <h2>
        <a href="javascript:history.go(-1)" onclick="history.go(-1);return false;"> <asp:Button ID="backBtn" CssClass="btn btn-sm btn-info" Text="<< Back" runat="server" /> </a>
                   Sell & Trade</h2>
    <hr />
    <div class="row">


         <div class="col-md-4" id="tradingDetailsDiv">
            <h3>Details & Description:</h3>
         <p style="font-family:TypoSlab_bold_demo;">   <b>ID:</b>   <asp:Label ID="id_lbl" runat="server"></asp:Label><br />
           <b>Image </b> <asp:Image ID="img"  Height="150px" Width="150px" runat="server" /><br />
          <b> Venue: </b> <asp:Label ID="venue_lbl" runat="server"></asp:Label><br />
            <b>Item Name:</b> <asp:Label ID="pc_lbl" runat="server"></asp:Label><br />
          <b>Description:</b>  <asp:Label ID="desc_lbl" runat="server"></asp:Label><br />
          <b> Location: </b> <asp:Label ID="location_lbl" runat="server"></asp:Label><br />
          <b> Posted on:</b>  <asp:Label ID="added_lbl" runat="server"></asp:Label><br />
          <b>posted by:</b>   <asp:Label ID="posted_by" runat="server"></asp:Label><br />
           
              <b>Type:</b> <asp:Label ID="type_lbl" runat="server"></asp:Label><br />
       </p>
              </div>
        <div class="col-md-8" id="tradingStepsDiv">
            <div class="form-group table-responsive">
                <asp:PlaceHolder ID = "trading_ph" runat="server" />
            </div>
        </div>
       
    </div>
    <hr />
    <asp:Label ID="msg" runat="server"></asp:Label>
    <hr />
    <div class="container">      
        <div class="row row-centered">
            <div class="col-md-10 col-centered" id="loginForm">
               <div class="row">
            <div class="form-group center-block">
                <asp:TextBox ID="newTradingStep" CssClass="form-control" Rows="6" Columns="140" placeholder="Write any thing you want to contact with seller/buyer . . ." TextMode="MultiLine" runat="server"></asp:TextBox>
             </div>  
                   <div class="form-group center-block">
             
                <asp:Button ID="submutNewfollowupBtn" Text="Chat with the seller" CssClass="btn btn-primary" runat="server" OnClick="submutNewTradingBtn_Click" Height="50px" Width="400px" />
            <asp:Button ID="payBtn" Text="Purchase this!" CssClass="btn btn-success" runat="server" OnClick="payBtn_Click" Width="400px" Height="50px" />
     
                        </div>
        </div>
                 </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" Runat="Server">
</asp:Content>

