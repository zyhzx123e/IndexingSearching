<%@ Page Title="Manage Goods and Services" Language="C#" MasterPageFile="~/master/main.master" AutoEventWireup="true" CodeFile="manageFunc.aspx.cs" Inherits="manageFunc" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="pageContent" Runat="Server">
    <h2>Manage Goods and Services</h2>
    <hr />
    <div class="row row-centered">
        <asp:Label ID="msg" runat="server"></asp:Label>

        <!--item_id] ,[venue] ,[item_name],[description],[location_id]
      ,[available_time],[date],[status] ,[type],[added_by],[unit_price],[img]-->

        <div runat="server" id="AlertBox" class="alertBox" Visible="false">
                <div runat="server" id="AlertBoxMessage"></div>
                <button onclick="closeAlert.call(this, event)">Ok</button>
            </div>
            <div class="form-group">
        Search by Item ID&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                :<asp:DropDownList ID="txt_itemId" CssClass="form-control alert-info" runat="server"></asp:DropDownList>
        <asp:Button ID="btn_searchId"  runat="server" Text="Search by Item ID" CssClass="center col-md-4 btn btn-primary" Height="40px" Width="180px" OnClick="itemIDsearch_click" />
       <asp:Button ID="btn_delete"  runat="server" Text="Delete this item by ID" CssClass="center col-md-4 btn btn-danger" Height="40px" Width="180px" OnClick="itemDelete_click" />
      
                    </div> 
            
            <br /> <div class="form-group">
        Search by Item Venue&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :<asp:TextBox ID="txt_itemVenue" CssClass="form-control alert-info" placeholder="Item Location" runat="server"></asp:TextBox>
      <asp:Button ID="btn_searchVenue"  runat="server" Text="Search by Item Venue" CssClass="center col-md-4 btn btn-primary" Height="40px" Width="180px" OnClick="itemVenue_click" />
      
                 </div> <br />
                 <div class="form-group">
        Search by Item Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :<asp:TextBox ID="txt_itemName" CssClass="form-control alert-info" placeholder="Item Name" runat="server" ></asp:TextBox>
    <asp:Button ID="btn_searchName"  runat="server" Text="Search by Item Name" CssClass="center col-md-4 btn btn-primary" Height="40px" Width="180px" OnClick="itemName_click" />
       
                      </div><br />
         <div class="form-group">
        Search by Item Description&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :<asp:TextBox ID="txt_description" CssClass="form-control alert-info" placeholder="Item Description" runat="server" ></asp:TextBox>
     <asp:Button ID="btn_searchDescription"  runat="server" Text="Search by Description" CssClass="center col-md-4 btn btn-primary" Height="40px" Width="180px" OnClick="itemDetail_click" />
       
         </div><br />
         <div class="form-group">
        Search by Item Location ID&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
             : <asp:DropDownList ID="txt_location" CssClass="form-control alert-info" runat="server"></asp:DropDownList>
         <asp:Button ID="btn_searchLocation"  runat="server" Text="Search by Location" CssClass="center col-md-4 btn btn-primary" Height="40px" Width="180px" OnClick="itemLocation_click" />
       
              </div><br />
        <div class="form-group">
        Search by Item Available Time&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :
            <asp:DropDownList CssClass="form-control alert-info" ID="availableTime" runat="server">
                          <asp:ListItem Value="morning">Morning</asp:ListItem>
                          <asp:ListItem Value="noon">Noon</asp:ListItem> 
                 <asp:ListItem Value="afternoon">Afternoon</asp:ListItem> 
                 <asp:ListItem Value="night">Night</asp:ListItem> 
                 <asp:ListItem Value="midnight">Midnight</asp:ListItem> 
                  </asp:DropDownList>
             <asp:Button ID="btn_searchTime"  runat="server" Text="Search by Available Time" CssClass="center col-md-4 btn btn-primary" Height="40px" Width="180px" OnClick="itemAvailable_click" />
       
                </div><br />
        <div class="form-group">
       Item or Service?&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
           : <asp:DropDownList CssClass="form-control alert-info" ID="itemType" runat="server">
                          <asp:ListItem Value="s">Services</asp:ListItem>
                          <asp:ListItem Value="g">Goods</asp:ListItem>
                      </asp:DropDownList>
              <asp:Button ID="btn_searchType"  runat="server" Text="Search by Type" CssClass="center col-md-4 btn btn-primary" Height="40px" Width="180px" OnClick="itemType_click" />
       
        </div>
        <br/> <br/>
         <asp:Button ID="btn_all"  runat="server" Text="Display All" CssClass="center col-md-4 btn btn-success" Height="40px" Width="180px" OnClick="populateAll" />
            
        
         <hr/>

        
           <br /> 

         <rsweb:ReportViewer ID="itemReport" runat="server" Width="416px"></rsweb:ReportViewer>
       
        <br/>
        <asp:GridView ID="stuff" runat="server" AutoGenerateColumns="true"  BorderColor="#FF6600" BorderStyle="Solid" Caption="Goods and Services Managament">
    <Columns>
        <asp:BoundField DataField="item_id" HeaderText="Item ID" ItemStyle-Width="150px" />
        <asp:BoundField DataField="venue" HeaderText="Location" ItemStyle-Width="100px" />
        <asp:BoundField DataField="item_name" HeaderText="Item Name" ItemStyle-Width="100px" />
    <asp:BoundField DataField="description" HeaderText="Description" ItemStyle-Width="100px" />
    <asp:BoundField DataField="location_id" HeaderText="Location ID" ItemStyle-Width="100px" />
    <asp:BoundField DataField="available_time" HeaderText="Available Time" ItemStyle-Width="100px" />
    <asp:BoundField DataField="date" HeaderText="Date of Publish" ItemStyle-Width="100px" />
    <asp:BoundField DataField="status" HeaderText="Item Status" ItemStyle-Width="100px" />
    <asp:BoundField DataField="type" HeaderText="Type of Item" ItemStyle-Width="100px" />
    <asp:BoundField DataField="added_by" HeaderText="Added by" ItemStyle-Width="100px" />
    <asp:BoundField DataField="unit_price" HeaderText="Unit Price" ItemStyle-Width="100px" />
    <asp:BoundField DataField="img" HeaderText="Image" ItemStyle-Width="100px" />
    
    
    </Columns>
