<%@ Page Title="View Customer" Language="C#" MasterPageFile="~/master/main.master" AutoEventWireup="true" CodeFile="viewCustomerInfo.aspx.cs" Inherits="viewCustomer" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="page_head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pageContent" Runat="Server">
    
     <div class="container">      
        <div class="row row-centered">
            <div class="col-md-11 col-centered" >
               <div class="row">

  <div class="row row-centered" >  <h2>View a Customer Info</h2> </div>
    <hr />


    <div class="form-group form-inline">
        <asp:Label AssociatedControlID="idToFind" Text="Search by ID number(Manually type the User ID)" runat="server" CssClass="col-md-3"></asp:Label>
        <asp:TextBox ID="idToFind" CssClass="form-control" runat="server"></asp:TextBox>
        <asp:Button ID="searchByNameBtn" CssClass="btn btn-primary" Text="Search by Name" runat="server" OnClick="searchByNameBtn_Click"/>
       </div>

   
    <div class="form-group form-inline">
        <asp:Label AssociatedControlID="namesDropList" Text="Report User by Name:" runat="server" CssClass="col-md-3"></asp:Label>
        <asp:DropDownList ID="namesDropList" CssClass="form-control" AutoPostBack="true" runat="server" OnSelectedIndexChanged="namesDropList_SelectedIndexChanged"></asp:DropDownList>
    <asp:Button ID="btn_displayAll" CssClass="btn btn-primary pull-right" Text="Display All Customer Info" runat="server" OnClick="displayAllCustomer"/>
   </div>
   
    <hr />
    <h3>Customer Report:</h3>
   
       <div class="form-group table-responsive">
       <div id="srollableTableDiv" style="height:350px;">
      <rsweb:ReportViewer ID="userReport" runat="server" Width="416px"></rsweb:ReportViewer>
           <asp:Label ID="msg" runat="server"></asp:Label>
       </div>
    

    </div>
       


                    </div>
            </div>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" Runat="Server">
</asp:Content>

