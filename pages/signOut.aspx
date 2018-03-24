<%@ Page Title="Sign Out" Language="C#" MasterPageFile="~/master/base.master" AutoEventWireup="true" CodeFile="signOut.aspx.cs" Inherits="signOut" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="userMenuContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content" Runat="Server">



     <div class="container">      
        <div class="row row-centered">
            <div class="col-md-6 col-centered" id="loginForm">
               <div class="row">
                   <br /><br />
                   <div class="col-md-12">
    <div style="margin: 0 auto; text-align:center;" class="row">
        <div style="margin: 0 auto; border:5px solid black;margin-top:5px;width:750px;text-align:center;" class="col-md-12">
            <h3>Here is the place you can search anything around you</h3></center>
            <hr />
            <p>Login to have the journey -> <a href="~/pages/login.aspx" runat="server"> <asp:Button ID="loginBTN" CssClass="btn btn-success" Text="Login Now!" runat="server" OnClick="register__btn_Click" />
              </a>.</p>
            <p>Search aroun you</p>
        </div>
    </div>



                       
                   </div>
               </div>
            </div>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="pageScripts" Runat="Server">
</asp:Content> 