</asp:GridView>


         <div class="form-group">
        Select an ID to update&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                :<asp:DropDownList ID="txt_newItemId" CssClass="form-control alert-info" runat="server"></asp:DropDownList>
      
                    </div> 
            
            <br /> <div class="form-group">
        Update this Item with a new Venue&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                :<asp:TextBox ID="txt_newVenue" CssClass="form-control alert-info" placeholder="Item Location" runat="server"></asp:TextBox>
      <asp:Button ID="btn_newVenue"  runat="server" Text="Update this Item with new Venue" CssClass="center col-md-4 btn btn-info" Height="40px" Width="250px" OnClick="itemNewVenue_click" />
      
                 </div> <br />
                 <div class="form-group">
        Update Item Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                     :<asp:TextBox ID="txt_newName" CssClass="form-control alert-info" placeholder="Item Name" runat="server" ></asp:TextBox>
    <asp:Button ID="btn_newName"  runat="server" Text="Update this Item with new Name" CssClass="center col-md-4 btn btn-info" Height="40px" Width="250px" OnClick="itemNewName_click" />
       
                      </div><br />
         <div class="form-group">
       Update Item Description&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
              :<asp:TextBox ID="txt_newDetail" CssClass="form-control alert-info" placeholder="Item Description" runat="server" ></asp:TextBox>
     <asp:Button ID="btn_newDetail"  runat="server" Text="Update this Item with new Description" CssClass="center col-md-4 btn btn-info" Height="40px" Width="300px" OnClick="itemNewDetail_click" />
       
         </div><br />
         <div class="form-group">
       Update Item status(sold/processing)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
              : <asp:DropDownList CssClass="form-control alert-info" ID="txt_newStatus" runat="server">
                          <asp:ListItem Value="s">Sold</asp:ListItem>
                          <asp:ListItem Value="p">Processing</asp:ListItem> 
              
                  </asp:DropDownList>
              <asp:Button ID="btn_newStatus"  runat="server" Text="Update this Item with new Description" CssClass="center col-md-4 btn btn-info" Height="40px" Width="300px" OnClick="itemNewStatus_click" />
       
         </div><br />
         <div class="form-group">
        Update Item Location ID&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
             : <asp:DropDownList ID="txt_newLocation" CssClass="form-control alert-info" runat="server"></asp:DropDownList>
         <asp:Button ID="btn_newLocation"  runat="server" Text="Update this Item with new Location" CssClass="center col-md-4 btn btn-info" Height="40px" Width="250px" OnClick="itemNewLocation_click" />
       
              </div><br />
        <div class="form-group">
        Update Item Available Time&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :
            <asp:DropDownList CssClass="form-control alert-info" ID="txt_newAvailable" runat="server">
                          <asp:ListItem Value="morning">Morning</asp:ListItem>
                          <asp:ListItem Value="noon">Noon</asp:ListItem> 
                 <asp:ListItem Value="afternoon">Afternoon</asp:ListItem> 
                 <asp:ListItem Value="night">Night</asp:ListItem> 
                 <asp:ListItem Value="midnight">Midnight</asp:ListItem> 
                  </asp:DropDownList>
             <asp:Button ID="btn_newAvailable"  runat="server" Text="Update the Item with new Available Time" CssClass="center col-md-4 btn btn-info" Height="40px" Width="300px" OnClick="itemNewAvailable_click" />
       
                </div><br />
        <div class="form-group">
       Update Item's Type&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
           : <asp:DropDownList CssClass="form-control alert-info" ID="txt_newType" runat="server">
                          <asp:ListItem Value="s">Services</asp:ListItem>
                          <asp:ListItem Value="g">Goods</asp:ListItem>
                      </asp:DropDownList>
              <asp:Button ID="btn_newType"  runat="server" Text="Update the Item with new Type" CssClass="center col-md-4 btn btn-info" Height="40px" Width="250px" OnClick="itemNewType_click" />
       </div>



    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="scripts" Runat="Server">
</asp:Content> 