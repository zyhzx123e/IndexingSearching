<%@ Page Title="Services" Language="C#" MasterPageFile="~/master/main.master" AutoEventWireup="true" CodeFile="Services.aspx.cs" Inherits="pages_services" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="page_head" Runat="Server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pageContent" Runat="Server">
     <div class="row row-centered">
            <div class="col-md-12 col-centered" >
            <h2>Find Your Services</h2></div>

     </div>
       <hr />

       <div class="row">
           <br /><br /><br />
            <div class="col-lg-7">
                <asp:Button ID="add_new_service" runat="server" CssClass="btn btn-primary" Text="Post Your Services" OnClick="add_new_service_Click"  Height="50px" />
                <asp:Label ID="msg" runat="server"></asp:Label>
            </div>
          
            <div class="col-lg-5">
                <div class="form-group form-inline">
                    <asp:DropDownList ID="location_list" CssClass="form-control alert-success" runat="server" AutoPostBack="true" OnSelectedIndexChanged="location_list_SelectedIndexChanged" Width="500px" Height="50px"></asp:DropDownList>
                
                
                </div>  
           </div>
       </div>
        
        <div class="form-group table-responsive glyphicon-text-color progress-bar-info">


         
           

                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            
    <asp:PlaceHolder ID="services_ph" runat="server"></asp:PlaceHolder>
          
            <asp:Timer ID="Timer1" runat="server" Interval="1000" OnTick="populate_items"></asp:Timer>
        </ContentTemplate>
</asp:UpdatePanel>
                   
        </div>

        
       
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
       </style>


        
        <div class="row">
            <div class="col-md-4">
                
            </div>
            <div class="col-md-8">
            </div>
        </div>
        
       
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" Runat="Server">

</asp:Content>

