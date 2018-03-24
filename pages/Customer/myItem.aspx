<%@ Page Title="My Item" Language="C#" MasterPageFile="~/master/main.master" AutoEventWireup="true" CodeFile="myItem.aspx.cs" Inherits="goods" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="control" %>

<asp:Content ID="Content1" ContentPlaceHolderID="page_head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pageContent" Runat="Server">
  <div class="row row-centered">
            <div class="col-md-12 col-centered" id="loginForm">
               <div class="row">  <h2>Manage Your Goods</h2></div></div>

  </div>

    <hr />
    <div class="row">
        <div class="col-lg-6">
         
            
              <asp:Label ID="msg" runat="server"></asp:Label>
        </div>
        <div class="col-lg-6">
           
        </div>
    </div>
        
    <div class="form-group table-responsive ">
      

           
          <div id="srollableTableDiv" class="glyphicon-text-color progress-bar-striped">
           
              <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
             
    <asp:PlaceHolder ID="good_ph" runat="server"></asp:PlaceHolder>
            <asp:Timer ID="Timer1" runat="server" Interval="1000" OnTick="populate_goods"></asp:Timer>
        </ContentTemplate>
</asp:UpdatePanel>

        </div>         
    </div>

       <style type="text/css">
 .modalBackground
{
    background-color:gray;
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
   </style>
   
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" Runat="Server">

</asp:Content>

