<%@ Page Title="Manage Your own Goods and Services" Language="C#" MasterPageFile="~/master/main.master" AutoEventWireup="true" CodeFile="manageMyItem.aspx.cs" Inherits="manageFunc" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="pageContent" Runat="Server">
    <h2>Manage Your Goods and Services</h2>
    <hr />
    <div class="row row-centered">
        <asp:Label ID="msg" runat="server"></asp:Label>

        <!--item_id] ,[venue] ,[item_name],[description],[location_id]
      ,[available_time],[date],[status] ,[type],[added_by],[unit_price],[img]-->

        <div runat="server" id="AlertBox" class="alertBox" Visible="false">
                <div runat="server" id="AlertBoxMessage"></div>
                <button onclick="closeAlert.call(this, event)">Ok</button>
            </div>
       
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
        This is Your Selected Item Id to update with&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                :
             <asp:TextBox ID="txt_newItemId" CssClass="form-control alert-info"  runat="server" Enabled="False"></asp:TextBox>
            
                    </div>
          <asp:Button ID="btn_delete"  runat="server" Text="Delete this item by ID" CssClass="center col-md-4 btn btn-danger" Height="40px" Width="180px" OnClick="itemDelete_click" />
      
            
            <br /> <div class="form-group">
        Update this Item with a new Venue&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                :<asp:TextBox ID="txt_newVenue" CssClass="form-control alert-info" placeholder="Item Venue" runat="server"></asp:TextBox>
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