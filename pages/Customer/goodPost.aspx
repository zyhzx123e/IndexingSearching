<%@ Page Title="Goods Posting" Language="C#" MasterPageFile="~/master/main.master" AutoEventWireup="true" CodeFile="goodPost.aspx.cs" Inherits="goodPost" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="control" %>
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
                     
                      <h2>  Welcome to the Goods Posting Page of Search Around You</h2>
                      <hr />
                      <a href="~/pages/Home.aspx" runat="server"> 
                      <img src="../../images/login.PNG" class="frontImage" />
                           </a>
                      <hr />
                     

                            <h3>>>  Click Here to Post your Good:<br/>
                         
                                <br/>


                            </h3>
                       <br/>
       <asp:Panel ID="add_new_good_panel" runat="server" CssClass="popForm"  align="center" Width="900px">      
            <h2>Publish Your Good</h2>
            <hr />

            <div class="form-group center-block">
                <asp:Label Text="Item Name" runat="server"></asp:Label>
                <asp:TextBox ID="item_name" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="form-group center-block">
                <asp:Label Text="Venue/place" runat="server"></asp:Label>
                <asp:TextBox ID="goodVenue" CssClass="form-control" runat="server"></asp:TextBox>
            </div>

            <div class="form-group center-block">
                <asp:Label Text="Location" runat="server"></asp:Label>
                <asp:DropDownList ID="newGoodLocation" CssClass="form-control" runat="server"></asp:DropDownList>
            </div>

            <div class="form-group center-block">
                <asp:Label Text="Available time" runat="server"></asp:Label>
                <asp:DropDownList ID="goodtimeList" CssClass="form-control" runat="server"></asp:DropDownList>
            </div>

             <div class="form-group center-block">
                <asp:Label Text="Price(RM)" runat="server"></asp:Label>
                <asp:TextBox  ID="goodunit_price" CssClass="form-control"  runat="server"></asp:TextBox>
            </div>

            <div class="form-group center-block">
                <asp:Label Text="Description" runat="server"></asp:Label>
                <asp:TextBox TextMode="MultiLine" ID="newGoodDescription" CssClass="form-control" Columns="30" Rows="5" runat="server"></asp:TextBox>
            </div>
            <div class="form-group center-block">
            
                 <asp:Label Text="Browse Item IMAGE " runat="server"></asp:Label>
                <asp:FileUpload ID="FileUpload2"  runat="server" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="FileUpload2" ErrorMessage="show image path"></asp:RequiredFieldValidator>
         
                </div>
            <div class="form-group center-block">
                <asp:Button ID="Button1" CssClass="btn col-md btn-primary" Text="Submit" Height="40px" Width="250px" runat="server" OnClick="submit_item_btn_Click" />
                <asp:Button ID="Button2" runat="server" CssClass="btn col-md btn-info" Height="40px" Width="250px" Text="Cancel" />
            </div>
        </asp:Panel>
             
                       
                       
                        
                        <!--
       modal popup control example referenced from
       https://www.codeproject.com/Articles/34996/ASP-NET-AJAX-Control-Toolkit-ModalPopupExtender-Co
       
       -->
                        <!--  good
                        <control:ModalPopupExtender ID="modal" runat="server" PopupControlID="add_new_good_panel" TargetControlID="add_new_good" CancelControlID="btnClose" BackgroundCssClass="modalBackground"></control:ModalPopupExtender>
    <asp:Button ID="add_new_good" CssClass="center col-md-4 btn btn-success" Height="100px" Width="300px" Text="Publish new Good" runat="server" Font-Size="XX-Large" ForeColor="Orange" />
    
                            
                               -->  
    
                       
                  
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
    <script>
        $(document).ready(function () {
            $('#service_dashboard').fadeIn(6000);
            //$("#SearchDiv").hide();
            $("#locationVenue").hide();
            $("#trading_process").hide();
            $("#topTrading").hide();
            $("#dealed").hide();

        });

        function hideDiv(name) {
            $("#" + name).toggle(function () { });

            //$("#" + name + "_span").attr('class', 'glyphicon glyphicon-chevron-down');

        }




        $(function () {
            $(".datepicker").datepicker({ dateFormat: 'yy-mm-dd' });
        });



    </script>
</asp:Content>
