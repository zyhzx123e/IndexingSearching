<%@ Page Title="Service Posting" Language="C#" MasterPageFile="~/master/main.master" AutoEventWireup="true" CodeFile="servicePost.aspx.cs" Inherits="servicePost" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="page_head" Runat="Server">
      <link href="css/login.css" type="text/css" rel="Stylesheet" />

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
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="pageContent" Runat="Server">
  
    <div class="container">      
        <div class="row row-centered">
            <div class="col-md-6 col-centered" id="loginForm">
               <div class="row">
                   <hr /><br /><br />
                   <div class="col-md-12">
                     
                      <h2>  Welcome to the Service Post Page of Search Around You</h2>
                      <hr />
                     
                     <a href="~/pages/Home.aspx" runat="server"> <img src="../../images/login.PNG" class="frontImage" /> </a>
                          
                      <hr />
                     

                            <h3>>>  Click Here to Post a Service:<br/>
                        <asp:Button ID="add_new_service" CssClass="center col-md-4 btn btn-info" Height="100px" Width="320px" Text="Publish new Service" runat="server" Font-Size="XX-Large" ForeColor="Yellow" />
      
                                <br/>


                            </h3>
                       <br/>
             
                       
                       
                       
                       
                     <!--
       modal popup control example referenced from
       https://www.codeproject.com/Articles/34996/ASP-NET-AJAX-Control-Toolkit-ModalPopupExtender-Co
       
       -->  
                       
                       <!--  service-->          
     <cc2:ModalPopupExtender ID="mp1" runat="server" PopupControlID="post_panel" TargetControlID="add_new_service" CancelControlID="btnClose" BackgroundCssClass="modalBackground"></cc2:ModalPopupExtender>
   
    <asp:Panel ID="post_panel" runat="server" CssClass="popForm" style ='display:none' align="center" ScrollBars="Vertical" >      
       <div id="srollableTableDiv" style="width:700px;height:500px;" class="glyphicon-text-color progress-bar-striped">
           
               <h2>Publish your service</h2>
            <hr />
            <div class="form-group center-block">
                <asp:Label Text="Venue" runat="server"></asp:Label>
                <asp:TextBox ID="venueTxt" CssClass="form-control" runat="server"></asp:TextBox>
            </div>

            <div class="form-group center-block">
                <asp:Label Text="Service Name" runat="server"></asp:Label>
                <asp:TextBox ID="service_name" CssClass="form-control" runat="server"></asp:TextBox>
            </div>

            <div class="form-group center-block">
                <asp:Label Text="Location" runat="server"></asp:Label>
                <asp:DropDownList ID="newitemLocation" CssClass="form-control" runat="server"></asp:DropDownList>
            </div>

            <div class="form-group center-block">
                <asp:Label Text="Available time" runat="server"></asp:Label>
                <asp:DropDownList ID="timeList" CssClass="form-control" runat="server"></asp:DropDownList>
            </div>

 <div class="form-group center-block">
                <asp:Label Text="Price(RM)" runat="server"></asp:Label>
                <asp:TextBox  ID="unit_price" CssClass="form-control"  runat="server"></asp:TextBox>
            </div>
            <div class="form-group center-block">
                <asp:Label Text="Description" runat="server"></asp:Label>
                <asp:TextBox TextMode="MultiLine" ID="servicesDescription" CssClass="form-control" Columns="30" Rows="5" runat="server"></asp:TextBox>
            </div>

        <div class="form-group form-inline">
            
                 <asp:Label Text="Browse Item IMAGE " runat="server"></asp:Label>
                <asp:FileUpload ID="FileUpload1"  runat="server" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="FileUpload1" ErrorMessage="show image path"></asp:RequiredFieldValidator>
         
                </div>

            <div class="form-group form-inline">
                <asp:Button ID="submit_item_btn" Height="40px" Width="250px" CssClass="btn btn-primary" Text="Submit" runat="server" OnClick="submit_item_btn_Click" />
                <asp:Button ID="btnClose" runat="server" Height="40px" Width="250px" CssClass="btn btn-info" Text="Cancel" />
            </div>
            <div class="form-group form-inline">
                <asp:Label ID="addServiceLabel" runat="server"></asp:Label>
            </div>    </div>
        </asp:Panel> 
                       <br/> <br/> <br/>
                       <br/>
                      <a href="javascript:history.go(-1)" onclick="history.go(-1);return false;"> <asp:Button ID="backBtn" CssClass="btn btn-sm btn-info" Text="<< Back" runat="server" /> </a>
                    <hr/>
                      <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>

                      <br /> 
                           <asp:Label ID="msg" runat="server" CssClass="warningLbl alert-danger"></asp:Label>
                       <br />

                            
  
                   </div>
               </div>
            </div>
        </div>
    </div>
             

</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="scripts" Runat="Server">
   
</asp:Content>